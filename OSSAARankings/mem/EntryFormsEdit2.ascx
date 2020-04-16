<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EntryFormsEdit2.ascx.vb" Inherits="OSSAARankings.EntryFormsEdit2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="PanelFormsEdit" runat="server" CssClass="panelHome">

    <asp:UpdatePanel ID="UpdatePanelEditForms" runat="server" UpdateMode="Always">
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdSaveVolleyball" />
        </Triggers>
        <ContentTemplate>
        <%-- **************************************************************** BASEBALL --%>
        <asp:Table runat="server" ID="tblBaseball" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2019-20 BASEBALL ENTRY FORM</strong></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageBaseballHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow> 
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingBaseballFall" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="NO" Value="N"/>
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label33" runat="server" Text="PARTICIPATING (FALL)? <span style='color:Red;'>(DUE : AUGUST 15, 2019)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingBaseball" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="PARTICIPATING (SPRING)? <span style='color:Red;'>(DUE : FEBURARY 10, 2020)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball1" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Is the lighting adequate for safe and fair play?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball2" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Is the infield grass, dirt and outfield smooth and is it adequate for safe and fair play?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball3" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Is the Pitcher's Plate 10 inches above the surface of Home Plate?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball4" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Is your Press Box with Public Address system capable of seating 4 to 6 people?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBaseball1" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label1a" runat="server" Text="Approximate number of seats available?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball5" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Is your seating area covered or partially covered?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball6" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label54" runat="server" Text="Is there space for fans to set-up lawn chairs down left and right fields fences and the back stop?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball7" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label55" runat="server" Text="Are there Men's and Women's restroom facilities at the ball park?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball8" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label56" runat="server" Text="Are there facilities for umpires to dress and be away from the crowd?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball9" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label57" runat="server" Text="If needed, will you have security available at the game site?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball10" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label58" runat="server" Text="Is there adequate parking and is it available during school hours?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball11" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label59" runat="server" Text="Is there an evacuation plan and shelter for your ball park in case of dangerous weather?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball12" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label60" runat="server" Text="Do you have a tarp to cover the infield area?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball13" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label61" runat="server" Text="Do you have a tarp to cover home plate/pitcher's mound?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball14" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label62" runat="server" Text="Are your baseball and softball fields adjacent?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBaseball15" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label149" runat="server" Text="Is your facility ADA Compliant? " Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBaseball2" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label63" runat="server" Text="Dimensions : LF Fence?" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBaseball3" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label64" runat="server" Text="Dimensions : CF Fence?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBaseball4" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label65" runat="server" Text="Dimensions : RF Fence?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBaseball5" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66" runat="server" Text="Dimensions : Home plate to Back-Stop fence?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="lblComments" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="60px">
                    <telerik:RadTextBox ID="TextBoxBaseballComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label6" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByBaseball" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label24" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveBaseball" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageBaseball" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelBaseball" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** Basketball --%>
        <asp:Table runat="server" ID="tblBasketball" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2019-20 BASKETBALL FACILITY FORM</strong></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageBasketballHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" VerticalAlign="Top">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingBasketball" runat="server" Width="120px" AutoPostBack="true" DropDownWidth="200px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                            <telerik:DropDownListItem Text="Only in OUR classification" Value="C" />
                            <telerik:DropDownListItem Text="In ANY classification" Value="A" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label27" runat="server" Text="Are you interested in hosting a post season basketball tournament for the 2019-20 season?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball1" runat="server" Width="60px" ></asp:TextBox>
                 </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label135" runat="server" Text="Our present gym was constructed in (year) ?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label1361" runat="server" Text="<strong>Dimensions of our playing court are (in feet) ?</strong>"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball2" runat="server" Width="60px"></asp:TextBox>&nbsp;&nbsp;&nbsp;BY&nbsp;
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxBasketball3" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball4" runat="server" Width="60px" ></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label137" runat="server" Text="Total number of boys dressing rooms?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball5" runat="server" Width="60px" ></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66b" runat="server" Text="Number of boys dressing rooms (with showers)?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball6" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label138" runat="server" Text="Total number of girls dressing rooms?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball7" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66a" runat="server" Text="Number of girls dressing rooms (with showers)?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label66c" runat="server" Text="<strong>Number of permanent rows (including roll-a-ways) of seating :</strong> "></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball8" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label139" runat="server" Text="Scoring table side" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball9" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66d" runat="server" Text="Opposite side" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball10" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66e" runat="server" Text="End(s)" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball11" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label66f" runat="server" Text="Total seating capacity (Please be as precise as possible) : " Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxBasketball12" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label140" runat="server" Text="How many cars will the parking lot accomodate? " Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBasketball1" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label141" runat="server" Text="Is your parking lot lighted?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListBasketball2" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label150" runat="server" Text="Is your facility ADA Compliant?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label142" runat="server" Text="List the OSSAA post season basketball tournaments you have hosted in the past 3 years :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell Height="70px" ColumnSpan="2">
                    <telerik:RadTextBox ID="TextBoxBasketballComments1" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label1366" runat="server" Text="Other pertinent information or comments :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Height="70px" ColumnSpan="2">
                    <telerik:RadTextBox ID="TextBoxBasketballComments2" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label144" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByBasketball" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label145" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveBasketball" runat="server" Text="Save Changes"  ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageBasketball" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelBasketball" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** CHEERLEADING (COMPETITIVE) --%>
        <asp:Table runat="server" ID="tblCheerleading" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="<strong>2019 CHEERLEADING (COMPETITIVE) ENTRY FORM</strong>" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageCheerleadingHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="Label1331" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="true" Text="DUE : AUGUST 23, 2019"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingCheerleading" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label52" runat="server" Text="PARTICIPATING (COMPETITIVE CHEER)?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListCoEdSquad" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label34" runat="server" Text="CO-ED SQUAD (COMPETITIVE CHEER)?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label25" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByCheerleading" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label26" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveCheerleading" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageCheerleading" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelCheerleading" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblCheerleadingFooter" Font-Names="Arial" Font-Size="Medium" ForeColor="Blue" Text="IF THE SMALL CO-ED DIVISION IS LESS THAN 8 SQUADS, THERE WILL BE ONLY ONE CO-ED DIVISION." Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** CHEERLEADING (GAME DAY) --%>
        <asp:Table runat="server" ID="tblCheerleadingGameDay" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="<strong>2019 CHEERLEADING (GAME DAY) ENTRY FORM</strong>" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageCheerleadingGameDayHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="Label91" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="true" Text="DUE : AUGUST 23, 2019"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingGameDay" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label151" runat="server" Text="PARTICIPATING (GAME DAY COMPETITION)?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label152" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByCheerleadingGameDay" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label153" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveCheerleadingGameDay" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageCheerleadingGameDay" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelCheerleadingGameDay" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
        </asp:Table>
        <%-- **************************************************************** CROSS COUNTRY BOYS --%>
        <asp:Table runat="server" ID="tblCrossCountryBoys" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="2019 CROSS COUNTRY BOYS ENTRY FORM" Font-Size="X-Large" Font-Bold="true"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageCrossCountryBoysHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="Label13322" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="true" Text="DUE : NO LATER THAN OCTOBER 7, 2019 FOR CLASSES 2A, 3A and 4A<br>DUE : NO LATER THAN OCTOBER 14, 2019 FOR CLASSES 5A-6A"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingCrossCountryBoys" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label8" runat="server" Text="PARTICIPATING?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="Contestant #1 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys1" Width="250px" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="Label22" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label10" runat="server" Text="Contestant #2 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys2" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="Contestant #3 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys3" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label12" runat="server" Text="Contestant #4 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys4" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label13" runat="server" Text="Contestant #5 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys5" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label14" runat="server" Text="Contestant #6 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys6" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label15" runat="server" Text="Contestant #7 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys7" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label16" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys8" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label17" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys9" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label18" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys10" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label19" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys11" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label20" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryBoys12" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label21" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByCrossCountryBoys" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label23" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveCrossCountryBoys" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageCrossCountryBoys" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Participants then <click> SAVE CHANGES." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelCrossCountryBoys" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** CROSS COUNTRY Girls --%>
        <asp:Table runat="server" ID="tblCrossCountryGirls" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="2018 CROSS COUNTRY GIRLS ENTRY FORM" Font-Bold="true" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageCrossCountryGirlsHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblCrossCountryGirlsHeader" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="true" Text="DUE : NO LATER THAN OCTOBER 7, 2019 FOR CLASSES 2A, 3A and 4A<br>DUE : NO LATER THAN OCTOBER 14, 2019 FOR CLASSES 5A-6A"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingCrossCountryGirls" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label35" runat="server" Text="PARTICIPATING?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label36" runat="server" Text="Contestant #1 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls1" Width="250px" MaxLength="100"></asp:TextBox>
                    <asp:Label ID="Label37" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label38" runat="server" Text="Contestant #2 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls2" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label39" runat="server" Text="Contestant #3 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls3" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label40" runat="server" Text="Contestant #4 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls4" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label41" runat="server" Text="Contestant #5 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls5" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label42" runat="server" Text="Contestant #6 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls6" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label43" runat="server" Text="Contestant #7 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls7" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label44" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls8" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label45" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls9" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label46" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls10" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label47" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls11" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label48" runat="server" Text="Alternate : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="TextBoxCrossCountryGirls12" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label49" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByCrossCountryGirls" runat="server" Width="225px" Text="Enter your name" ></asp:TextBox>
                    <asp:Label ID="Label50" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveCrossCountryGirls" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageCrossCountryGirls" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Participants then <click> SAVE CHANGES." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelCrossCountryGirls" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** GOLF BOYS --%>
        <asp:Table runat="server" ID="tblGolfBoys" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="2020 GOLF BOYS ENTRY FORM" Font-Bold="true" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageGolfBoysHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblGolfBoysHeader" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="True" Text="DUE : APRIL 1, 2020"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingGolfBoys" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label95" runat="server" Text="PARTICIPATING?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label96" runat="server" Text="Golfer #1 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfBoys1" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label98" runat="server" Text="Golfer #2 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfBoys2" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label99" runat="server" Text="Golfer #3 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfBoys3" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label100" runat="server" Text="Golfer #4 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfBoys4" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label101" runat="server" Text="Golfer #5 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfBoys5" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label102" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByGolfBoys" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label103" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveGolfBoys" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageGolfBoys" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Golfers then <click> SAVE CHANGES." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelGolfBoys" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** GOLF GIRLS --%>
        <asp:Table runat="server" ID="tblGolfGirls" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="2020 GOLF GIRLS ENTRY FORM" Font-Bold="true" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageGolfGirlsHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblGolfGirlsHeader" Font-Names="Segoe UI, Arial" Font-Size="Medium" ForeColor="Red" Font-Bold="True" Text="DUE : APRIL 1, 2020"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingGolfGirls" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label104" runat="server" Text="PARTICIPATING?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label105" runat="server" Text="Golfer #1 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfGirls1" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label107" runat="server" Text="Golfer #2 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfGirls2" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label108" runat="server" Text="Golfer #3 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfGirls3" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label109" runat="server" Text="Golfer #4 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfGirls4" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label110" runat="server" Text="Golfer #5 : " Font-Bold="true" Font-Size="18px" ForeColor="Navy" Width="150px"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtGolfGirls5" Width="250px" MaxLength="100" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label111" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByGolfGirls" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label112" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveGolfGirls" runat="server" Text="Save Changes"  ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageGolfGirls" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Participants then <click> SAVE CHANGES." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelGolfGirls" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** SOFTBALL (FAST-PITCH) --%>
        <asp:Table runat="server" ID="tblFPSoftball" visible="false">
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="2019 FAST PITCH SOFTBALL ENTRY FORM" Font-Bold="true" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageFastPitchHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblDueDateFastPitch" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="True" Text="DUE : AUGUST 23, 2019"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingFPSoftball" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label77" runat="server" Text="PARTICIPATING? " Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball1" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label67" runat="server" Text="Is field lighted?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball2" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label68" runat="server" Text="Is field fenced?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label69" runat="server" Text="If fenced, list outfield dimensions?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
        		    &nbsp;&nbsp;<asp:Label ID="Label1b" runat="server" Text="LF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxFPSoftball1" runat="server" Width="60px"></asp:TextBox>&nbsp;&nbsp;		    
		            <asp:Label ID="Label1c" runat="server" Text="CF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxFPSoftball2" runat="server" Width="60px"></asp:TextBox>&nbsp;&nbsp;
		            <asp:Label ID="Label1d" runat="server" Text="RF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxFPSoftball3" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball3" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label70" runat="server" Text="Is infield all dirt?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxFPSoftball4" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label71" runat="server" Text="How far is back stop from home plate (FT)?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball4" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label72" runat="server" Text="Do you have adequate parking?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball5" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label73" runat="server" Text="Is field suited to charge admission?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball6" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label74" runat="server" Text="Do you have a consession stand?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball7" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label75" runat="server" Text="Is seating adequate?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxFPSoftball5" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label18a" runat="server" Text="Approximate number of seats available?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball8" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label76" runat="server" Text="Are restrooms available at site?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftball10" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label106" runat="server" Text="Is your facility ADA Compliant? " Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="lblCommentsFP" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="60px">
                    <telerik:RadTextBox ID="TextBoxFPSoftballComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListFPSoftballHosting" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label322" runat="server" Text="Willing to host ANY fast-pitch softball playoff tournaments?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label29" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByFPSoftball" runat="server" Width="225px" Text="Enter your name" ></asp:TextBox>
                    <asp:Label ID="Label30" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveFPSoftball" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageFastPitch" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelFPSoftball" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** SOFTBALL (SLOW-PITCH) --%>
        <asp:Table runat="server" ID="tblSPSoftball" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="<strong>2020 SLOW-PITCH SOFTBALL ENTRY FORM</strong>" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageSlowPitchHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblDueDateSlowPitch" Font-Names="Segoe UI, Arial" Font-Size="Large" Font-Bold="True" ForeColor="Red" Text="DUE : JANUARY 27, 2020"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingSPSoftball" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label113" runat="server" Text="PARTICIPATING? " Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball1" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label114" runat="server" Text="Do you have adequate lighting?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball2" runat="server" Width="100px" DropDownWidth="120px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="Permanent" Value="P" />
                            <telerik:DropDownListItem Text="Temporary" Value="T" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label115" runat="server" Text="Is your field fenced with a permanent or temporary fencing?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label116" runat="server" Text="If fenced, list outfield dimensions?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
        		    &nbsp;&nbsp;<asp:Label ID="Label117" runat="server" Text="LF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxSPSoftball1" runat="server" Width="60px"></asp:TextBox>&nbsp;&nbsp;		    
		            <asp:Label ID="Label118" runat="server" Text="CF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxSPSoftball2" runat="server" Width="60px"></asp:TextBox>&nbsp;&nbsp;
		            <asp:Label ID="Label119" runat="server" Text="RF (FT) : " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TextBoxSPSoftball3" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball3" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label120" runat="server" Text="Do you have a dirt infield?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxSPSoftball4" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label121" runat="server" Text="How far is back stop from home plate (FT)?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball4" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label122" runat="server" Text="Do you have adequate parking?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball5" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label123" runat="server" Text="Is field suited to charge admission?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball6" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label124" runat="server" Text="Do you have a consession stand?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball7" runat="server" Width="60px" >
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label125" runat="server" Text="Is seating adequate?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxSPSoftball5" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label126" runat="server" Text="Approximate number of seats available?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball8" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label127" runat="server" Text="Are restrooms available at site?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball9" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label132" runat="server" Text="Are your softball field and baseball field adjacent to each other?" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftball11" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label97" runat="server" Text="Is your facility ADA Compliant? " Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="Label128" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <telerik:RadTextBox ID="TextBoxSPSoftballComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListSPSoftballHosting" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label129" runat="server" Text="Willing to host ANY Slow-PItch softball playoff tournaments?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label130" runat="server" Text="SUBMITTED BY?&nbsp;" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedBySPSoftball" runat="server" Width="225px" Text="Enter your name" ></asp:TextBox>
                    <asp:Label ID="Label131" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveSPSoftball" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageSlowPitch" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelSPSoftball" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** Volleyball --%>
        <asp:Table runat="server" ID="tblVolleyball" visible="false">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Text="<strong>2019 VOLLEYBALL ENTRY FORM</strong>" Font-Size="X-Large"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageVolleyballHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" ID="lblVolleyballHeader" Font-Names="Segoe UI, Arial" Font-Size="Large" ForeColor="Red" Font-Bold="True" Text="DUE : AUGUST 19, 2019"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingVolleyball" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label31" runat="server" Text="PARTICIPATING?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:75px;">
                    <telerik:RadDropDownList ID="RadDropDownListVolleyballHosting" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label32" runat="server" Text="Willing to host a Regional Tournament?" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label51" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByVolleyball" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label53" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveVolleyball" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageVolleyball" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelVolleyball" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** SWIMMING (BOYS)--%>
        <asp:Table runat="server" ID="tblSwimmingBoys" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2019-20 BOYS SWIMMING ENTRY FORM</strong></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageSwimmingBoysHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingSwimmingBoys" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label78" runat="server" Text="PARTICIPATING : BOYS SWIMMING? <span style='color:Red;'>(DUE : October 18, 2019)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxSwimmingBoys1" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelSw1a" runat="server" Text="Approximate number of Swimmers (BOYS)?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="Label80" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <telerik:RadTextBox ID="TextBoxSwimmingBoysComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label81" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedBySwimmingBoys" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label82" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveSwimmingBoys" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageSwimmingBoys" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelSwimmingBoys" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

        <%-- **************************************************************** SWIMMING (Girls)--%>
        <asp:Table runat="server" ID="tblSwimmingGirls" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2019-20 GIRLS SWIMMING ENTRY FORM</strong></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageSwimmingGirlsHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingSwimmingGirls" runat="server" Width="100px" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label28" runat="server" Text="PARTICIPATING : GIRLS SWIMMING? <span style='color:Red;'>(DUE : October 18, 2019)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox ID="TextBoxSwimmingGirls1" runat="server" Width="60px"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label79" runat="server" Text="Approximate number of Swimmers (Girls)?" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="Label88" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <telerik:RadTextBox ID="TextBoxSwimmingGirlsComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label89" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedBySwimmingGirls" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label90" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveSwimmingGirls" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageSwimmingGirls" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelSwimmingGirls" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>


        <%-- **************************************************************** TENNIS (BOYS)--%>
        <asp:Table runat="server" ID="tblTennisBoys" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2020 BOYS TENNIS ENTRY FORM</strong></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageTennisBoysHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingTennisBoys" runat="server" Width="100px" AutoPostBack="true" Font-Size="16px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label83" runat="server" Text="PARTICIPATING : BOYS TENNIS? <span style='color:Red;'>(DUE : April 3, 2020)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisBoys1" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelTN1" runat="server" Text="BOYS #1 SINGLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisBoys2" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label85" runat="server" Text="BOYS #1 DOUBLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisBoys3" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label86" runat="server" Text="BOYS #2 SINGLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisBoys4" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label87" runat="server" Text="BOYS #2 DOUBLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>

            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="Label92" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <telerik:RadTextBox ID="TextBoxTennisBoysComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label93" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByTennisBoys" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label94" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveTennisBoys" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageTennisBoys" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelTennisBoys" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%-- **************************************************************** TENNIS (GIRLS)--%>
        <asp:Table runat="server" ID="tblTennisGirls" visible="false" >
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Font-Size="X-Large"><strong>2020 GIRLS TENNIS ENTRY FORM</strong></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="lblMessageTennisGirlsHeader" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="RadDropDownListParticipatingTennisGirls" runat="server" Width="100px" Font-Size="16px" AutoPostBack="true">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label84" runat="server" Text="PARTICIPATING : GIRLS TENNIS? <span style='color:Red;'>(DUE : April 3, 2020)</span>" Font-Bold="true" Font-Size="18px" ForeColor="Navy"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow><asp:TableCell ColumnSpan="2">&nbsp;</asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisGirls1" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label133" runat="server" Text="GIRLS #1 SINGLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisGirls2" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label134" runat="server" Text="GIRLS #1 DOUBLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisGirls3" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label136" runat="server" Text="GIRLS #2 SINGLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <telerik:RadDropDownList ID="RadDropDownListTennisGirls4" runat="server" Width="60px">
                        <Items>
                            <telerik:DropDownListItem Text="Select..." Value="-" />
                            <telerik:DropDownListItem Text="YES" Value="Y" />
                            <telerik:DropDownListItem Text="NO" Value="N" />
                        </Items>
                    </telerik:RadDropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label143" runat="server" Text="GIRLS #2 DOUBLES" Font-Bold="True"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow VerticalAlign="Top">
                <asp:TableCell>
                    <asp:Label ID="Label146" runat="server" Text="Comments/Notes :" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="100px">
                    <telerik:RadTextBox ID="TextBoxTennisGirlsComments" runat="server" Rows="3" MaxLength="2000" Width="90%" TextMode="MultiLine"></telerik:RadTextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell style="width:120px;">
                    <asp:Label ID="Label147" runat="server" Text="SUBMITTED BY?&nbsp;&nbsp;" Width="140px" Font-Bold="True"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSubmittedByTennisGirls" runat="server" Width="225px" Text="Enter your name"></asp:TextBox>
                    <asp:Label ID="Label148" runat="server" Text=" *" Font-Bold="true" Font-Size="18px" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Button ID="cmdSaveTennisGirls" runat="server" Text="Save Changes" ForeColor="White" BackColor="Green" Width="150px" Height="40px" Font-Bold="True" /></asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblMessageTennisGirls" ForeColor="Red" Font-Names="Anton, Segoe UI" Font-Size="Large" Text="Enter all Information above then <click> SAVE CHANGES (button)." Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                    <asp:Button ID="cmdCancelTennisGirls" Text="DONE" runat="server" CommandName="Cancel" Font-Bold="True" Height="40px"></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </ContentTemplate>
        
    </asp:UpdatePanel>
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
</asp:Panel>

