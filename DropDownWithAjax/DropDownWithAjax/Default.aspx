<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bind dropdown in javascript by server side method</title>
    <link href="Style/Style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="script/jquery-1.6.1.js"></script>
    <script language="javascript" type="text/javascript" src="script/LoadData.js"></script>
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
                    <select id="ddlEmployeeName"style="width:200px"  disabled="disabled">
                    </select>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
