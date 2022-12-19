using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary.Enigma {
    internal class RotorManager {

        private Rotor I = null;
        private Rotor II = null;
        private Rotor III = null;
        private Reflector reflector = null;

        private void setup(
            int I_key, string I_rotor_configuration, char I_rotor_turnover_letter,
            int II_key, string II_rotor_configuration, char II_rotor_turnover_letter,
            int III_key, string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration
        ) {
            I = new Rotor(I_rotor_configuration, I_rotor_turnover_letter);
            II = new Rotor(II_rotor_configuration, II_rotor_turnover_letter);
            III = new Rotor(III_rotor_configuration, III_rotor_turnover_letter);

            reflector = new Reflector(reflector_configuration);

            I_key = Utility.valid_rotor_key(I_key);
            II_key = Utility.valid_rotor_key(II_key);
            III_key = Utility.valid_rotor_key(III_key);


            // rotiramo rotor 3 da podesimo kljuc
            for (int i = 0 ;i < III_key ;i++) { IncrementRotors_III(); }

            // rotiramo rotor 2 da podesimo kljuc
            for (int i = 0 ;i < II_key ;i++) { IncrementRotors_II(); }

            // rotiramo rotor 1 da podesimo kljuc
            for (int i = 0 ;i < I_key ;i++) { IncrementRotors_I(); }
        }


        public RotorManager(
            int I_key,     string I_rotor_configuration,   char I_rotor_turnover_letter,
            int II_key,    string II_rotor_configuration,  char II_rotor_turnover_letter,
            int III_key,   string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration
        ) {
            setup(
                I_key,      I_rotor_configuration,      I_rotor_turnover_letter,
                II_key,     II_rotor_configuration,     II_rotor_turnover_letter,
                III_key,    III_rotor_configuration,    III_rotor_turnover_letter,
                reflector_configuration
            );
        }

        public RotorManager(
            char I_key,     string I_rotor_configuration,   char I_rotor_turnover_letter,
            char II_key,    string II_rotor_configuration,  char II_rotor_turnover_letter,
            char III_key,   string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration
        ) {
            int I_key_int = Utility.alphabet_letter_to_number(I_key);
            int II_key_int = Utility.alphabet_letter_to_number(II_key);
            int III_key_int = Utility.alphabet_letter_to_number(III_key);

            setup(
                I_key_int,      I_rotor_configuration,      I_rotor_turnover_letter,
                II_key_int,     II_rotor_configuration,     II_rotor_turnover_letter,
                III_key_int,    III_rotor_configuration,    III_rotor_turnover_letter,
                reflector_configuration
            );            
        }

        private void IncrementRotors_I() {
            I.Rotate();
        }

        private void IncrementRotors_II() {
            if (II.Rotate() == true) {
                I.Rotate();
            }
        }

        private void IncrementRotors_III() {
            
            if (III.Rotate() == true) {
                IncrementRotors_II();
            }

        }
        
        // letter path: IN -> R3 -> R2 -> R1 -> R -> R1 -> R2 -> R3 -> OUT
        public char Get(char letter) {

            IncrementRotors_III();

            letter = III.Get(letter, false);
            letter = II.Get(letter, false);
            letter = I.Get(letter, false);

            letter = reflector.Get(letter);

            letter = I.Get(letter, true);
            letter = II.Get(letter, true);
            letter = III.Get(letter, true);

            return letter;

        }

        public string Get(string message) {
            if (message == null) { throw new ArgumentNullException("null message"); }
            string output = "";

            foreach (char letter in message) {
                char new_letter = Get(letter);
                output += new_letter;
            }

            return output;
        }
    }
}
