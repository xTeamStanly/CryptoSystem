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

            TEA teaimg = new TEA("vZQS2MEkE-Z%R$PK");
            teaimg.encrypt_bitmap_file_from_path(@"C:\Users\Stanko\Desktop\bitmap\original.bmp", @"C:\Users\Stanko\Desktop\bitmap\encrypted.bmp");
            teaimg.decrypt_bitmap_file_from_path(@"C:\Users\Stanko\Desktop\bitmap\encrypted.bmp", @"C:\Users\Stanko\Desktop\bitmap\decrypted.bmp");


            






            //TEA tea = new TEA("vZQS2MEkE-Z%R$PK");

            //byte[] inputerino = Utility.get_bytes_from_unicode("dorojutro");
            //byte[] xddd = tea.encrypt_bytes_to_bytes(inputerino);

            //string idkmen = tea.decrypt_bytes_to_unicode(xddd);

            //string inputfile = @"C:\Users\Stanko\Desktop\enc\lipsum_input";
            //string outputfile = @"C:\Users\Stanko\Desktop\enc\lipsum_output";
            //string tempfile = @"C:\Users\Stanko\Desktop\enc\lipsum_temp";

            //byte[] open_bytes = Utility.open_file_to_bytes(inputfile);
            //byte[] modified_bytes = tea.encrypt_bytes_to_bytes(open_bytes);

            //Utility.write_bytes_to_file(outputfile, modified_bytes);



            //open_bytes = Utility.open_file_to_bytes(outputfile);
            //modified_bytes = tea.decrypt_bytes_to_bytes(open_bytes);

            //Utility.write_bytes_to_file(tempfile, modified_bytes);

            //bool little = BitConverter.IsLittleEndian;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
