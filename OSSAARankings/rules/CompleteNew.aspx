<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CompleteNew.aspx.vb" Inherits="OSSAARankings.CompleteNew" ClientTarget="uplevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblComplete" runat="server" Font-Bold="True" 
            Font-Size="XX-Large" Text="COMPLETION"></asp:Label>
    
    </div>
    <p>
        <asp:Label ID="lblComplete0" runat="server" Font-Bold="True" Font-Size="Medium" 
            Text="You have completed the OSSAA Rules Meeting.&lt;br&gt;Confirmation of your completion of this meeting has been sent to the OSSAA office. &lt;br&gt;You will receive an automated email from OSSAA to confirm receipt.<br><br>"></asp:Label>
        <asp:Label ID="lblComplete1" runat="server" Font-Bold="True" 
            Font-Size="Medium" ForeColor="Maroon"
            Text="CLICK NEXT BELOW TO CONTINUE..."></asp:Label>  
  </p>
    </form>
</body>
</html>
