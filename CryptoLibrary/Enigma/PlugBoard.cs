using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary.Enigma {
    internal class PlugBoard {
        private Dictionary<char, char> plug_board = null;

        public PlugBoard(string plug_board_configuration) {
            plug_board = Utility.plug_board_configuration_string_to_dictionary(plug_board_configuration);
        }

        public char Get(char letter) {
            letter = Char.ToUpper(letter);

            if (plug_board.ContainsKey(letter) == true) {
                return plug_board[letter];
            }

            return letter;
        }
    }
}
