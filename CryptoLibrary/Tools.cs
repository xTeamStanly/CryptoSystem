using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public static class Tools {

        public static byte[] RandomBytes(uint lenght) {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] result = new byte[lenght];
            rng.GetNonZeroBytes(result);
            rng.Dispose();
            return result;
        }

        public static string RandomString(uint lenght) {
            byte[] bytes = RandomBytes(lenght);
            return Convertor.bytes_to_string(bytes);
        }

    }
}
