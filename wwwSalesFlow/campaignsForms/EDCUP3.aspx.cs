using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace wwwSalesFlow.campaignsForms
{
    public partial class EDCUP3 : System.Web.UI.Page
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


                #region Sale Type(s)
                LoadSaleTypes();
                LoadProductTypes();
                #endregion

                #region Gender(s)

                ////-- Main Member--\\
                //cmbGender.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbGender.DataValueField = "Value";
                //cmbGender.DataTextField = "Key";
                //cmbGender.DataBind();

                //-- Riders X 5 --\\
                //cmbRIGender1.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbRIGender1.DataValueField = "Value";
                //cmbRIGender1.DataTextField = "Key";
                //cmbRIGender1.DataBind();

                //cmbRIGender2.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbRIGender2.DataValueField = "Value";
                //cmbRIGender2.DataTextField = "Key";
                //cmbRIGender2.DataBind();

                //cmbRIGender3.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbRIGender3.DataValueField = "Value";
                //cmbRIGender3.DataTextField = "Key";
                //cmbRIGender3.DataBind();

                //cmbRIGender4.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbRIGender4.DataValueField = "Value";
                //cmbRIGender4.DataTextField = "Key";
                //cmbRIGender4.DataBind();

                //cmbRIGender5.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbRIGender5.DataValueField = "Value";
                //cmbRIGender5.DataTextField = "Key";
                //cmbRIGender5.DataBind();

                ////-- Family Riders --\\
                //cmbFRGender1.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbFRGender1.DataValueField = "Value";
                //cmbFRGender1.DataTextField = "Key";
                //cmbFRGender1.DataBind();

                //cmbFRGender2.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbFRGender2.DataValueField = "Value";
                //cmbFRGender2.DataTextField = "Key";
                //cmbFRGender2.DataBind();

                //cmbFRGender3.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbFRGender3.DataValueField = "Value";
                //cmbFRGender3.DataTextField = "Key";
                //cmbFRGender3.DataBind();

                //cmbFRGender4.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbFRGender4.DataValueField = "Value";
                //cmbFRGender4.DataTextField = "Key";
                //cmbFRGender4.DataBind();

                //cmbFRGender5.DataSource = BusinessLogic.CommonLists.GetGender();
                //cmbFRGender5.DataValueField = "Value";
                //cmbFRGender5.DataTextField = "Key";
                //cmbFRGender5.DataBind();

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

                //cmbDebitOrderDay.DataSource = BusinessLogic.CommonLists.GetDebitOrderDays();
                //cmbDebitOrderDay.DataValueField = "Value";
                //cmbDebitOrderDay.DataTextField = "Key";
                //cmbDebitOrderDay.DataBind();

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
                                //LoadBankDetails(sal.ID);
                                LoadSubmemberDetails(sal.ID);
                                loadSaleHistory(sal.ID);
                                //LoadCampaignBenefits(sal.CampaignID);
                                //LoadRelationshipTypes(sal.CampaignID);
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
                            //LoadBankDetails(sal.ID);
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
            }
        }
        private void LoadSaleTypes()
        {
            List<BusinessLogic.Campaigns.EDCON.SaleType> lstBundleTypes = BusinessLogic.Campaigns.EDCON.SaleType.GetAllSaleTypes();
            BusinessLogic.Campaigns.EDCON.SaleType dummyBundleTypes = new BusinessLogic.Campaigns.EDCON.SaleType();
            dummyBundleTypes.Title = "[ Please Select ]";
            dummyBundleTypes.SaleTypesEDCONID = -1;
            lstBundleTypes.Insert(0, dummyBundleTypes);
            cmbSaleType1.DataTextField = "Title";
            cmbSaleType1.DataValueField = "SaleTypesEDCONID";
            cmbSaleType1.DataSource = lstBundleTypes;
            cmbSaleType1.DataBind();

            cmbSaleType2.DataTextField = "Title";
            cmbSaleType2.DataValueField = "SaleTypesEDCONID";
            cmbSaleType2.DataSource = lstBundleTypes;
            cmbSaleType2.DataBind();

            cmbSaleType3.DataTextField = "Title";
            cmbSaleType3.DataValueField = "SaleTypesEDCONID";
            cmbSaleType3.DataSource = lstBundleTypes;
            cmbSaleType3.DataBind();

            cmbSaleType4.DataTextField = "Title";
            cmbSaleType4.DataValueField = "SaleTypesEDCONID";
            cmbSaleType4.DataSource = lstBundleTypes;
            cmbSaleType4.DataBind();

            cmbSaleType5.DataTextField = "Title";
            cmbSaleType5.DataValueField = "SaleTypesEDCONID";
            cmbSaleType5.DataSource = lstBundleTypes;
            cmbSaleType5.DataBind();

            cmbSaleType6.DataTextField = "Title";
            cmbSaleType6.DataValueField = "SaleTypesEDCONID";
            cmbSaleType6.DataSource = lstBundleTypes;
            cmbSaleType6.DataBind();

            cmbSaleType7.DataTextField = "Title";
            cmbSaleType7.DataValueField = "SaleTypesEDCONID";
            cmbSaleType7.DataSource = lstBundleTypes;
            cmbSaleType7.DataBind();

            cmbSaleType7.DataTextField = "Title";
            cmbSaleType7.DataValueField = "SaleTypesEDCONID";
            cmbSaleType7.DataSource = lstBundleTypes;
            cmbSaleType7.DataBind();

        }
        private void LoadProductTypes()
        {
            List<BusinessLogic.Campaigns.EDCON.ProductTypes> lstBundleTypes = BusinessLogic.Campaigns.EDCON.ProductTypes.GetAllProductTypes();
            BusinessLogic.Campaigns.EDCON.ProductTypes dummyBundleTypes = new BusinessLogic.Campaigns.EDCON.ProductTypes();
            dummyBundleTypes.Title = "[ Please Select ]";
            dummyBundleTypes.ProductTypesID = -1;
            lstBundleTypes.Insert(0, dummyBundleTypes);
            cmbOldProduct1.DataTextField = "Title";
            cmbOldProduct1.DataValueField = "ProductTypesID";
            cmbOldProduct1.DataSource = lstBundleTypes;
            cmbOldProduct1.DataBind();

            cmbOldProduct2.DataTextField = "Title";
            cmbOldProduct2.DataValueField = "ProductTypesID";
            cmbOldProduct2.DataSource = lstBundleTypes;
            cmbOldProduct2.DataBind();

            cmbOldProduct3.DataTextField = "Title";
            cmbOldProduct3.DataValueField = "ProductTypesID";
            cmbOldProduct3.DataSource = lstBundleTypes;
            cmbOldProduct3.DataBind();

            cmbOldProduct4.DataTextField = "Title";
            cmbOldProduct4.DataValueField = "ProductTypesID";
            cmbOldProduct4.DataSource = lstBundleTypes;
            cmbOldProduct4.DataBind();

            cmbOldProduct5.DataTextField = "Title";
            cmbOldProduct5.DataValueField = "ProductTypesID";
            cmbOldProduct5.DataSource = lstBundleTypes;
            cmbOldProduct5.DataBind();

            cmbOldProduct6.DataTextField = "Title";
            cmbOldProduct6.DataValueField = "ProductTypesID";
            cmbOldProduct6.DataSource = lstBundleTypes;
            cmbOldProduct6.DataBind();

            cmbOldProduct7.DataTextField = "Title";
            cmbOldProduct7.DataValueField = "ProductTypesID";
            cmbOldProduct7.DataSource = lstBundleTypes;
            cmbOldProduct7.DataBind();

            cmbOldProduct8.DataTextField = "Title";
            cmbOldProduct8.DataValueField = "ProductTypesID";
            cmbOldProduct8.DataSource = lstBundleTypes;
            cmbOldProduct8.DataBind();
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
                //txtPassportNumber.Text = mem.PassportNumber;
                //txtDateOfBirth.Text = mem.DateOfBirth.ToString("yyyy-MM-dd");
                txtTelWork.Text = mem.TelWork;
                txtTelCell.Text = mem.TelCell;
                // txtTelHome.Text = mem.TelHome;
                // txtTelFax.Text = mem.TelFax;
                //cmbGender.SelectedValue = mem.Gender;
                //txtPostalAddress1.Text = mem.Address1;
                //txtPostalAddress2.Text = mem.Address2;
                //txtSurburb.Text = mem.Address3;
                // txtPostalAddress4.Text = mem.Address4;
                // txtCity.Text = mem.City;
                //txtPostalCode.Text = mem.PostalCode;
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

        //private void LoadBankDetails(int saleID)
        //{
        //    BankDetails bank = BankDetails.GetBankDetails(saleID);
        //    if (bank.Found)
        //    {
        //        txtBankAccountNumber.Text = BusinessLogic.Validators.MaskBankDetails(bank.AccountNumber);

        //        txtBankName.Text = bank.BankName;
        //        txtBankAccountHolder.Text = bank.AccountName;
        //        if (bank.FirstDebitDay == 0)
        //        {
        //            cmbDebitOrderDay.SelectedValue = DateTime.Now.AddDays(3).Day.ToString();
        //        }
        //        else
        //        {
        //            cmbDebitOrderDay.SelectedValue = bank.FirstDebitDay.ToString();
        //        }
        //    }
        //    bank = null;
        //}

        private void loadSaleHistory(int saleID)
        {
            gvHistory.DataSource = SalesLog.GetAllSalesLog(saleID);
            gvHistory.DataBind();
        }     

        private void EnableDisableProduct(int idx, bool enabled)
        {
            ((DropDownList)mvMain.FindControl("cmbSaleType" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbOldProduct" + idx.ToString())).Enabled = enabled;
            ((DropDownList)mvMain.FindControl("cmbNewProduct" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtCancelCode" + idx.ToString())).Enabled = enabled;
        }
        private void EnableDisableChildRider(int idx, bool enabled)
        {
            ((TextBox)mvMain.FindControl("txtChildName" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtChildSurname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtChildDOB" + idx.ToString())).Enabled = enabled;
        }
        private void EnableDisableParentRider(int idx, bool enabled)
        {
            ((TextBox)mvMain.FindControl("txtParentName" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtParentSurname" + idx.ToString())).Enabled = enabled;
            ((TextBox)mvMain.FindControl("txtParentDOB" + idx.ToString())).Enabled = enabled;
        }

        protected void chkProduct1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(1, chkProduct1.Checked);
        }
        protected void chkProduct2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(2, chkProduct2.Checked);
        }

        protected void chkProduct3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(3, chkProduct3.Checked);
        }

        protected void chkProduct4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(4, chkProduct4.Checked);
        }

        protected void chkProduct5_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(5, chkProduct5.Checked);
        }

        protected void chkProduct6_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(6, chkProduct6.Checked);
        }

        protected void chkProduct7_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(7, chkProduct7.Checked);
        }

        protected void chkProduct8_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableProduct(8, chkProduct8.Checked);
        }

        protected void chkBeneficiary_CheckedChanged(object sender, EventArgs e)
        {
            ((TextBox)mvMain.FindControl("txtBenName")).Enabled = true;
            ((TextBox)mvMain.FindControl("txtBenSurname")).Enabled = true;
            ((TextBox)mvMain.FindControl("txtBenDOB")).Enabled = true;
        }

        protected void chkSpouse_CheckedChanged(object sender, EventArgs e)
        {
            ((TextBox)mvMain.FindControl("txtSpouseName")).Enabled = true;
            ((TextBox)mvMain.FindControl("txtSpouseSurname")).Enabled = true;
            ((TextBox)mvMain.FindControl("txtSpouseDOB")).Enabled = true;
        }

        protected void chkChild1_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableChildRider(1, chkChild1.Checked);
        }

        protected void chkChild2_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableChildRider(2, chkChild2.Checked);
        }

        protected void chkChild3_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableChildRider(3, chkChild3.Checked);
        }

        protected void chkChild4_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableChildRider(4, chkChild4.Checked);
        }

        protected void chkChild5_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableChildRider(5, chkChild5.Checked);
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

        protected void cmbOldProduct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct1.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct1.DataTextField = "Title";
            cmbNewProduct1.DataValueField = "ProductID";
            cmbNewProduct1.DataSource = lstBenefits;
            cmbNewProduct1.DataBind();
        }
        protected void cmbNewProduct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI1.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct1.SelectedValue)).BI;
        }
        protected void cmbOldProduct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct2.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct2.DataTextField = "Title";
            cmbNewProduct2.DataValueField = "ProductID";
            cmbNewProduct2.DataSource = lstBenefits;
            cmbNewProduct2.DataBind();
        }

        protected void cmbNewProduct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI2.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct2.SelectedValue)).BI;
        }

        protected void cmbNewProduct3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct3.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct3.DataTextField = "Title";
            cmbNewProduct3.DataValueField = "ProductID";
            cmbNewProduct3.DataSource = lstBenefits;
            cmbNewProduct3.DataBind();
        }

        protected void cmbOldProduct3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI3.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct3.SelectedValue)).BI;
        }
        protected void cmbOldProduct4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct4.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct4.DataTextField = "Title";
            cmbNewProduct4.DataValueField = "ProductID";
            cmbNewProduct4.DataSource = lstBenefits;
            cmbNewProduct4.DataBind();
        }

        protected void cmbNewProduct4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI4.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct4.SelectedValue)).BI;
        }
        protected void cmbOldProduct5_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct5.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct5.DataTextField = "Title";
            cmbNewProduct5.DataValueField = "ProductID";
            cmbNewProduct5.DataSource = lstBenefits;
            cmbNewProduct5.DataBind();
        }

        protected void cmbNewProduct5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI5.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct5.SelectedValue)).BI;
        }
        protected void cmbOldProduct6_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct6.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct6.DataTextField = "Title";
            cmbNewProduct6.DataValueField = "ProductID";
            cmbNewProduct6.DataSource = lstBenefits;
            cmbNewProduct6.DataBind();
        }

        protected void cmbNewProduct6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI6.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct6.SelectedValue)).BI;
        }
        protected void cmbOldProduct7_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BusinessLogic.Campaigns.EDCON.Products> lstBenefits = BusinessLogic.Campaigns.EDCON.Products.GetProductsByProductType(Convert.ToInt32(cmbOldProduct7.SelectedValue));
            BusinessLogic.Campaigns.EDCON.Products dummyBenefit = new BusinessLogic.Campaigns.EDCON.Products();
            dummyBenefit.Title = "[ Please Select ]";
            dummyBenefit.ProductID = -1;
            lstBenefits.Insert(0, dummyBenefit);
            cmbNewProduct7.DataTextField = "Title";
            cmbNewProduct7.DataValueField = "ProductID";
            cmbNewProduct7.DataSource = lstBenefits;
            cmbNewProduct7.DataBind();
        }

        protected void cmbNewProduct7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBI7.Text = BusinessLogic.Campaigns.EDCON.Products.GetProductBI(Convert.ToInt32(cmbNewProduct7.SelectedValue)).BI;
        }
        //protected void cmbBenefit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblPremiumAmount.Visible = true;
        //    lblPremiumAmount.Text = "Premium is R" + CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
        //    lblPremiumAmount.Font.Bold = true;
        //    lblPremiumAmount.ForeColor = System.Drawing.Color.Green;
        //    hiddenPremiumAmount.Value = CampaignBenefits.GetBenefitAmount(Convert.ToInt32(cmbBenefit.SelectedValue)).PremiumAmount.ToString();
        //}
        //protected void cmbRIRelationship1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtRIDateOfBirth1.Text;
        //    if (dOb == "")
        //    {
        //        txtRIDateOfBirth1.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbRIRelationship1.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbRIBenefitAmount1.DataTextField = "BenefitAmount";
        //        cmbRIBenefitAmount1.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbRIBenefitAmount1.DataSource = lstBenefits;
        //        cmbRIBenefitAmount1.DataBind();

        //        DateTime DOB1 = Convert.ToDateTime(txtRIDateOfBirth1.Text);
        //        int years = DateTime.Now.Year - DOB1.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbRIRelationship1.SelectedValue));
        //        cmbRIBenefitAmount1.Enabled = true;
        //        lblRIPremiumAmount1.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbRIBenefitAmount1.Enabled = false;
        //                lblRIPremiumAmount1.Visible = true;
        //                lblRIPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship1.SelectedItem.Text;
        //                lblRIPremiumAmount1.Font.Bold = true;
        //                lblRIPremiumAmount1.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth1.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbRIBenefitAmount1.Enabled = false;
        //                lblRIPremiumAmount1.Visible = true;
        //                lblRIPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship1.SelectedItem.Text;
        //                lblRIPremiumAmount1.Font.Bold = true;
        //                lblRIPremiumAmount1.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth1.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbRIBenefitAmount1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblRIPremiumAmount1.Visible = true;
        //    lblRIPremiumAmount1.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        //    lblRIPremiumAmount1.Font.Bold = true;
        //    lblRIPremiumAmount1.ForeColor = System.Drawing.Color.Green;
        //    hiddenRIPremiumAmount1.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbRIRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtRIDateOfBirth2.Text;
        //    if (dOb == "")
        //    {
        //        txtRIDateOfBirth2.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbRIRelationship2.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbRIBenefitAmount2.DataTextField = "BenefitAmount";
        //        cmbRIBenefitAmount2.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbRIBenefitAmount2.DataSource = lstBenefits;
        //        cmbRIBenefitAmount2.DataBind();

        //        DateTime DOB2 = Convert.ToDateTime(txtRIDateOfBirth2.Text);
        //        int years = DateTime.Now.Year - DOB2.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbRIRelationship2.SelectedValue));
        //        cmbRIBenefitAmount2.Enabled = true;
        //        lblRIPremiumAmount2.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbRIBenefitAmount2.Enabled = false;
        //                lblRIPremiumAmount2.Visible = true;
        //                lblRIPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship2.SelectedItem.Text;
        //                lblRIPremiumAmount2.Font.Bold = true;
        //                lblRIPremiumAmount2.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth2.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbRIBenefitAmount2.Enabled = false;
        //                lblRIPremiumAmount2.Visible = true;
        //                lblRIPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship2.SelectedItem.Text;
        //                lblRIPremiumAmount2.Font.Bold = true;
        //                lblRIPremiumAmount2.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth2.Focus();
        //            }
        //        }
        //    }
        //}
        //protected void cmbRIBenefitAmount2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblRIPremiumAmount2.Visible = true;
        //    lblRIPremiumAmount2.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        //    lblRIPremiumAmount2.Font.Bold = true;
        //    lblRIPremiumAmount2.ForeColor = System.Drawing.Color.Green;
        //    hiddenRIPremiumAmount2.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbRIRelationship3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtRIDateOfBirth3.Text;
        //    if (dOb == "")
        //    {
        //        txtRIDateOfBirth3.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbRIRelationship3.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbRIBenefitAmount3.DataTextField = "BenefitAmount";
        //        cmbRIBenefitAmount3.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbRIBenefitAmount3.DataSource = lstBenefits;
        //        cmbRIBenefitAmount3.DataBind();

        //        DateTime DOB3 = Convert.ToDateTime(txtRIDateOfBirth3.Text);
        //        int years = DateTime.Now.Year - DOB3.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbRIRelationship3.SelectedValue));
        //        cmbRIBenefitAmount3.Enabled = true;
        //        lblRIPremiumAmount3.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbRIBenefitAmount3.Enabled = false;
        //                lblRIPremiumAmount3.Visible = true;
        //                lblRIPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship3.SelectedItem.Text;
        //                lblRIPremiumAmount3.Font.Bold = true;
        //                lblRIPremiumAmount3.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth3.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbRIBenefitAmount3.Enabled = false;
        //                lblRIPremiumAmount3.Visible = true;
        //                lblRIPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship3.SelectedItem.Text;
        //                lblRIPremiumAmount3.Font.Bold = true;
        //                lblRIPremiumAmount3.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth3.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbRIBenefitAmount3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblRIPremiumAmount3.Visible = true;
        //    lblRIPremiumAmount3.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        //    lblRIPremiumAmount3.Font.Bold = true;
        //    lblRIPremiumAmount3.ForeColor = System.Drawing.Color.Green;
        //    hiddenRIPremiumAmount3.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbRIRelationship4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtRIDateOfBirth4.Text;
        //    if (dOb == "")
        //    {
        //        txtRIDateOfBirth4.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbRIRelationship4.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbRIBenefitAmount4.DataTextField = "BenefitAmount";
        //        cmbRIBenefitAmount4.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbRIBenefitAmount4.DataSource = lstBenefits;
        //        cmbRIBenefitAmount4.DataBind();

        //        DateTime DOB4 = Convert.ToDateTime(txtRIDateOfBirth4.Text);
        //        int years = DateTime.Now.Year - DOB4.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbRIRelationship4.SelectedValue));
        //        cmbRIBenefitAmount4.Enabled = true;
        //        lblRIPremiumAmount4.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbRIBenefitAmount4.Enabled = false;
        //                lblRIPremiumAmount4.Visible = true;
        //                lblRIPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship4.SelectedItem.Text;
        //                lblRIPremiumAmount4.Font.Bold = true;
        //                lblRIPremiumAmount4.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth3.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbRIBenefitAmount4.Enabled = false;
        //                lblRIPremiumAmount4.Visible = true;
        //                lblRIPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship4.SelectedItem.Text;
        //                lblRIPremiumAmount4.Font.Bold = true;
        //                lblRIPremiumAmount4.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth4.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbRIBenefitAmount4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblRIPremiumAmount4.Visible = true;
        //    lblRIPremiumAmount4.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        //    lblRIPremiumAmount4.Font.Bold = true;
        //    lblRIPremiumAmount4.ForeColor = System.Drawing.Color.Green;
        //    hiddenRIPremiumAmount4.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbRIRelationship5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtRIDateOfBirth5.Text;
        //    if (dOb == "")
        //    {
        //        txtRIDateOfBirth5.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbRIRelationship5.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbRIBenefitAmount5.DataTextField = "BenefitAmount";
        //        cmbRIBenefitAmount5.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbRIBenefitAmount5.DataSource = lstBenefits;
        //        cmbRIBenefitAmount5.DataBind();

        //        DateTime DOB5 = Convert.ToDateTime(txtRIDateOfBirth5.Text);
        //        int years = DateTime.Now.Year - DOB5.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbRIRelationship5.SelectedValue));
        //        cmbRIBenefitAmount5.Enabled = true;
        //        lblRIPremiumAmount5.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbRIBenefitAmount5.Enabled = false;
        //                lblRIPremiumAmount5.Visible = true;
        //                lblRIPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship5.SelectedItem.Text;
        //                lblRIPremiumAmount5.Font.Bold = true;
        //                lblRIPremiumAmount5.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth5.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbRIBenefitAmount5.Enabled = false;
        //                lblRIPremiumAmount5.Visible = true;
        //                lblRIPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbRIRelationship5.SelectedItem.Text;
        //                lblRIPremiumAmount5.Font.Bold = true;
        //                lblRIPremiumAmount5.ForeColor = System.Drawing.Color.Red;
        //                txtRIDateOfBirth5.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbRIBenefitAmount5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblRIPremiumAmount5.Visible = true;
        //    lblRIPremiumAmount5.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        //    lblRIPremiumAmount5.Font.Bold = true;
        //    lblRIPremiumAmount5.ForeColor = System.Drawing.Color.Green;
        //    hiddenRIPremiumAmount5.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbRIBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbFRRelationship1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtFRDateOfBirth1.Text;
        //    if (dOb == "")
        //    {
        //        txtFRDateOfBirth1.Focus();
        //    }
        //    else
        //    {

        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbFRRelationship1.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbFRBenefitAmount1.DataTextField = "BenefitAmount";
        //        cmbFRBenefitAmount1.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbFRBenefitAmount1.DataSource = lstBenefits;
        //        cmbFRBenefitAmount1.DataBind();

        //        DateTime DOB1 = Convert.ToDateTime(txtFRDateOfBirth1.Text);
        //        int years = DateTime.Now.Year - DOB1.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbFRRelationship1.SelectedValue));
        //        cmbFRBenefitAmount1.Enabled = true;
        //        lblFRPremiumAmount1.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbFRBenefitAmount1.Enabled = false;
        //                lblFRPremiumAmount1.Visible = true;
        //                lblFRPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship1.SelectedItem.Text;
        //                lblFRPremiumAmount1.Font.Bold = true;
        //                lblFRPremiumAmount1.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth1.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbFRBenefitAmount1.Enabled = false;
        //                lblFRPremiumAmount1.Visible = true;
        //                lblFRPremiumAmount1.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship1.SelectedItem.Text;
        //                lblFRPremiumAmount1.Font.Bold = true;
        //                lblFRPremiumAmount1.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth1.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbFRBenefitAmount1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblFRPremiumAmount1.Visible = true;
        //    lblFRPremiumAmount1.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        //    lblFRPremiumAmount1.Font.Bold = true;
        //    lblFRPremiumAmount1.ForeColor = System.Drawing.Color.Green;
        //    hiddenFRPremiumAmount1.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount1.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbFRRelationship2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtFRDateOfBirth2.Text;
        //    if (dOb == "")
        //    {
        //        txtFRDateOfBirth2.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbFRRelationship2.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbFRBenefitAmount2.DataTextField = "BenefitAmount";
        //        cmbFRBenefitAmount2.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbFRBenefitAmount2.DataSource = lstBenefits;
        //        cmbFRBenefitAmount2.DataBind();

        //        DateTime DOB2 = Convert.ToDateTime(txtFRDateOfBirth2.Text);
        //        int years = DateTime.Now.Year - DOB2.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbFRRelationship2.SelectedValue));
        //        cmbFRBenefitAmount2.Enabled = true;
        //        lblFRPremiumAmount2.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbFRBenefitAmount2.Enabled = false;
        //                lblFRPremiumAmount2.Visible = true;
        //                lblFRPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship2.SelectedItem.Text;
        //                lblFRPremiumAmount2.Font.Bold = true;
        //                lblFRPremiumAmount2.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth2.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbFRBenefitAmount2.Enabled = false;
        //                lblFRPremiumAmount2.Visible = true;
        //                lblFRPremiumAmount2.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship2.SelectedItem.Text;
        //                lblFRPremiumAmount2.Font.Bold = true;
        //                lblFRPremiumAmount2.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth2.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbFRBenefitAmount2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblFRPremiumAmount2.Visible = true;
        //    lblFRPremiumAmount2.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        //    lblFRPremiumAmount2.Font.Bold = true;
        //    lblFRPremiumAmount2.ForeColor = System.Drawing.Color.Green;
        //    hiddenFRPremiumAmount2.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount2.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbFRRelationship3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtFRDateOfBirth3.Text;
        //    if (dOb == "")
        //    {
        //        txtFRDateOfBirth3.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbFRRelationship3.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbFRBenefitAmount3.DataTextField = "BenefitAmount";
        //        cmbFRBenefitAmount3.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbFRBenefitAmount3.DataSource = lstBenefits;
        //        cmbFRBenefitAmount3.DataBind();

        //        DateTime DOB3 = Convert.ToDateTime(txtFRDateOfBirth3.Text);
        //        int years = DateTime.Now.Year - DOB3.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbFRRelationship3.SelectedValue));
        //        cmbFRBenefitAmount3.Enabled = true;
        //        lblFRPremiumAmount3.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbFRBenefitAmount3.Enabled = false;
        //                lblFRPremiumAmount3.Visible = true;
        //                lblFRPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship3.SelectedItem.Text;
        //                lblFRPremiumAmount3.Font.Bold = true;
        //                lblFRPremiumAmount3.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth3.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbFRBenefitAmount3.Enabled = false;
        //                lblFRPremiumAmount3.Visible = true;
        //                lblFRPremiumAmount3.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship3.SelectedItem.Text;
        //                lblFRPremiumAmount3.Font.Bold = true;
        //                lblFRPremiumAmount3.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth3.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbFRBenefitAmount3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblFRPremiumAmount3.Visible = true;
        //    lblFRPremiumAmount3.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        //    lblFRPremiumAmount3.Font.Bold = true;
        //    lblFRPremiumAmount3.ForeColor = System.Drawing.Color.Green;
        //    hiddenFRPremiumAmount3.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount3.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbFRRelationship4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtFRDateOfBirth4.Text;
        //    if (dOb == "")
        //    {
        //        txtFRDateOfBirth4.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbFRRelationship4.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbFRBenefitAmount4.DataTextField = "BenefitAmount";
        //        cmbFRBenefitAmount4.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbFRBenefitAmount4.DataSource = lstBenefits;
        //        cmbFRBenefitAmount4.DataBind();

        //        DateTime DOB4 = Convert.ToDateTime(txtFRDateOfBirth4.Text);
        //        int years = DateTime.Now.Year - DOB4.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbFRRelationship4.SelectedValue));
        //        cmbFRBenefitAmount4.Enabled = true;
        //        lblFRPremiumAmount4.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbFRBenefitAmount4.Enabled = false;
        //                lblFRPremiumAmount4.Visible = true;
        //                lblFRPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship4.SelectedItem.Text;
        //                lblFRPremiumAmount4.Font.Bold = true;
        //                lblFRPremiumAmount4.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth4.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbFRBenefitAmount4.Enabled = false;
        //                lblFRPremiumAmount4.Visible = true;
        //                lblFRPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship4.SelectedItem.Text;
        //                lblFRPremiumAmount4.Font.Bold = true;
        //                lblFRPremiumAmount4.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth4.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbFRBenefitAmount4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblFRPremiumAmount4.Visible = true;
        //    lblFRPremiumAmount4.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount4.SelectedValue)).PremiumAmount.ToString();
        //    lblFRPremiumAmount4.Font.Bold = true;
        //    lblFRPremiumAmount4.ForeColor = System.Drawing.Color.Green;
        //    hiddenFRPremiumAmount4.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void cmbFRRelationship5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string dOb = txtFRDateOfBirth5.Text;
        //    if (dOb == "")
        //    {
        //        txtFRDateOfBirth5.Focus();
        //    }
        //    else
        //    {
        //        List<CampaignRelationshipTypeFNB> lstBenefits = CampaignRelationshipTypeFNB.GetBenefitsByRelation(Convert.ToInt32(cmbFRRelationship5.SelectedValue));
        //        CampaignRelationshipTypeFNB dummyBenefit = new CampaignRelationshipTypeFNB();
        //        dummyBenefit.BenefitAmount = 0;
        //        dummyBenefit.CampaignRelationshipTypeFNBID = -1;
        //        lstBenefits.Insert(0, dummyBenefit);
        //        cmbFRBenefitAmount5.DataTextField = "BenefitAmount";
        //        cmbFRBenefitAmount5.DataValueField = "CampaignRelationshipTypeFNBID";
        //        cmbFRBenefitAmount5.DataSource = lstBenefits;
        //        cmbFRBenefitAmount5.DataBind();

        //        DateTime DOB5 = Convert.ToDateTime(txtFRDateOfBirth5.Text);
        //        int years = DateTime.Now.Year - DOB5.Year;
        //        CampaignRelationshipTypeFNB _ageVerifier = CampaignRelationshipTypeFNB.GetMinMaxAges(Convert.ToInt32(cmbFRRelationship5.SelectedValue));
        //        cmbFRBenefitAmount5.Enabled = true;
        //        lblFRPremiumAmount5.Visible = false;

        //        if (_ageVerifier.Minage != 0 && _ageVerifier.Maxage != 0)
        //        {
        //            if (years < _ageVerifier.Minage)
        //            {
        //                cmbFRBenefitAmount5.Enabled = false;
        //                lblFRPremiumAmount5.Visible = true;
        //                lblFRPremiumAmount5.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship5.SelectedItem.Text;
        //                lblFRPremiumAmount5.Font.Bold = true;
        //                lblFRPremiumAmount5.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth5.Focus();
        //            }
        //            else if (years > _ageVerifier.Maxage)
        //            {
        //                cmbFRBenefitAmount4.Enabled = false;
        //                lblFRPremiumAmount4.Visible = true;
        //                lblFRPremiumAmount4.Text = "The beneficiary is younger than minimum age allowed for this " + cmbFRRelationship4.SelectedItem.Text;
        //                lblFRPremiumAmount4.Font.Bold = true;
        //                lblFRPremiumAmount4.ForeColor = System.Drawing.Color.Red;
        //                txtFRDateOfBirth4.Focus();
        //            }
        //        }
        //    }
        //}

        //protected void cmbFRBenefitAmount5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblFRPremiumAmount5.Visible = true;
        //    lblFRPremiumAmount5.Text = "Premium is R" + CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        //    lblFRPremiumAmount5.Font.Bold = true;
        //    lblFRPremiumAmount5.ForeColor = System.Drawing.Color.Green;
        //    hiddenFRPremiumAmount5.Value = CampaignRelationshipTypeFNB.GetBenefitAmount(Convert.ToInt32(cmbFRBenefitAmount5.SelectedValue)).PremiumAmount.ToString();
        //}

        //protected void btnPremiumCalc_Click(object sender, EventArgs e)
        //{
        //    decimal premiumAmount = 0;

        //    premiumAmount = Convert.ToDecimal(hiddenPremiumAmount.Value) + Convert.ToDecimal(hiddenRIPremiumAmount1.Value) + Convert.ToDecimal(hiddenRIPremiumAmount2.Value) + Convert.ToDecimal(hiddenRIPremiumAmount3.Value) +
        //                    Convert.ToDecimal(hiddenRIPremiumAmount4.Value) + +Convert.ToDecimal(hiddenRIPremiumAmount5.Value) + Convert.ToDecimal(hiddenFRPremiumAmount1.Value) + Convert.ToDecimal(hiddenFRPremiumAmount2.Value)
        //                    + Convert.ToDecimal(hiddenFRPremiumAmount3.Value) + Convert.ToDecimal(hiddenFRPremiumAmount4.Value) + Convert.ToDecimal(hiddenFRPremiumAmount5.Value);

        //    lblCalculatorPremiumAmount.Visible = true;
        //    lblCalculatorPremiumAmount.Text = "Total Premium Amount is R" + premiumAmount.ToString();
        //    lblCalculatorPremiumAmount.ForeColor = System.Drawing.Color.Green;
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Workflow Step... set to next step....
            lblConfirmation.Text = "Success: <br/>Sale submitted.";
            //int savedRiderCount = 0;
            //int savedFamilyRiderCount = 0;        
            mvMain.SetActiveView(vwConfirm);

            //if (Session["userID"] != null)
            //{
            //    int campaignID = Convert.ToInt32(ViewState["CampaignID"]);
            //    Users currentUser = Users.GetUserByID(Convert.ToInt32(Session["userID"]));
            //    if (currentUser.Found)
            //    {
            //        WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Pre-VET", campaignID);

            //        if (ws.Found)
            //        {
            //            //Create New Sale if New...
            //            if (ViewState["SaleID"] != null)
            //            {
            //                Sales sal = Sales.GetSale((int)ViewState["SaleID"]);
            //                int saleID = sal.ID;

            //                saleID = Sales.SaveSale(saleID, currentUser.ID, currentUser.ADUserName, DateTime.Now, ws.WorkflowID, ws.StepName,
            //                    "", "", "", "", "", "", "", "", "", "", Convert.ToInt32(cmbCallLanguage.SelectedValue));

            //                if (saleID > 0)
            //                {
            //                    //Save Sales Log...
            //                    int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());
            //                    //Save Personal Details...
            //                    int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, txtFirstname.Text, "", txtSurname.Text, txtIdNumber.Text, "", DateTime.Now, txtTelWork.Text, txtTelCell.Text, "", "", "", "", "", "", "", "", "", txtEMail.Text, 0);

            //                    //Save SubMembers Riders...
            //                    int submemberID = SubMemberType.GetSubMemberType("Rider").SubMemberTypeID;
            //                    //-- flush before save --\\
            //                    SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
            //                    //--loop through all ticked tickboxes and save --\\
            //                    for (int i = 1; i < 6; i++)
            //                    {
            //                        if (((CheckBox)mvMain.FindControl("chkR" + i.ToString())).Checked)
            //                        {
            //                            string surname = ((TextBox)mvMain.FindControl("txtRISurname" + i.ToString())).Text;
            //                            string firstName = ((TextBox)mvMain.FindControl("txtRIName" + i.ToString())).Text;
            //                            string secondName = ((TextBox)mvMain.FindControl("txtRISecondName" + i.ToString())).Text;
            //                            string gender = ((DropDownList)mvMain.FindControl("cmbRIGender" + i.ToString())).SelectedValue;
            //                            string idNumber = ((TextBox)mvMain.FindControl("txtRIIdNumber" + i.ToString())).Text;
            //                            DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtRIDateOfBirth" + i.ToString())).Text);
            //                            int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbRIRelationship" + i.ToString())).SelectedValue);

            //                            int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
            //                            if (newID > 0)
            //                            {
            //                                savedRiderCount += 1;
            //                            }
            //                        }
            //                    }

            //                    //Save SubMembers Family Riders...
            //                    submemberID = SubMemberType.GetSubMemberType("Family Rider").SubMemberTypeID;
            //                    //-- flush before save --\\
            //                    SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
            //                    //--loop through all ticked tickboxes and save --\\
            //                    for (int i = 1; i < 6; i++)
            //                    {
            //                        if (((CheckBox)mvMain.FindControl("chkFR" + i.ToString())).Checked)
            //                        {
            //                            string surname = ((TextBox)mvMain.FindControl("txtFRSurname" + i.ToString())).Text;
            //                            string firstName = ((TextBox)mvMain.FindControl("txtFRName" + i.ToString())).Text;
            //                            string secondName = ((TextBox)mvMain.FindControl("txtFRSecondName" + i.ToString())).Text;
            //                            string gender = ((DropDownList)mvMain.FindControl("cmbFRGender" + i.ToString())).SelectedValue;
            //                            string idNumber = ((TextBox)mvMain.FindControl("txtFRIdNumber" + i.ToString())).Text;
            //                            DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtFRDateOfBirth" + i.ToString())).Text);
            //                            int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbFRRelationship" + i.ToString())).SelectedValue);

            //                            int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
            //                            if (newID > 0)
            //                            {
            //                                savedFamilyRiderCount += 1;
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    lblConfirmation.Text = string.Format("Sale {0} not saved... <br/> Please escalate to admin", sal.ID.ToString());
            //                    mvMain.SetActiveView(vwConfirm);
            //                }
            //                sal = null;
            //            }
            //        }
            //        ws = null;
            //        mvMain.SetActiveView(vwConfirm);
            //    }
            //}
            //else
            //{
            //    lblConfirmation.Text = "Session Expired <br/>Please close your browser and start again.";
            //    mvMain.SetActiveView(vwConfirm);
            //}
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Workflow Step... set to next step....
            //int savedRiderCount = 0;
            //int savedFamilyRiderCount = 0;

            lblConfirmation.Text = "Sale saved successfully.";
            mvMain.SetActiveView(vwConfirm);

            //if (Session["userID"] != null)
            //{
            //    int campaignID = Convert.ToInt32(ViewState["CampaignID"]);
            //    Users currentUser = Users.GetUserByID(Convert.ToInt32(Session["userID"]));
            //    if (currentUser.Found)
            //    {
            //        WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Capture", campaignID);

            //        if (ws.Found)
            //        {
            //            //Create New Sale if New...
            //            if (ViewState["SaleID"] != null)
            //            {
            //                Sales sal = Sales.GetSale((int)ViewState["SaleID"]);
            //                int saleID = sal.ID;

            //                //WorkflowStep ws = WorkflowStep.GetWorkflowStepByNameAndCampaignID("Capture", campaignID);

            //                saleID = Sales.SaveSale(saleID, currentUser.ID, currentUser.ADUserName, DateTime.Now, ws.WorkflowID, ws.StepName);

            //                if (saleID > 0)
            //                {
            //                    //Save Sales Log...
            //                    int slog = SalesLog.CreateSalesLog(saleID, currentUser.ADUserName, ws.StepName + ": " + txtNotes.Text.Trim());
            //                    //Save Personal Details...
            //                    int personalDetails = PersonalDetails.SavePersonalDetails(saleID, cmbTitle.SelectedValue, txtFirstname.Text, "", txtSurname.Text, txtIdNumber.Text, "", DateTime.Now, txtTelWork.Text, txtTelCell.Text, "", "", "", "", "", "", "", "", "", txtEMail.Text, 0);

            //                    //Save SubMembers Riders...
            //                    int submemberID = SubMemberType.GetSubMemberType("Rider").SubMemberTypeID;
            //                    //-- flush before save --\\
            //                    SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
            //                    //--loop through all ticked tickboxes and save --\\
            //                    for (int i = 1; i < 6; i++)
            //                    {
            //                        if (((CheckBox)mvMain.FindControl("chkR" + i.ToString())).Checked)
            //                        {
            //                            string surname = ((TextBox)mvMain.FindControl("txtRISurname" + i.ToString())).Text;
            //                            string firstName = ((TextBox)mvMain.FindControl("txtRIName" + i.ToString())).Text;
            //                            DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtRIDateOfBirth" + i.ToString())).Text);
            //                            string secondName = ((TextBox)mvMain.FindControl("txtRISecondName" + i.ToString())).Text;
            //                            string gender = ((DropDownList)mvMain.FindControl("cmbRIGender" + i.ToString())).SelectedValue;
            //                            string idNumber = ((TextBox)mvMain.FindControl("txtRIIdNumber" + i.ToString())).Text;
            //                            int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbRIRelationship" + i.ToString())).SelectedValue);

            //                            int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
            //                            if (newID > 0)
            //                            {
            //                                savedRiderCount += 1;
            //                            }
            //                        }
            //                    }

            //                    //Save SubMembers Family Riders...
            //                    submemberID = SubMemberType.GetSubMemberType("Family Rider").SubMemberTypeID;
            //                    //-- flush before save --\\
            //                    SubMemberDetails.DeleteSubMemberDetails(saleID, submemberID);
            //                    //--loop through all ticked tickboxes and save --\\
            //                    for (int i = 1; i < 6; i++)
            //                    {
            //                        if (((CheckBox)mvMain.FindControl("chkFR" + i.ToString())).Checked)
            //                        {
            //                            string surname = ((TextBox)mvMain.FindControl("txtFRSurname" + i.ToString())).Text;
            //                            string firstName = ((TextBox)mvMain.FindControl("txtFRName" + i.ToString())).Text;
            //                            DateTime dateOfBirth = DateTime.Parse(((TextBox)mvMain.FindControl("txtFRDateOfBirth" + i.ToString())).Text);
            //                            string secondName = ((TextBox)mvMain.FindControl("txtFRSecondName" + i.ToString())).Text;
            //                            string gender = ((DropDownList)mvMain.FindControl("cmbFRGender" + i.ToString())).SelectedValue;
            //                            string idNumber = ((TextBox)mvMain.FindControl("txtFRIdNumber" + i.ToString())).Text;
            //                            int relationID = Convert.ToInt32(((DropDownList)mvMain.FindControl("cmbFRRelationship" + i.ToString())).SelectedValue);

            //                            int newID = SubMemberDetails.SaveSubMemberDetails(saleID, "", firstName, secondName, surname, gender, submemberID, idNumber, dateOfBirth, relationID);
            //                            if (newID > 0)
            //                            {
            //                                savedFamilyRiderCount += 1;
            //                            }
            //                        }
            //                    }

            //                    //Save Banking Details...
            //                    //DateTime debitDate = BusinessLogic.Validators.MakeDateFromDay(int.Parse(cmbDebitOrderDay.SelectedValue));
            //                    //#region format BankAccountNumber
            //                    //long bankAccountNumber;
            //                    ////if it contains X's we assume the account number has not been altered. - deal with it.
            //                    //if (txtBankAccountNumber.Text.IndexOf("X") >= 0)
            //                    //{
            //                    //    BankDetails bank = BankDetails.GetBankDetails(sal.ID);
            //                    //    if (bank.Found)
            //                    //    {
            //                    //        bankAccountNumber = long.Parse(bank.AccountNumber.Replace("-", ""));
            //                    //    }
            //                    //    else
            //                    //    {
            //                    //        bankAccountNumber = 0;
            //                    //    }
            //                    //}
            //                    //else
            //                    //{
            //                    //    if (!long.TryParse(txtBankAccountNumber.Text.Trim().Replace("-", ""), out bankAccountNumber))
            //                    //    {
            //                    //        bankAccountNumber = 0;
            //                    //    }
            //                    //}
            //                    //#endregion

            //                   // int banId = BankDetails.ModifyBankDetails(bankAccountNumber, txtBankAccountHolder.Text, txtBankName.Text, cmbAccountCode.SelectedValue, "", debitDate.Month, debitDate.Day, "Primary", saleID);
            //                }
            //                else
            //                {
            //                    lblConfirmation.Text = string.Format("Sale {0} not saved... <br/> Please escalate to admin", sal.ID.ToString());
            //                    mvMain.SetActiveView(vwConfirm);
            //                }

            //                DateTime callbackDate;
            //                if (!DateTime.TryParse(txtScheduleDate.Text + " " + txtScheduleTime.Text, out callbackDate))
            //                {
            //                    callbackDate = DateTime.Now.AddHours(4);
            //                }
            //                else
            //                {
            //                    if (callbackDate <= DateTime.Now)
            //                    {
            //                        callbackDate = DateTime.Now.AddHours(4);
            //                    }
            //                }

            //                BusinessLogic.DialAPI.ScheduleCallback(sal.CampaignName, sal.LeadID.ToString(), callbackDate, sal.AgentCode.ToString(), txtNotes.Text);
            //                sal = null;
            //            }
            //        }
            //        ws = null;


            //        mvMain.SetActiveView(vwConfirm);
            //    }
            //}
            //else
            //{
            //    lblConfirmation.Text = "Session Expired <br/>Please close your browser and start again.";
            //    mvMain.SetActiveView(vwConfirm);
            //}
        }

        protected void cmbOldProduct8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbNewProduct8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}