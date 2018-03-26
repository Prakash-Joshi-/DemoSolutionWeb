<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCache3.aspx.cs" Inherits="WCF_Cache_Demo.WebFormCache3" %>

<%@ OutputCache Duration="120" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>cache substitution</title>
</head>
<body>
    http://asp.net-tutorials.com/caching/output-cache-substitution/
    <form id="form1" runat="server">
        Cached datestamp:<br />
        <%= DateTime.Now.ToString() %><br />
        <br />
        Fresh datestamp:<br />
        <asp:Substitution runat="server" ID="UnCachedArea" MethodName="GetFreshDateTime" />
    </form>
</body>
</html>
