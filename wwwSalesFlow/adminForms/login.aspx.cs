using System;
using BusinessLogic;

namespace wwwSalesFlow.adminForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mvMain.ActiveViewIndex = 0;
            txtAgentCode.Focus();
        }
        
        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            Users currentUser = Users.GetValidatedUser(Convert.ToInt32(txtAgentCode.Text.Trim()));
            if (currentUser.Found)
            {
                // now check the password
                if (currentUser.Password == txtPassword.Text.Trim())
                {
                    if (currentUser.IsAdmin == true)
                    {
                        // Yeppy you are in!!!
                        Session["AdminUserID"] = currentUser.ID;
                        lblMessage.Visible = false;
                        Response.Redirect("campaignAdmin.aspx");
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = string.Format("Agent Code {0} currently does not have persmission to use the Sales Flow Admin.<br/> Please escalate to systems support.", txtAgentCode.Text.Trim().ToString());
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = string.Format("Password for Agent Code {0} does not match the one we have on record.<br/> Please escalate to systems support.", txtAgentCode.Text.Trim().ToString());
                }

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = string.Format("Agent Code: {0} does not exist.<br/> Please escalate to systems support.", txtAgentCode.Text.Trim().ToString());

            }
        }
    }
}