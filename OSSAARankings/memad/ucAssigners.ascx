<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucAssigners.ascx.vb" Inherits="OSSAARankings.ucAssigners" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<link rel="stylesheet" type="text/css" href="../memad/mem.css">

<ajax:RoundedCornersExtender ID="RoundedCornersExtender32" runat="server" TargetControlID="PanelCoachesAssignersList" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>

<asp:Panel ID="PanelCoachesAssignersList" runat="server" CssClass="panelSmall" >
    <ContentTemplate>
        <asp:Table ID="tblCoachesSportsList" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="Your Assigner of Officials" Width="60%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                <asp:Button ID="cmdSave" runat="server" Text="SAVE CHANGES" CssClass="buttonSave" />&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBaseball" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="BASEBALL : "></asp:Label>
                    <asp:TextBox ID="strBaseball" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBasketball" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="BASKETBALL : "></asp:Label>
                    <asp:TextBox ID="strBasketball" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFootball" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="FOOTBALL : "></asp:Label>
                    <asp:TextBox ID="strFootball" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSoccer" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="SOCCER : "></asp:Label>
                    <asp:TextBox ID="strSoccer" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSoftball" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="SOFTBALL : "></asp:Label>
                    <asp:TextBox ID="strSoftball" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblVolleyball" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="VOLLEYBALL : "></asp:Label>
                    <asp:TextBox ID="strVolleyball" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblWrestling" runat="server" CssClass="perInfoLabel" font-size="14px" Width="125px" Text="WRESTLING : "></asp:Label>
                    <asp:TextBox ID="strWrestling" runat="server" CssClass="DropDown" width="450px" MaxLen="200" ></asp:TextBox>
                </asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:Panel>

