<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Change_URL_without_page_load_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <script type="text/javascript">
        function ChangeUrl(page, url) {
            if (typeof (history.pushState) != "undefined") {
                var obj = { Page: page, Url: url };
                history.pushState(obj, obj.Page, obj.Url);
            } else {
                alert("Browser does not support HTML5.");
            }
        }
        $(function () {
            $("#button1").click(function () {
                ChangeUrl('Page1', 'Default1.aspx');
            });
            $("#button2").click(function () {
                ChangeUrl('Page2', 'Default2.aspx');
            });
            $("#button3").click(function () {
                ChangeUrl('Page3', 'Default3.aspx');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="Default1" id="button1" />
            <input type="button" value="Default2" id="button2" />
            <input type="button" value="Default3" id="button3" />
        </div>
    </form>
</body>
</html>
