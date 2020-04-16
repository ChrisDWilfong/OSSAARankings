<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewRanking.aspx.vb" Inherits="ViewRanking" title="OKRankings.com - View Ranking" %>

<%@ Register src="ucRankingAdL.ascx" tagname="ucRankingAdL" tagprefix="ucL" %>

<%@ Register src="ucRankingAdR.ascx" tagname="ucRankingAdR" tagprefix="ucR" %>

<%@ Register src="ucViewRanking.ascx" tagname="ucViewRanking" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="Server">
    <form id="formLR" runat="server">
    <table width="969" border="0" cellpadding="0" style="border-collapse: collapse; height: 542px;" id="HeaderTable" align="center"  >
        <tr align="left">
            <!-- Left Pane -->
            <td height="100%" width="170">
                <asp:Panel ID="PanelLeft" runat="server" Height="100%">
                    <table width="100%" border="1" cellpadding="0" style="border-collapse: collapse; height: 100%;" id="TableL" align="center">
                        <tr valign="top">
                            <td valign="top" style="height: 166%">
                                <ucL:ucRankingAdL ID="ucRankingAdL" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <!-- Center Pane -->
            <td height="100%">
                <asp:Panel ID="PanelCenter" runat="server" Height="100%">
                    <table width="590" border="0" cellpadding="0" style="border-collapse: collapse" id="TableCenterPane" align="center"  >
                        <tr>
                            <td valign="top" width="100%" align="center"><asp:Label ID="lblSport" 
                                    runat="server" Text="OKRankings.com " CssClass="SportHeader"></asp:Label>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Coaches Poll"></asp:Label>
                                </td>
		                <tr>
		                    <td height="100%" align="center" valign="top" width="100%">
                                <uc1:ucViewRanking ID="ucViewRanking" runat="server" />
		                    </td>
		                </tr>
		            </table>
                </asp:Panel>
            </td>
            <!-- Right Panel -->
                <td height="100%" width="170">
                    <asp:Panel ID="PanelRight" runat="server" Height="100%">
                        <table width="100%" border="1" cellpadding="0" style="border-collapse: collapse; height: 100%;" id="TableR" align="center">
                            <tr valign="top">
                                <td valign="top" style="height: 166%">
                                    <ucR:ucRankingAdR ID="ucRankingAdR" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>            
        </tr>
    </table>
    </form>
</asp:Content>

