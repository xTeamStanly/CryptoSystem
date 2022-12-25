using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CryptoLibrary;
namespace CryptoLibrary {
    public class TEA {
        private readonly static uint delta_const = 0x9E3779B9;
        private readonly static uint sum_const = 0xC6EF3720;    // (delta_const << 5) & 0xFFFFFFFF

        private uint[] key;
        public uint[] Key {
            get { return key; }
        }

        public TEA(string input_key) {
            if (input_key == null) { throw new ArgumentNullException("invalid key"); }

            // 128b = char (8b) * 16
            if (input_key.Length != 16) { throw new ArgumentException("invalid key"); }

            key = Utility.unicode_to_tea_key(input_key);
        }

        public void encrypt_one_cycle(uint[] v) {
            uint v0 = v[0];
            uint v1 = v[1];
            uint sum = 0;
            uint i;

            uint k0 = key[0];
            uint k1 = key[1];
            uint k2 = key[2];
            uint k3 = key[3];

            for (i = 0 ; i < 32 ; i++) {
                sum += delta_const;
                v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            }

            v[0] = v0;
            v[1] = v1;
        }

        public void decrypt_one_cycle(uint[] v) {
            uint v0 = v[0];
            uint v1 = v[1];
            uint sum = sum_const;
            uint i;

            uint k0 = key[0];
            uint k1 = key[1];
            uint k2 = key[2];
            uint k3 = key[3];

            for (i = 0 ; i < 32 ; i++) {
                v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
                v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                sum -= delta_const;
            }

            v[0] = v0;
            v[1] = v1;
        }

        public void Encrypt(ref uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }
            
            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = data[i];
                arr[1] = data[i + 1]; 

                encrypt_one_cycle(arr);

                data[i] = arr[0];
                data[i + 1] = arr[1];
            }
        }

        public void Decrypt(uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }

            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] arr = new uint[2];
                arr[0] = data[i];
                arr[1] = data[i + 1];
                
                decrypt_one_cycle(arr);

                data[i] = arr[0];
                data[i + 1] = arr[1];
            }
        }
    
        public byte[] encrypt_bytes_to_bytes(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Encrypt(ref data);
            return Utility.unsigned_array_to_byte_array(data);
        }
        public string encrypt_bytes_to_unicode(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Encrypt(ref data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public string encrypt_unicode_to_unicode(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return encrypt_bytes_to_unicode(input_bytes);
        }
        public byte[] encrypt_unicode_to_bytes(string input) {
            byte[] input_bytes = Utility.get_bytes_from_unicode(input);
            return encrypt_bytes_to_bytes(input_bytes);
        }

        public byte[] decrypt_bytes_to_bytes(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_byte_array(data);
        }
        public string decrypt_bytes_to_unicode(byte[] input) {
            uint[] data = Utility.byte_array_to_unsigned_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public string decrypt_unicode_to_unicode(string input) {
            uint[] data = Utility.unicode_to_uint_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_unicode(data);
        }
        public byte[] decrypt_unicode_to_bytes(string input) {
            uint[] data = Utility.unicode_to_uint_array(input, 2);
            Decrypt(data);
            return Utility.unsigned_array_to_byte_array(data);
        }


        // bitmap
        public void encrypt_bitmap_file_from_path(string inputpath, string outputpath) {
            byte[] input_image = Utility.open_file_to_bytes(inputpath);
            int input_image_length = input_image.Length;

            int end_of_header_position = input_image[10] + 256 * (input_image[11] + 256 * (input_image[12] + 256 * input_image[13]));

            // samo informacije o pikselima
            byte[] input_image_pixels = new byte[input_image_length - end_of_header_position];
            // preskocili smo header i kopiramo samo informacije o pikselima
            Array.Copy(input_image, end_of_header_position, input_image_pixels, 0, input_image_pixels.Length);

            input_image_pixels = encrypt_bytes_to_bytes(input_image_pixels);

            // moze da se desi da je slika previse mala pa mora da se padduje, primer 1x1 slika
            // u takvom slucaju slika nece biti iste velicine kao originalna, nego za 4 bajta veca
            // ti bajtovi su 0x00 (padding)
            byte[] output_image = new byte[end_of_header_position + input_image_pixels.Length];
            Array.Copy(input_image, 0, output_image, 0, end_of_header_position); // kopiramo header
            Array.Copy(input_image_pixels, 0, output_image, end_of_header_position, input_image_pixels.Length); // kopiramo data bez hedera

            Utility.write_bytes_to_file(outputpath, output_image);
        }
        public void decrypt_bitmap_file_from_path(string inputpath, string outputpath) {
            byte[] input_image = Utility.open_file_to_bytes(inputpath);
            int input_image_length = input_image.Length;

            int end_of_header_position = input_image[10] + 256 * (input_image[11] + 256 * (input_image[12] + 256 * input_image[13]));

            // samo informacije o pikselima
            byte[] input_image_pixels = new byte[input_image_length - end_of_header_position];
            // preskocili smo header i kopiramo samo informacije o pikselima
            Array.Copy(input_image, end_of_header_position, input_image_pixels, 0, input_image_pixels.Length);

            input_image_pixels = decrypt_bytes_to_bytes(input_image_pixels);

            byte[] output_image = new byte[input_image_length];
            Array.Copy(input_image, 0, output_image, 0, end_of_header_position); // kopiramo header
            Array.Copy(input_image_pixels, 0, output_image, end_of_header_position, input_image_pixels.Length); // kopiramo data bez hedera

            Utility.write_bytes_to_file(outputpath, output_image);
        }
        public byte[] encrypt_bitmap_from_bytes(byte[] input_image) {
            if (input_image == null) { throw new Exception("invalid input"); }
            if (input_image.Length == 0) { throw new Exception("invalid input"); }

            int input_image_length = input_image.Length;

            int end_of_header_position = input_image[10] + 256 * (input_image[11] + 256 * (input_image[12] + 256 * input_image[13]));

            // samo informacije o pikselima
            byte[] input_image_pixels = new byte[input_image_length - end_of_header_position];
            // preskocili smo header i kopiramo samo informacije o pikselima
            Array.Copy(input_image, end_of_header_position, input_image_pixels, 0, input_image_pixels.Length);

            input_image_pixels = encrypt_bytes_to_bytes(input_image_pixels);

            // moze da se desi da je slika previse mala pa mora da se padduje, primer 1x1 slika
            // u takvom slucaju slika nece biti iste velicine kao originalna, nego za 4 bajta veca
            // ti bajtovi su 0x00 (padding)
            byte[] output_image = new byte[end_of_header_position + input_image_pixels.Length];
            Array.Copy(input_image, 0, output_image, 0, end_of_header_position); // kopiramo header
            Array.Copy(input_image_pixels, 0, output_image, end_of_header_position, input_image_pixels.Length); // kopiramo data bez hedera

            return output_image;
        }
        public byte[] decrypt_bitmap_from_bytes(byte[] input_image) {
            if (input_image == null) { throw new Exception("invalid input"); }
            if (input_image.Length == 0) { throw new Exception("invalid input"); }

            int input_image_length = input_image.Length;

            int end_of_header_position = input_image[10] + 256 * (input_image[11] + 256 * (input_image[12] + 256 * input_image[13]));

            // samo informacije o pikselima
            byte[] input_image_pixels = new byte[input_image_length - end_of_header_position];
            // preskocili smo header i kopiramo samo informacije o pikselima
            Array.Copy(input_image, end_of_header_position, input_image_pixels, 0, input_image_pixels.Length);

            input_image_pixels = decrypt_bytes_to_bytes(input_image_pixels);

            // moze da se desi da je slika previse mala pa mora da se padduje, primer 1x1 slika
            // u takvom slucaju slika nece biti iste velicine kao originalna, nego za 4 bajta veca
            // ti bajtovi su 0x00 (padding)
            byte[] output_image = new byte[end_of_header_position + input_image_pixels.Length];
            Array.Copy(input_image, 0, output_image, 0, end_of_header_position); // kopiramo header
            Array.Copy(input_image_pixels, 0, output_image, end_of_header_position, input_image_pixels.Length); // kopiramo data bez hedera

            return output_image;
        }
    }
}
