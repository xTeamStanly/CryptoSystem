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
        }

        private void TEAForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (parent_form != null) { parent_form.close_tea_form(true); }
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

                int thread_count = (int)file_threads_numeric.Value;
                
                if (file_offline_mode == true) {
                    TEAThreaded cipher = new TEAThreaded(file_key_textbox.Text, thread_count);
                    cipher.EncryptFile(file_input_filepath, file_output_filepath);
                } else {

                    using (FileStream input = new FileStream(file_input_filepath, FileMode.Open, FileAccess.Read)) {
                        using (FileStream output = File.Create(file_output_filepath)) {

                            byte[] buffer = new byte[128 * 1024 * 1024]; // 128 MB BUFFER
                            int bytes_read = input.Read(buffer, 0, buffer.Length);

                            while(bytes_read > 0) {

                                byte[] bytes = new byte[bytes_read];
                                Array.Copy(buffer, 0, bytes, 0, bytes_read);

                                byte[] output_bytes = await cryptoProvider.TEA_EncryptFileAsync(file_key_textbox.Text, bytes, thread_count);
                                if (output_bytes == null) { throw new Exception("Server error!"); }

                                // ako se radi o zadnjem chunk-u, ne treba zanemariti padding

                                if (bytes_read == buffer.Length) { // ceo chuck, zanemariti padding
                                    Array.Resize(ref output_bytes, output_bytes.Length - 4); // brisemo padding bytes
                                }

                                output.Write(output_bytes, 0, output_bytes.Length);
                                bytes_read = input.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
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

                int thread_count = (int)file_threads_numeric.Value;

                if (file_offline_mode == true) {
                    TEAThreaded cipher = new TEAThreaded(file_key_textbox.Text, thread_count);
                    cipher.DecryptFile(file_input_filepath, file_output_filepath);
                } else {

                    using (FileStream input = new FileStream(file_input_filepath, FileMode.Open, FileAccess.Read)) {
                        using (FileStream output = File.Create(file_output_filepath)) {

                            byte[] buffer = new byte[128 * 1024 * 1024]; // 128 MB BUFFER
                            int bytes_read = input.Read(buffer, 0, buffer.Length);

                            while (bytes_read > 0) {

                                byte[] bytes = new byte[bytes_read];
                                Array.Copy(buffer, bytes, bytes_read);

                                byte[] output_bytes = null;

                                if (bytes_read == buffer.Length) { // u pitanju je ceo chunk, u suprotnom je u pitanju zadnji chunk i saljemo sve
                                    Array.Resize(ref bytes, bytes_read + 4); // ostavljamo mesto za padding (koji je 0x00 0x00 0x00 0x00)
                                }

                                output_bytes = await cryptoProvider.TEA_DecryptFileAsync(file_key_textbox.Text, bytes, thread_count);
                                if (output_bytes == null) { throw new Exception("Server error!"); }

                                output.Write(output_bytes, 0, output_bytes.Length);
                                bytes_read = input.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
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

                int thread_count = (int)file_threads_numeric.Value;

                byte[] input_bytes = IO.OpenFile(bitmap_input_filepath);
                byte[] output_bytes = null;

                if (bitmap_offline_mode == true) {
                    TEAThreaded cipher = new TEAThreaded(bitmap_key_textbox.Text, thread_count);
                    output_bytes = cipher.EncryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.TEA_EncryptBitmapAsync(bitmap_key_textbox.Text, input_bytes, thread_count);
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

                int thread_count = (int)file_threads_numeric.Value;

                byte[] input_bytes = IO.OpenFile(bitmap_input_filepath);
                byte[] output_bytes = null;

                if (bitmap_offline_mode == true) {
                    TEAThreaded cipher = new TEAThreaded(bitmap_key_textbox.Text, thread_count);
                    output_bytes = cipher.DecryptBitmap(input_bytes);
                } else {
                    output_bytes = await cryptoProvider.TEA_DecryptBitmapAsync(bitmap_key_textbox.Text, input_bytes, thread_count);
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
