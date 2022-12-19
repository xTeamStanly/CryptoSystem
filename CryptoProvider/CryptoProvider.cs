using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CryptoLibrary.Enigma;
namespace CryptoProvider {

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CryptoProvider : ICryptoProvider {

        public string EnigmaCrypt(EnigmaState state, string input) {
            try {

                Enigma enigma = new Enigma(
                    state.I_Key, state.I_Rotor_Configuration, state.I_Rotor_Turnover_Letter,
                    state.II_Key, state.II_Rotor_Configuration, state.II_Rotor_Turnover_Letter,
                    state.III_Key, state.III_Rotor_Configuration, state.III_Rotor_Turnover_Letter,
                    state.Reflector_Configuration, state.Plug_Board_Configuration
                );

                return enigma.Get(input);

            } catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
