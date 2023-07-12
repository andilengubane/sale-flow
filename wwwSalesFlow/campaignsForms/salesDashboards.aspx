<%@ Page Title="" Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="salesDashboards.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.salesDashboards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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

            <asp:MultiView ID="mvMain" runat="server" ActiveViewIndex="0">
                <asp:View ID="vwMain" runat="server">

                    <div class="row wrapper border-bottom white-bg page-heading">
                            <div class="col-lg-10">
                                <h2>Daily Sales Dashboard</h2>
                            </div>
                            <div class="col-lg-2">

                            </div>
                        </div>

                    <div class="wrapper wrapper-content animated fadeInRight">
                        <div class="panel col-md-12">
                            <div class="panel-heading">
                                <H3>Filters</H3>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group-sm">
                                            <label class="control-label" for="cmbCampaignFilter">Campaign</label>
                                            <asp:DropDownList ID="cmbCampaignFilter" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbCampaignFilter_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group-sm">
                                            <label class="control-label" for="cmbAgentFilter">Agent</label>
                                            <asp:DropDownList ID="cmbAgentFilter" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbAgentFilter_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <div class="widget style1">
                                        <div class="row p-m">
                                            <div class="col-4 text-center">
                                                <i class="fa fa-trophy fa-5x"></i>
                                            </div>
                                            <div class="col-8 text-center">
                                                <span> Vetting</span>     
                                                <h2 class="font-bold"> <asp:Label ID="lblVetting" runat="server" Text="Zero"></asp:Label></h2>
                                            </div>
                                        </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="widget style1 navy-bg" style="box-shadow: 1px 1px 5px grey;">
                                    <div class="row p-m">
                                        <div class="col-4">
                                            <i class="fa fa-area-chart fa-5x"></i>
                                        </div>
                                        <div class="col-8 text-right">
                                            <span> Current Month total </span>
                                            <h2 class="font-bold">
                                                <asp:Label ID="lblCurrentMonthCurrentCampaignSuccess" runat="server" Text="0"></asp:Label>
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="widget style1 yellow-bg" style="box-shadow: 1px 1px 5px grey;">
                                    <div class="row p-m">
                                        <div class="col-4">
                                            <i class="fa fa-hourglass fa-5x"></i>
                                        </div>
                                        <div class="col-8 text-right">
                                            <span>Agent call-back</span>
                                            <h2 class="font-bold"><asp:Label ID="lblAgentCallback" runat="server" Text="Zero"></asp:Label></h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="widget style1 red-bg" style="box-shadow: 1px 1px 5px grey;"> 
                                    <div class="row p-m">
                                        <div class="col-4">
                                            <i class="fa fa-ambulance fa-5x"></i>
                                        </div>
                                        <div class="col-8 text-right">
                                            <span> Re-Try </span>
                                            <h2 class="font-bold">
                                                <asp:Label ID="lblRetryCount" runat="server" Text="Zero"></asp:Label></h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="widget white-bg no-padding" style="box-shadow: 1px 1px 5px grey;">
                                    <div class="p-m">
                                        <h1 class="m-xs">Retry List</h1>
                                        <asp:GridView ID="gvRetry" runat="server" CssClass="table-hover" Width="100%" AutoGenerateColumns="False" EmptyDataText="&lt;div class=&quot;col-md-12 text-center&quot;&gt;&lt;small&gt;No sales to retry.&lt;/small&gt;&lt;/div&gt;" DataKeyNames="ID,CampaignName" BorderStyle="None" GridLines="Horizontal">
                                            <Columns>
                                                <asp:BoundField DataField="CampaignName" HeaderText="Campaign" />
                                                <asp:BoundField DataField="UpdateBy" HeaderText="UpdatedBy" />
                                                <asp:BoundField DataField="UpdateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="UpdateTime" />
                                                <asp:BoundField DataField="Comment" HeaderText="Comment" />
                                                <asp:BoundField DataField="ID" HeaderText="Sale ID" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="widget lazur-bg no-padding" style="box-shadow: 1px 1px 5px grey;">
                                    <div class="p-m">
                                        <h1 class="m-xs">210</h1>

                                        <h3 class="font-bold no-margins">
                                            Monthly income
                                        </h3>
                                        <small>Income form project Beta.</small>
                                    </div>
                                    <div class="flot-chart">
                                        <div class="flot-chart-content" id="flot-chart2"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="widget white-bg no-padding" style="box-shadow: 1px 1px 5px grey;">
                                    <div class="p-m">
                                        <h1 class="m-xs">Sales Status</h1>
                                        <asp:GridView ID="gvStepStatus" runat="server" CssClass="table-hover" Width="100%" AutoGenerateColumns="False" EmptyDataText="&lt;div class=&quot;col-md-12 text-center&quot;&gt;&lt;small&gt;No sales to retry.&lt;/small&gt;&lt;/div&gt;" BorderStyle="None" GridLines="Horizontal" >
                                            <Columns>
                                                <asp:BoundField DataField="StepName" HeaderText="Step" />
                                                <asp:BoundField DataField="TotalSales" HeaderText="TotalSales">
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="badge" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:GridView>
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
