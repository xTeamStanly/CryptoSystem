using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary.Enigma {    
    public class Enigma {

        private RotorManager rotor_manager = null;
        private PlugBoard plug_board = null;

        private void setup(
            // rotor manager
            int I_key, string I_rotor_configuration, char I_rotor_turnover_letter,
            int II_key, string II_rotor_configuration, char II_rotor_turnover_letter,
            int III_key, string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration,

            // plug board
            string plug_board_configuration
        ) {
            rotor_manager = new RotorManager(
                I_key, I_rotor_configuration, I_rotor_turnover_letter,
                II_key, II_rotor_configuration, II_rotor_turnover_letter,
                III_key, III_rotor_configuration, III_rotor_turnover_letter,
                reflector_configuration
            );

            plug_board = new PlugBoard(plug_board_configuration);
        }

        public Enigma(
            int I_key, string I_rotor_configuration, char I_rotor_turnover_letter,
            int II_key, string II_rotor_configuration, char II_rotor_turnover_letter,
            int III_key, string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration, string plug_board_configuration
        ) {
            setup(
                I_key, I_rotor_configuration, I_rotor_turnover_letter,
                II_key, II_rotor_configuration, II_rotor_turnover_letter,
                III_key, III_rotor_configuration, III_rotor_turnover_letter,
                reflector_configuration, plug_board_configuration
            );
        }

        public Enigma(
            char I_key, string I_rotor_configuration, char I_rotor_turnover_letter,
            char II_key, string II_rotor_configuration, char II_rotor_turnover_letter,
            char III_key, string III_rotor_configuration, char III_rotor_turnover_letter,
            string reflector_configuration, string plug_board_configuration
        ) {
            int I_key_int = Utility.alphabet_letter_to_number(I_key);
            int II_key_int = Utility.alphabet_letter_to_number(II_key);
            int III_key_int = Utility.alphabet_letter_to_number(III_key);

            setup(
                I_key_int, I_rotor_configuration, I_rotor_turnover_letter,
                II_key_int, II_rotor_configuration, II_rotor_turnover_letter,
                III_key_int, III_rotor_configuration, III_rotor_turnover_letter,
                reflector_configuration, plug_board_configuration
            );
        }

        private char Get(char letter) {
            
            letter = plug_board.Get(letter);
            letter = rotor_manager.Get(letter);
            letter = plug_board.Get(letter);

            return letter;
        }

        public string Get(string message) {
            if (message == null) { throw new ArgumentNullException("null message"); }
            string output = "";

            message = Utility.remove_all_whitespace_from_string(message);

            foreach (char letter in message) {
                char new_letter = Get(letter);
                output += new_letter;
            }

            return output;
        }

    }
}
