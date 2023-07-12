using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.campaignsForms
{
    public partial class FNBBCPP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserID"] = 2;

            if (!IsPostBack)
            {
                txtNotes.Attributes.Add("MaxLength", "255");

                mvMain.SetActiveView(vwMain);

                Sales sal = null;
                if (Request["SaleID"] == null)
                {
                    //validate the remaining parameters....
                    if (Request["LeadID"] == null || Request["CampaignID"] == null)
                    {
                        lblConfirmation.Text = "Sale or Lead ID not supplied. <br/> Please try again.";
                        mvMain.SetActiveView(vwConfirm);
                        return;
                    }
                    else
                    {
                        sal = Sales.GetSale(Convert.ToInt32(Request["LeadID"]), Convert.ToInt32(Request["CampaignID"]));
                        if (sal.Found)
                        {
                            ViewState["LeadID"] = sal.LeadID;
                            ViewState["CampaignID"] = sal.CampaignID;
                            ViewState["IsDialed"] = sal.IsDialed;
                        }
                        else
                        {
                            lblConfirmation.Text = "Sale or Lead ID not supplied. <br/> Please try again.";
                            mvMain.SetActiveView(vwConfirm);
                        }
                    }
                }
                else
                {
                    ViewState["SaleID"] = Convert.ToInt32(Request["SaleID"].ToString());
                    sal = Sales.GetSale((int)ViewState["SaleID"]);
                    if (sal.Found)
                    {
                        ViewState["LeadID"] = sal.LeadID;
                        ViewState["CampaignID"] = sal.CampaignID;
                        ViewState["IsDialed"] = sal.IsDialed;
                    }
                    else
                    {
                        lblConfirmation.Text = "Sale or Lead ID not found. <br/> Please try again.";
                        mvMain.SetActiveView(vwConfirm);
                        return;
                    }
                }


                #region Facility(s)
                //Load Family Rider Relationship Types:

                cmbCredit1.DataSource = BusinessLogic.RevolvingFacilities.GetOverdraft();
                cmbCredit1.DataValueField = "FacilitiesID";
                cmbCredit1.DataTextField = "Facilities";
                cmbCredit1.DataBind();

                #endregion

                #region Title(s)
                cmbTitle.DataSource = BusinessLogic.CommonLists.GetTitle();
                cmbTitle.DataValueField = "Value";
                cmbTitle.DataTextField = "Key";
                cmbTitle.DataBind();
                #endregion

                #region Disposition
                cmbDisposition.DataSource = BusinessLogic.CommonLists.GetDisposition();
                cmbDisposition.DataValueField = "Value";
                cmbDisposition.DataTextField = "Key";
                cmbDisposition.DataBind();
                #endregion

                #region Debit Order Day

                cmbDebitOrderDay.DataSource = BusinessLogic.CommonLists.GetDebitOrderDays();
                cmbDebitOrderDay.DataValueField = "Value";
                cmbDebitOrderDay.DataTextField = "Key";
                cmbDebitOrderDay.DataBind();

                #endregion

                #region Languages
                List<Languages> langs = Languages.GetAllLanguages();

                Languages tmpLang = new Languages();
                tmpLang.LanguagesID = 0;
                tmpLang.Title = "< select >";
                langs.Insert(0, tmpLang);

                cmbCallLanguage.DataSource = langs;
                cmbCallLanguage.DataTextField = "Title";
                cmbCallLanguage.DataValueField = "LanguagesID";
                cmbCallLanguage.DataBind();

                tmpLang = null;
                langs = null;
                #endregion

                #region load sale details:
                //// Expecting the following parameteres ...
                /// LeadID, Campaign, AgentCode
                ////

                if (Request["SaleID"] == null)
                {
                    //validate the remaining parameters....
                    if (Request["LeadID"] == null || Request["CampaignID"] == null)
                    {
                        lblConfirmation.Text = "Sale or Lead ID not supplied. <br/> Please try again.";
                        mvMain.SetActiveView(vwConfirm);
                    }
                    else
                    {
                        try
                        {
                            ViewState["LeadID"] = Convert.ToInt32(Request["LeadID"].ToString());
                            ViewState["CampaignID"] = Convert.ToInt32(Request["CampaignID"].ToString());
                            ViewState["AgentCode"] = Request["AgentCode"].ToString();

                            sal = Sales.GetSale((int)ViewState["LeadID"], (int)ViewState["CampaignID"]);
                            if (sal.Found)
                            {
                                ViewState["SaleID"] = sal.ID;
                                ViewState["IsDialed"] = sal.IsDialed;

                                LoadPersonalDetails(sal.ID);
                                LoadBankDetails(sal.ID);
                                //LoadSubmemberDetails(sal.ID);
                                loadSaleHistory(sal.ID);
                                //LoadCampaignBenefits(sal.CampaignID);
                                LoadRelationshipTypes(sal.CampaignID);
                            }
                            else
                            {
                                lblConfirmation.Text = string.Format("Lead ID: {0} not found.<br/> Please try again.", ViewState["LeadID"].ToString());
                                mvMain.SetActiveView(vwConfirm);
                            }
                        }
                        catch (Exception ex)
                        {
                            lblConfirmation.Text = ex.Message + "<br/> Please try again.";
                            mvMain.SetActiveView(vwConfirm);
                        }
                    }
                }
                else
                {
                    try
                    {
                        ViewState["SaleID"] = Convert.ToInt32(Request["SaleID"].ToString());

                        sal = Sales.GetSale((int)ViewState["SaleID"]);
                        if (sal.Found)
                        {
                            ViewState["LeadID"] = sal.LeadID;
                            ViewState["CampaignID"] = sal.CampaignID;
                            ViewState["IsDialed"] = sal.IsDialed;

                            LoadPersonalDetails(sal.ID);
                            LoadBankDetails(sal.ID);
                            //LoadSubmemberDetails(sal.ID);
                            loadSaleHistory(sal.ID);
                        }
                        else
                        {
                            lblConfirmation.Text = "Sale not found.<br/> Please try again.";
                            mvMain.SetActiveView(vwConfirm);
                        }
                    }
                    catch (Exception ex)
                    {
                        lblConfirmation.Text = ex.Message + "<br/> Please try again.";
                        mvMain.SetActiveView(vwConfirm);
                    }
                }

                sal = null;
                #endregion
            }
        }

        private void LoadCampaignBenefits(int CampaignID)
        {
            List<CampaignBenefits> lstBenefits = CampaignBenefits.GetCampaignBenefitList(CampaignID);
            CampaignBenefits dummyBenefit = new CampaignBenefits();
            dummyBenefit.BenefitAmount = 0;
            dummyBenefit.CampaignBenefitsID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbBenefit.DataTextField = "BenefitAmount";
            cmbBenefit.DataValueField = "CampaignBenefitsID";
            cmbBenefit.DataSource = lstBenefits;
            cmbBenefit.DataBind();
        }
        private void LoadRelationshipTypes(int CampaignID)
        {
            List<RevolvingFacilities> lstBenefits = RevolvingFacilities.GetOverdraft();
            RevolvingFacilities dummyBenefit = new RevolvingFacilities();
            dummyBenefit.Facilities = "[ Select Credit Protection ]";
            dummyBenefit.FacilitiesID = -1;
            lstBenefits.Insert(0, dummyBenefit);

            cmbCredit1.DataTextField = "Facilities";
            cmbCredit1.DataValueField = "FacilitiesID";
            cmbCredit1.DataSource = lstBenefits;
            cmbCredit1.DataBind();
        }
        private void LoadPersonalDetails(int saleID)
        {
            PersonalDetails mem = PersonalDetails.GetPersonalDetails(saleID);
            if (mem.Found)
            {
                cmbTitle.SelectedValue = mem.Title;
                txtFirstname.Text = mem.FirstName;
                txtSurname.Text = mem.Surname;
                txtIdNumber.Text = mem.IDNumber;
                txtPassportNumber.Text = mem.PassportNumber;
                txtDateOfBirth.Text = mem.DateOfBirth.ToString("yyyy-MM-dd");
                txtTelWork.Text = mem.TelWork;
                txtTelCell.Text = mem.TelCell;
                // txtTelHome.Text = mem.TelHome;
                // txtTelFax.Text = mem.TelFax;
                cmbGender.SelectedValue = mem.Gender;
                txtPostalAddress1.Text = mem.Address1;
                txtPostalAddress2.Text = mem.Address2;
                txtSurburb.Text = mem.Address3;
                // txtPostalAddress4.Text = mem.Address4;
                // txtCity.Text = mem.City;
                txtPostalCode.Text = mem.PostalCode;
                txtEMail.Text = mem.Email;
            }
            mem = null;
        }

        private void LoadSubmemberDetails(int saleID)
        {
            //GET Rider: SubmemberType ID = 1
            List<SubMemberDetails> subMembers = SubMemberDetails.GetSubMembers(saleID, 1);
            for (int i = 0; i < subMembers.Count; i++)
            {
                int idx = i + 1;

                if (idx > 5) break;
                ((CheckBox)mvMain.FindControl("chkR" + idx.ToString())).Checked = true;

                ((TextBox)mvMain.FindControl("txtRIDateOfBirth" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtRIName" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtRISurname" + idx.ToString())).Enabled = true;
                ((DropDownList)mvMain.FindControl("cmbRIRelationship" + idx.ToString())).Enabled = true;


                ((TextBox)mvMain.FindControl("txtRIDateOfBirth" + idx.ToString())).Text = subMembers[i].DateOfBirth.ToString("yyyy-MM-dd");
                ((TextBox)mvMain.FindControl("txtRIName" + idx.ToString())).Text = subMembers[i].FirstName;
                ((TextBox)mvMain.FindControl("txtRISurname" + idx.ToString())).Text = subMembers[i].Surname;
                ((DropDownList)mvMain.FindControl("cmbRIRelationship" + idx.ToString())).SelectedValue = subMembers[i].RelationshipTypeID.ToString();
            }
            subMembers = null;

            //GET Family Rider: SubmemberType ID = 4
            List<SubMemberDetails> familySubMembers = SubMemberDetails.GetSubMembers(saleID, 4);
            for (int i = 0; i < familySubMembers.Count; i++)
            {
                int idx = i + 1;

                if (idx > 5) break;
                ((CheckBox)mvMain.FindControl("chkFR" + idx.ToString())).Checked = true;

                ((TextBox)mvMain.FindControl("txtFRSurname" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtFRName" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtFRDateOfBirth" + idx.ToString())).Enabled = true;
                ((DropDownList)mvMain.FindControl("cmbFRRelationship" + idx.ToString())).Enabled = true;

                ((TextBox)mvMain.FindControl("txtFRSurname" + idx.ToString())).Text = familySubMembers[i].Surname;
                ((TextBox)mvMain.FindControl("txtFRName" + idx.ToString())).Text = familySubMembers[i].FirstName;
                ((TextBox)mvMain.FindControl("txtFRDateOfBirth" + idx.ToString())).Text = familySubMembers[i].DateOfBirth.ToString("yyyy-MM-dd");
                ((DropDownList)mvMain.FindControl("cmbFRRelationship" + idx.ToString())).SelectedValue = familySubMembers[i].RelationshipTypeID.ToString();
            }
            familySubMembers = null;
        }

        private void LoadBankDetails(int saleID)
        {
            BankDetails bank = BankDetails.GetBankDetails(saleID);
            if (bank.Found)
            {
                txtBankAccountNumber.Text = BusinessLogic.Validators.MaskBankDetails(bank.AccountNumber);

                txtBankName.Text = bank.BankName;
                txtBankAccountHolder.Text = bank.AccountName;
                if (bank.FirstDebitDay == 0)
                {
                    cmbDebitOrderDay.SelectedValue = DateTime.Now.AddDays(3).Day.ToString();
                }
                else
                {
                    cmbDebitOrderDay.SelectedValue = bank.FirstDebitDay.ToString();
                }
            }
            bank = null;
        }

        private void loadSaleHistory(int saleID)
        {
            gvHistory.DataSource = SalesLog.GetAllSalesLog(saleID);
            gvHistory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Workflow Step... set to next step....
            lblConfirmation.Text = "Success: <br/>Sale submitted.";
            int savedRiderCount = 0;
            int savedFamilyRiderCount = 0;

            if (Session["userID"] != null)
            {
                int campaignID = Convert.ToInt32(ViewState["CampaignID"]);
                Users currentUser = Users.GetUserByID(Convert.ToInt32(Session["userID"]));
                if (currentUser.Found)
                {
                    WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Pre-VET", campaignID);

                    if (ws.Found)
                    {
                        //Create New Sale if New...
                        if (ViewState["SaleID"] != null)
                        {
                            Sales sal = Sales.GetSale((int)ViewState["SaleID"]);
                            int saleID = sal.ID;

                            saleID = Sales.SaveSale(saleID, currentUser.ID, currentUser.ADUserName, DateTime.Now, ws.WorkflowID, ws.StepName,
                                "", "", "", "", "", "", "", "", "", "", Convert.ToInt32(cmbCallLanguage.SelectedValue));

                            if (saleID > 0)
                            {
                                //Save Sales Log...
                                int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());
                                //Save Personal Details...
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, txtFirstname.Text, txtSecondName.Text, txtSurname.Text, txtIdNumber.Text, txtPassportNumber.Text, DateTime.Parse(txtDateOfBirth.Text), txtTelWork.Text, txtTelCell.Text, "", "", cmbGender.SelectedValue, txtPostalAddress1.Text, txtPostalAddress2.Text, txtSurburb.Text, "", "", txtPostalCode.Text, txtEMail.Text, 0);

                                //Save SubMembers Riders...
                                int submemberID = SubMemberType.GetSubMemberType("Rider").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 6; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkR" + i.ToString())).Checked)
                                    {
                                        string productName = ((TextBox)mvMain.FindControl("txtproductname" + i.ToString())).Text;
                                        string productCode = ((TextBox)mvMain.FindControl("txtproductcode" + i.ToString())).Text;
                                        string profuctSubCode = ((TextBox)mvMain.FindControl("txtsubproductcode" + i.ToString())).Text;
                                        string productAccount = ((TextBox)mvMain.FindControl("txtproductaccount" + i.ToString())).Text;
                                        string creditProtection = ((DropDownList)mvMain.FindControl("cmbCredit" + i.ToString())).SelectedValue;

                                        //int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
                                        //if (newID > 0)
                                        //{
                                        //    savedRiderCount += 1;
                                        //}
                                    }
                                }

                                //Save SubMembers Family Riders...
                                submemberID = SubMemberType.GetSubMemberType("Family Rider").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 6; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkFR" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtFRSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtFRName" + i.ToString())).Text;
                                        string secondName = ((TextBox)mvMain.FindControl("txtFRSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbFRGender" + i.ToString())).SelectedValue;
                                        string idNumber = ((TextBox)mvMain.FindControl("txtFRIdNumber" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtFRDateOfBirth" + i.ToString())).Text);
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbFRRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
                                        if (newID > 0)
                                        {
                                            savedFamilyRiderCount += 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lblConfirmation.Text = string.Format("Sale {0} not saved... <br/> Please escalate to admin", sal.ID.ToString());
                                mvMain.SetActiveView(vwConfirm);
                            }
                            sal = null;
                        }
                    }
                    ws = null;
                    mvMain.SetActiveView(vwConfirm);
                }
            }
            else
            {
                lblConfirmation.Text = "Session Expired <br/>Please close your browser and start again.";
                mvMain.SetActiveView(vwConfirm);
            }
        }

        private void EnableDisableRider(int idx, bool enabled)
        {
            ((TextBox)mvMain.FindControl("txtproductname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtproductcode" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtsubproductcode" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtproductaccount" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbCredit" + idx.ToString())).Enabled = enabled;
        }

        protected void chkR1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(1, chkR1.Checked);
        }
        protected void chkR2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(2, chkR2.Checked);
        }

        protected void chkR3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(3, chkR3.Checked);
        }

        protected void chkR4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(4, chkR4.Checked);
        }

        protected void btnECCNo_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {

        }

        protected void txtBankAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Workflow Step... set to next step....
            int savedRiderCount = 0;
            int savedFamilyRiderCount = 0;

            lblConfirmation.Text = "Sale saved successfully.";

            if (Session["userID"] != null)
            {
                int campaignID = Convert.ToInt32(ViewState["CampaignID"]);
                Users currentUser = Users.GetUserByID(Convert.ToInt32(Session["userID"]));
                if (currentUser.Found)
                {
                    WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Capture", campaignID);

                    if (ws.Found)
                    {
                        //Create New Sale if New...
                        if (ViewState["SaleID"] != null)
                        {
                            Sales sal = Sales.GetSale((int)ViewState["SaleID"]);
                            int saleID = sal.ID;

                            //WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Capture", campaignID);

                            saleID = Sales.SaveSale(saleID, currentUser.ID, currentUser.ADUserName, DateTime.Now, ws.WorkflowID, ws.StepName);

                            if (saleID > 0)
                            {
                                //Save Sales Log...
                                int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());
                                //Save Personal Details...
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, txtFirstname.Text, txtSecondName.Text, txtSurname.Text, txtIdNumber.Text, txtPassportNumber.Text, DateTime.Parse(txtDateOfBirth.Text), txtTelWork.Text, txtTelCell.Text, "", "", cmbGender.SelectedValue, txtPostalAddress1.Text, txtPostalAddress2.Text, txtSurburb.Text, "", "", txtPostalCode.Text, txtEMail.Text, 0);

                                //Save SubMembers Riders...
                                int submemberID = SubMemberType.GetSubMemberType("Rider").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 6; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkR" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtRISurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtRIName" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtRIDateOfBirth" + i.ToString())).Text);
                                        string secondName = ((TextBox)mvMain.FindControl("txtRISecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbRIGender" + i.ToString())).SelectedValue;
                                        string idNumber = ((TextBox)mvMain.FindControl("txtRIIdNumber" + i.ToString())).Text;
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbRIRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
                                        if (newID > 0)
                                        {
                                            savedRiderCount += 1;
                                        }
                                    }
                                }

                                //Save SubMembers Family Riders...
                                submemberID = SubMemberType.GetSubMemberType("Family Rider").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 6; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkFR" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtFRSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtFRName" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtFRDateOfBirth" + i.ToString())).Text);
                                        string secondName = ((TextBox)mvMain.FindControl("txtFRSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbFRGender" + i.ToString())).SelectedValue;
                                        string idNumber = ((TextBox)mvMain.FindControl("txtFRIdNumber" + i.ToString())).Text;
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbFRRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
                                        if (newID > 0)
                                        {
                                            savedFamilyRiderCount += 1;
                                        }
                                    }
                                }

                                //Save Banking Details...
                                DateTime debitDate = BusinessLogic.Validators.MakeDateFromDay(int.Parse(cmbDebitOrderDay.SelectedValue));
                                #region format BankAccountNumber
                                long bankAccountNumber;
                                //if it contains X's we assume the account number has not been altered. - deal with it.
                                if (txtBankAccountNumber.Text.IndexOf("X") >= 0)
                                {
                                    BankDetails bank = BankDetails.GetBankDetails(sal.ID);
                                    if (bank.Found)
                                    {
                                        bankAccountNumber = long.Parse(bank.AccountNumber.Replace("-", ""));
                                    }
                                    else
                                    {
                                        bankAccountNumber = 0;
                                    }
                                }
                                else
                                {
                                    if (!long.TryParse(txtBankAccountNumber.Text.Trim().Replace("-", ""), out bankAccountNumber))
                                    {
                                        bankAccountNumber = 0;
                                    }
                                }
                                #endregion

                                // int banId = BankDetails.ModifyBankDetails(bankAccountNumber, txtBankAccountHolder.Text, txtBankName.Text, cmbAccountCode.SelectedValue, "", debitDate.Month, debitDate.Day, "Primary", saleID);
                            }
                            else
                            {
                                lblConfirmation.Text = string.Format("Sale {0} not saved... <br/> Please escalate to admin", sal.ID.ToString());
                                mvMain.SetActiveView(vwConfirm);
                            }

                            DateTime callbackDate;
                            if (!DateTime.TryParse(txtScheduleDate.Text + " " + txtScheduleTime.Text, out callbackDate))
                            {
                                callbackDate = DateTime.Now.AddHours(4);
                            }
                            else
                            {
                                if (callbackDate <= DateTime.Now)
                                {
                                    callbackDate = DateTime.Now.AddHours(4);
                                }
                            }

                            BusinessLogic.DialAPI.ScheduleCallback(sal.CampaignName, sal.LeadID.ToString(), callbackDate, sal.AgentCode.ToString(), txtNotes.Text);
                            sal = null;
                        }
                    }
                    ws = null;


                    mvMain.SetActiveView(vwConfirm);
                }
            }
            else
            {
                lblConfirmation.Text = "Session Expired <br/>Please close your browser and start again.";
                mvMain.SetActiveView(vwConfirm);
            }
        }
        protected void cmbBenefit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPremiumAmount.Visible = true;
            lblPremiumAmount.Text = "Premium is R" + CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
            lblPremiumAmount.Font.Bold = true;
            lblPremiumAmount.ForeColor = System.Drawing.Color.Green;
            hiddenPremiumAmount.Value = CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
        }
    }
}