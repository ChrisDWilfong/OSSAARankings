Public Class ucCoachesSports
    Inherits System.Web.UI.UserControl
    Dim ds1 As DataSet

    ' NOTES : 
    '   - Added Academic 6/5/2014...
    '

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("madgCoachName") = "" Then
            Response.Redirect("adLogin.aspx")
        End If

        If Not IsPostBack Then
            If ds1 Is Nothing Then
                LoadDropDownData()
            End If
        End If

        If Me.Visible = False Then
            LoadDropDownData()
            If Session("madgOrganizationType") = "OSSAAADMIN" Or Session("madgOrganizationType") = "MULTI" Then
                ChangeObject(cboAcademic, lblAcademic, 0)
                ChangeObject(cboBaseballFall, lblBaseballFall, 0)
                ChangeObject(cboBaseballSpring, lblBaseballSpring, 0)
                ChangeObject(cboBasketballBoys, lblBasketballBoys, 0)
                ChangeObject(cboBasketballGirls, lblBasketballGirls, 0)
                ChangeObject(cboCheerleading, lblCheerleading, 0)
                ChangeObject(cboCrossCountryBoys, lblCrossCountryGirls, 0)
                ChangeObject(cboCrossCountryGirls, lblCrossCountryGirls, 0)
                ChangeObject(cboFootball, lblFootball, 0)
                ChangeObject(cboFastPitch, lblFastPitch, 0)
                ChangeObject(cboGolfBoys, lblGolfBoys, 0)
                ChangeObject(cboGolfGirls, lblGolfGirls, 0)
                ChangeObject(cboSoccerBoys, lblSoccerBoys, 0)
                ChangeObject(cboSoccerGirls, lblSoccerGirls, 0)
                ChangeObject(cboSlowPitch, lblSlowPitch, 0)
                ChangeObject(cboSwimmingBoys, lblSwimmingBoys, 0)
                ChangeObject(cboSwimmingGirls, lblSwimmingGirls, 0)
                ChangeObject(cboTennisBoys, lblTennisBoys, 0)
                ChangeObject(cboTennisGirls, lblTennisGirls, 0)
                ChangeObject(cboTrackBoys, lblTrackBoys, 0)
                ChangeObject(cboTrackGirls, lblTrackGirls, 0)
                ChangeObject(cboVolleyball, lblVolleyball, 0)
                ChangeObject(cboWrestling, lblWrestling, 0)
            End If
            LoadData()
        End If
        'End If

    End Sub

    Public Sub LoadDropDownData()

        ' Populate the dropdowns...
        ds1 = clsMembers.GetCoachesDatasetFromSchool(Session("madgSchoolID"), clsFunctions.GetCurrentYear)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            cboAcademic.DataSource = ds1
            cboAcademic.DataBind()
            Dim objList0 As New System.Web.UI.WebControls.ListItem
            objList0.Value = 0
            objList0.Text = "Select Coach..."
            cboAcademic.Items.Insert(0, objList0)

            cboBaseballFall.DataSource = ds1
            cboBaseballFall.DataBind()
            Dim objList1 As New System.Web.UI.WebControls.ListItem
            objList1.Value = 0
            objList1.Text = "Select Coach..."
            cboBaseballFall.Items.Insert(0, objList1)

            cboBaseballSpring.DataSource = ds1
            cboBaseballSpring.DataBind()
            Dim objList2 As New System.Web.UI.WebControls.ListItem
            objList2.Value = 0
            objList2.Text = "Select Coach..."
            cboBaseballSpring.Items.Insert(0, objList2)

            cboBasketballBoys.DataSource = ds1
            cboBasketballBoys.DataBind()
            Dim objList3 As New System.Web.UI.WebControls.ListItem
            objList3.Value = 0
            objList3.Text = "Select Coach..."
            cboBasketballBoys.Items.Insert(0, objList3)

            cboBasketballGirls.DataSource = ds1
            cboBasketballGirls.DataBind()
            Dim objList4 As New System.Web.UI.WebControls.ListItem
            objList4.Value = 0
            objList4.Text = "Select Coach..."
            cboBasketballGirls.Items.Insert(0, objList4)

            cboCheerleading.DataSource = ds1
            cboCheerleading.DataBind()
            Dim objList5 As New System.Web.UI.WebControls.ListItem
            objList5.Value = 0
            objList5.Text = "Select Coach..."
            cboCheerleading.Items.Insert(0, objList5)

            cboCrossCountryBoys.DataSource = ds1
            cboCrossCountryBoys.DataBind()
            Dim objList6 As New System.Web.UI.WebControls.ListItem
            objList6.Value = 0
            objList6.Text = "Select Coach..."
            cboCrossCountryBoys.Items.Insert(0, objList6)

            cboCrossCountryGirls.DataSource = ds1
            cboCrossCountryGirls.DataBind()
            Dim objList7 As New System.Web.UI.WebControls.ListItem
            objList7.Value = 0
            objList7.Text = "Select Coach..."
            cboCrossCountryGirls.Items.Insert(0, objList7)

            cboFastPitch.DataSource = ds1
            cboFastPitch.DataBind()
            Dim objList8 As New System.Web.UI.WebControls.ListItem
            objList8.Value = 0
            objList8.Text = "Select Coach..."
            cboFastPitch.Items.Insert(0, objList8)

            cboFootball.DataSource = ds1
            cboFootball.DataBind()
            Dim objList9 As New System.Web.UI.WebControls.ListItem
            objList9.Value = 0
            objList9.Text = "Select Coach..."
            cboFootball.Items.Insert(0, objList9)

            cboGolfBoys.DataSource = ds1
            cboGolfBoys.DataBind()
            Dim objList10 As New System.Web.UI.WebControls.ListItem
            objList10.Value = 0
            objList10.Text = "Select Coach..."
            cboGolfBoys.Items.Insert(0, objList10)

            cboGolfGirls.DataSource = ds1
            cboGolfGirls.DataBind()
            Dim objList11 As New System.Web.UI.WebControls.ListItem
            objList11.Value = 0
            objList11.Text = "Select Coach..."
            cboGolfGirls.Items.Insert(0, objList11)

            cboSlowPitch.DataSource = ds1
            cboSlowPitch.DataBind()
            Dim objList12 As New System.Web.UI.WebControls.ListItem
            objList12.Value = 0
            objList12.Text = "Select Coach..."
            cboSlowPitch.Items.Insert(0, objList12)

            cboSoccerBoys.DataSource = ds1
            cboSoccerBoys.DataBind()
            Dim objList13 As New System.Web.UI.WebControls.ListItem
            objList13.Value = 0
            objList13.Text = "Select Coach..."
            cboSoccerBoys.Items.Insert(0, objList13)

            cboSoccerGirls.DataSource = ds1
            cboSoccerGirls.DataBind()
            Dim objList14 As New System.Web.UI.WebControls.ListItem
            objList14.Value = 0
            objList14.Text = "Select Coach..."
            cboSoccerGirls.Items.Insert(0, objList14)

            cboSwimmingBoys.DataSource = ds1
            cboSwimmingBoys.DataBind()
            Dim objList15 As New System.Web.UI.WebControls.ListItem
            objList15.Value = 0
            objList15.Text = "Select Coach..."
            cboSwimmingBoys.Items.Insert(0, objList15)

            cboSwimmingGirls.DataSource = ds1
            cboSwimmingGirls.DataBind()
            Dim objList16 As New System.Web.UI.WebControls.ListItem
            objList16.Value = 0
            objList16.Text = "Select Coach..."
            cboSwimmingGirls.Items.Insert(0, objList16)

            cboTennisBoys.DataSource = ds1
            cboTennisBoys.DataBind()
            Dim objList17 As New System.Web.UI.WebControls.ListItem
            objList17.Value = 0
            objList17.Text = "Select Coach..."
            cboTennisBoys.Items.Insert(0, objList17)

            cboTennisGirls.DataSource = ds1
            cboTennisGirls.DataBind()
            Dim objList18 As New System.Web.UI.WebControls.ListItem
            objList18.Value = 0
            objList18.Text = "Select Coach..."
            cboTennisGirls.Items.Insert(0, objList18)

            cboTrackBoys.DataSource = ds1
            cboTrackBoys.DataBind()
            Dim objList19 As New System.Web.UI.WebControls.ListItem
            objList19.Value = 0
            objList19.Text = "Select Coach..."
            cboTrackBoys.Items.Insert(0, objList19)

            cboTrackGirls.DataSource = ds1
            cboTrackGirls.DataBind()
            Dim objList20 As New System.Web.UI.WebControls.ListItem
            objList20.Value = 0
            objList20.Text = "Select Coach..."
            cboTrackGirls.Items.Insert(0, objList20)

            cboVolleyball.DataSource = ds1
            cboVolleyball.DataBind()
            Dim objList21 As New System.Web.UI.WebControls.ListItem
            objList21.Value = 0
            objList21.Text = "Select Coach..."
            cboVolleyball.Items.Insert(0, objList21)

            cboWrestling.DataSource = ds1
            cboWrestling.DataBind()
            Dim objList22 As New System.Web.UI.WebControls.ListItem
            objList22.Value = 0
            objList22.Text = "Select Coach..."
            cboWrestling.Items.Insert(0, objList22)
        End If

    End Sub

    Public Sub LoadData()
        ' Load the current selected coaches...
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer
        Dim strSportID As String = ""

        If Session("madgSchoolID") = 0 Then Exit Sub

        strSQL = "SELECT memberID, sportID FROM tblTeams WHERE schoolID = " & Session("madgSchoolID") & " AND intYear = " & clsFunctions.GetCurrentYear & " AND memberID > 0"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strSportID = ds.Tables(0).Rows(x).Item("sportID")
                If InStr(strSportID, "Academic") > 0 Then
                    ChangeObject(cboAcademic, lblAcademic, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "BaseballFall") > 0 Then
                    ChangeObject(cboBaseballFall, lblBaseballFall, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "Baseball") > 0 Then
                    ChangeObject(cboBaseballSpring, lblBaseballSpring, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "BasketballBoys") > 0 Then
                    ChangeObject(cboBasketballBoys, lblBasketballBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "BasketballGirls") > 0 Then
                    ChangeObject(cboBasketballGirls, lblBasketballGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "Cheer") > 0 Then
                    ChangeObject(cboCheerleading, lblCheerleading, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "CrossCountryBoys") > 0 Then
                    ChangeObject(cboCrossCountryBoys, lblCrossCountryGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "CrossCountryGirls") > 0 Then
                    ChangeObject(cboCrossCountryGirls, lblCrossCountryGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "Football") > 0 Then
                    ChangeObject(cboFootball, lblFootball, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "FPSoftball") > 0 Then
                    ChangeObject(cboFastPitch, lblFastPitch, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "GolfBoys") > 0 Then
                    ChangeObject(cboGolfBoys, lblGolfBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "GolfGirls") > 0 Then
                    ChangeObject(cboGolfGirls, lblGolfGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "SoccerBoys") > 0 Then
                    ChangeObject(cboSoccerBoys, lblSoccerBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "SoccerGirls") > 0 Then
                    ChangeObject(cboSoccerGirls, lblSoccerGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "SPSoftball") > 0 Then
                    ChangeObject(cboSlowPitch, lblSlowPitch, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "SwimmingBoys") > 0 Then
                    ChangeObject(cboSwimmingBoys, lblSwimmingBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "SwimmingGirls") > 0 Then
                    ChangeObject(cboSwimmingGirls, lblSwimmingGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "TennisBoys") > 0 Then
                    ChangeObject(cboTennisBoys, lblTennisBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "TennisGirls") > 0 Then
                    ChangeObject(cboTennisGirls, lblTennisGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "TrackBoys") > 0 Then
                    ChangeObject(cboTrackBoys, lblTrackBoys, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "TrackGirls") > 0 Then
                    ChangeObject(cboTrackGirls, lblTrackGirls, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "Volleyball") > 0 Then
                    ChangeObject(cboVolleyball, lblVolleyball, ds.Tables(0).Rows(x).Item("memberID"))
                ElseIf InStr(strSportID, "Wrestling") > 0 Then
                    ChangeObject(cboWrestling, lblWrestling, ds.Tables(0).Rows(x).Item("memberID"))
                End If
            Next
        End If
    End Sub

    Public Sub ChangeObject(ByRef objDropDown As System.Web.UI.WebControls.DropDownList, ByRef objLabel As System.Web.UI.WebControls.Label, intMemberID As Long)

        If intMemberID > 0 Then
            Try
                objDropDown.SelectedValue = intMemberID
                objDropDown.BackColor = Drawing.Color.LightGreen
                objDropDown.Font.Bold = True
                objLabel.Font.Bold = True
            Catch
            End Try
        Else
            objDropDown.BackColor = Drawing.Color.LightYellow
            objDropDown.Font.Bold = False
            objLabel.Font.Bold = False
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strSQL As String

        strSQL = "UPDATE tblTeams SET memberID = " & cboAcademic.SelectedValue & " WHERE sportID Like 'Academic%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboBaseballFall.SelectedValue & " WHERE sportID Like 'BaseballFall%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboBaseballSpring.SelectedValue & " WHERE sportID Like 'Baseball%' AND Not sportID Like 'BaseballFall%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboBasketballBoys.SelectedValue & " WHERE sportID Like 'BasketballBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboBasketballGirls.SelectedValue & " WHERE sportID Like 'BasketballGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboCheerleading.SelectedValue & " WHERE sportID Like 'Cheer%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboCrossCountryBoys.SelectedValue & " WHERE sportID Like 'CrossCountryBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboCrossCountryGirls.SelectedValue & " WHERE sportID Like 'CrossCountryGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboFastPitch.SelectedValue & " WHERE sportID Like 'FPSoftball%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboFootball.SelectedValue & " WHERE sportID Like 'Football%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboGolfBoys.SelectedValue & " WHERE sportID Like 'GolfBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboGolfGirls.SelectedValue & " WHERE sportID Like 'GolfGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboSlowPitch.SelectedValue & " WHERE sportID Like 'SPSoftball%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboSoccerBoys.SelectedValue & " WHERE sportID Like 'SoccerBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboSoccerGirls.SelectedValue & " WHERE sportID Like 'SoccerGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboSwimmingBoys.SelectedValue & " WHERE sportID Like 'SwimmingBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboSwimmingGirls.SelectedValue & " WHERE sportID Like 'SwimmingGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboTennisBoys.SelectedValue & " WHERE sportID Like 'TennisBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboTennisGirls.SelectedValue & " WHERE sportID Like 'TennisGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboTrackBoys.SelectedValue & " WHERE sportID Like 'TrackBoys%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboTrackGirls.SelectedValue & " WHERE sportID Like 'TrackGirls%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboVolleyball.SelectedValue & " WHERE sportID Like 'Volleyball%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "UPDATE tblTeams SET memberID = " & cboWrestling.SelectedValue & " WHERE sportID Like 'Wrestling%' AND intYear = " & clsFunctions.GetCurrentYear & " AND schoolID = " & Session("madgSchoolID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Me.lblMessage.Text = "Your changes have been saved."

    End Sub

    Private Sub cboBaseballFall_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboBaseballFall.SelectedIndexChanged
        ChangeObject(cboBaseballFall, lblBaseballFall, cboBaseballFall.SelectedValue)
    End Sub

    Private Sub cboBaseballSpring_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboBaseballSpring.SelectedIndexChanged
        ChangeObject(cboBaseballSpring, lblBaseballSpring, cboBaseballSpring.SelectedValue)
    End Sub

    Private Sub cboBasketballBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboBasketballBoys.SelectedIndexChanged
        ChangeObject(cboBasketballBoys, lblBasketballBoys, cboBasketballBoys.SelectedValue)
    End Sub

    Private Sub cboBasketballGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboBasketballGirls.SelectedIndexChanged
        ChangeObject(cboBasketballGirls, lblBasketballGirls, cboBasketballGirls.SelectedValue)
    End Sub

    Private Sub cboCheerleading_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCheerleading.SelectedIndexChanged
        ChangeObject(cboCheerleading, lblCheerleading, cboCheerleading.SelectedValue)
    End Sub

    Private Sub cboCrossCountryBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCrossCountryBoys.SelectedIndexChanged
        ChangeObject(cboCrossCountryBoys, lblCrossCountryBoys, cboCrossCountryBoys.SelectedValue)
    End Sub

    Private Sub cboCrossCountryGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCrossCountryGirls.SelectedIndexChanged
        ChangeObject(cboCrossCountryGirls, lblCrossCountryGirls, cboCrossCountryGirls.SelectedValue)
    End Sub

    Private Sub cboFastPitch_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFastPitch.SelectedIndexChanged
        ChangeObject(cboFastPitch, lblFastPitch, cboFastPitch.SelectedValue)
    End Sub

    Private Sub cboFootball_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFootball.SelectedIndexChanged
        ChangeObject(cboFootball, lblFootball, cboFootball.SelectedValue)
    End Sub

    Private Sub cboGolfBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboGolfBoys.SelectedIndexChanged
        ChangeObject(cboGolfBoys, lblGolfBoys, cboGolfBoys.SelectedValue)
    End Sub

    Private Sub cboGolfGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboGolfGirls.SelectedIndexChanged
        ChangeObject(cboGolfGirls, lblGolfGirls, cboGolfGirls.SelectedValue)
    End Sub

    Private Sub cboSlowPitch_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSlowPitch.SelectedIndexChanged
        ChangeObject(cboSlowPitch, lblSlowPitch, cboSlowPitch.SelectedValue)
    End Sub

    Private Sub cboSoccerBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSoccerBoys.SelectedIndexChanged
        ChangeObject(cboSoccerBoys, lblSoccerBoys, cboSoccerBoys.SelectedValue)
    End Sub

    Private Sub cboSoccerGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSoccerGirls.SelectedIndexChanged
        ChangeObject(cboSoccerGirls, lblSoccerGirls, cboSoccerGirls.SelectedValue)
    End Sub

    Private Sub cboSwimmingBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSwimmingBoys.SelectedIndexChanged
        ChangeObject(cboSwimmingBoys, lblSwimmingBoys, cboSwimmingBoys.SelectedValue)
    End Sub

    Private Sub cboSwimmingGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSwimmingGirls.SelectedIndexChanged
        ChangeObject(cboSwimmingGirls, lblSwimmingGirls, cboSwimmingGirls.SelectedValue)
    End Sub

    Private Sub cboTennisBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTennisBoys.SelectedIndexChanged
        ChangeObject(cboTennisBoys, lblTennisBoys, cboTennisBoys.SelectedValue)
    End Sub

    Private Sub cboTennisGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTennisGirls.SelectedIndexChanged
        ChangeObject(cboTennisGirls, lblTennisGirls, cboTennisGirls.SelectedValue)
    End Sub

    Private Sub cboTrackBoys_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTrackBoys.SelectedIndexChanged
        ChangeObject(cboTrackBoys, lblTrackBoys, cboTrackBoys.SelectedValue)
    End Sub

    Private Sub cboTrackGirls_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTrackGirls.SelectedIndexChanged
        ChangeObject(cboTrackGirls, lblTrackGirls, cboTrackGirls.SelectedValue)
    End Sub

    Private Sub cboVolleyball_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboVolleyball.SelectedIndexChanged
        ChangeObject(cboVolleyball, lblVolleyball, cboVolleyball.SelectedValue)
    End Sub

    Private Sub cboWrestling_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboWrestling.SelectedIndexChanged
        ChangeObject(cboWrestling, lblWrestling, cboWrestling.SelectedValue)
    End Sub

    Private Sub cboAcademic_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAcademic.SelectedIndexChanged
        ChangeObject(cboAcademic, lblAcademic, cboAcademic.SelectedValue)
    End Sub
End Class