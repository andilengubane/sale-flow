<%@ Page Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="FNBFUN4.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.FNBFUN4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message">Welcome to Bytes People Solutions Sales App.</span>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                    </a>
                </li>
            </ul>
        </nav>
    </div>
    <br />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:MultiView ID="mvMain" runat="server">
                    <asp:View ID="vwMain" runat="server">
                        <div class="row wrapper border-bottom white-bg page-heading">
                                <div class="col-lg-10">
                                    <h2>FNB FUNERAL NEW ACQUISITIONS (FNBFUN4)</h2>
                                </div>
                            </div>

                        <div class="wrapper wrapper-content animated fadeInRight">
                               <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>BUNDLE TYPE (Individual or Family)</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                              <div class="form-group">
                                                <label class="col-sm-2 control-label">*Call Language</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbCallLanguage" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                            </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Funeral Cover for</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbBundleType" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                            </div>
                                            <div class="hr-line-dashed"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                               <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>ADDITIONAL DATA</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Recommended Benefit</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtRecommendedBenefit" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                            <label class="col-sm-2 control-label">Suggested Plan</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSuggestedPlan" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                                                          <div class="form-group">
                                                            <label class="col-sm-2 control-label">Preferred Debit Order</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPreferredDebitOrder" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                                    <div class="form-group">
                                                            <label class="col-sm-2 control-label">Gross Income</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtGrossIncome" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Account Type</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAccountType" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                             <div class="form-group">
                                                            <label class="col-sm-2 control-label">Competitor</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCompetitor" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Competitor Premium</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCompetitorPremium" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>PLAN HOLDER DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">                                          

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Title</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbTitle" CssClass="form-control" runat="server"></asp:DropDownList></div>

                                                    <label class="col-sm-2 control-label">*Firstname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" required="required"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">Secondname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSecondName" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurname" runat="server" CssClass="form-control  input-sm"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*ID Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                            
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">Passport Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPassportNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*Date of birth</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtDateOfBirth" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Work Tel</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelWork" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}"></asp:TextBox>   </div>

                                                    <label class="col-sm-2 control-label">*Cell No</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelCell" runat="server" CssClass="form-control" type="tel" required></asp:TextBox>  </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Account Code</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbAccountCode" CssClass="form-control" runat="server"></asp:DropDownList></div>

                                                    <label class="col-sm-2 control-label">*Vehicle</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtVehicle" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Gender</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="cmbGender" runat="server" CssClass="select2_demo_3 form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Postal Address 1</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtPostalAddress1" CssClass="form-control" runat="server"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">Postal Address 2</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtPostalAddress2" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Suburb/Town</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurburb" runat="server" CssClass="form-control"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*Postal Code</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">Personal Tel Number</label>
                                                    <div class="col-sm-4"><input type="text" class="form-control"></div>

                                                    <label class="col-sm-2 control-label">Email Address</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtEMail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Benefit</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="cmbBenefit" runat="server" OnSelectedIndexChanged="cmbBenefit_SelectedIndexChanged" AutoPostBack="true" CssClass="select2_demo_3 form-control"></asp:DropDownList><br/>
                                                          <asp:Label ID="lblPremiumAmount" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenPremiumAmount" Value="0" runat="server" />
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                              <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>SPOUSE DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">                                          

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Title</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbSpouseTitle" CssClass="form-control" runat="server"></asp:DropDownList></div>

                                                    <label class="col-sm-2 control-label">*Firstname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSpouseFirstname" runat="server" CssClass="form-control" required="required"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">Secondname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSpouseSecondName" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSpouseSurname" runat="server" CssClass="form-control  input-sm"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*ID Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSpouseIDNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                            
                                                <div class="form-group">

                                                     <label class="col-sm-2 control-label">*Gender</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="cmbSpouseGender" runat="server" CssClass="select2_demo_3 form-control"></asp:DropDownList>
                                                    </div>

                                                    <label class="col-sm-2 control-label">*Date of birth</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSpouseDateOfBirth" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox></div>
                                                </div>                                           
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Benefit</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="cmbSpouseBenefit" runat="server" OnSelectedIndexChanged="cmbSpouseBenefit_SelectedIndexChanged" AutoPostBack="true" CssClass="select2_demo_3 form-control"></asp:DropDownList><br/>
                                                          <asp:Label ID="lblSpousePremiumAmount" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenSpousePremiumAmount" Value="0" runat="server" />
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>CHILDREN DETAILS / <small> (MAX 8)</small></h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>

                                        </div>
                                    </div>
                                    <div class="ibox-content form-horizontal">
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4>
                                                        <span class="badge">&nbsp;Child 1:&nbsp;<asp:CheckBox ID="chkChild1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                           <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship1" runat="server" OnSelectedIndexChanged="cmbChildRelationship1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount1" OnSelectedIndexChanged="cmbChildBenefitAmount1_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount1" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount1" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 2:&nbsp;<asp:CheckBox ID="chkChild2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth2" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship2" runat="server" OnSelectedIndexChanged="cmbChildRelationship2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount2" OnSelectedIndexChanged="cmbChildBenefitAmount2_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount2" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount2" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Child 3:&nbsp;<asp:CheckBox ID="chkChild3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth3" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship3" AutoPostBack="true" OnSelectedIndexChanged="cmbChildRelationship3_SelectedIndexChanged" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                           <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount3" OnSelectedIndexChanged="cmbChildBenefitAmount3_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount3" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount3" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 4:&nbsp;<asp:CheckBox ID="chkChild4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship4" OnSelectedIndexChanged="cmbChildRelationship4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount4" OnSelectedIndexChanged="cmbChildBenefitAmount4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount4" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount4" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Child 5:&nbsp;<asp:CheckBox ID="chkChild5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild5_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth5" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship5" OnSelectedIndexChanged="cmbChildRelationship5_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount5" OnSelectedIndexChanged="cmbChildBenefitAmount5_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount5" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount5" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                      <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 6:&nbsp;<asp:CheckBox ID="chkChild6" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild6_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender6" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth6" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship6" OnSelectedIndexChanged="cmbChildRelationship6_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount6" OnSelectedIndexChanged="cmbChildBenefitAmount6_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount6" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount6" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                         <div class="hr-line-dashed"></div>
                                          <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Child 7:&nbsp;<asp:CheckBox ID="chkChild7" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild7_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender7" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth7" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship7" OnSelectedIndexChanged="cmbChildRelationship7_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount7" OnSelectedIndexChanged="cmbChildBenefitAmount7_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount7" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount7" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                      <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 8:&nbsp;<asp:CheckBox ID="chkChild8" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild8_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbChildGender8" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtChildDateOfBirth8" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbChildRelationship8" OnSelectedIndexChanged="cmbChildRelationship8_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbChildBenefitAmount8" OnSelectedIndexChanged="cmbChildBenefitAmount8_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblChildPremiumAmount8" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenChildPremiumAmount8" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                                <div class="col-lg-6">
                                    <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>EXTENDED FAMILY DETAILS / <small> (MAX 8)</small></h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>

                                        </div>
                                    </div>
                                    <div class="ibox-content form-horizontal">
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Extended Family 1:&nbsp;<asp:CheckBox ID="chkExtFam1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship1" OnSelectedIndexChanged="cmbExtFamRelationship1_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount1" OnSelectedIndexChanged="cmbExtFamBenefitAmount1_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount1" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount1" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Extended Family 2:&nbsp;<asp:CheckBox ID="chkExtFam2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth2" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship2" OnSelectedIndexChanged="cmbExtFamRelationship2_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount2" OnSelectedIndexChanged="cmbExtFamBenefitAmount2_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount2" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount2" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Extended Family 3:&nbsp;<asp:CheckBox ID="chkExtFam3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth3" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship3" OnSelectedIndexChanged="cmbExtFamRelationship3_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount3" OnSelectedIndexChanged="cmbExtFamBenefitAmount3_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount3" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount3" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Extended Family 4:&nbsp;<asp:CheckBox ID="chkExtFam4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship4" OnSelectedIndexChanged="cmbExtFamRelationship4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount4" OnSelectedIndexChanged="cmbExtFamBenefitAmount4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount4" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount4" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Extended Family 5:&nbsp;<asp:CheckBox ID="chkExtFam5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam5_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth5" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship5" OnSelectedIndexChanged="cmbExtFamRelationship5_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount5" OnSelectedIndexChanged="cmbExtFamBenefitAmount5_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount5" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount5" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                               <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Extended Family 6:&nbsp;<asp:CheckBox ID="chkExtFam6" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam6_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender6" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth6" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship6" OnSelectedIndexChanged="cmbExtFamRelationship6_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount6" OnSelectedIndexChanged="cmbExtFamBenefitAmount6_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount6" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount6" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                        </div>
                                          <div class="hr-line-dashed"></div>
                                         <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Extended Family 7:&nbsp;<asp:CheckBox ID="chkExtFam7" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam7_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender7" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth7" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship7" OnSelectedIndexChanged="cmbExtFamRelationship7_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount7" OnSelectedIndexChanged="cmbExtFamBenefitAmount7_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount7" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount7" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                               <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Extended Family 8:&nbsp;<asp:CheckBox ID="chkExtFam8" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkExtFam8_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtExtFamSurname8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtExtFamName8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbExtFamGender8" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtExtFamDateOfBirth8" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbExtFamRelationship8" OnSelectedIndexChanged="cmbExtFamRelationship8_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbExtFamBenefitAmount8" OnSelectedIndexChanged="cmbExtFamBenefitAmount8_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblExtFamPremiumAmount8" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenExtFamPremiumAmount8" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                              <div class="row">
                                <div class="col-lg-12">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>Parent(s)/Parent(s)-In-Law Details / <small> (MAX 4)</small></h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>

                                        </div>
                                    </div>
                                    <div class="ibox-content form-horizontal">
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4>
                                                        <span class="badge">&nbsp;Parent 1:&nbsp;<asp:CheckBox ID="chkParent1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbParentGender1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtParentDateOfBirth1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                           <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbParentRelationship1" runat="server" OnSelectedIndexChanged="cmbParentRelationship1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbParentBenefitAmount1" OnSelectedIndexChanged="cmbParentBenefitAmount1_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblParentPremiumAmount1" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenParentPremiumAmount1" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Parent 2:&nbsp;<asp:CheckBox ID="chkParent2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbParentGender2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtParentDateOfBirth2" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbParentRelationship2" runat="server" OnSelectedIndexChanged="cmbParentRelationship2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbParentBenefitAmount2" OnSelectedIndexChanged="cmbParentBenefitAmount2_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblParentPremiumAmount2" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenParentPremiumAmount2" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Parent 3:&nbsp;<asp:CheckBox ID="chkParent3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbParentGender3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtParentDateOfBirth3" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbParentRelationship3" AutoPostBack="true" OnSelectedIndexChanged="cmbParentRelationship3_SelectedIndexChanged" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                           <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbParentBenefitAmount3" OnSelectedIndexChanged="cmbParentBenefitAmount3_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblParentPremiumAmount3" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenParentPremiumAmount3" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Parent 4:&nbsp;<asp:CheckBox ID="chkParent4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbParentGender4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>		
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtParentDateOfBirth4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbParentRelationship4" OnSelectedIndexChanged="cmbParentRelationship4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Benefit Amount</label>
                                                            <asp:DropDownList ID="cmbParentBenefitAmount4" OnSelectedIndexChanged="cmbParentBenefitAmount4_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                         <div class="form-group">
                                                             <asp:Label ID="lblParentPremiumAmount4" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenParentPremiumAmount4" Value="0" runat="server" />
                                                         </div>
                                                    </div>
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                                  </div>

                              <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>BENEFICIARY DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">*Title</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenTitle" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                            <label class="col-sm-2 control-label">*Initials</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenInitials" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                      <div class="form-group">
                                                            <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenSurname" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                                    <div class="form-group">
                                                            <label class="col-sm-2 control-label">*First Name</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenFirstName" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Second Name</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenSecondName" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                             <div class="form-group">
                                                            <label class="col-sm-2 control-label">*Gender</label>
                                                    <div class="col-sm-4">  <asp:DropDownList ID="cmbBenGender" runat="server" CssClass="form-control"></asp:DropDownList> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">RSA ID Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenRSAIDNumber" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                               <div class="form-group">
                                                            <label class="col-sm-2 control-label">*Date of Birth</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenDOB" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox> </div>
                                                        </div>
                                                  <div class="hr-line-dashed"></div>
                                               <div class="form-group">
                                                            <label class="col-sm-2 control-label">Cellphone Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenCellphoneNumber" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Work Tel Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenWorkTelNumber" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                            <label class="col-sm-2 control-label">Personal Tel Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenPersonalTelNumber" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                               <div class="form-group">
                                                            <label class="col-sm-2 control-label">Email Address</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtBenEmailAddress" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>DEBIT ORDER DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                    <%--        <div class="row">
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Bank Name</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtBankName" CssClass="form-control" runat="server"></asp:TextBox></div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Account Holder</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtBankAccountHolder" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>--%>

                                            <div class="row">
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Account Number</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtBankAccountNumber" CssClass="form-control" runat="server" MaxLength="25" OnTextChanged="txtBankAccountNumber_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Debit Order Date</label>
                                                    <div class="col-sm-4">
                                                        <asp:DropDownList ID="cmbDebitOrderDay" CssClass="select2_demo_3 form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="hr-line-dashed"></div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>External/Extended Functions</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content">
                                                <div class="form-group">

                                                    <div class="form-group">
                                                        <asp:Button ID="btnPremiumCalc" CssClass="btn btn-block" runat="server" OnClick="btnPremiumCalc_Click" Text="Premium Calculator" />
                                                        <asp:Label ID="lblCalculatorPremiumAmount" runat="server" Visible="False" Text="Label" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                  <%--                      <asp:Button ID="btnECCNo" CssClass="btn btn-block" runat="server" Text="Client Already Has ECC No" OnClick="btnECCNo_Click" />
                                                        <asp:Button ID="btnUSSD" CssClass="btn btn-block" runat="server" Text="SEND USSD (attempts 0)" />
                                                        <asp:Button ID="btnUpdateClient" CssClass="btn btn-block" runat="server" Text="Update Client Information" OnClick="btnUpdateClient_Click" />--%>
                                                    </div>
                                                </div>

                                                <div class="hr-line-dashed"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>Finally</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-3 control-label">Disposition</label>
                                                        <div class="col-sm-9">
                                                                <asp:DropDownList ID="cmbDisposition" CssClass="select2_demo_3 form-control" runat="server"></asp:DropDownList>     
                                                            </div>
                                                    </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="btnSubmit_Click" />
                                                    </div>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-6">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>Call Back</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <label class="col-sm-3 control-label">Notes</label>
                                                        <div class="col-sm-9">
                                                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="hr-line-dashed"></div>
                                                    <div class="row">

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">*Date</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtScheduleDate" runat="server" TextMode="Date" CssClass="form-control"/>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="col-sm-3 control-label">*Time</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtScheduleTime" runat="server" TextMode="Time" CssClass="form-control"/>
                                                             </div>
                                                        </div>
                                                        <div class="hr-line-dashed"></div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-offset-9 col-sm-3">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save - For Later" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                </div>

                            </div>



                            





                        </div>

                        <!--sale history-->
                            <div class="small-chat-box fadeInRight animated" style="width:500px!important">
                                <div class="heading" draggable="true">
                                    SALE HISTORY
                                </div>

                                <div class="content" style="width:500px!important; height:500px!important">
                                    <div class="col-lg-12">
                                        <div class="ibox float-e-margins">
                                            <div class="ibox-content">
                                                <asp:GridView ID="gvHistory" CssClass="table table-hover" runat="server" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField DataField="ModifiedDate" DataFormatString="{0:yy/MM/dd HH:mm:ss}" HeaderText="Action Date" />
                                                        <asp:BoundField DataField="UpdatedBy" HeaderText="User" />
                                                        <asp:BoundField DataField="Comment" HeaderText="Comment" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="small-chat">
                                <span class="badge badge-warning pull-left"></span>
                    
                                <a class="open-small-chat">
                                     <i class="fa fa-chain"> </i> 
                                </a>
                            </div>

                    </asp:View>
                    <asp:View ID="vwConfirm" runat="server">
                        <div class="wrapper wrapper-content animated fadeInRight">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>PERSONAL DETAILS</h5>
                                                <div class="ibox-tools">
                                                    <a class="collapse-link">
                                                        <i class="fa fa-chevron-up"></i>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="ibox-content form-horizontal">
                                                <asp:Label ID="lblConfirmation" runat="server" CssClass="label-info" Text="Label"></asp:Label>
	                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>

        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="chkChild1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild5" EventName="CheckedChanged" />

            <asp:AsyncPostBackTrigger ControlID="chkExtFam1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkExtFam5" EventName="CheckedChanged" />

            <asp:AsyncPostBackTrigger ControlID="chkParent1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent4" EventName="CheckedChanged" />

            <asp:AsyncPostBackTrigger ControlID="btnPremiumCalc" EventName="Click" />           
            <asp:AsyncPostBackTrigger ControlID="cmbBenefit" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbSpouseBenefit" EventName="SelectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship5" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount5" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship6" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount6" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship7" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount7" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildRelationship8" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbChildBenefitAmount8" EventName="SelectedIndexChanged" />
           
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship5" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount5" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship6" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount6" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship7" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount7" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamRelationship8" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbExtFamBenefitAmount8" EventName="SelectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="cmbParentRelationship1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentBenefitAmount1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentRelationship2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentBenefitAmount2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentRelationship3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentBenefitAmount3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentRelationship4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbParentBenefitAmount4" EventName="SelectedIndexChanged" />

<%--            <asp:AsyncPostBackTrigger ControlID="btnECCNo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdateClient" EventName="Click" />--%>

        </Triggers>
    </asp:UpdatePanel>
   
<%-- <script>
        function validateID1() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;
          
            var theIDnumber = document.getElementById("<%=txtRIIdNumber1.ClientID%>").value;
            if (ex.test(theIDnumber) == false) {
                alert('Please supply a valid ID number on Beneficiary 1');
                return false;
            }
           

            var theIDnumber3 = document.getElementById("<%=txtRIIdNumber3.ClientID%>").value;
            if (ex.test(theIDnumber3) == false) {
                alert('Please supply a valid ID number on Beneficiary 3');
                return false;
            }

            var theIDnumber4 = document.getElementById("<%=txtRIIdNumber4.ClientID%>").value;
            if (ex.test(theIDnumber4) == false) {
                alert('Please supply a valid ID number on Beneficiary 4');
                return false;
            }

           var theIDnumber5 = document.getElementById("<%=txtRIIdNumber5.ClientID%>").value;
            if (ex.test(theIDnumber5) == false) {
                alert('Please supply a valid ID number on Beneficiary 5');
                return false;
            }--%>
        

<%--        function validateID2() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

            var theIDnumber2 = document.getElementById("<%=txtRIIdNumber2.ClientID%>").value;
            if (ex.test(theIDnumber2) == false) {
                alert('Please supply a valid ID number on Beneficiary 2');
                return false;
            }
        }

        function validateID3() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

            var theIDnumber3 = document.getElementById("<%=txtRIIdNumber3.ClientID%>").value;
            if (ex.test(theIDnumber3) == false) {
                alert('Please supply a valid ID number on Beneficiary 3');
                return false;
            }
        }

        function validateID4() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

            var theIDnumber4 = document.getElementById("<%=txtRIIdNumber4.ClientID%>").value;
            if (ex.test(theIDnumber4) == false) {
                alert('Please supply a valid ID number on Beneficiary 4');
                return false;
            }
        }--%>

<%--        function validateID4() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

            var theIDnumber4 = document.getElementById("<%=txtRIIdNumber4.ClientID%>").value;
            if (ex.test(theIDnumber4) == false) {
                alert('Please supply a valid ID number on Beneficiary 4');
                return false;
            }
        }
    </script>--%>
    <script>
        function getDateDiffYears(dateOne, dateTwo) {

    var daysInYear = 365.2425;
    var dateDiffTime = (dateOne.getTime() - dateTwo.getTime());
    var dateDiffDays = dateDiffTime / (1000 * 3600 * 24);

    var dateDiffYears = dateDiffDays / daysInYear;

    return dateDiffYears;
}

function validateDatesOfBirth() {

    var policyHolderDob = document.getElementById("<%=txtDateOfBirth.ClientID%>").value;
    var spouseDob = document.getElementById("<%=txtSpouseDateOfBirth.ClientID%>").value;

    var child1Dob = document.getElementById("<%=txtChildDateOfBirth1.ClientID%>").value;
    var child2Dob = document.getElementById("<%=txtChildDateOfBirth2.ClientID%>").value;
    var child3Dob = document.getElementById("<%=txtChildDateOfBirth3.ClientID%>").value;
    var child4Dob = document.getElementById("<%=txtChildDateOfBirth4.ClientID%>").value;
    var child5Dob = document.getElementById("<%=txtChildDateOfBirth5.ClientID%>").value;
    var child6Dob = document.getElementById("<%=txtChildDateOfBirth6.ClientID%>").value;
    var child7Dob = document.getElementById("<%=txtChildDateOfBirth7.ClientID%>").value;
    var child8Dob = document.getElementById("<%=txtChildDateOfBirth8.ClientID%>").value;

    var parent1Dob = document.getElementById("<%=txtParentDateOfBirth1.ClientID%>").value;
    var parent2Dob = document.getElementById("<%=txtParentDateOfBirth2.ClientID%>").value;
    var parent3Dob = document.getElementById("<%=txtParentDateOfBirth3.ClientID%>").value;
    var parent4Dob = document.getElementById("<%=txtParentDateOfBirth4.ClientID%>").value;

    var extended1Dob = document.getElementById("<%=txtExtFamDateOfBirth1.ClientID%>").value;
    var extended2Dob = document.getElementById("<%=txtExtFamDateOfBirth2.ClientID%>").value;
    var extended3Dob = document.getElementById("<%=txtExtFamDateOfBirth3.ClientID%>").value;
    var extended4Dob = document.getElementById("<%=txtExtFamDateOfBirth4.ClientID%>").value;
    var extended5Dob = document.getElementById("<%=txtExtFamDateOfBirth5.ClientID%>").value;
    var extended6Dob = document.getElementById("<%=txtExtFamDateOfBirth6.ClientID%>").value;
    var extended7Dob = document.getElementById("<%=txtExtFamDateOfBirth7.ClientID%>").value;
    var extended8Dob = document.getElementById("<%=txtExtFamDateOfBirth8.ClientID%>").value;

    var today = new Date();

    if (policyHolderDob != ''){
        var birthDate = new Date(policyHolderDob);
        var age = getDateDiffYears(today, birthDate); //today.getFullYear() - birthDate.getFullYear();
    
        if (age < 18){
            alert("Policy Holder age must be higher than 18 years.");
            return false;
        }
        else if (age > 74){
            alert("Policy Holder age cannot be higher than 74 years.")
            return false;
        }
    }

    if (spouseDob != ''){
        var birthDate = new Date(spouseDob);
        var age = getDateDiffYears(today, birthDate);    

        if (age < 18){
            alert("Spouse age must be higher than 18 years.");
            return false;
        }
        else if (age > 74){
            alert("Spouse age cannot be higher than 74 years.")
            return false;
        }
    }

    if (child1Dob != '') {
        var birthDate = new Date(child1Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 1 age may not be over 17 years.");
            return false;
        }
    }

    if (child2Dob != '') {
        var birthDate = new Date(child2Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 2 age may not be over 17 years.");
            return false;
        }
    }

    if (child3Dob != '') {
        var birthDate = new Date(child3Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 3 age may not be over 17 years.");
            return false;
        }
    }

    if (child4Dob != '') {
        var birthDate = new Date(child4Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 4 age may not be over 17 years.");
            return false;
        }
    }

    if (child5Dob != '') {
        var birthDate = new Date(child5Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 5 age may not be over 17 years.");
            return false;
        }
    }

    if (child6Dob != '') {
        var birthDate = new Date(child6Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 6 age may not be over 17 years.");
            return false;
        }
    }

    if (child7Dob != '') {
        var birthDate = new Date(child7Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 7 age may not be over 17 years.");
            return false;
        }
    }

    if (child8Dob != '') {
        var birthDate = new Date(child8Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age >= 18) {
            alert("Child 8 age may not be over 17 years.");
            return false;
        }
    }

    if (parent1Dob != '') {
        var birthDate = new Date(parent1Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age < 35) {
            alert("Parent 1 age may not be below 35 years.");
            return false;
        }
        else if (age > 74) {
            alert("Parent 1 age may not be over 74 years.");
            return false;
        }
    }

    if (parent2Dob != '') {
        var birthDate = new Date(parent2Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age < 35) {
            alert("Parent 2 age may not be below 35 years.");
            return false;
        }
        else if (age > 74) {
            alert("Parent 2 age may not be over 74 years.");
            return false;
        }
    }

    if (parent3Dob != '') {
        var birthDate = new Date(parent3Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age < 35) {
            alert("Parent 3 age may not be below 35 years.");
            return false;
        }
        else if (age > 74) {
            alert("Parent 3 age may not be over 74 years.");
            return false;
        }
    }

    if (parent4Dob != '') {
        var birthDate = new Date(parent4Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age < 35) {
            alert("Parent 4 age may not be below 35 years.");
            return false;
        }
        else if (age > 74) {
            alert("Parent 4 age may not be over 74 years.");
            return false;
        }
    }

    if (extended1Dob != '') {
        var birthDate = new Date(extended1Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 1 age may not be over 74 years.");
            return false;
        }
    }

    if (extended2Dob != '') {
        var birthDate = new Date(extended2Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 2 age may not be over 74 years.");
            return false;
        }
    }

    if (extended3Dob != '') {
        var birthDate = new Date(extended3Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 3 age may not be over 74 years.");
            return false;
        }
    }

    if (extended4Dob != '') {
        var birthDate = new Date(extended4Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 4 age may not be over 74 years.");
            return false;
        }
    }

    if (extended5Dob != '') {
        var birthDate = new Date(extended5Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 5 age may not be over 74 years.");
            return false;
        }
    }

    if (extended6Dob != '') {
        var birthDate = new Date(extended6Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 6 age may not be over 74 years.");
            return false;
        }
    }

    if (extended7Dob != '') {
        var birthDate = new Date(extended7Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 7 age may not be over 74 years.");
            return false;
        }
    }

    if (extended8Dob != '') {
        var birthDate = new Date(extended8Dob);
        var age = getDateDiffYears(today, birthDate);

        if (age > 74) {
            alert("Extended 8 age may not be over 74 years.");
            return false;
        }
    }

    return true;

}

        </script>
</asp:Content>