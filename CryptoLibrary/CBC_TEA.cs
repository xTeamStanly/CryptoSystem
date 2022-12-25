using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLibrary;

namespace CryptoLibrary {
    public class CBC_TEA {
        private TEA tea = null;
        private uint[] init_vector = null;

        private uint[] IV_key = null;

        private void setup(string tea_key, uint[] init_vector) {
            tea = new TEA(tea_key);
            this.init_vector = init_vector;

            IV_key = new uint[2];
        }

        public CBC_TEA(string tea_key, string init_vector_string) {
            uint[] init_vector = Utility.unicode_to_uint_array(init_vector_string, 2); // todo check padding!!
            setup(tea_key, init_vector);
        }

        public CBC_TEA(string tea_key, uint[] init_vector) {
            setup(tea_key, init_vector);
        }

        public void Encrypt(ref uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }

            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            // CBC_TEA state setup
            Array.Copy(init_vector, IV_key, 2);

            // CBC_TEA rounds
            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] input = new uint[2];
                input[0] = data[i] ^ IV_key[0];
                input[1] = data[i + 1] ^ IV_key[1];

                tea.encrypt_one_cycle(input);

                data[i] = input[0];
                data[i + 1] = input[1];

                Array.Copy(input, IV_key, 2);
            }
        }

        public void Decrypt(uint[] data) {
            if (data == null) { throw new Exception("invalid input"); }

            int data_lenght = data.Length;
            if (data_lenght == 0) { throw new Exception("invalid input"); }

            // CBC_TEA state setup
            Array.Copy(init_vector, IV_key, 2);

            // CBC_TEA rounds
            for (int i = 0 ; i < data.Length ; i += 2) {
                uint[] input = new uint[2];
                input[0] = data[i];
                input[1] = data[i + 1];

                uint[] input_copy = new uint[2];
                Array.Copy(input, input_copy, 2);

                tea.decrypt_one_cycle(input);

                data[i] = input[0] ^ IV_key[0];
                data[i + 1] = input[1] ^ IV_key[1];
                
                Array.Copy(input_copy, IV_key, 2);
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
