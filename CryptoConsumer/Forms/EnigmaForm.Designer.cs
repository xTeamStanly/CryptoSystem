namespace CryptoConsumer.Forms {
    partial class EnigmaForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnigmaForm));
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.file_buttons_layout = new System.Windows.Forms.TableLayoutPanel();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.extra_groupbox = new System.Windows.Forms.GroupBox();
            this.file_extra_layout = new System.Windows.Forms.TableLayoutPanel();
            this.offline_checkbox = new System.Windows.Forms.CheckBox();
            this.swap_button = new System.Windows.Forms.Button();
            this.layout_inner = new System.Windows.Forms.TableLayoutPanel();
            this.layout_text = new System.Windows.Forms.TableLayoutPanel();
            this.output_groupbox = new System.Windows.Forms.GroupBox();
            this.output_textbox = new System.Windows.Forms.TextBox();
            this.input_groupbox = new System.Windows.Forms.GroupBox();
            this.input_textbox = new System.Windows.Forms.TextBox();
            this.layout_configuration = new System.Windows.Forms.TableLayoutPanel();
            this.plugboard_groupbox = new System.Windows.Forms.GroupBox();
            this.plugboard_textbox = new System.Windows.Forms.TextBox();
            this.reflector_groupbox = new System.Windows.Forms.GroupBox();
            this.reflector_selector = new System.Windows.Forms.ComboBox();
            this.rotors_groupbox = new System.Windows.Forms.GroupBox();
            this.rotor_layout = new System.Windows.Forms.TableLayoutPanel();
            this.slow_rotor_selector = new System.Windows.Forms.ComboBox();
            this.middle_rotor_selector = new System.Windows.Forms.ComboBox();
            this.fast_rotor_selector = new System.Windows.Forms.ComboBox();
            this.enigma_fast_rotor_label = new System.Windows.Forms.Label();
            this.enigma_middle_rotor_label = new System.Windows.Forms.Label();
            this.enigma_slow_rotor_label = new System.Windows.Forms.Label();
            this.rings_groupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.slow_key_selector = new System.Windows.Forms.ComboBox();
            this.middle_key_selector = new System.Windows.Forms.ComboBox();
            this.fast_key_selector = new System.Windows.Forms.ComboBox();
            this.enigma_fast_key_label = new System.Windows.Forms.Label();
            this.enigma_middle_key_label = new System.Windows.Forms.Label();
            this.enigma_slow_key_label = new System.Windows.Forms.Label();
            this.layout.SuspendLayout();
            this.file_buttons_layout.SuspendLayout();
            this.extra_groupbox.SuspendLayout();
            this.file_extra_layout.SuspendLayout();
            this.layout_inner.SuspendLayout();
            this.layout_text.SuspendLayout();
            this.output_groupbox.SuspendLayout();
            this.input_groupbox.SuspendLayout();
            this.layout_configuration.SuspendLayout();
            this.plugboard_groupbox.SuspendLayout();
            this.reflector_groupbox.SuspendLayout();
            this.rotors_groupbox.SuspendLayout();
            this.rotor_layout.SuspendLayout();
            this.rings_groupbox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.file_buttons_layout, 0, 1);
            this.layout.Controls.Add(this.layout_inner, 0, 0);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(10, 10);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layout.Size = new System.Drawing.Size(1308, 874);
            this.layout.TabIndex = 0;
            // 
            // file_buttons_layout
            // 
            this.file_buttons_layout.ColumnCount = 3;
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.file_buttons_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.file_buttons_layout.Controls.Add(this.encrypt_button, 0, 0);
            this.file_buttons_layout.Controls.Add(this.extra_groupbox, 2, 0);
            this.file_buttons_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_buttons_layout.Location = new System.Drawing.Point(3, 745);
            this.file_buttons_layout.Name = "file_buttons_layout";
            this.file_buttons_layout.RowCount = 1;
            this.file_buttons_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.file_buttons_layout.Size = new System.Drawing.Size(1302, 126);
            this.file_buttons_layout.TabIndex = 4;
            // 
            // encrypt_button
            // 
            this.encrypt_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encrypt_button.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.encrypt_button.Location = new System.Drawing.Point(3, 3);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(775, 120);
            this.encrypt_button.TabIndex = 0;
            this.encrypt_button.Text = "Encode";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // extra_groupbox
            // 
            this.extra_groupbox.Controls.Add(this.file_extra_layout);
            this.extra_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extra_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.extra_groupbox.Location = new System.Drawing.Point(914, 3);
            this.extra_groupbox.Name = "extra_groupbox";
            this.extra_groupbox.Padding = new System.Windows.Forms.Padding(4);
            this.extra_groupbox.Size = new System.Drawing.Size(385, 120);
            this.extra_groupbox.TabIndex = 2;
            this.extra_groupbox.TabStop = false;
            this.extra_groupbox.Text = "Extra";
            // 
            // file_extra_layout
            // 
            this.file_extra_layout.ColumnCount = 2;
            this.file_extra_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.file_extra_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.file_extra_layout.Controls.Add(this.offline_checkbox, 1, 0);
            this.file_extra_layout.Controls.Add(this.swap_button, 0, 0);
            this.file_extra_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_extra_layout.Location = new System.Drawing.Point(4, 32);
            this.file_extra_layout.Name = "file_extra_layout";
            this.file_extra_layout.RowCount = 1;
            this.file_extra_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.file_extra_layout.Size = new System.Drawing.Size(377, 84);
            this.file_extra_layout.TabIndex = 1;
            // 
            // offline_checkbox
            // 
            this.offline_checkbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.offline_checkbox.AutoSize = true;
            this.offline_checkbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offline_checkbox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
            this.offline_checkbox.Location = new System.Drawing.Point(191, 3);
            this.offline_checkbox.Name = "offline_checkbox";
            this.offline_checkbox.Size = new System.Drawing.Size(183, 78);
            this.offline_checkbox.TabIndex = 1;
            this.offline_checkbox.Text = "Offline Mode";
            this.offline_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.offline_checkbox.UseVisualStyleBackColor = true;
            this.offline_checkbox.CheckedChanged += new System.EventHandler(this.offline_checkbox_CheckedChanged);
            // 
            // swap_button
            // 
            this.swap_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.swap_button.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
            this.swap_button.Location = new System.Drawing.Point(3, 3);
            this.swap_button.Name = "swap_button";
            this.swap_button.Size = new System.Drawing.Size(182, 78);
            this.swap_button.TabIndex = 0;
            this.swap_button.Text = "Swap Input/Output";
            this.swap_button.UseVisualStyleBackColor = true;
            this.swap_button.Click += new System.EventHandler(this.swap_button_Click);
            // 
            // layout_inner
            // 
            this.layout_inner.ColumnCount = 2;
            this.layout_inner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_inner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_inner.Controls.Add(this.layout_text, 1, 0);
            this.layout_inner.Controls.Add(this.layout_configuration, 0, 0);
            this.layout_inner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_inner.Location = new System.Drawing.Point(3, 3);
            this.layout_inner.Name = "layout_inner";
            this.layout_inner.RowCount = 1;
            this.layout_inner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_inner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout_inner.Size = new System.Drawing.Size(1302, 736);
            this.layout_inner.TabIndex = 5;
            // 
            // layout_text
            // 
            this.layout_text.ColumnCount = 1;
            this.layout_text.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_text.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout_text.Controls.Add(this.output_groupbox, 0, 1);
            this.layout_text.Controls.Add(this.input_groupbox, 0, 0);
            this.layout_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_text.Location = new System.Drawing.Point(654, 3);
            this.layout_text.Name = "layout_text";
            this.layout_text.RowCount = 2;
            this.layout_text.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_text.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_text.Size = new System.Drawing.Size(645, 730);
            this.layout_text.TabIndex = 0;
            // 
            // output_groupbox
            // 
            this.output_groupbox.Controls.Add(this.output_textbox);
            this.output_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.output_groupbox.Location = new System.Drawing.Point(3, 368);
            this.output_groupbox.Name = "output_groupbox";
            this.output_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.output_groupbox.Size = new System.Drawing.Size(639, 359);
            this.output_groupbox.TabIndex = 2;
            this.output_groupbox.TabStop = false;
            this.output_groupbox.Text = "Output Plaintext";
            // 
            // output_textbox
            // 
            this.output_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_textbox.Location = new System.Drawing.Point(16, 44);
            this.output_textbox.Multiline = true;
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.Size = new System.Drawing.Size(607, 299);
            this.output_textbox.TabIndex = 0;
            // 
            // input_groupbox
            // 
            this.input_groupbox.Controls.Add(this.input_textbox);
            this.input_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.input_groupbox.Location = new System.Drawing.Point(3, 3);
            this.input_groupbox.Name = "input_groupbox";
            this.input_groupbox.Padding = new System.Windows.Forms.Padding(16);
            this.input_groupbox.Size = new System.Drawing.Size(639, 359);
            this.input_groupbox.TabIndex = 1;
            this.input_groupbox.TabStop = false;
            this.input_groupbox.Text = "Input Plaintext";
            // 
            // input_textbox
            // 
            this.input_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_textbox.Location = new System.Drawing.Point(16, 44);
            this.input_textbox.Multiline = true;
            this.input_textbox.Name = "input_textbox";
            this.input_textbox.Size = new System.Drawing.Size(607, 299);
            this.input_textbox.TabIndex = 0;
            // 
            // layout_configuration
            // 
            this.layout_configuration.ColumnCount = 1;
            this.layout_configuration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_configuration.Controls.Add(this.plugboard_groupbox, 0, 3);
            this.layout_configuration.Controls.Add(this.reflector_groupbox, 0, 2);
            this.layout_configuration.Controls.Add(this.rotors_groupbox, 0, 1);
            this.layout_configuration.Controls.Add(this.rings_groupbox, 0, 0);
            this.layout_configuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_configuration.Location = new System.Drawing.Point(3, 3);
            this.layout_configuration.Name = "layout_configuration";
            this.layout_configuration.RowCount = 4;
            this.layout_configuration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layout_configuration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layout_configuration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.layout_configuration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layout_configuration.Size = new System.Drawing.Size(645, 730);
            this.layout_configuration.TabIndex = 1;
            // 
            // plugboard_groupbox
            // 
            this.plugboard_groupbox.Controls.Add(this.plugboard_textbox);
            this.plugboard_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plugboard_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.plugboard_groupbox.Location = new System.Drawing.Point(3, 586);
            this.plugboard_groupbox.Name = "plugboard_groupbox";
            this.plugboard_groupbox.Padding = new System.Windows.Forms.Padding(10);
            this.plugboard_groupbox.Size = new System.Drawing.Size(639, 141);
            this.plugboard_groupbox.TabIndex = 5;
            this.plugboard_groupbox.TabStop = false;
            this.plugboard_groupbox.Text = "Plug Board (PO AB DC ...)";
            // 
            // plugboard_textbox
            // 
            this.plugboard_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plugboard_textbox.Location = new System.Drawing.Point(10, 38);
            this.plugboard_textbox.Multiline = true;
            this.plugboard_textbox.Name = "plugboard_textbox";
            this.plugboard_textbox.Size = new System.Drawing.Size(619, 93);
            this.plugboard_textbox.TabIndex = 0;
            // 
            // reflector_groupbox
            // 
            this.reflector_groupbox.Controls.Add(this.reflector_selector);
            this.reflector_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reflector_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.reflector_groupbox.Location = new System.Drawing.Point(3, 477);
            this.reflector_groupbox.Name = "reflector_groupbox";
            this.reflector_groupbox.Padding = new System.Windows.Forms.Padding(10);
            this.reflector_groupbox.Size = new System.Drawing.Size(639, 103);
            this.reflector_groupbox.TabIndex = 4;
            this.reflector_groupbox.TabStop = false;
            this.reflector_groupbox.Text = "Reflector";
            // 
            // reflector_selector
            // 
            this.reflector_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.reflector_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reflector_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.reflector_selector.FormattingEnabled = true;
            this.reflector_selector.Location = new System.Drawing.Point(10, 47);
            this.reflector_selector.Name = "reflector_selector";
            this.reflector_selector.Size = new System.Drawing.Size(619, 31);
            this.reflector_selector.TabIndex = 4;
            // 
            // rotors_groupbox
            // 
            this.rotors_groupbox.Controls.Add(this.rotor_layout);
            this.rotors_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotors_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.rotors_groupbox.Location = new System.Drawing.Point(3, 222);
            this.rotors_groupbox.Name = "rotors_groupbox";
            this.rotors_groupbox.Padding = new System.Windows.Forms.Padding(10);
            this.rotors_groupbox.Size = new System.Drawing.Size(639, 249);
            this.rotors_groupbox.TabIndex = 3;
            this.rotors_groupbox.TabStop = false;
            this.rotors_groupbox.Text = "Rotors";
            // 
            // rotor_layout
            // 
            this.rotor_layout.ColumnCount = 2;
            this.rotor_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.rotor_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.rotor_layout.Controls.Add(this.slow_rotor_selector, 1, 2);
            this.rotor_layout.Controls.Add(this.middle_rotor_selector, 1, 1);
            this.rotor_layout.Controls.Add(this.fast_rotor_selector, 1, 0);
            this.rotor_layout.Controls.Add(this.enigma_fast_rotor_label, 0, 0);
            this.rotor_layout.Controls.Add(this.enigma_middle_rotor_label, 0, 1);
            this.rotor_layout.Controls.Add(this.enigma_slow_rotor_label, 0, 2);
            this.rotor_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rotor_layout.Location = new System.Drawing.Point(10, 38);
            this.rotor_layout.Name = "rotor_layout";
            this.rotor_layout.RowCount = 3;
            this.rotor_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rotor_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rotor_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rotor_layout.Size = new System.Drawing.Size(619, 201);
            this.rotor_layout.TabIndex = 0;
            // 
            // slow_rotor_selector
            // 
            this.slow_rotor_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.slow_rotor_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slow_rotor_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.slow_rotor_selector.FormattingEnabled = true;
            this.slow_rotor_selector.Location = new System.Drawing.Point(188, 152);
            this.slow_rotor_selector.Name = "slow_rotor_selector";
            this.slow_rotor_selector.Size = new System.Drawing.Size(428, 31);
            this.slow_rotor_selector.TabIndex = 5;
            // 
            // middle_rotor_selector
            // 
            this.middle_rotor_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.middle_rotor_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.middle_rotor_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.middle_rotor_selector.FormattingEnabled = true;
            this.middle_rotor_selector.Location = new System.Drawing.Point(188, 85);
            this.middle_rotor_selector.Name = "middle_rotor_selector";
            this.middle_rotor_selector.Size = new System.Drawing.Size(428, 31);
            this.middle_rotor_selector.TabIndex = 4;
            // 
            // fast_rotor_selector
            // 
            this.fast_rotor_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fast_rotor_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fast_rotor_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.fast_rotor_selector.FormattingEnabled = true;
            this.fast_rotor_selector.Location = new System.Drawing.Point(188, 18);
            this.fast_rotor_selector.Name = "fast_rotor_selector";
            this.fast_rotor_selector.Size = new System.Drawing.Size(428, 31);
            this.fast_rotor_selector.TabIndex = 3;
            // 
            // enigma_fast_rotor_label
            // 
            this.enigma_fast_rotor_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_fast_rotor_label.AutoSize = true;
            this.enigma_fast_rotor_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_fast_rotor_label.Location = new System.Drawing.Point(52, 22);
            this.enigma_fast_rotor_label.Name = "enigma_fast_rotor_label";
            this.enigma_fast_rotor_label.Size = new System.Drawing.Size(130, 23);
            this.enigma_fast_rotor_label.TabIndex = 0;
            this.enigma_fast_rotor_label.Text = "Fast Rotor";
            // 
            // enigma_middle_rotor_label
            // 
            this.enigma_middle_rotor_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_middle_rotor_label.AutoSize = true;
            this.enigma_middle_rotor_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_middle_rotor_label.Location = new System.Drawing.Point(28, 89);
            this.enigma_middle_rotor_label.Name = "enigma_middle_rotor_label";
            this.enigma_middle_rotor_label.Size = new System.Drawing.Size(154, 23);
            this.enigma_middle_rotor_label.TabIndex = 1;
            this.enigma_middle_rotor_label.Text = "Middle Rotor";
            // 
            // enigma_slow_rotor_label
            // 
            this.enigma_slow_rotor_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_slow_rotor_label.AutoSize = true;
            this.enigma_slow_rotor_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_slow_rotor_label.Location = new System.Drawing.Point(52, 156);
            this.enigma_slow_rotor_label.Name = "enigma_slow_rotor_label";
            this.enigma_slow_rotor_label.Size = new System.Drawing.Size(130, 23);
            this.enigma_slow_rotor_label.TabIndex = 2;
            this.enigma_slow_rotor_label.Text = "Slow Rotor";
            // 
            // rings_groupbox
            // 
            this.rings_groupbox.Controls.Add(this.tableLayoutPanel1);
            this.rings_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rings_groupbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.rings_groupbox.Location = new System.Drawing.Point(3, 3);
            this.rings_groupbox.Name = "rings_groupbox";
            this.rings_groupbox.Padding = new System.Windows.Forms.Padding(10);
            this.rings_groupbox.Size = new System.Drawing.Size(639, 213);
            this.rings_groupbox.TabIndex = 2;
            this.rings_groupbox.TabStop = false;
            this.rings_groupbox.Text = "Rings / Key";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.slow_key_selector, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.middle_key_selector, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fast_key_selector, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.enigma_fast_key_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.enigma_middle_key_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.enigma_slow_key_label, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 165);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // slow_key_selector
            // 
            this.slow_key_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.slow_key_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.slow_key_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.slow_key_selector.FormattingEnabled = true;
            this.slow_key_selector.Location = new System.Drawing.Point(281, 122);
            this.slow_key_selector.Name = "slow_key_selector";
            this.slow_key_selector.Size = new System.Drawing.Size(335, 31);
            this.slow_key_selector.TabIndex = 5;
            // 
            // middle_key_selector
            // 
            this.middle_key_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.middle_key_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.middle_key_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.middle_key_selector.FormattingEnabled = true;
            this.middle_key_selector.Location = new System.Drawing.Point(281, 67);
            this.middle_key_selector.Name = "middle_key_selector";
            this.middle_key_selector.Size = new System.Drawing.Size(335, 31);
            this.middle_key_selector.TabIndex = 4;
            // 
            // fast_key_selector
            // 
            this.fast_key_selector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fast_key_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fast_key_selector.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.fast_key_selector.FormattingEnabled = true;
            this.fast_key_selector.Location = new System.Drawing.Point(281, 12);
            this.fast_key_selector.Name = "fast_key_selector";
            this.fast_key_selector.Size = new System.Drawing.Size(335, 31);
            this.fast_key_selector.TabIndex = 3;
            // 
            // enigma_fast_key_label
            // 
            this.enigma_fast_key_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_fast_key_label.AutoSize = true;
            this.enigma_fast_key_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_fast_key_label.Location = new System.Drawing.Point(97, 16);
            this.enigma_fast_key_label.Name = "enigma_fast_key_label";
            this.enigma_fast_key_label.Size = new System.Drawing.Size(178, 23);
            this.enigma_fast_key_label.TabIndex = 0;
            this.enigma_fast_key_label.Text = "Fast Rotor Key";
            // 
            // enigma_middle_key_label
            // 
            this.enigma_middle_key_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_middle_key_label.AutoSize = true;
            this.enigma_middle_key_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_middle_key_label.Location = new System.Drawing.Point(73, 71);
            this.enigma_middle_key_label.Name = "enigma_middle_key_label";
            this.enigma_middle_key_label.Size = new System.Drawing.Size(202, 23);
            this.enigma_middle_key_label.TabIndex = 1;
            this.enigma_middle_key_label.Text = "Middle Rotor Key";
            // 
            // enigma_slow_key_label
            // 
            this.enigma_slow_key_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.enigma_slow_key_label.AutoSize = true;
            this.enigma_slow_key_label.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enigma_slow_key_label.Location = new System.Drawing.Point(97, 126);
            this.enigma_slow_key_label.Name = "enigma_slow_key_label";
            this.enigma_slow_key_label.Size = new System.Drawing.Size(178, 23);
            this.enigma_slow_key_label.TabIndex = 2;
            this.enigma_slow_key_label.Text = "Slow Rotor Key";
            // 
            // EnigmaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1328, 894);
            this.Controls.Add(this.layout);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnigmaForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Enigma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnigmaForm_FormClosing);
            this.Load += new System.EventHandler(this.EnigmaForm_Load);
            this.layout.ResumeLayout(false);
            this.file_buttons_layout.ResumeLayout(false);
            this.extra_groupbox.ResumeLayout(false);
            this.file_extra_layout.ResumeLayout(false);
            this.file_extra_layout.PerformLayout();
            this.layout_inner.ResumeLayout(false);
            this.layout_text.ResumeLayout(false);
            this.output_groupbox.ResumeLayout(false);
            this.output_groupbox.PerformLayout();
            this.input_groupbox.ResumeLayout(false);
            this.input_groupbox.PerformLayout();
            this.layout_configuration.ResumeLayout(false);
            this.plugboard_groupbox.ResumeLayout(false);
            this.plugboard_groupbox.PerformLayout();
            this.reflector_groupbox.ResumeLayout(false);
            this.rotors_groupbox.ResumeLayout(false);
            this.rotor_layout.ResumeLayout(false);
            this.rotor_layout.PerformLayout();
            this.rings_groupbox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.TableLayoutPanel file_buttons_layout;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.GroupBox extra_groupbox;
        private System.Windows.Forms.TableLayoutPanel file_extra_layout;
        private System.Windows.Forms.CheckBox offline_checkbox;
        private System.Windows.Forms.Button swap_button;
        private System.Windows.Forms.TableLayoutPanel layout_inner;
        private System.Windows.Forms.TableLayoutPanel layout_text;
        private System.Windows.Forms.GroupBox input_groupbox;
        private System.Windows.Forms.TextBox input_textbox;
        private System.Windows.Forms.GroupBox output_groupbox;
        private System.Windows.Forms.TextBox output_textbox;
        private System.Windows.Forms.TableLayoutPanel layout_configuration;
        private System.Windows.Forms.GroupBox plugboard_groupbox;
        private System.Windows.Forms.TextBox plugboard_textbox;
        private System.Windows.Forms.GroupBox reflector_groupbox;
        private System.Windows.Forms.GroupBox rotors_groupbox;
        private System.Windows.Forms.GroupBox rings_groupbox;
        private System.Windows.Forms.TableLayoutPanel rotor_layout;
        private System.Windows.Forms.Label enigma_fast_rotor_label;
        private System.Windows.Forms.Label enigma_middle_rotor_label;
        private System.Windows.Forms.Label enigma_slow_rotor_label;
        private System.Windows.Forms.ComboBox slow_rotor_selector;
        private System.Windows.Forms.ComboBox middle_rotor_selector;
        private System.Windows.Forms.ComboBox fast_rotor_selector;
        private System.Windows.Forms.ComboBox reflector_selector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox slow_key_selector;
        private System.Windows.Forms.ComboBox middle_key_selector;
        private System.Windows.Forms.ComboBox fast_key_selector;
        private System.Windows.Forms.Label enigma_fast_key_label;
        private System.Windows.Forms.Label enigma_middle_key_label;
        private System.Windows.Forms.Label enigma_slow_key_label;
    }
}