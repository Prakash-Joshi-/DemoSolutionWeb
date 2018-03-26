<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bidding.aspx.cs" Inherits="UtsavFashionBidDemo.Bidding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">--%>


    <div class="container-fluid">
        <form class="form-horizontal" role="form">
            <div class="row">
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="inputEmail" class="col-md-4 control-label">Email:</label>
                        <div class="col-md-8">
                            <input type="email" class="form-control" id="inputEmail" placeholder="Email">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="inputPassword" class="col-md-4 control-label">Password:</label>
                        <div class="col-md-8">
                            <input type="password" class="form-control" id="inputPassword" placeholder="Password">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="inputName" class="col-md-4 control-label">Name:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="inputName" placeholder="Name">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="inputItemCode" class="col-md-4 control-label">Item Code:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="inputItemCode" placeholder="Item Code">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="inputPrice" class="col-md-4 control-label">Price:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="inputPrice" placeholder="Price">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="input6" class="col-md-4 control-label">123456789012:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input6" placeholder="input 6">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="input7" class="col-md-4 control-label">12345678901234:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input7" placeholder="input 7">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="input8" class="col-md-4 control-label">1234567890123456:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input8" placeholder="input 8">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="input9" class="col-md-4 control-label">123456789012345678:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input9" placeholder="input 9">
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="form-group">
                        <label for="input10" class="col-md-4 control-label">12345678901234567890:</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input10" placeholder="input 10">
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row this actually does not appear to be needed with the form-horizontal -->
        </form>
        <p>
            Note: label text will occupy as much space as the text takes regardless of the 
      column size, so be sure to validate your spacing.
        </p>
    </div>
    <!-- /.container -->
    <%--</form>--%>
</body>
</html>
