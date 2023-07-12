<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/adminForms/login.Master" CodeBehind="login.aspx.cs" Inherits="wwwSalesFlow.adminForms.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         
    <asp:MultiView ID="mvMain" runat="server">
        <asp:View ID="vwMain" runat="server">
            <div class="row wrapper border-bottom white-bg page-heading">
                    <div class="col-lg-10">
                        <h2>Sales Flow Admin</h2>
                    </div>
                    <div class="col-lg-2">

                    </div>
                </div>

           <div class="wrapper wrapper-content">       
                <div class="row">

                    <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins" id="getSalesDiv" runat="server">
                        <div class="ibox-title">
                            <h5>Login</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                
                            </div>
                        </div>
                        <div class="ibox-content">
                               
                          <table style="width: 100%">
                                       <tr><td> 
                                          
                                           <asp:TextBox ID="txtAgentCode" runat="server" placeholder="Agent Code"  class="form-control" TextMode="Number"></asp:TextBox><br />
                                           </td>

                                       </tr>
                                         <tr><td> 
                                               <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" class="form-control"></asp:TextBox><br />
                                            </td></tr>
                              <tr><td>
                                  <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label></td></tr>
                                   </table>
                                   
                                </div>
                                              <br />     
                                <asp:Button ID="btnLogin" runat="server" class="btn btn-w-m btn-primary" Text="Login" OnClick="btnLogin_Click1" />

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