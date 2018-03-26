<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Change_URL_without_page_load_Default6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-2.2.3.min.js"></script>
    <script type="text/javascript">
        function emailCheck(current) {
            var $email = $(current).val();
            var emailReg = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (!emailReg.test($email)) {
                emailFlag = 1;
                return false;
            } else {
                return true;
            }
        }
        $('#btnsubmit').click(function () {
            var result = emailCheck($('#txtemail').text);
            if (result) {
                $.ajax({
                    url: "default6.aspx",
                    type: 'POST',
                    data: { name: $('#txtname').val(), email: $('#txtemail').val },
                    success: function (response) {
                        $('#answers').html(response);
                    }
                });
            }

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="txtname" />
            <input type="text" id="txtemail" />
            <input type="button" id="btnsubmit" name="Default1" value="Default1" />
        </div>
    </form>
</body>
</html>
