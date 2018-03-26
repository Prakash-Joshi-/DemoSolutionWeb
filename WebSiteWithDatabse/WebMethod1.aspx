<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebMethod1.aspx.cs" Inherits="WebMethod1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.2.3.min.js"></script>
    <script src="Scripts/LoadData.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px" cellpadding="10" cellspacing="10" border="0">
            <tr>
                <th align="right">
                    Departments
                </th>
                <td>
                    <select id="ddlDepartments" style="width:200px"   onchange="GetEmployeeName();">
                    </select>
                </td>
            </tr>
            <tr>
                <th align="right">
                    Employee Name
                </th>
                <td>
                    <select id="ddlEmployeeName" style="width:200px"  disabled="disabled">
                    </select>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
