<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sbBasketball.aspx.vb" Inherits="OSSAARankings.sbBasketball" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>OSSAARankings.com - Basketball</title>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Luckiest+Guy' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Michroma:400,700,300' rel='stylesheet' type='text/css'>
    <link href="http://fonts.googleapis.com/css?family=Lato:100,300,400,700" rel='stylesheet' type='text/css' />
    <meta charset="utf-8">
    <meta name="format-detection" content="telephone=no"/>
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <link rel="stylesheet" href="../css/m/grid.css">
    <link rel="stylesheet" href="../css/m/contact-form.css"/>
    <link rel="stylesheet" href="../css/m/style.css">

    <script src="js/jquery.js"></script>
    <script src="js/jquery-migrate-1.2.1.js"></script>
    <script src="js/device.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ReadOnly="true" Text="" ID="lblHeader" Font-Names="Lato" Font-Size="24px" ForeColor="Yellow" BackColor="Black" BorderStyle="None" Width="90%" style="padding-left:20px;" ></asp:TextBox>
        <asp:LinkButton ID="LinkButton0" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton6" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false" ></asp:LinkButton>
        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton9" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton10" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton11" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton12" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton13" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton14" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton15" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton16" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton17" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton18" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton19" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton20" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton21" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton22" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton23" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton24" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton25" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton26" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton27" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton28" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton29" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton30" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton31" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton32" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton33" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton34" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton35" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton36" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton37" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton38" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton39" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton40" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton41" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton42" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton43" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton44" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton45" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton46" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton47" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton48" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton49" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton50" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton51" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton52" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton53" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton54" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton55" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton56" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton57" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton58" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton59" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton60" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton61" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton62" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton63" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton64" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton65" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton66" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton67" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton68" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton69" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton70" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton71" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton72" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton73" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton74" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton75" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton76" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton77" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton78" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton79" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton80" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton81" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton82" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton83" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton84" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton85" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton86" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton87" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton88" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton89" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton90" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton91" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton92" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton93" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton94" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton95" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton96" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton97" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton98" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton99" runat="server" CssClass="mLinkButtonsb" Text="" Visible="false"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
