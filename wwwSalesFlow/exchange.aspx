<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exchange.aspx.cs" Inherits="wwwSalesFlow.exchange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>

    <title>Sales</title>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet"/>

    <!-- Toastr style -->
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet"/>

    <!-- Gritter -->
    <link href="js/plugins/gritter/jquery.gritter.css" rel="stylesheet"/>

    <link href="css/animate.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!--
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
            </div> -->

            <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>ALTRON - Bytes People Solutions</h2>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

            <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>SYSTEM ERROR !!!</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-ambulance"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="alert-danger">
                            <asp:Label ID="lblMessage" runat="server" Text="Campaign Not Found<br/>Notify systems support" CssClass="danger" Font-Size="15px" Font-Bold="True"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
     </div>
    </form>
</body>
</html>
