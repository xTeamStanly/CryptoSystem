using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary.Enigma {
    internal class Reflector {
        private string configuration = null;

        public Reflector(string configuration) {
            this.configuration = Utility.valid_rotor_configuration(configuration);
            if (this.configuration == null) { throw new Exception("invalid rotor configuration"); }
        }

        public char Get(char input) {
            int letter_index = Utility.alphabet_letter_to_number(input) - 1;
            if (letter_index < 0) { throw new ArgumentException("input not a letter"); }
            return configuration[letter_index];
        }
    }
}
