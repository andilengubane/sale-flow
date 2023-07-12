<%@ Page Title="" Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="RCNEDD.aspx.cs" Inherits="wwwSalesFlow.RCNEDD" %>

<%--<%@ Register Assembly="ddmControls" Namespace="ddmControls" TagPrefix="cc1" %>--%>

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
                                    <h2>RoadCover Nedbank (RCNEDD)</h2>
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

                                                    <label class="col-sm-2 control-label">*Title</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="cmbTitle" CssClass="form-control" runat="server"></asp:DropDownList></div>

                                                    <label class="col-sm-2 control-label">*Firstname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control"></asp:TextBox> </div>
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
                                                        <asp:DropDownList ID="cmbBenefit" runat="server" CssClass="select2_demo_3 form-control"></asp:DropDownList>
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
                                        <h5>Rider Individual / <small> MEMBER ADD-ON</small></h5>
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
                                                        <span class="badge">&nbsp;Rider 1:&nbsp;<asp:CheckBox ID="chkR1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkR1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtRISurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtRIName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtRISecondName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbRIGender1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>	
                                                        <div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtRIIdNumber1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtRIDateOfBirth1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbRIRelationship1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Rider 2:&nbsp;<asp:CheckBox ID="chkR2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkR2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtRISurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtRIName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtRISecondName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbRIGender2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtRIIdNumber2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtRIDateOfBirth2" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbRIRelationship2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Rider 3:&nbsp;<asp:CheckBox ID="chkR3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkR3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtRISurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtRIName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtRISecondName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbRIGender3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtRIIdNumber3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtRIDateOfBirth3" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbRIRelationship3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Rider 4:&nbsp;<asp:CheckBox ID="chkR4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkR4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtRISurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtRIName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtRISecondName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbRIGender4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtRIIdNumber4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtRIDateOfBirth4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbRIRelationship4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Rider 5:&nbsp;<asp:CheckBox ID="chkR5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkR5_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtRISurname5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtRIName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtRISecondName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbRIGender5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtRIIdNumber5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtRIDateOfBirth5" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbRIRelationship5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
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
                                        <h5>Rider / <small> FAMILY ADD-ON</small></h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>

                                        </div>
                                    </div>
                                    <div class="ibox-content form-horizontal">
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Family Rider 1:&nbsp;<asp:CheckBox ID="chkFR1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkFR1_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtFRSurname1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtFRName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtFRSecondName1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbFRGender1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtFRIdNumber1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtFRDateOfBirth1" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbFRRelationship1" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Family Rider 2:&nbsp;<asp:CheckBox ID="chkFR2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkFR2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtFRSurname2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtFRName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtFRSecondName2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbFRGender2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtFRIdNumber2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtFRDateOfBirth2" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbFRRelationship2" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Family Rider 3:&nbsp;<asp:CheckBox ID="chkFR3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkFR3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtFRSurname3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtFRName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtFRSecondName3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbFRGender3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtFRIdNumber3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtFRDateOfBirth3" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbFRRelationship3" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Family Rider 4:&nbsp;<asp:CheckBox ID="chkFR4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkFR4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtFRSurname4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtFRName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtFRSecondName4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbFRGender4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtFRIdNumber4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtFRDateOfBirth4" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbFRRelationship4" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div class="row">
                                            <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Family Rider 5:&nbsp;<asp:CheckBox ID="chkFR5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkFR5_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Surname</label>
                                                            <asp:TextBox ID="txtFRSurname5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Name</label>
                                                            <asp:TextBox ID="txtFRName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">SecondName</label>
                                                            <asp:TextBox ID="txtFRSecondName5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
														<div class="form-group">
                                                            <label class="control-label">Gender</label>
                                                            <asp:DropDownList ID="cmbFRGender5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                                                        </div>														
														<div class="form-group">
                                                            <label class="control-label">ID Number</label>
                                                            <asp:TextBox ID="txtFRIdNumber5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Date of Birth</label>
                                                            <asp:TextBox ID="txtFRDateOfBirth5" runat="server" CssClass="form-control" TextMode="Date" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Relationship to Member</label>
                                                            <asp:DropDownList ID="cmbFRRelationship5" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
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
                                                        <asp:Button ID="btnPremiumCalc" CssClass="btn btn-block" runat="server" Text="Premium Calculator" />
                                                        <asp:Button ID="btnECCNo" CssClass="btn btn-block" runat="server" Text="Client Already Has ECC No" OnClick="btnECCNo_Click" />
                                                        <asp:Button ID="btnUSSD" CssClass="btn btn-block" runat="server" Text="SEND USSD (attempts 0)" />
                                                        <asp:Button ID="btnUpdateClient" CssClass="btn btn-block" runat="server" Text="Update Client Information" OnClick="btnUpdateClient_Click" />
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

            <asp:AsyncPostBackTrigger ControlID="chkR1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkR2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkR3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkR4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkR5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkFR5" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnECCNo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdateClient" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

