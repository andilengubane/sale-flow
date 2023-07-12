using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow
{
    public partial class exchange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //retreive campaign details by either Name or ID
            if(Request["campaignID"] != null)
            {
                Campaign cam = new Campaign(Request["campaignID"].ToString());

                if (cam.Found && cam.IsActive)
                {
                    Session["CampaignID"] = cam.CampaignID;

                    string url = cam.CaptureForm;

                    if (Request["leadID"] != null)
                    {
                        int leadID = 0;
                        if (int.TryParse(Request["leadID"].ToString(), out leadID))
                        {
                            /// Validate User
                            int agentCode = 0;
                            if (int.TryParse(Request["AgentCode"].ToString(), out agentCode))
                            {
                                Users currentUser = Users.GetValidatedUser(agentCode);
                                if(currentUser.Found)
                                {
                                    Session["UserID"] = currentUser.ID;

                                    Sales sal = Sales.GetSale(leadID, cam.CampaignID);
                                    if (sal.Found)
                                    {
                                        Response.Redirect(string.Format("~/campaignsForms/{0}?LeadID={1}&CampaignID={2}&AgentCode={3}", url, leadID.ToString(), cam.CampaignID.ToString(), agentCode));
                                        //Response.Redirect("~/campaignForms/" + url + "?LeadID=" + leadID.ToString());
                                    }
                                    else
                                    {
                                        lblMessage.Text = string.Format("Lead ID: {0} for campaign: {1} does not exist.<br/> Please escalate to systems support.", leadID.ToString(), cam.Title);
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
    }
}