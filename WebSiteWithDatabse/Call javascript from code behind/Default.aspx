<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Call_javascript_from_code_behind_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function myFunction() {
            //some code here
            alert('Function called successfully!');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4>Call JavaScript function from code-behin in Asp.net</h4>
        <div>
            <asp:Button ID="btnServerSide" runat="server" OnClick="btnServerSide_Click"
                Text="Call Function" />
        </div>
    </form>
</body>
</html>
