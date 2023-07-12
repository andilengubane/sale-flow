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
    public class WorkflowStep
    {
        private bool _found = false;

        public int WorkflowID { get; set; }
        public string StepName { get; set; }
        public bool Found
        {
            get
            { return _found; }
        }

        public static WorkflowStep GetWorkflowStep(string stepName)
        {
            WorkflowStep retVal = new WorkflowStep();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@stepName", stepName)
            };

            string sql = "select * from WorkflowStep where StepName = @stepName";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if(results.Rows.Count>0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        public static WorkflowStep GetWorkflowStep(int workFlowID)
        {
            WorkflowStep retVal = new WorkflowStep();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@workFlowID", workFlowID)
            };

            string sql = "select * from WorkflowStep where ID = @workFlowID";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        public static int CreateWorkflowStep(string stepName)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@StepName", stepName)
            };

            string sql = "spCreateWorkflowStep";

            retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static int SaveWorkflowStep(int workflowStepId, string stepName)
        {
            int retVal = 0;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@ID", workflowStepId),
                new SqlParameter("@Title", stepName)
            };

                string sql = "spSaveWorkflowStep";

                retVal = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }

        private static WorkflowStep MakeObject(DataRow inputRow)
        {
            WorkflowStep retValue = new WorkflowStep();

            retValue.WorkflowID = (int)inputRow["ID"];
            retValue.StepName = (string)inputRow["StepName"];
            retValue._found = true;

            return retValue;
        }

        /// <summary>
        /// Retrieves all Workflow steps in the system.
        /// </summary>
        /// <returns>A List of all <see cref="WorkflowStep"/> objects in the system.</returns>
        public static List<WorkflowStep> GetAllWorkflowSteps()
        {
            List<WorkflowStep> retVal = new List<WorkflowStep>();

            string sql = "spGetAllWorkflowSteps";
            
            DataTable results = DataAccess.ExecuteSimpleDataReader(sql);
            
            for (int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Retrieves WorkflowStep data from the database using the passed Workflow step name and campaign ID.
        /// </summary>
        /// <param name="workflowStepName">A <see cref="string"/> value containing the name of the Workflow step name to be retrieved.</param>
        /// <param name="campaignId">An <see cref="int"/> value containing the ID of the campaign to filter by.</param>
        /// <returns>A <see cref="WorkflowStep"/> object populated with the data from the database.</returns>
        public static WorkflowStep GetWorkflowStepByNameAndCampaignID(string workflowStepName, int campaignId)
        {
            WorkflowStep retVal = new WorkflowStep();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignId),
                new SqlParameter("@StepName", workflowStepName)
            };

            string sql = "spGetWorkflowStepByNameAndCampaignID";

            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Retrieves WorkflowStep data from the database using the passed campaign ID
        /// </summary>
        /// <param name="campaignId">An <see cref="int"/> value containing the campaign ID to retrieve data for.</param>
        /// <returns>A List of <see cref="WorkflowStep"/> objects related to the passed campaign ID.</returns>
        public static List<WorkflowStep> GetWorkflowStepByCampaign(int campaignId)
        {
            List<WorkflowStep> retVal = new List<WorkflowStep>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignId)
            };

            string sql = "spGetWorkflowStepByCampaign";

            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            for( int i =0; i < results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }

            results.Dispose();
            return retVal;
        }
    }
}
