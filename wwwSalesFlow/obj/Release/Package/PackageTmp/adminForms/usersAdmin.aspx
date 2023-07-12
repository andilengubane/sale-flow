<%@ Page Title="" Language="C#" MasterPageFile="~/adminForms/admin.Master" AutoEventWireup="true" CodeBehind="usersAdmin.aspx.cs" Inherits="wwwSalesFlow.adminForms.usersAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message">.</span>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                    </a>
                </li>
            </ul>
        </nav>
    </div>        
    <asp:MultiView ID="mvMain" runat="server">
        <asp:View ID="vwMain" runat="server">
            <div class="row wrapper border-bottom white-bg page-heading">
                    <div class="col-lg-10">
                        <h2>User Admin</h2>
                    </div>
                    <div class="col-lg-2">

                    </div>
                </div>

            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>All Users</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Button ID="btnAddUser" runat="server" CssClass="btn btn-default btn-info" Text="New User" OnClick="btnAddUser_Click" /></div>              
                                    <div class="col-sm-8"> 
                                        <asp:GridView ID="gvAll" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDataBound="gvAll_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="ADUserName" HeaderText="AD Username" />
                                                <asp:BoundField DataField="AgentCode" HeaderText="Agent Code" />
                                                <asp:BoundField DataField="IsAdmin" HeaderText="Admin Access" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" ToolTip="Edit user details." runat="server" CssClass="badge" OnClick="lnkEdit_Click">edit</asp:LinkButton>
                                                        &nbsp;|
                                                        <asp:LinkButton ID="lnkLanguage" runat="server" CssClass="badge" ToolTip="Edit user languages." OnClick="lnkLanguage_Click">languages</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView> 
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </asp:View>
        <asp:View ID="vwConfirm" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>Confirmation</h5>
                                    <div class="ibox-tools">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="ibox-content form-horizontal">
                                    <asp:Label ID="lblConfirmation" runat="server" CssClass="label-info" Text="confirmation message here"></asp:Label>
	                            </div>
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnOK" runat="server" CssClass="btn btn-default btn-primary" Text="Ok" OnClick="btnOK_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>User : Edit</h5>       
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">*Agent Code</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtAgentCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">AD Username</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtAdUsername" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">ID Number</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtIDNumber" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Employee Number</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtEmployeeNumber" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
                                    </div>

                                   <div class="form-group">
                                        <label class="col-sm-2 control-label">Password</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                    </div>

                                     <div class="form-group">
                                        <label class="col-sm-2 control-label">Team Leader (Agent Code)</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtTeamLeader" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                            </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Admin</label>
                                        <div class="col-sm-10">
                                            <asp:CheckBox runat="server" CssClass="form-control" ID="chkAdmin"></asp:CheckBox>
                                            </div>
                                    </div>

                                   <div class="form-group">
                                        <label class="col-sm-2 control-label">Verification Agent</label>
                                        <div class="col-sm-10">
                                            <asp:CheckBox runat="server" CssClass="form-control" ID="chkVerificationAgent"></asp:CheckBox>
                                            </div>
                                    </div>
       
                                    <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </asp:View>

        <asp:View ID="vwLanguages" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>User Language : Edit</h5>       
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">

                                    <div class="form-group">
                                        <asp:GridView ID="gvLanguages" CssClass="table table-hover no-borders" runat="server" AutoGenerateColumns="False" DataKeyNames="LanguagesID">
                                            <Columns>
                                                <asp:BoundField DataField="Title" HeaderText="Language" />
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkLanguage" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

   
                                    <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnSaveLanguage" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnSaveLanguage_Click" />
                                        <asp:Button ID="btnCancelLanguage" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </asp:View>

    </asp:MultiView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
