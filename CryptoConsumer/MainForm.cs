using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CryptoLibrary;
using CryptoLibrary.Enigma;
using CryptoProvider;

namespace CryptoConsumer {
    public partial class MainForm : Form {

        CryptoProviderServiceReference.ICryptoProvider cryptoProvider = null;
        
        public MainForm() {
            InitializeComponent();

            // enigma form init
            enigma_state_to_form(default_enigma_state);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            cryptoProvider = new CryptoProviderServiceReference.CryptoProviderClient();
        }

        // ENIGMA
        private EnigmaState default_enigma_state = new EnigmaState {
            I_Key = 1, I_Rotor_Configuration = "EKMFLGDQVZNTOWYHXUSPAIBRCJ", I_Rotor_Turnover_Letter = 'Q',
            II_Key = 1, II_Rotor_Configuration = "BDFHJLCPRTXVZNYEIWGAKMUSQO", II_Rotor_Turnover_Letter = 'V',
            III_Key = 1, III_Rotor_Configuration = "AJDKSIRUXBLHWTMCQGZNPYFVOE", III_Rotor_Turnover_Letter = 'E',
            Reflector_Configuration = "YRUHQSLDPXNGOKMIEBFZCWVJAT",
            Plug_Board_Configuration = "PO ML IU KJ NH YT GB VF RE DC"
        };
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

                string enigma_result;
                if (enigma_offline.Checked == false) {
                    enigma_result = await cryptoProvider.EnigmaCryptAsync(enigma_state, enigma_input.Text);
                } else {
                    Enigma enigma = new Enigma(
                        Int32.Parse(enigma_rotor1_key_input.Text), enigma_rotor1_config_input.Text, (enigma_rotor1_turnover_input.Text.ToCharArray())[0],
                        Int32.Parse(enigma_rotor2_key_input.Text), enigma_rotor2_config_input.Text, (enigma_rotor2_turnover_input.Text.ToCharArray())[0],
                        Int32.Parse(enigma_rotor3_key_input.Text), enigma_rotor3_config_input.Text, (enigma_rotor3_turnover_input.Text.ToCharArray())[0],
                        enigma_reflector_config_input.Text, enigma_plugboard_input.Text
                    );
                    enigma_result = enigma.Get(enigma_input.Text);
                }

                enigma_output.Text = enigma_result;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void enigma_decode_button_Click(object sender, EventArgs e) {
            try {
                EnigmaState enigma_state = form_to_enigma_state();

                string enigma_result;
                if (enigma_offline.Checked == false) {
                    enigma_result = await cryptoProvider.EnigmaCryptAsync(enigma_state, enigma_input.Text);
                } else {
                    Enigma enigma = new Enigma(
                        Int32.Parse(enigma_rotor1_key_input.Text), enigma_rotor1_config_input.Text, (enigma_rotor1_turnover_input.Text.ToCharArray())[0],
                        Int32.Parse(enigma_rotor2_key_input.Text), enigma_rotor2_config_input.Text, (enigma_rotor2_turnover_input.Text.ToCharArray())[0],
                        Int32.Parse(enigma_rotor3_key_input.Text), enigma_rotor3_config_input.Text, (enigma_rotor3_turnover_input.Text.ToCharArray())[0],
                        enigma_reflector_config_input.Text, enigma_plugboard_input.Text
                    );
                    enigma_result = enigma.Get(enigma_input.Text);
                }

                enigma_output.Text = enigma_result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void enigma_switch_button_Click(object sender, EventArgs e) {
            string temp = enigma_input.Text;
            enigma_input.Text = enigma_output.Text;
            enigma_output.Text = temp;
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

        // RC4 BITMAP
        private string rc4_bitmap_input_filepath = "";
        private string rc4_bitmap_output_filepath = "";

        private void rc4_bitmap_input_button_Click(object sender, EventArgs e) {
            DialogResult dialog_result = rc4_bitmap_openfile_dialog.ShowDialog();
            if (dialog_result == DialogResult.OK) {
                rc4_bitmap_input_filepath = rc4_bitmap_openfile_dialog.FileName;
                rc4_bitmap_input_path_textbox.Text = rc4_bitmap_input_filepath;
            }
        }
        private void rc4_bitmap_output_button_Click(object sender, EventArgs e) {
            DialogResult dialog_result = rc4_bitmap_savefile_dialog.ShowDialog();
            if (dialog_result == DialogResult.OK) {
                rc4_bitmap_output_filepath = rc4_bitmap_savefile_dialog.FileName;
                rc4_bitmap_output_path_textbox.Text = rc4_bitmap_output_filepath;
            }
        }
        private async void rc4_bitmap_encrypt_button_Click(object sender, EventArgs e) {
            try {

                rc4_bitmap_input_filepath = rc4_bitmap_input_path_textbox.Text;
                rc4_bitmap_output_filepath = rc4_bitmap_output_path_textbox.Text;

                byte[] input_image_bytes = Utility.open_file_to_bytes(rc4_bitmap_input_filepath);

                byte[] output_image_bytes = null;

                if (rc4_bitmap_offline.Checked == true) {
                    RC4 rc4 = new RC4(rc4_bitmap_key_textbox.Text);
                    output_image_bytes = rc4.encrypt_bitmap_from_bytes(input_image_bytes);
                } else {
                    output_image_bytes = await cryptoProvider.RC4BitmapCryptAsync(rc4_bitmap_key_textbox.Text, input_image_bytes);
                }

                
                Bitmap input_image;
                using (MemoryStream ms = new MemoryStream(input_image_bytes)) {
                    input_image = new Bitmap(ms);
                }
                rc4_bitmap_input_image_box.Image = input_image;

                Bitmap output_image;
                using (MemoryStream ms = new MemoryStream(output_image_bytes)) {
                    output_image = new Bitmap(ms);
                }
                rc4_bitmap_output_image_box.Image = output_image;


                Utility.write_bytes_to_file(rc4_bitmap_output_filepath, output_image_bytes);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void rc4_bitmap_decrypt_button_Click(object sender, EventArgs e) {
            try {

                rc4_bitmap_input_filepath = rc4_bitmap_input_path_textbox.Text;
                rc4_bitmap_output_filepath = rc4_bitmap_output_path_textbox.Text;

                byte[] input_image_bytes = Utility.open_file_to_bytes(rc4_bitmap_input_filepath);

                byte[] output_image_bytes = null;

                if (rc4_bitmap_offline.Checked == true) {
                    RC4 rc4 = new RC4(rc4_bitmap_key_textbox.Text);
                    output_image_bytes = rc4.decrypt_bitmap_from_bytes(input_image_bytes);
                } else {
                    output_image_bytes = await cryptoProvider.RC4BitmapDecryptAsync(rc4_bitmap_key_textbox.Text, input_image_bytes);
                }


                Bitmap input_image;
                using (MemoryStream ms = new MemoryStream(input_image_bytes)) {
                    input_image = new Bitmap(ms);
                }
                rc4_bitmap_input_image_box.Image = input_image;

                Bitmap output_image;
                using (MemoryStream ms = new MemoryStream(output_image_bytes)) {
                    output_image = new Bitmap(ms);
                }
                rc4_bitmap_output_image_box.Image = output_image;


                Utility.write_bytes_to_file(rc4_bitmap_output_filepath, output_image_bytes);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rc4_bitmap_random_key_button_Click(object sender, EventArgs e) {
            rc4_bitmap_key_textbox.Text = Utility.rc4_random_key();
        }
        private void rc4_bitmap_swap_button_Click(object sender, EventArgs e) {
            string temp = rc4_bitmap_input_path_textbox.Text;
            rc4_bitmap_input_path_textbox.Text = rc4_bitmap_output_path_textbox.Text;
            rc4_bitmap_output_path_textbox.Text = temp;
        }

        // RC4 TEXT
        private async void rc4_text_encrypt_button_Click(object sender, EventArgs e) {
            try {
                string rc4_result;

                if (rc4_text_offline.Checked == true) {
                    RC4 rc4 = new RC4(rc4_text_key_textbox.Text);
                    rc4_result = rc4.encrypt_unicode_to_unicode(rc4_text_input_textbox.Text);
                } else {
                    rc4_result = await cryptoProvider.RC4CryptAsync(rc4_text_key_textbox.Text, rc4_text_input_textbox.Text);
                }

                rc4_text_output_textbox.Text = rc4_result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void rc4_text_decrypt_button_Click(object sender, EventArgs e) {
            try {
                string rc4_result;

                if (rc4_text_offline.Checked == true) {
                    RC4 rc4 = new RC4(rc4_text_key_textbox.Text);
                    rc4_result = rc4.decrypt_unicode_to_unicode(rc4_text_input_textbox.Text);
                } else {
                    rc4_result = await cryptoProvider.RC4DecryptAsync(rc4_text_key_textbox.Text, rc4_text_input_textbox.Text);
                }

                rc4_text_output_textbox.Text = rc4_result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool rc4_text_info_message_shown = false;
        private void rc4_tabs_SelectedIndexChanged(object sender, EventArgs e) {
            if (rc4_tabs.SelectedIndex == 2 && rc4_text_info_message_shown == false) {
                rc4_text_info_message_shown = true;
                MessageBox.Show("Ovaj režim ne funkcioniše najbolje sa tekstom, a na to utiče postojanje \\0 (0x00) karaktera. Moguće je da se neki karakter šifruje/dešifruje u 0x00 i pri prikazivanju rastumači kao kraj string-a, što dovodi do preranog odsecanja ostalih karaktera sledbenika u nizu.", "RC4 (Text) - Napomena", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void rc4_text_swap_button_Click(object sender, EventArgs e) {
            string temp = rc4_text_input_textbox.Text;
            rc4_text_input_textbox.Text = rc4_text_output_textbox.Text;
            rc4_text_output_textbox.Text = temp;
        }
        private void rc4_text_random_button_Click(object sender, EventArgs e) {
            rc4_text_key_textbox.Text = Utility.rc4_random_key();
        }



        // TEA
        //private async void tea_encrypt_button_Click(object sender, EventArgs e) {
        //    try {
        //        string tea_result = await cryptoProvider.TEACryptAsync(tea_key_input.Text, tea_input_textbox.Text/*, tea_padding_checkbox.Checked*/);
        //        tea_output_textbox.Text = tea_result.Replace(@"\0", "\0"); // todo check this
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private async void tea_decrypt_button_Click(object sender, EventArgs e) {
        //    try {
        //        string tea_result = await cryptoProvider.TEADecryptAsync(tea_key_input.Text, tea_input_textbox.Text/*, tea_padding_checkbox.Checked*/);
        //        tea_output_textbox.Text = tea_result.Replace("\0", @"\0"); // todo check this
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void tea_switch_button_Click(object sender, EventArgs e) {
        //    string temp = tea_output_textbox.Text;
        //    tea_output_textbox.Text = tea_input_textbox.Text;
        //    tea_input_textbox.Text = temp;
        //}
        //private void tea_random_key_Click(object sender, EventArgs e) {
        //    tea_key_input.Text = Utility.tea_random_key();
        //}

        //// RC4
        //private async void rc4_crypt_Click(object sender, EventArgs e) {
        //    try {
        //        string rc4_result = await cryptoProvider.RC4CryptAsync(rc4_key.Text, rc4_input.Text);
        //        rc4_output.Text = rc4_result.Replace(@"\0", "\0");
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private async void rc4_decrypt_Click(object sender, EventArgs e) {
        //    try {
        //        string rc4_result = await cryptoProvider.RC4DecryptAsync(rc4_key.Text, rc4_input.Text);
        //        rc4_output.Text = rc4_result.Replace("\0", @"\0");
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void rc4_swap_Click(object sender, EventArgs e) {
        //    string temp = rc4_input.Text;
        //    rc4_input.Text = rc4_output.Text;
        //    rc4_output.Text = temp;
        //}
        //private void rc4_random_key_Click(object sender, EventArgs e) {
        //    rc4_key.Text = Utility.rc4_random_key();
        //}

        //// CBC
        //private async void cbc_encrypt_Click(object sender, EventArgs e) {
        //    try {
        //        string cbc_result = await cryptoProvider.CBC_TEACryptAsync(cbc_key.Text, cbc_input.Text, cbc_vector.Text/*, cbc_padding_checkbox.Checked*/);
        //        cbc_output.Text = cbc_result.Replace(@"\0", "\0"); // todo check this
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private async void cbc_decrypt_Click(object sender, EventArgs e) {
        //    try {
        //        string cbc_result = await cryptoProvider.CBC_TEADecryptAsync(cbc_key.Text, cbc_input.Text, cbc_vector.Text/*, cbc_padding_checkbox.Checked*/);
        //        cbc_output.Text = cbc_result.Replace("\0", @"\0"); // todo check this
        //    } catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void cbc_swap_Click(object sender, EventArgs e) {
        //    string temp = cbc_input.Text;
        //    cbc_input.Text = cbc_output.Text;
        //    cbc_output.Text = temp;
        //}
        //private void cbc_random_key_Click(object sender, EventArgs e) {
        //    cbc_key.Text = Utility.tea_random_key();
        //}
        //private void cbc_random_iv_Click(object sender, EventArgs e) {
        //    cbc_vector.Text = Utility.tea_random_key();
        //}
    }
}
