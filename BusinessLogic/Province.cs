using System;
using Helper;
using System.Linq;
using System.Text;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static Province MakeObject(DataRow inputRow)
        {
            Province province = new Province();

            province.Id = (int)inputRow["Id"];
            province.Name = (string)inputRow["Name"];
            return province;
        }
        public static List<Province> GetProvince(int provinceId)
        {
            List<Province> province = new List<Province>();

            string sql = "select * from Province Where ID = "+ provinceId +"";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                province.Add(MakeObject(results.Rows[i]));
            }
            return province;
        }
    }
}
