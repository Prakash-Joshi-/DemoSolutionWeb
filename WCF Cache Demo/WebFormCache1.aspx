<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCache1.aspx.cs" Inherits="WCF_Cache_Demo.WebFormCache1" %>

<%@ OutputCache Duration="30" varybyparam="none" Location="Server" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataGrid ID="MyDataGrid" runat="server"
            Width="900"
            BackColor="#ccccff"
            BorderColor="black"
            ShowFooter="false"
            CellPadding="3"
            CellSpacing="0"
            Font-Names="Verdana"
            Font-Size="8pt"
            HeaderStyle-BackColor="#aaaadd"
            EnableViewState="false" />

        <i>Page last generated on:</i>
        <asp:Label ID="TimeMsg" runat="server" />

    </form>
</body>
</html>
