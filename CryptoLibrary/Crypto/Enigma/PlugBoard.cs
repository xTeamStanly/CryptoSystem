using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Crypto.Enigma {
    public class PlugBoard {

        private static string plugboard_configuration_string_to_string(string configuration_string) {
            StringBuilder result = new StringBuilder(Rotor.alphabet);
            
            if (configuration_string == null) { return result.ToString(); }

            configuration_string = configuration_string.ToUpper();
            configuration_string = Regex.Replace(configuration_string, " ", "");

            int configuration_string_lenght = configuration_string.Length;
            if (configuration_string_lenght % 2 == 1) {
                configuration_string.Remove(configuration_string_lenght - 1, 1);
            }

            bool all_letters = configuration_string.All(i => (i >= 'A' && i <= 'Z'));
            if (all_letters == false) { throw new Exception("Invalid characters in plugboard configuration string"); }

            configuration_string_lenght = configuration_string.Length;
            for (int i = 0 ; i < configuration_string_lenght ; i += 2) {
                char first = configuration_string[i];
                char second = configuration_string[i + 1];

                if (first == second) { continue; }

                string result_string = result.ToString();
                int first_index = result_string.IndexOf(first);
                int second_index = result_string.IndexOf(second);

                result[first_index] = second;
                result[second_index] = first;
            }

            return result.ToString();
        }

        private string configuration;

        public PlugBoard(string configuration) {
            this.configuration = plugboard_configuration_string_to_string(configuration);
        }

        private int get(int input, string input_config, string output_config) {
            char symbol = output_config[input];
            int output = input_config.IndexOf(symbol);
            return output;
        }
        public int encode(int input) { return get(input, Rotor.alphabet, configuration); }
    }
}
