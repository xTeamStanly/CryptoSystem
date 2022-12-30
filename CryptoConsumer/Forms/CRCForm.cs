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
            GUI.SetColor(text_offline_checkbox, text_offline_mode);
            GUI.SetColor(plaintext_offline_checkbox, plaintext_offline_mode);
            
            // ### file tab ###
            file_key_selector.Items.AddRange(CRCChecksum.algorithms.ToArray());
            file_datagrid.DataSource = CRC.FileHistory;
            file_datagrid.TopLeftHeaderCell.Value = "#";

            // ### text tab ###
            text_key_selector.Items.AddRange(CRCChecksum.algorithms.ToArray());
            text_datagrid.DataSource = CRC.TextFileHistory;
            text_datagrid.TopLeftHeaderCell.Value = "#";

            // ### plaintext tab ###
            plaintext_key_selector.Items.AddRange(CRCChecksum.algorithms.ToArray());
            plaintext_datagrid.DataSource = CRC.PlaintextHistory;
            plaintext_datagrid.TopLeftHeaderCell.Value = "#";
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

                FileInfo fileinfo = new FileInfo(file_input_filepath);
                byte[] bytes = IO.OpenFile(file_input_filepath);

                ulong? checksum = null;

                Stopwatch timer = new Stopwatch();
                if (file_offline_mode == true) {
                    CRC cipher = new CRC(file_key_textbox.Text);
                    timer.Start();
                    checksum = cipher.ChecksumFile(bytes);
                    timer.Stop();
                } else {
                    timer.Start();
                    checksum = await cryptoProvider.CRC_ChecksumFileAsync(file_key_textbox.Text, bytes);
                    timer.Stop();
                    if (checksum == null) { throw new Exception("Server error!"); }
                }

                GUI.ShowInformation("Success", "Checksum calculation successful!");

                CRCFileItem fileitem = new CRCFileItem {
                    FilePath = file_input_filepath,
                    CheckSum = (ulong)checksum,
                    CheckSumHex = CRC.unsigned_to_hexstring((ulong)checksum),
                    CalculationDuration = String.Format("{0} ms", timer.ElapsedMilliseconds),
                    DateCalculated = DateTime.Now,
                    FileSize = IO.calculate_filesize((decimal)fileinfo.Length)
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

        // ################################ text tab ################################
        private string text_input_filepath = "";
        private bool text_offline_mode = false;

        private void text_input_button_Click(object sender, EventArgs e) {
            open_file_dialog.Filter = "Text files (*.txt)|*.txt";
            DialogResult result = open_file_dialog.ShowDialog();
            if (result == DialogResult.OK) {
                text_input_filepath = open_file_dialog.FileName;
                text_input_textbox.Text = text_input_filepath;
            }
        }
        private void text_key_button_Click(object sender, EventArgs e) {
            text_key_textbox.Text = Tools.RandomString(33);
        }
        private void text_key_selector_SelectedIndexChanged(object sender, EventArgs e) {
            int current_index = text_key_selector.SelectedIndex;
            CRCPolynomial polynomial = (CRCPolynomial)text_key_selector.Items[current_index];
            text_key_textbox.Text = polynomial.Polynomial;
        }
        private void text_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            text_offline_mode = !text_offline_mode;
            GUI.SetColor(text_offline_checkbox, text_offline_mode);
        }
        private async void text_encrypt_button_Click(object sender, EventArgs e) {
            try {
                text_input_filepath = text_input_textbox.Text;

                FileInfo fileinfo = new FileInfo(text_input_filepath);
                string[] lines = IO.OpenTextFile(text_input_filepath);

                ulong? checksum = null;

                Stopwatch timer = new Stopwatch();
                if (text_offline_mode == true) {
                    CRC cipher = new CRC(text_key_textbox.Text);
                    timer.Start();
                    checksum = cipher.ChecksumTextFile(lines);
                    timer.Stop();
                } else {
                    timer.Start();
                    checksum = await cryptoProvider.CRC_ChecksumTextFileAsync(file_key_textbox.Text, lines);
                    timer.Stop();
                    if (checksum == null) { throw new Exception("Server error!"); }
                }

                GUI.ShowInformation("Success", "Checksum calculation successful!");
                
                CRCTextItem textitem = new CRCTextItem {
                    FilePath = file_input_filepath,
                    CheckSum = (ulong)checksum,
                    CheckSumHex = CRC.unsigned_to_hexstring((ulong)checksum),
                    CalculationDuration = String.Format("{0} ms", timer.ElapsedMilliseconds),
                    DateCalculated = DateTime.Now,
                    FileSize = IO.calculate_filesize((decimal)fileinfo.Length),
                    Lines = lines.Length
                };
                CRC.TextFileHistory.Add(textitem);
                BindingSource binding_source = new BindingSource();
                binding_source.DataSource = CRC.TextFileHistory;
                file_datagrid.DataSource = binding_source;

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }

        private void text_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            for (int i = 0 ; i < text_datagrid.Rows.Count ; i++) {
                text_datagrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // ################################ plaintext tab ################################
        private bool plaintext_offline_mode = false;

        private void plaintext_key_selector_SelectedIndexChanged(object sender, EventArgs e) {
            int current_index = plaintext_key_selector.SelectedIndex;
            CRCPolynomial polynomial = (CRCPolynomial)plaintext_key_selector.Items[current_index];
            plaintext_key_textbox.Text = polynomial.Polynomial;
        }
        private void plaintext_key_button_Click(object sender, EventArgs e) {
            plaintext_key_textbox.Text = Tools.RandomString(33);
        }
        private async void plaintext_encrypt_button_Click(object sender, EventArgs e) {
            try {
                ulong? checksum = null;

                Stopwatch timer = new Stopwatch();
                if (plaintext_offline_mode == true) {
                    CRC cipher = new CRC(plaintext_key_textbox.Text);
                    timer.Start();
                    checksum = cipher.ChecksumPlaintext(plaintext_input_textbox.Text);
                    timer.Stop();
                } else {
                    timer.Start();
                    checksum = await cryptoProvider.CRC_ChecksumPlaintextAsync(file_key_textbox.Text, plaintext_input_textbox.Text);
                    timer.Stop();
                    if (checksum == null) { throw new Exception("Server error!"); }
                }

                GUI.ShowInformation("Success", "Checksum calculation successful!");

                CRCPlaintextItem plaintextitem = new CRCPlaintextItem {
                    Content = plaintext_input_textbox.Text,
                    CheckSum = (ulong)checksum,
                    CheckSumHex = CRC.unsigned_to_hexstring((ulong)checksum),
                    DateCalculated = DateTime.Now,
                    Length = plaintext_input_textbox.Text.Length,
                    CalculationDuration = String.Format("{0} ms", timer.ElapsedMilliseconds)
                };
                CRC.PlaintextHistory.Add(plaintextitem);
                BindingSource binding_source = new BindingSource();
                binding_source.DataSource = CRC.PlaintextHistory;
                plaintext_datagrid.DataSource = binding_source;

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
        private void plaintext_offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            plaintext_offline_mode = !plaintext_offline_mode;
            GUI.SetColor(plaintext_offline_checkbox, plaintext_offline_mode);
        }
        private void plaintext_datagrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            for (int i = 0 ; i < plaintext_datagrid.Rows.Count ; i++) {
                plaintext_datagrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
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

        private void text_input_layout_DragDrop(object sender, DragEventArgs e) {
            text_input_filepath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            text_input_textbox.Text = text_input_filepath;
        }
    }
}
