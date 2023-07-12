using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    public class Clients
    {
        public int ClientsID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        private bool _found = false;
        public bool IsFound { get { return _found; } set { _found = value; } }

        private static Clients MakeObject(DataRow inputRow)
        {
            Clients retValue = new Clients();

            retValue.ClientsID = (int)inputRow["ClientsID"];
            retValue.Title = (string)inputRow["Title"];
            retValue.IsActive = (bool)inputRow["IsActive"];
            retValue._found = true;

            return retValue;
        }
        public static List<Clients> GetAllActiveClients()
        {
            List<Clients> retVal = new List<Clients>();

            string sql = "Select * from [Clients] where IsActive = 1 order by Title asc;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }

        public static List<Clients> GetAllClients()
        {
            List<Clients> retVal = new List<Clients>();

            string sql = "Select * from [Clients] order by Title asc;";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }

        public static int SaveClient(bool isActive, string title)
        {
            return SaveClient(0, isActive, title);
        }
        public static int SaveClient(int clientsID, bool isActive, string title)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@clientsID", clientsID),
                new SqlParameter("@title", title),
                new SqlParameter("@isActive", isActive)
            };

            string sql = "spSaveClients";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
    }
}
