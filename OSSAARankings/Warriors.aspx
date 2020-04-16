<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Warriors.aspx.vb" Inherits="OSSAARankings.Warriors" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size:xx-large;
            color: #FF0000;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
            font-weight:bold;
        }
        .style4
        {
            width: 341px;
            height: 336px;
            vertical-align:top;
        }
        .style5
        {
            width: 336px;
            height: 400px;
        }
        .style6
        {
            width: 800px;
            height: 65px;
        }
    </style>
</head>
<body>
<form target="paypal" action="https://www.paypal.com/cgi-bin/webscr" method="post">
<input type="hidden" name="cmd" value="_s-xclick" />
<input type="hidden" name="hosted_button_id" value="39563CCBT9DEC" />
<table>
<tr><td class="style1" colspan="2">
    <img alt="" class="style6" src="images/TitleSmall.png" /></td></tr>
<tr style="background-color:lightgray;"><td class="style3">Front of WHITE Shirt</td><td class="style3">Back of WHITE Shirt</td></tr>
<tr><td>
    <img alt="" class="style4" src="images/TribePrideFinalSmall.png" /></td>
 <td><img alt="" 
        class="style5" src="images/TribePrideBackSmall.png" /></td></tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr style="background-color:lightgray;"><td class="style3">Front of GRAY Shirt</td><td class="style3">Back of GRAY Shirt</td></tr>
<tr><td style="vertical-align:top;">
    <img alt="" class="style4" src="images/TribePrideBWFront.jpg" /></td>
 <td><img alt="" 
        class="style5" src="images/TribePrideBWBack.jpg" /></td></tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr style="background-color:lightgray;"><td class="style2" colspan="2">PayPal payment process...</td></tr>
<tr><td class="style3" colspan="2">Select your size(s) below, add to your cart and checkout when done.</td></tr>
<tr><td><input type="hidden" name="on0" value="Short - Long">Short - Long</td></tr><tr><td><select name="os0">
	<option value="WHITE - Short Sleeve">WHITE - Short Sleeve $15.00 USD</option>
	<option value="WHITE - Long Sleeve">WHITE - Long Sleeve $18.00 USD</option>
	<option value="GRAY - Short Sleeve">GRAY - Short Sleeve $15.00 USD</option>
</select> </td></tr>
<tr><td><input type="hidden" name="on1" value="Sizes">Sizes</td></tr><tr><td><select name="os1">
	<option value="3XL">3XL </option>
	<option value="2XL">2XL </option>
	<option value="XL">XL </option>
	<option value="L">L </option>
	<option value="M">M </option>
	<option value="S">S </option>
	<option value="Youth L">Youth L </option>
	<option value="Youth M">Youth M </option>
	<option value="Youth S">Youth S </option>
</select> </td></tr>
</table>
<input type="hidden" name="currency_code" value="USD">
<input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_cart_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>
</body>
</html>
