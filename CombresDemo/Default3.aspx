<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form2" runat="server">
    <div>
        <h1>
            Without Combres</h1>
    </div>
    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                    My ASP.NET Application
                </h1>
            </div>
            <div class="loginDisplay">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        [ <a href="~/Account/Login.aspx" id="HeadLoginStatus" runat="server">Log In</a>
                        ]
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        Welcome <span class="bold">
                            <asp:LoginName ID="HeadLoginName" runat="server" />
                        </span>! [
                        <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                            LogoutPageUrl="~/" />
                        ]
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
            <div class="clear hideSkiplink">
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false"
                    IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" />
                        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About" />
                    </Items>
                </asp:Menu>
            </div>
        </div>
        <div class="main">
            <h2>
                Welcome to ASP.NET!
            </h2>
            <p>
                To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">
                    www.asp.net</a>.
            </p>
            <p>
                You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
                    title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
            </p>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="footer">
    </div>
    </form>
</body>
</html>
