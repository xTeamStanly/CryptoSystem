using CryptoConsumer.CryptoServiceReference;
using Library;
using Library.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoConsumer.Forms {
    public partial class CRCForm : Form {

        private ICryptoProvider cryptoProvider = null;
        private MainForm parent_form = null;

        public CRCForm(MainForm parent_form, ICryptoProvider cryptoProvider) {
            InitializeComponent();
            this.cryptoProvider = cryptoProvider;
            this.parent_form = parent_form;
        }

        private void CRCForm_Load(object sender, EventArgs e) {
            GUI.SetColor(file_offline_checkbox, file_offline_mode);
            
            // ### file tab ###
            file_key_selector.Items.AddRange(CRCChecksum.algorithms.ToArray());
            file_datagrid.DataSource = CRC.FileHistory;
            file_datagrid.TopLeftHeaderCell.Value = "#";
        }

        private void CRCForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (parent_form != null) { parent_form.close_crc_form(true); }
        }


        // ################################ file tab ################################
        private string file_input_filepath = "";
        private bool file_offline_mode = false;

        private void file_input_button_Click(object sender, EventArgs e) {
            open_file_dialog.Filter = "All files (*.*)|*.*";
            DialogResult result = open_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                file_input_filepath = open_file_dialog.FileName;
                file_input_textbox.Text = file_input_filepath;
            }
        }
        private void file_key_button_Click(object sender, EventArgs e) {
            file_key_textbox.Text = Tools.RandomBinaryString(33);
        }
        private async void file_encrypt_button_Click(object sender, EventArgs e) {
            try {
                file_input_filepath = file_input_textbox.Text;

                int thread_count = (int)file_threads_numeric.Value;

                FileInfo fileinfo = new FileInfo(file_input_filepath);
                ulong? checksum = null;

                Stopwatch timer = new Stopwatch();
                if (file_offline_mode == true) {
                    CRC cipher = new CRC(file_key_textbox.Text, thread_count);
                    timer.Start();
                    checksum = cipher.ChecksumFile(file_input_filepath);
                    timer.Stop();
                } else {
                    checksum = 0;
                    
                    timer.Start();

                    using (FileStream filestream = new FileStream(file_input_filepath, FileMode.Open, FileAccess.Read)) {

                        byte[] buffer = new byte[128 * 1024 * 1024]; // 128MB BUFFER
                        int bytes_read = filestream.Read(buffer, 0, buffer.Length);

                        while (bytes_read > 0) {
                            ulong? partial_checksum = await cryptoProvider.CRC_ChecksumFileAsync(file_key_textbox.Text, buffer, thread_count);
                            if (partial_checksum == null) { throw new Exception("Server error!"); }
                            checksum = checksum ^ (ulong)partial_checksum;

                            bytes_read = filestream.Read(buffer, 0, buffer.Length);
                            long remanining_bytes = buffer.LongLength - bytes_read;
                            if (remanining_bytes > 0) {
                                Array.Clear(buffer, bytes_read, (int)remanining_bytes);
                            }
                            
                        }
                    }

                    timer.Stop();
                }

                GUI.ShowInformation("Success", "Checksum calculation successful!");

                CRCFileItem fileitem = new CRCFileItem {
                    FilePath = file_input_filepath,
                    CheckSum = (ulong)checksum,
                    CheckSumHex = CRC.unsigned_to_hexstring((ulong)checksum),
                    CalculationDuration = String.Format("{0} ms", timer.ElapsedMilliseconds),
                    ThreadCount = thread_count,
                    FileSize = IO.calculate_filesize((decimal)fileinfo.Length),
                    Offline = file_offline_mode
                };
                CRC.FileHistory.Add(fileitem);
                BindingSource binding_source = new BindingSource();
                binding_source.DataSource = CRC.FileHistory;
                file_datagrid.DataSource = binding_source;

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void file_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            file_offline_mode = !file_offline_mode;
            GUI.SetColor(file_offline_checkbox, file_offline_mode);
        }
        private void file_key_selector_SelectedIndexChanged(object sender, EventArgs e) {
            int current_index = file_key_selector.SelectedIndex;
            CRCPolynomial polynomial = (CRCPolynomial)file_key_selector.Items[current_index];
            file_key_textbox.Text = polynomial.Polynomial;
        }
        private void file_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            for (int i = 0 ; i < file_datagrid.Rows.Count ; i++) {
                file_datagrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // ################################ drag & drop ################################
        private void handler_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) == true) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void file_input_layout_DragDrop(object sender, DragEventArgs e) {
            file_input_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            file_input_textbox.Text = file_input_filepath;
        }
    }
}
