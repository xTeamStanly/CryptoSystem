using CryptoProvider;
using Library;
using Library.Crypto.Enigma;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CryptoConsumer.Forms {
    public partial class EnigmaForm : Form {

        private CryptoServiceReference.ICryptoProvider cryptoProvider = null;
        private MainForm parent_form = null;

        public EnigmaForm(MainForm parent_form, CryptoServiceReference.ICryptoProvider cryptoProvider) {
            InitializeComponent();
            this.cryptoProvider = cryptoProvider;
            this.parent_form = parent_form;
        }

        private bool offline_mode = false;
        private void EnigmaForm_Load(object sender, EventArgs e) {
            GUI.SetColor(offline_checkbox, offline_mode);
            fill_enigma_form();
        }

        private void fill_enigma_form() {
            // rings
            fast_key_selector.Items.AddRange(Rotor.alphabet.ToCharArray().Select(c => (object)Rotor.alphabet_letter_to_number(c)).ToArray());
            fast_key_selector.SelectedIndex = 0;
            
            middle_key_selector.Items.AddRange(Rotor.alphabet.ToCharArray().Select(c => (object)Rotor.alphabet_letter_to_number(c)).ToArray());
            middle_key_selector.SelectedIndex = 0;

            slow_key_selector.Items.AddRange(Rotor.alphabet.ToCharArray().Select(c => (object)Rotor.alphabet_letter_to_number(c)).ToArray());
            slow_key_selector.SelectedIndex = 0;

            // rotors
            fast_rotor_selector.Items.AddRange(Rotors.rotors);
            fast_rotor_selector.SelectedIndex = (int)Rotors.RotorType.III;

            middle_rotor_selector.Items.AddRange(Rotors.rotors);
            middle_rotor_selector.SelectedIndex = (int)Rotors.RotorType.II;

            slow_rotor_selector.Items.AddRange(Rotors.rotors);
            slow_rotor_selector.SelectedIndex = (int)Rotors.RotorType.I;

            // reflectors
            reflector_selector.Items.AddRange(Reflectors.reflectors);
            reflector_selector.SelectedIndex = (int)Reflectors.ReflectorType.B;

            // plugboard
            plugboard_textbox.Text = "";
        }

        private void EnigmaForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (parent_form != null) { parent_form.close_enigma_form(true); }
        }

        private void swap_button_Click(object sender, EventArgs e) {
            GUI.SwapText(input_textbox, output_textbox);
        }

        private void offline_checkbox_CheckedChanged(object sender, EventArgs e) {
            offline_mode = !offline_mode;
            GUI.SetColor(offline_checkbox, offline_mode);
        }

        private async void encrypt_button_Click(object sender, EventArgs e) {
            try {

                Rotor fast_rotor = new Rotor((Rotor)fast_rotor_selector.Items[fast_rotor_selector.SelectedIndex]);
                fast_rotor.rotation = (int)fast_key_selector.Items[fast_key_selector.SelectedIndex];
                fast_rotor.start_position = fast_rotor.rotation;

                Rotor middle_rotor = new Rotor((Rotor)middle_rotor_selector.Items[middle_rotor_selector.SelectedIndex]);
                middle_rotor.rotation = (int)middle_key_selector.Items[middle_key_selector.SelectedIndex];
                middle_rotor.start_position = middle_rotor.rotation;

                Rotor slow_rotor = new Rotor((Rotor)slow_rotor_selector.Items[slow_rotor_selector.SelectedIndex]);
                slow_rotor.rotation = (int)slow_key_selector.Items[slow_key_selector.SelectedIndex];
                slow_rotor.start_position = slow_rotor.rotation;
                
                Reflector reflector = new Reflector((Reflector)reflector_selector.Items[reflector_selector.SelectedIndex]);
                
                if (offline_mode == true) {
                    Enigma cipher = new Enigma(reflector, new Rotor[] { fast_rotor, middle_rotor, slow_rotor }, plugboard_textbox.Text);
                    output_textbox.Text = cipher.Get(input_textbox.Text);
                } else {

                    EnigmaState enigma_state = new EnigmaState {
                        SlowType = slow_rotor.type,
                        SlowRotation = slow_rotor.rotation,
                        SlowStart = slow_rotor.start_position,

                        MiddleType = middle_rotor.type,
                        MiddleRotation = middle_rotor.rotation,
                        MiddleStart = middle_rotor.start_position,

                        FastType = fast_rotor.type,
                        FastRotation = fast_rotor.rotation,
                        FastStart = fast_rotor.start_position,

                        PlugboardConfiguration = plugboard_textbox.Text,
                        ReflectorType = reflector.type
                    };
                    output_textbox.Text = await cryptoProvider.Enigma_EncodeAsync(enigma_state, input_textbox.Text);
                }

                GUI.ShowInformation("Success", "Encoding successful!");

            } catch (Exception ex) {
                GUI.ShowError(ex.Message);
            }
        }
    }
}
