<%@ Page Language="VB" AutoEventWireup="false" Inherits="OSSAARankings.memSchedule" title="OSSAARankings.com - Member Schedule" Codebehind="memSchedule.aspx.vb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register src="ucLogo.ascx" tagname="ucLogo" tagprefix="ucLogo1" %>

<%@ Register src="ucMemberHeader.ascx" tagname="ucMemberHeader" tagprefix="uc1" %>

<%@ Register src="ucFooter.ascx" tagname="ucFooter" tagprefix="ucFooter1" %>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="RowHeader" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
    <div>
        <asp:Table ID="Table1" runat="server" Width="1200" HorizontalAlign="Left">
            <asp:TableRow ID="RowLogo">
                <asp:TableCell>
                    <ucLogo1:ucLogo ID="ucLogo1" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="RowHeader" BorderStyle="Solid" BorderWidth="2" VerticalAlign="Top">
                <asp:TableCell>
                    <uc1:ucMemberHeader ID="ucMemberHeader1" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="cmdAddGame" runat="server" Text="Add Game" />&nbsp;&nbsp;<asp:Button ID="cmdRefresh" runat="server" Text="Refresh Schedule" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="RowAction">
                <asp:TableCell>
                    <asp:PlaceHolder runat="server" ID="PlaceHolderAction"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="RowSchedule">
                <asp:TableCell>
                    <asp:PlaceHolder runat="server" ID="PlaceHolderSchedule"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="RowFooter">
                <asp:TableCell>
                    <ucFooter1:ucFooter ID="ucFooter1" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

