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
    public class RelationshipType
    {
        public int RelationshipTypeID { get; set; }
        public string Title { get; set; }
        private bool _found = false;
        public bool Found { get { return _found; } }

        private static RelationshipType MakeObject(DataRow inputRow)
        {
            RelationshipType retValue = new RelationshipType();

            retValue.RelationshipTypeID = (int)inputRow["ID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }
        public static List<RelationshipType> GetRelationshipTypeList()
        {
            List<RelationshipType> retVal = new List<RelationshipType>();

            string sql = "select * from RelationshipType order by Title asc;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            return retVal;
        }

        public static int SaveRelationshipType(string title)
        {
            return SaveRelationshipType(0, title);
        }
        public static int SaveRelationshipType(int ID, string title)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@Title", title),
                new SqlParameter("@ID", ID)
                
            };

            string sql = "spSaveRelationshipType";

            retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public RelationshipType(int ID)
        {
            string sql = "select * from RelationshipType where ID = @ID";
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ID", ID)
            };

            DataTable data = DataAccess.ExecuteDataReader(sql, parm);
            if (data.Rows.Count > 0)
            {
                this.RelationshipTypeID = (int)data.Rows[0]["ID"];
                this.Title = (string)data.Rows[0]["Title"];
                this._found = true;
            }
            data.Dispose();
        }

        public static RelationshipType GetRelationshipType(int relationshipID)
        {
            return new RelationshipType(relationshipID);
        }

        public RelationshipType()
        { }
    }
}
