<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Using Session.aspx.cs" Inherits="Call_javascript_from_code_behind_Using_Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function checkUser() {
            alert("User is registered");
        }
        var userStatus = '<%=Session["newUser"]%>';
        if (userStatus == 'true')
            checkUser();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Submit" runat="server" OnClick="CallJavascript" />
        </div>
    </form>
</body>
</html>
