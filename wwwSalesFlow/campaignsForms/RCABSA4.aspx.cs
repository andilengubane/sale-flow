using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using RC = BusinessLogic.Campaigns.ROADCOVER;
using TP = wwwSalesFlow.TemplateProcessor;
using EmailLib;
using System.Web.Script.Services;

namespace wwwSalesFlow.campaignsForms
{
    public partial class RCABSA4 : System.Web.UI.Page
    {
        /// <summary>
        /// Primary Page-Load event handler
        /// </summary>
        /// <param name="sender">The WebPage that initiated the Page_Load event.</param>
        /// <param name="e">The event arguments passed to the event handler.</param>
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


                #region Relationship(s)
                //Load Family Rider Relationship Types:

                List<CampaignRelationshipType> relTypes = CampaignRelationshipType.GetRelationshipTypes((int)ViewState["CampaignID"]);

                relTypes = null;
                #endregion

                SetupProductsDropDown();
                SetupTitleDropDown();
                SetupProvinceDropDown();
                SetupDispositionDropDown();
                SetupGenderDropDown();
                //SetupDebitOrderDayDropDown();
                SetupBankDropDown();

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
                                LoadSaleHistory(sal.ID);
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
                            LoadSaleHistory(sal.ID);
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

        #region Control Events

        /// <summary>
        /// Click event handler for the Submit button.
        /// </summary>
        /// <param name="sender">The <see cref="Button"/> control that initiated the event (upcast to object).</param>
        /// <param name="e">The event arguments passed to the event handler.</param>
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

                            saleID = SaveSale(saleID, ws, currentUser);

                            if (saleID > 0)
                            {
                                //Save Sales Log...
                                int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());

                                //Save Personal Details...
                                int personalDetails = SavePersonalDetails(saleID);

                                //Save Sale Details
                                SaveSaleDetails(saleID, currentUser);

                                //Save Banking Details...
                                int banId = SaveBankDetails(saleID);
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

        /// <summary>
        /// Click event handler for the Save button.
        /// </summary>
        /// <param name="sender">The <see cref="Button"/> control that initiated the event (upcast to object).</param>
        /// <param name="e">The event arguments passed to the event handler.</param>
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

                            saleID = SaveSale(saleID, ws, currentUser);

                            if (saleID > 0)
                            {
                                //Save Sales Log...
                                string logDetails = $"{ws.StepName } : { txtNotes.Text.Trim() }";
                                int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, logDetails);

                                //Save Personal Details...
                                int personalDetails = SavePersonalDetails(saleID);

                                //Save Sale Details
                                SaveSaleDetails(saleID, currentUser);

                                //Save Banking Details...
                                int banId = SaveBankDetails(saleID);
                            }
                            else
                            {
                                lblConfirmation.Text = string.Format("Sale {0} not saved... <br/> Please escalate to admin", sal.ID.ToString());
                                mvMain.SetActiveView(vwConfirm);
                            }

                            SetupCallback(sal);

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

        /// <summary>
        /// Click event handler for the PremiumCalc button.
        /// </summary>
        /// <param name="sender">The <see cref="Button"/> control that initiated the event (upcast to object).</param>
        /// <param name="e">The event arguments passed to the event handler.</param>
        protected void btnPremiumCalc_Click(object sender, EventArgs e)
        {
            lblCalculatorPremiumAmount.Visible = true;
            lblCalculatorPremiumAmount.Text = "Total Premium Amount is R49.00";
            lblCalculatorPremiumAmount.ForeColor = System.Drawing.Color.Green;
        }

        #endregion

        #region Setup and Saving methods

        /// <summary>
        /// Pulls the necessary Bank names and IDs from the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in the Bank Name drop-down list on the front-end.
        /// </summary>
        private void SetupBankDropDown()
        {
            cmbBankName.DataSource = BusinessLogic.CommonLists.GetBanks();
            cmbBankName.DataValueField = "ID";
            cmbBankName.DataTextField = "BankName";
            cmbBankName.DataBind();
        }

        /// <summary>
        /// Pulls the necessary Title names and IDs from the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in Title drop-down lists on the front-end.
        /// </summary>
        private void SetupTitleDropDown()
        {
            cmbTitle.DataSource = BusinessLogic.CommonLists.GetTitle();
            cmbTitle.DataValueField = "ID";
            cmbTitle.DataTextField = "Name";
            cmbTitle.DataBind();
        }

        /// <summary>
        /// Pulls the necessary Province names and IDs from the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in the Province drop-down list on the front-end.
        /// </summary>
        private void SetupProvinceDropDown()
        {
            cmbProvince.DataSource = BusinessLogic.CommonLists.GetProvinces();
            cmbProvince.DataValueField = "ID";
            cmbProvince.DataTextField = "Name";
            cmbProvince.DataBind();
        }

        /// <summary>
        /// Pulls the necessary Disposition names and IDs from the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in the Disposition drop-down list on the front-end.
        /// </summary>
        private void SetupDispositionDropDown()
        {
            cmbDisposition.DataSource = BusinessLogic.CommonLists.GetDisposition();
            cmbDisposition.DataValueField = "Value";
            cmbDisposition.DataTextField = "Key";
            cmbDisposition.DataBind();
        }

        /// <summary>
        /// Pulls the necessary Gender names and IDs from the the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in the Gender drop-down list on the front-end.
        /// </summary>
        private void SetupGenderDropDown()
        {
            cmbGender.DataSource = BusinessLogic.CommonLists.GetGender();
            cmbGender.DataValueField = "Value";
            cmbGender.DataTextField = "Key";
            cmbGender.DataBind();
        }

        /// <summary>
        /// Pulls the necessary Debit Order Day values from the <see cref="BusinessLogic.CommonLists"/> object
        /// to use in the Debit Order Day drop-down list on the front-end.
        /// </summary>
        //private void SetupDebitOrderDayDropDown()
        //{
        //    cmbDebitOrderDay.DataSource = BusinessLogic.CommonLists.GetDebitOrderDays();
        //    cmbDebitOrderDay.DataValueField = "Value";
        //    cmbDebitOrderDay.DataTextField = "Key";
        //    cmbDebitOrderDay.DataBind();
        //}

        private void SetupProductsDropDown()
        {
            Campaign c = Campaign.GetCampaignByCampaignName("RCABSA4");
            List<RC.RoadCoverProductCatalog> products = RC.RoadCoverProductCatalog.GetListOfCampaignProducts(c.CampaignID);

            cmbProduct.DataSource = products;
            cmbProduct.DataValueField = "ID";
            cmbProduct.DataTextField = "Name";

            cmbProduct.DataBind();

            cmbProduct.Items.Insert(0, "<Select>");
        }

        /// <summary>
        /// Instantiates a <see cref="PersonalDetails"/> object containing the data for the sale ID 
        /// (or empty values if the sale is new), and initializes the front-end with said data.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to process.</param>
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
                txtTelHome.Text = mem.TelHome;
                // txtTelFax.Text = mem.TelFax;
                cmbGender.SelectedValue = mem.Gender;
                txtPostalAddress1.Text = mem.Address1;
                txtPostalAddress2.Text = mem.Address2;
                txtPostalAddress3.Text = mem.Address3;
                cmbProvince.SelectedValue = mem.Address4;
                txtCity.Text = mem.City;
                txtPostalCode.Text = mem.PostalCode;
                txtEmail.Text = mem.Email;
            }
            mem = null;
        }

        /// <summary>
        /// Instantiates a <see cref="BankDetails"/> object containing the data for the sale ID 
        /// (or empty values if the sale is new), and initializes the front-end with said data.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to process.</param>
        private void LoadBankDetails(int saleID)
        {
            BankDetails bank = BankDetails.GetBankDetails(saleID);
            RC.SaleDetailsRCABSA4 salesDetails = RC.SaleDetailsRCABSA4.GetSaleDetails(saleID);
            Bank bankData = Bank.GetBankByID(salesDetails.BankID);

            if (bank.Found)
            {
                txtBankAccountNumber.Text = BusinessLogic.Validators.MaskBankDetails(bank.AccountNumber);

                string bankVal = String.Empty;

                //foreach (ListItem item in cmbBankName.Items)
                //{
                //    if (item.Value.ToUpper() == bank.BankName.ToUpper())
                //    {
                //        cmbBankName.SelectedValue = item.Value;
                //        txtBankBranchCode.Text = bank.BranchCode;
                //        break;
                //    }
                //}

                cmbBankName.SelectedValue = bankData.BankName;
                txtBankBranchCode.Text = bankData.BranchCode;
                txtBankAccountHolder.Text = bank.BankAccountHolder;

                txtBankAccountHolder.Text = bank.AccountName;
                //if (bank.FirstDebitDay == 0)
                //{
                //    cmbDebitOrderDay.SelectedValue = DateTime.Now.AddDays(3).Day.ToString();
                //}
                //else
                //{
                //    cmbDebitOrderDay.SelectedValue = bank.FirstDebitDay.ToString();
                //}
            }
            bank = null;
        }

        /// <summary>
        /// Gets all sale logs for the specific sale, and binds said data to a <see cref="GridView"/>
        /// on the front-end
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to process.</param>
        private void LoadSaleHistory(int saleID)
        {
            gvHistory.DataSource = SalesLog.GetAllSalesLog(saleID);
            gvHistory.DataBind();
        }

        /// <summary>
        /// Sets up a callback on the dialler.
        /// </summary>
        /// <param name="sal">A <see cref="Sales"/> object containing necessary data to process the callback.</param>
        private void SetupCallback(Sales sal)
        {
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
        }

        /// <summary>
        /// Saves an instance of a PersonalDetails object to the database.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to process.</param>
        /// <returns>An <see cref="int"/> value containing the ID of the PersonalDetails object saved to the database.</returns>
        private int SavePersonalDetails(int saleID)
        {
            int output = PersonalDetails.SavePersonalDetails
                         (
                             saleID,
                             cmbTitle.SelectedValue,
                             String.Empty,
                             txtFirstname.Text,
                             String.Empty,
                             txtSurname.Text,
                             txtIdNumber.Text,
                             txtPassportNumber.Text,
                             DateTime.Parse(txtDateOfBirth.Text),
                             txtTelWork.Text,
                             txtTelCell.Text,
                             txtTelHome.Text,
                             String.Empty,
                             cmbGender.SelectedValue,
                             txtPostalAddress1.Text,
                             txtPostalAddress2.Text,
                             txtPostalAddress3.Text,
                             cmbProvince.SelectedValue,
                             txtCity.Text,
                             txtPostalCode.Text,
                             txtEmail.Text,
                             0
                         );

            return output;
        }

        /// <summary>
        /// Saves a Sales object to the database.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing an existing sale ID, or a 0 for a new sale.</param>
        /// <param name="ws">A <see cref="WorkflowStep"/> object containing the data for the "Pre-Vet" status (usually)</param>
        /// <param name="currentUser">A <see cref="Users"/> object containing the current user's data.</param>
        /// <returns>An <see cref="int"/> value containing the actual Sale ID.</returns>
        private int SaveSale(int saleID, WorkflowStep ws, Users currentUser)
        {
            int output = Sales.SaveSale
                         (
                             saleID,
                             currentUser.ID,
                             currentUser.ADUserName,
                             DateTime.Now,
                             ws.WorkflowID,
                             ws.StepName,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             String.Empty,
                             Convert.ToInt32(cmbCallLanguage.SelectedValue)
                         );

            return output;
        }

        /// <summary>
        /// Saves a SaleDetails object's values to the database.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID.</param>
        /// <param name="currentUser">A <see cref="Users"/> object containing the submitting user's data</param>
        /// <returns>An <see cref="int"/> value containing the SaleDetails database ID.</returns>
        private void SaveSaleDetails(int salesDetailsID, Users currentUser)
        {
            RC.SaleDetailsRCABSA4.UpdateSaleDetail
            (
                salesDetailsID,
                (decimal)49.00,
                Convert.ToInt32(cmbBankName.SelectedValue),
                Convert.ToInt32(cmbTitle.SelectedValue),
                Convert.ToInt32(cmbProvince.SelectedValue),
                "Member",
                hidRoadCoverLeadID.Value,
                hidConsFileNumber.Value,
                hidMemberNumber.Value,
                String.Empty,
                String.Empty, // VehicleDetail1
                String.Empty, // VehicleDetail2
                String.Empty, // VehicleDetail3
                String.Empty, // VehicleDetail4
                String.Empty, // VehicleDetail5
                String.Empty, // Product1 
                String.Empty, // Product2
                String.Empty, // Product3
                String.Empty, // Product4
                String.Empty, // Product5
                null, // Date1 
                null, // Date2 
                null, // Date3 
                null, // Date4 
                null, // Date5
                hidAllocatedTo.Value,
                null, // Date Allocated
                String.Empty, // AssetShortDescription
                null, // DateExpiry
                null, //DateFirstLicensed,
                String.Empty, // Make Description
                String.Empty, // RegistrationNum
                DebitOrderDay.Text,
                cmbDisposition.SelectedItem.Text,
                DateTime.Now,
                currentUser.ID.ToString(),
                Convert.ToInt32(cmbProduct.SelectedValue)
            );
        }

        /// <summary>
        /// Formats the bank account number related to a passed Sale ID.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value representing the sale ID to process.</param>
        /// <returns>A <see cref="long"/> value containing the formatted account number.</returns>
        private long FormatBankAccountNumber(int saleID)
        {
            long bankAccountNumber = 0;

            //if it contains X's we assume the account number has not been altered. - deal with it.
            if (txtBankAccountNumber.Text.IndexOf("X") >= 0)
            {
                BankDetails bank = BankDetails.GetBankDetails(saleID);
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

            return bankAccountNumber;
        }

        /// <summary>
        /// Calculates a debit date, formats the sale bank account number, 
        /// and saves a BankDetails object's data to the database.
        /// </summary>
        /// <param name="saleID">An <see cref="int"/> value containing the sale ID to process.</param>
        /// <returns>An <see cref="int"/> value containing the unique database ID of the saved BankDetails object.</returns>
        private int SaveBankDetails(int saleID)
        {
            int output = 0;

            DateTime debitDate = Convert.ToDateTime(DebitOrderDay.Text);
            long bankAccountNumber = FormatBankAccountNumber(saleID);
            output = BankDetails.SaveBankDetails(bankAccountNumber, txtBankAccountHolder.Text, cmbBankName.SelectedValue, "", "", debitDate.Month, debitDate.Day, "Primary", saleID);

            return output;
        }

        #endregion

        #region WebMethods

        /// <summary>
        /// Test WebMethod. Will return Hello World to the caller if things are set up properly.
        /// </summary>
        /// <returns>A <see cref="string"/> value containing "Hello World!"</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string HelloWorld()
        {
            return "Hello World!";
        }

        /// <summary>
        /// A WebMethod that attempts to send a RoadCover OnePager.
        /// Invoked by an AJAX call on the client that passes client name, and email address.
        /// </summary>
        /// <param name="name">A <see cref="string"/> value containing the name of the customer being sent the one-pager.</param>
        /// <param name="emailAddress">a <see cref="string"/> value containing the email address to use for the customer</param>
        /// <returns>A <see cref="string"/> containing either "Mail Sent." for successful sending, or an exception message.</returns>
        [WebMethod]
        public static string SendOnePager(string name, string emailAddress)
        {
            string output = String.Empty;

            try
            {
                TP.ITemplateBuilder absaOnePager = new TemplateProcessor.RCABSAOnePagerTemplate();
                TP.TemplateDirector director = new TP.TemplateDirector(absaOnePager);
                director.BuildTemplate();
                TP.Template template = director.GetTemplate();

                string pathToAttachment = HttpContext.Current.Server.MapPath("~/TemplateProcessor/EmailTemplates/RoadCover/Absa/ABSARoadCoverBrochure.pdf");

                Email mail = new Email("RCABSA4OnePager", $"RoadCover Information - { name }", template.GetAlternativeViewForMail(), emailAddress, pathToAttachment);
                mail.SendMail();

                output = "Mail Sent.";
            }
            catch (Exception ex)
            {
                output = ex.ToString();
            }

            return output;
        }

        #endregion
    }
}