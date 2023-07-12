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
    public class DPPOffer
    {
        public int DPPOfferID { get; set; }
        public string Title { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }
        private bool _found = false;

        private static DPPOffer MakeObject(DataRow inputRow)
        {
            DPPOffer retValue = new DPPOffer();

            retValue.DPPOfferID = (int)inputRow["DPPOfferID"];
            retValue.Title = (string)inputRow["Title"];
            retValue._found = true;

            return retValue;
        }

        public static List<DPPOffer> GetAllDPPOffers()
        {
            List<DPPOffer> retVal = new List<DPPOffer>();
            string sql = "select * from MCA_DPPOffer where IsActive = 1";
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
