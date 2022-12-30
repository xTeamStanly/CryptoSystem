using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    public interface ICipherValue {
        // ################ BYTES ################
        byte[] Encrypt(byte[] input);
        byte[] Decrypt(byte[] input);
    }
}
