<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Change_URL_without_page_load_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <script type="text/javascript">
        function ChangeUrl(title, url) {
            if (typeof(history.pushState)!="undefined") {
                var obj = { Title: title, Url: url };
                history.pushState(obj, obj.Title, obj.Url);
            } else {
                alert("Browser does not support HTML5.");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" name="Default1" value="Default1" onclick="ChangeUrl('Default1','Default1.aspx')" />
            <input type="button" name="Default2" value="Default2" onclick="ChangeUrl('Default2','Default2.aspx')" />
        </div>
    </form>
</body>
</html>
