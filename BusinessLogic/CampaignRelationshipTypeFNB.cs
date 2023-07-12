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
    public class CampaignRelationshipTypeFNB
    {
        public int CampaignRelationshipTypeFNBID { get; set; }
        public int CampaignID { get; set; }
        public int RelationshipTypeID { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;
        public int Minage { get; set; }
        public int Maxage { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal BenefitAmount { get; set; }

        public static CampaignRelationshipTypeFNB GetBenefitAmount(int CampaignRelationshipTypeFNBID)
        {
            CampaignRelationshipTypeFNB retVal = new CampaignRelationshipTypeFNB();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", CampaignRelationshipTypeFNBID)
            };

            string sql = "select * from CampaignRelationshipTypeFNB where ID = @ID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static CampaignRelationshipTypeFNB GetMinMaxAges(int RelationshipTypeID)
        {
            CampaignRelationshipTypeFNB retVal = new CampaignRelationshipTypeFNB();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@RelationshipTypeID", RelationshipTypeID)
            };

            string sql = "select * from CampaignRelationshipTypeFNB where RelationshipTypeID = @RelationshipTypeID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static List<CampaignRelationshipTypeFNB> GetRelationshipTypes(int campaignID)
        {
            List<CampaignRelationshipTypeFNB> retVal = new List<CampaignRelationshipTypeFNB>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "select cr.*, rt.Title from CampaignRelationshipTypeFNB cr inner join RelationshipType rt on cr.RelationshipTypeID = rt.ID where CampaignID = @campaignID";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }
        public static List<CampaignRelationshipTypeFNB> GetBenefitsByRelation(int relationshipTypeID)
        {
            List<CampaignRelationshipTypeFNB> retVal = new List<CampaignRelationshipTypeFNB>();

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@relationshipTypeID", relationshipTypeID)
            };

            string sql = "select cr.*, rt.Title from CampaignRelationshipTypeFNB cr inner join RelationshipType rt on cr.RelationshipTypeID = rt.ID where RelationshipTypeID = @relationshipTypeID";

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }
        public static int SaveCampaignRelationshipType(int relationshipTypeID, int campaignID, int minage, int maxage, decimal premiumAmount, decimal benefitAmount)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@relationshipTypeID", relationshipTypeID),
                new SqlParameter("@minage", minage),
                new SqlParameter("@maxage", maxage),
                new SqlParameter("@premiumAmount", premiumAmount),
                new SqlParameter("@benefitAmount", benefitAmount)
            };

            string sql = "spSaveCampaignRelationshipTypeFNB";

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

                string sql = "spDeleteCampaignRelationshipTypeFNB";

                DataAccess.ExecuteSpNoReader(sql, parm);
                retval = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }
        private static CampaignRelationshipTypeFNB MakeObject(DataRow inputRow)
        {
            CampaignRelationshipTypeFNB retValue = new CampaignRelationshipTypeFNB();

            retValue.CampaignRelationshipTypeFNBID = (int)inputRow["ID"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.RelationshipTypeID = (int)inputRow["RelationshipTypeID"];
            retValue.Minage = (int)inputRow["Minage"];
            retValue.Maxage = (int)inputRow["Maxage"];
            retValue.PremiumAmount = (decimal)inputRow["PremiumAmount"];
            retValue.BenefitAmount = (decimal)inputRow["BenefitAmount"];

            retValue._found = true;

            return retValue;
        }
    }
}
