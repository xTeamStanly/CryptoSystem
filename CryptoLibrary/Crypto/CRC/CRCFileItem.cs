namespace Library.Crypto {
    public class CRCFileItem {
        [System.ComponentModel.DisplayName("File Path")]
        public string FilePath { get; set; }

        [System.ComponentModel.DisplayName("Checksum")]
        public ulong CheckSum { get; set; }

        [System.ComponentModel.DisplayName("Checksum (Hex)")]
        public string CheckSumHex { get; set; }

        [System.ComponentModel.DisplayName("Calculation Duration")]
        public string CalculationDuration { get; set; }

        [System.ComponentModel.DisplayName("Threads")]
        public int ThreadCount { get; set; }

        [System.ComponentModel.DisplayName("File Size")]
        public string FileSize { get; set; }

        [System.ComponentModel.DisplayName("Offline")]
        public bool Offline { get; set; }
    }
}
