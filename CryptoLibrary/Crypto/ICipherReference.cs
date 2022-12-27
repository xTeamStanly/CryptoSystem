using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Crypto {
    internal interface ICipherReference {
        // ################ UINTs ################
        void Encrypt(ref uint[] input);
        void Decrypt(ref uint[] input);
    }
}
