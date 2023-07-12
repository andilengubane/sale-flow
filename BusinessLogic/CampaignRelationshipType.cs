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
    public class CampaignRelationshipType
    {
        public int CampaignRelationshipTypeID { get; set; }
        public int CampaignID { get; set; }
        public int RelationshipTypeID { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;
        public decimal PremiumAmount { get; set; }
        public decimal BenefitAmount { get; set; }
        public string Title { get { return _title; } }
        private string _title = string.Empty;

        public static List<CampaignRelationshipType> GetRelationshipTypes(int campaignID)
        {
            List<CampaignRelationshipType> retVal = new List<CampaignRelationshipType>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "select cr.*, rt.Title from CampaignRelationshipType cr inner join RelationshipType rt on cr.RelationshipTypeID = rt.ID where CampaignID = @campaignID";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }

        public static int SaveCampaignRelationshipType(int relationshipTypeID, int campaignID, decimal premiumAmount, decimal benefitAmount)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@relationshipTypeID", relationshipTypeID),
                new SqlParameter("@premiumAmount", premiumAmount),
                new SqlParameter("@benefitAmount", benefitAmount)
            };

            string sql = "spSaveCampaignRelationshipType";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static bool RemoveCampaignRelationshipType(int relationshipTypeID, int campaignID)
        {
            bool retval = false;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@RelationshipType", relationshipTypeID),
                new SqlParameter("@CampaignID", campaignID)
            };

                string sql = "spDeleteCampaignRelationshipType";

                DataAccess.ExecuteSpNoReader(sql, parm);
                retval = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }
        private static CampaignRelationshipType MakeObject(DataRow inputRow)
        {
            CampaignRelationshipType retValue = new CampaignRelationshipType();

            retValue.CampaignRelationshipTypeID = (int)inputRow["ID"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.RelationshipTypeID = (int)inputRow["RelationshipTypeID"];
            retValue.PremiumAmount = (decimal)inputRow["PremiumAmount"];
            retValue.BenefitAmount = (decimal)inputRow["BenefitAmount"];
            retValue._title = inputRow["Title"].ToString();

            retValue._found = true;

            return retValue;
        }
    }
}
