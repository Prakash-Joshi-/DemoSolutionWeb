<%@ Page Language="C#" AutoEventWireup="true" CodeFile="File Upload.aspx.cs" Inherits="File_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>jQuery Upload multiple files in asp.net</title>
<script src="http://code.jquery.com/jquery-1.8.2.js"></script>
<link href="Styles/uploadify.css" rel="stylesheet" type="text/css" />
<script src="Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#file_upload").uploadify({
            'swf': 'uploadify.swf',
            'uploader': 'Handler2.ashx',
            'cancelImg': 'uploadify-cancel.png',
            'buttonText': 'Select Files',
            'fileDesc': 'Image Files',
            'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
            'multi': true,
            'auto': true
        });
    })
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:FileUpload ID="file_upload" runat="server" />
</div>
</form>
</body>
</html>
