<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCoachesSports.ascx.vb" Inherits="OSSAARankings.ucCoachesSports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link rel="stylesheet" type="text/css" href="../mem/mem.css">
<ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelCoachesSportsList" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<asp:Panel ID="PanelCoachesSportsList" runat="server" CssClass="panelSmall">
    <ContentTemplate>
        <asp:Table ID="tblCoachesSportsList" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" Text="Assign Coaches to Sports" Width="100%"></asp:Label>
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
                    <asp:Label ID="lblAcademic" runat="server" CssClass="perInfoLabel" Width="250px" Text="Academic Bowl"></asp:Label><br />
                    <asp:DropDownList ID="cboAcademic" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBaseballFall" runat="server" CssClass="perInfoLabel" Width="250px" Text="Baseball (Fall)"></asp:Label><br />
                    <asp:DropDownList ID="cboBaseballFall" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBaseballSpring" runat="server" CssClass="perInfoLabel" Width="250px" Text="Baseball (Spring)"></asp:Label><br />
                    <asp:DropDownList ID="cboBaseballSpring" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBasketballBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Basketball (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboBasketballBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBasketballGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Basketball (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboBasketballGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCheerleading" runat="server" CssClass="perInfoLabel" Width="250px" Text="Cheerleading"></asp:Label><br />
                    <asp:DropDownList ID="cboCheerleading" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCrossCountryBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Cross Country (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboCrossCountryBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCrossCountryGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Cross Country (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboCrossCountryGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFootball" runat="server" CssClass="perInfoLabel" Width="250px" Text="Football"></asp:Label><br />
                    <asp:DropDownList ID="cboFootball" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFastPitch" runat="server" CssClass="perInfoLabel" Width="250px" Text="Fast Pitch Softball"></asp:Label><br />
                    <asp:DropDownList ID="cboFastPitch" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGolfBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Golf (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboGolfBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGolfGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Golf (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboGolfGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSlowPitch" runat="server" CssClass="perInfoLabel" Width="250px" Text="Slow Pitch Softball"></asp:Label><br />
                    <asp:DropDownList ID="cboSlowPitch" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSoccerBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Soccer (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboSoccerBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSoccerGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Soccer (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboSoccerGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSwimmingBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Swimming (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboSwimmingBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSwimmingGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Swimming (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboSwimmingGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTennisBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Tennis (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboTennisBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTennisGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Tennis (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboTennisGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTrackBoys" runat="server" CssClass="perInfoLabel" Width="250px" Text="Track (Boys)"></asp:Label><br />
                    <asp:DropDownList ID="cboTrackBoys" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTrackGirls" runat="server" CssClass="perInfoLabel" Width="250px" Text="Track (Girls)"></asp:Label><br />
                    <asp:DropDownList ID="cboTrackGirls" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblVolleyball" runat="server" CssClass="perInfoLabel" Width="250px" Text="Volleyball"></asp:Label><br />
                    <asp:DropDownList ID="cboVolleyball" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblWrestling" runat="server" CssClass="perInfoLabel" Width="250px" Text="Wrestling"></asp:Label><br />
                    <asp:DropDownList ID="cboWrestling" runat="server" CssClass="DropDown" Width="250px" DataValueField="MemberID" DataTextField="FullName" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select Coach...</asp:ListItem>                                    
                    </asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:Panel>

