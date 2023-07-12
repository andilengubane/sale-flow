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
    public class Languages
    {
        public int LanguagesID { get; set; }
        public string Title { get; set; }

        public bool IsActive { get; set; }
        public bool Found { get
            { return _found; }
        }
        private bool _found = false;

        public static Languages GetLanguages(string language)
        {
            Languages retVal = new Languages();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@language", language)
            };

            string sql = "select * from Languages where IsActive = 1 and Title = @language";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if(results.Rows.Count>0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }
        public static Languages GetLanguages(int LanguagesID)
        {
            Languages retVal = new Languages();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@LanguagesID", LanguagesID)
            };

            string sql = "select * from Languages where IsActive = 1 and LanguagesID = @LanguagesID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        public static int SaveLanguage(string language, bool isActive, int LanguagesID = 0)
        {
            int retVal = 0;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ID", LanguagesID),
                new SqlParameter("@Title", language),
                new SqlParameter("@IsActive", isActive)
            };

                string sql = "spSaveLanguages";

                retVal = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }
        private static Languages MakeObject(DataRow inputRow)
        {
            Languages retValue = new Languages();

            retValue.LanguagesID = (int)inputRow["LanguagesID"];
            retValue.Title = (string)inputRow["Title"];
            retValue.IsActive = (bool)inputRow["IsActive"];
            retValue._found = true;

            return retValue;
        }

        public static List<Languages> GetAllLanguages()
        {
            List<Languages> retVal = new List<Languages>();
            string sql = "select * from Languages where IsActive = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }

        public static List<Languages> GetLanguagesByUserID(int userID)
        {
            List<Languages> retVal = new List<Languages>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "select l.* from Languages l inner join UserLanguages ul on l.LanguagesID = ul.LanguagesID where l.IsActive = 1 and ul.UserID = @userID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for( int i =0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }
    }
}
