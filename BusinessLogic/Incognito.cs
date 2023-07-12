using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BusinessLogic
{
    /// <summary>
    /// Class for handling field encryption and decryption.
    /// </summary>
    internal class Incognito
    {

        #region public methods

        public static string Encrypt(string textToEncrypt)
        {
            return EncryptData(textToEncrypt, "@gPr5-3dGe-#5Dp@-Lt3");
        }

        public static string Decrypt(string encryptedText)
        {
            return DecryptData(encryptedText, "@gPr5-3dGe-#5Dp@-Lt3");
        }

        #endregion

        #region The private methods

        /// <summary>
        /// Encrypts a string using a symmetric algorith on the database server.
        /// </summary>
        /// <param name="EncryptedText">A <see cref="string"/> value containing the unencrypted data.</param>
        /// <param name="Encryptionkey">A <see cref="string"/> value containing the encryption key to use for the encryption.</param>
        /// <returns>A <see cref="string"/> containing the decrypted value.</returns>
        private static string EncryptData(string textData, string Encryptionkey)
        {
            string sqlsp = "spEncEncryptString";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["primarySQL"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(sqlsp, conn);
            conn.Open();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@StringToEncrypt", SqlDbType.Text).Value = textData;
            da.SelectCommand.CommandTimeout = 60000;

            DataSet ds = new DataSet();
            da.Fill(ds, "GetRecordingRecors");
            DataTable dtcl = ds.Tables["GetRecordingRecors"];

            conn.Dispose();
            da.Dispose();
            ds.Dispose();
            return dtcl.Rows[0][0].ToString();
        }

        /// <summary>
        /// Decrypts an encrypted string using a symmetric algorithm on the database server.
        /// </summary>
        /// <param name="EncryptedText">A <see cref="string"/> value containing the encrypted data.</param>
        /// <param name="Encryptionkey">A <see cref="string"/> value containing the encryption key to use for the decryption.</param>
        /// <returns>A <see cref="string"/> containing the decrypted value.</returns>
        private static string DecryptData(string EncryptedText, string Encryptionkey)
        {
            string sqlsp = "spEncDeEncryptString";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["primarySQL"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(sqlsp, conn);
            conn.Open();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@StringToDeEncrypt", SqlDbType.Text).Value = EncryptedText;
            da.SelectCommand.CommandTimeout = 60000;

            DataSet ds = new DataSet();
            da.Fill(ds, "GetRecordingRecors");
            DataTable dtcl = ds.Tables["GetRecordingRecors"];

            conn.Dispose();
            da.Dispose();
            ds.Dispose();
            return dtcl.Rows[0][0].ToString();
        }

        #endregion

    }
}