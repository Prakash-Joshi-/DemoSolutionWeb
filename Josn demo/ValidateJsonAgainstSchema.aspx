<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateJsonAgainstSchema.aspx.cs" Inherits="Josn_demo.ValidateJsonAgainstSchema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInputSchema" runat="server" TextMode="MultiLine" Rows="10" Columns="70" placeholder="Enter Schema to validate"></asp:TextBox>
            <asp:Button ID="btnValidateJosn" runat="server" Text="Validate Json" OnClick="btnValidateJosn_Click" />
            <asp:TextBox ID="txtInputJson" runat="server" TextMode="MultiLine" Rows="10" Columns="70" placeholder="Enter Json to validate"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblIsValid" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
<!--
{
 'status': {'type': 'string'},
 'error': {'type': 'string'},
 'code': {'type': 'string'}
}
-->

<!--
{
    "error": {
        "status": "error message",
        "code": "999"
    }
}-->