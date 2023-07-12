using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow
{
    public partial class AvailableClientDetails : System.Web.UI.Page
    {
        string url = "";
        int leadID = 0;
        int agentCode = 0;
        string campaignID = "";
        int campID = 0;
        int batchID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //retreive campaign details by either Name or ID
            if (Request["campaignID"] != null)
            {
                Campaign cam = new Campaign(Request["campaignID"].ToString());

                if (cam.Found && cam.IsActive)
                {
                    Session["CampaignID"] = cam.CampaignID;

                    url = cam.CaptureForm;
                    campaignID = cam.CampaignID.ToString();
                    campID = cam.CampaignID;

                    if (Request["leadID"] != null)
                    {
                        
                        if (int.TryParse(Request["leadID"].ToString(), out leadID))
                        {
                            /// Validate User
                           
                            if (int.TryParse(Request["AgentCode"].ToString(), out agentCode))
                            {
                                Users currentUser = Users.GetValidatedUser(agentCode);
                                if (currentUser.Found)
                                {
                                    Session["UserID"] = currentUser.ID;

                                    Sales sal = Sales.GetSale(leadID, cam.CampaignID);
                                    if (sal.Found)
                                    {
                                        btnNewSale.Visible = true;
                                        lnkSaleDetails.Visible = true;
                                        lnkSaleDetails.Text = "Client Details for Sale ID: " + sal.ID.ToString();
                                        lblLeadID.Text = leadID.ToString();
                                        notFound.Visible = false;
                                        batchID = sal.BatchID;
                                    }
                                    else
                                    {
                                        btnNewSale.Visible = true;
                                        notFound.Visible = true;
                                        lblMessage.Text = "";
                                        //lblMessage.Text = string.Format("Lead ID: {0} for campaign: {1} does not exist.<br/> Please escalate to systems support.", leadID.ToString(), cam.Title);
                                    }
                                    sal = null;
                                }
                                else
                                {
                                    lblMessage.Text = string.Format("Agent Code: {0} does not exist.<br/> Please escalate to systems support.", agentCode.ToString());

                                }
                            }
                            else
                            {
                                lblMessage.Text = "Agent Code Parameter Missing<br/> Please escalate to systems support.";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Lead ID not found... <br/> Please escalate to systems support.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Lead ID Parameter Not Found.<br/> Please escalate to systems support.";
                    }
                }
                else
                {
                    lblMessage.Text = "Default campaign not found... <br/> Please escalate to systems support.";
                }
            }
            else
            {
                lblMessage.Text = "Campaign Parameter Not Found.<br/> Please escalate to systems support.";
            }
        }

        protected void lnkSaleDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/campaignsForms/{0}?LeadID={1}&CampaignID={2}&AgentCode={3}", url, leadID.ToString(), campaignID, agentCode));
        }

        protected void btnNewSale_Click(object sender, EventArgs e)
        {
            // 3. Create a sale with "IsDialed" tag set to FALSE by Default
            if (batchID == 0)
               batchID = 25;
          
            int newSaleId = Sales.CreateNewSale(leadID, campID, Session["UserID"].ToString(), DateTime.Now, 2, "", DateTime.Now, "Capture", 25, "", "", "", "", "", "", "", "", "", "");
            Session["SaleID"] = newSaleId;

            Response.Redirect(string.Format("~/campaignsForms/{0}?LeadID={1}&CampaignID={2}&AgentCode={3}", url, leadID.ToString(), campaignID, agentCode));
        }
    }
}