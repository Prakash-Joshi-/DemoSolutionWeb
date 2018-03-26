<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JQueryCropImage.aspx.cs"
    Inherits="JQueryCropImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>jQuery Crop Image using crop plugin</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.2.js"></script>
    <script src="jquery.Jcrop.js" type="text/javascript"></script>
    <link href="jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        /*
        $(function () {
            $('#imgcrop').Jcrop({
                onSelect: getcroparea,
                boxWidth: 450,
                boxHeight: 800,
                onSelect: showCoords,
                onChange: showCoords,
                bgColor: 'red',
                bgOpacity: .4,
                maxSize: [300, 300],
                minSize: [120, 120],
                setSelect: [470, 500, 50, 50],
                aspectRatio: 16 / 9
            });
        })
        */
        $(function () {
            $('#imgcrop').Jcrop({
                
                bgColor: 'red',
                bgOpacity: .4,
                onSelect: showCoords,
                onChange: showCoords,
                onSelect: getcroparea
            });
        })
        function getcroparea(c) {
            $('#hdnx').val(c.x);
            $('#hdny').val(c.y);
            $('#hdnw').val(c.w);
            $('#hdnh').val(c.h);
        };
        function showCoords(c) {
            jQuery('#x1').val(c.x);
            jQuery('#y1').val(c.y);
            jQuery('#x2').val(c.x2);
            jQuery('#y2').val(c.y2);
            jQuery('#w').val(c.w);
            jQuery('#h').val(c.h);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>
            X1
            <input type="text" size="4" id="x1" name="x1" runat="server" /></label>
        <label>
            Y1
            <input type="text" size="4" id="y1" name="y1" runat="server" /></label>
        <label>
            X2
            <input type="text" size="4" id="x2" name="x2" runat="server" /></label>
        <label>
            Y2
            <input type="text" size="4" id="y2" name="y2" runat="server" /></label>
        <label>
            W
            <input type="text" size="4" id="w" name="w" runat="server" /></label>
        <label>
            H
            <input type="text" size="4" id="h" name="h" runat="server" /></label>
    </div>
    <div>
        <img src="images/Tulips.jpg" id="imgcrop" alt="sample image" />
        <input type="hidden" id="hdnx" runat="server" />
        <input type="hidden" id="hdny" runat="server" />
        <input type="hidden" id="hdnw" runat="server" />
        <input type="hidden" id="hdnh" runat="server" />
        <asp:Button ID="btncrop" runat="server" OnClick="btncrop_Click" Text="Crop Images" />
        <img id="imgcropped" runat="server" visible="false" />
    </div>
    </form>
</body>
</html>
