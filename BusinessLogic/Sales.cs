using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;
using Utils.Logger;

namespace BusinessLogic
{
    public class Sales
    {
        private bool _found = false;

        public int ID { get; set; }
        public int LeadID { get; set; }
        public int CampaignID { get; set; }
        public DateTime CaptureDate { get; set; }
        public string CaptureBy { get; set; }
        public int WorkflowStepID { get; set; }        
        public string VerifiedBy { get; set; }
        public DateTime VerifiedDate { get; set; }
        public string Status { get; set; }
        public bool IsDialed { get; set; }
        public bool IsDeleted { get; set; }
        public int BatchID { get; set; }
        public int UserID { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
        public string Extra6 { get; set; }
        public string Extra7 { get; set; }
        public string Extra8 { get; set; }
        public string Extra9 { get; set; }
        public string Extra10 { get; set; }
        public int LanguagesID { get; set; }
        public string WorkFlowStep
        {
            get
            {
                string retVal = string.Empty;
                WorkflowStep wf = WorkflowStep.GetWorkflowStep(this.WorkflowStepID);
                if (wf.Found)
                {
                    retVal = wf.StepName;
                }
                wf = null;
                return retVal;
            }
        }

        public int AgentCode
        {
            get
            {
                return Users.GetUserByID(this.UserID).AgentCode;
            }
        }

        public bool Found
        {
            get
            { return _found; }
        }
        
        public string CampaignName
        {
            get
            {
                return new Campaign(this.CampaignID).Title;
            }
        }
                
        public string LanguageDescription
        {
            get
            {
                string retVal = "None";
                Languages lang = Languages.GetLanguages(this.LanguagesID);
                if(lang.Found)
                {
                    retVal = lang.Title;
                }
                lang = null;
                return retVal;
            }
        }

        public SalesLog CurrentSaleLog { get { return SalesLog.GetCurrentSalesLog(this.ID); } }

        public static Sales GetSale(int saleID)
        {
            Sales retVal = new Sales();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", saleID)
            };

            string sql = "spGetSaleByID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        public static Sales GetSale(int leadID, int campaignId)
        {
            Sales retVal = new Sales();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@LeadID", leadID),
                new SqlParameter("@CampaignID", campaignId)
            };

            string sql = "spGetSaleByLeadIDAndCampaignID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            results.Dispose();
            return retVal;
        }

        public static List<Sales> GetSalesByCampaignAndWorkflowStep(int campaignId, int currentWorkflowStepID)
        {
            List<Sales> retVal = new List<Sales>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignId),
                new SqlParameter("@WorkflowStepID", currentWorkflowStepID)
            };

            string sql = "spGetSalesByCampaignAndWorkflowStep";
            DataTable data = DataAccess.ExecuteSpDataReader(sql, parms);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            return retVal;
        }

        public static List<Sales> GetAllSaleByCampaignID(int campaignId)
        {


            string sql = "select * from Sales where CampaignID = "+ campaignId + " AND WorkFlowStepID = 4"; //TODO : find the WorkFlow Step ID
            DataTable data = DataAccess.ExecuteSimpleDataReader(sql);

            List<Sales> retVal = new List<Sales>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            return retVal;
        }

        public static int GetSaleTotalByBatchID(int batchID)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@BatchID", batchID)
            };

            string sql = "spGetSaleTotalByBatchID";
            retVal = Convert.ToInt32( DataAccess.ExecuteSpScalar(sql, parms));
            
            return retVal;
        }

        public static Sales UpdateSaleStatus(int saleID)
        {
            Sales retVal = new Sales();
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@ID", saleID)
            };

            string sql = "spUpdateSaleStatusID";
            DataTable results = DataAccess.ExecuteSpDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = MakeObject(results.Rows[0]);
            }
            return retVal;
        }

        public static int SaveSale(int saleID, int userID, string capturedBy, DateTime captureDate, int workflowStepId, string status, string extra1 = "", string extra2 = "", string extra3 = "", string extra4 = "", string extra5 = "", string extra6 = "", string extra7 = "", string extra8 = "", string extra9 = "", string extra10 = "", int languagesID = 0)
        {
            int retval = 0;
            Sales sal = Sales.GetSale(saleID);
            string sql = string.Empty;

            if (sal.Found)
            {
                List<SqlParameter> parm;

                if (sal.IsDialed)
                {
                    sql = "spSaveSales";
                    parm = new List<SqlParameter>()
                    {
                        new SqlParameter("@capturedBy", sal.CaptureBy),
                        new SqlParameter("@captureDate", sal.CaptureDate),
                        new SqlParameter("@workflowStepId", workflowStepId),
                        new SqlParameter("@IsDialed", true),
                        new SqlParameter("@status", status),
                        new SqlParameter("@saleID", saleID),
                        new SqlParameter("@Extra1", extra1),
                        new SqlParameter("@Extra2", extra2),
                        new SqlParameter("@Extra3", extra3),
                        new SqlParameter("@Extra4", extra4),
                        new SqlParameter("@Extra5", extra5),
                        new SqlParameter("@Extra6", extra6),
                        new SqlParameter("@Extra7", extra7),
                        new SqlParameter("@Extra8", extra8),
                        new SqlParameter("@Extra9", extra9),
                        new SqlParameter("@Extra10", extra10),
                        new SqlParameter("@LanguagesID", languagesID)
                    };
                }
                else
                {
                    sql = "spSaveNewSale";
                    parm = new List<SqlParameter>()
                    {
                        new SqlParameter("@capturedBy", capturedBy),
                        new SqlParameter("@userID", userID),
                        new SqlParameter("@captureDate", captureDate),
                        new SqlParameter("@workflowStepId", workflowStepId),
                        new SqlParameter("@IsDialed", true),
                        new SqlParameter("@status", status),
                        new SqlParameter("@saleID", saleID),
                        new SqlParameter("@Extra1", extra1),
                        new SqlParameter("@Extra2", extra2),
                        new SqlParameter("@Extra3", extra3),
                        new SqlParameter("@Extra4", extra4),
                        new SqlParameter("@Extra5", extra5),
                        new SqlParameter("@Extra6", extra6),
                        new SqlParameter("@Extra7", extra7),
                        new SqlParameter("@Extra8", extra8),
                        new SqlParameter("@Extra9", extra9),
                        new SqlParameter("@Extra10", extra10),
                        new SqlParameter("@LanguagesID", languagesID)
                    };
                }
                
                retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));
            }

            return retval;
        }

        public static int CreateSale(int leadId, int campaignId, string capturedBy, DateTime captureDate, int workflowStepId, string verifiedBy, DateTime verifiedDate, string status, int batchID, string extra1 = "", string extra2 = "", string extra3 = "", string extra4 = "", string extra5 = "", string extra6 = "", string extra7 = "", string extra8 = "", string extra9 = "", string extra10 = "", int languagesID = 0)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@leadID", leadId),
                new SqlParameter("@campaignID", campaignId),
                new SqlParameter("@capturedBy", capturedBy),
                new SqlParameter("@captureDate", captureDate),
                new SqlParameter("@workflowStepId", workflowStepId),
                new SqlParameter("@verifiedby", verifiedBy),
                new SqlParameter("@verifiedDate", verifiedDate),
                new SqlParameter("@status", status),
                new SqlParameter("@BatchID", batchID),
                new SqlParameter("@Extra1", extra1),
                new SqlParameter("@Extra2", extra2),
                new SqlParameter("@Extra3", extra3),
                new SqlParameter("@Extra4", extra4),
                new SqlParameter("@Extra5", extra5),
                new SqlParameter("@Extra6", extra6),
                new SqlParameter("@Extra7", extra7),
                new SqlParameter("@Extra8", extra8),
                new SqlParameter("@Extra9", extra9),
                new SqlParameter("@Extra10", extra10),
                new SqlParameter("@LanguagesID", languagesID),
            };

            string sql = "spCreateSales";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        public static int CreateNewSale(int leadId, int campaignId, string capturedBy, DateTime captureDate, int workflowStepId, string verifiedBy, DateTime verifiedDate, string status, int batchID, string extra1 = "", string extra2 = "", string extra3 = "", string extra4 = "", string extra5 = "", string extra6 = "", string extra7 = "", string extra8 = "", string extra9 = "", string extra10 = "", int languagesID = 0)
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@leadID", leadId),
                new SqlParameter("@campaignID", campaignId),
                new SqlParameter("@capturedBy", capturedBy),
                new SqlParameter("@captureDate", captureDate),
                new SqlParameter("@workflowStepId", workflowStepId),
                new SqlParameter("@verifiedby", verifiedBy),
                new SqlParameter("@verifiedDate", verifiedDate),
                new SqlParameter("@status", status),
                new SqlParameter("@BatchID", batchID),
                new SqlParameter("@Extra1", extra1),
                new SqlParameter("@Extra2", extra2),
                new SqlParameter("@Extra3", extra3),
                new SqlParameter("@Extra4", extra4),
                new SqlParameter("@Extra5", extra5),
                new SqlParameter("@Extra6", extra6),
                new SqlParameter("@Extra7", extra7),
                new SqlParameter("@Extra8", extra8),
                new SqlParameter("@Extra9", extra9),
                new SqlParameter("@Extra10", extra10),
                new SqlParameter("@LanguagesID", languagesID),
            };

            string sql = "spCreateNewSale";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }

        private static Sales MakeObject(DataRow inputRow)
        {
            Sales retValue = new Sales();

            retValue.ID = (int)inputRow["ID"];
            retValue.WorkflowStepID = (int)inputRow["WorkflowStepID"];
            retValue.CaptureDate = (DateTime)inputRow["CaptureDate"];
            retValue.CaptureBy = (string)inputRow["CapturedBy"];
            retValue.CampaignID = (int)inputRow["CampaignID"];
            retValue.UserID = (int)inputRow["UserID"];
            retValue.LeadID = (int)inputRow["LeadID"];

            retValue.VerifiedDate = (DateTime)inputRow["VerifiedDate"];
            retValue.VerifiedBy = (string)inputRow["VerifiedBy"];
            retValue.Status = (string)inputRow["Status"];
            retValue.IsDialed = (bool)inputRow["IsDialed"];
            retValue.IsDeleted = (bool)inputRow["IsDeleted"];
            retValue.BatchID = (int)inputRow["BatchID"];
            retValue.LanguagesID = Convert.ToInt32(inputRow["LanguagesID"]);

            retValue.Extra1 = (string)inputRow["Extra1"];
            retValue.Extra2 = (string)inputRow["Extra2"];
            retValue.Extra3 = (string)inputRow["Extra3"];
            retValue.Extra4 = (string)inputRow["Extra4"];
            retValue.Extra5 = (string)inputRow["Extra5"];
            retValue.Extra6 = (string)inputRow["Extra6"];
            retValue.Extra7 = (string)inputRow["Extra7"];
            retValue.Extra8 = (string)inputRow["Extra8"];
            retValue.Extra9 = (string)inputRow["Extra9"];
            retValue.Extra10 = (string)inputRow["Extra10"];
            

            retValue._found = true;
            return retValue;
        }

        public bool Update()
        {
            bool retVal = false;

            if(Sales.SaveSale(this.ID, this.UserID, this.CaptureBy, this.CaptureDate, this.WorkflowStepID, this.WorkFlowStep,
                this.Extra1, this.Extra2, this.Extra3, this.Extra4, this.Extra5, this.Extra6, this.Extra7, this.Extra8, this.Extra9, this.Extra10, this.LanguagesID) > 0)
            {
                retVal = true;
            }

            return retVal;
        }
    }
}
