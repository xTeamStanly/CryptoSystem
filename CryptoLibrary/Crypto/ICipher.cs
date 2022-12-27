using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public interface ICipher {
        // ################ FILES ################
        byte[] EncryptFile(byte[] input);
        byte[] DecryptFile(byte[] input);
        void EncryptFile(string inputpath, string outputpath);
        void DecryptFile(string inputpath, string outputpath);

        byte[] EncryptBitmap(byte[] input);
        byte[] DecryptBitmap(byte[] input);
        void EncryptBitmap(string inputpath, string outputpath);
        void DecryptBitmap(string inputpath, string outputpath);

        string[] EncryptText(string[] input);
        string[] DecryptText(string[] input);
        void EncryptText(string inputpath, string outputpath);
        void DecryptText(string inputpath, string outputpath);

        // ################ TEXTBOX ################
        string EncryptPlaintext(string input);
        string DecryptPlaintext(string input);
    }
}
