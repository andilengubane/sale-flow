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
    public class CampaignSubMemberType
    {
        public int CampaignSubMemberTypeID { get; set; }
        public int CampaignID { get; set; }
        public bool Found { get { return _found; } }
        public bool _found = false;

        public decimal PremiumAmount { set { _premiumAmount = value; } get { return _premiumAmount; } }
        private decimal _premiumAmount = 0;
        public decimal BenefitAmount { set { _benefitAmount = value; } get { return _benefitAmount; } }
        private decimal _benefitAmount = 0;

        public static List<SubMemberType> GetSubMemberTypes(int CampaignID)
        {
            List<SubMemberType> retVal = new List<SubMemberType>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignId", CampaignID)
            };

            string sql = "select s.* from CampaignSubMemberType c inner join SubMemberType s on c.SubMemberTypeID = s.ID where c.CampaignID = @CampaignId";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);

            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal.Add(SubMemberType.GetSubMemberType((int)results.Rows[i]["ID"]));
            }

            results.Dispose();
            results = null;

            return retVal;
        }

        public static int SaveCampaignSubMemberType( int campaignID, decimal premiumAmount, decimal benefitAmount)
        {
            return SaveCampaignSubMemberType(0, campaignID, premiumAmount, benefitAmount);
        }
        public static int SaveCampaignSubMemberType(int subMemberTypeID, int campaignID, decimal premiumAmount, decimal benefitAmount)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SubMemberTypeID", subMemberTypeID),
                new SqlParameter("@CampaignID", campaignID),
                new SqlParameter("@PremiumAmount", premiumAmount),
                new SqlParameter("@BenefitAmount", benefitAmount)
            };

            string sql = "spCreateCampaignSubMemberType";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static bool RemoveCampaignSubMemberType(int subMemberTypeID, string campaignID)
        {
            bool retval = false;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@SubMemberTypeID", subMemberTypeID),
                new SqlParameter("@CampaignID", campaignID)
            };

                string sql = "spDeleteCampaignSubMemberType";

                DataAccess.ExecuteSpNoReader(sql, parm);
                retval = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }
        private static CampaignSubMemberType MakeObject(DataRow inputRow)
        {
            CampaignSubMemberType retValue = new CampaignSubMemberType();

            retValue.CampaignSubMemberTypeID = (int)inputRow["ID"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.PremiumAmount = (decimal)inputRow["PremiumAmount"];
            retValue.BenefitAmount = (decimal)inputRow["BenefitAmount"];
            retValue._found = true;

            return retValue;
        }
    }
}
