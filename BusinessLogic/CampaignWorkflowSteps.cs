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
    public class CampaignWorkflowSteps
    {
        public int CampaignWorkflowStepsID { get; set; }
        public int WorkflowStepID { get; set; }
        public int CampaignID { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        private bool _found = false;

        public string WorkFlowStepName
        {
            get
            {
                return WorkflowStep.GetWorkflowStep(this.WorkflowStepID).StepName;
            }
        }

        public static List<CampaignWorkflowSteps> GetWorkflowStepsList(int campaignID)
        {
            List<CampaignWorkflowSteps> retVal = new List<CampaignWorkflowSteps>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignId", campaignID)
            };

            string sql = "select * from CampaignWorkflowSteps where CampaignID = @CampaignId";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);

            for (int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            return retVal;
        }

        public static int AddWorkflowStepToCampaign(int workflowStepID, int campaignID)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@WorkflowStepID", workflowStepID),
                new SqlParameter("@CampaignID", campaignID)
            };

            string sql = "spCreateCampaignWorkflowStep";

            retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
        public static bool RemoveWorkflowStepFromCampaign(int workflowStepID, string campaignID)
        {
            bool retval = false;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@WorkflowStepId", workflowStepID),
                new SqlParameter("@CampaignID", campaignID)
            };

                string sql = "spDeleteCampaignWorkflowStep";

                DataAccess.ExecuteSpNoReader(sql, parm);
                retval = true;
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retval;
        }
        private static CampaignWorkflowSteps MakeObject(DataRow inputRow)
        {
            CampaignWorkflowSteps retValue = new CampaignWorkflowSteps();

            retValue.CampaignWorkflowStepsID = (int)inputRow["ID"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.WorkflowStepID = (int)inputRow["WorkflowStepID"];
            retValue._found = true;

            return retValue;
        }
    }
}
