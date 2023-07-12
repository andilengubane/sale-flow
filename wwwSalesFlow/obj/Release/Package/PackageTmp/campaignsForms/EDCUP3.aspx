<%@ Page Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="EDCUP3.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.EDCUP3" %>

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
                                    <h2>EDCON - UPSELL (EDCUP3)</h2>
                                </div>
                                <div class="col-lg-2">

                                </div>
                            </div>

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

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Call Language</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbCallLanguage" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                            </div>
                                            <div class="hr-line-dashed"></div>
                                             <div class="form-group">
                                                    <label class="col-sm-2 control-label">Account Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Category</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Title</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbTitle" CssClass="form-control" runat="server"></asp:DropDownList></div>

                                                    <label class="col-sm-2 control-label">*Firstname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

<%--                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">Secondname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSecondName" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>--%>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurname" runat="server" CssClass="form-control  input-sm"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*ID Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                                              <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Work Tel</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelWork" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}"></asp:TextBox>   </div>

                                                    <label class="col-sm-2 control-label">*Cell No</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelCell" runat="server" CssClass="form-control" type="tel" required></asp:TextBox>  </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                            
                                           <%--     <div class="form-group">

                                                    <label class="col-sm-2 control-label">Passport Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPassportNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*Date of birth</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtDateOfBirth" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                              --%>

                                       <%--         <div class="form-group">

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
                                                <div class="hr-line-dashed"></div>--%>

                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">Alt Phone Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAltPhoneNumber" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">Email Address</label>
                                                    <div class="col-sm-4">
                                                        <asp:TextBox ID="txtEMail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                 <%--               <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Benefit</label>
                                                    <div class="col-sm-10">
                                                        <asp:DropDownList ID="cmbBenefit" runat="server" OnSelectedIndexChanged="cmbBenefit_SelectedIndexChanged" AutoPostBack="true" CssClass="select2_demo_3 form-control"></asp:DropDownList><br/>
                                                          <asp:Label ID="lblPremiumAmount" runat="server" Visible="false" Text="Label"></asp:Label><asp:HiddenField ID="hiddenPremiumAmount" Value="0" runat="server" />
                                                    </div>
                                                </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>PRODUCTS <small> </small></h5>
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
                                                        <span class="badge">&nbsp;Product 1:&nbsp;<asp:CheckBox ID="chkProduct1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType1" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct1" OnSelectedIndexChanged="cmbOldProduct1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct1" OnSelectedIndexChanged="cmbNewProduct1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Product 2:&nbsp;<asp:CheckBox ID="chkProduct2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                      <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType2" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct2" OnSelectedIndexChanged="cmbOldProduct2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct2" OnSelectedIndexChanged="cmbNewProduct2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Product 3:&nbsp;<asp:CheckBox ID="chkProduct3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType3" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct3" OnSelectedIndexChanged="cmbOldProduct3_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct3" OnSelectedIndexChanged="cmbNewProduct3_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Product 4:&nbsp;<asp:CheckBox ID="chkProduct4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType4" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct4" OnSelectedIndexChanged="cmbOldProduct4_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct4" OnSelectedIndexChanged="cmbNewProduct4_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Product 5:&nbsp;<asp:CheckBox ID="chkProduct5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct5_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType5" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct5" OnSelectedIndexChanged="cmbOldProduct5_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct5" OnSelectedIndexChanged="cmbNewProduct5_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                     <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Product 6:&nbsp;<asp:CheckBox ID="chkProduct6" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct6_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                      <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType6" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct6" OnSelectedIndexChanged="cmbOldProduct6_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct6" OnSelectedIndexChanged="cmbNewProduct6_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI6" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                           <div class="hr-line-dashed"></div>
                                          <div class="row">
                                     
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Product 7:&nbsp;<asp:CheckBox ID="chkProduct7" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct7_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType7" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct7" OnSelectedIndexChanged="cmbOldProduct7_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct7" OnSelectedIndexChanged="cmbNewProduct7_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI7" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                     <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Product 8:&nbsp;<asp:CheckBox ID="chkProduct8" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkProduct8_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">*Sale Type</label>
                                                            <asp:DropDownList ID="cmbSaleType8" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Old Product</label>
                                                            <asp:DropDownList ID="cmbOldProduct8" OnSelectedIndexChanged="cmbOldProduct8_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>

                                                        <div class="form-group">
                                                            <label class="control-label">*New Product</label>
                                                            <asp:DropDownList ID="cmbNewProduct8" OnSelectedIndexChanged="cmbNewProduct8_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Cancel Code</label>
                                                            <asp:TextBox ID="txtCancelCode8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">BI</label>
                                                            <asp:TextBox ID="txtBI8" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
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
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>BENEFICIARIES AND INSURED <small> </small></h5>
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
                                                        <span class="badge">&nbsp;Beneficiary:&nbsp;<asp:CheckBox ID="chkBeneficiary" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkBeneficiary_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">*Beneficiary Name</label>
                                                             <asp:TextBox ID="txtBenName" runat="server" CssClass="form-control" required="required"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">*Beneficiary Surname</label>
                                                             <asp:TextBox ID="txtBenSurname" runat="server" CssClass="form-control" required="required"  Enabled="False"></asp:TextBox>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">*Beneficiary DOB</label>
                                                            <asp:TextBox ID="txtBenDOB" runat="server" CssClass="form-control" TextMode="Date" required="required" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Spouse:&nbsp;<asp:CheckBox ID="chkSpouse" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkSpouse_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                      <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                             <asp:TextBox ID="txtSpouseName" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                             <asp:TextBox ID="txtSpouseSurname" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                           <asp:TextBox ID="txtSpouseDOB" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Child 1:&nbsp;<asp:CheckBox ID="chkChild1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtChildDOB1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 2:&nbsp;<asp:CheckBox ID="chkChild2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>

                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtChildDOB2" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
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
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtChildDOB3" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                   <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Child 4:&nbsp;<asp:CheckBox ID="chkChild4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkChild4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                           <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtChildDOB4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
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
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtChildName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtChildSurname5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtChildDOB5" runat="server" CssClass="form-control" TextMode="Date" Enabled="False" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                    <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Parent 1:&nbsp;<asp:CheckBox ID="chkParent1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                           <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                             <div class="form-group">
                                                            <label class="control-label">PSurname</label>
                                                            <asp:TextBox ID="txtParentSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtParentDOB1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                          <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Parent 2:&nbsp;<asp:CheckBox ID="chkParent2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                          <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtParentDOB2" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                    <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Parent 3:&nbsp;<asp:CheckBox ID="chkParent3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                           <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                          <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label">DOB</label>
                                                            <asp:TextBox ID="txtParentDOB3" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Parent 4:&nbsp;<asp:CheckBox ID="chkParent4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkParent4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtParentName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                            <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtParentSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="control-label"> DOB</label>
                                                            <asp:TextBox ID="txtParentDOB4" runat="server" CssClass="form-control" TextMode="Date"  Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </div>
                                <%--<div class="col-lg-12">
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
                                            <div class="row">
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
                                            </div>

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
                                </div>--%>
                            </div>

         <%--                   <div class="row">
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
                                                   <asp:Button ID="btnECCNo" CssClass="btn btn-block" runat="server" Text="Client Already Has ECC No" OnClick="btnECCNo_Click" />
                                                        <asp:Button ID="btnUSSD" CssClass="btn btn-block" runat="server" Text="SEND USSD (attempts 0)" />
                                                        <asp:Button ID="btnUpdateClient" CssClass="btn btn-block" runat="server" Text="Update Client Information" OnClick="btnUpdateClient_Click" />
                                                    </div>
                                                </div>

                                                <div class="hr-line-dashed"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>

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

            <asp:AsyncPostBackTrigger ControlID="chkProduct1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct6" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct7" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkProduct8" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkBeneficiary" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkSpouse" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkChild5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkParent4" EventName="CheckedChanged" />
    <%--        <asp:AsyncPostBackTrigger ControlID="chkFR4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR5" EventName="CheckedChanged" />--%>
            <%--<asp:AsyncPostBackTrigger ControlID="btnPremiumCalc" EventName="Click" />           
            <asp:AsyncPostBackTrigger ControlID="cmbBenefit" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIRelationship1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIBenefitAmount1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIRelationship2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIBenefitAmount2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIRelationship3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIBenefitAmount3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIRelationship4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIBenefitAmount4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIRelationship5" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbRIBenefitAmount5" EventName="SelectedIndexChanged" />
           
            <asp:AsyncPostBackTrigger ControlID="cmbFRRelationship1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRBenefitAmount1" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRRelationship2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRBenefitAmount2" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRRelationship3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRBenefitAmount3" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRRelationship4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRBenefitAmount4" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbFRRelationship5" EventName="SelectedIndexChanged" />--%>
            <%--<asp:AsyncPostBackTrigger ControlID="cmbFRBenefitAmount5" EventName="SelectedIndexChanged" />--%>
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

<%--           

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
</asp:Content>