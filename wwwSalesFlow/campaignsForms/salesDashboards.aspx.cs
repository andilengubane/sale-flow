using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;

namespace wwwSalesFlow.campaignsForms
{
    public partial class salesDashboards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // -- remove section, only for testing
            Session["userID"]  = 2;
            Session["CampaignID"] = 28;
            // -- remove section, end

            if(!IsPostBack)
            {
                //load campaign filter list
                Campaign blank = new Campaign();
                blank.Title = "< All >";

                List<Campaign> campaignList = Campaign.GetAllActiveCampaigns();
                campaignList.Insert(0, blank);
                cmbCampaignFilter.DataSource = campaignList;
                cmbCampaignFilter.DataTextField = "Title";
                cmbCampaignFilter.DataValueField = "CampaignID";
                cmbCampaignFilter.DataBind();
                campaignList = null;
                blank = null;


                //load agents filter list
                List<Users> agents = Users.GetAllUsers();
                Users blankUser = new Users();
                blankUser.ID = 0;
                blankUser.ADUserName = "< All >";
                agents.Insert(0, blankUser);
                cmbAgentFilter.DataValueField = "ID";
                cmbAgentFilter.DataTextField = "ADUserName";
                cmbAgentFilter.DataSource = agents;
                cmbAgentFilter.DataBind();

                blankUser = null;
                agents = null;
            }


            if(Session["userID"] == null || Session["CampaignID"] == null)
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Session Expired. <br/> Please log off and start again.";
            }
            else
            {
                RefreshDashboardAll();
            }
        }

        private void RefreshDashboardAll()
        {
            if(cmbCampaignFilter.SelectedIndex > 0 && cmbAgentFilter.SelectedIndex > 0)
            {
                RefreshDashboardCampaignAndUserID(Convert.ToInt32(cmbCampaignFilter.SelectedValue), Convert.ToInt32(cmbAgentFilter.SelectedValue));
            }
            else if(cmbCampaignFilter.SelectedIndex > 0 && cmbAgentFilter.SelectedIndex == 0)
            {
                RefreshDashboardCampaign(Convert.ToInt32(cmbCampaignFilter.SelectedValue));
            }
            else
            {
                RefreshDashboard();
            }
        }

        private void RefreshDashboard()
        {
            int userID = (int)Session["userID"];
            int campaignID = (int)Session["CampaignID"];

            Users us = Users.GetUserByID(userID);
            if (us.Found)
            {
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                mvMain.SetActiveView(vwMain);

                //Load ReTry List
                #region retry list
                DataTable rData = Dashboard.GetRetrySalesListByUser(us.ID);
                gvRetry.DataSource = rData;
                gvRetry.DataBind();  // Total retry list
                lblRetryCount.Text = rData.Rows.Count.ToString(); // Total Count
                rData.Dispose();
                #endregion

                #region Vetting list
                DataTable vetData = Dashboard.GetVettingSalesListByUser(us.ID);
                lblVetting.Text = vetData.Rows.Count.ToString(); // Total Count
                vetData.Dispose();
                #endregion

                #region Callback list
                DataTable callBackData = Dashboard.GetVetRetrySalesListByUser(us.ID);
                lblAgentCallback.Text = callBackData.Rows.Count.ToString(); // Total Count
                callBackData.Dispose();
                #endregion

                #region All Status List
                DataTable allStatusData = Dashboard.GetALLSaleStatus();
                gvStepStatus.DataSource = allStatusData;
                gvStepStatus.DataBind();
                allStatusData.Dispose();
                #endregion

                #region Current month success by campaign
                lblCurrentMonthCurrentCampaignSuccess.Text = Dashboard.GetTotalSuccessfullSalesByUser(firstDayOfMonth, campaignID, us.ID).ToString();
                #endregion
            }
        }
        private void RefreshDashboardCampaign(int campaignID)
        {
            int userID = (int)Session["userID"];
            Users us = Users.GetUserByID(userID);

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            mvMain.SetActiveView(vwMain);

            //Load ReTry List
            #region retry list
            DataTable rData = Dashboard.GetRetrySalesListByCampaignID(campaignID);
            gvRetry.DataSource = rData;
            gvRetry.DataBind();  // Total retry list
            lblRetryCount.Text = rData.Rows.Count.ToString(); // Total Count
            rData.Dispose();
            #endregion

            #region Vetting list
            DataTable vetData = Dashboard.GetVettingSalesListByCampaignID(campaignID);
            lblVetting.Text = vetData.Rows.Count.ToString(); // Total Count
            vetData.Dispose();
            #endregion

            #region Callback list
            DataTable callBackData = Dashboard.GetVetRetrySalesListByCampaignID(campaignID);
            lblAgentCallback.Text = callBackData.Rows.Count.ToString(); // Total Count
            callBackData.Dispose();
            #endregion

            #region All Status List
            DataTable allStatusData = Dashboard.GetALLSaleStatusByCampaignID(campaignID);
            gvStepStatus.DataSource = allStatusData;
            gvStepStatus.DataBind();
            allStatusData.Dispose();
            #endregion
            
            #region Current month success by campaign
            lblCurrentMonthCurrentCampaignSuccess.Text = Dashboard.GetTotalSuccessfullSalesByCampaignID(firstDayOfMonth, campaignID).ToString();
            #endregion
        }

        private void RefreshDashboardCampaignAndUserID(int campaignID, int userID)
        {
            //int userID = (int)Session["userID"];
            Users us = Users.GetUserByID(userID);

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            mvMain.SetActiveView(vwMain);

            //Load ReTry List
            #region retry list
            DataTable rData = Dashboard.GetRetrySalesListByCampaignAndUserID(campaignID, userID);
            gvRetry.DataSource = rData;
            gvRetry.DataBind();  // Total retry list
            lblRetryCount.Text = rData.Rows.Count.ToString(); // Total Count
            rData.Dispose();
            #endregion

            #region Vetting list
            DataTable vetData = Dashboard.GetVettingSalesListByCampaignAndUserID(campaignID, userID);
            lblVetting.Text = vetData.Rows.Count.ToString(); // Total Count
            vetData.Dispose();
            #endregion

            #region Callback list
            DataTable callBackData = Dashboard.GetVetRetrySalesListByCampaignIDAndUserID(campaignID, userID);
            lblAgentCallback.Text = callBackData.Rows.Count.ToString(); // Total Count
            callBackData.Dispose();
            #endregion

            #region All Status List
            DataTable allStatusData = Dashboard.GetALLSaleStatusByCampaignIDAndUserID(campaignID, userID);
            gvStepStatus.DataSource = allStatusData;
            gvStepStatus.DataBind();
            allStatusData.Dispose();
            #endregion

            #region Current month success by campaign
            lblCurrentMonthCurrentCampaignSuccess.Text = Dashboard.GetTotalSuccessfullSalesByCampaignIDAndUserID(firstDayOfMonth, campaignID, userID).ToString();
            #endregion
        }
        protected void lnkView_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            int leadID = Convert.ToInt32(gvRetry.DataKeys[rowIndex]["LeadID"]);
            string campaignName = gvRetry.DataKeys[rowIndex]["CampaignName"].ToString();
            
            Users cUser = Users.GetUserByID((int)Session["userID"]);
            
            if (cUser.Found)
            {
                DialAPI.ScheduleCallback(campaignName, leadID.ToString(), DateTime.Now, cUser.AgentCode.ToString(), "");
                Response.Redirect(string.Format("~/exchange.aspx?campaignID=@campaignID&LeadID=@leadID", leadID, campaignName));
            }
            else
            {

            }

            cUser = null;
        }

        protected void cmbCampaignFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDashboardAll();
        }

        protected void cmbAgentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDashboardAll();
        }
    }
}