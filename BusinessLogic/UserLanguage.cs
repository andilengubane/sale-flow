using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    public class UserLanguage
    {
        public int ID { get; set; }
        public int LanguagesID { get; set; }
        public int UsersID { get; set; }
        public bool IsActive  { get; set; }
        public bool Found { get
            { return _found; }
        }
        private bool _found = false;

        public static int SaveUserLanguage(int userID, int languageID, bool isActive = true)
        {
            int retVal = 0;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@LanguageID", languageID),
                new SqlParameter("@IsActive", isActive)
            };

                string sql = "spSaveUserLanguages";

                retVal = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }
        private static UserLanguage MakeObject(DataRow inputRow)
        {
            UserLanguage retValue = new UserLanguage();

            retValue.LanguagesID = (int)inputRow["LanguagesID"];
            retValue.ID = (int)inputRow["UserLanguagesID"];
            retValue.UsersID = (int)inputRow["UserID"];
            retValue.IsActive = (bool)inputRow["IsActive"];
            retValue._found = true;

            return retValue;
        }
        public static List<UserLanguage> GetLanguagesByUserID(int userID)
        {
            List<UserLanguage> retVal = new List<UserLanguage>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "select ul.* from Languages l inner join UserLanguages ul on l.LanguagesID = ul.LanguagesID where l.IsActive = 1 and ul.UserID = @userID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for( int i =0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }

        public static UserLanguage GetLanguagesByUserIdAndLanguageID(int userID, int languageID)
        {
            UserLanguage retVal = new UserLanguage();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID),
                new SqlParameter("@languageID", languageID)
            };

            string sql = "select ul.* from Languages l inner join UserLanguages ul on l.LanguagesID = ul.LanguagesID where l.IsActive = 1 and ul.UserID = @userID and ul.LanguagesID = @languageID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }

            results.Dispose();
            return retVal;
        }

        public bool Delete()
        {
            bool retVal = false;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userLanguageID", this.ID)
            };
            
            string sql = "delete from UserLanguages where userLanguagesID = @userLanguageID ";
            try
            {
                DataAccess.ExecuteNoReader(sql, parms);
                retVal = true;
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + " \n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            return retVal;
        }
    }
}
