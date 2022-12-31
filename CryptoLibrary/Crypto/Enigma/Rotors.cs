using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto.Enigma {
    public static class Rotors {
        // https://en.wikipedia.org/wiki/Enigma_rotor_details

        public enum RotorType {
            I = 0,
            II = 1,
            III = 2,
            
            IV = 3,
            V = 4,

            VI = 5,
            VII = 6,
            VIII = 7
        };

        public static Rotor[] rotors = new Rotor[] {
            // Enigma I (1930)
            new Rotor("Rotor I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", new char[] { 'Q' }, 'A', RotorType.I),
            new Rotor("Rotor II","AJDKSIRUXBLHWTMCQGZNPYFVOE", new char[] { 'E' }, 'A', RotorType.II),
            new Rotor("Rotor III","BDFHJLCPRTXVZNYEIWGAKMUSQO", new char[] { 'V' }, 'A', RotorType.III),

            // M3 Army (1938)
            new Rotor("Rotor IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", new char[] { 'J' }, 'A', RotorType.IV),
            new Rotor("Rotor V", "VZBRGITYUPSDNHLXAWMJQOFECK", new char[] { 'Z' }, 'A', RotorType.V),

            // M3 & M4 Naval (1939)
            new Rotor("Rotor VI", "JPGVOUMFYQBENHZRDKASXLICTW", new char[] { 'Z', 'M' }, 'A', RotorType.VI),
            new Rotor("Rotor VII", "NZJHGRCXMYSWBOUFAIVLPEKQDT", new char[] { 'Z', 'M' }, 'A', RotorType.VII),
            new Rotor("Rotor VIII", "FKQHTLXOCBJSPDZRAMEWNIUYGV", new char[] { 'Z', 'M' }, 'A', RotorType.VIII)
        };
    }
}
