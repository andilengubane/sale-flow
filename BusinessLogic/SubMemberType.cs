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
    public class SubMemberType
    {
        public int SubMemberTypeID { get; set; }
        public string Title { get; set; }
        public bool Found { get { return _found; } }
        private bool _found = false;
        public static List<SubMemberType> GetAllSubMemberTypes()
        {
            List<SubMemberType> retVal = new List<SubMemberType>();

            string sql = "select * from SubMemberType;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
        public static SubMemberType GetSubMemberType(string title)
        {
            SubMemberType retVal = new SubMemberType();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@Title", title)
            };

            string sql = "select * from SubMemberType where Title = @Title";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static SubMemberType GetSubMemberType(int subMemberTypeID)
        {
            SubMemberType retVal = new SubMemberType();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", subMemberTypeID)
            };

            string sql = "select * from SubMemberType where ID = @ID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static int SaveSubMemberType(int ID, string title)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@Title", title),
                new SqlParameter("@ID", ID)
            };

            string sql = "spSaveSubMemberType";

            retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static int SaveSubMemberType(string title)
        {
            return SaveSubMemberType(0, title);
        }
        private static SubMemberType MakeObject(DataRow inputRow)
        {
            SubMemberType retValue = new SubMemberType();

            retValue.SubMemberTypeID = (int)inputRow["ID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }
    }
}
