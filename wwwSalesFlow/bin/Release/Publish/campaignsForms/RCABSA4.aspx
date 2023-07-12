<%@ Page Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="RCABSA4.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.RCABSA4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/js/CampaignJS/RoadCover/RCABSA4/RCABSA4.js"></script>
    <style>
        .modalCloseBtn
        {
            font-size: 45px;
        }
    </style>
    
    <div id="Navigation" class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i></a>
            </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message">Welcome to Altron People Solutions Sales App</span>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#"></a>
                </li>
            </ul>
        </nav>
    </div>

    <br />

    <asp:UpdatePanel ID="MainUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:MultiView ID="mvMain" runat="server">
                <asp:View ID="vwMain" runat="server">
                    <div id="PageHeading" class="row wrapper border-bottom white-bg page-heading">                        
                        <div class="col-lg-10">
                            <h2>RoadCover ABSA4 (RCABSA4)</h2>
                        </div>
                        <div class="col-lg-2">
                        </div>
                        <div class="col-lg-12 white-bg">
                            <button type="button" btn class="btn btn-primary" data-toggle="modal" onclick="openModal()">Send One Pager</button>                            
                        </div>
                    </div>

                    <div id="PrimaryContentWrapper" class="wrapper wrapper-content animated fadeInRight">

                        <div id="PersonalDetails" class="row">
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
                                            <label class="col-sm-2 control-label">*Product</label>
                                            <div class="col-sm-4">
                                                <asp:DropDownList ID="cmbProduct1" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">

                                            <div class="col-sm-4">
                                                <asp:HiddenField ID="hidRoadCoverLeadID" ClientIDMode="Static" runat="server"></asp:HiddenField>
                                            </div>
                                            
                                        </div>

                                        <div class="form-group">
                                                                                        
                                            <div class="col-sm-4">
                                                <asp:HiddenField ID="hidConsFileNumber" ClientIDMode="Static" runat="server"></asp:HiddenField>
                                            </div>
                                            
                                            <div class="col-sm-4">
                                                <asp:HiddenField ID="hidMemberNumber" runat="server" ></asp:HiddenField>
                                            </div>

                                        </div>

                                        <div class="form-group">
                                                                                        
                                            <div class="col-sm-4">
                                                <asp:HiddenField ID="hidDateFirstLicensed" ClientIDMode="Static" runat="server"></asp:HiddenField>
                                            </div>
                                            
                                            <div class="col-sm-4">
                                                <asp:HiddenField ID="hidAllocatedTo" runat="server"></asp:HiddenField>
                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Call Language</label>
                                            <div class="col-sm-4">
                                                <asp:DropDownList ID="cmbCallLanguage" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">

                                            <label class="col-sm-2 control-label">*Title</label>
                                            <div class="col-sm-4">
                                                <asp:DropDownList ID="cmbTitle" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                               <label class="col-sm-2 control-label">Initials</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtInitials" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Firstname</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-sm-2 control-label">*Surname</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtSurname" ClientIDMode="Static" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*ID Number</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>

                                            <label class="col-sm-2 control-label">Passport Number</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtPassportNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Date of birth</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control input-sm" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Gender</label>
                                            <div class="col-sm-4">
                                                <asp:DropDownList ID="cmbGender" runat="server" CssClass="select2_demo_3 form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="ContactDetails" class="row">
                            <div class="col-lg-12">
                                <div class="ibox float-e-margins">
                                    <!-- Section Title -->
                                    <div class="ibox-title">
                                        <h5>CONTACT DETAILS</h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                        </div>
                                    </div>

                                    <!-- Section Content -->
                                    <div class="ibox-content form-horizontal">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Mobile Tel No</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtTelCell" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" type="tel"></asp:TextBox>
                                            </div>

                                            <label class="col-sm-2 control-label">*Work Tel No</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtTelWork" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Home Tel No</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtTelHome" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" type="tel"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div id="EmailAddress" class="form-group">
                                            <label class="col-sm-2 control-label">Email Address</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Postal Address 1</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtPostalAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Postal Address 2</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtPostalAddress2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Postal Address 3</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtPostalAddress3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*City</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="col-sm-2 control-label">*Province</label>
                                            <div class="col-sm-4">
                                                <asp:DropDownList ID="cmbProvince" runat="server" CssClass="select2_demo_3 form-control"></asp:DropDownList>
                                            </div>

                                        </div>
                                        
                                        <div class="hr-line-dashed"></div>

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">*Postal Code</label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="DebitOrderDetails" class="row">
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
                                        
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Bank Name</label>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="cmbBankName" CssClass="select2_demo_3 form-control" runat="server"></asp:DropDownList>
                                                </div>

                                                <label class="col-sm-2 control-label">*Bank Branch Code</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtBankBranchCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="hr-line-dashed"></div>
                                        
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Account Holder</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtBankAccountHolder" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                                </div>
                                            </div>                                        

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Account Number</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="txtBankAccountNumber" CssClass="form-control" runat="server" MaxLength="25"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="hr-line-dashed"></div>

                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">*Debit Order Date</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox ID="DebitOrderDay" runat="server" CssClass="form-control input-sm" TextMode="Date"></asp:TextBox>
                                                    <%--<asp:DropDownList ID="cmbDebitOrderDay" CssClass="select2_demo_3 form-control" runat="server"></asp:DropDownList>--%>
                                                </div>
                                            </div>                                        
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="PremiumCalculator" class="row">
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
                                                <asp:Button ID="btnPremiumCalc" CssClass="btn btn-block" runat="server" Text="Premium Calculator" OnClick="btnPremiumCalc_Click" />
                                                <asp:Label ID="lblCalculatorPremiumAmount" runat="server" Visible="False" Text="Label" Font-Bold="True" Font-Size="Medium"></asp:Label>                                                
                                                <%--      <asp:Button ID="btnECCNo" CssClass="btn btn-block" runat="server" Text="Client Already Has ECC No" OnClick="btnECCNo_Click" />
                                                        <asp:Button ID="btnUSSD" CssClass="btn btn-block" runat="server" Text="SEND USSD (attempts 0)" />
                                                        <asp:Button ID="btnUpdateClient" CssClass="btn btn-block" runat="server" Text="Update Client Information" OnClick="btnUpdateClient_Click" />--%>
                                            </div>
                                        </div>

                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="DispoAndSubmission" class="row">
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
                                                            <asp:TextBox ID="txtScheduleDate" runat="server" TextMode="Date" CssClass="form-control" />
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-sm-3 control-label">*Time</label>
                                                        <div class="col-sm-9">
                                                            <asp:TextBox ID="txtScheduleTime" runat="server" TextMode="Time" CssClass="form-control" />
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
                    <div id="SaleHistory" class="small-chat-box fadeInRight animated" style="width: 500px!important">
                        <div class="heading" draggable="true">
                            SALE HISTORY
                        </div>

                        <div class="content" style="width: 500px!important; height: 500px!important">
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
                            <i class="fa fa-chain"></i>
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

            <%--    <asp:AsyncPostBackTrigger ControlID="chkR1" EventName="CheckedChanged" />
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
            <asp:AsyncPostBackTrigger ControlID="btnUpdateClient" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <div id="OnePagerModal" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h1 class="modal-title pull-left">Send a One-Pager</h1>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="modalCloseBtn" >&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <input type="hidden" id="opModalTitle" />
                    <input type="hidden" id="opModalSurname" />
                    <input type="hidden" id="opModalEmail">
                    <div class="text-info" id="opModalInfo"></div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="sendOpBtn">Send One-Pager</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>

    </div>
</asp:Content>


