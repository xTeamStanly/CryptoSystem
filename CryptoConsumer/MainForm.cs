using CryptoConsumer.Forms;
using Library;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CryptoConsumer {
    public partial class MainForm : Form {

        
        private CryptoServiceReference.ICryptoProvider cryptoProvider = null;
        
        public MainForm() {
            InitializeComponent();
            cryptoProvider = new CryptoServiceReference.CryptoProviderClient();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            GUI.SetColor(rc4_button, false);
            GUI.SetColor(enigma_button, false);
            GUI.SetColor(tea_button, false);
            GUI.SetColor(cbc_button, false);
            GUI.SetColor(crc_button, false);
        }

        private bool rc4_visible = false;
        private bool enigma_visible = false;
        private bool tea_visible = false;
        private bool cbc_visible = false;
        private bool crc_visible = false;

        // todo list form objects
        RC4Form rc4_form = null;
        TEAForm tea_form = null;




        // ################################ RC4 ################################
        public void close_rc4_form(bool call_from_child_form) {
            rc4_visible = false;
            if (call_from_child_form == false) {
                if (rc4_form != null) { rc4_form.Close(); }
            } else {
                GUI.SetColor(rc4_button, rc4_visible);
            }
        }
        private void control_panel_rc4_button_Click(object sender, EventArgs e) {
            rc4_visible = !rc4_visible;
            GUI.SetColor(rc4_button, rc4_visible);

            if (rc4_visible == true) {
                rc4_form = new RC4Form(this, cryptoProvider);
                rc4_form.Show();
            } else {
                close_rc4_form(false);
            }
        }

        // ################################ TEA ################################
        public void close_tea_form(bool call_from_child_form) {
            tea_visible = false;
            if (call_from_child_form == false) {
                if (tea_form != null) { tea_form.Close(); }
            } else {
                GUI.SetColor(tea_button, tea_visible);
            }
        }
        private void control_panel_tea_button_Click(object sender, EventArgs e) {
            tea_visible = !tea_visible;
            GUI.SetColor(tea_button, tea_visible);

            if (tea_visible == true) {
                tea_form = new TEAForm(this, cryptoProvider);
                tea_form.Show();
            } else {
                close_tea_form(false);
            }
        }

        // ################################ TODO ################################




        private void control_panel_enigma_button_Click(object sender, EventArgs e) {
            enigma_visible = !enigma_visible;
            GUI.SetColor(enigma_button, enigma_visible);
        }

        

        private void cbc_button_Click(object sender, EventArgs e) {
            cbc_visible = !cbc_visible;
            GUI.SetColor(cbc_button, cbc_visible);
        }

        private void crc_button_Click(object sender, EventArgs e) {
            crc_visible = !crc_visible;
            GUI.SetColor(crc_button, crc_visible);
        }

        // todo
        private void hide_all_buton_Click(object sender, EventArgs e) {
            if (rc4_form != null) { rc4_form.Close(); }
            if (tea_form != null) { tea_form.Close(); }








        }





        private void handler_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
