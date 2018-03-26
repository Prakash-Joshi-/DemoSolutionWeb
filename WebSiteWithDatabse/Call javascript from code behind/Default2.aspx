<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Call_javascript_from_code_behind_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                url: '../_service.aspx/binddata',
                type: 'POST',
                data: "  {'yourDatabaseObject':" + JSON.stringify(Parameters) + "}",
                datatype: 'html',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $('a.fancybox-messageboard').fancybox({ width: 600, height: 440, closeClick: true, hideOnOverlayClick: true, href: 'http://upload.wikimedia.org/wikipedia/commons/1/1a/Bachalpseeflowers.jpg' }).trigger('click');;
                },
                error: function (request, status, err) {
                    //   alert(status);
                    //alert(err);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
