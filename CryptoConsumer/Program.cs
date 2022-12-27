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

            // RC4 a = new RC4("1234");
            // string asd = a.encrypt_unicode_to_unicode("a");


            // Library.Convertor.unicode_to_bytes("");

            //CBC_TEA cbc = new CBC_TEA("vZQS2MEkE-Z%R$PK", "1");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
