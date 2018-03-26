<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vbcode.aspx.vb" Inherits="vbcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>jQuery Crop Image using crop plugin</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="jquery.Jcrop.js" type="text/javascript"></script>
    <link href="jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function() {
        $('#imgcrop').Jcrop({
        onSelect: getcroparea
            });
        })

        function getcroparea(c) {
            $('#hdnx').val(c.x);
            $('#hdny').val(c.y);
            $('#hdnw').val(c.w);
            $('#hdnh').val(c.h);
        };
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="images/pool.jpg" id="imgcrop" alt="sample image"/>
        <input type="hidden" id="hdnx" runat="server" />
        <input type="hidden" id="hdny" runat="server"/>
        <input type="hidden" id="hdnw" runat="server"/>
        <input type="hidden" id="hdnh" runat="server" />
        <asp:Button ID="btncrop" runat="server" OnClick="btncrop_Click" Text="Crop Images" />
        <img id="imgcropped" runat="server" visible="false" />
    </div>
    </form>
</body>
</html>
