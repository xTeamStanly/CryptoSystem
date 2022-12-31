using CryptoConsumer.Forms;
using Library;
using System;
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

        RC4Form rc4_form = null;
        EnigmaForm enigma_form = null;
        TEAForm tea_form = null;
        CBCForm cbc_form = null;
        CRCForm crc_form = null;

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

        // ################################ ENIGMA ################################
        public void close_enigma_form(bool call_from_child_form) {
            enigma_visible = false;
            if (call_from_child_form == false) {
                if (enigma_form != null) { enigma_form.Close(); }
            } else {
                GUI.SetColor(enigma_button, enigma_visible);
            }
        }
        private void control_panel_enigma_button_Click(object sender, EventArgs e) {
            enigma_visible = !enigma_visible;
            GUI.SetColor(enigma_button, enigma_visible);

            if (enigma_visible == true) {
                enigma_form = new EnigmaForm(this, cryptoProvider);
                enigma_form.Show();
            } else {
                close_enigma_form(false);
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

        // ################################ CBC ################################
        public void close_cbc_form(bool call_from_child_form) {
            cbc_visible = false;
            if (call_from_child_form == false) {
                if (cbc_form != null) { cbc_form.Close(); }
            } else {
                GUI.SetColor(cbc_button, cbc_visible);
            }
        }
        private void cbc_button_Click(object sender, EventArgs e) {
            cbc_visible = !cbc_visible;
            GUI.SetColor(cbc_button, cbc_visible);

            if (cbc_visible == true) {
                cbc_form = new CBCForm(this, cryptoProvider);
                cbc_form.Show();
            } else {
                close_cbc_form(false);
            }
        }

        // ################################ CRC ################################
        public void close_crc_form(bool call_from_child_form) {
            crc_visible = false;
            if (call_from_child_form == false) {
                if (crc_form != null) { crc_form.Close(); }
            } else {
                GUI.SetColor(crc_button, crc_visible);
            }
        }
        private void crc_button_Click(object sender, EventArgs e) {
            crc_visible = !crc_visible;
            GUI.SetColor(crc_button, crc_visible);

            if (crc_visible == true) {
                crc_form = new CRCForm(this, cryptoProvider);
                crc_form.Show();
            } else {
                close_crc_form(false);
            }
        }

        private void hide_all_buton_Click(object sender, EventArgs e) {
            if (rc4_form != null) { rc4_form.Close(); }
            if (tea_form != null) { tea_form.Close(); }
            if (cbc_form != null) { cbc_form.Close(); }
            if (crc_form != null) { crc_form.Close(); }
            if (enigma_form != null) { enigma_form.Close(); }
        }
    }
}
