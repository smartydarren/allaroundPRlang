using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleAppLearning.LearnConcepts
{
    internal class UrlEncrytp
    {
        public string GetEncryptUrl(string moveID)
        {
            string secretKey1 = "1$bb1089$%^J&*(t8898^&James$%^c18945m%v1";
            string secretKey2 = "j%k1&*(6678^&Jesus$%^6756";            
            
            var encryptedURL = HttpUtility.UrlEncode(secretKey1 + moveID + secretKey2);
            //var encryptedURL1 = HttpUtility.UrlEncode(moveID);

            return encryptedURL;
        }

        public string DecryptUrlForMoveID(string urlString)
        {
            var dencryptedURL = HttpUtility.UrlDecode(urlString);

            int index1 = dencryptedURL.IndexOf("m%v1", 0) + 4;
            int index2 = dencryptedURL.IndexOf("j%k1", 0);
            var getMoveId = dencryptedURL.Substring(index1, (index2 - index1));
            
            return getMoveId;
        }

    }
}
