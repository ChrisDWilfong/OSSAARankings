<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sbSwimmingState.aspx.vb" Inherits="OSSAARankings.sbSwimmingState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Swimming STATE Scoreboard</title>
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
    <form id="form1" runat="server" style="margin-top:-20px; margin-bottom:10px;">
    <div>
        <div class="btn-wr">
            <div class="caption">
            <br />
            <asp:Label ID="Header1" runat="server" CssClass="headTitle" Font-Bold="true" Text="2017 OSSAA STATE" ForeColor="Yellow" style="text-align:center;"></asp:Label>
            <br />
            <asp:Label ID="Header2" runat="server" CssClass="headTitle" Font-Bold="true" Text="SWIMMING RESULTS" ForeColor="Yellow" style="text-align:center;"></asp:Label>
            <br />
            <asp:Label ID="Header3" runat="server" CssClass="headTitle" Font-Bold="true" Text="February 17-18, 2017" ForeColor="Yellow"  style="text-align:center;"></asp:Label>
            <br />

            <asp:Button runat="server" ID="Button1" CssClass="btn btn__mod wow fadeInLeft" Text="Button 1" />
            <asp:Button runat="server" ID="Button2" CssClass="btn btn__mod wow fadeInRight" Text="Button 2" />

            <asp:Button runat="server" ID="Button3" CssClass="btn btn__mod wow fadeInLeft" Text="Button 3"/>
            <asp:Button runat="server" ID="Button4" CssClass="btn btn__mod wow fadeInRight" Text="Button 4" />

            <asp:Label runat="server" ID="aBlank" Text="<br><br><br><br>"></asp:Label>

            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
