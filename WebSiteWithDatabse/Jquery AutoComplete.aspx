<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jquery AutoComplete.aspx.cs" Inherits="Jquery_AutoComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="UserName" />
        <input type="text" id="UserID" />
        <input type="text" id="r" />
    </div>
    </form>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" />
    <script>
        $(function () {
            $("#UserName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "Jquery AutoComplete.aspx/GetADUsers",
                        data: "{ 'strADUser' : '" + $("#UserName").val() + "'}",
                        dataType: "json",
                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) {
                            return data;
                        },
                        success: function (data) {
                            if (data.d.length == 0) {
                                $("#UserName").val('');
                            } else {
                                $("#UserName").val();
                            }
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }));
                        },
                        failure: function (response) {
                            alert(response.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                select: function (event, ui) {
                    varusrsplit = ui.item.value.split(",");
                    document.getElementById('UserName').value = '';
                    document.getElementById('UserName').value = varusrsplit[0];
                    document.getElementById('UserID').value = varusrsplit[1];
                    ui.item.value = ui.item.value.split(",")[0];
                },
                minLength: 3
            });

        });
    </script>
</body>
</html>
