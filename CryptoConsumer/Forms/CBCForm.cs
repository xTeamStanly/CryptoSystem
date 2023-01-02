using CryptoConsumer.CryptoServiceReference;
using Library;
using Library.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoConsumer.Forms {
    public partial class CBCForm : Form {
        private ICryptoProvider cryptoProvider = null;
        private MainForm parent_form = null;

        public CBCForm(MainForm parent_form, ICryptoProvider cryptoProvider) {
            InitializeComponent();
            this.cryptoProvider = cryptoProvider;
            this.parent_form = parent_form;
        }
        private void CBCForm_Load(object sender, EventArgs e) {
            GUI.SetColor(file_offline_checkbox, file_offline_mode);
            GUI.SetColor(bitmap_offline_checkbox, bitmap_offline_mode);
        }

        private void CBCForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (parent_form != null) { parent_form.close_cbc_form(true); }
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
                    CBCTEA cipher = new CBCTEA(file_key_textbox.Text, file_vector_textbox.Text);
                    cipher.EncryptFile(file_input_filepath, file_output_filepath);
                } else {
                    byte[] bytes = IO.OpenFile(file_input_filepath);
                    bytes = await cryptoProvider.CBC_EncryptFileAsync(file_key_textbox.Text, bytes, file_vector_textbox.Text);
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
                    CBCTEA cipher = new CBCTEA(file_key_textbox.Text, file_vector_textbox.Text);
                    cipher.DecryptFile(file_input_filepath, file_output_filepath);
                } else {
                    byte[] bytes = IO.OpenFile(file_input_filepath);
                    bytes = await cryptoProvider.CBC_DecryptFileAsync(file_key_textbox.Text, bytes, file_vector_textbox.Text);
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
        private void file_vector_button_Click(object sender, EventArgs e) {
            file_vector_textbox.Text = Tools.RandomString(8);
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
                    CBCTEA cipher = new CBCTEA(bitmap_key_textbox.Text, bitmap_vector_textbox.Text);
                    output_bytes = cipher.EncryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.CBC_EncryptBitmapAsync(bitmap_key_textbox.Text, input_bytes, bitmap_vector_textbox.Text);
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
                    CBCTEA cipher = new CBCTEA(bitmap_key_textbox.Text, bitmap_vector_textbox.Text);
                    output_bytes = cipher.DecryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.CBC_DecryptBitmapAsync(bitmap_key_textbox.Text, input_bytes, bitmap_vector_textbox.Text);
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
        private void bitmap_vector_button_Click(object sender, EventArgs e) {
            bitmap_vector_textbox.Text = Tools.RandomString(8);
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
    }
}
