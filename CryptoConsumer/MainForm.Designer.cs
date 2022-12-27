namespace CryptoConsumer {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.control_panel_groupbox = new System.Windows.Forms.GroupBox();
            this.control_panel_button_layout = new System.Windows.Forms.TableLayoutPanel();
            this.hide_all_buton = new System.Windows.Forms.Button();
            this.crc_button = new System.Windows.Forms.Button();
            this.rc4_button = new System.Windows.Forms.Button();
            this.cbc_button = new System.Windows.Forms.Button();
            this.enigma_button = new System.Windows.Forms.Button();
            this.tea_button = new System.Windows.Forms.Button();
            this.control_panel_groupbox.SuspendLayout();
            this.control_panel_button_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel_groupbox
            // 
            this.control_panel_groupbox.Controls.Add(this.control_panel_button_layout);
            this.control_panel_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_panel_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.control_panel_groupbox.Location = new System.Drawing.Point(10, 10);
            this.control_panel_groupbox.Name = "control_panel_groupbox";
            this.control_panel_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.control_panel_groupbox.Size = new System.Drawing.Size(509, 510);
            this.control_panel_groupbox.TabIndex = 2;
            this.control_panel_groupbox.TabStop = false;
            this.control_panel_groupbox.Text = "Control Panel";
            // 
            // control_panel_button_layout
            // 
            this.control_panel_button_layout.ColumnCount = 1;
            this.control_panel_button_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.control_panel_button_layout.Controls.Add(this.hide_all_buton, 0, 6);
            this.control_panel_button_layout.Controls.Add(this.crc_button, 0, 4);
            this.control_panel_button_layout.Controls.Add(this.rc4_button, 0, 0);
            this.control_panel_button_layout.Controls.Add(this.cbc_button, 0, 3);
            this.control_panel_button_layout.Controls.Add(this.enigma_button, 0, 1);
            this.control_panel_button_layout.Controls.Add(this.tea_button, 0, 2);
            this.control_panel_button_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_panel_button_layout.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.control_panel_button_layout.Location = new System.Drawing.Point(16, 44);
            this.control_panel_button_layout.Name = "control_panel_button_layout";
            this.control_panel_button_layout.RowCount = 7;
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.control_panel_button_layout.Size = new System.Drawing.Size(477, 450);
            this.control_panel_button_layout.TabIndex = 0;
            // 
            // hide_all_buton
            // 
            this.hide_all_buton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(134)))), ((int)(((byte)(212)))));
            this.hide_all_buton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hide_all_buton.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.hide_all_buton.ForeColor = System.Drawing.Color.White;
            this.hide_all_buton.Location = new System.Drawing.Point(3, 387);
            this.hide_all_buton.Name = "hide_all_buton";
            this.hide_all_buton.Size = new System.Drawing.Size(471, 60);
            this.hide_all_buton.TabIndex = 7;
            this.hide_all_buton.Text = "Hide All";
            this.hide_all_buton.UseVisualStyleBackColor = false;
            this.hide_all_buton.Click += new System.EventHandler(this.hide_all_buton_Click);
            // 
            // crc_button
            // 
            this.crc_button.BackColor = System.Drawing.Color.LightGray;
            this.crc_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crc_button.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.crc_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.crc_button.Location = new System.Drawing.Point(3, 259);
            this.crc_button.Name = "crc_button";
            this.crc_button.Size = new System.Drawing.Size(471, 58);
            this.crc_button.TabIndex = 6;
            this.crc_button.Text = "Cyclic Redundancy Check";
            this.crc_button.UseVisualStyleBackColor = true;
            this.crc_button.Click += new System.EventHandler(this.crc_button_Click);
            // 
            // rc4_button
            // 
            this.rc4_button.BackColor = System.Drawing.Color.LightGray;
            this.rc4_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rc4_button.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.rc4_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rc4_button.Location = new System.Drawing.Point(3, 3);
            this.rc4_button.Name = "rc4_button";
            this.rc4_button.Size = new System.Drawing.Size(471, 58);
            this.rc4_button.TabIndex = 2;
            this.rc4_button.Text = "RC4";
            this.rc4_button.UseVisualStyleBackColor = true;
            this.rc4_button.Click += new System.EventHandler(this.control_panel_rc4_button_Click);
            // 
            // cbc_button
            // 
            this.cbc_button.BackColor = System.Drawing.Color.LightGray;
            this.cbc_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbc_button.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.cbc_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbc_button.Location = new System.Drawing.Point(3, 195);
            this.cbc_button.Name = "cbc_button";
            this.cbc_button.Size = new System.Drawing.Size(471, 58);
            this.cbc_button.TabIndex = 5;
            this.cbc_button.Text = "Cipher Block Chaining (TEA)";
            this.cbc_button.UseVisualStyleBackColor = true;
            this.cbc_button.Click += new System.EventHandler(this.cbc_button_Click);
            // 
            // enigma_button
            // 
            this.enigma_button.BackColor = System.Drawing.Color.LightGray;
            this.enigma_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enigma_button.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.enigma_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.enigma_button.Location = new System.Drawing.Point(3, 67);
            this.enigma_button.Name = "enigma_button";
            this.enigma_button.Size = new System.Drawing.Size(471, 58);
            this.enigma_button.TabIndex = 3;
            this.enigma_button.Text = "Enigma";
            this.enigma_button.UseVisualStyleBackColor = true;
            this.enigma_button.Click += new System.EventHandler(this.control_panel_enigma_button_Click);
            // 
            // tea_button
            // 
            this.tea_button.BackColor = System.Drawing.Color.LightGray;
            this.tea_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tea_button.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.tea_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tea_button.Location = new System.Drawing.Point(3, 131);
            this.tea_button.Name = "tea_button";
            this.tea_button.Size = new System.Drawing.Size(471, 58);
            this.tea_button.TabIndex = 4;
            this.tea_button.Text = "Tiny Encryption Algorithm (TEA)";
            this.tea_button.UseVisualStyleBackColor = true;
            this.tea_button.Click += new System.EventHandler(this.control_panel_tea_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(529, 530);
            this.Controls.Add(this.control_panel_groupbox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zaštita Informacija - 17784";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.control_panel_groupbox.ResumeLayout(false);
            this.control_panel_button_layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox control_panel_groupbox;
        private System.Windows.Forms.TableLayoutPanel control_panel_button_layout;
        private System.Windows.Forms.Button crc_button;
        private System.Windows.Forms.Button rc4_button;
        private System.Windows.Forms.Button cbc_button;
        private System.Windows.Forms.Button enigma_button;
        private System.Windows.Forms.Button tea_button;
        private System.Windows.Forms.Button hide_all_buton;
    }
}

