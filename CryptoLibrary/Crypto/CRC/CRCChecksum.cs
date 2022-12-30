using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    
    public struct CRCPolynomial {
        public string Name;
        public string Polynomial;

        // combobox tostring override
        override public string ToString() {
            return Name;
        }

    }

    public static class CRCChecksum {

        // https://en.wikipedia.org/wiki/Cyclic_redundancy_check#Polynomial_representations_of_cyclic_redundancy_checks
        public static ArrayList algorithms = new ArrayList() {
            new CRCPolynomial { Name = "CRC-1", Polynomial = "11" },
            new CRCPolynomial { Name = "CRC-3-GSM", Polynomial = "1011" },
            new CRCPolynomial { Name = "CRC-4-ITU", Polynomial = "10011" },
            new CRCPolynomial { Name = "CRC-5-EPC", Polynomial = "101001" },
            new CRCPolynomial { Name = "CRC-5-ITU", Polynomial = "110101" },
            new CRCPolynomial { Name = "CRC-5-USB", Polynomial = "100101" },
            new CRCPolynomial { Name = "CRC-6", Polynomial = "1100001" },
            new CRCPolynomial { Name = "CRC-6-GSM", Polynomial = "1101111" },
            new CRCPolynomial { Name = "CRC-6-ITU", Polynomial = "1000011" },
            new CRCPolynomial { Name = "CRC-7", Polynomial = "10001001" },
            new CRCPolynomial { Name = "CRC-8", Polynomial = "111010101" },
            new CRCPolynomial { Name = "CRC-8-AUTOSAR", Polynomial = "100101111" },
            new CRCPolynomial { Name = "CRC-8-Bluetooth", Polynomial = "110100111" },
            new CRCPolynomial { Name = "CRC-8-CCITT", Polynomial = "100000111" },
            new CRCPolynomial { Name = "CRC-8-Dallas/Maxim", Polynomial = "100110001" },
            new CRCPolynomial { Name = "CRC-8-DARC", Polynomial = "100111001" },
            new CRCPolynomial { Name = "CRC-8-GSM-B", Polynomial = "101001001" },
            new CRCPolynomial { Name = "CRC-8-SAE J1850", Polynomial = "100011101" },
            new CRCPolynomial { Name = "CRC-8-WCDMA", Polynomial = "110011011" },
            new CRCPolynomial { Name = "CRC-10", Polynomial = "11000110011" },
            new CRCPolynomial { Name = "CRC-11", Polynomial = "101110000101" },
            new CRCPolynomial { Name = "CRC-12", Polynomial = "1100000001111" },
            new CRCPolynomial { Name = "CRC-13-BBC", Polynomial = "11110011110101" },
            new CRCPolynomial { Name = "CRC-15-CAN", Polynomial = "1100010110011001" },
            new CRCPolynomial { Name = "CRC-16-CCITT", Polynomial = "10001000000100001" },
            new CRCPolynomial { Name = "CRC-16-DECT", Polynomial = "10000010110001001" },
            new CRCPolynomial { Name = "CRC-16-T10-DIF", Polynomial = "11000101110110111" },
            new CRCPolynomial { Name = "CRC-16-DNP", Polynomial = "10011110101100101" },
            new CRCPolynomial { Name = "CRC-16-IBM", Polynomial = "11000000000000101" },
            new CRCPolynomial { Name = "CRC-24", Polynomial = "1010111010110110111001011" },
            new CRCPolynomial { Name = "CRC-24-Radix-64", Polynomial = "1100001100100110011111011" },
            new CRCPolynomial { Name = "CRC-24-WCDMA", Polynomial = "1100000000000000001100011" },
            new CRCPolynomial { Name = "CRC-30", Polynomial = "1100000001100001011100111000111" },
            new CRCPolynomial { Name = "CRC-32", Polynomial = "100000100110000010001110110110111" },
            new CRCPolynomial { Name = "CRC-32C (Castagnoli)", Polynomial = "100011110110111000110111101000001" },
            new CRCPolynomial { Name = "CRC-32K (Koopman)", Polynomial = "101110100000110111000110011010111" },
            new CRCPolynomial { Name = "CRC-32Q", Polynomial = "110000001010000010100000110101011" },
            new CRCPolynomial { Name = "CRC-40-GSM", Polynomial = "10000000000000100100000100000000000001001" },
            new CRCPolynomial { Name = "CRC-64-ECMA", Polynomial = "10100001011110000111000011110101110101001111010100011011010010011" },
            new CRCPolynomial { Name = "CRC-64-ISO", Polynomial = "10000000000000000000000000000000000000000000000000000000000011011" }            
        };

        public static CRCPolynomial Get(int index) {
            if (index < 0 || index >= algorithms.Count) { throw new IndexOutOfRangeException("Index out of range"); }
            return (CRCPolynomial)algorithms[index];
        }
    }
}
