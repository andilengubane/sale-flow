using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using BusinessLogic;

namespace wwwSalesFlow.campaignsForms
{
    public partial class FNBFUN4 : System.Web.UI.Page
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


                #region Relationship(s)
                //Load Child Relationship Types:

                List<CampaignRelationshipType> relTypes = CampaignRelationshipType.GetRelationshipTypes((int)ViewState["CampaignID"]);
                cmbChildRelationship1.DataSource = relTypes;
                cmbChildRelationship1.DataTextField = "Title";
                cmbChildRelationship1.DataValueField = "RelationshipTypeID";
                cmbChildRelationship1.DataBind();

                cmbChildRelationship2.DataSource = relTypes;
                cmbChildRelationship2.DataTextField = "Title";
                cmbChildRelationship2.DataValueField = "RelationshipTypeID";
                cmbChildRelationship2.DataBind();

                cmbChildRelationship3.DataSource = relTypes;
                cmbChildRelationship3.DataTextField = "Title";
                cmbChildRelationship3.DataValueField = "RelationshipTypeID";
                cmbChildRelationship3.DataBind();

                cmbChildRelationship4.DataSource = relTypes;
                cmbChildRelationship4.DataTextField = "Title";
                cmbChildRelationship4.DataValueField = "RelationshipTypeID";
                cmbChildRelationship4.DataBind();

                cmbChildRelationship5.DataSource = relTypes;
                cmbChildRelationship5.DataTextField = "Title";
                cmbChildRelationship5.DataValueField = "RelationshipTypeID";
                cmbChildRelationship5.DataBind();

                cmbChildRelationship6.DataSource = relTypes;
                cmbChildRelationship6.DataTextField = "Title";
                cmbChildRelationship6.DataValueField = "RelationshipTypeID";
                cmbChildRelationship6.DataBind();

                cmbChildRelationship7.DataSource = relTypes;
                cmbChildRelationship7.DataTextField = "Title";
                cmbChildRelationship7.DataValueField = "RelationshipTypeID";
                cmbChildRelationship7.DataBind();

                cmbChildRelationship8.DataSource = relTypes;
                cmbChildRelationship8.DataTextField = "Title";
                cmbChildRelationship8.DataValueField = "RelationshipTypeID";
                cmbChildRelationship8.DataBind();

                //Load Ext Fam Relationship Types:
                List<CampaignRelationshipType> extrelTypes = CampaignRelationshipType.GetRelationshipTypes((int)ViewState["CampaignID"]);
                cmbExtFamRelationship1.DataSource = extrelTypes;
                cmbExtFamRelationship1.DataTextField = "Title";
                cmbExtFamRelationship1.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship1.DataBind();

                cmbExtFamRelationship2.DataSource = extrelTypes;
                cmbExtFamRelationship2.DataTextField = "Title";
                cmbExtFamRelationship2.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship2.DataBind();

                cmbExtFamRelationship3.DataSource = extrelTypes;
                cmbExtFamRelationship3.DataTextField = "Title";
                cmbExtFamRelationship3.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship3.DataBind();

                cmbExtFamRelationship4.DataSource = extrelTypes;
                cmbExtFamRelationship4.DataTextField = "Title";
                cmbExtFamRelationship4.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship4.DataBind();

                cmbExtFamRelationship5.DataSource = extrelTypes;
                cmbExtFamRelationship5.DataTextField = "Title";
                cmbExtFamRelationship5.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship5.DataBind();

                cmbExtFamRelationship5.DataSource = extrelTypes;
                cmbExtFamRelationship5.DataTextField = "Title";
                cmbExtFamRelationship5.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship5.DataBind();

                cmbExtFamRelationship6.DataSource = extrelTypes;
                cmbExtFamRelationship6.DataTextField = "Title";
                cmbExtFamRelationship6.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship6.DataBind();

                cmbExtFamRelationship7.DataSource = extrelTypes;
                cmbExtFamRelationship7.DataTextField = "Title";
                cmbExtFamRelationship7.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship7.DataBind();

                cmbExtFamRelationship8.DataSource = extrelTypes;
                cmbExtFamRelationship8.DataTextField = "Title";
                cmbExtFamRelationship8.DataValueField = "RelationshipTypeID";
                cmbExtFamRelationship8.DataBind();

                //Load Parents Relationship Types:

                cmbParentRelationship1.DataSource = relTypes;
                cmbParentRelationship1.DataTextField = "Title";
                cmbParentRelationship1.DataValueField = "RelationshipTypeID";
                cmbParentRelationship1.DataBind();

                cmbParentRelationship2.DataSource = relTypes;
                cmbParentRelationship2.DataTextField = "Title";
                cmbParentRelationship2.DataValueField = "RelationshipTypeID";
                cmbParentRelationship2.DataBind();

                cmbParentRelationship3.DataSource = relTypes;
                cmbParentRelationship3.DataTextField = "Title";
                cmbParentRelationship3.DataValueField = "RelationshipTypeID";
                cmbParentRelationship3.DataBind();

                cmbParentRelationship4.DataSource = relTypes;
                cmbParentRelationship4.DataTextField = "Title";
                cmbParentRelationship4.DataValueField = "RelationshipTypeID";
                cmbParentRelationship4.DataBind();

                relTypes = null;
                #endregion

                #region Gender(s)

                //-- Main Member--\\
                cmbGender.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbGender.DataValueField = "Value";
                cmbGender.DataTextField = "Key";
                cmbGender.DataBind();

                //-- Spouse--\\
                cmbSpouseGender.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbSpouseGender.DataValueField = "Value";
                cmbSpouseGender.DataTextField = "Key";
                cmbSpouseGender.DataBind();

                //-- Riders X 5 --\\
                cmbChildGender1.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender1.DataValueField = "Value";
                cmbChildGender1.DataTextField = "Key";
                cmbChildGender1.DataBind();

                cmbChildGender2.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender2.DataValueField = "Value";
                cmbChildGender2.DataTextField = "Key";
                cmbChildGender2.DataBind();

                cmbChildGender3.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender3.DataValueField = "Value";
                cmbChildGender3.DataTextField = "Key";
                cmbChildGender3.DataBind();

                cmbChildGender4.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender4.DataValueField = "Value";
                cmbChildGender4.DataTextField = "Key";
                cmbChildGender4.DataBind();

                cmbChildGender5.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender5.DataValueField = "Value";
                cmbChildGender5.DataTextField = "Key";
                cmbChildGender5.DataBind();

                cmbChildGender6.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender6.DataValueField = "Value";
                cmbChildGender6.DataTextField = "Key";
                cmbChildGender6.DataBind();

                cmbChildGender7.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender7.DataValueField = "Value";
                cmbChildGender7.DataTextField = "Key";
                cmbChildGender7.DataBind();

                cmbChildGender8.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbChildGender8.DataValueField = "Value";
                cmbChildGender8.DataTextField = "Key";
                cmbChildGender8.DataBind();

                //-- Ext Family Riders --\\
                cmbExtFamGender1.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender1.DataValueField = "Value";
                cmbExtFamGender1.DataTextField = "Key";
                cmbExtFamGender1.DataBind();

                cmbExtFamGender2.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender2.DataValueField = "Value";
                cmbExtFamGender2.DataTextField = "Key";
                cmbExtFamGender2.DataBind();

                cmbExtFamGender3.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender3.DataValueField = "Value";
                cmbExtFamGender3.DataTextField = "Key";
                cmbExtFamGender3.DataBind();

                cmbExtFamGender4.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender4.DataValueField = "Value";
                cmbExtFamGender4.DataTextField = "Key";
                cmbExtFamGender4.DataBind();

                cmbExtFamGender5.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender5.DataValueField = "Value";
                cmbExtFamGender5.DataTextField = "Key";
                cmbExtFamGender5.DataBind();

                cmbExtFamGender5.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender5.DataValueField = "Value";
                cmbExtFamGender5.DataTextField = "Key";
                cmbExtFamGender5.DataBind();

                cmbExtFamGender6.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender6.DataValueField = "Value";
                cmbExtFamGender6.DataTextField = "Key";
                cmbExtFamGender6.DataBind();

                cmbExtFamGender7.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender7.DataValueField = "Value";
                cmbExtFamGender7.DataTextField = "Key";
                cmbExtFamGender7.DataBind();

                cmbExtFamGender8.DataSource = BusinessLogic.CommonLists.GetGender();
                cmbExtFamGender8.DataValueField = "Value";
                cmbExtFamGender8.DataTextField = "Key";
                cmbExtFamGender8.DataBind();

                #endregion

                #region Title(s)
                cmbTitle.DataSource = BusinessLogic.CommonLists.GetTitle();
                cmbTitle.DataValueField = "Value";
                cmbTitle.DataTextField = "Key";
                cmbTitle.DataBind();

                cmbSpouseTitle.DataSource = BusinessLogic.CommonLists.GetTitle();
                cmbSpouseTitle.DataValueField = "Value";
                cmbSpouseTitle.DataTextField = "Key";
                cmbSpouseTitle.DataBind();
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
                                LoadSubmemberDetails(sal.ID);
                                loadSaleHistory(sal.ID);
                                LoadCampaignBenefits(sal.CampaignID);
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
                            LoadSubmemberDetails(sal.ID);
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

                LoadBundleTypes();

                // do an example request call here
                //FNB_FUN4.ExportPassthroughWSClient wsClient = new FNB_FUN4.ExportPassthroughWSClient();
                //var state = wsClient.State;
                //var state = wsClient.RequestQuoteAsync
                //string requestXML = MakeRequestXML();
               
                //var xmlResponse = wsClient.RequestQuote(requestXML);

            }
        }
        private static string MakeRequestXML(string refNumber, string relType, string dob, string coverAmount)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\" ?>");
            xml.AppendLine("<REQUEST>");
            xml.AppendLine("<COMMONDATA>");

            xml.AppendLine(new XElement("ACTION", "3").ToString());
            xml.AppendLine(new XElement("TIMESTAMP", DateTime.Now).ToString());
            xml.AppendLine(new XElement("REFNUMBER", refNumber).ToString());
            xml.AppendLine(new XElement("PRODUCTCODE", "FIS").ToString());
            xml.AppendLine(new XElement("SUBPRODCODE", "FI").ToString());
            xml.AppendLine(new XElement("CHANNELID", "BPS").ToString());
            xml.AppendLine("</COMMONDATA>");

            xml.AppendLine("<POLICYDATA>");
            xml.AppendLine(new XElement("POLICYNO", "").ToString());
            xml.AppendLine("</POLICYDATA>");

            xml.AppendLine("<MEMBERDATA>");
            xml.AppendLine(new XElement("RELACT", "AD").ToString());
            xml.AppendLine(new XElement("RELATIONSHIP", relType).ToString());
            xml.AppendLine(new XElement("DOB", dob).ToString());
            xml.AppendLine(new XElement("COVERAMOUNT", coverAmount).ToString());
            xml.AppendLine(new XElement("SEQ", "").ToString());
            xml.AppendLine("</MEMBERDATA>");

            xml.AppendLine("</REQUEST>");
            return xml.ToString();
        }
        private static string ValidateGroupResults(string premiumResult)
        {
            string premiumAmount = "";
            try
            {
                XmlDocument theDoc = new XmlDocument();
                theDoc.LoadXml(premiumResult.ToLower());
                XmlNodeList theNode = theDoc.SelectNodes("response/commondata/resultmsg");
                if (theNode.Count > 0)
                {
                    if (theNode[0].InnerText == "successful")
                    {                   
                        premiumAmount = theDoc.SelectSingleNode("/response/pricingdetails/premiumamount").InnerText;
                    }
                    else
                    {
                        premiumAmount = "'Failed to fetch premium from FNB.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return premiumAmount;
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

            cmbSpouseBenefit.DataTextField = "BenefitAmount";
            cmbSpouseBenefit.DataValueField = "CampaignBenefitsID";
            cmbSpouseBenefit.DataSource = lstBenefits;
            cmbSpouseBenefit.DataBind();
        }
        private void LoadBundleTypes()
        {
            List<BusinessLogic.Campaigns.FNB.FNBBundleType> lstBundleTypes = BusinessLogic.Campaigns.FNB.FNBBundleType.GetAllFNBBundleTypes();
            BusinessLogic.Campaigns.FNB.FNBBundleType dummyBundleTypes = new BusinessLogic.Campaigns.FNB.FNBBundleType();
            dummyBundleTypes.Title = "[ Please Select ]";
            dummyBundleTypes.FNBBundleTypeID = -1;
            lstBundleTypes.Insert(0, dummyBundleTypes);
            cmbBundleType.DataTextField = "Title";
            cmbBundleType.DataValueField = "FNBBundleTypeID";
            cmbBundleType.DataSource = lstBundleTypes;
            cmbBundleType.DataBind();
        }
        private void LoadRelationshipTypes(int CampaignID)
        {
            List<RelationshipType> lstBenefits = RelationshipType.GetRelationshipTypeList();
            RelationshipType dummyBenefit = new RelationshipType();
            dummyBenefit.Title = "[ Select Relationship ]";
            dummyBenefit.RelationshipTypeID = -1;
            lstBenefits.Insert(0, dummyBenefit);

            /////////////////// CHILD //////////////////////
            cmbChildRelationship1.DataTextField = "Title";
            cmbChildRelationship1.DataValueField = "RelationshipTypeID";
            cmbChildRelationship1.DataSource = lstBenefits;
            cmbChildRelationship1.DataBind();

            cmbChildRelationship2.DataTextField = "Title";
            cmbChildRelationship2.DataValueField = "RelationshipTypeID";
            cmbChildRelationship2.DataSource = lstBenefits;
            cmbChildRelationship2.DataBind();

            cmbChildRelationship3.DataTextField = "Title";
            cmbChildRelationship3.DataValueField = "RelationshipTypeID";
            cmbChildRelationship3.DataSource = lstBenefits;
            cmbChildRelationship3.DataBind();

            cmbChildRelationship4.DataTextField = "Title";
            cmbChildRelationship4.DataValueField = "RelationshipTypeID";
            cmbChildRelationship4.DataSource = lstBenefits;
            cmbChildRelationship4.DataBind();

            cmbChildRelationship5.DataTextField = "Title";
            cmbChildRelationship5.DataValueField = "RelationshipTypeID";
            cmbChildRelationship5.DataSource = lstBenefits;
            cmbChildRelationship5.DataBind();

            cmbChildRelationship6.DataTextField = "Title";
            cmbChildRelationship6.DataValueField = "RelationshipTypeID";
            cmbChildRelationship6.DataSource = lstBenefits;
            cmbChildRelationship6.DataBind();

            cmbChildRelationship7.DataTextField = "Title";
            cmbChildRelationship7.DataValueField = "RelationshipTypeID";
            cmbChildRelationship7.DataSource = lstBenefits;
            cmbChildRelationship7.DataBind();

            cmbChildRelationship8.DataTextField = "Title";
            cmbChildRelationship8.DataValueField = "RelationshipTypeID";
            cmbChildRelationship8.DataSource = lstBenefits;
            cmbChildRelationship8.DataBind();

            /////////////////// EXT FAM ///////////////////////////////////
            cmbExtFamRelationship1.DataTextField = "Title";
            cmbExtFamRelationship1.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship1.DataSource = lstBenefits;
            cmbExtFamRelationship1.DataBind();

            cmbExtFamRelationship2.DataTextField = "Title";
            cmbExtFamRelationship2.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship2.DataSource = lstBenefits;
            cmbExtFamRelationship2.DataBind();

            cmbExtFamRelationship3.DataTextField = "Title";
            cmbExtFamRelationship3.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship3.DataSource = lstBenefits;
            cmbExtFamRelationship3.DataBind();

            cmbExtFamRelationship4.DataTextField = "Title";
            cmbExtFamRelationship4.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship4.DataSource = lstBenefits;
            cmbExtFamRelationship4.DataBind();

            cmbExtFamRelationship5.DataTextField = "Title";
            cmbExtFamRelationship5.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship5.DataSource = lstBenefits;
            cmbExtFamRelationship5.DataBind();

            cmbExtFamRelationship6.DataTextField = "Title";
            cmbExtFamRelationship6.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship6.DataSource = lstBenefits;
            cmbExtFamRelationship6.DataBind();

            cmbExtFamRelationship7.DataTextField = "Title";
            cmbExtFamRelationship7.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship7.DataSource = lstBenefits;
            cmbExtFamRelationship7.DataBind();
            
            cmbExtFamRelationship8.DataTextField = "Title";
            cmbExtFamRelationship8.DataValueField = "RelationshipTypeID";
            cmbExtFamRelationship8.DataSource = lstBenefits;
            cmbExtFamRelationship8.DataBind();

            //////////////////// PARENT /////////////
            cmbParentRelationship1.DataTextField = "Title";
            cmbParentRelationship1.DataValueField = "RelationshipTypeID";
            cmbParentRelationship1.DataSource = lstBenefits;
            cmbParentRelationship1.DataBind();

            cmbParentRelationship2.DataTextField = "Title";
            cmbParentRelationship2.DataValueField = "RelationshipTypeID";
            cmbParentRelationship2.DataSource = lstBenefits;
            cmbParentRelationship2.DataBind();

            cmbParentRelationship3.DataTextField = "Title";
            cmbParentRelationship3.DataValueField = "RelationshipTypeID";
            cmbParentRelationship3.DataSource = lstBenefits;
            cmbParentRelationship3.DataBind();

            cmbParentRelationship4.DataTextField = "Title";
            cmbParentRelationship4.DataValueField = "RelationshipTypeID";
            cmbParentRelationship4.DataSource = lstBenefits;
            cmbParentRelationship4.DataBind();
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
            //GET Child: SubmemberType ID = 1
            List<SubMemberDetails> childMembers = SubMemberDetails.GetSubMembers(saleID, 5);
            for (int i = 0; i < childMembers.Count; i++)
            {
                int idx = i + 1;

                if (idx > 8) break;
                ((CheckBox)mvMain.FindControl("chkChild" + idx.ToString())).Checked = true;

                ((TextBox)mvMain.FindControl("txtChildDateOfBirth" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtChildName" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtChildSurname" + idx.ToString())).Enabled = true;
                ((DropDownList)mvMain.FindControl("cmbChildRelationship" + idx.ToString())).Enabled = true;


                ((TextBox)mvMain.FindControl("txtChildDateOfBirth" + idx.ToString())).Text = childMembers[i].DateOfBirth.ToString("yyyy-MM-dd");
                ((TextBox)mvMain.FindControl("txtChildName" + idx.ToString())).Text = childMembers[i].FirstName;
                ((TextBox)mvMain.FindControl("txtChildSurname" + idx.ToString())).Text = childMembers[i].Surname;
                ((DropDownList)mvMain.FindControl("cmbChildRelationship" + idx.ToString())).SelectedValue = childMembers[i].RelationshipTypeID.ToString();
            }
            childMembers = null;

            //GET Ext Family Rider: SubmemberType ID = 4
            List<SubMemberDetails> familySubMembers = SubMemberDetails.GetSubMembers(saleID, 4);
            for (int i = 0; i < familySubMembers.Count; i++)
            {
                int idx = i + 1;

                if (idx > 8) break;
                ((CheckBox)mvMain.FindControl("chkExtFam" + idx.ToString())).Checked = true;

                ((TextBox)mvMain.FindControl("txtExtFamSurname" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtExtFamName" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtExtFamDateOfBirth" + idx.ToString())).Enabled = true;
                ((DropDownList)mvMain.FindControl("cmbExtFamRelationship" + idx.ToString())).Enabled = true;

                ((TextBox)mvMain.FindControl("txtExtFamSurname" + idx.ToString())).Text = familySubMembers[i].Surname;
                ((TextBox)mvMain.FindControl("txtExtFamName" + idx.ToString())).Text = familySubMembers[i].FirstName;
                ((TextBox)mvMain.FindControl("txtExtFamDateOfBirth" + idx.ToString())).Text = familySubMembers[i].DateOfBirth.ToString("yyyy-MM-dd");
                ((DropDownList)mvMain.FindControl("cmbExtFamRelationship" + idx.ToString())).SelectedValue = familySubMembers[i].RelationshipTypeID.ToString();
            }
            familySubMembers = null;

            //GET Parent Rider: SubmemberType ID = 6
            List<SubMemberDetails> parentSubMembers = SubMemberDetails.GetSubMembers(saleID, 6);
            for (int i = 0; i < parentSubMembers.Count; i++)
            {
                int idx = i + 1;

                if (idx > 4) break;
                ((CheckBox)mvMain.FindControl("chkParent" + idx.ToString())).Checked = true;

                ((TextBox)mvMain.FindControl("txtParentSurname" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtParentName" + idx.ToString())).Enabled = true;
                ((TextBox)mvMain.FindControl("txtParentDateOfBirth" + idx.ToString())).Enabled = true;
                ((DropDownList)mvMain.FindControl("cmbParentRelationship" + idx.ToString())).Enabled = true;

                ((TextBox)mvMain.FindControl("txtParentSurname" + idx.ToString())).Text = parentSubMembers[i].Surname;
                ((TextBox)mvMain.FindControl("txtParentName" + idx.ToString())).Text = parentSubMembers[i].FirstName;
                ((TextBox)mvMain.FindControl("txtParentDateOfBirth" + idx.ToString())).Text = parentSubMembers[i].DateOfBirth.ToString("yyyy-MM-dd");
                ((DropDownList)mvMain.FindControl("cmbParentRelationship" + idx.ToString())).SelectedValue = parentSubMembers[i].RelationshipTypeID.ToString();
            }
            parentSubMembers = null;
        }

        private void LoadBankDetails(int saleID)
        {
            BankDetails bank = BankDetails.GetBankDetails(saleID);
            if (bank.Found)
            {
                txtBankAccountNumber.Text = BusinessLogic.Validators.MaskBankDetails(bank.AccountNumber);

                //txtBankName.Text = bank.BankName;
                //txtBankAccountHolder.Text = bank.AccountName;
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
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, "", txtFirstname.Text, txtSecondName.Text, txtSurname.Text, txtIdNumber.Text, txtPassportNumber.Text, DateTime.Parse(txtDateOfBirth.Text), txtTelWork.Text, txtTelCell.Text, "", "", cmbGender.SelectedValue, txtPostalAddress1.Text, txtPostalAddress2.Text, txtSurburb.Text, "", "", txtPostalCode.Text, txtEMail.Text, 0);

                                //Save SubMembers Riders...
                                int submemberID = SubMemberType.GetSubMemberType("Child").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 9; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkChild" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtChildSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtChildName" + i.ToString())).Text;
                                        string secondName = ((TextBox)mvMain.FindControl("txtChildSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbChildGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtChildIdNumber" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtChildDateOfBirth" + i.ToString())).Text);
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbChildRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
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
                                for (int i = 1; i < 9; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkExtFam" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtExtFamSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtExtFamName" + i.ToString())).Text;
                                        string secondName = ((TextBox)mvMain.FindControl("txtExtFamSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbExtFamGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtExtFamIdNumber" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtExtFamDateOfBirth" + i.ToString())).Text);
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbExtFamRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
                                        if (newID > 0)
                                        {
                                            savedFamilyRiderCount += 1;
                                        }
                                    }
                                }

                                //Save SubMembers Parents...
                                submemberID = SubMemberType.GetSubMemberType("Parent").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 5; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkParent" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtParentSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtParentName" + i.ToString())).Text;
                                        string secondName = ((TextBox)mvMain.FindControl("txtParentSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbParentGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtParentIdNumber" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtParentDateOfBirth" + i.ToString())).Text);
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbParentRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
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
            ((TextBox)mvMain.FindControl("txtChildSurname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtChildName" + idx.ToString())).Enabled = enabled;
            //((TextBox)mvMain.FindControl("txtChildSecondName" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbChildGender" + idx.ToString())).Enabled = enabled;
           // ((TextBox)mvMain.FindControl("txtChildIdNumber" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtChildDateOfBirth" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbChildRelationship" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbChildBenefitAmount" + idx.ToString())).Enabled = enabled;
        }

        private void EnableDisableFamilyRider(int idx, bool enabled)
        {
            ((TextBox)mvMain.FindControl("txtExtFamSurname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtExtFamName" + idx.ToString())).Enabled = enabled;
            //((TextBox)mvMain.FindControl("txtExtFamSecondName" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbExtFamGender" + idx.ToString())).Enabled = enabled;
            //((TextBox)mvMain.FindControl("txtExtFamIdNumber" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtExtFamDateOfBirth" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbExtFamRelationship" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbExtFamBenefitAmount" + idx.ToString())).Enabled = enabled;
        }
        private void EnableDisableParentRider(int idx, bool enabled)
        {
            ((TextBox)mvMain.FindControl("txtParentSurname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtParentName" + idx.ToString())).Enabled = enabled;
            //((TextBox)mvMain.FindControl("txtParentSecondName" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbParentGender" + idx.ToString())).Enabled = enabled;
            //((TextBox)mvMain.FindControl("txtParentIdNumber" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtParentDateOfBirth" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbParentRelationship" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbParentBenefitAmount" + idx.ToString())).Enabled = enabled;
        }
        protected void chkChild1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(1, chkChild1.Checked);
        }
        protected void chkChild2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(2, chkChild2.Checked);
        }

        protected void chkChild3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(3, chkChild3.Checked);
        }

        protected void chkChild4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(4, chkChild4.Checked);
        }

        protected void chkChild5_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(5, chkChild5.Checked);
        }
        protected void chkChild6_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(6, chkChild6.Checked);
        }
        protected void chkChild7_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(7, chkChild7.Checked);
        }
        protected void chkChild8_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableRider(8, chkChild8.Checked);
        }

        protected void chkExtFam1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(1, chkExtFam1.Checked);
        }

        protected void chkExtFam2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(2, chkExtFam2.Checked);
        }

        protected void chkExtFam3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(3, chkExtFam3.Checked);
        }

        protected void chkExtFam4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(4, chkExtFam4.Checked);
        }

        protected void chkExtFam5_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(5, chkExtFam5.Checked);
        }
        protected void chkExtFam6_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(6, chkExtFam6.Checked);
        }
        protected void chkExtFam7_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(7, chkExtFam7.Checked);
        }
        protected void chkExtFam8_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableFamilyRider(8, chkExtFam8.Checked);
        }
        protected void chkParent1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableParentRider(1, chkParent1.Checked);
        }
        protected void chkParent2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableParentRider(2, chkParent2.Checked);
        }
        protected void chkParent3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableParentRider(3, chkParent3.Checked);
        }
        protected void chkParent4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableParentRider(4, chkParent4.Checked);
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
                                int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, "", txtFirstname.Text, txtSecondName.Text, txtSurname.Text, txtIdNumber.Text, txtPassportNumber.Text, DateTime.Parse(txtDateOfBirth.Text), txtTelWork.Text, txtTelCell.Text, "", "", cmbGender.SelectedValue, txtPostalAddress1.Text, txtPostalAddress2.Text, txtSurburb.Text, "", "", txtPostalCode.Text, txtEMail.Text, 0);

                                //Save SubMembers Riders...
                                int submemberID = SubMemberType.GetSubMemberType("Child").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 9; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkChild" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtChildSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtChildName" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtChildDateOfBirth" + i.ToString())).Text);
                                        string secondName = ((TextBox)mvMain.FindControl("txtChildSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbChildGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtChildIdNumber" + i.ToString())).Text;
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbChildRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
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
                                for (int i = 1; i < 9; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkExtFam" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtExtFamSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtExtFamName" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtExtFamDateOfBirth" + i.ToString())).Text);
                                        string secondName = ((TextBox)mvMain.FindControl("txtExtFamSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbExtFamGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtExtFamIdNumber" + i.ToString())).Text;
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbExtFamRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
                                        if (newID > 0)
                                        {
                                            savedFamilyRiderCount += 1;
                                        }
                                    }
                                }

                                //Save SubMembers Parent Riders...
                                submemberID = SubMemberType.GetSubMemberType("Parent").SubMemberTypeID;
                                //-- flush before save --\\
                                SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
                                //--loop through all ticked tickboxes and save --\\
                                for (int i = 1; i < 5; i++)
                                {
                                    if (((CheckBox)mvMain.FindControl("chkParent" + i.ToString())).Checked)
                                    {
                                        string surname = ((TextBox)mvMain.FindControl("txtParentSurname" + i.ToString())).Text;
                                        string firstName = ((TextBox)mvMain.FindControl("txtParentName" + i.ToString())).Text;
                                        DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtParentDateOfBirth" + i.ToString())).Text);
                                        string secondName = ((TextBox)mvMain.FindControl("txtParentSecondName" + i.ToString())).Text;
                                        string gender = ((DropDownList)mvMain.FindControl("cmbParentGender" + i.ToString())).SelectedValue;
                                        //string idNumber = ((TextBox)mvMain.FindControl("txtParentIdNumber" + i.ToString())).Text;
                                        int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbParentRelationship" + i.ToString())).SelectedValue);

                                        int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, "", dateOfBirth, relationID);
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
            // check the value of the benefit if benefit > 70k then call the FNB web service
            decimal benefitAmount = CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).BenefitAmount;
            DateTime dob = Convert.ToDateTime(txtDateOfBirth.Text);
            string phDOB = dob.ToShortDateString().Replace(@"/", ""); 

            if (benefitAmount >= Convert.ToDecimal(70000.00))
            {                
                FNB_FUN4.ExportPassthroughWSClient wsClient = new FNB_FUN4.ExportPassthroughWSClient();
                string requestXML = MakeRequestXML("0001", "PH", phDOB, benefitAmount.ToString());

                string premiumAmount = ValidateGroupResults(wsClient.RequestQuote(requestXML));
                lblPremiumAmount.Visible = true;
                lblPremiumAmount.Text = "Premium is R" + premiumAmount;
                lblPremiumAmount.Font.Bold = true;
                lblPremiumAmount.ForeColor = System.Drawing.Color.Green;
                hiddenPremiumAmount.Value = premiumAmount.Replace(".", ",");
            }
            else
            {
                // go check against the DB
                lblPremiumAmount.Visible = true;
                lblPremiumAmount.Text = "Premium is R" + CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
                lblPremiumAmount.Font.Bold = true;
                lblPremiumAmount.ForeColor = System.Drawing.Color.Green;
                hiddenPremiumAmount.Value = CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
            }

        }
        protected void cmbSpouseBenefit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check the value of the benefit if benefit > 70k then call the FNB web service
            decimal benefitAmount = CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbSpouseBenefit.SelectedValue)).BenefitAmount;
            DateTime dob = Convert.ToDateTime(txtSpouseDateOfBirth.Text);
            string spDOB = dob.ToShortDateString().Replace(@"/", "");

            if (benefitAmount >= Convert.ToDecimal(70000.00))
            {
                FNB_FUN4.ExportPassthroughWSClient wsClient = new FNB_FUN4.ExportPassthroughWSClient();
                string requestXML = MakeRequestXML("0001", "SP", spDOB, benefitAmount.ToString());

                string premiumAmount = ValidateGroupResults(wsClient.RequestQuote(requestXML));
                lblSpousePremiumAmount.Visible = true;
                lblSpousePremiumAmount.Text = "Premium is R" + premiumAmount;
                lblSpousePremiumAmount.Font.Bold = true;
                lblSpousePremiumAmount.ForeColor = System.Drawing.Color.Green;
                hiddenSpousePremiumAmount.Value = Convert.ToDecimal(premiumAmount).ToString();
            }
            else
            {
                lblSpousePremiumAmount.Visible = true;
                lblSpousePremiumAmount.Text = "Premium is R" + BusinessLogic.Campaigns.FNB.CampaignBenefitsFNB.GetBenefitAmount(Convert.ToInt32(cmbSpouseBenefit.SelectedValue)).PremiumAmount.ToString();
                lblSpousePremiumAmount.Font.Bold = true;
                lblSpousePremiumAmount.ForeColor = System.Drawing.Color.Green;
                hiddenSpousePremiumAmount.Value = BusinessLogic.Campaigns.FNB.CampaignBenefitsFNB.GetBenefitAmount(Convert.ToInt32(cmbSpouseBenefit.SelectedValue)).PremiumAmount.ToString();
            }
        }
        protected void cmbChildRelationship1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth1.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth1.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship1.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount1.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount1.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount1.DataSource = lstBenefits;
                cmbChildBenefitAmount1.DataBind();

                DateTime DOB1 = Convert.ToDateTime(txtChildDateOfBirth1.Text);
                int years = DateTime.Now.Year - DOB1.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship1.SelectedValue));
                cmbChildBenefitAmount1.Enabled = true;
                lblChildPremiumAmount1.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount1.Enabled = false;
                        lblChildPremiumAmount1.Visible = true;
                        lblChildPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship1.SelectedItem.Text;
                        lblChildPremiumAmount1.Font.Bold = true;
                        lblChildPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth1.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount1.Enabled = false;
                        lblChildPremiumAmount1.Visible = true;
                        lblChildPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship1.SelectedItem.Text;
                        lblChildPremiumAmount1.Font.Bold = true;
                        lblChildPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth1.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount1.Visible = true;
            lblChildPremiumAmount1.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount1.Font.Bold = true;
            lblChildPremiumAmount1.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount1.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth2.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth2.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship2.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount2.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount2.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount2.DataSource = lstBenefits;
                cmbChildBenefitAmount2.DataBind();

                DateTime DOB2 = Convert.ToDateTime(txtChildDateOfBirth2.Text);
                int years = DateTime.Now.Year - DOB2.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship2.SelectedValue));
                cmbChildBenefitAmount2.Enabled = true;
                lblChildPremiumAmount2.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount2.Enabled = false;
                        lblChildPremiumAmount2.Visible = true;
                        lblChildPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship2.SelectedItem.Text;
                        lblChildPremiumAmount2.Font.Bold = true;
                        lblChildPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth2.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount2.Enabled = false;
                        lblChildPremiumAmount2.Visible = true;
                        lblChildPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship2.SelectedItem.Text;
                        lblChildPremiumAmount2.Font.Bold = true;
                        lblChildPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth2.Focus();
                    }
                }
            }
        }
        protected void cmbChildBenefitAmount2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount2.Visible = true;
            lblChildPremiumAmount2.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount2.Font.Bold = true;
            lblChildPremiumAmount2.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount2.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth3.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth3.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship3.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount3.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount3.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount3.DataSource = lstBenefits;
                cmbChildBenefitAmount3.DataBind();

                DateTime DOB3 = Convert.ToDateTime(txtChildDateOfBirth3.Text);
                int years = DateTime.Now.Year - DOB3.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship3.SelectedValue));
                cmbChildBenefitAmount3.Enabled = true;
                lblChildPremiumAmount3.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount3.Enabled = false;
                        lblChildPremiumAmount3.Visible = true;
                        lblChildPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship3.SelectedItem.Text;
                        lblChildPremiumAmount3.Font.Bold = true;
                        lblChildPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth3.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount3.Enabled = false;
                        lblChildPremiumAmount3.Visible = true;
                        lblChildPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship3.SelectedItem.Text;
                        lblChildPremiumAmount3.Font.Bold = true;
                        lblChildPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth3.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount3.Visible = true;
            lblChildPremiumAmount3.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount3.Font.Bold = true;
            lblChildPremiumAmount3.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount3.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth4.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth4.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship4.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount4.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount4.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount4.DataSource = lstBenefits;
                cmbChildBenefitAmount4.DataBind();

                DateTime DOB4 = Convert.ToDateTime(txtChildDateOfBirth4.Text);
                int years = DateTime.Now.Year - DOB4.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship4.SelectedValue));
                cmbChildBenefitAmount4.Enabled = true;
                lblChildPremiumAmount4.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount4.Enabled = false;
                        lblChildPremiumAmount4.Visible = true;
                        lblChildPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship4.SelectedItem.Text;
                        lblChildPremiumAmount4.Font.Bold = true;
                        lblChildPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                       //txtChildDateOfBirth3.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount4.Enabled = false;
                        lblChildPremiumAmount4.Visible = true;
                        lblChildPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship4.SelectedItem.Text;
                        lblChildPremiumAmount4.Font.Bold = true;
                        lblChildPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth4.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount4.Visible = true;
            lblChildPremiumAmount4.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount4.Font.Bold = true;
            lblChildPremiumAmount4.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount4.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth5.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth5.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship5.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount5.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount5.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount5.DataSource = lstBenefits;
                cmbChildBenefitAmount5.DataBind();

                DateTime DOB5 = Convert.ToDateTime(txtChildDateOfBirth5.Text);
                int years = DateTime.Now.Year - DOB5.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship5.SelectedValue));
                cmbChildBenefitAmount5.Enabled = true;
                lblChildPremiumAmount5.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount5.Enabled = false;
                        lblChildPremiumAmount5.Visible = true;
                        lblChildPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship5.SelectedItem.Text;
                        lblChildPremiumAmount5.Font.Bold = true;
                        lblChildPremiumAmount5.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth5.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount5.Enabled = false;
                        lblChildPremiumAmount5.Visible = true;
                        lblChildPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship5.SelectedItem.Text;
                        lblChildPremiumAmount5.Font.Bold = true;
                        lblChildPremiumAmount5.ForeColor = System.Drawing.Color.Red;
                       // txtChildDateOfBirth5.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount5_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount5.Visible = true;
            lblChildPremiumAmount5.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount5.Font.Bold = true;
            lblChildPremiumAmount5.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount5.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth6.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth6.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship6.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount6.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount6.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount6.DataSource = lstBenefits;
                cmbChildBenefitAmount6.DataBind();

                DateTime DOB6 = Convert.ToDateTime(txtChildDateOfBirth6.Text);
                int years = DateTime.Now.Year - DOB6.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship6.SelectedValue));
                cmbChildBenefitAmount6.Enabled = true;
                lblChildPremiumAmount6.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount6.Enabled = false;
                        lblChildPremiumAmount6.Visible = true;
                        lblChildPremiumAmount6.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship6.SelectedItem.Text;
                        lblChildPremiumAmount6.Font.Bold = true;
                        lblChildPremiumAmount6.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth6.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount6.Enabled = false;
                        lblChildPremiumAmount6.Visible = true;
                        lblChildPremiumAmount6.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship6.SelectedItem.Text;
                        lblChildPremiumAmount6.Font.Bold = true;
                        lblChildPremiumAmount6.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth6.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount6_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount6.Visible = true;
            lblChildPremiumAmount6.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount6.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount6.Font.Bold = true;
            lblChildPremiumAmount6.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount6.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount6.SelectedValue)).PremiumAmount.ToString();
        }
        protected void cmbChildRelationship7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth7.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth7.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship7.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount7.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount7.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount7.DataSource = lstBenefits;
                cmbChildBenefitAmount7.DataBind();

                DateTime DOB7 = Convert.ToDateTime(txtChildDateOfBirth7.Text);
                int years = DateTime.Now.Year - DOB7.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship7.SelectedValue));
                cmbChildBenefitAmount7.Enabled = true;
                lblChildPremiumAmount7.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount7.Enabled = false;
                        lblChildPremiumAmount7.Visible = true;
                        lblChildPremiumAmount7.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship7.SelectedItem.Text;
                        lblChildPremiumAmount7.Font.Bold = true;
                        lblChildPremiumAmount7.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth7.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount7.Enabled = false;
                        lblChildPremiumAmount7.Visible = true;
                        lblChildPremiumAmount7.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship7.SelectedItem.Text;
                        lblChildPremiumAmount7.Font.Bold = true;
                        lblChildPremiumAmount7.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth7.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount7_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount7.Visible = true;
            lblChildPremiumAmount7.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount7.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount7.Font.Bold = true;
            lblChildPremiumAmount7.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount7.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount7.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbChildRelationship8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtChildDateOfBirth8.Text;
            if (dOb == "")
            {
                txtChildDateOfBirth8.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbChildRelationship8.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbChildBenefitAmount8.DataTextField = "BenefitAmount";
                cmbChildBenefitAmount8.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbChildBenefitAmount8.DataSource = lstBenefits;
                cmbChildBenefitAmount8.DataBind();

                DateTime DOB8 = Convert.ToDateTime(txtChildDateOfBirth8.Text);
                int years = DateTime.Now.Year - DOB8.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbChildRelationship8.SelectedValue));
                cmbChildBenefitAmount8.Enabled = true;
                lblChildPremiumAmount8.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbChildBenefitAmount8.Enabled = false;
                        lblChildPremiumAmount8.Visible = true;
                        lblChildPremiumAmount8.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship8.SelectedItem.Text;
                        lblChildPremiumAmount8.Font.Bold = true;
                        lblChildPremiumAmount8.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth8.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbChildBenefitAmount8.Enabled = false;
                        lblChildPremiumAmount8.Visible = true;
                        lblChildPremiumAmount8.Text = "The beneficiary is younger than minimum age allowed for this " + cmbChildRelationship8.SelectedItem.Text;
                        lblChildPremiumAmount8.Font.Bold = true;
                        lblChildPremiumAmount8.ForeColor = System.Drawing.Color.Red;
                        //txtChildDateOfBirth8.Focus();
                    }
                }
            }
        }

        protected void cmbChildBenefitAmount8_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChildPremiumAmount8.Visible = true;
            lblChildPremiumAmount8.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount8.SelectedValue)).PremiumAmount.ToString();
            lblChildPremiumAmount8.Font.Bold = true;
            lblChildPremiumAmount8.ForeColor = System.Drawing.Color.Green;
            hiddenChildPremiumAmount8.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbChildBenefitAmount8.SelectedValue)).PremiumAmount.ToString();
        }


        protected void cmbExtFamRelationship1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth1.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth1.Focus();
            }
            else
            {

                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship1.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount1.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount1.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount1.DataSource = lstBenefits;
                cmbExtFamBenefitAmount1.DataBind();

                DateTime DOB1 = Convert.ToDateTime(txtExtFamDateOfBirth1.Text);
                int years = DateTime.Now.Year - DOB1.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship1.SelectedValue));
                cmbExtFamBenefitAmount1.Enabled = true;
                lblExtFamPremiumAmount1.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount1.Enabled = false;
                        lblExtFamPremiumAmount1.Visible = true;
                        lblExtFamPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship1.SelectedItem.Text;
                        lblExtFamPremiumAmount1.Font.Bold = true;
                        lblExtFamPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth1.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount1.Enabled = false;
                        lblExtFamPremiumAmount1.Visible = true;
                        lblExtFamPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship1.SelectedItem.Text;
                        lblExtFamPremiumAmount1.Font.Bold = true;
                        lblExtFamPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth1.Focus();
                    }
                }
            }
        }
        protected void cmbExtFamBenefitAmount1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount1.Visible = true;
            lblExtFamPremiumAmount1.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount1.Font.Bold = true;
            lblExtFamPremiumAmount1.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount1.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbExtFamRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth2.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth2.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship2.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount2.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount2.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount2.DataSource = lstBenefits;
                cmbExtFamBenefitAmount2.DataBind();

                DateTime DOB2 = Convert.ToDateTime(txtExtFamDateOfBirth2.Text);
                int years = DateTime.Now.Year - DOB2.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship2.SelectedValue));
                cmbExtFamBenefitAmount2.Enabled = true;
                lblExtFamPremiumAmount2.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount2.Enabled = false;
                        lblExtFamPremiumAmount2.Visible = true;
                        lblExtFamPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship2.SelectedItem.Text;
                        lblExtFamPremiumAmount2.Font.Bold = true;
                        lblExtFamPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth2.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount2.Enabled = false;
                        lblExtFamPremiumAmount2.Visible = true;
                        lblExtFamPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship2.SelectedItem.Text;
                        lblExtFamPremiumAmount2.Font.Bold = true;
                        lblExtFamPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth2.Focus();
                    }
                }
            }
        }
        protected void cmbExtFamBenefitAmount2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount2.Visible = true;
            lblExtFamPremiumAmount2.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount2.Font.Bold = true;
            lblExtFamPremiumAmount2.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount2.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbExtFamRelationship3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth3.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth3.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship3.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount3.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount3.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount3.DataSource = lstBenefits;
                cmbExtFamBenefitAmount3.DataBind();

                DateTime DOB3 = Convert.ToDateTime(txtExtFamDateOfBirth3.Text);
                int years = DateTime.Now.Year - DOB3.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship3.SelectedValue));
                cmbExtFamBenefitAmount3.Enabled = true;
                lblExtFamPremiumAmount3.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount3.Enabled = false;
                        lblExtFamPremiumAmount3.Visible = true;
                        lblExtFamPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship3.SelectedItem.Text;
                        lblExtFamPremiumAmount3.Font.Bold = true;
                        lblExtFamPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth3.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount3.Enabled = false;
                        lblExtFamPremiumAmount3.Visible = true;
                        lblExtFamPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship3.SelectedItem.Text;
                        lblExtFamPremiumAmount3.Font.Bold = true;
                        lblExtFamPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth3.Focus();
                    }
                }
            }
        }
        protected void cmbExtFamBenefitAmount3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount3.Visible = true;
            lblExtFamPremiumAmount3.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount3.Font.Bold = true;
            lblExtFamPremiumAmount3.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount3.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbExtFamRelationship4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth4.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth4.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship4.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount4.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount4.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount4.DataSource = lstBenefits;
                cmbExtFamBenefitAmount4.DataBind();

                DateTime DOB4 = Convert.ToDateTime(txtExtFamDateOfBirth4.Text);
                int years = DateTime.Now.Year - DOB4.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship4.SelectedValue));
                cmbExtFamBenefitAmount4.Enabled = true;
                lblExtFamPremiumAmount4.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount4.Enabled = false;
                        lblExtFamPremiumAmount4.Visible = true;
                        lblExtFamPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship4.SelectedItem.Text;
                        lblExtFamPremiumAmount4.Font.Bold = true;
                        lblExtFamPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth4.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount4.Enabled = false;
                        lblExtFamPremiumAmount4.Visible = true;
                        lblExtFamPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship4.SelectedItem.Text;
                        lblExtFamPremiumAmount4.Font.Bold = true;
                        lblExtFamPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth4.Focus();
                    }
                }
            }
        }
        protected void cmbExtFamBenefitAmount4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount4.Visible = true;
            lblExtFamPremiumAmount4.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount4.Font.Bold = true;
            lblExtFamPremiumAmount4.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount4.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbExtFamRelationship5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth5.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth5.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship5.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount5.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount5.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount5.DataSource = lstBenefits;
                cmbExtFamBenefitAmount5.DataBind();

                DateTime DOB5 = Convert.ToDateTime(txtExtFamDateOfBirth5.Text);
                int years = DateTime.Now.Year - DOB5.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship5.SelectedValue));
                cmbExtFamBenefitAmount5.Enabled = true;
                lblExtFamPremiumAmount5.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount5.Enabled = false;
                        lblExtFamPremiumAmount5.Visible = true;
                        lblExtFamPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship5.SelectedItem.Text;
                        lblExtFamPremiumAmount5.Font.Bold = true;
                        lblExtFamPremiumAmount5.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth5.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount5.Enabled = false;
                        lblExtFamPremiumAmount5.Visible = true;
                        lblExtFamPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship5.SelectedItem.Text;
                        lblExtFamPremiumAmount5.Font.Bold = true;
                        lblExtFamPremiumAmount5.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth5.Focus();
                    }
                }
            }
        }

        protected void cmbExtFamBenefitAmount5_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount5.Visible = true;
            lblExtFamPremiumAmount5.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount5.Font.Bold = true;
            lblExtFamPremiumAmount5.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount5.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbExtFamRelationship6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth6.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth6.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship6.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount6.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount6.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount6.DataSource = lstBenefits;
                cmbExtFamBenefitAmount6.DataBind();

                DateTime DOB6 = Convert.ToDateTime(txtExtFamDateOfBirth6.Text);
                int years = DateTime.Now.Year - DOB6.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship6.SelectedValue));
                cmbExtFamBenefitAmount6.Enabled = true;
                lblExtFamPremiumAmount6.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount6.Enabled = false;
                        lblExtFamPremiumAmount6.Visible = true;
                        lblExtFamPremiumAmount6.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship6.SelectedItem.Text;
                        lblExtFamPremiumAmount6.Font.Bold = true;
                        lblExtFamPremiumAmount6.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth6.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount6.Enabled = false;
                        lblExtFamPremiumAmount6.Visible = true;
                        lblExtFamPremiumAmount6.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship6.SelectedItem.Text;
                        lblExtFamPremiumAmount6.Font.Bold = true;
                        lblExtFamPremiumAmount6.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth6.Focus();
                    }
                }
            }
        }

        protected void cmbExtFamBenefitAmount6_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount6.Visible = true;
            lblExtFamPremiumAmount6.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount6.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount6.Font.Bold = true;
            lblExtFamPremiumAmount6.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount6.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount6.SelectedValue)).PremiumAmount.ToString();
        }
        protected void cmbExtFamRelationship7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth7.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth7.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship7.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount7.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount7.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount7.DataSource = lstBenefits;
                cmbExtFamBenefitAmount7.DataBind();

                DateTime DOB7 = Convert.ToDateTime(txtExtFamDateOfBirth7.Text);
                int years = DateTime.Now.Year - DOB7.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship7.SelectedValue));
                cmbExtFamBenefitAmount7.Enabled = true;
                lblExtFamPremiumAmount7.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount7.Enabled = false;
                        lblExtFamPremiumAmount7.Visible = true;
                        lblExtFamPremiumAmount7.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship7.SelectedItem.Text;
                        lblExtFamPremiumAmount7.Font.Bold = true;
                        lblExtFamPremiumAmount7.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth7.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount7.Enabled = false;
                        lblExtFamPremiumAmount7.Visible = true;
                        lblExtFamPremiumAmount7.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship7.SelectedItem.Text;
                        lblExtFamPremiumAmount7.Font.Bold = true;
                        lblExtFamPremiumAmount7.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth7.Focus();
                    }
                }
            }
        }

        protected void cmbExtFamBenefitAmount7_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount7.Visible = true;
            lblExtFamPremiumAmount7.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount7.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount7.Font.Bold = true;
            lblExtFamPremiumAmount7.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount7.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount6.SelectedValue)).PremiumAmount.ToString();
        }
        protected void cmbExtFamRelationship8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtExtFamDateOfBirth8.Text;
            if (dOb == "")
            {
                txtExtFamDateOfBirth8.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbExtFamRelationship8.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbExtFamBenefitAmount8.DataTextField = "BenefitAmount";
                cmbExtFamBenefitAmount8.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbExtFamBenefitAmount8.DataSource = lstBenefits;
                cmbExtFamBenefitAmount8.DataBind();

                DateTime DOB8 = Convert.ToDateTime(txtExtFamDateOfBirth8.Text);
                int years = DateTime.Now.Year - DOB8.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbExtFamRelationship8.SelectedValue));
                cmbExtFamBenefitAmount8.Enabled = true;
                lblExtFamPremiumAmount8.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbExtFamBenefitAmount8.Enabled = false;
                        lblExtFamPremiumAmount8.Visible = true;
                        lblExtFamPremiumAmount8.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship8.SelectedItem.Text;
                        lblExtFamPremiumAmount8.Font.Bold = true;
                        lblExtFamPremiumAmount8.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth8.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount8.Enabled = false;
                        lblExtFamPremiumAmount8.Visible = true;
                        lblExtFamPremiumAmount8.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship8.SelectedItem.Text;
                        lblExtFamPremiumAmount8.Font.Bold = true;
                        lblExtFamPremiumAmount8.ForeColor = System.Drawing.Color.Red;
                        //txtExtFamDateOfBirth8.Focus();
                    }
                }
            }
        }

        protected void cmbExtFamBenefitAmount8_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblExtFamPremiumAmount8.Visible = true;
            lblExtFamPremiumAmount8.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount8.SelectedValue)).PremiumAmount.ToString();
            lblExtFamPremiumAmount8.Font.Bold = true;
            lblExtFamPremiumAmount8.ForeColor = System.Drawing.Color.Green;
            hiddenExtFamPremiumAmount8.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbExtFamBenefitAmount8.SelectedValue)).PremiumAmount.ToString();
        }


        protected void cmbParentRelationship1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtParentDateOfBirth1.Text;
            if (dOb == "")
            {
                txtParentDateOfBirth1.Focus();
            }
            else
            {

                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbParentRelationship1.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbParentBenefitAmount1.DataTextField = "BenefitAmount";
                cmbParentBenefitAmount1.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbParentBenefitAmount1.DataSource = lstBenefits;
                cmbParentBenefitAmount1.DataBind();

                DateTime DOB1 = Convert.ToDateTime(txtParentDateOfBirth1.Text);
                int years = DateTime.Now.Year - DOB1.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbParentRelationship1.SelectedValue));
                cmbParentBenefitAmount1.Enabled = true;
                lblParentPremiumAmount1.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbParentBenefitAmount1.Enabled = false;
                        lblParentPremiumAmount1.Visible = true;
                        lblParentPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship1.SelectedItem.Text;
                        lblParentPremiumAmount1.Font.Bold = true;
                        lblParentPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth1.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbParentBenefitAmount1.Enabled = false;
                        lblParentPremiumAmount1.Visible = true;
                        lblParentPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship1.SelectedItem.Text;
                        lblParentPremiumAmount1.Font.Bold = true;
                        lblParentPremiumAmount1.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth1.Focus();
                    }
                }
            }
        }
        protected void cmbParentBenefitAmount1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParentPremiumAmount1.Visible = true;
            lblParentPremiumAmount1.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
            lblParentPremiumAmount1.Font.Bold = true;
            lblParentPremiumAmount1.ForeColor = System.Drawing.Color.Green;
            hiddenParentPremiumAmount1.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbParentRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtParentDateOfBirth2.Text;
            if (dOb == "")
            {
                txtParentDateOfBirth2.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbParentRelationship2.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbParentBenefitAmount2.DataTextField = "BenefitAmount";
                cmbParentBenefitAmount2.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbParentBenefitAmount2.DataSource = lstBenefits;
                cmbParentBenefitAmount2.DataBind();

                DateTime DOB2 = Convert.ToDateTime(txtParentDateOfBirth2.Text);
                int years = DateTime.Now.Year - DOB2.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbParentRelationship2.SelectedValue));
                cmbParentBenefitAmount2.Enabled = true;
                lblParentPremiumAmount2.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbParentBenefitAmount2.Enabled = false;
                        lblParentPremiumAmount2.Visible = true;
                        lblParentPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship2.SelectedItem.Text;
                        lblParentPremiumAmount2.Font.Bold = true;
                        lblParentPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth2.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbParentBenefitAmount2.Enabled = false;
                        lblParentPremiumAmount2.Visible = true;
                        lblParentPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbExtFamRelationship2.SelectedItem.Text;
                        lblParentPremiumAmount2.Font.Bold = true;
                        lblParentPremiumAmount2.ForeColor = System.Drawing.Color.Red;
                       // txtParentDateOfBirth2.Focus();
                    }
                }
            }
        }
        protected void cmbParentBenefitAmount2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParentPremiumAmount2.Visible = true;
            lblParentPremiumAmount2.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
            lblParentPremiumAmount2.Font.Bold = true;
            lblParentPremiumAmount2.ForeColor = System.Drawing.Color.Green;
            hiddenParentPremiumAmount2.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbParentRelationship3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtParentDateOfBirth3.Text;
            if (dOb == "")
            {
                txtParentDateOfBirth3.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbParentRelationship3.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbParentBenefitAmount3.DataTextField = "BenefitAmount";
                cmbParentBenefitAmount3.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbParentBenefitAmount3.DataSource = lstBenefits;
                cmbParentBenefitAmount3.DataBind();

                DateTime DOB3 = Convert.ToDateTime(txtParentDateOfBirth3.Text);
                int years = DateTime.Now.Year - DOB3.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbParentRelationship3.SelectedValue));
                cmbParentBenefitAmount3.Enabled = true;
                lblParentPremiumAmount3.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbParentBenefitAmount3.Enabled = false;
                        lblParentPremiumAmount3.Visible = true;
                        lblParentPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship3.SelectedItem.Text;
                        lblParentPremiumAmount3.Font.Bold = true;
                        lblParentPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                       // txtParentDateOfBirth3.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbExtFamBenefitAmount3.Enabled = false;
                        lblParentPremiumAmount3.Visible = true;
                        lblParentPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship3.SelectedItem.Text;
                        lblParentPremiumAmount3.Font.Bold = true;
                        lblParentPremiumAmount3.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth3.Focus();
                    }
                }
            }
        }
        protected void cmbParentBenefitAmount3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParentPremiumAmount3.Visible = true;
            lblParentPremiumAmount3.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
            lblParentPremiumAmount3.Font.Bold = true;
            lblParentPremiumAmount3.ForeColor = System.Drawing.Color.Green;
            hiddenParentPremiumAmount3.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        }

        protected void cmbParentRelationship4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dOb = txtParentDateOfBirth4.Text;
            if (dOb == "")
            {
                txtParentDateOfBirth4.Focus();
            }
            else
            {
                List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbParentRelationship4.SelectedValue));
                CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
                dummyBenefit.BenefitAmount = 0;
                dummyBenefit.CampaignRelationshipTypeFNBID = -1;
                lstBenefits.Insert(0, dummyBenefit);
                cmbParentBenefitAmount4.DataTextField = "BenefitAmount";
                cmbParentBenefitAmount4.DataValueField = "CampaignRelationshipTypeFNBID";
                cmbParentBenefitAmount4.DataSource = lstBenefits;
                cmbParentBenefitAmount4.DataBind();

                DateTime DOB4 = Convert.ToDateTime(txtParentDateOfBirth4.Text);
                int years = DateTime.Now.Year - DOB4.Year;
                CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbParentRelationship4.SelectedValue));
                cmbParentBenefitAmount4.Enabled = true;
                lblParentPremiumAmount4.Visible = false;

                if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
                {
                    if (years < _ageVerifier.Minage)
                    {
                        cmbParentBenefitAmount4.Enabled = false;
                        lblParentPremiumAmount4.Visible = true;
                        lblParentPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship4.SelectedItem.Text;
                        lblParentPremiumAmount4.Font.Bold = true;
                        lblParentPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth4.Focus();
                    }
                    else if (years > _ageVerifier.Maxage)
                    {
                        cmbParentBenefitAmount4.Enabled = false;
                        lblParentPremiumAmount4.Visible = true;
                        lblParentPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbParentRelationship4.SelectedItem.Text;
                        lblParentPremiumAmount4.Font.Bold = true;
                        lblParentPremiumAmount4.ForeColor = System.Drawing.Color.Red;
                        //txtParentDateOfBirth4.Focus();
                    }
                }
            }
        }
        protected void cmbParentBenefitAmount4_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblParentPremiumAmount4.Visible = true;
            lblParentPremiumAmount4.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
            lblParentPremiumAmount4.Font.Bold = true;
            lblParentPremiumAmount4.ForeColor = System.Drawing.Color.Green;
            hiddenParentPremiumAmount4.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbParentBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        }
        protected void btnPremiumCalc_Click(object sender, EventArgs e)
        {
            decimal premiumAmount = 0;

            premiumAmount = Convert.ToDecimal(hiddenPremiumAmount.Value) + Convert.ToDecimal(hiddenSpousePremiumAmount.Value) + Convert.ToDecimal(hiddenChildPremiumAmount1.Value) + Convert.ToDecimal(hiddenChildPremiumAmount2.Value) + Convert.ToDecimal(hiddenChildPremiumAmount3.Value) +
                            Convert.ToDecimal(hiddenChildPremiumAmount4.Value) + Convert.ToDecimal(hiddenChildPremiumAmount5.Value) + Convert.ToDecimal(hiddenChildPremiumAmount6.Value) + Convert.ToDecimal(hiddenChildPremiumAmount7.Value) + Convert.ToDecimal(hiddenChildPremiumAmount8.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount1.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount2.Value)
                            + Convert.ToDecimal(hiddenExtFamPremiumAmount3.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount4.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount5.Value + Convert.ToDecimal(hiddenExtFamPremiumAmount6.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount7.Value) + Convert.ToDecimal(hiddenExtFamPremiumAmount8.Value) +
                             Convert.ToDecimal(hiddenParentPremiumAmount1.Value) + Convert.ToDecimal(hiddenParentPremiumAmount2.Value) + Convert.ToDecimal(hiddenParentPremiumAmount3.Value) + Convert.ToDecimal(hiddenParentPremiumAmount4.Value));

            lblCalculatorPremiumAmount.Visible = true;
            lblCalculatorPremiumAmount.Text = "Total Premium Amount is R" + premiumAmount.ToString();
            lblCalculatorPremiumAmount.ForeColor = System.Drawing.Color.Green;
        }

    }
}