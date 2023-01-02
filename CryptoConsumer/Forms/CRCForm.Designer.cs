namespace CryptoConsumer.Forms {
    partial class CRCForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRCForm));
            this.open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.file_layout = new System.Windows.Forms.TableLayoutPanel();
            this.file_history_groupbox = new System.Windows.Forms.GroupBox();
            this.file_datagrid = new System.Windows.Forms.DataGridView();
            this.file_key_groupbox = new System.Windows.Forms.GroupBox();
            this.file_key_layout = new System.Windows.Forms.TableLayoutPanel();
            this.file_key_selector = new System.Windows.Forms.ComboBox();
            this.file_key_button = new System.Windows.Forms.Button();
            this.file_key_textbox = new System.Windows.Forms.TextBox();
            this.file_buttons_layout = new System.Windows.Forms.TableLayoutPanel();
            this.file_thread_groupbox = new System.Windows.Forms.GroupBox();
            this.file_threads_numeric = new System.Windows.Forms.NumericUpDown();
            this.file_encrypt_button = new System.Windows.Forms.Button();
            this.extra_groupbox = new System.Windows.Forms.GroupBox();
            this.file_offline_checkbox = new System.Windows.Forms.CheckBox();
            this.file_input_groupbox = new System.Windows.Forms.GroupBox();
            this.file_input_layout = new System.Windows.Forms.TableLayoutPanel();
            this.file_input_button = new System.Windows.Forms.Button();
            this.file_input_textbox = new System.Windows.Forms.TextBox();
            this.file_layout.SuspendLayout();
            this.file_history_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file_datagrid)).BeginInit();
            this.file_key_groupbox.SuspendLayout();
            this.file_key_layout.SuspendLayout();
            this.file_buttons_layout.SuspendLayout();
            this.file_thread_groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file_threads_numeric)).BeginInit();
            this.extra_groupbox.SuspendLayout();
            this.file_input_groupbox.SuspendLayout();
            this.file_input_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // file_layout
            // 
            this.file_layout.ColumnCount = 1;
            this.file_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.file_layout.Controls.Add(this.file_history_groupbox, 0, 3);
            this.file_layout.Controls.Add(this.file_key_groupbox, 0, 1);
            this.file_layout.Controls.Add(this.file_buttons_layout, 0, 2);
            this.file_layout.Controls.Add(this.file_input_groupbox, 0, 0);
            this.file_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_layout.Location = new System.Drawing.Point(10, 10);
            this.file_layout.Name = "file_layout";
            this.file_layout.RowCount = 4;
            this.file_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.file_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.file_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.file_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.file_layout.Size = new System.Drawing.Size(1308, 874);
            this.file_layout.TabIndex = 4;
            // 
            // file_history_groupbox
            // 
            this.file_history_groupbox.Controls.Add(this.file_datagrid);
            this.file_history_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_history_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.file_history_groupbox.Location = new System.Drawing.Point(3, 482);
            this.file_history_groupbox.Name = "file_history_groupbox";
            this.file_history_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.file_history_groupbox.Size = new System.Drawing.Size(1302, 389);
            this.file_history_groupbox.TabIndex = 3;
            this.file_history_groupbox.TabStop = false;
            this.file_history_groupbox.Text = "File History";
            // 
            // file_datagrid
            // 
            this.file_datagrid.AllowUserToAddRows = false;
            this.file_datagrid.AllowUserToDeleteRows = false;
            this.file_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.file_datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.file_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.file_datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_datagrid.Location = new System.Drawing.Point(16, 44);
            this.file_datagrid.Name = "file_datagrid";
            this.file_datagrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.file_datagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.file_datagrid.RowHeadersWidth = 62;
            this.file_datagrid.RowTemplate.Height = 28;
            this.file_datagrid.Size = new System.Drawing.Size(1270, 329);
            this.file_datagrid.TabIndex = 0;
            this.file_datagrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.file_datagrid_DataBindingComplete);
            // 
            // file_key_groupbox
            // 
            this.file_key_groupbox.Controls.Add(this.file_key_layout);
            this.file_key_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_key_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.file_key_groupbox.Location = new System.Drawing.Point(3, 177);
            this.file_key_groupbox.Name = "file_key_groupbox";
            this.file_key_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.file_key_groupbox.Size = new System.Drawing.Size(1302, 168);
            this.file_key_groupbox.TabIndex = 1;
            this.file_key_groupbox.TabStop = false;
            this.file_key_groupbox.Text = "Polynomial";
            // 
            // file_key_layout
            // 
            this.file_key_layout.ColumnCount = 2;
            this.file_key_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.file_key_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.file_key_layout.Controls.Add(this.file_key_selector, 1, 1);
            this.file_key_layout.Controls.Add(this.file_key_button, 1, 0);
            this.file_key_layout.Controls.Add(this.file_key_textbox, 0, 0);
            this.file_key_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_key_layout.Location = new System.Drawing.Point(16, 44);
            this.file_key_layout.Name = "file_key_layout";
            this.file_key_layout.RowCount = 2;
            this.file_key_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.file_key_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.file_key_layout.Size = new System.Drawing.Size(1270, 108);
            this.file_key_layout.TabIndex = 0;
            // 
            // file_key_selector
            // 
            this.file_key_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.file_key_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.file_key_selector.FormattingEnabled = true;
            this.file_key_selector.Location = new System.Drawing.Point(1019, 65);
            this.file_key_selector.Name = "file_key_selector";
            this.file_key_selector.Size = new System.Drawing.Size(248, 31);
            this.file_key_selector.TabIndex = 1;
            this.file_key_selector.Text = "Presets";
            this.file_key_selector.SelectedIndexChanged += new System.EventHandler(this.file_key_selector_SelectedIndexChanged);
            // 
            // file_key_button
            // 
            this.file_key_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_key_button.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.file_key_button.Location = new System.Drawing.Point(1019, 3);
            this.file_key_button.Name = "file_key_button";
            this.file_key_button.Size = new System.Drawing.Size(248, 48);
            this.file_key_button.TabIndex = 0;
            this.file_key_button.Text = "Random Polynomial";
            this.file_key_button.UseVisualStyleBackColor = true;
            this.file_key_button.Click += new System.EventHandler(this.file_key_button_Click);
            // 
            // file_key_textbox
            // 
            this.file_key_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_key_textbox.Location = new System.Drawing.Point(3, 3);
            this.file_key_textbox.MaxLength = 16;
            this.file_key_textbox.Multiline = true;
            this.file_key_textbox.Name = "file_key_textbox";
            this.file_key_layout.SetRowSpan(this.file_key_textbox, 2);
            this.file_key_textbox.Size = new System.Drawing.Size(1010, 102);
            this.file_key_textbox.TabIndex = 0;
            this.file_key_textbox.Text = "100000100110000010001110110110111";
            // 
            // file_buttons_layout
            // 
            this.file_buttons_layout.ColumnCount = 3;
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.file_buttons_layout.Controls.Add(this.file_thread_groupbox, 1, 0);
            this.file_buttons_layout.Controls.Add(this.file_encrypt_button, 0, 0);
            this.file_buttons_layout.Controls.Add(this.extra_groupbox, 2, 0);
            this.file_buttons_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_buttons_layout.Location = new System.Drawing.Point(3, 351);
            this.file_buttons_layout.Name = "file_buttons_layout";
            this.file_buttons_layout.RowCount = 1;
            this.file_buttons_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.file_buttons_layout.Size = new System.Drawing.Size(1302, 125);
            this.file_buttons_layout.TabIndex = 2;
            // 
            // file_thread_groupbox
            // 
            this.file_thread_groupbox.Controls.Add(this.file_threads_numeric);
            this.file_thread_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_thread_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.file_thread_groupbox.Location = new System.Drawing.Point(784, 3);
            this.file_thread_groupbox.Name = "file_thread_groupbox";
            this.file_thread_groupbox.Padding = new System.Windows.Forms.Padding(4);
            this.file_thread_groupbox.Size = new System.Drawing.Size(189, 119);
            this.file_thread_groupbox.TabIndex = 2;
            this.file_thread_groupbox.TabStop = false;
            this.file_thread_groupbox.Text = "Threads";
            // 
            // file_threads_numeric
            // 
            this.file_threads_numeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.file_threads_numeric.Location = new System.Drawing.Point(7, 55);
            this.file_threads_numeric.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.file_threads_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.file_threads_numeric.Name = "file_threads_numeric";
            this.file_threads_numeric.Size = new System.Drawing.Size(175, 35);
            this.file_threads_numeric.TabIndex = 0;
            this.file_threads_numeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.file_threads_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // file_encrypt_button
            // 
            this.file_encrypt_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_encrypt_button.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.file_encrypt_button.Location = new System.Drawing.Point(3, 3);
            this.file_encrypt_button.Name = "file_encrypt_button";
            this.file_encrypt_button.Size = new System.Drawing.Size(775, 119);
            this.file_encrypt_button.TabIndex = 1;
            this.file_encrypt_button.Text = "Calculate Checksum";
            this.file_encrypt_button.UseVisualStyleBackColor = true;
            this.file_encrypt_button.Click += new System.EventHandler(this.file_encrypt_button_Click);
            // 
            // extra_groupbox
            // 
            this.extra_groupbox.Controls.Add(this.file_offline_checkbox);
            this.extra_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extra_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.extra_groupbox.Location = new System.Drawing.Point(979, 3);
            this.extra_groupbox.Name = "extra_groupbox";
            this.extra_groupbox.Padding = new System.Windows.Forms.Padding(4);
            this.extra_groupbox.Size = new System.Drawing.Size(320, 119);
            this.extra_groupbox.TabIndex = 0;
            this.extra_groupbox.TabStop = false;
            this.extra_groupbox.Text = "Extra";
            // 
            // file_offline_checkbox
            // 
            this.file_offline_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.file_offline_checkbox.AutoSize = true;
            this.file_offline_checkbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_offline_checkbox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
            this.file_offline_checkbox.Location = new System.Drawing.Point(4, 32);
            this.file_offline_checkbox.Name = "file_offline_checkbox";
            this.file_offline_checkbox.Size = new System.Drawing.Size(312, 83);
            this.file_offline_checkbox.TabIndex = 0;
            this.file_offline_checkbox.Text = "Offline Mode";
            this.file_offline_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.file_offline_checkbox.UseVisualStyleBackColor = true;
            this.file_offline_checkbox.Click += new System.EventHandler(this.file_offline_checkbox_CheckedChanged);
            // 
            // file_input_groupbox
            // 
            this.file_input_groupbox.Controls.Add(this.file_input_layout);
            this.file_input_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_input_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.file_input_groupbox.Location = new System.Drawing.Point(3, 3);
            this.file_input_groupbox.Name = "file_input_groupbox";
            this.file_input_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.file_input_groupbox.Size = new System.Drawing.Size(1302, 168);
            this.file_input_groupbox.TabIndex = 0;
            this.file_input_groupbox.TabStop = false;
            this.file_input_groupbox.Text = "Input File Path";
            // 
            // file_input_layout
            // 
            this.file_input_layout.AllowDrop = true;
            this.file_input_layout.ColumnCount = 2;
            this.file_input_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.file_input_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.file_input_layout.Controls.Add(this.file_input_button, 1, 0);
            this.file_input_layout.Controls.Add(this.file_input_textbox, 0, 0);
            this.file_input_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_input_layout.Location = new System.Drawing.Point(16, 44);
            this.file_input_layout.Name = "file_input_layout";
            this.file_input_layout.RowCount = 1;
            this.file_input_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.file_input_layout.Size = new System.Drawing.Size(1270, 108);
            this.file_input_layout.TabIndex = 1;
            this.file_input_layout.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_input_layout_DragDrop);
            this.file_input_layout.DragEnter += new System.Windows.Forms.DragEventHandler(this.handler_DragEnter);
            // 
            // file_input_button
            // 
            this.file_input_button.AllowDrop = true;
            this.file_input_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_input_button.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.file_input_button.Location = new System.Drawing.Point(1019, 3);
            this.file_input_button.Name = "file_input_button";
            this.file_input_button.Size = new System.Drawing.Size(248, 102);
            this.file_input_button.TabIndex = 1;
            this.file_input_button.Text = "Browse";
            this.file_input_button.UseVisualStyleBackColor = true;
            this.file_input_button.Click += new System.EventHandler(this.file_input_button_Click);
            this.file_input_button.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_input_layout_DragDrop);
            this.file_input_button.DragEnter += new System.Windows.Forms.DragEventHandler(this.handler_DragEnter);
            // 
            // file_input_textbox
            // 
            this.file_input_textbox.AllowDrop = true;
            this.file_input_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_input_textbox.Location = new System.Drawing.Point(3, 3);
            this.file_input_textbox.Multiline = true;
            this.file_input_textbox.Name = "file_input_textbox";
            this.file_input_textbox.Size = new System.Drawing.Size(1010, 102);
            this.file_input_textbox.TabIndex = 0;
            this.file_input_textbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_input_layout_DragDrop);
            this.file_input_textbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.handler_DragEnter);
            // 
            // CRCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1328, 894);
            this.Controls.Add(this.file_layout);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CRCForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "CRC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CRCForm_FormClosed);
            this.Load += new System.EventHandler(this.CRCForm_Load);
            this.file_layout.ResumeLayout(false);
            this.file_history_groupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.file_datagrid)).EndInit();
            this.file_key_groupbox.ResumeLayout(false);
            this.file_key_layout.ResumeLayout(false);
            this.file_key_layout.PerformLayout();
            this.file_buttons_layout.ResumeLayout(false);
            this.file_thread_groupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.file_threads_numeric)).EndInit();
            this.extra_groupbox.ResumeLayout(false);
            this.extra_groupbox.PerformLayout();
            this.file_input_groupbox.ResumeLayout(false);
            this.file_input_layout.ResumeLayout(false);
            this.file_input_layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog open_file_dialog;
        private System.Windows.Forms.TableLayoutPanel file_layout;
        private System.Windows.Forms.GroupBox file_history_groupbox;
        private System.Windows.Forms.DataGridView file_datagrid;
        private System.Windows.Forms.GroupBox file_key_groupbox;
        private System.Windows.Forms.TableLayoutPanel file_key_layout;
        private System.Windows.Forms.ComboBox file_key_selector;
        private System.Windows.Forms.Button file_key_button;
        private System.Windows.Forms.TextBox file_key_textbox;
        private System.Windows.Forms.TableLayoutPanel file_buttons_layout;
        private System.Windows.Forms.GroupBox file_thread_groupbox;
        private System.Windows.Forms.NumericUpDown file_threads_numeric;
        private System.Windows.Forms.Button file_encrypt_button;
        private System.Windows.Forms.GroupBox extra_groupbox;
        private System.Windows.Forms.CheckBox file_offline_checkbox;
        private System.Windows.Forms.GroupBox file_input_groupbox;
        private System.Windows.Forms.TableLayoutPanel file_input_layout;
        private System.Windows.Forms.Button file_input_button;
        private System.Windows.Forms.TextBox file_input_textbox;
    }
}