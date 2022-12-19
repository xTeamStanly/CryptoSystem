using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using CryptoLibrary;
using CryptoLibrary.Enigma;
using CryptoLibrary.RC4;
using CryptoProvider;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CryptoConsumer {
    public partial class MainForm : Form {

        CryptoProviderServiceReference.ICryptoProvider cryptoProvider = null;
        private EnigmaState default_enigma_state = new EnigmaState {
            I_Key = 1, I_Rotor_Configuration = "EKMFLGDQVZNTOWYHXUSPAIBRCJ", I_Rotor_Turnover_Letter = 'Q',
            II_Key = 1, II_Rotor_Configuration = "BDFHJLCPRTXVZNYEIWGAKMUSQO", II_Rotor_Turnover_Letter = 'V',
            III_Key = 1, III_Rotor_Configuration = "AJDKSIRUXBLHWTMCQGZNPYFVOE", III_Rotor_Turnover_Letter = 'E',
            Reflector_Configuration = "YRUHQSLDPXNGOKMIEBFZCWVJAT",
            Plug_Board_Configuration = "EJ OY IV AQ KW FX MT PS LU BD"
        };

        public MainForm() {
            InitializeComponent();

            // enigma form init
            enigma_state_to_form(default_enigma_state);

        }

        private void MainForm_Load(object sender, EventArgs e) {

            cryptoProvider = new CryptoProviderServiceReference.CryptoProviderClient();
            //RC4 rc4 = new RC4(new byte[] { 0x52, 0x43, 0x34 });
            //byte[] output = rc4.Encrypt(new byte[] { 0x64, 0x43, 0x6F, 0x64, 0x65 });


        }

        private EnigmaState form_to_enigma_state() {
            try {
                
                EnigmaState enigma_state = new EnigmaState();

                enigma_state.I_Key = Int32.Parse(enigma_rotor1_key_input.Text);
                enigma_state.II_Key = Int32.Parse(enigma_rotor2_key_input.Text);
                enigma_state.III_Key = Int32.Parse(enigma_rotor3_key_input.Text);

                enigma_state.I_Rotor_Turnover_Letter = (enigma_rotor1_turnover_input.Text.ToCharArray())[0];
                enigma_state.II_Rotor_Turnover_Letter = (enigma_rotor2_turnover_input.Text.ToCharArray())[0];
                enigma_state.III_Rotor_Turnover_Letter = (enigma_rotor3_turnover_input.Text.ToCharArray())[0];

                enigma_state.I_Rotor_Configuration = enigma_rotor1_config_input.Text;
                enigma_state.II_Rotor_Configuration = enigma_rotor2_config_input.Text;
                enigma_state.III_Rotor_Configuration = enigma_rotor3_config_input.Text;

                enigma_state.Reflector_Configuration = enigma_reflector_config_input.Text;
                enigma_state.Plug_Board_Configuration = enigma_plugboard_input.Text;

                return enigma_state;
                
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void enigma_state_to_form(EnigmaState enigma_state) {
            try {

                enigma_rotor1_key_input.Text = enigma_state.I_Key.ToString();
                enigma_rotor2_key_input.Text = enigma_state.II_Key.ToString();
                enigma_rotor3_key_input.Text = enigma_state.III_Key.ToString();

                enigma_rotor1_turnover_input.Text = enigma_state.I_Rotor_Turnover_Letter.ToString();
                enigma_rotor2_turnover_input.Text = enigma_state.II_Rotor_Turnover_Letter.ToString();
                enigma_rotor3_turnover_input.Text = enigma_state.III_Rotor_Turnover_Letter.ToString();

                enigma_rotor1_config_input.Text = enigma_state.I_Rotor_Configuration;
                enigma_rotor2_config_input.Text = enigma_state.II_Rotor_Configuration;
                enigma_rotor3_config_input.Text = enigma_state.III_Rotor_Configuration;

                enigma_reflector_config_input.Text = enigma_state.Reflector_Configuration;
                enigma_plugboard_input.Text = enigma_state.Plug_Board_Configuration;

            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void enigma_encode_button_Click(object sender, EventArgs e) {
            try {

                EnigmaState enigma_state = form_to_enigma_state();
                string enigma_result = await cryptoProvider.EnigmaCryptAsync(enigma_state, enigma_cipher_input.Text);
                enigma_plaintext_input.Text = enigma_result;

            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void enigma_decode_button_Click(object sender, EventArgs e) {
            try {

                EnigmaState enigma_state = form_to_enigma_state();
                string enigma_result = await cryptoProvider.EnigmaCryptAsync(enigma_state, enigma_plaintext_input.Text);
                enigma_cipher_input.Text = enigma_result;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void enigma_plugboard_input_KeyPress(object sender, KeyPressEventArgs e) {
            e.KeyChar = Char.ToUpper(e.KeyChar);

            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == ' ') {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        private void enigma_input_KeyPress(object sender, KeyPressEventArgs e) {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
