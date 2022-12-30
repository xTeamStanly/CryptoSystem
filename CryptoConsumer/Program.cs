using Library.Crypto;
using System;
using System.Collections;
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

            //CRC crc = new CRC("11011001101011101010110");
            //byte[] crcinput = new byte[] { 0xAA, 0xBB };
            //ulong crcoutput = crc.Checksum(crcinput);

            // BitArray barr = CRC.unicode_poynomial_to_bitarray("1100000");

            // CRC crc = new CRC("01010100110010101");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
