<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"   Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" action="Default2.aspx" method="get" runat="server">
    <input type="text" id="user" name="user" />
    <input type="text" id="Text1" name="user" />
    <input type="text" id="Text2" name="user" />
    <input type="submit" value="click" />
    <asp:TextBox runat="server" ID="txt"></asp:TextBox>
     <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
    
    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
    <asp:Button ID="Button1" Text="Button 1" runat="Server"></asp:Button>
    <asp:Button ID="Button2" Text="button 2" PostBackUrl="Default2.aspx"
        runat="Server"></asp:Button>
    </form>
</body>
</html>
