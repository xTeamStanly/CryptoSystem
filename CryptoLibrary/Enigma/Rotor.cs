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
            set { index = value; }
        }

        private int turnover_index;
        public int TurnoverIndex {
            get { return turnover_index; }
        }

        private string configuration = null;
        private string inverse_configuration = null;

        public Rotor(string configuration, char turnover_letter) {            
            this.turnover_index = Utility.alphabet_letter_to_number(turnover_letter);
            if (this.turnover_index < 1) { throw new Exception("invalid turnover letter"); }
            this.turnover_index--;

            this.configuration = Utility.valid_rotor_configuration(configuration);
            if (this.configuration == null) { throw new Exception("invalid rotor configuration"); }

            inverse_configuration = Utility.inverse_rotor_configuration(this.configuration);

        }

        // vraca true ako se desio turnover
        public bool Rotate() {
            configuration = Utility.shift_string(configuration, 1, true);
            inverse_configuration = Utility.inverse_rotor_configuration(this.configuration);

            bool turnover = (index == turnover_index);
            index = (index + 1) % 26;

            return turnover;
        }

        public char Get(char input, bool inverse) {
            int letter_index = Utility.alphabet_letter_to_number(input) - 1;
            if (letter_index < 0) { throw new ArgumentException("input not a letter"); }

            return (inverse == true) ? inverse_configuration[letter_index] : configuration[letter_index];            
        }
    }
}
