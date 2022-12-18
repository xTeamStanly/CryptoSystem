using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary.Enigma {
    internal class Rotor {
        private int index = 0;
        public int Index {
            get { return index; }
        }

        private string configuration = null;

        public Rotor(string configuration) {
            this.configuration = Utility.valid_rotor_configuration(configuration);
            if (this.configuration == null) {
                throw new Exception("invalid rotor configuration");
            }
        }

        public char Rotate(char input) {
            int letter_index = Utility.alphabet_letter_to_number(input) - 1;
            if (letter_index < 0) { throw new ArgumentException("input not a letter"); }

            index = (index + 1) % 26;
            return configuration[letter_index];
        }
    }
}
