<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web-method-using-javascript.aspx.cs" Inherits="WebMethod_web_method_using_javascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function HandleIT() {
            var name = document.getElementById('<%=txtname.ClientID %>').value;
            var address = document.getElementById('<%=txtaddress.ClientID %>').value;
            PageMethods.ProcessIT(name, address, onSucess, onError); 
            function onSucess(result) {
                alert(result);
            }
            function onError(result) {
                alert('Something wrong.');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" Text="Signup" OnClientClick="HandleIT(); return false;" />
        </div>
    </form>
</body>
</html>
