using CryptoConsumer.CryptoServiceReference;
using Library;
using Library.Crypto;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CryptoConsumer.Forms {
    public partial class TEAForm : Form {

        private ICryptoProvider cryptoProvider = null;
        private MainForm parent_form = null;

        public TEAForm(MainForm parent_form, ICryptoProvider cryptoProvider) {
            InitializeComponent();
            this.cryptoProvider = cryptoProvider;
            this.parent_form = parent_form;
        }

        private void TEAForm_Load(object sender, EventArgs e) {
            GUI.SetColor(file_offline_checkbox, file_offline_mode);
            GUI.SetColor(bitmap_offline_checkbox, bitmap_offline_mode);
            GUI.SetColor(text_offline_checkbox, text_offline_mode);
            GUI.SetColor(plaintext_offline_checkbox, plaintext_offline_mode);
        }

        private void TEAForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (parent_form != null) { parent_form.close_tea_form(true); }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabs.SelectedIndex == 3 && plaintext_show_warning == true) {
                plaintext_show_warning = false;
                GUI.ShowInformation("TEA (Plaintext) - Napomena", "Ovaj režim ne funkcioniše najbolje sa tekstom, a na to utiče postojanje \\0 (0x00) karaktera. Moguće je da se neki karakter šifruje/dešifruje u 0x00 i pri prikazivanju rastumači kao kraj string-a, što dovodi do preranog odsecanja ostalih karaktera sledbenika u nizu.");
            }
        }

        // ################################ file tab ################################
        private string file_input_filepath = "";
        private string file_output_filepath = "";
        private bool file_offline_mode = false;

        private void file_input_button_Click(object sender, EventArgs e) {
            open_file_dialog.Filter = "All files (*.*)|*.*";
            DialogResult result = open_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                file_input_filepath = open_file_dialog.FileName;
                file_input_textbox.Text = file_input_filepath;
            }
        }
        private void file_output_button_Click(object sender, EventArgs e) {
            save_file_dialog.Filter = "All files (*.*)|*.*";
            DialogResult result = save_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                file_output_filepath = save_file_dialog.FileName;
                file_output_textbox.Text = file_output_filepath;
            }
        }
        private void file_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            file_offline_mode = !file_offline_mode;
            GUI.SetColor(file_offline_checkbox, file_offline_mode);
        }
        private void file_swap_button_Click(object sender, EventArgs e) {
            GUI.SwapText(file_input_textbox, file_output_textbox);
        }
        private async void file_encrypt_button_Click(object sender, EventArgs e) {
            try {
                file_input_filepath = file_input_textbox.Text;
                file_output_filepath = file_output_textbox.Text;
                
                if (file_offline_mode == true) {
                    TEA cipher = new TEA(file_key_textbox.Text);
                    cipher.EncryptFile(file_input_filepath, file_output_filepath);
                } else {
                    byte[] bytes = IO.OpenFile(file_input_filepath);
                    bytes = await cryptoProvider.TEA_EncryptFileAsync(file_key_textbox.Text, bytes);
                    if (bytes == null) { throw new Exception("Server error!"); }
                    IO.SaveFile(file_output_filepath, bytes);
                }

                GUI.ShowInformation("Success", "Encryption successful!");

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private async void file_decrypt_button_Click(object sender, EventArgs e) {
            try {
                file_input_filepath = file_input_textbox.Text;
                file_output_filepath = file_output_textbox.Text;

                if (file_offline_mode == true) {
                    TEA cipher = new TEA(file_key_textbox.Text);
                    cipher.DecryptFile(file_input_filepath, file_output_filepath);
                } else {
                    byte[] bytes = IO.OpenFile(file_input_filepath);
                    bytes = await cryptoProvider.TEA_DecryptFileAsync(file_key_textbox.Text, bytes);
                    if (bytes == null) { throw new Exception("Server error!"); }
                    IO.SaveFile(file_output_filepath, bytes);
                }

                GUI.ShowInformation("Success", "Decryption successful!");

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void file_key_button_Click(object sender, EventArgs e) {
            file_key_textbox.Text = Tools.RandomString(16);
        }

        // ################################ bitmap tab ################################
        private string bitmap_input_filepath = "";
        private string bitmap_output_filepath = "";
        private bool bitmap_offline_mode = false;

        private void bitmap_input_button_Click(object sender, EventArgs e) {
            open_file_dialog.Filter = "24 Bit Bitmap File |*.bmp";
            DialogResult result = open_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                bitmap_input_filepath = open_file_dialog.FileName;
                bitmap_input_textbox.Text = bitmap_input_filepath;
            }
        }
        private void bitmap_output_button_Click(object sender, EventArgs e) {
            save_file_dialog.Filter = "24 Bit Bitmap File |*.bmp";
            DialogResult result = save_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                bitmap_output_filepath = open_file_dialog.FileName;
                bitmap_output_textbox.Text = bitmap_output_filepath;
            }
        }
        private void bitmap_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            bitmap_offline_mode = !bitmap_offline_mode;
            GUI.SetColor(bitmap_offline_checkbox, bitmap_offline_mode);
        }
        private void bitmap_swap_button_Click(object sender, EventArgs e) {
            GUI.SwapText(bitmap_input_textbox, bitmap_output_textbox);
        }
        private async void bitmap_encrypt_button_Click(object sender, EventArgs e) {
            try {
                bitmap_input_filepath = bitmap_input_textbox.Text;
                bitmap_output_filepath = bitmap_output_textbox.Text;

                byte[] input_bytes = IO.OpenFile(bitmap_input_filepath);
                byte[] output_bytes = null;

                if (bitmap_offline_mode == true) {
                    TEA cipher = new TEA(bitmap_key_textbox.Text);
                    output_bytes = cipher.EncryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.TEA_EncryptBitmapAsync(bitmap_key_textbox.Text, input_bytes);
                    if (output_bytes == null) { throw new Exception("Server error!"); }
                }

                Bitmap input;
                using (MemoryStream ms = new MemoryStream(input_bytes)) {
                    input = new Bitmap(ms);
                }
                bitmap_preview_input_picturebox.Image = input;

                Bitmap output;
                using (MemoryStream ms = new MemoryStream(output_bytes)) {
                    output = new Bitmap(ms);
                }
                bitmap_preview_output_picturebox.Image = output;

                IO.SaveFile(bitmap_output_filepath, output_bytes);
                GUI.ShowInformation("Success", "Encryption successful!");
            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private async void bitmap_decrypt_button_Click(object sender, EventArgs e) {
            try {
                bitmap_input_filepath = bitmap_input_textbox.Text;
                bitmap_output_filepath = bitmap_output_textbox.Text;

                byte[] input_bytes = IO.OpenFile(bitmap_input_filepath);
                byte[] output_bytes = null;

                if (bitmap_offline_mode == true) {
                    TEA cipher = new TEA(bitmap_key_textbox.Text);
                    output_bytes = cipher.DecryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.TEA_DecryptBitmapAsync(bitmap_key_textbox.Text, input_bytes);
                    if (output_bytes == null) { throw new Exception("Server error!"); }
                }

                Bitmap input;
                using (MemoryStream ms = new MemoryStream(input_bytes)) {
                    input = new Bitmap(ms);
                }
                bitmap_preview_input_picturebox.Image = input;

                Bitmap output;
                using (MemoryStream ms = new MemoryStream(output_bytes)) {
                    output = new Bitmap(ms);
                }
                bitmap_preview_output_picturebox.Image = output;

                IO.SaveFile(bitmap_output_filepath, output_bytes);
                GUI.ShowInformation("Success", "Decryption successful!");
            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void bitmap_key_button_Click(object sender, EventArgs e) {
            bitmap_key_textbox.Text = Tools.RandomString(16);
        }

        // ################################ text tab ################################
        private string text_input_filepath = "";
        private string text_output_filepath = "";
        private bool text_offline_mode = false;

        private void text_input_button_Click(object sender, EventArgs e) {
            open_file_dialog.Filter = "Text files (*.txt)|*.txt";
            DialogResult result = open_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                text_input_filepath = open_file_dialog.FileName;
                text_input_textbox.Text = text_input_filepath;
            }
        }
        private void text_output_button_Click(object sender, EventArgs e) {
            save_file_dialog.Filter = "Text files (*.txt)|*.txt";
            DialogResult result = save_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                text_output_filepath = open_file_dialog.FileName;
                text_output_textbox.Text = text_output_filepath;
            }
        }
        private void text_key_button_Click(object sender, EventArgs e) {
            text_key_textbox.Text = Tools.RandomString(16);
        }
        private async void text_encrypt_button_Click(object sender, EventArgs e) {
            try {
                text_input_filepath = text_input_textbox.Text;
                text_output_filepath = text_output_textbox.Text;

                if (text_offline_mode == true) {
                    TEA cipher = new TEA(text_key_textbox.Text);
                    cipher.EncryptText(text_input_filepath, text_output_filepath);
                } else {
                    string[] lines = IO.OpenTextFile(text_input_filepath);
                    lines = await cryptoProvider.TEA_EncryptTextAsync(text_key_textbox.Text, lines);
                    if (lines == null) { throw new Exception("Server error!"); }
                    IO.SaveTextFile(text_output_filepath, lines);
                }

                GUI.ShowInformation("Success", "Encryption successfull!");

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private async void text_decrypt_button_Click(object sender, EventArgs e) {
            try {
                text_input_filepath = text_input_textbox.Text;
                text_output_filepath = text_output_textbox.Text;

                if (text_offline_mode == true) {
                    TEA cipher = new TEA(text_key_textbox.Text);
                    cipher.DecryptText(text_input_filepath, text_output_filepath);
                } else {
                    string[] lines = IO.OpenTextFile(text_input_filepath);
                    lines = await cryptoProvider.TEA_DecryptTextAsync(text_key_textbox.Text, lines);
                    if (lines == null) { throw new Exception("Server error!"); }
                    IO.SaveTextFile(text_output_filepath, lines);
                }

                GUI.ShowInformation("Success", "Decryption successful!");

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void text_swap_button_Click(object sender, EventArgs e) {
            GUI.SwapText(text_input_textbox, text_output_textbox);
        }
        private void text_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            text_offline_mode = !text_offline_mode;
            GUI.SetColor(text_offline_checkbox, text_offline_mode);
        }

        // ################################ plaintext tab ################################
        private bool plaintext_offline_mode = false;
        private static bool plaintext_show_warning = true;

        private async void plaintext_encrypt_button_Click(object sender, EventArgs e) {
            try {
                if (plaintext_offline_mode == true) {
                    TEA cipher = new TEA(plaintext_key_textbox.Text);
                    plaintext_output_textbox.Text = cipher.EncryptPlaintext(plaintext_input_textbox.Text);
                } else {
                    plaintext_output_textbox.Text = await cryptoProvider.TEA_EncryptPlaintextAsync(plaintext_key_textbox.Text, plaintext_input_textbox.Text);
                }
            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private async void plaintext_decrypt_button_Click(object sender, EventArgs e) {
            try {
                if (plaintext_offline_mode == true) {
                    TEA cipher = new TEA(plaintext_key_textbox.Text);
                    plaintext_output_textbox.Text = cipher.DecryptPlaintext(plaintext_input_textbox.Text);
                } else {
                    plaintext_output_textbox.Text = await cryptoProvider.TEA_DecryptPlaintextAsync(plaintext_key_textbox.Text, plaintext_input_textbox.Text);
                }
            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void plaintext_key_button_Click(object sender, EventArgs e) {
            plaintext_key_textbox.Text = Tools.RandomString(16);
        }
        private void plaintext_swap_button_Click(object sender, EventArgs e) {
            GUI.SwapText(plaintext_input_textbox, plaintext_output_textbox);
        }
        private void plaintext_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            plaintext_offline_mode = !plaintext_offline_mode;
            GUI.SetColor(plaintext_offline_checkbox, plaintext_offline_mode);
        }

        // ################################ drag & drop ################################
        private void handler_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void file_input_groupbox_DragDrop(object sender, DragEventArgs e) {
            file_input_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            file_input_textbox.Text = file_input_filepath;
        }

        private void file_output_groupbox_DragDrop(object sender, DragEventArgs e) {
            file_output_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            file_output_textbox.Text = file_output_filepath;
        }

        private void bitmap_input_groupbox_DragDrop(object sender, DragEventArgs e) {
            bitmap_input_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            bitmap_input_textbox.Text = bitmap_input_filepath;
        }

        private void bitmap_output_groupbox_DragDrop(object sender, DragEventArgs e) {
            bitmap_output_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            bitmap_output_textbox.Text = bitmap_output_filepath;
        }

        private void text_input_groupbox_DragDrop(object sender, DragEventArgs e) {
            text_input_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            text_input_textbox.Text = text_input_filepath;
        }

        private void text_output_groupbox_DragDrop(object sender, DragEventArgs e) {
           text_output_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            text_output_textbox.Text = text_output_filepath;
        }
    }
}
