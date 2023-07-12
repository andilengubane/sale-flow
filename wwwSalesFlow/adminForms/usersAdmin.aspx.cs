using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.adminForms
{
    public partial class usersAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserID"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    mvMain.SetActiveView(vwMain);
                    ShowAll();
                }
            }
        }

        private void LoadExisting(int userID)
        {
            Users x = Users.GetUserByID(userID);

            if (x.Found)
            {
                txtAdUsername.Text = x.ADUserName;
                txtAgentCode.Text = x.AgentCode.ToString();
                txtIDNumber.Text = x.IDNumber;
                txtEmployeeNumber.Text = x.EmployeeNo;
                chkAdmin.Checked = x.IsAdmin;
                txtPassword.Text = x.Password;
                txtTeamLeader.Text = x.TeamLeader;
                chkVerificationAgent.Checked = x.IsVerificationAgent;

                mvMain.SetActiveView(vwEdit);
                ViewState["EditID"] = x.ID;
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
            x = null;
        }

        private void LoadUserLanguage(int userID)
        {
            Users x = Users.GetUserByID(userID);
            if (x.Found)
            {

                gvLanguages.DataSource = Languages.GetAllLanguages();
                gvLanguages.DataBind();

                List<Languages> ul = x.UserLanguages;
                for(int i=0; i<ul.Count; i++)
                {
                    for(int j=0; j<gvLanguages.Rows.Count; j++)
                    {
                        if(ul[i].LanguagesID ==  Convert.ToInt32(gvLanguages.DataKeys[j][0]))
                        {
                            ((CheckBox)gvLanguages.Rows[j].Cells[1].FindControl("chkLanguage")).Checked = true;
                            break;
                        }
                    }
                }
                

                mvMain.SetActiveView(vwLanguages);
                ViewState["EditID"] = x.ID;
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
            x = null;
        }

        private void ShowAll()
        {
            gvAll.DataSource = Users.GetAllUsers();
            gvAll.DataBind();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadExisting(theId);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ViewState["EditID"] = 0;
            mvMain.SetActiveView(vwMain);
            ShowAll();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvMain.SetActiveView(vwMain);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["EditID"] != null)
            {
                int currentId = (int)ViewState["EditID"];
                currentId = Users.SaveUserDetails(currentId, txtAdUsername.Text, chkAdmin.Checked, int.Parse(txtAgentCode.Text.Trim()), txtIDNumber.Text.Trim(), txtEmployeeNumber.Text.Trim(), txtPassword.Text.Trim(), txtTeamLeader.Text.Trim(), chkVerificationAgent.Checked);
                if (currentId > 0)
                {
                    lblConfirmation.Text = "Record Saved Successfully. <br/> ID: " + currentId.ToString();
                }
                else
                {
                    lblConfirmation.Text = "Update Failed !!! <br/> Please refresh and try again.";
                }
                mvMain.SetActiveView(vwConfirm);
            }
        }

        protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.Cells[3].FindControl("lnkEdit")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
                ((LinkButton)e.Row.Cells[3].FindControl("lnkLanguage")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            txtAgentCode.Text = "";
            txtAdUsername.Text = "";
            chkAdmin.Checked = false;
            txtEmployeeNumber.Text = "";
            txtIDNumber.Text = "";
            txtPassword.Text = "";
            txtTeamLeader.Text = "";
            chkVerificationAgent.Checked = false;

            ViewState["EditID"] = 0;
            mvMain.SetActiveView(vwEdit);
        }

        protected void btnSaveLanguage_Click(object sender, EventArgs e)
        {
            int addCount = 0;
            int removeCount = 0;

            if (ViewState["EditID"] != null)
            {
                int currentUserId = (int)ViewState["EditID"];

                for (int j = 0; j < gvLanguages.Rows.Count; j++)
                {
                    int currLangID = Convert.ToInt32(gvLanguages.DataKeys[j][0]);

                    if (((CheckBox)gvLanguages.Rows[j].Cells[1].FindControl("chkLanguage")).Checked)
                    {
                        //Add Language to User
                        if (UserLanguage.SaveUserLanguage(currentUserId, currLangID) > 0)
                        {
                            addCount++;
                        }
                    }
                    else
                    {
                        //Remove Language from User
                        UserLanguage ul = UserLanguage.GetLanguagesByUserIdAndLanguageID(currentUserId, currLangID);
                        if(ul.Found)
                        {
                            if(ul.Delete())
                            {
                                removeCount++;
                            }
                        }
                    }
                }

                lblConfirmation.Text = string.Format("Success.<br/> languages added: {0} <br/> languages removed: {1}", addCount, removeCount);
                mvMain.SetActiveView(vwConfirm);
            }
         }

        protected void lnkLanguage_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadUserLanguage(theId);
        }
    }
}