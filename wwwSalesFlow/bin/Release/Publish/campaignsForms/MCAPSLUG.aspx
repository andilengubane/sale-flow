<%@ Page Title="" Language="C#" MasterPageFile="~/campaignsForms/principal.Master" AutoEventWireup="true" CodeBehind="MCAPSLUG.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.MCAPSLUG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
        </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message">Welcome to Altron People Solutions Sales App.</span>
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
                                    <h2>MULTICHOICE - MCAPSLUG</h2>
                                </div>
                                <div class="col-lg-2">

                                </div>
                            </div>

                        <div class="wrapper wrapper-content animated fadeInRight">

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>CLIENT DETAILS</h5>
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
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" required="required"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                                <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurname" runat="server" CssClass="form-control  input-sm" required="required"></asp:TextBox></div>

                                                    <label class="col-sm-2 control-label">*ID Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm" required="required" TextMode="Number" MaxLength="13"></asp:TextBox></div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                                              <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Work Tel</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelWork" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" required="required" TextMode="Number"></asp:TextBox>   </div>

                                                    <label class="col-sm-2 control-label">*Cell No</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelCell" runat="server" CssClass="form-control" type="tel" required="required"></asp:TextBox>  </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                             <div class="form-group" style="visibility:hidden">

                                                    <label class="col-sm-2 control-label">*Product</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="DPP" Value="DPP"></asp:ListItem>
                                                        </asp:DropDownList>
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
                                            <h5>ADDRESS DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                          
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Address Line 1</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                     <label class="col-sm-2 control-label">Address Line 2</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">City</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Suburb</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Postal Code</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control input-sm" TextMode="Number" MaxLength="6"></asp:TextBox></div>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                     <%--       <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>COLECTION PLAN</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Payment Method</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlPaymentMethod" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="USSD" Value="USSD"></asp:ListItem>
                                                        <asp:ListItem Text="EFT" Value="EFT"></asp:ListItem>
                                                        <asp:ListItem Text="Debit Order" Value="Debit Order"></asp:ListItem>
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Adhoc Debit Order" Value="Adhoc Debit Order"></asp:ListItem>
                                                        <asp:ListItem Text="EFT" Value="EFT"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Will customer buy Hardware from Retailer?</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlWillcustomerbuyHardwarefromRetailer" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Escalated to Field Services for installation</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlEscalatedtoFieldServicesforinstallation" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Capture Customers residential address</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlCaptureCustomersresidentialaddress" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>

                                        </div>
                                    </div>
                                </div>
                            </div>--%>

                         <%--   <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>PACKAGE DETAILS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Old Package</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlOldPackage" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="USSD" Value="USSD"></asp:ListItem>
                                                        <asp:ListItem Text="EFT" Value="EFT"></asp:ListItem>
                                                        <asp:ListItem Text="Debit Order" Value="Debit Order"></asp:ListItem>
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                        <asp:ListItem Text="Adhoc Debit Order" Value="Adhoc Debit Order"></asp:ListItem>
                                                        <asp:ListItem Text="EFT" Value="EFT"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Upgrade / Downgrade</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlUpgrade" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Upgrade" Value="Upgrade"></asp:ListItem>
                                                        <asp:ListItem Text="Downgrade" Value="Downgrade"></asp:ListItem>
                                                        <asp:ListItem Text="Same" Value="Same"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">New Package</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlNewPackage" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">New Addon Package</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlAdons" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Zee TV Add-on" Value="Zee TV Add-on"></asp:ListItem>
                                                        <asp:ListItem Text="South Indian Add-on" Value="South Indian Add-on"></asp:ListItem>
                                                        <asp:ListItem Text="Indian Add-on" Value="Indian Add-on"></asp:ListItem>
                                                        <asp:ListItem Text="Portuguese Add-on" Value="Portuguese Add-on"></asp:ListItem>
                                                        <asp:ListItem Text="Portuguese + Indian Add-on" Value="Portuguese + Indian Add-on"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>

                                 


                              <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>ADDITIONAL SALE OPPORTUNITIES</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">DPP OffeR</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlOffer" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Debit Order</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDebitOrder" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">*DCC Insurance</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDCCInsurance" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">R50 once off discount offered</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDiscountOffered" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">R50 once off discount Accepted</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDiscountAccepted" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Salary Date Aligned</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlSalaryDate" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Customer only interested in locking services</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlCustomeronlyinterestedinlockingservices" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                     <label class="col-sm-2 control-label">*Financial Account Number</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtFinancialAccountNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                            <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                     <label class="col-sm-2 control-label">Money To Pay</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtMoneyToPay" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Money Paid</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtMoneyPaid" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                               <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Date Promised to Pay</label>
                                                      <div class="col-sm-4"><asp:TextBox ID="txtDatePromisedtoPay" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
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
                                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-primary pull-right" />
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
                                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save - For Later" CssClass="btn btn-info pull-right" />
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

          <%--  <asp:AsyncPostBackTrigger ControlID="chkProduct1" EventName="CheckedChanged" />
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
            <asp:AsyncPostBackTrigger ControlID="chkParent4" EventName="CheckedChanged" />--%>
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
       <script>
       function validateID() {

            var ex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;

            var theIDnumber = document.getElementById("<%=txtIdNumber.ClientID%>").value;
            if (ex.test(theIDnumber) == false) {
                alert('Please provide a valid ID number.');
                return false;
            }
        }
    </script>
</asp:Content>
