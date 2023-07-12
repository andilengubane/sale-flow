using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Logger;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic.Campaigns.FNB
{
    public class CampaignBenefitsFNB
    {
        public int CampaignBenefitsID { get; set; }
        public int CampaignID { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal PremiumAmount { set { _premiumAmount = value; } get { return _premiumAmount; } }
        private decimal _premiumAmount = 0;
        public decimal BenefitAmount { set { _benefitAmount = value; } get { return _benefitAmount; } }
        private decimal _benefitAmount = 0;
        public bool Found { get { return _found; } }
        public bool _found = false;

        private static CampaignBenefitsFNB MakeObject(DataRow inputRow)
        {
            CampaignBenefitsFNB retValue = new CampaignBenefitsFNB();

            retValue.CampaignBenefitsID = (int)inputRow["CampaignBenefitsFNBID"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.MinAge = (int)inputRow["MinAge"];
            retValue.MaxAge = (int)inputRow["MaxAge"];
            retValue.PremiumAmount = (decimal)inputRow["PremiumAmount"];
            retValue.BenefitAmount = (decimal)inputRow["BenefitAmount"];
            retValue._found = true;

            return retValue;
        }
        public static CampaignBenefitsFNB GetBenefitAmount(int CampaignBenefitsID)
        {
            CampaignBenefitsFNB retVal = new CampaignBenefitsFNB();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignBenefitsFNBID", CampaignBenefitsID)
            };

            string sql = "select * from CampaignBenefitsFNB where CampaignBenefitsFNBID = @CampaignBenefitsFNBID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }
        public static List<CampaignBenefitsFNB> GetCampaignBenefitList(int CampaignID)
        {
            List<CampaignBenefitsFNB> retVal = new List<CampaignBenefitsFNB>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignId", CampaignID)
            };

            string sql = "select * from CampaignBenefitsFNB where CampaignID = @CampaignId";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }

        public static int SaveCampaignBenefits(int campaignID, int MinAge, int MaxAge, decimal premiumAmount, decimal benefitAmount)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID),
                new SqlParameter("@MinAge", MinAge),
                new SqlParameter("@MaxAge", MaxAge),
                new SqlParameter("@PremiumAmount", premiumAmount),
                new SqlParameter("@BenefitAmount", benefitAmount)
            };

            string sql = "spSaveCampaignBenefitsFNB";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static int SaveCampaignBenefits(int campaignBenefitsID, int campaignID, int MinAge, int MaxAge, decimal premiumAmount, decimal benefitAmount)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignBenefitsID", campaignBenefitsID),
                new SqlParameter("@CampaignID", campaignID),
                new SqlParameter("@MinAge", MinAge),
                new SqlParameter("@MaxAge", MaxAge),
                new SqlParameter("@PremiumAmount", premiumAmount),
                new SqlParameter("@BenefitAmount", benefitAmount)
            };

            string sql = "spSaveCampaignBenefits";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static bool RemoveCampaignBenefits(int campaignBenefitsID, string campaignID)
        {
            bool retval = false;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignBenefitsID", campaignBenefitsID),
                new SqlParameter("@CampaignID", campaignID)
            };

                string sql = "spDeleteCampaignBenefit";

                DataAccess.ExecuteSpNoReader(sql, parm);
                retval = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }
    }
}
