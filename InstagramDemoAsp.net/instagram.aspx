<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instagram.aspx.cs" Inherits="InstagramDemoAsp.net.instagram" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                        <img src='<%# Eval("SmallImage") %>' alt='<%# Eval("Caption") %>' />
                        <p><%# Eval("Tags") %></p>
                        <p>&hearts; <%# Eval("Likes") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
