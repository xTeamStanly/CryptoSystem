using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoConsumer {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            TEA tea = new TEA("vZQS2MEkE-Z%R$PK");
            string res = tea.encrypt_unicode_to_unicode("BRUH");
            // string ress = Encoding.ASCII.GetString(res);

            // TEA tea = new TEA("vZQS2MEkE-Z%R$PK");
            // tea.encrypt_bitmap_file_from_path(@"C:\Users\Stanko\Desktop\bitmap\original.bmp", @"C:\Users\Stanko\Desktop\bitmap\encrypted.bmp");
            // tea.decrypt_bitmap_file_from_path(@"C:\Users\Stanko\Desktop\bitmap\encrypted.bmp", @"C:\Users\Stanko\Desktop\bitmap\decrypted.bmp");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
