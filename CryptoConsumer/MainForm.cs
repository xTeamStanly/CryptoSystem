using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CryptoLibrary;
using CryptoLibrary.RC4;

namespace CryptoConsumer {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {

            //RC4 rc4 = new RC4(new byte[] { 0x52, 0x43, 0x34 });
            //byte[] output = rc4.Encrypt(new byte[] { 0x64, 0x43, 0x6F, 0x64, 0x65 });


            //int a = 0;

            // bool validrotor = Utility.valid_rotor_configuration("ABCDEFG         QRSTUVWXYZ");

            var x = Utility.plug_board_configuration_string_to_dictionary("  PO ML IU   KJ NH YT GB VF       RE DC     ");

            int a = 0;
        }
    }
}
