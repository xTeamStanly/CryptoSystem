using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public static class IO {

        public static void valid_filepath(string filepath) {
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

        private static readonly string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string calculate_filesize(decimal filesize_bytes) {
            ulong unit_index = 0;
            while (filesize_bytes >= 1024) {
                filesize_bytes /= 1024;
                unit_index++;
            }

            return string.Format("{0:0.###} {1}", filesize_bytes, units[unit_index]);
        }

        public struct ThreadInfo {
            public int id;
            public long offset;
            public long lenght;
        }
        public static ThreadInfo[] calculate_thread_info(long data_lenght, long thread_count) {
            if (thread_count < 1) { throw new ArgumentException("Invalid thread count"); }
            if (data_lenght < 0) { throw new ArgumentException("Invalid data lenght"); }

            if (thread_count > data_lenght) { thread_count = 1; }
            
            ThreadInfo[] result = new ThreadInfo[thread_count];
            if (thread_count == 1) {
                // jedan jedini thread
                result[0] = new ThreadInfo {
                    id = 0,
                    offset = 0,
                    lenght = data_lenght
                };
            } else {
                // 2 ili vise (N) thread-ova
                // N - 1 thread-ova imaju istu duzinu podataka
                // N-ti thread ima vecu (za data_lenght % thread_count)

                long thread_data_size = data_lenght / thread_count;
                int i;

                // N - 1 thread-ova
                for (i = 0 ; i < thread_count - 1 ; i++) {
                    result[i] = new ThreadInfo {
                        id = i,
                        offset = i * thread_data_size,
                        lenght = thread_data_size
                    };
                }

                // N-ti thread
                long last_thread_data_size = thread_data_size + data_lenght % thread_count;
                result[i] = new ThreadInfo {
                    id = i,
                    offset = i * thread_data_size,
                    lenght = last_thread_data_size
                };
            }

            return result;
        }
    }
}
