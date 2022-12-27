using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public static class IO {

        private static void valid_filepath(string filepath) {
            if (filepath == null) { throw new ArgumentNullException("Filepath is null"); }
            filepath = filepath.Trim();
            if (filepath.Length == 0) { throw new ArgumentException("Filepath is empty"); }
        }

        public static byte[] OpenFile(string filepath) {
            valid_filepath(filepath);
            return File.ReadAllBytes(filepath);
        }

        public static void SaveFile(string filepath, byte[] bytes) {
            valid_filepath(filepath);

            if (bytes == null) { throw new ArgumentNullException("Input byte array is null"); }
            File.WriteAllBytes(filepath, bytes);
        }

        public static string[] OpenTextFile(string filepath) {
            valid_filepath(filepath);
            return File.ReadAllLines(filepath);
        }

        public static void SaveTextFile(string filepath, string[] input) {
            valid_filepath(filepath);
            if (input == null) { throw new ArgumentNullException("String array is null"); }

            // WriteAllLines radi append \r\n na svaku liniju
            // ukljucujuci i zadnju liniju, a mi to ne zelimo
            // File.WriteAllLines(filepath, input);

            File.WriteAllText(filepath, String.Join("\r\n", input));
        }

    }
}
