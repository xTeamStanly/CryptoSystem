﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CryptoProvider {
    [ServiceContract]
    public interface ICryptoProvider {

        [OperationContract]
        string EnigmaCrypt(EnigmaState state, string input);
    }

    [DataContract]
    public class EnigmaState {
        int I_key;
        [DataMember]
        public int I_Key {
            get { return I_key; }
            set { I_key = value; }
        }

        int II_key;
        [DataMember]
        public int II_Key {
            get { return II_key; }
            set { II_key = value; }
        }

        int III_key;
        [DataMember]
        public int III_Key {
            get { return III_key; }
            set { III_key = value; }
        }

        char I_rotor_turnover_letter;
        [DataMember]
        public char I_Rotor_Turnover_Letter {
            get { return I_rotor_turnover_letter; }
            set { I_rotor_turnover_letter = value; }
        }

        char II_rotor_turnover_letter;
        [DataMember]
        public char II_Rotor_Turnover_Letter {
            get { return II_rotor_turnover_letter; }
            set { II_rotor_turnover_letter = value; }
        }

        char III_rotor_turnover_letter;
        [DataMember]
        public char III_Rotor_Turnover_Letter {
            get { return III_rotor_turnover_letter; }
            set { III_rotor_turnover_letter = value; }
        }

        string I_rotor_configuration;
        [DataMember]
        public string I_Rotor_Configuration {
            get { return I_rotor_configuration; }
            set { I_rotor_configuration = value; }
        }

        string II_rotor_configuration;
        [DataMember]
        public string II_Rotor_Configuration {
            get { return II_rotor_configuration; }
            set { II_rotor_configuration = value; }
        }

        string III_rotor_configuration;
        [DataMember]
        public string III_Rotor_Configuration {
            get { return III_rotor_configuration; }
            set { III_rotor_configuration = value; }
        }

        string reflector_configuration;
        [DataMember]
        public string Reflector_Configuration {
            get { return reflector_configuration; }
            set { reflector_configuration = value; }
        }

        string plug_board_configuration;
        [DataMember]
        public string Plug_Board_Configuration {
            get { return plug_board_configuration; }
            set { plug_board_configuration = value; }
        }
    }
}
