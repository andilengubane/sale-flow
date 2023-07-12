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
    public class WorkflowNextStep
    {        
        private string _currentStepName = String.Empty;
        private string _nextStepName = String.Empty;
        private bool _found = false;

        public int ID { get; set; }
        public int WorkflowNextStepID { get; set; }
        public int WorkflowCurrentStepID { get; set; }
        public int CampaignWorkflowStepID { get; set; }

        public string CurrentStepName
        {
            get
            {
                return _currentStepName;
            }
        }
        
        public string NextStepName
        {
            get
            {
                return _nextStepName;
            }
        }        

        public bool Found { get
            { return _found; }
        }

        /// <summary>
        /// Creates a new entry in the WorkFlowNextStep database table.
        /// </summary>
        /// <param name="currentWorkFlowStepID">An <see cref="int"/> value containing the current Workflow step ID.</param>
        /// <param name="nextWorkflowStepID">An <see cref="int"/> value containing the intended next Workflow step ID.</param>
        /// <param name="campaignWorkflowStepID">An <see cref="int"/> value containing the Workflow step ID for the campaign in question.</param>
        /// <returns>An <see cref="int"/> value containing the new ID of the new WorkflowNextStep database entry, or 0.</returns>
        public static int CreateWorkflowStepNextStep(int currentWorkFlowStepID, int nextWorkflowStepID, int campaignWorkflowStepID)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@WorkflowCurrentID", currentWorkFlowStepID),
                new SqlParameter("@WorkflowNextID", nextWorkflowStepID),
                new SqlParameter("@CampaignWorkflowStepID", campaignWorkflowStepID),
            };

            string sql = "spCreateWorflowNextStep";

            retval = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        /// <summary>
        /// Saves an entry in the WorkFlowNextStep database table.
        /// </summary>
        /// <param name="currentWorkFlowStepID">An <see cref="int"/> value containing the current Workflow step ID.</param>
        /// <param name="nextWorkflowStepID">An <see cref="int"/> value containing the intended next Workflow step ID.</param>
        /// <param name="campaignWorkflowStepID">An <see cref="int"/> value containing the Workflow step ID for the campaign in question.</param>
        /// <returns>An <see cref="int"/> value containing the ID of the new WorkflowNextStep database entry, or 0.</returns>
        public static int SaveWorkflowNextStep(int id, int currentWorkFlowStepID, int nextWorkflowStepID, int campaignWorkflowStepID)
        {
            int retVal = 0;
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@WorkflowCurrentID", currentWorkFlowStepID),
                    new SqlParameter("@WorkflowNextID", nextWorkflowStepID),
                    new SqlParameter("@CampaignWorkflowStepID", campaignWorkflowStepID),
                    new SqlParameter("@WID", id)
                };

                string sql = "spSaveWorflowNextStep";

                retVal = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + "\n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }
        
        /// <summary>
        /// Mini-factory method that generates a <see cref="DataRow"/> object from the database into a domain object.
        /// </summary>
        /// <param name="inputRow">A <see cref="DataRow"/> containing the data from the database to use when generating the new object.</param>
        /// <returns>A <see cref="WorkflowNextStep"/> object instantiated using the data from the passed <see cref="DataRow"/>.</returns>
        private static WorkflowNextStep MakeObject(DataRow inputRow)
        {
            WorkflowNextStep retValue = new WorkflowNextStep();

            retValue.ID = (int)inputRow["ID"];
            retValue.WorkflowCurrentStepID = (int)inputRow["WorkflowIDCurrent"];
            retValue.WorkflowNextStepID = (int)inputRow["WorkflowIDNext"];
            retValue.CampaignWorkflowStepID = (int)inputRow["CampaingWorkflowStepID"];

            retValue._nextStepName = (string)inputRow["NextStepName"];
            retValue._currentStepName = (string)inputRow["CurrentStepName"];

            retValue._found = true;

            return retValue;
        }

        /// <summary>
        /// Retrieves all WorkFlowNextStep data from the database.
        /// </summary>
        /// <param name="campaignID">An <see cref="int"/> value containing the campaign to pull for.</param>
        /// <returns>A List of <see cref="WorkflowNextStep"/> objects pulled from the database.</returns>
        public static List<WorkflowNextStep> GetAllWorkflowNextStepsByCampaignID(int campaignID)
        {
            List<WorkflowNextStep> retVal = new List<WorkflowNextStep>();
            string sql = "spGetAllWorkflowNextStepsByCampaignID";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@CampaignID", campaignID)
                };

            DataTable results = DataAccess.ExecuteSpDataReader(sql, parm);
            for (int i=0; i< results.Rows.Count; i++)
            {
                retVal.Add(MakeObject(results.Rows[i]));
            }
            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Retrieves a WorkFlowNextStep row from the database based on the passed ID.
        /// </summary>
        /// <param name="id">An <see cref="int"/> value containing the ID to find and pull from the database.</param>
        /// <returns>A <see cref="WorkflowNextStep"/> object containing the data pulled from the database.</returns>
        public static WorkflowNextStep GetWorkflowNextStepsByID(int id)
        {
            WorkflowNextStep retVal = new WorkflowNextStep();

            string sql = "spGetWorkflowNextStepsByID";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@ID", id)
                };

            DataTable results = DataAccess.ExecuteSpDataReader(sql, parm);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal = MakeObject(results.Rows[i]);
                break;
            }

            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Gets WorkflowNextSteps based on campaign ID and current WorkflowStep ID.
        /// </summary>
        /// <param name="campaignID">An <see cref="int"/> value containing the campaign ID to use.</param>
        /// <param name="currentWorkflowStepID">An <see cref="int"/> value containing the current WorkflowStep ID.</param>
        /// <returns>A <see cref="WorkflowNextStep"/> object containing the data fetched from the database.</returns>
        public static WorkflowNextStep GetWorkflowNextStepsByCampaignIdAndCurrentWorkflowStepID(int campaignID, int currentWorkflowStepID)
        {
            WorkflowNextStep retVal = new WorkflowNextStep();

            string sql = "spGetWorkflowNextStepsByCampaignIdAndCurrentWorkflowStepID";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@CampaignID", campaignID),
                    new SqlParameter("@CurrentWorkflowStepID", currentWorkflowStepID),
                };

            DataTable results = DataAccess.ExecuteDataReader(sql, parm);
            for (int i = 0; i < results.Rows.Count; i++)
            {
                retVal = MakeObject(results.Rows[i]);
                break;
            }

            results.Dispose();
            return retVal;
        }

        /// <summary>
        /// Deletes a WorkflowNextStep record from the database based on a passed ID.
        /// </summary>
        /// <param name="id">An <see cref="int"/> value containg the ID to delete from the database.</param>
        /// <returns>A <see cref="string"/> value containing either a success or failure message.</returns>
        public static string DeleteWorkflowNextStepsByID(int id)
        {
            string retVal = "Item successfully removed.";

            string sql = "spDeleteWorkflowNextStepsByID";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@ID", id)
                };

            try
            {
                DataAccess.ExecuteSpNoReader(sql, parm);
            }
            catch (Exception ex)
            {
                retVal = "FAIL: " + ex.Message;
            }
            return retVal;
        }

        /// <summary>
        /// Deletes a WorkflowNextStep record from the database based on a passed ID.
        /// </summary>
        /// <param name="id">An <see cref="int"/> value containg the ID to delete from the database.</param>
        /// <returns>A <see cref="bool"/> value signifying success (true) or failure (false).</returns>
        public bool Delete()
        {
            bool retVal = false;

            string sql = "spDeleteWorkflowNextStepsByID";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@ID", this.ID)
                };

            try
            {
                DataAccess.ExecuteSpNoReader(sql, parm);
                retVal = true;
            }
            catch(Exception ex)
            {
                evLogger.LogEvent(ex.Message + " \n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }
            
            return retVal;
        }

        /// <summary>
        /// Updates a WorkflowNextStep record in the database.
        /// </summary>
        /// <param name="currentWorkflowID">An <see cref="int"/> value containing the current Workflow ID.</param>
        /// <param name="nextWorkflowID">An <see cref="int"/> value containg the ID of the next Workflow step to move to.</param>
        /// <param name="campaignWorkflowStepID">An <see cref="int"/> value containing the ID of the Workflow step for the specific campaign.</param>
        /// <returns>A <see cref="bool"/> value signifying success (true) or failure (false).</returns>
        public bool Update(int currentWorkflowID, int nextWorkflowID, int campaignWorkflowStepID)
        {
            bool retVal = false;

            string sql = "spSaveWorkflowNextStep";

            List<SqlParameter> parm = new List<SqlParameter>()
                {
                    new SqlParameter("@ID", this.ID),
                    new SqlParameter("@WorkflowIDNext", nextWorkflowID),
                    new SqlParameter("@WorkflowIDCurrent", currentWorkflowID),
                    new SqlParameter("@CampaignWorkflowStepID", campaignWorkflowStepID)
                };

            try
            {
                int newID = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parm));

                if (newID > 0)
                {
                    retVal = true;
                    this.ID = newID;
                    this.WorkflowCurrentStepID = currentWorkflowID;
                    this.WorkflowNextStepID = nextWorkflowID;
                    this.CampaignWorkflowStepID = campaignWorkflowStepID;
                }
            }
            catch (Exception ex)
            {
                evLogger.LogEvent(ex.Message + " \n" + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error);
            }

            return retVal;
        }
    }
}
