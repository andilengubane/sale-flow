<%@ Page Title="" Language="C#" MasterPageFile="~/adminForms/admin.Master" AutoEventWireup="true" CodeBehind="campaignAdmin.aspx.cs" Inherits="wwwSalesFlow.adminForms.campaignAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowSliderValue()
        {
            document.getElementById("ContentPlaceHolder1_lblSweepValue").innerText = document.getElementById("ContentPlaceHolder1_txtSweepPercentage").value + ' %';
        }
    </script>
    <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message"> </span>
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
                        <h2>Campaign Admin</h2>
                    </div>
                    <div class="col-lg-2">

                    </div>
                </div>

            <div class="wrapper wrapper-content animated fadeInRight">

                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>All Campaigns</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnAddCampaign" runat="server" CssClass="btn btn-default btn-info" Text="New Campaign" OnClick="btnAddCampaign_Click" /></div>              

                                    <div class="col-md-offset-1 col-md-9">
                                        <asp:GridView ID="gvAll" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="CampaignID" OnRowDataBound="gvAll_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Title" HeaderText="Campaign" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" ToolTip="Edit Campaign record details." runat="server" OnClick="lnkEdit_Click" CssClass="badge">edit</asp:LinkButton>&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lnkWorkFlowStep" runat="server" OnClick="lnkWorkFlowStep_Click" ToolTip="Edit campaign workflow steps" CssClass="badge">steps</asp:LinkButton>&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lnkPricing" runat="server" OnClick="lnkPricing_Click" ToolTip="Edit campaign pricing and benefits" CssClass="badge">pricing</asp:LinkButton>&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lnkRelationshipTypes" runat="server" CssClass="badge" OnClick="lnkRelationshipTypes_Click">Relationships</asp:LinkButton>&nbsp;|&nbsp;
                                                        <asp:LinkButton ID="lnkWorkflowNextStep" runat="server" CssClass="badge" OnClick="lnkWorkflowNextStep_Click" >Workflow Next Step</asp:LinkButton>
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
                                <h5>Campaign : Edit</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">

                                    <div class="form-group">
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">*Campaign ID {viciDIAL}</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignID" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                            </div></div>   
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">*Campaign Name</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignName" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">*Campaign Group</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="cmbCampaignGroup" CssClass="form-control" runat="server" DataTextField="Title" DataValueField="ClientsID"></asp:DropDownList>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">Description</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                            </div></div>

                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">Active</label>
                                        <div class="col-sm-10">
                                            <asp:CheckBox ID="chkActive" CssClass="form-control" runat="server" />
                                             </div></div>

                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">Capture Form</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCaptureForm" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>

                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">Sweep Percentage</label>
                                        <div class="col-sm-7">
                                            <asp:TextBox ID="txtSweepPercentage" onchange="ShowSliderValue()" CssClass="form-control" TextMode="Range" Min="0" Max="100" MaxLength="3" runat="server"></asp:TextBox>
                                             </div>
                                            <div class="col-sm-3">
                                                <asp:Label runat="server" ID="lblSweepValue" CssClass="badge"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">*Final Status</label>
                                        <div class="col-sm-10">
                                            <asp:DropDownList ID="cmbFinalStatus" CssClass="form-control" runat="server" DataTextField="StepName" DataValueField="WorkflowID"></asp:DropDownList>
                                             </div></div>

                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 1</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 2</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting2" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 3</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting3" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 4</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting4" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 5</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting5" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 6</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting6" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>
                                        <div class="form-group">
                                        <label class="col-sm-2 control-label">CampaignSetting 7</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCampaignSetting7" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                             </div></div>


                                        <div class="hr-line-dashed"></div>
                                            <div class="col-sm-2 btn-block">
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
        <asp:View ID="vwWorkFlowSteps" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">        
                                <h5>Campaign Workflow Steps [<asp:Label ID="lblWorkflowCampaign" runat="server" Text="CampaignName"></asp:Label>] : Edit</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="form-group">
                                    <div class="form-group">
                                    <label class="col-sm-2 control-label">Choose Applicable Steps</label>
                                    <div class="col-sm-10">
                                        <asp:GridView ID="gvWorkFlow" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkflowID">
                                            <Columns>
                                                <asp:BoundField DataField="StepName" HeaderText="Workflow Step" />
                                                <asp:TemplateField HeaderText="Allow"><ItemTemplate><asp:CheckBox ID="chkAllow" runat="server" /></ItemTemplate></asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div></div>
                                        
                                    <div class="hr-line-dashed"></div>
                                        <div class="col-sm-2 btn-block">
                                            <asp:Button ID="btnWorkFlowSave" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnWorkFlowSave_Click" />
                                            <asp:Button ID="btnWorkFlowCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                        </div>   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </asp:View>

        <asp:View ID="vwPricing" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">        
                                <h5>Campaign Pricing (Primary Member) : [<asp:Label ID="lblPricingCampaign" runat="server" Text="CampaignName"></asp:Label>] : Edit</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="form-group">
                                    <div class="form-group">
                                    <label class="col-sm-2 control-label">Premium Amount</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPremium" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div></div>
                                    
                                    <div class="form-group">
                                    <label class="col-sm-2 control-label">Benefit</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtBenefit" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                        
                                    <div class="hr-line-dashed"></div>
                                        <div class="col-sm-2 btn-block">
                                            <asp:Button ID="btnPricingSave" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnPricingSave_Click" />
                                            <asp:Button ID="btnPricingCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                        </div>   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </asp:View>

        <asp:View ID="vwNextStepEdit" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">        
                                <h5>Workflow next step auto-advance : [<asp:Label ID="lblNextStepEditCampaignName" runat="server" Text="CampaignName"></asp:Label>] : Edit</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-11">
                                        <asp:GridView ID="gvNextStep" runat="server" DataKeyNames="CampaignWorkflowStepsID,WorkflowStepID,CampaignID" CssClass="table table-hover" AutoGenerateColumns="False" EmptyDataText="<div class='jumbotron text-center'><span>No data found.</span></div>" OnRowDataBound="gvNextStep_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="WorkFlowStepName" HeaderText="Current WorkflowStep" />
                                                <asp:TemplateField HeaderText="Next Step Name">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="cmbNextStep" runat="server" CssClass="form-control ">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle BorderStyle="None" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="row">
                                    <div class="col-sm-2 btn-block">
                                    <asp:Button ID="btnNextStepSave" CssClass="btn btn-default" runat="server" Text="Save" OnClick="btnNextStepSave_Click" />
                                    <asp:Button ID="btnNextStepCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnNextStepCancel_Click" />
                                </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
        </asp:View>

        <asp:View ID="vwSubMemberRelationships" runat="server">
            <div class="wrapper wrapper-content animated fadeInRight">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">        
                                <h5>Campaign Sub Member Relationships [<asp:Label ID="lblSubMemberRelationships" runat="server" Text="CampaignName"></asp:Label>] : Edit</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content form-horizontal">
                                <div class="form-group">
                                    <div class="form-group">
                                    <label class="col-sm-2 control-label">Choose Applicable Sub Member Relationships</label>
                                    <div class="col-sm-10">
                                        <asp:GridView ID="gvSubMemberRelationships" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="RelationshipTypeID">
                                            <Columns>
                                                <asp:BoundField DataField="Title" HeaderText="Relationships" />
                                                <asp:TemplateField HeaderText="Allow" >
                                                    <ItemTemplate>
                                                        <div class="form-horizontal">
                                                            <div class="col-md-1">
                                                                <asp:CheckBox ID="chkAllow"  AutoPostBack="true" runat="server" ToolTip="Click to enable/disable" OnCheckedChanged="chkAllow_CheckedChanged" />
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-horizontal">
                                                                    <asp:Label ID="Label1" runat="server" Text="Premium" CssClass="control-label"></asp:Label>
                                                                    <asp:TextBox ID="txtPremiumRelation" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-7">
                                                                <div class="form-horizontal">
                                                                    <asp:Label ID="Label2" runat="server"  Text="Benefit" CssClass="control-label"></asp:Label>
                                                                    <asp:TextBox ID="txtBenefitRelation" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div></div>
                                        
                                    <div class="hr-line-dashed"></div>
                                        <div class="col-sm-2 btn-block">
                                            <asp:Button ID="btnSaveRelationships" runat="server" CssClass="btn btn-default" Text="Save" OnClick="btnSaveRelationships_Click" />
                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
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
