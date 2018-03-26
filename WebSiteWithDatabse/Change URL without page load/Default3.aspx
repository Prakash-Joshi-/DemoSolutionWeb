<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Change_URL_without_page_load_Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="post" action="Default3.aspx" runat="server">

        <input id="customerName" name="customerName" type="text" />
        <input id="customerPhone" name="customerPhone" type="text" />
        <input value="Save" type="submit" />

        <asp:Button ID="btnSubmit" Text="ASP Submit" runat="server" OnClick="btnSubmit_Click" />

    </form>
</body>
</html>
