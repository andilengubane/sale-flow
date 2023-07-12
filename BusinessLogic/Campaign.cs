using System;
using Helper;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Campaign
    {
        public int CampaignID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CaptureForm { get; set; }
        private bool _found = false;
        public bool Found { get { return _found; } }
        public int ExtCampaignID { get; set; }
        public int SweepPercentage { get; set; }
        public int ClientsID { get; set; }
        public string CampaignSetting1 { get; set; }
        public string CampaignSetting2 { get; set; }
        public string CampaignSetting3 { get; set; }
        public string CampaignSetting4 { get; set; }
        public string CampaignSetting5 { get; set; }
        public string CampaignSetting6 { get; set; }
        public string CampaignSetting7 { get; set; }
        public string FinalStatus { get; set; }
        public int FinalStatusID { get; set; }

        public Campaign()
        { }

        /// <summary>
        /// Constructor that instantiates an object instance based on the passed campaign ID.
        /// </summary>
        /// <param name="campaignID">An <see cref="int"/> value containing the campaign ID to use.</param>
        public Campaign(int campaignID)
        {
            string sql = "spGetCampaignByCampaignID";
            
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            DataTable data = DataAccess.ExecuteSpDataReader(sql, parm);
            if (data.Rows.Count > 0)
            {
                this.CampaignID = (int)data.Rows[0]["ID"];
                this.Title = (string)data.Rows[0]["Title"];
                this.Description = (string)data.Rows[0]["Description"];
                this.IsActive = (bool)data.Rows[0]["IsActive"];
                this.CaptureForm = (string)data.Rows[0]["CaptureForm"];
                this.ExtCampaignID = (int)data.Rows[0]["ExtCampaignID"];
                this.SweepPercentage = (int)data.Rows[0]["SweepPercentage"];

                this.ClientsID = (int)data.Rows[0]["ClientsID"];
                this.CampaignSetting1 = (string)data.Rows[0]["CampaignSetting1"];
                this.CampaignSetting2 = (string)data.Rows[0]["CampaignSetting2"];
                this.CampaignSetting3 = (string)data.Rows[0]["CampaignSetting3"];
                this.CampaignSetting4 = (string)data.Rows[0]["CampaignSetting4"];
                this.CampaignSetting5 = (string)data.Rows[0]["CampaignSetting5"];
                this.CampaignSetting6 = (string)data.Rows[0]["CampaignSetting6"];
                this.CampaignSetting7 = (string)data.Rows[0]["CampaignSetting7"];
                this.FinalStatus = (string)data.Rows[0]["FinalStatus"];
                this.FinalStatusID = (int)data.Rows[0]["FinalStatusID"];

                this._found = true;
            }
            data.Dispose();
        }
        
        /// <summary>
        /// Constructor that instantiates an object instance based on the passed campaign name.
        /// </summary>
        /// <param name="campaignName">A <see cref="string"/> value containing the campaign name to use.</param>
        public Campaign(string campaignName)
        {
            string sql = "spGetCampaignByCampaignName";
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignName", campaignName)
            };

            DataTable data = DataAccess.ExecuteSpDataReader(sql, parm);
            if(data.Rows.Count > 0)
            {
                this.CampaignID = (int)data.Rows[0]["ID"];
                this.Title = (string)data.Rows[0]["Title"];
                this.Description = (string)data.Rows[0]["Description"];
                this.IsActive = (bool)data.Rows[0]["IsActive"];
                this.CaptureForm = (string)data.Rows[0]["CaptureForm"];
                this.ExtCampaignID = (int)data.Rows[0]["ExtCampaignID"];
                this.SweepPercentage = (int)data.Rows[0]["SweepPercentage"];

                this.ClientsID = (int)data.Rows[0]["ClientsID"];
                this.CampaignSetting1 = (string)data.Rows[0]["CampaignSetting1"];
                this.CampaignSetting2 = (string)data.Rows[0]["CampaignSetting2"];
                this.CampaignSetting3 = (string)data.Rows[0]["CampaignSetting3"];
                this.CampaignSetting4 = (string)data.Rows[0]["CampaignSetting4"];
                this.CampaignSetting5 = (string)data.Rows[0]["CampaignSetting5"];
                this.CampaignSetting6 = (string)data.Rows[0]["CampaignSetting6"];
                this.CampaignSetting7 = (string)data.Rows[0]["CampaignSetting7"];
                this.FinalStatus = (string)data.Rows[0]["FinalStatus"];
                this.FinalStatusID = (int)data.Rows[0]["FinalStatusID"];

                this._found = true;
            }
            data.Dispose();
        }
        
        /// <summary>
        /// Constructor that instantiates an object instance using an ExtCampaignID and a campaign name.
        /// </summary>
        /// <param name="extCampaignID">An <see cref="int"/> value containing the ExtCampaignID to use.</param>
        /// <param name="campaignName">A <see cref="string"/> value containing the campaign name to use.</param>
        public Campaign(int extCampaignID, string campaignName)
        {
            string sql = "select * from Campaign where Title = @campaignName and ExtCampaignID = @extCampaignID";
            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@campaignName", campaignName),
                new SqlParameter("@extCampaignID", extCampaignID)
            };

            DataTable data = DataAccess.ExecuteDataReader(sql, parm);
            if (data.Rows.Count > 0)
            {
                this.CampaignID = (int)data.Rows[0]["ID"];
                this.Title = (string)data.Rows[0]["Title"];
                this.Description = (string)data.Rows[0]["Description"];
                this.IsActive = (bool)data.Rows[0]["IsActive"];
                this.CaptureForm = (string)data.Rows[0]["CaptureForm"];
                this.ExtCampaignID = (int)data.Rows[0]["ExtCampaignID"];

                this.ClientsID = (int)data.Rows[0]["ClientsID"];
                this.CampaignSetting1 = (string)data.Rows[0]["CampaignSetting1"];
                this.CampaignSetting2 = (string)data.Rows[0]["CampaignSetting2"];
                this.CampaignSetting3 = (string)data.Rows[0]["CampaignSetting3"];
                this.CampaignSetting4 = (string)data.Rows[0]["CampaignSetting4"];
                this.CampaignSetting5 = (string)data.Rows[0]["CampaignSetting5"];
                this.CampaignSetting6 = (string)data.Rows[0]["CampaignSetting6"];
                this.CampaignSetting7 = (string)data.Rows[0]["CampaignSetting7"];
                this.FinalStatus = (string)data.Rows[0]["FinalStatus"];
                this.FinalStatusID = (int)data.Rows[0]["FinalStatusID"];

                this._found = true;
            }
            data.Dispose();
        }
        
        /// <summary>
        /// Retrieves all campaigns from the database. 
        /// </summary>
        /// <returns>A List of <see cref="Campaign"/> objects from the database.</returns>
        public static List<Campaign> GetAllCampaigns()
        {
            string sql = "spGetAllCampaigns";
            DataTable data = DataAccess.ExecuteSimpleSpDataReader(sql);

            List<Campaign> retVal = new List<Campaign>();

            for(int i=0; i< data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }
            return retVal;
        }

        /// <summary>
        /// Gets campaign data from the database for the provided campaign name.
        /// </summary>
        /// <param name="campaignID">An <see cref="int"/> value containing the campaign name to process.</param>
        /// <returns>A <see cref="Campaign"/> object either containing the necessary data, or an empty <see cref="Campaign"/> object.</returns>
        public static Campaign GetCampaignByID(int campaignID)
        {
            Campaign output = new Campaign();

            string sqlString = "spGetCampaignByCampaignID";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID)
            };

            DataTable data = DataAccess.ExecuteSpDataReader(sqlString, parameters);

            if (data.Rows.Count > 0)
                output = MakeObject(data.Rows[0]);

            return output;
        }

        /// <summary>
        /// Gets campaign data from the database for the provided campaign name.
        /// </summary>
        /// <param name="campaignName">A <see cref="string"/> value containing the campaign name to process.</param>
        /// <returns>A <see cref="Campaign"/> object either containing the necessary data, or an empty <see cref="Campaign"/> object.</returns>
        public static Campaign GetCampaignByCampaignName(string campaignName)
        {
            Campaign output = new Campaign();

            string sqlString = "spGetCampaignByCampaignName";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignName", campaignName)
            };

            DataTable data = DataAccess.ExecuteSpDataReader(sqlString, parameters);

            if (data.Rows.Count > 0)
                output = MakeObject(data.Rows[0]);

            return output;

        }

        /// <summary>
        /// Gets a list of campaigns from the database for the provided campaign name.
        /// (Not sure why this is here, but hey... There's a lot of this system that's been copy-pasted without any care, so meh)
        /// </summary>
        /// <param name="campaignName">A <see cref="string"/> value containing the campaign name to process.</param>
        /// <returns>A List of <see cref="Campaign"/> objects related to the passed campaign name.</returns>
        public static List<Campaign> GetCampaignsByCampaignName(string campaignName)
        {
            string sql = "spGetCampaignsByCampaignName";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignName", campaignName)
            };

            DataTable data = DataAccess.ExecuteSpDataReader(sql, parameters);

            List<Campaign> retVal = new List<Campaign>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }

            return retVal;
        }

        /// <summary>
        /// Retrieves a list of campaigns that the exporter will process.        
        /// </summary>
        /// <returns>A <see cref="string[]"/> containing the names of campaigns pulled from the database for exporting.</returns>
        public static string[] GetCampaignsToExport() 
        {
            string sql = "spGetCampaignsToExport";
            DataTable data = DataAccess.ExecuteSimpleDataReader(sql);

            ArrayList campaigns = new ArrayList();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                campaigns.Add(data.Rows[i][0]);
            }
            data.Dispose();
            return (string[])campaigns.ToArray(typeof(string));
        }
        
        /// <summary>
        /// Retrieves a list of active campaigns in the system.
        /// </summary>
        /// <returns>A List of <see cref="Campaign"/> objects that denote active campaigns in the system.</returns>
        public static List<Campaign> GetAllActiveCampaigns()
        {
            string sql = "spGetFullCampaignsToExport";
            DataTable data = DataAccess.ExecuteSimpleDataReader(sql);

            List<Campaign> retVal = new List<Campaign>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                retVal.Add(MakeObject(data.Rows[i]));
            }

            return retVal;
        }
        
        /// <summary>
        /// Mini-factory method that generates an object from a row from the database.
        /// </summary>
        /// <param name="inputRow">The <see cref="DataRow"/> to use when generating the object.</param>
        /// <returns>A <see cref="Campaign"/> object instantiated from the passed <see cref="DataRow"/>.</returns>
        private static Campaign MakeObject(DataRow inputRow)
        {
            Campaign retValue = new Campaign();

            retValue.CampaignID = (int)inputRow["ID"];
            retValue.Title = (string)inputRow["Title"];
            retValue.Description = (string)inputRow["Description"];
            retValue.IsActive = (bool)inputRow["IsActive"];
            retValue.CaptureForm = (string)inputRow["CaptureForm"];
            retValue.ExtCampaignID = (int)inputRow["ExtCampaignID"];
            retValue.SweepPercentage = (int)inputRow["SweepPercentage"];

            retValue.ClientsID = (int)inputRow["ClientsID"];
            retValue.CampaignSetting1 = (string)inputRow["CampaignSetting1"];
            retValue.CampaignSetting2 = (string)inputRow["CampaignSetting2"];
            retValue.CampaignSetting3 = (string)inputRow["CampaignSetting3"];
            retValue.CampaignSetting4 = (string)inputRow["CampaignSetting4"];
            retValue.CampaignSetting5 = (string)inputRow["CampaignSetting5"];
            retValue.CampaignSetting6 = (string)inputRow["CampaignSetting6"];
            retValue.CampaignSetting7 = (string)inputRow["CampaignSetting7"];
            retValue.FinalStatus = (string)inputRow["FinalStatus"];
            retValue.FinalStatusID = (int)inputRow["FinalStatusID"];

            retValue._found = true;

            return retValue;
        }
        
        //TODO: Finish the parameters.
        /// <summary>
        /// Creates or updates a campaign record in the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="isActive"></param>
        /// <param name="captureForm"></param>
        /// <param name="externalCampaignID"></param>
        /// <param name="sweepPercentage"></param>
        /// <param name="finalStatus"></param>
        /// <param name="finalStatusID"></param>
        /// <param name="clientsID"></param>
        /// <param name="campaignSetting1"></param>
        /// <param name="campaignSetting2"></param>
        /// <param name="campaignSetting3"></param>
        /// <param name="campaignSetting4"></param>
        /// <param name="campaignSetting5"></param>
        /// <param name="campaignSetting6"></param>
        /// <param name="campaignSetting7"></param>
        /// <returns>An <see cref="int"/> value containing the ID of the saved or updated campaign record.</returns>
        public static int SaveCampaign(int ID, string title, string description, bool isActive, string captureForm, 
                                       int externalCampaignID, int sweepPercentage, string finalStatus, int finalStatusID,
                                       int clientsID=0, string campaignSetting1 = "", string campaignSetting2 = "", string campaignSetting3 = "",
                                       string campaignSetting4 = "", string campaignSetting5 = "", string campaignSetting6 = "", string campaignSetting7 = "")
        {
            int retval = 0;

            List<SqlParameter> parm = new List<SqlParameter>()
            {
                new SqlParameter("@title", title),
                new SqlParameter("@description", description),
                new SqlParameter("@isActive", isActive),
                new SqlParameter("@ID", ID),
                new SqlParameter("@captureForm", captureForm),
                new SqlParameter("@extCampaignId", externalCampaignID),
                new SqlParameter("@sweepPercentage", sweepPercentage),
                new SqlParameter("@clientsId", clientsID),
                new SqlParameter("@campaignSetting1", campaignSetting1),
                new SqlParameter("@campaignSetting2", campaignSetting2),
                new SqlParameter("@campaignSetting3", campaignSetting3),
                new SqlParameter("@campaignSetting4", campaignSetting4),
                new SqlParameter("@campaignSetting5", campaignSetting5),
                new SqlParameter("@campaignSetting6", campaignSetting6),
                new SqlParameter("@campaignSetting7", campaignSetting7),
                new SqlParameter("@finalStatus", finalStatus),
                new SqlParameter("@finalStatusID", finalStatusID)
            };

            string sql = "spSaveCampaign";

            retval = Convert.ToInt32(DataAccess.ExecuteSpScalar(sql, parm));

            return retval;
        }
    }
}
