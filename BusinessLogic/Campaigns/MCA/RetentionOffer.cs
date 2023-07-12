using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;


namespace BusinessLogic.Campaigns.MCA
{
    public class RetentionOffer
    {
        public int RetentionOfferID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static RetentionOffer MakeObject(DataRow inputRow)
        {
            RetentionOffer retValue = new RetentionOffer();

            retValue.RetentionOfferID = (int)inputRow["RetentionOfferID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<RetentionOffer> GetAllRetentionOffers()
        {
            List<RetentionOffer> retVal = new List<RetentionOffer>();
            string sql = "select * from MCA_RetentionOffer where IsActive = 1";
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }
    }
}
