<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRosterAdd.ascx.vb" Inherits="OSSAARankings.ucRosterAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<link rel="stylesheet" type="text/css" href="mem.css">
<asp:UpdatePanel ID="UpdatePanelRosterAdd" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="lblHeader" Radius="3" BorderColor="gray"></ajax:RoundedCornersExtender>
    <asp:Table runat="server" ID="tblHome" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblHeader" runat="server" CssClass="headerSmall" Height="24px" style="text-align:center;" Text="Edit / Add Roster" Width="100%"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Button ID="cmdCancel" runat="server" CssClass="button" Text="Cancel" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdSaveChanges" runat="server" Text="SAVE CHANGES" CssClass="buttonSave" />&nbsp;&nbsp;
                <asp:Button ID="cmdDelete" runat="server" Text="DELETE" CssClass="buttonDelete" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell colspan="3">
                <asp:Label ID="lblMessage" runat="server" CssClass="labelMessage" ForeColor="Red" Font-Bold="True"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowName1" Visible="true">
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblFirstName" runat="server" CssClass="perInfoLabel" Width="145px">FIRST NAME<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="lblLastName" runat="server" CssClass="perInfoLabel" Width="125px">LAST NAME<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowName2" Visible="true">
            <asp:TableCell ColumnSpan="3">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="perInfoText" Width="120px"></asp:TextBox></asp:Label>
                <asp:Label ID="lblSpace1" runat="server" CssClass="perInfoLabel" Width="10px">&nbsp;</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="perInfoText" Width="120px"></asp:TextBox></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblPosition" runat="server" CssClass="perInfoLabel" Width="125px">MAIN POSITION<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="lblSpace2" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:Label ID="lblHeight" runat="server" CssClass="perInfoLabel">HEIGHT<span style="color:Red;"> *</span></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:DropDownList ID="cboPosition" runat="server" CssClass="DropDown" Width="120px" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:DropDownList ID="cboHeight" runat="server" CssClass="DropDown" >
                    <asp:ListItem Selected="True">Select...</asp:ListItem>                                    
                    <asp:ListItem>4-11</asp:ListItem>
                    <asp:ListItem>5-0</asp:ListItem>
                    <asp:ListItem>5-1</asp:ListItem>
                    <asp:ListItem>5-2</asp:ListItem>
                    <asp:ListItem>5-3</asp:ListItem>
                    <asp:ListItem>5-4</asp:ListItem>
                    <asp:ListItem>5-5</asp:ListItem>
                    <asp:ListItem>5-6</asp:ListItem>
                    <asp:ListItem>5-7</asp:ListItem>
                    <asp:ListItem>5-8</asp:ListItem>
                    <asp:ListItem>5-9</asp:ListItem>
                    <asp:ListItem>5-10</asp:ListItem>
                    <asp:ListItem>5-11</asp:ListItem>
                    <asp:ListItem>6-0</asp:ListItem>
                    <asp:ListItem>6-1</asp:ListItem>
                    <asp:ListItem>6-2</asp:ListItem>
                    <asp:ListItem>6-3</asp:ListItem>
                    <asp:ListItem>6-4</asp:ListItem>
                    <asp:ListItem>6-5</asp:ListItem>
                    <asp:ListItem>6-6</asp:ListItem>
                    <asp:ListItem>6-7</asp:ListItem>
                    <asp:ListItem>6-8</asp:ListItem>
                    <asp:ListItem>6-9</asp:ListItem>
                    <asp:ListItem>6-10</asp:ListItem>
                    <asp:ListItem>6-11</asp:ListItem>
                    <asp:ListItem>7-0</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblGrade" runat="server" CssClass="perInfoLabel" Width="70px">GRADE<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="Label2" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:Label ID="lblJersey" runat="server" CssClass="perInfoLabel">JERSEY #<span style="color:Red;"> *</span></asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:Label ID="lblWeight" runat="server" CssClass="perInfoLabel">WEIGHT</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:DropDownList ID="cboGrade" runat="server" CssClass="DropDown">
                    <asp:ListItem>Select...</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:TextBox ID="txtJersey" runat="server" CssClass="perInfoText" Width="50px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" CssClass="perInfoLabel" Width="20px">&nbsp;</asp:Label>
                <asp:TextBox ID="txtWeight" runat="server" CssClass="perInfoText" Width="50px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:CheckBox ID="cbPitcher" runat="server" Text="Does this player Pitch?" CssClass="perInfoText" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow><asp:TableCell ColumnSpan="3"><hr /></asp:TableCell></asp:TableRow>
    </asp:Table>
</ContentTemplate>
</asp:UpdatePanel>


