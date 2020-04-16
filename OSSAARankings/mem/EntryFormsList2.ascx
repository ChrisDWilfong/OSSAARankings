<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EntryFormsList2.ascx.vb" Inherits="OSSAARankings.EntryFormsList2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="PanelFormsList" runat="server" CssClass="panelHome">
    <div>
    <asp:Label runat="server" ID="lblHead" ForeColor="Red" Font-Bold="true" Text="Entry Forms will be open Monday, July 29th" Visible="false"></asp:Label>
     <asp:Panel ID="PanelEntryFormsList" runat="server" CssClass="panelHome">
        <asp:UpdatePanel ID="UpdatePanelEditFormsList" runat="server" UpdateMode="Always">
        <ContentTemplate>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" RenderMode="Lightweight" AllowAutomaticInserts="false" AllowAutomaticUpdates="false">
            <MasterTableView DataSourceID="SqlDataSource1" EditMode="Popup">
                <ItemStyle VerticalAlign="Middle" />
                <Columns>
                    <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" ButtonType="LinkButton" EditText="Enter Form Details" >
                        <ItemStyle Font-Names="Segoe UI" Font-Size="11px" Width="100px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridTemplateColumn DataField="EntryFormYN" UniqueName="EntryFormYN">
                            <HeaderStyle ForeColor="Navy" Font-Bold="true" Font-Names="Segoe UI" Font-Size="2em"/>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ossaalogoBlackSmall.gif" Width="25px" />
                                <asp:HiddenField ID="hiddenschoolID" runat="server" value='<%# DataBinder.Eval(Container, "DataItem.schoolID")%>' />
                                <asp:HiddenField ID="hiddenActivity" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.strActivity")%>' />
                                <asp:HiddenField ID="hiddenActivityAbb" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.strActivityAbb")%>' />
                                <asp:HiddenField ID="hiddenFormStamp" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormStamp")%>' />
                                <asp:HiddenField ID="hiddenFormYN" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormYN")%>' />
                                <asp:HiddenField ID="hiddenFormYN1" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormYN1")%>' />
                                <asp:HiddenField ID="hiddenFormComplete" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormComplete")%>' />
                                <asp:HiddenField ID="HiddenSportGenderKey" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.SportGenderKey")%>' />
                                <asp:HiddenField ID="HiddenStart" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.dtmEntryFormStart")%>' />
                                <asp:HiddenField ID="HiddenEnd" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.dtmEntryFormEnd")%>' />
                                <asp:HiddenField ID="HiddenActive" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ysnEntryFormActive")%>' />
                                <asp:Label ID="lblDetailHeader" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.strActivity")%>'></asp:Label>&nbsp;&nbsp;
                                <telerik:RadDropDownList runat="server" ID="cboEntryFormYN" Width="125px" AutoPostBack="true" ToolTip="" DataValueField="EntryFormYN" OnDataBound="GetDropDownValue" Visible="false" >
                                    <Items>
                                        <telerik:DropDownListItem Text="Select..." Value="" />
                                        <telerik:DropDownListItem Text="YES Participating" Value="Y" />
                                        <telerik:DropDownListItem Text="NOT Participating" Value="N" />
                                    </Items>
                                 </telerik:RadDropDownList>
                                <asp:Label ID="lblDetailFooter" runat="server" Text="" Font-Bold="false"></asp:Label>&nbsp;&nbsp;
                                <asp:HiddenField ID="lblComplete" runat="server" value=""></asp:HiddenField>&nbsp;&nbsp;
                                </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" Font-Names="Anton, Segoe UI" Font-Bold="false"  Font-Size="1.5em" />
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings UserControlName="../mem/EntryFormsEdit2.ascx" EditFormType="WebUserControl" >
                    <EditColumn UniqueName="EditCommandColumn1" >
                    </EditColumn>
                    <PopUpSettings Width="960px" KeepInScreenBounds="true" Modal="true" ShowCaptionInEditForm="false" OverflowPosition="UpperLeft" />
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>  
        </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel> 
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSSAAServerConnectionString %>" 
            SelectCommand="SELECT * FROM viewEntryFormsGrid WHERE schoolID = @schoolID AND ysnEntryForms <> 0 ORDER BY strActivity">
            <SelectParameters>
                <asp:Parameter DefaultValue="20" Name="intYear" Type="Int16" />
                <asp:SessionParameter SessionField="entryFormSchoolID" DefaultValue="343" Name="schoolID" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Panel>
