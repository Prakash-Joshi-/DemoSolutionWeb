<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCache2.aspx.cs" Inherits="WCF_Cache_Demo.WebFormCache2" %>

<%@ OutputCache Duration="10" VaryByParam="p" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>caching varybyparam </title>
</head>
<body>
    http://asp.net-tutorials.com/caching/output-cache/
    <form id="form1" runat="server">
        <div>
            <%= DateTime.Now.ToString() %><br />
            <a href="?p=1">1</a><br />
            <a href="?p=2">2</a><br />
            <a href="?p=3">3</a><br />
        </div>
    </form>
</body>
</html>
