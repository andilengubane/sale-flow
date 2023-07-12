using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace BusinessLogic
{
    public class Dashboard
    {
        public static int GetTotalSalesByDate(DateTime selectedDate)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CaptureDate", selectedDate)
            };

            string sql = "select count(1) Total from Sales where IsDeleted = 0 and IsDialed = 1 and Cast(CaptureDate as Date) = Cast(@CaptureDate AS Date);";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = Convert.ToInt32(results.Rows[0][0]);
            }
            results.Dispose();

            return retVal;
        }
        public static List<KeyValuePair<int,string>> GetTotalSalesByDateGroupedByCampaignName(DateTime selectedDate )
        {
            List<KeyValuePair<int, string>> retVal = new List<KeyValuePair<int, string>>();

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CaptureDate", selectedDate)
            };

            string sql = "select count(1), Title Total from Sales inner join Campaign on Sale.CampaignID = Campaign.ID where IsDeleted = 0 and IsDialed = 1 and Cast(CaptureDate as Date) = Cast(@CaptureDate AS Date) group by Title Order by Title asc;";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            for ( int i =0; i< results.Rows.Count; i++)
            {
                retVal.Add( new KeyValuePair<int, string>(Convert.ToInt32(results.Rows[i][0]), results.Rows[i][1].ToString()));
            }
            results.Dispose();

            return retVal;
        }
        public static int GetTotalSalesByCampaign(int campaignID)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID)
            };

            string sql = "select count(1) Total from Sales where IsDeleted = 0 and IsDialed = 1 and CampaignID = @CampaignID;";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = Convert.ToInt32(results.Rows[0][0]);
            }
            results.Dispose();

            return retVal;
        }
        public static int GetTotalSalesByCampaign(DateTime selectedDate, int campaignID)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID),
                new SqlParameter("@CaptureDate", selectedDate)
            };

            string sql = "select count(1) Total from Sales where IsDeleted = 0 and IsDialed = 1 and CampaignID = @CampaignID and Cast(CaptureDate as Date) = Cast(@CaptureDate AS Date);";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = Convert.ToInt32(results.Rows[0][0]);
            }
            results.Dispose();

            return retVal;
        }
        public static int GetTotalSalesByDateByUser(DateTime selectedDate, string capturedBy)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CaptureDate", selectedDate),
                new SqlParameter("@CapturedBy", capturedBy)
            };

            string sql = "select count(1) Total from Sales where IsDeleted = 0 and IsDialed = 1 and Cast(CaptureDate as Date) = Cast(@CaptureDate AS Date) and CapturedBy = @CapturedBy;";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = Convert.ToInt32(results.Rows[0][0]);
            }
            results.Dispose();

            return retVal;
        }
        public static int GetTotalSalesByCampaignByUser(DateTime selectedDate, int campaignID, string capturedBy)
        {
            int retVal = 0;

            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@CampaignID", campaignID),
                new SqlParameter("@CaptureDate", selectedDate),
                new SqlParameter("@CapturedBy", capturedBy)
            };

            string sql = "select count(1) Total from Sales where IsDeleted = 0 and IsDialed = 1 and CampaignID = @CampaignID and Cast(CaptureDate as Date) = Cast(@CaptureDate AS Date) and CapturedBy = @CapturedBy;";
            DataTable results = DataAccess.ExecuteDataReader(sql, parms);
            if (results.Rows.Count > 0)
            {
                retVal = Convert.ToInt32(results.Rows[0][0]);
            }
            results.Dispose();

            return retVal;
        }
        public static int GetTotalSuccessfullSalesByCampaignByUser(DateTime selectedDate, int campaignID, int userID)
        {
            int retVal = 0;

            Campaign camp = new Campaign(campaignID);
            if (camp.Found)
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@CampaignID", campaignID),
                    new SqlParameter("@CaptureDate", selectedDate),
                    new SqlParameter("@UserID", userID),
                    new SqlParameter("@FinalStatusID", camp.FinalStatusID)
                };

                string sql = "select count(1) Total from Sales inner join Campaign on Sales.CampaignID = Campaign.ID where Sales.IsDeleted = 0 and Sales.IsDialed = 1 and Sales.CampaignID = @CampaignID and Cast(Sales.CaptureDate as Date) >= Cast(@CaptureDate AS Date) and Sales.UserID = @UserID and Campaign.FinalStatusID = @FinalStatusID;";
                DataTable results = DataAccess.ExecuteDataReader(sql, parms);
                if (results.Rows.Count > 0)
                {
                    retVal = Convert.ToInt32(results.Rows[0][0]);
                }
                results.Dispose();
            }
            return retVal;
        }
        public static int GetTotalSuccessfullSalesByUser(DateTime selectedDate, int campaignID, int userID)
        {
            int retVal = 0;

            Campaign camp = new Campaign(campaignID);
            if (camp.Found)
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@CampaignID", campaignID),
                    new SqlParameter("@CaptureDate", selectedDate),
                    new SqlParameter("@UserID", userID),
                    new SqlParameter("@FinalStatusID", camp.FinalStatusID)
                };

                string sql = "select count(1) Total from Sales inner join Campaign on Sales.CampaignID = Campaign.ID where Sales.IsDeleted = 0 and Sales.IsDialed = 1 and Sales.CampaignID = @CampaignID and Cast(Sales.CaptureDate as Date) >= Cast(@CaptureDate AS Date) and Sales.UserID = @UserID and Campaign.FinalStatusID = @FinalStatusID;";
                DataTable results = DataAccess.ExecuteDataReader(sql, parms);
                if (results.Rows.Count > 0)
                {
                    retVal = Convert.ToInt32(results.Rows[0][0]);
                }
                results.Dispose();
            }
            return retVal;
        }
        public static int GetTotalSuccessfullSalesByCampaignID(DateTime selectedDate, int campaignID)
        {
            int retVal = 0;

            Campaign camp = new Campaign(campaignID);
            if (camp.Found)
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@CampaignID", campaignID),
                    new SqlParameter("@CaptureDate", selectedDate),
                    new SqlParameter("@FinalStatusID", camp.FinalStatusID)
                };

                string sql = "select count(1) Total from Sales inner join Campaign on Sales.CampaignID = Campaign.ID where Sales.IsDeleted = 0 and Sales.IsDialed = 1 and Sales.CampaignID = @CampaignID and Cast(Sales.CaptureDate as Date) >= Cast(@CaptureDate AS Date) and Campaign.FinalStatusID = @FinalStatusID;";
                DataTable results = DataAccess.ExecuteDataReader(sql, parms);
                if (results.Rows.Count > 0)
                {
                    retVal = Convert.ToInt32(results.Rows[0][0]);
                }
                results.Dispose();
            }
            return retVal;
        }
        public static int GetTotalSuccessfullSalesByCampaignIDAndUserID(DateTime selectedDate, int campaignID, int userID)
        {
            int retVal = 0;

            Campaign camp = new Campaign(campaignID);
            if (camp.Found)
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@userID", userID),
                    new SqlParameter("@CampaignID", campaignID),
                    new SqlParameter("@CaptureDate", selectedDate),
                    new SqlParameter("@FinalStatusID", camp.FinalStatusID)
                };

                string sql = "select count(1) Total from Sales inner join Campaign on Sales.CampaignID = Campaign.ID where Sales.IsDeleted = 0 and Sales.IsDialed = 1 and Sales.UserID = @userID and Sales.CampaignID = @CampaignID and Cast(Sales.CaptureDate as Date) >= Cast(@CaptureDate AS Date) and Campaign.FinalStatusID = @FinalStatusID;";
                DataTable results = DataAccess.ExecuteDataReader(sql, parms);
                if (results.Rows.Count > 0)
                {
                    retVal = Convert.ToInt32(results.Rows[0][0]);
                }
                results.Dispose();
            }
            return retVal;
        }
        public static DataTable GetRetrySalesListByUser(int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetRetrySalesListByUser";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }
        
        public static DataTable GetRetrySalesListByCampaignID(int campaignID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "spGetRetrySalesListByCampaignID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetRetrySalesListByCampaignAndUserID(int campaignID, int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetRetrySalesListByCampaignIDAndUserID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetVettingSalesListByUser(int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetVettingSalesListByUser";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetVettingSalesListByCampaignID(int campaignID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "spGetVettingSalesListByCampaignID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetVettingSalesListByCampaignAndUserID(int campaignID, int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetVettingSalesListByCampaignIDAndSaleID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetVettingSalesTotal()
        {
            string sql = "select * from vwGetVettingSalesCount;";
            return DataAccess.ExecuteSimpleDataReader(sql);
        }

        public static DataTable GetVetRetrySalesListByUser(int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetVetRetrySalesListByUser";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }

        public static DataTable GetVetRetrySalesListByCampaignID(int campaignID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "spGetVetRetrySalesListByCampaignID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }
        public static DataTable GetVetRetrySalesListByCampaignIDAndUserID(int campaignID, int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@userID", userID)
            };

            string sql = "spGetVetRetrySalesListByCampaignIDAndUserID";
            return DataAccess.ExecuteSpDataReader(sql, parms);
        }
        public static DataTable GetVetRetrySalesCount()
        {
            string sql = "select * from vwGetVetRetrySalesCount;";
            return DataAccess.ExecuteSimpleDataReader(sql);
        }

        public static DataTable GetALLSaleStatus()
        {
            string sql = "select * from vwSalesCountByWorkflowStep;";
            return DataAccess.ExecuteSimpleDataReader(sql);
        }

        public static DataTable GetALLSaleStatusByCampaignID(int campaignID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID)
            };

            string sql = "select StepName, TotalSales from [dbo].[vwSalesCountByWorkflowStepByCampaign] where CampaignID = @campaignID;";
            return DataAccess.ExecuteDataReader(sql, parms);
        }

        public static DataTable GetALLSaleStatusByCampaignIDAndUserID(int campaignID, int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@campaignID", campaignID),
                new SqlParameter("@userID", userID)
            };

            string sql = "select StepName, TotalSales from [dbo].[vwSalesCountByWorkflowStepByCampaignAndUser] where CampaignID = @campaignID and UserID = @userID;";
            return DataAccess.ExecuteDataReader(sql, parms);
        }
        public static DataTable GetALLSaleStatusByUser(int userID)
        {
            List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@userID", userID)
            };

            string sql = "select * from vwSalesCountByWorkflowStepByUser where UserID = @userID;";
            return DataAccess.ExecuteDataReader(sql, parms);
        }
    }
}
