using System;

namespace Library.Crypto {
    public class CRCPlaintextItem {
        [System.ComponentModel.DisplayName("Content")]
        public string Content { get; set; }

        [System.ComponentModel.DisplayName("Checksum")]
        public ulong CheckSum { get; set; }

        [System.ComponentModel.DisplayName("Checksum (Hex)")]
        public string CheckSumHex { get; set; }

        [System.ComponentModel.DisplayName("Date Calculated")]
        public DateTime DateCalculated { get; set; }

        [System.ComponentModel.DisplayName("Length")]
        public int Length { get; set; }
    }
}
