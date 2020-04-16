<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortalInfo.aspx.vb" Inherits="OSSAARankings.PortalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Info</title>
    <link href="Officials.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow ID="rowStep">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblStepPortal" Text="OSSAA Officials Information" CssClass="labelStep" >
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfo">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblPersonalInfoHeader" CssClass="shadedheaderP" Text="PERSONAL INFO" Width="500px" Height="26px"></asp:Label><br />
                    <asp:Label runat="server" ID="lblPersonalInfo" CssClass="label" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowPersonalInfoHR"><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowOfficialsInfo">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblOfficialsInfoHeader" CssClass="shadedheaderP" Text="OFFICIALS INFO" Width="500px" Height="26px"></asp:Label><br />
                    <asp:Label runat="server" ID="lblOfficialsInfo" CssClass="label" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowOfficialsInfoHR"><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow ID="rowMeetings">
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMeetingsHeader" CssClass="shadedheaderP" Text="MEETINGS INFO" Width="500px" Height="26px"></asp:Label><br />
                    <asp:Label runat="server" ID="lblMeetings" CssClass="label" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowMeetingsHR"><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
           
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessage" CssClass="labelMessage"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowButtons">
                <asp:TableCell>
                    <asp:Button runat="server" ID="cmdReturn" Text="Return to Portal Home" CssClass="button" Width="200px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
