<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="WCF_Demo_WebForms.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server" class="form-horizontal" role="form">

            <div class="row">
                <label for="inputEmail" class="col-xs-6 col-lg-4 control-label">Item Name:</label>
                <div class="col-xs-6 col-lg-4">
                    <asp:TextBox ID="txtItemName" class="form-control" placeholder="Enter Item Name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label for="inputEmail" class="col-xs-6 col-lg-4 control-label">Ship Country:</label>
                <div class="col-xs-6 col-lg-4">
                    <asp:TextBox ID="txtShipCountry" class="form-control" placeholder="Enter Ship Country" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label for="inputEmail" class="col-xs-6 col-lg-4 control-label">Item Name:</label>
                <div class="col-xs-6 col-lg-4">
                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Enter Item Name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label for="inputEmail" class="col-xs-6 col-lg-4 control-label">Item Name:</label>
                <div class="col-xs-6 col-lg-4">
                    <asp:Button ID="btnSubmit" class="btn-primary" Text="Submit" runat="server" OnClick="btnSubmit_Click"></asp:Button>
                </div>
            </div>

        </form>
    </div>
</body>
</html>
