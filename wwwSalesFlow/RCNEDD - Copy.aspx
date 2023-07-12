<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="RCNEDD.aspx.cs" Inherits="wwwSalesFlow.RCNEDD" %>
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

    <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>FNB FUNERAL REFRESH Capture Form</h2>
            </div>
            <div class="col-lg-2">

            </div>
        </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
        <div class="col-lg-7">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Individual / <small> Family</small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12 b-r">
                            <form role="form">
                                <div class="form-group"><label>*FNB Funeral Cover for</label> 
                                    <select class="select2_demo_3 form-control">
                                        <option>None Selected</option>
                                        <option value="individual">Individual</option>
                                        <option value="family">Family</option>
                                    </select>

                                </div>
                                <div class="form-group"><label>Recommended Benefit</label> <input type="text" placeholder="Enter Benefit" class="form-control"></div>
                                <div class="form-group"><label>*Gross Income</label> <input type="text" placeholder="Enter gross income" class="form-control"></div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <div class="col-lg-5">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Plan</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>

                        </div>
                    </div>
                    <div class="ibox-content">
                        <form class="form-horizontal">
                            <div class="form-group"><label>Suggested Plan</label> <input type="text" placeholder="Enter Plan" class="form-control"></div>
                            <div class="form-group"><label>Account Type</label> <input type="text" placeholder="Enter Account Type" class="form-control"></div>
                            <div class="form-group"><label>Preferred Debit Order</label> <input type="text" placeholder="Enter Debit Order" class="form-control"></div>
                                
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>PLAN HOLDER DETAILS</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Title</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Initials</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Second Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Marital Status</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="married">Married</option>
                                        <option value="single">Single</option>
                                        <option value="separated">Separated</option>
                                        <option value="widow">Widow</option>
                                        <option value="widower">Widower</option>
                                        <option value="other">Other</option>
                                    </select>

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*RSA ID Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Gender</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Postal Address 1</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Postal Address 2</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Suburb/Town</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Postal Code</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Cellphone Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Work Tel Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Personal Tel Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Email Address</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>
                                </div>

                            </div>

                        </form>
                    </div>



                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>SPOUSE DETAILS</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="form-group">

                                <label class="col-sm-2 control-label">Title</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Initials</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Second Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Marital Status</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="married">Married</option>
                                        <option value="single">Single</option>
                                        <option value="separated">Separated</option>
                                        <option value="widow">Widow</option>
                                        <option value="widower">Widower</option>
                                        <option value="other">Other</option>
                                    </select>

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">RSA ID Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>

                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>
                            <div class="ibox-title">
                                <h5>Child 1</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 2</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 3</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 4</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 5</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 6</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 7</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Child 8</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>
 
                        </form>
                    </div>



                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>PARENT(S)/PARENT(S) IN-LAW</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="ibox-title">
                                <h5>Parent 1</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Parent 2</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Parent 3</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Parent 4</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                        </form>
                    </div>



                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Extended Family</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="ibox-title">
                                <h5>Extended Family 1</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 2</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 3</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 4</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 5</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 6</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 7</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                            <div class="ibox-title">
                                <h5>Extended Family 8</h5>
                            </div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>                                
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                                <label class="col-sm-2 control-label">Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Benefit</label>
                                <div class="col-sm-10">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="R20 000">R20 000</option>
                                        <option value="R30 000">R30 000</option>
                                        <option value="R40 000">R40 000</option>
                                        <option value="R50 000">R50 000</option>
                                        <option value="R60 000">R60 000</option>
                                        <option value="R70 000">R70 000</option>
                                        <option value="R50 000">R80 000</option>
                                        <option value="R60 000">R90 000</option>
                                        <option value="R70 000">R100 000</option>
                                    </select>

                                </div>

                            </div>

                        </form>
                    </div>



                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>BENEFICIARY DETAILS</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Title</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Initials</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Surname</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*First Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Second Name</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Gender</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Gender</option>
                                        <option value="male">Male</option>
                                        <option value="female">Female</option>
                                    </select>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">*RSA ID Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Date of Birth</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Cellphone Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Work Tel Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">

                                <label class="col-sm-2 control-label">Personal Tel Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">Email Address</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>
                            </div>
                            <div class="hr-line-dashed"></div>
 
                        </form>
                    </div>



                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>DEBIT ORDER DETAILS</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <form method="get" class="form-horizontal">

                            <div class="form-group">

                                <label class="col-sm-2 control-label">*Account Number</label>
                                <div class="col-sm-4"><input type="text" class="form-control"></div>

                                <label class="col-sm-2 control-label">*Debit Order Date</label>
                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option></option>
                                        <option value="1">1</option>
                                        <option value="2">1</option>
                                        <option value="3">3</option>
                                        <option value="4">4</option>
                                        <option value="5">5</option>
                                        <option value="6">6</option>
                                        <option value="7">7</option>
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                </select>

                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                                
                                
                            <div class="form-group">

                                <div class="col-sm-4">
                                    <select class="select2_demo_3 form-control">
                                        <option>Select Status</option>
                                        <option value="sale">Sale</option>
                                        <option value="incomplete">Incomplete</option>
                                    </select>
                                </div>
                                <div class="col-sm-4"><button class="btn btn-primary" type="submit">Submit</button></div>

                            </div>
                        </form>
                    </div>



                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

