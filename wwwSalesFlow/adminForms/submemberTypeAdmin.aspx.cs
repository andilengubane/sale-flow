﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.adminForms
{
    public partial class submemberTypeAdmin : System.Web.UI.Page
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

        private void ShowAll()
        {
            gvAll.DataSource = SubMemberType.GetAllSubMemberTypes();
            gvAll.DataBind();
        }

        private void LoadExisting(int iD)
        {
            SubMemberType x = SubMemberType.GetSubMemberType(iD);
            if (x.Found)
            {
                txtTitle.Text = x.Title;
                ViewState["EditID"] = x.SubMemberTypeID;
                mvMain.SetActiveView(vwEdit);
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
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

        protected void btnAddSubMemberType_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            mvMain.SetActiveView(vwEdit);
            ViewState["EditID"] = 0;
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
                currentId = SubMemberType.SaveSubMemberType(currentId, txtTitle.Text);
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
                ((LinkButton)e.Row.Cells[1].FindControl("lnkEdit")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
            }
        }
    }
}