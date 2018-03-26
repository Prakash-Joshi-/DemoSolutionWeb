<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web-method-using-javascript1.aspx.cs" Inherits="WebMethod_web_method_using_javascript1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type='text/javascript'>
        function GetMessage() {
            PageMethods.Message(OnGetMessageSuccess, OnGetMessageFailure);
        }
        function OnGetMessageSuccess(result, userContext, methodName) {
            alert(result);
        }
        function OnGetMessageFailure(error, userContext, methodName) {
            alert(error.get_message());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID='ScriptManager1' runat='server' EnablePageMethods='true' />
            <div>
                <input type='submit' value='Get Message' onclick='GetMessage(); return false;' />
            </div>
        </div>
    </form>
</body>
</html>
