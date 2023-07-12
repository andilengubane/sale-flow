<%@ Page Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="VODAINUP.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.VODAINUP" %>

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
                                    <h2>VODACON - UPSELL (VODAINUP)</h2>
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

                                                    <label class="col-sm-2 control-label">*Firstname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" required="required"></asp:TextBox> </div>

                                                       <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" required="required"></asp:TextBox></div>
                                                </div>
                                                <div class="hr-line-dashed"></div>

                                                <div class="form-group">
                                                    <label class="col-sm-2 control-label">*MSISDN</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm" required="required"></asp:TextBox></div>

                                                      <label class="col-sm-2 control-label">*Alternative Number 1</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAltNum1" runat="server" CssClass="form-control" type="tel" ></asp:TextBox>  </div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                                              <div class="form-group">
                                                       <label class="col-sm-2 control-label">*Alternative Number 2</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAltNum2" runat="server" CssClass="form-control" type="tel" ></asp:TextBox>  </div>                                                  
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
                                            <h5>DEAL DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Subs ID</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSubsID" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                            <label class="col-sm-2 control-label">CONN</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCONN" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                      <div class="form-group">
                                                            <label class="col-sm-2 control-label">Device 1</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtDevice1Name" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                                                    <div class="form-group">
                                                            <label class="col-sm-2 control-label">Device 2</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtDevice2Name" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Insurance Cover</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtInsuranceCver" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                             <div class="form-group">
                                                            <label class="col-sm-2 control-label">Date Ref</label>
                                                   <div class="col-sm-4"><asp:TextBox ID="txtDateRef" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox> </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                            <label class="col-sm-2 control-label">Has Recurring Bundle</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtRecurringBundle" runat="server" CssClass="form-control"></asp:TextBox> </div>
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
                                        <h5>DEVICES <small> </small></h5>
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
                                                        <span class="badge">&nbsp;Device 1:&nbsp;<asp:CheckBox ID="chkDevice1" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkDevice1_CheckedChanged"/></span></h4>
                                                    <div class="panel-body">                                                        
                                                        <div class="form-group">
                                                            <label class="control-label">Device 1</label>
                                                            <asp:TextBox ID="txtDevice1" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Device 1 Premium</label>
                                                            <asp:TextBox ID="txtDevice1Premium" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Device 2:&nbsp;<asp:CheckBox ID="chkDevice2" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkDevice2_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                        <div class="form-group">
                                                            <label class="control-label">Device 2</label>
                                                            <asp:TextBox ID="txtDevice2" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Device 2 Premium</label>
                                                            <asp:TextBox ID="txtDevice2Premium" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Device 3:&nbsp;<asp:CheckBox ID="chkDevice3" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkDevice3_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">Device 3</label>
                                                            <asp:TextBox ID="txtDevice3" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Device 3 Premium</label>
                                                            <asp:TextBox ID="txtDevice3Premium" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-heading col-sm-6">
                                                    <h4><span class="badge">&nbsp;Device 4:&nbsp;<asp:CheckBox ID="chkDevice4" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkDevice4_CheckedChanged" /></span></h4>
                                                    <div class="panel-body">
                                                       <div class="form-group">
                                                            <label class="control-label">Device 4</label>
                                                            <asp:TextBox ID="txtDevice4" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Device 4 Premium</label>
                                                            <asp:TextBox ID="txtDevice4Premium" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="hr-line-dashed"></div>
                                            <div class="row">
                                                <div class="panel-heading col-sm-6 img-shadow">
                                                    <h4><span class="badge">&nbsp;Device 5:&nbsp;<asp:CheckBox ID="chkDevice5" CssClass="badge" Text="" runat="server" AutoPostBack="True" OnCheckedChanged="chkDevice5_CheckedChanged"/></span></h4>
                                                    <div class="panel-body">
                                                         <div class="form-group">
                                                            <label class="control-label">Device 5</label>
                                                            <asp:TextBox ID="txtDevice5" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Device 5 Premium</label>
                                                            <asp:TextBox ID="txtDevice5Premium" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
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

            <asp:AsyncPostBackTrigger ControlID="chkDevice1" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkDevice2" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkDevice3" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkDevice4" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="chkDevice5" EventName="CheckedChanged" />           

        </Triggers>
    </asp:UpdatePanel>

</asp:Content>