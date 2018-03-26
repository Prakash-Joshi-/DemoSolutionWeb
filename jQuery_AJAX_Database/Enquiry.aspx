<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Enquiry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <style type="text/css">
        .hidediv {
            display: none;
        }
    </style>
</head>
<body>
    <div>
        <div class="head-box" style="margin-top: -5px;">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">

                        <div id="div1" class="hidediv">
                            <h4 style="color: red">We have received your query/feedback and would soon get in touch with you.
                            <br />
                                <small>Thank you, Team RREstate</small><br />
                                <br />
                            </h4>
                        </div>
                        <div id="div2" class="search-panel">
                            <%--<script src="assets/js/validation_contactus.js"></script>--%>
                            <form id="Form2" class="form-inline" role="form" runat="server">

                                <div class="form-group">
                                    <asp:TextBox ID="txtFirstName" class="form-control" autocomplete="off" placeholder="First Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtLastName" class="form-control" autocomplete="off" placeholder="Last Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmailID" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPhone" class="form-control" placeholder="Phone number" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnSend" class="btn btnsearch" runat="server" Text="Send Enquiry"  />
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- end .col-sm-12 -->
                </div>
                <!-- ene .row -->
            </div>
        </div>
    </div>
    <%--<script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=btnSend]").bind("click", function () {
                var enquiryDetails = {};
                enquiryDetails.FirstName = $("[id*=txtFirstName]").val();
                enquiryDetails.LastName = $("[id*=txtLastName]").val();
                enquiryDetails.EmailID = $("[id*=txtEmailID]").val();
                enquiryDetails.PhoneNo = $("[id*=txtPhone]").val();
                $.ajax({
                    type: "POST",
                    url: "Enquiry.aspx/SaveUser",
                    data: '{enquiryDetails: ' + JSON.stringify(enquiryDetails) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //alert("User has been added successfully.");
                        //window.location.reload();
                    }
                });
                return false;
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $("#btnSend").click(function () {
                //$(".news").hide();
                $("#div1").show();
                $("#div2").hide();
            });
        });
    </script>
</body>
</html>
