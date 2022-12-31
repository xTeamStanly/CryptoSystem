using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Library.Crypto.Enigma.Rotors;

namespace Library.Crypto.Enigma {
    public class Rotor {

        public static string valid_rotor_configuration(string input) {
            if (input == null) { throw new ArgumentNullException("Rotor configuration is null"); }

            input = Regex.Replace(input, " ", "").ToLower();
            if (input.Length != 26) { throw new Exception("Rotor configuration length is invalid"); }

            HashSet<char> chars = new HashSet<char>();
            foreach (char c in input) {
                if (chars.Contains(c) == true) { throw new Exception("Rotor configuration is invalid"); }
                chars.Add(c);
            }

            return input.ToUpper();
        }

        public readonly static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string inverse_rotor_configuration(string valid_rotor_configuration) {
            char[] inverse_configuration = new char[26];
            for (int i = 0 ; i < 26 ; i++) {
                char rotor_letter = valid_rotor_configuration[i];
                int inverse_letter_position = alphabet.IndexOf(rotor_letter);

                inverse_configuration[inverse_letter_position] = alphabet[i];
            }

            return new string(inverse_configuration);
        }

        public static int alphabet_letter_to_number(char letter) {
            bool small_letter = letter >= 'a' && letter <= 'z';
            bool big_letter = letter >= 'A' && letter <= 'Z';

            if (small_letter == false && big_letter == false) { return -1; }

            byte letter_byte = Encoding.UTF8.GetBytes(letter.ToString()).First();
            return letter_byte & 0b11111; // bitmask ascii/utf8 hack
        }
        public static string remove_all_whitespace_from_string(string input) {
            if (input == null) { return null; }
            input = Regex.Replace(input, " ", "");
            return input;
        }

        public RotorType type;
        public string name;
        public string configuration;
        public int[] notches;
        public int rotation;
        public int start_position;

        private static bool valid_letter(char input) {
            input = Char.ToLower(input);
            if (input >= 'a' && input <= 'z') {
                return true;
            }
            return false;
        }

        public Rotor(string name, string configuration, char[] notches, char rotation, RotorType type) {
            if (name == null) { throw new ArgumentNullException("Rotor name is null"); }
            if (name.Length == 0) { throw new ArgumentException("Rotor name is empty"); }
            this.name = name;

            if (notches == null) { throw new Exception("Rotor notches array is null"); }
            if (notches.Length == 0) { throw new Exception("Rotor notch array is empty"); }
            notches = notches.Select(c => Char.ToLower(c)).ToArray();

            List<int> index_notches = new List<int>();
            foreach (char c in notches) {
                if (valid_letter(c) == false) { throw new Exception("Notch array contains a non letter"); }
                index_notches.Add(alphabet_letter_to_number(c));
            }
            this.notches = index_notches.ToArray();
            

            this.configuration = valid_rotor_configuration(configuration);

            if (valid_letter(rotation) == false) { throw new ArgumentException("Rotation is not a letter"); }
            this.rotation = alphabet_letter_to_number(Char.ToLower(rotation));
            start_position = this.rotation;

            this.type = type;
        }

        public Rotor(Rotor rotor) {
            if (rotor == null) { throw new ArgumentNullException("Input rotor is null"); }

            name = rotor.name;
            configuration = rotor.configuration;
            rotation = rotor.rotation;
            start_position = rotor.start_position;

            notches = new int[rotor.notches.Length];
            Array.Copy(rotor.notches, notches, notches.Length);

            type = rotor.type;
        }

        public void reset_rotor() { rotation = start_position; }

        public void rotate() {
            if (rotation == configuration.Length) {
                rotation = 1;
            } else {
                rotation++;
            }
        }
        public bool rotate_next() {
            foreach (int notch in notches) {
                if (notch == rotation) { return true; }
            }
            return false;
        }

        private int apply_rotation(int input) {
            int shifted_input = input + rotation - 1;
            if (shifted_input >= configuration.Length) {
                return shifted_input - configuration.Length;
            } else {
                return shifted_input;
            }
        }
        private int undo_rotation(int input) {
            int shifted_input = input - rotation + 1;
            if (shifted_input < 0) {
                return shifted_input + configuration.Length;
            } else {
                return shifted_input;
            }
        }

        private int get(int input, string input_config, string output_config) {
            char symbol = output_config[input];
            int output = input_config.IndexOf(symbol);
            return output;
        }
        private int encode_input(int input, string input_config, string output_config) {
            int rotated = apply_rotation(input);
            int output_with_rotation = get(rotated, input_config, output_config);
            int output_with_no_rotation = undo_rotation(output_with_rotation);
            return output_with_no_rotation;
        }
        public int encode_forwards(int input) { return encode_input(input, alphabet, configuration); }
        public int encode_backwards(int input) { return encode_input(input, configuration, alphabet); }

        public override string ToString() {
            return name;
        }

    }
}
