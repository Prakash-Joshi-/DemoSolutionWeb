<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Call_javascript_from_code_behind_Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Calling POST and GET method </title>
    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script type="text/javascript">
        function myFunction() {
            //some code here
            alert('Function called successfully!');
            $.ajax({
                url: 'Default3.aspx/asdf',
                type: 'POST',
            });

            $.ajax({
                url: 'Default3.aspx/asdf',
                type: 'GET',
            });
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnServerSide" runat="server" OnClick="btnServerSide_Click"
                Text="Call Function" />
        </div>
    </form>
</body>
</html>
