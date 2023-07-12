using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic.Campaigns
{
	public class Agents
	{
		public int ProductID { get; set; }
		public string Title { get; set; }
		public bool Found { get { return _found; } }
		public bool _found = false;

		public static List<Agents> GetProducts()
		{
			List<Agents> retVal = new List<Agents>();

			List<SqlParameter> parm = new List<SqlParameter>()
			{
				new SqlParameter("@IsActive", true)
			};

			string sql = "select * from Agents where IsActive = @IsActive";

			DataTable results = DataAccess.ExecuteDataReader(sql, parm);

			for (int i = 0; i < results.Rows.Count; i++)
			{
				retVal.Add(MakeObject(results.Rows[i]));
			}

			results.Dispose();
			results = null;

			return retVal;
		}
		private static Agents MakeObject(DataRow inputRow)
		{
			Agents retValue = new Agents();

			retValue.ProductID = (int)inputRow["AgentID"];
			retValue.Title = (string)inputRow["AgentName"];
			retValue._found = true;

			return retValue;
		}
	}
}
