using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace IncognitoDBDecryptor
{
    class IncognitoOld
    {
        public static string Encrypt(string textToEncrypt)
        {
            return EncryptData(textToEncrypt, "@gPr5-3dGe-#5Dp@-Lt3");
        }
        public static string Decrypt(string encryptedText)
        {
            return DecryptData(encryptedText, "@gPr5-3dGe-#5Dp@-Lt3");
        }

        private static string EncryptData(string textData, string Encryptionkey)
        {
            if (textData.Trim().Length == 0) textData = " ";
            RijndaelManaged objrij = new RijndaelManaged();

            //set the mode for operation of the algorithm
            objrij.Mode = CipherMode.CBC;

            //set the padding mode used in the algorithm.
            objrij.Padding = PaddingMode.PKCS7;

            //set the size, in bits, for the secret key.
            objrij.KeySize = 0x80;

            //set the block size in bits for the cryptographic operation.
            objrij.BlockSize = 0x80;

            //set the symmetric key that is used for encryption & decryption.
            byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);

            //set the initialization vector (IV) for the symmetric algorithm
            byte[] EncryptionkeyBytes = new byte[] { 0x11, 0x41, 0x19, 0x05, 0x47, 0x21, 0x02, 0x77, 0x06, 0x12, 0x41, 0x40, 0x18, 0x00, 0x03, 0x01 };

            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }

            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;

            //Creates symmetric AES object with the current key and initialization vector IV.
            ICryptoTransform objtransform = objrij.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);

            //Final transform the test string.
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }
        private static string DecryptData(string EncryptedText, string Encryptionkey)
        {
            string retVal = String.Empty;
            try
            {
                RijndaelManaged objrij = new RijndaelManaged();
                objrij.Mode = CipherMode.CBC;
                objrij.Padding = PaddingMode.PKCS7;
                objrij.KeySize = 0x80;
                objrij.BlockSize = 0x80;
                byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
                byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
                byte[] EncryptionkeyBytes = new byte[0x10];
                int len = passBytes.Length;

                if (len > EncryptionkeyBytes.Length)
                {
                    len = EncryptionkeyBytes.Length;
                }

                Array.Copy(passBytes, EncryptionkeyBytes, len);
                objrij.Key = EncryptionkeyBytes;
                objrij.IV = EncryptionkeyBytes;
                byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
                retVal = Encoding.UTF8.GetString(TextByte);  //it will return readable string
            }
            catch (Exception ex)
            {
                //
            }
            return retVal;
        }
    }
}
