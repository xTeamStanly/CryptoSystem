using System;
using static Library.Crypto.Enigma.Reflectors;

namespace Library.Crypto.Enigma {
    public class Reflector {
        public ReflectorType type;
        private string configuration;
        private string name;

        public Reflector(string name, string configuration, ReflectorType type) {
            if (name == null) { throw new ArgumentNullException("Reflector name is null"); }
            if (name.Length == 0) { throw new ArgumentException("Reflector name is empty"); }
            this.name = name;

            this.configuration = Rotor.valid_rotor_configuration(configuration);

            this.type = type;
        }

        public Reflector(Reflector reflector) {
            if (reflector == null) { throw new ArgumentNullException("Input reflector is null"); }

            configuration = reflector.configuration;
            name = reflector.name;
            type = reflector.type;
        }

        private int get(int input, string input_config, string output_config) {
            char symbol = output_config[input];
            int output = input_config.IndexOf(symbol);
            return output;
        }
        public int encode(int input) { return get(input, Rotor.alphabet, configuration); }

        public override string ToString() {
            return name;
        }
    }
}
