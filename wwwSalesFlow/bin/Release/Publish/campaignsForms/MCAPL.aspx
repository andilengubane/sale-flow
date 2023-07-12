<%@ Page Language="C#"  MasterPageFile="~/campaignsForms/principal.Master"  AutoEventWireup="true" CodeBehind="MCAPL.aspx.cs" Inherits="wwwSalesFlow.campaignsForms.MCAPL" %>

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
                                    <h2>MULTICHOICE - MCAPL</h2>
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
                                      <%--       <div class="form-group">
                                                    <label class="col-sm-2 control-label">Surname</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSurname" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Category</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox> </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>--%>
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
                                                    <div class="col-sm-4"><asp:TextBox ID="txtIdNumber" runat="server" CssClass="form-control input-sm" required="required"></asp:TextBox></div>
                                                </div>
                                                <div class= "hr-line-dashed"></div>
                                              <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Work Tel</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelWork" runat="server" CssClass="form-control" pattern="[0-9]{3}[0-9]{3}[0-9]{4}" required="required"></asp:TextBox>   </div>

                                                    <label class="col-sm-2 control-label">*Cell No</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtTelCell" runat="server" CssClass="form-control" type="tel" required="required"></asp:TextBox>  </div>
                                                </div>
                                                <div class="hr-line-dashed"></div>
                                             <div class="form-group">

                                                    <label class="col-sm-2 control-label">*Multichoice ID</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtMultichoiceID" runat="server" CssClass="form-control" required="required"></asp:TextBox>   </div>

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
                                            <h5>RETENTIONS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Retained</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlRetained" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Old Package</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlOldPackage" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Upgrade/Downgrade</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlUpOrDown" CssClass="form-control" runat="server">
                                                         <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Same" Value="Same"></asp:ListItem>
                                                          <asp:ListItem Text="Downgrade" Value="Downgrade"></asp:ListItem>
                                                          <asp:ListItem Text="Upgrade" Value="Upgrade"></asp:ListItem>
                                                          </asp:DropDownList></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">New Package</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlNewPackage" CssClass="form-control" runat="server">
                                                         </asp:DropDownList></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Retention Offer</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlRetentionOffer" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                                 <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>INSTALLATION REQUIREMENTS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Installation Requirements</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlInstallationRequirement" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Notes</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtInstallationNotes" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
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
                                                    <label class="col-sm-2 control-label">Suburb</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                               <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">City</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Postal Code</label>
                                                    <div class="col-sm-4"><asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


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
                                                    <label class="col-sm-2 control-label">DPP Offer</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDPPOffer" CssClass="form-control" runat="server"></asp:DropDownList></div>
                                                        </div>
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
                                                    <label class="col-sm-2 control-label">DCC ( Insurance )</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlDCCInsure" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Box Office Activation</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlBoxOfficeActivation" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                              <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Connect ID</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlConnectID" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Montly Payment Notifications</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlMontlyPaymentNotifications" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                               <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Price Increase Notification</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlPriceIncreaseNotification" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem></asp:DropDownList></div>
                                                        </div>
                                               <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">*Watched Since Last Disconnect</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlLastDisconnect" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                        <asp:ListItem Text="Live Streaming" Value="Live Streaming"></asp:ListItem>
                                                        <asp:ListItem Text="No TV" Value="No TV"></asp:ListItem>
                                                        <asp:ListItem Text="StarSat" Value="StarSat"></asp:ListItem>
                                                        <asp:ListItem Text="OVHD" Value="OVHD"></asp:ListItem>
                                                         <asp:ListItem Text="NetFlix" Value="NetFlix"></asp:ListItem>
                                                        <asp:ListItem Text="TopTV" Value="TopTV"></asp:ListItem>
                                                        <asp:ListItem Text="SABC" Value="SABC"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                               <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">What would make you comeback?</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlComeBack" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Nothing Can Retain" Value="Nothing Can Retain"></asp:ListItem>
                                                        <asp:ListItem Text="Price Decrease" Value="Price Decrease"></asp:ListItem>
                                                        <asp:ListItem Text="Unemployed" Value="Unemployed"></asp:ListItem>
                                                        <asp:ListItem Text="Will Call Us In Future" Value="Will Call Us In Future"></asp:ListItem>
                                                        <asp:ListItem Text="Free Installation" Value="Free Installation"></asp:ListItem>
                                                         <asp:ListItem Text="Require CallBack" Value="Require CallBack"></asp:ListItem>
                                                        <asp:ListItem Text="Choose Own Channels" Value="Choose Own Channels"></asp:ListItem>
                                                        <asp:ListItem Text="Payment Notice" Value="Payment Notice"></asp:ListItem>
                                                        <asp:ListItem Text="More Channels to Lower Packages" Value="More Channels to Lower Packages"></asp:ListItem>
                                                        <asp:ListItem Text="New Decoder" Value="New Decoder"></asp:ListItem>
                                                        <asp:ListItem Text="Pensioner Discount" Value="Pensioner Discount"></asp:ListItem>
                                                        <asp:ListItem Text="Not Interested" Value="Not Interested"></asp:ListItem>
                                                        <asp:ListItem Text="Sport on the Lower Packages" Value="Sport on the Lower Packages"></asp:ListItem>
                                                        <asp:ListItem Text="Happy without DSTV" Value="Happy without DSTV"></asp:ListItem>
                                                        <asp:ListItem Text="Away from Home" Value="Away from Home"></asp:ListItem>
                                                         <asp:ListItem Text="Cannot Afford" Value="Cannot Afford"></asp:ListItem>
                                                         <asp:ListItem Text="Free DSTV 1 Month" Value="Free DSTV 1 Month"></asp:ListItem>
                                                         <asp:ListItem Text="Discount on Overdue Amount" Value="Discount on Overdue Amount"></asp:ListItem>
                                                         <asp:ListItem Text="Free Dish" Value="Free Dish"></asp:ListItem>
                                                         <asp:ListItem Text="Full Channel Access for a Day" Value="Full Channel Access for a Day"></asp:ListItem>
                                                         <asp:ListItem Text="More Days Before Disconnect" Value="More Days Before Disconnect"></asp:ListItem>
                                                         <asp:ListItem Text="More Channels" Value="More Channels"></asp:ListItem>
                                                         <asp:ListItem Text="More Competitions & Freebies" Value="More Competitions & Freebies"></asp:ListItem>
                                                         <asp:ListItem Text="Never at Home" Value="Never at Home"></asp:ListItem>
                                                         <asp:ListItem Text="Payment Reversal" Value="Payment Reversal"></asp:ListItem>
                                                         <asp:ListItem Text="Poor Service" Value="Poor Service"></asp:ListItem>
                                                         <asp:ListItem Text="Reconnect at a Later Stage" Value="Reconnect at a Later Stage"></asp:ListItem>
                                                         <asp:ListItem Text="Reduce Over Due Amount" Value="Reduce Over Due Amount"></asp:ListItem>
                                                         <asp:ListItem Text="Scheduled Upgrade" Value="Scheduled Upgrade"></asp:ListItem>
                                                         <asp:ListItem Text="Sport Channels Only" Value="Sport Channels Only"></asp:ListItem>
                                                         <asp:ListItem Text="Unsure what can Retain" Value="Unsure what can Retain"></asp:ListItem>

                                                                          </asp:DropDownList></div>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                              <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox float-e-margins">
                                        <div class="ibox-title">
                                            <h5>INSTALLATION REQUIREMENTS</h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content form-horizontal">

                                            <div class="form-group">
                                                    <label class="col-sm-2 control-label">Reason for leaving</label>
                                                    <div class="col-sm-4"><asp:DropDownList ID="ddlLeaveReason" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                        <asp:ListItem Text="Cannot afford DSTV" Value="Cannot afford DSTV"></asp:ListItem>
                                                        <asp:ListItem Text="Currently Out of Country" Value="Currently Out of Country"></asp:ListItem>
                                                        <asp:ListItem Text="Had a problem with DSTV account" Value="Had a problem with DSTV account"></asp:ListItem>
                                                        <asp:ListItem Text="Has DSTV on someone else’s name" Value="Has DSTV on someone else’s name"></asp:ListItem>
                                                        <asp:ListItem Text="Moved into a house with DSTV" Value="Moved into a house with DSTV"></asp:ListItem>
                                                        <asp:ListItem Text="Not always home to watch " Value="Not always home to watch "></asp:ListItem>
                                                        <asp:ListItem Text="Too many repeats" Value="Too many repeats"></asp:ListItem>
                                                        <asp:ListItem Text="Unemployed" Value="Unemployed"></asp:ListItem>
                                                        <asp:ListItem Text="Watching Netflix" Value="Watching Netflix"></asp:ListItem>
                                                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                                                                          </asp:DropDownList></div>
                                                        </div>
                                             <div class="hr-line-dashed"></div>
                                              <div class="form-group">
                                                    <label class="col-sm-2 control-label">Other TV Channels</label>
                                                     <div class="col-sm-4"><asp:DropDownList ID="ddlOtherTVChannels" CssClass="form-control" runat="server">
                                                         <asp:ListItem Text="[ Please Select ]" Value="[ Please Select ]"></asp:ListItem>
                                                         <asp:ListItem Text="Client is not watching anything" Value="Client is not watching anything"></asp:ListItem>
                                                         <asp:ListItem Text="Live Streaming" Value="Live Streaming"></asp:ListItem>
                                                         <asp:ListItem Text="Netflix online" Value="Netflix online"></asp:ListItem>
                                                         <asp:ListItem Text="OVHD Decoder" Value="OVHD Decoder"></asp:ListItem>
                                                         <asp:ListItem Text="Radio" Value="Radio"></asp:ListItem>
                                                         <asp:ListItem Text="Reads Books" Value="Reads Books"></asp:ListItem>
                                                         <asp:ListItem Text="Show Max online" Value="Show Max online"></asp:ListItem>
                                                         <asp:ListItem Text="Watched DSTV on someone else’s account" Value="Watched DSTV on someone else’s account"></asp:ListItem>
                                                         <asp:ListItem Text="Watched movies on the hard drive" Value="Watched movies on the hard drive"></asp:ListItem>
                                                         <asp:ListItem Text="Watches SABC Channels" Value="Watches SABC Channels"></asp:ListItem>
                                                         <asp:ListItem Text="Watching DVD's" Value="Watching DVD's"></asp:ListItem>
                                                                           </asp:DropDownList></div>
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
                                                      <div class="col-sm-4"><asp:TextBox ID="txtDatePromisedPay" runat="server"  CssClass="form-control input-sm" TextMode="Date"></asp:TextBox></div>
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
