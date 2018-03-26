<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>uploading file using jquery with generic handler ashx</title>
<script src="http://code.jquery.com/jquery-1.10.2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('#btnUpload').click(function () {
            var fileUpload = $("#FileUpload1").get(0);
            var files = fileUpload.files;
            var test = new FormData();
            for (var i = 0; i < files.length; i++) {
                test.append(files[i].name, files[i]);
            }
            $.ajax({
                url: "UploadHandler.ashx",
                type: "POST",
                contentType: false,
                processData: false,
                data: test,
                // dataType: "json",
                success: function (result) {
                    alert(result);
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });
        });
    })
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
<%--<input type="file" id="FileUpload1" /><br />--%>
<asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
<br />
<input type="button" id="btnUpload" value="Upload Files"/>
</div>
</form>
</body>
</html>