using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.campaignsForms
{
    public partial class MCAPL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


                #region Dropdowns
                LoadPackages();
                LoadDPPOffers();
                LoadInstallationsRequirements();
                LoadRetentionOffer();
                #endregion

                #region Title(s)
                cmbTitle.DataSource = BusinessLogic.CommonLists.GetTitle();
                cmbTitle.DataValueField = "ID";
                cmbTitle.DataTextField = "Name";
                cmbTitle.DataBind();
                #endregion

                #region Disposition
                cmbDisposition.DataSource = BusinessLogic.CommonLists.GetDisposition();
                cmbDisposition.DataValueField = "Value";
                cmbDisposition.DataTextField = "Key";
                cmbDisposition.DataBind();
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
                                loadSaleHistory(sal.ID);
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

        private void LoadPackages()
        {
            List<BusinessLogic.Campaigns.MCA.Packages> lstPackages = BusinessLogic.Campaigns.MCA.Packages.GetAllPackages();
            BusinessLogic.Campaigns.MCA.Packages dummyPackages = new BusinessLogic.Campaigns.MCA.Packages();
            dummyPackages.Title = "[ Please Select ]";
            dummyPackages.PackagesID = -1;
            lstPackages.Insert(0, dummyPackages);
            ddlOldPackage.DataTextField = "Title";
            ddlOldPackage.DataValueField = "PackagesID";
            ddlOldPackage.DataSource = lstPackages;
            ddlOldPackage.DataBind();

            ddlNewPackage.DataTextField = "Title";
            ddlNewPackage.DataValueField = "PackagesID";
            ddlNewPackage.DataSource = lstPackages;
            ddlNewPackage.DataBind();
        }
        private void LoadDPPOffers()
        {
            List<BusinessLogic.Campaigns.MCA.DPPOffer> lstDPPOffers = BusinessLogic.Campaigns.MCA.DPPOffer.GetAllDPPOffers();
            BusinessLogic.Campaigns.MCA.DPPOffer dummyDPPOffers = new BusinessLogic.Campaigns.MCA.DPPOffer();
            dummyDPPOffers.Title = "[ Please Select ]";
            dummyDPPOffers.DPPOfferID = -1;
            lstDPPOffers.Insert(0, dummyDPPOffers);
            ddlDPPOffer.DataTextField = "Title";
            ddlDPPOffer.DataValueField = "DPPOfferID";
            ddlDPPOffer.DataSource = lstDPPOffers;
            ddlDPPOffer.DataBind();
        }
        private void LoadRetentionOffer()
        {
            List<BusinessLogic.Campaigns.MCA.RetentionOffer> lstRetentionOffers = BusinessLogic.Campaigns.MCA.RetentionOffer.GetAllRetentionOffers();
            BusinessLogic.Campaigns.MCA.RetentionOffer dummyRetentionOffers = new BusinessLogic.Campaigns.MCA.RetentionOffer();
            dummyRetentionOffers.Title = "[ Please Select ]";
            dummyRetentionOffers.RetentionOfferID = -1;
            lstRetentionOffers.Insert(0, dummyRetentionOffers);
            ddlRetentionOffer.DataTextField = "Title";
            ddlRetentionOffer.DataValueField = "RetentionOfferID";
            ddlRetentionOffer.DataSource = lstRetentionOffers;
            ddlRetentionOffer.DataBind();
        }
        private void LoadInstallationsRequirements()
        {
            List<BusinessLogic.Campaigns.MCA.InstallationsRequirements> lstInstallationsRequirements = BusinessLogic.Campaigns.MCA.InstallationsRequirements.GetAllInstallationsRequirements();
            BusinessLogic.Campaigns.MCA.InstallationsRequirements dummyInstallationsRequirements = new BusinessLogic.Campaigns.MCA.InstallationsRequirements();
            dummyInstallationsRequirements.Title = "[ Please Select ]";
            dummyInstallationsRequirements.InstallationsRequirementsID = -1;
            lstInstallationsRequirements.Insert(0, dummyInstallationsRequirements);
            ddlInstallationRequirement.DataTextField = "Title";
            ddlInstallationRequirement.DataValueField = "InstallationsRequirementsID";
            ddlInstallationRequirement.DataSource = lstInstallationsRequirements;
            ddlInstallationRequirement.DataBind();
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
                txtDatePromisedPay.Text = mem.DateOfBirth.ToString("yyyy-MM-dd");
                txtTelWork.Text = mem.TelWork;
                txtTelCell.Text = mem.TelCell;
                txtAddressLine1.Text = mem.Address1;
                txtAddressLine2.Text = mem.Address2;
                txtSuburb.Text = mem.Address3;
                txtCity.Text = mem.City;
                txtPostalCode.Text = mem.PostalCode;
            }
            mem = null;
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

            if (Session["userID"] != null)
            {
                int campaignID = Convert.ToInt32(ViewState["CampaignID"]);
                Users currentUser = Users.GetUserByID(Convert.ToInt32(Session["userID"]));
                if (currentUser.Found)
                {
                    WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Sale Complete", campaignID);

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
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, "", txtFirstname.Text, "", txtSurname.Text, txtIdNumber.Text, "", DateTime.Now, txtTelWork.Text, txtTelCell.Text, "", "", "", txtAddressLine1.Text, txtAddressLine2.Text, txtSuburb.Text, "", "", txtPostalCode.Text, "", 0);
                                // Save Sale Details
                                int saleDetails = BusinessLogic.Campaigns.MCA.SaleDetails.CreateSaleDetail(saleID, (ddlRetained.SelectedItem.Text == "Yes"), Convert.ToInt32(ddlOldPackage.SelectedValue), Convert.ToInt32(ddlNewPackage.SelectedValue), ddlUpOrDown.SelectedItem.Text, Convert.ToInt32(ddlRetentionOffer.SelectedValue),
                                    Convert.ToInt32(ddlInstallationRequirement.SelectedValue), txtInstallationNotes.Text.Trim(), txtAddressLine1.Text.Trim(), txtAddressLine2.Text.Trim(), txtSuburb.Text.Trim(), txtCity.Text.Trim(), txtPostalCode.Text.Trim(), Convert.ToInt32(ddlDPPOffer.SelectedValue), ddlDebitOrder.SelectedItem.Text,
                                    ddlDCCInsure.SelectedItem.Text, ddlBoxOfficeActivation.SelectedItem.Text, ddlConnectID.SelectedItem.Text, ddlMontlyPaymentNotifications.SelectedItem.Text, ddlPriceIncreaseNotification.SelectedItem.Text, ddlLastDisconnect.SelectedItem.Text,
                                    ddlComeBack.SelectedItem.Text, ddlOtherTVChannels.SelectedItem.Text, ddlLeaveReason.SelectedItem.Text, txtMoneyToPay.Text.Trim(), txtMoneyPaid.Text.Trim(), DateTime.Parse(txtDatePromisedPay.Text), true);

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Workflow Step... set to next step....
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

                            saleID = Sales.SaveSale(saleID, currentUser.ID, currentUser.ADUserName, DateTime.Now, ws.WorkflowID, ws.StepName);

                            if (saleID > 0)
                            {
                                //Save Sales Log...
                                int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());
                                //Save Personal Details...
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, "", txtFirstname.Text, "", txtSurname.Text, txtIdNumber.Text, "", DateTime.Now, txtTelWork.Text, txtTelCell.Text, "", "", "", txtAddressLine1.Text, txtAddressLine2.Text, txtSuburb.Text, "", "", txtPostalCode.Text, "", 0);
                                // Save Sale Details
                                int saleDetails = BusinessLogic.Campaigns.MCA.SaleDetails.CreateSaleDetail(saleID, (ddlRetained.SelectedItem.Text == "Yes"), Convert.ToInt32(ddlOldPackage.SelectedValue), Convert.ToInt32(ddlNewPackage.SelectedValue), ddlUpOrDown.SelectedItem.Text, Convert.ToInt32(ddlRetentionOffer.SelectedValue),
                                    Convert.ToInt32(ddlInstallationRequirement.SelectedValue), txtInstallationNotes.Text.Trim(), txtAddressLine1.Text.Trim(), txtAddressLine2.Text.Trim(), txtSuburb.Text.Trim(), txtCity.Text.Trim(), txtPostalCode.Text.Trim(), Convert.ToInt32(ddlDPPOffer.SelectedValue), ddlDebitOrder.SelectedItem.Text,
                                    ddlDCCInsure.SelectedItem.Text, ddlBoxOfficeActivation.SelectedItem.Text, ddlConnectID.SelectedItem.Text, ddlMontlyPaymentNotifications.SelectedItem.Text, ddlPriceIncreaseNotification.SelectedItem.Text, ddlLastDisconnect.SelectedItem.Text,
                                    ddlComeBack.SelectedItem.Text, ddlOtherTVChannels.SelectedItem.Text, ddlLeaveReason.SelectedItem.Text, txtMoneyToPay.Text.Trim(), txtMoneyPaid.Text.Trim(), DateTime.Parse(txtDatePromisedPay.Text), true);
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
    }
}