<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Change_URL_without_page_load_Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ChangeUrl(title, url) {
            if (typeof (history.pushState) != "undefined") {
                var obj = { Title: title, Url: url };
                history.pushState(obj, obj.Title, obj.Url);
            } else {
                alert("Browser does not support HTML5.");
            }
        }
    </script>
    <script type="text/javascript">
        function clientValidate() {
            alert("execute before");
            return true;
        }

        function executeAfter() {
            ChangeUrl('Default', 'Default.aspx')
            alert("execute after");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>
            <input type="button" name="Default1" value="Default1" onclick="ChangeUrl('Default1', 'Default1.aspx')" />
            <input type="button" name="Default2" value="Default2" onclick="ChangeUrl('Default2', 'Default2.aspx')" />
            <asp:Button ID="Button1" runat="server" Text="Server" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
