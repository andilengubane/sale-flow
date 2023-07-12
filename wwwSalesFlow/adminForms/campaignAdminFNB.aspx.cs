using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.adminForms
{
    public partial class campaignAdminFNB : System.Web.UI.Page
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
                    LoadCampaignClients();
                    ShowAll();
                }
            }
        }
        private void LoadCampaignClients()
        {
            cmbCampaignGroup.DataSource = Clients.GetAllActiveClients();
            cmbCampaignGroup.DataBind();
        }

        private void LoadCampaignWorkflowStatuses(int campaignID)
        {
            cmbFinalStatus.DataSource = WorkflowStep.GetWorkflowStepByCampaign(campaignID);
            //cmbFinalStatus.DataSource = WorkflowStep.GetAllWorkflowSteps();
            cmbFinalStatus.DataBind();
        }
        private void ShowAll()
        {
            gvAll.DataSource = Campaign.GetAllCampaigns();
            gvAll.DataBind();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadSelectedCampaign(theId);
        }

        protected void btnAddCampaign_Click(object sender, EventArgs e)
        {
            txtCampaignID.Text = "";
            txtCampaignName.Text = "";
            txtDescription.Text = "";
            txtCaptureForm.Text = "";
            chkActive.Checked = false;

            cmbFinalStatus.DataSource = WorkflowStep.GetAllWorkflowSteps();
            cmbFinalStatus.DataBind();

            if (cmbCampaignGroup.Items.Count > 0) cmbCampaignGroup.SelectedIndex = 0;
            txtCampaignSetting1.Text = "";
            txtCampaignSetting2.Text = "";
            txtCampaignSetting3.Text = "";
            txtCampaignSetting4.Text = "";
            txtCampaignSetting5.Text = "";
            txtCampaignSetting6.Text = "";
            txtCampaignSetting7.Text = "";

            mvMain.SetActiveView(vwEdit);
            ViewState["EditID"] = 0;
        }

        private void LoadSelectedCampaign(int iD)
        {
            Campaign x = new Campaign(iD);
            if (x.Found)
            {
                LoadCampaignWorkflowStatuses(x.CampaignID);

                txtCampaignID.Text = x.ExtCampaignID.ToString();
                txtCampaignName.Text = x.Title;
                txtDescription.Text = x.Description;
                txtCaptureForm.Text = x.CaptureForm;
                chkActive.Checked = x.IsActive;
                txtSweepPercentage.Text = x.SweepPercentage.ToString();
                lblSweepValue.Text = x.SweepPercentage.ToString() + " %";

                BusinessLogic.Validators.SetDropDownBoxText(x.FinalStatus, ref cmbFinalStatus);

                cmbCampaignGroup.SelectedValue = x.ClientsID.ToString();
                txtCampaignSetting1.Text = x.CampaignSetting1;
                txtCampaignSetting2.Text = x.CampaignSetting2;
                txtCampaignSetting3.Text = x.CampaignSetting3;
                txtCampaignSetting4.Text = x.CampaignSetting4;
                txtCampaignSetting5.Text = x.CampaignSetting5;
                txtCampaignSetting6.Text = x.CampaignSetting6;
                txtCampaignSetting7.Text = x.CampaignSetting7;

                mvMain.SetActiveView(vwEdit);
                ViewState["EditID"] = x.CampaignID;
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
        }

        private void LoadPricing(int iD)
        {
            List<CampaignBenefits> x = CampaignBenefits.GetCampaignBenefitList((iD));
            if (x.Count > 0)
            {
                txtPremium.Text = x[0].PremiumAmount.ToString("#.00");
                txtBenefit.Text = x[0].BenefitAmount.ToString("#.00");
            }
            else
            {
                txtPremium.Text = "0.00";
                txtBenefit.Text = "0.00";
            }

            mvMain.SetActiveView(vwPricing);
            ViewState["EditID"] = iD;
            mvMain.SetActiveView(vwPricing);
        }

        private void LoadWorkflowSteps(int iD)
        {
            Campaign x = new Campaign(iD);
            if (x.Found)
            {
                lblWorkflowCampaign.Text = x.Title;
                gvWorkFlow.DataSource = WorkflowStep.GetAllWorkflowSteps();
                gvWorkFlow.DataBind();

                #region Tick Already Selected

                List<CampaignWorkflowSteps> cws = CampaignWorkflowSteps.GetWorkflowStepsList(iD);
                for (int i = 0; i < gvWorkFlow.Rows.Count; i++)
                {
                    for (int j = 0; j < cws.Count; j++)
                    {
                        if ((int)gvWorkFlow.DataKeys[i]["WorkflowID"] == cws[j].WorkflowStepID)
                        {
                            ((CheckBox)gvWorkFlow.Rows[i].Cells[1].FindControl("chkAllow")).Checked = true;
                            ((CheckBox)gvWorkFlow.Rows[i].Cells[1].FindControl("chkAllow")).Enabled = false;
                            continue;
                        }
                    }
                }
                cws.Clear();

                #endregion

                mvMain.SetActiveView(vwWorkFlowSteps);
                ViewState["EditID"] = x.CampaignID;
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
            x = null;
        }

        private void LoadRelationshipsTypes(int iD)
        {
            Campaign x = new Campaign(iD);
            if (x.Found)
            {
                lblSubMemberRelationships.Text = x.Title;
                gvSubMemberRelationships.DataSource = RelationshipType.GetRelationshipTypeList();
                gvSubMemberRelationships.DataBind();

                #region Tick Already Selected

                List<CampaignRelationshipType> cws = CampaignRelationshipType.GetRelationshipTypes(iD);
                for (int i = 0; i < gvSubMemberRelationships.Rows.Count; i++)
                {
                    for (int j = 0; j < cws.Count; j++)
                    {
                        if ((int)gvSubMemberRelationships.DataKeys[i]["RelationshipTypeID"] == cws[j].RelationshipTypeID)
                        {
                            ((CheckBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("chkAllow")).Checked = true;
                            ((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtPremiumRelation")).Enabled = true;
                            ((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtBenefitRelation")).Enabled = true;
                            ((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtPremiumRelation")).Text = cws[j].PremiumAmount.ToString("#0.00");
                            ((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtBenefitRelation")).Text = cws[j].BenefitAmount.ToString("#0.00");
                            continue;
                        }
                    }
                }
                cws.Clear();

                #endregion

                mvMain.SetActiveView(vwSubMemberRelationships);
                ViewState["EditID"] = x.CampaignID;
            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }
            x = null;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["EditID"] != null)
            {
                int currentId = (int)ViewState["EditID"];
                currentId = Campaign.SaveCampaign(currentId, txtCampaignName.Text, txtDescription.Text, chkActive.Checked, txtCaptureForm.Text, int.Parse(txtCampaignID.Text), int.Parse(txtSweepPercentage.Text), cmbFinalStatus.SelectedItem.Text, int.Parse(cmbFinalStatus.SelectedItem.Value), int.Parse(cmbCampaignGroup.SelectedValue), txtCampaignSetting1.Text, txtCampaignSetting2.Text, txtCampaignSetting3.Text, txtCampaignSetting4.Text, txtCampaignSetting5.Text, txtCampaignSetting6.Text, txtCampaignSetting7.Text);
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ViewState["EditID"] = 0;
            mvMain.SetActiveView(vwMain);
            ShowAll();
        }

        protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.Cells[3].FindControl("lnkEdit")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
                ((LinkButton)e.Row.Cells[3].FindControl("lnkPricing")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
                ((LinkButton)e.Row.Cells[3].FindControl("lnkWorkFlowStep")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
                ((LinkButton)e.Row.Cells[3].FindControl("lnkRelationshipTypes")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
                ((LinkButton)e.Row.Cells[3].FindControl("lnkWorkflowNextStep")).CommandArgument = gvAll.DataKeys[e.Row.RowIndex][0].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvMain.SetActiveView(vwMain);
        }

        protected void lnkPricing_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadPricing(theId);
        }

        protected void lnkWorkFlowStep_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadWorkflowSteps(theId);
        }

        protected void btnPricingSave_Click(object sender, EventArgs e)
        {
            if (ViewState["EditID"] != null)
            {
                int currentId = (int)ViewState["EditID"];

                decimal prem = decimal.Parse(txtPremium.Text.Replace(",", "").Replace(".", ","));
                decimal ben = decimal.Parse(txtBenefit.Text.Replace(",", "").Replace(".", ","));

                currentId = CampaignBenefits.SaveCampaignBenefits(currentId, prem, ben);
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
        protected void btnPricingSaveNew_Click(object sender, EventArgs e)
        {
            if (ViewState["EditID"] != null)
            {
                int currentId = (int)ViewState["EditID"];

                decimal prem = decimal.Parse(txtPremium.Text.Replace(",", "").Replace(".", ","));
                decimal ben = decimal.Parse(txtBenefit.Text.Replace(",", "").Replace(".", ","));

                currentId = CampaignBenefits.SaveCampaignBenefits(currentId, prem, ben);
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
        protected void btnWorkFlowSave_Click(object sender, EventArgs e)
        {
            int changeCount = 0;
            for (int i = 0; i < gvWorkFlow.Rows.Count; i++)
            {
                if (((CheckBox)gvWorkFlow.Rows[i].Cells[1].FindControl("chkAllow")).Enabled
                    && ((CheckBox)gvWorkFlow.Rows[i].Cells[1].FindControl("chkAllow")).Checked)
                {
                    int newId = CampaignWorkflowSteps.AddWorkflowStepToCampaign((int)gvWorkFlow.DataKeys[i]["WorkflowID"], (int)ViewState["EditID"]);
                    if (newId > 0) changeCount++;
                }
            }

            if (changeCount > 0)
            {
                lblConfirmation.Text = "Record Saved Successfully. <br/> Changes: " + changeCount.ToString();
            }
            else
            {
                lblConfirmation.Text = "No Changes Applied!!! <br/> Please refresh and try again.";
            }
            mvMain.SetActiveView(vwConfirm);
        }

        protected void lnkRelationshipTypes_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadRelationshipsTypes(theId);
        }

        protected void chkAllow_CheckedChanged(object sender, EventArgs e)
        {
            int rowInd = ((GridViewRow)((System.Web.UI.Control)sender).Parent.Parent).RowIndex;
            if (rowInd <= gvSubMemberRelationships.Rows.Count)
            {
                ((TextBox)gvSubMemberRelationships.Rows[rowInd].Cells[1].FindControl("txtPremiumRelation")).Enabled = ((CheckBox)sender).Checked;
                ((TextBox)gvSubMemberRelationships.Rows[rowInd].Cells[1].FindControl("txtBenefitRelation")).Enabled = ((CheckBox)sender).Checked;
            }
        }

        protected void btnSaveRelationships_Click(object sender, EventArgs e)
        {
            int changeCount = 0;
            for (int i = 0; i < gvSubMemberRelationships.Rows.Count; i++)
            {
                if (((CheckBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("chkAllow")).Checked)
                {
                    decimal premiumAmt = 0;
                    decimal benefitAmt = 0;

                    decimal.TryParse(((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtPremiumRelation")).Text, out premiumAmt);
                    decimal.TryParse(((TextBox)gvSubMemberRelationships.Rows[i].Cells[1].FindControl("txtBenefitRelation")).Text, out benefitAmt);

                    int newId = CampaignRelationshipType.SaveCampaignRelationshipType((int)gvSubMemberRelationships.DataKeys[i]["RelationshipTypeID"], (int)ViewState["EditID"], premiumAmt, benefitAmt);
                    if (newId > 0) changeCount++;
                }
                else
                {
                    CampaignRelationshipType.RemoveCampaignRelationshipType((int)gvSubMemberRelationships.DataKeys[i]["RelationshipTypeID"], (int)ViewState["EditID"]);
                }
            }

            if (changeCount > 0)
            {
                lblConfirmation.Text = "Record Saved Successfully. <br/> Changes: " + changeCount.ToString();
            }
            else
            {
                lblConfirmation.Text = "No Changes Applied!!! <br/> Please refresh and try again.";
            }
            mvMain.SetActiveView(vwConfirm);
        }

        protected void lnkWorkflowNextStep_Click(object sender, EventArgs e)
        {
            int theId = int.Parse(((LinkButton)sender).CommandArgument);
            LoadWorkflowNextStep(theId);
        }

        private void LoadWorkflowNextStep(int campaigniD)
        {
            Campaign x = new Campaign(campaigniD);
            if (x.Found)
            {
                ViewState["EditID"] = x.CampaignID;

                lblNextStepEditCampaignName.Text = x.Title;
                gvNextStep.DataSource = CampaignWorkflowSteps.GetWorkflowStepsList(x.CampaignID);
                gvNextStep.DataBind();

                mvMain.SetActiveView(vwNextStepEdit);

            }
            else
            {
                mvMain.SetActiveView(vwConfirm);
                lblConfirmation.Text = "Selected record not found. <br/> Please refresh and try again.";
            }

            x = null;
        }

        protected void gvNextStep_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<CampaignWorkflowSteps> configuredList = CampaignWorkflowSteps.GetWorkflowStepsList((int)ViewState["EditID"]);

                ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).DataTextField = "WorkflowStepName";
                ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).DataValueField = "WorkflowStepID";
                ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).DataSource = configuredList;
                ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).DataBind();

                ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).Items.Insert(0, new ListItem("< None >", "0"));

                WorkflowNextStep selItem = WorkflowNextStep.GetWorkflowNextStepsByCampaignIdAndCurrentWorkflowStepID((int)ViewState["EditID"], (int)gvNextStep.DataKeys[e.Row.RowIndex][1]);

                if (selItem.Found)
                {
                    WorkflowStep ws = WorkflowStep.GetWorkflowStep(selItem.WorkflowNextStepID);
                    if (ws.Found)
                    {
                        ((DropDownList)e.Row.Cells[1].FindControl("cmbNextStep")).SelectedValue = ws.WorkflowID.ToString();
                    }
                    ws = null;
                }

                configuredList.Clear();
                configuredList = null;
            }
        }

        protected void btnNextStepCancel_Click(object sender, EventArgs e)
        {
            mvMain.SetActiveView(vwMain);
        }

        protected void btnNextStepSave_Click(object sender, EventArgs e)
        {
            int campaignID = (int)ViewState["EditID"];

            int changeCount = 0;

            for (int i = 0; i < gvNextStep.Rows.Count; i++)
            {
                int selectedNextWorkflowStepID = int.Parse(((DropDownList)gvNextStep.Rows[i].Cells[1].FindControl("cmbNextStep")).SelectedValue);
                int curWorkflowStepID = (int)gvNextStep.DataKeys[i][1];
                int campaignWorkflowStepID = (int)gvNextStep.DataKeys[i][0];

                WorkflowNextStep editItem = WorkflowNextStep.GetWorkflowNextStepsByCampaignIdAndCurrentWorkflowStepID(campaignID, curWorkflowStepID);

                if (editItem.WorkflowNextStepID != selectedNextWorkflowStepID)
                {
                    if (selectedNextWorkflowStepID == 0) //If zero, means it has been set to none.
                    {
                        //Delete entry
                        if (editItem.Delete())
                        {
                            changeCount++;
                        }
                    }
                    else
                    {
                        //Save changes by passing the new workflowstepID to the current object
                        if (editItem.Update(curWorkflowStepID, selectedNextWorkflowStepID, campaignWorkflowStepID))
                        {
                            changeCount++;
                        }
                    }
                }
                editItem = null;
            }

            mvMain.SetActiveView(vwConfirm);
            if (changeCount > 0)
            {
                lblConfirmation.Text = string.Format("Successful number of changes applied: {0}", changeCount);
            }
            else
            {
                lblConfirmation.Text = "NO changes applied. <br/> Please check again.";
            }
        }

     
    }
}