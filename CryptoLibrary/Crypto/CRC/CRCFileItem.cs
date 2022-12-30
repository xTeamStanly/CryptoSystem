using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public class CRCFileItem {
        [System.ComponentModel.DisplayName("File Path")]
        public string FilePath { get; set; }

        [System.ComponentModel.DisplayName("Checksum")]
        public ulong CheckSum { get; set; }

        [System.ComponentModel.DisplayName("Checksum (Hex)")]
        public string CheckSumHex { get; set; }

        [System.ComponentModel.DisplayName("Date Calculated")]
        public DateTime DateCalculated { get; set; }

        [System.ComponentModel.DisplayName("Calculation Duration")]
        public string CalculationDuration { get; set; }

        [System.ComponentModel.DisplayName("File Size")]
        public string FileSize { get; set; }
    }
}
