using System;
using System.Text.RegularExpressions;

namespace Library.Crypto.Enigma {
    public class Enigma {

        private Reflector reflector = null;
        private Rotor[] rotors = null;
        private PlugBoard plugboard = null;

        public Enigma(Reflector reflector, Rotor[] rotors, string plugboard_configuration) {
            this.reflector = reflector;
            this.rotors = rotors;

            plugboard = new PlugBoard(plugboard_configuration);
        }

        public string Get(string message) {
            if (message == null) { throw new ArgumentException("Message is null"); }
            message = message.ToUpper();
            message = Regex.Replace(message, "[^A-Z]", ""); // samo velika slova ostaju u poruci

            string result = "";
            foreach (char c in message) {
                result += get(c);
            }

            return result;
        }

        private char get(char input) {
            int index = Rotor.alphabet.IndexOf(input);
            index = plugboard.encode(index);
            index = forward_rotate_rotors(index);

            index = reflector.encode(index);

            index = backwards_rotate_rotors(index);
            index = plugboard.encode(index);

            return Rotor.alphabet[index];
        }

        private int forward_rotate_rotors(int input) {
            int index = input;
            bool should_rotate_next = true;

            for (int i = 0 ; i < rotors.Length ; i++) {
                if (should_rotate_next == true) {
                    should_rotate_next = rotors[i].rotate_next();
                    rotors[i].rotate();
                }
    
                index = rotors[i].encode_forwards(index);
            }

            return index;
        }

        private int backwards_rotate_rotors(int input) {
            int index = input;
            for (int i = rotors.Length - 1 ; i >= 0 ; i--) {
                index = rotors[i].encode_backwards(index);
            }
            return index;
        }

    }
}
