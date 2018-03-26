<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getCordinates.aspx.cs" Inherits="getCordinates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!doctype html>
<html>
<head>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <title>Jcrop &raquo; Tutorials &raquo; Event Handler</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="jquery.Jcrop.js" type="text/javascript"></script>
    <link href="jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        jQuery(document).ready(function () {

            jQuery('#cropbox').Jcrop({
                onChange: showCoords,
                onSelect: showCoords
            });

        });

        // Simple event handler, called from onChange and onSelect
        // event handlers, as per the Jcrop invocation above
        function showCoords(c) {
            jQuery('#x1').val(c.x);
            jQuery('#y1').val(c.y);
            jQuery('#x2').val(c.x2);
            jQuery('#y2').val(c.y2);
            jQuery('#w').val(c.w);
            jQuery('#h').val(c.h);
        };

    </script>
</head>
<body>
    <img src="images/Tulips.jpg" id="cropbox" />
    <!-- This is the form that our event handler fills -->
    <form onsubmit="return false;" class="coords">
    <label>
        X1
        <input type="text" size="4" id="x1" name="x1" /></label>
    <label>
        Y1
        <input type="text" size="4" id="y1" name="y1" /></label>
    <label>
        X2
        <input type="text" size="4" id="x2" name="x2" /></label>
    <label>
        Y2
        <input type="text" size="4" id="y2" name="y2" /></label>
    <label>
        W
        <input type="text" size="4" id="w" name="w" /></label>
    <label>
        H
        <input type="text" size="4" id="h" name="h" /></label>
    </form>
    <p>
        <b>An example with a basic event handler.</b> Here we've tied several form values
        together with a simple event handler invocation. The result is that the form values
        are updated in real-time as the selection is changed, thanks to Jcrop's <em>onChange</em>
        event handler.
    </p>
    <p>
        That's how easily Jcrop can be integrated into a traditional web form!
    </p>
</body>
</html>
