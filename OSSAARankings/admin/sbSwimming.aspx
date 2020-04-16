<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sbSwimming.aspx.vb" Inherits="OSSAARankings.sbSwimming" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Scoreboard Admin : Swimming</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table id="tblName" runat="server" Width="960px">
            <asp:TableRow><asp:TableCell><asp:Label ID="Label2" runat="server" Text="State Swimming Admin" Font-Names="Verdana" Font-Size="20pt" ForeColor="Navy" Font-Bold="true"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><asp:Label ID="Label1" runat="server" Text="Tournament:" Font-Names="Verdana" Font-Size="16pt" ForeColor="Maroon"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><asp:DropDownList ID="cboDetail" runat="server" DataTextField="strDisplay" DataValueField="Id" Font-Names="Verdana" Font-Size="28pt" BackColor="#FFFF99"  AutoPostBack="True"></asp:DropDownList>&nbsp;
            <asp:Button ID="cmdGo" runat="server" Text="Load Tourney" Font-Names="Verdana" Font-Size="28pt" Width="350px" />&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="<< Step 1" Font-Names="Verdana" Font-Size="24pt" ForeColor="Red" Font-Bold="true" ></asp:Label>
            </asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="intScore1" runat="server" Width="150px" Font-Bold="True" Font-Names="Verdana" Font-Size="28pt" ForeColor="Red" BackColor="#FFFF99">
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdSave" runat="server" Text="Save" Font-Names="Verdana" Font-Size="28pt" />&nbsp;&nbsp;
                    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" Font-Names="Verdana" Font-Size="28pt" />&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="<< Step 2" Font-Names="Verdana" Font-Size="24pt" ForeColor="Red" Font-Bold="true" ></asp:Label>     
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow><asp:TableCell><asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="28pt" ForeColor="Red"></asp:Label></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="Oklahoma Secondary School Activities Association" Font-Names="Verdana" Font-Size="12pt"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label CssClass="labels" ID="Label23" runat="server" Text="PDF File:" Font-Names="Verdana" Font-Size="12pt"  ></asp:Label>
                    <asp:FileUpload id="FileUpload1"  runat="server" Width="400px"> </asp:FileUpload>&nbsp;&nbsp;
                    <asp:Button id="UploadButton" AutoPostBack="true" Text="Upload PDF" runat="server"></asp:Button>&nbsp;
                    <asp:Label id="UploadStatusLabel"   forecolor="Red" runat="server"></asp:Label>&nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" Text="<< Step 3" Font-Names="Verdana" Font-Size="24pt" ForeColor="Red" Font-Bold="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
        </asp:Table>
    </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    </form>
</body>
</html>
