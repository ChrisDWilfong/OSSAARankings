<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRankings.ascx.vb" Inherits="OSSAARankings.ucRankings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register src="ucScheduleListSmall.ascx" tagname="ucScheduleListSmall" tagprefix="uc1" %>

<link href="mem.css" rel="stylesheet" type="text/css" />

<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="PanelRankings" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelScheduleTeam" Radius="5" BorderColor="gray"></ajax:RoundedCornersExtender>

<asp:Panel ID="PanelScheduleTeam" runat="server" Visible="false" CssClass="panelSmall">
    <asp:Button ID="cmdClose" runat="server" Text="Close This Schedule" CssClass="button" />
    <uc1:ucScheduleListSmall ID="ucScheduleListSmall1" runat="server" />
</asp:Panel>

<asp:Label runat="server" ID="space1"><hr /></asp:Label>

<asp:Panel ID="PanelRankings" runat="server" CssClass="panelSmall" Width="825px">
    <asp:Table runat="server" ID="tblRankings" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblHeader" runat="server" CssClass="subHeader" Height="22px" style="text-align:center;" Text="Enter Rankings" Width="800px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowButton">
            <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="cmdContinue" Text="SUBMIT Your Rankings" CssClass="buttonSave" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="cmdCancel" Text="Cancel" CssClass="button" /><br />
                <asp:Label ID="lblClickOnce" runat="server" Text="ONLY CLICK SUBMIT BUTTON ONCE" CssClass="rankingsLabel" color="black"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label runat="server" ID="lblMessage" Text="" CssClass="labelMessage" font-bold="true" Font-Size="Larger"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDetail" Visible="false">
            <asp:TableCell><asp:Label ID="Label22" runat="server" Text="&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="Label21" runat="server" Text="View Selected Teams Schedule (from Green dropdown)" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell>&nbsp;</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDetail1" Visible="false">
            <asp:TableCell><asp:Label ID="Label23" runat="server" Text="&nbsp;&nbsp;" CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboViewDetail" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" BackColor="LightGreen" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
            <asp:TableCell>&nbsp;</asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3"><hr /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row1">
            <asp:TableCell width="20px"><asp:Label ID="Label1" runat="server" Text="&nbsp;1." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell Width="300px"><asp:DropDownList runat="server" ID="cboTeam1" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule1" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender1" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule1" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
            <asp:TableCell RowSpan="20" HorizontalAlign="Left" VerticalAlign="Top">
                <asp:Label ID="lblLastWeeks" runat="server" Text="<strong>Last Weeks Rankings</strong>" ForeColor="Red" Font-Names="Verdana" Font-Size="Small"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row2">
            <asp:TableCell width="20px"><asp:Label ID="Label2" runat="server" Text="&nbsp;2." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam2" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule2" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender2" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule2" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow ID="row3">
            <asp:TableCell width="20px"><asp:Label ID="Label3" runat="server" Text="&nbsp;3." CssClass="rankingsLabel"></asp:Label>
            <ajax:popupcontrolextender id="PopupControlExtender3" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule3" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>
            </asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam3" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule3" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row4">
            <asp:TableCell width="20px"><asp:Label ID="Label4" runat="server" Text="&nbsp;4." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam4" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule4" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender4" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule4" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row5">
            <asp:TableCell width="20px"><asp:Label ID="Label5" runat="server" Text="&nbsp;5." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam5" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule5" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender5" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule5" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row6">
            <asp:TableCell width="20px"><asp:Label ID="Label6" runat="server" Text="&nbsp;6." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam6" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule6" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender6" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule6" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row7">
            <asp:TableCell width="20px"><asp:Label ID="Label7" runat="server" Text="&nbsp;7." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam7" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule7" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender7" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule7" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row8">
            <asp:TableCell width="20px"><asp:Label ID="Label8" runat="server" Text="&nbsp;8." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam8" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule8" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender8" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule8" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row9">
            <asp:TableCell width="20px"><asp:Label ID="Label9" runat="server" Text="&nbsp;9." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam9" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule9" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender9" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule9" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row10">
            <asp:TableCell width="20px"><asp:Label ID="Label10" runat="server" Text="10." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam10" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule10" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender10" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule10" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row11">
            <asp:TableCell width="20px"><asp:Label ID="Label11" runat="server" Text="11." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam11" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule11" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender11" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule11" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row12">
            <asp:TableCell width="20px"><asp:Label ID="Label12" runat="server" Text="12." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam12" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule12" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender12" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule12" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row13">
            <asp:TableCell width="20px"><asp:Label ID="Label13" runat="server" Text="13." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam13" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule13" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender13" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule13" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row14">
            <asp:TableCell width="20px"><asp:Label ID="Label14" runat="server" Text="14." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam14" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule14" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender14" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule14" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row15">
            <asp:TableCell width="20px"><asp:Label ID="Label15" runat="server" Text="15." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam15" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule15" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender15" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule15" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row16">
            <asp:TableCell width="20px"><asp:Label ID="Label16" runat="server" Text="16." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam16" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule16" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender16" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule16" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row17">
            <asp:TableCell width="20px"><asp:Label ID="Label17" runat="server" Text="17." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam17" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule17" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender17" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule17" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row18">
            <asp:TableCell width="20px"><asp:Label ID="Label18" runat="server" Text="18." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam18" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule18" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender18" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule18" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row19">
            <asp:TableCell width="20px"><asp:Label ID="Label19" runat="server" Text="19." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam19" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule19" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender19" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule19" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="row20">
            <asp:TableCell width="20px"><asp:Label ID="Label20" runat="server" Text="20." CssClass="rankingsLabel"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="cboTeam20" CssClass="rankingsDropdown" DataValueField="teamID" DataTextField="school" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:ImageButton runat="server" id="imgSchedule20" ImageUrl="../images/Iconschedule.png" Width="20px" ImageAlign="Middle" OnClientClick="return false;" ></asp:ImageButton>
            <ajax:popupcontrolextender id="PopupControlExtender20" runat="server" popupcontrolid="Panel123"
                            targetcontrolid="imgSchedule20" dynamiccontextkey='<%# 0 %>' dynamiccontrolid="Panel123"
                            dynamicservicemethod="GetDynamicContent" position="Bottom">
           </ajax:popupcontrolextender>            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1">
            <asp:TableCell width="20px">&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="cmdPreviousWeeks" Text="Load Previous Weeks Rankings" CssClass="button" visible="false" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
<asp:Panel ID="Panel123" runat="server">
</asp:Panel>












