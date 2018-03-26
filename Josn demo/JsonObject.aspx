<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsonObject.aspx.cs" Inherits="Josn_demo.JsonObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script>
        var myJSON = '[{"host":"foo","url":"bar"},{"host":"foos","url":"bars"}]';
        var Json1 = '{"event": "addToCart","ecommerce": {"currencyCode": "GBP","add": {"products": [{"name": "product.name","id": "product.id","price": "product.price","brand": "product.brand","category": "product.category","quantity": "product.qty","list": "list"}]}}}';
        var objJson1 = $.parseJSON(Json1);
        console.log(objJson1.ecommerce.add.products[0].name);

        $.each($.parseJSON(myJSON), function (key, value) {
            
            console.log(value.url);
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
