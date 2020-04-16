﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EntryFormsList.ascx.vb" Inherits="OSSAARankings.EntryFormsList"  %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="PanelFormsList" runat="server" CssClass="panelHome">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
    <div>
        <asp:Panel ID="PanelHome" runat="server" CssClass="panelHome">
        <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanelHome" runat="server" ViewStateMode="Enabled">
            <ProgressTemplate>  
                <div style="position:absolute; top:400px;left:250px;">
                    <img alt="Loading..." src="../images/ajax-loader1.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelHome" runat="server" UpdateMode="Always">
        <ContentTemplate>
        <asp:RadioButtonList ID="cmdHide" runat="server" Font-Bold="false" Font-Size="Small" OnSelectedIndexChanged="HideUnhide" AutoPostBack="true"
            ForeColor="Navy" Font-Names="Verdana" >
            <asp:ListItem Value="HIDE" Text="Hide SPORTS marked NOT participating" Selected="True"></asp:ListItem>
            <asp:ListItem Value="UNHIDE" Text="Unhide SPORTS"></asp:ListItem>
        </asp:RadioButtonList>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" RenderMode="Lightweight" AllowAutomaticInserts="false" AllowAutomaticUpdates="false">
            <MasterTableView DataSourceID="SqlDataSource1" EditMode="Popup">
                <Columns>
                    <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" ButtonType="LinkButton" EditText="Enter Form Details">
                        <ItemStyle Font-Names="Segoe UI" Font-Size="11px" Width="100px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridTemplateColumn DataField="EntryFormYN" UniqueName="EntryFormYN">
                            <HeaderTemplate>
                                <asp:Label ID="lblHeader" runat="server" Text="ENTRY FORMS : KINGFISHER"></asp:Label><hr />
                            </HeaderTemplate>
                            <HeaderStyle ForeColor="Navy" Font-Bold="true" Font-Names="Segoe UI" Font-Size="2em"/>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ossaalogoBlackSmall.gif" Width="25px" />
                                <asp:HiddenField ID="hiddenschoolID" runat="server" value='<%# DataBinder.Eval(Container, "DataItem.schoolID")%>' />
                                <asp:HiddenField ID="hiddenActivity" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.strActivity")%>' />
                                <asp:HiddenField ID="hiddenActivityAbb" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.strActivityAbb")%>' />
                                <asp:HiddenField ID="hiddenFormStamp" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormStamp")%>' />
                                <asp:HiddenField ID="hiddenFormYN" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormYN")%>' />
                                <asp:HiddenField ID="hiddenFormComplete" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.EntryFormComplete")%>' />
                                <asp:Label ID="lblDetailHeader" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.strActivity")%>'></asp:Label>&nbsp;&nbsp;
                                <telerik:RadDropDownList runat="server" ID="cboEntryFormYN" Width="125px"
                                        AutoPostBack="true" ToolTip="" DataValueField="EntryFormYN" OnDataBound="GetDropDownValue" Visible="false" >
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
                <EditFormSettings UserControlName="EntryFormsEdit.ascx" EditFormType="WebUserControl" >
                    <EditColumn UniqueName="EditCommandColumn1">
                    </EditColumn>
                    <PopUpSettings Width="960px" KeepInScreenBounds="true" Modal="true" ShowCaptionInEditForm="false" OverflowPosition="UpperLeft" />
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>  
        </ContentTemplate>
        </asp:UpdatePanel>
        </asp:Panel> 
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OSSAAServerConnectionString %>" 
            SelectCommand="SELECT * FROM viewEntryFormsGrid WHERE schoolID = @schoolID AND ysnEntryForms <> 0 ORDER BY strActivity">
            <SelectParameters>
                <asp:Parameter DefaultValue="17" Name="intYear" Type="Int16" />
                <asp:SessionParameter SessionField="entryFormSchoolID" DefaultValue="343" Name="schoolID" Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>

</asp:Panel>