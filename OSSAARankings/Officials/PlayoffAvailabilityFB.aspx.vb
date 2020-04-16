Public Class PlayoffAvailabilityFB
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("OSSAAID") = 23722

        If Session("user") = "" Then
            Response.Redirect("LoginWH.aspx")
        End If

        objDashboard = New clsDashboard("PLAYOFFAVAILSUB", "Football", clsFunctions.GetCurrentYear)

        If Not IsPostBack Then
            cboHomeTeam.DataSourceID = "SqlDataSource2"
            cboHomeTeam.DataBind()

            cboAwayTeam.DataSourceID = "SqlDataSource2"
            cboAwayTeam.DataBind()

            LoadData(Session("OSSAAID"))
        End If

        lblPageHeader.Text = "&nbsp;&nbsp;WHITE HAT " & objDashboard.gYear & " FOOTBALL PLAYOFF AVAILABILITY"
        LoadLabels()

    End Sub

    Public Sub LoadLabels()
        lblWeek1.Text = objDashboard.gTourneyName1
        lblWeek2.Text = objDashboard.gTourneyName2
        lblWeek3.Text = objDashboard.gTourneyName3
        lblWeek4.Text = objDashboard.gTourneyName4
        lblWeek5.Text = objDashboard.gTourneyName5
        cbWeek11.Text = objDashboard.gTourney101
        cbWeek12.Text = objDashboard.gTourney102
        cbWeek13.Text = objDashboard.gTourney103
        cbWeek21.Text = objDashboard.gTourney201
        cbWeek22.Text = objDashboard.gTourney202
        cbWeek23.Text = objDashboard.gTourney203
        cbWeek31.Text = objDashboard.gTourney301
        cbWeek32.Text = objDashboard.gTourney302
        cbWeek41.Text = objDashboard.gTourney401
        cbWeek42.Text = objDashboard.gTourney402
        cbWeek43.Text = objDashboard.gTourney403
        cbWeek51.Text = objDashboard.gTourney501
        cbWeek52.Text = objDashboard.gTourney502
    End Sub

    Private Sub cboHomeTeam_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHomeTeam.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboHomeTeam.Items.Insert(0, objItem)
    End Sub

    Private Sub cboAwayTeam_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAwayTeam.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboAwayTeam.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict1.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict1.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict2.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict2.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict3.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict3.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict4.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict4.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict5.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict5.Items.Insert(0, objItem)
    End Sub

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged

        If Not IsNumeric(Me.txtOSSAAID1.Text) Then
            Me.lblOfficialName1.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleUnusedOfficialFootball(CLng(Me.txtOSSAAID1.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                'Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName1.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "NOHEAT" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoHeatMessage
            ElseIf strFirstLast = "NOCONCUSSION" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoConcussionMessage
            ElseIf strFirstLast = "FAILED" Then
                'Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName1.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "DUPLICATE OFFICIAL" Then
                Me.lblOfficialName1.Text = "This official is already on a playoff crew."
                Me.txtOSSAAID1.Text = ""
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName1.Text = strFirstLast
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID2.TextChanged

        If Not IsNumeric(Me.txtOSSAAID2.Text) Then
            Me.lblOfficialName2.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleUnusedOfficialFootball(CLng(Me.txtOSSAAID2.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblOfficialName2.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "NOHEAT" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoHeatMessage
            ElseIf strFirstLast = "NOCONCUSSION" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoConcussionMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblOfficialName2.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "DUPLICATE OFFICIAL" Then
                Me.lblOfficialName2.Text = "This official is already on a playoff crew."
                Me.txtOSSAAID2.Text = ""
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName2.Text = strFirstLast
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID3.TextChanged
        If Not IsNumeric(Me.txtOSSAAID3.Text) Then
            Me.lblOfficialName3.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleUnusedOfficialFootball(CLng(Me.txtOSSAAID3.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblOfficialName3.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "NOHEAT" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoHeatMessage
            ElseIf strFirstLast = "NOCONCUSSION" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoConcussionMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblOfficialName3.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "DUPLICATE OFFICIAL" Then
                Me.lblOfficialName3.Text = "This official is already on a playoff crew."
                Me.txtOSSAAID3.Text = ""
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName3.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID4.TextChanged
        If Not IsNumeric(Me.txtOSSAAID4.Text) Then
            Me.lblOfficialName4.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleUnusedOfficialFootball(CLng(Me.txtOSSAAID4.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblOfficialName4.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "NOHEAT" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoHeatMessage
            ElseIf strFirstLast = "NOCONCUSSION" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoConcussionMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblOfficialName4.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "DUPLICATE OFFICIAL" Then
                Me.lblOfficialName4.Text = "This official is already on a playoff crew."
                Me.txtOSSAAID4.Text = ""
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName4.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID5.TextChanged
        If Not IsNumeric(Me.txtOSSAAID5.Text) Then
            Me.lblOfficialName5.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleUnusedOfficialFootball(CLng(Me.txtOSSAAID5.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblOfficialName5.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "NOHEAT" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoHeatMessage
            ElseIf strFirstLast = "NOCONCUSSION" Then
                Me.lblOfficialName1.Text = clsOfficials.GetNoConcussionMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblOfficialName5.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "DUPLICATE OFFICIAL" Then
                Me.lblOfficialName5.Text = "This official is already on a playoff crew."
                Me.txtOSSAAID5.Text = ""
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName5.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub cmdSave1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave1.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Protected Sub cmdSave2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave2.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

#Region "Functions"

    Public Function SaveData(ByVal intOSSAAID As Integer) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String

        strSQL = "UPDATE " & objDashboard.gTableSource & " SET "

        ' Official #1...
        If ParseString(Me.txtOSSAAID1.Text) = "" Then
            strSQL = strSQL & "intPlayoffCrewR = Null, "
            strSQL = strSQL & "strPlayoffCrewR = Null, "
        Else
            strSQL = strSQL & "intPlayoffCrewR = " & ParseString(Me.txtOSSAAID1.Text) & ", "
            strSQL = strSQL & "strPlayoffCrewR = '" & ParseString(Me.lblOfficialName1.Text) & "', "
        End If

        ' Official #2...
        If ParseString(Me.txtOSSAAID2.Text) = "" Then
            strSQL = strSQL & "intPlayoffCrewU = Null, "
            strSQL = strSQL & "strPlayoffCrewU = Null, "
        Else
            strSQL = strSQL & "intPlayoffCrewU = " & ParseString(Me.txtOSSAAID2.Text) & ", "
            strSQL = strSQL & "strPlayoffCrewU = '" & Me.lblOfficialName2.Text & "', "
        End If

        ' Official #3...
        If ParseString(Me.txtOSSAAID3.Text) = "" Then
            strSQL = strSQL & "intPlayoffCrewHL = Null, "
            strSQL = strSQL & "strPlayoffCrewHL = Null, "
        Else
            strSQL = strSQL & "intPlayoffCrewHL = " & ParseString(Me.txtOSSAAID3.Text) & ", "
            strSQL = strSQL & "strPlayoffCrewHL = '" & Me.lblOfficialName3.Text & "', "
        End If

        ' Official #4...
        If ParseString(Me.txtOSSAAID4.Text) = "" Then
            strSQL = strSQL & "intPlayoffCrewLJ = Null, "
            strSQL = strSQL & "strPlayoffCrewLJ = Null, "
        Else
            strSQL = strSQL & "intPlayoffCrewLJ = " & ParseString(Me.txtOSSAAID4.Text) & ", "
            strSQL = strSQL & "strPlayoffCrewLJ = '" & Me.lblOfficialName4.Text & "', "
        End If

        ' Official #5...
        If ParseString(Me.txtOSSAAID5.Text) = "" Then
            strSQL = strSQL & "intPlayoffCrewBJ = Null, "
            strSQL = strSQL & "strPlayoffCrewBJ = Null, "
        Else
            strSQL = strSQL & "intPlayoffCrewBJ = " & ParseString(Me.txtOSSAAID5.Text) & ", "
            strSQL = strSQL & "strPlayoffCrewBJ = '" & Me.lblOfficialName5.Text & "', "
        End If

        ' Level...
        If cb6A.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel6A = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel6A = 0, "
        End If
        If cb5A.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel5A = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel5A = 0, "
        End If
        If cb4A.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel4A = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel4A = 0, "
        End If
        If cb3A.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel3A = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel3A = 0, "
        End If
        If cb2A.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel2A = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel2A = 0, "
        End If
        If cbA.Checked Then
            strSQL = strSQL & "ysnPlayoffLevelA = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevelA = 0, "
        End If
        If cbB.Checked Then
            strSQL = strSQL & "ysnPlayoffLevelB = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevelB = 0, "
        End If
        If cbC.Checked Then
            strSQL = strSQL & "ysnPlayoffLevelC = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevelC = 0, "
        End If
        If cb8Man.Checked Then
            strSQL = strSQL & "ysnPlayoffLevel8Man = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffLevel8Man = 0, "
        End If

        ' Availability...
        If cbWeek11.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail01 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail01 = 0, "
        End If

        If cbWeek12.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail02 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail02 = 0, "
        End If

        If cbWeek13.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail03 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail03 = 0, "
        End If

        If cbWeek21.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail04 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail04 = 0, "
        End If

        If cbWeek22.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail05 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail05 = 0, "
        End If

        If cbWeek23.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail06 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail06 = 0, "
        End If

        If cbWeek31.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail07 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail07 = 0, "
        End If

        If cbWeek32.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail08 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail08 = 0, "
        End If

        If cbWeek41.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail09 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail09 = 0, "
        End If

        If cbWeek42.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail10 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail10 = 0, "
        End If

        If cbWeek43.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail11 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail11 = 0, "
        End If

        If cbWeek51.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail12 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail12 = 0, "
        End If

        If cbWeek52.Checked Then
            strSQL = strSQL & "ysnPlayoffUnavail13 = 1, "
        Else
            strSQL = strSQL & "ysnPlayoffUnavail13 = 0, "
        End If

        strSQL = strSQL & "intGame10TeamHome = " & Me.cboHomeTeam.SelectedValue & ", "
        strSQL = strSQL & "intGame10TeamAway = " & Me.cboAwayTeam.SelectedValue & ", "

        strSQL = strSQL & "intSchoolIDConflict1 = " & Me.cboTeamConflict1.SelectedValue & ", "
        If Me.cboTeamConflict1.SelectedValue > 0 Then
            strSQL = strSQL & "strSchoolConflict1 = '" & Me.cboTeamConflict1.SelectedItem.ToString & "', "
        End If
        strSQL = strSQL & "intSchoolIDConflict2 = " & Me.cboTeamConflict2.SelectedValue & ", "
        If Me.cboTeamConflict2.SelectedValue > 0 Then
            strSQL = strSQL & "strSchoolConflict2 = '" & Me.cboTeamConflict2.SelectedItem.ToString & "', "
        End If
        strSQL = strSQL & "intSchoolIDConflict3 = " & Me.cboTeamConflict3.SelectedValue & ", "
        If Me.cboTeamConflict3.SelectedValue > 0 Then
            strSQL = strSQL & "strSchoolConflict3 = '" & Me.cboTeamConflict3.SelectedItem.ToString & "', "
        End If
        strSQL = strSQL & "intSchoolIDConflict4 = " & Me.cboTeamConflict4.SelectedValue & ", "
        If Me.cboTeamConflict4.SelectedValue > 0 Then
            strSQL = strSQL & "strSchoolConflict4 = '" & Me.cboTeamConflict4.SelectedItem.ToString & "', "
        End If
        If Me.cboTeamConflict5.SelectedValue > 0 Then
            strSQL = strSQL & "strSchoolConflict5 = '" & Me.cboTeamConflict5.SelectedItem.ToString & "', "
        End If
        strSQL = strSQL & "intSchoolIDConflict5 = " & Me.cboTeamConflict5.SelectedValue & " "

        strSQL = strSQL & " WHERE intOSSAAID = " & intOSSAAID

        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            strReturn = "Changes Saved."
        Catch
            strReturn = "FAILED"
        End Try

        Return strReturn

    End Function

    Public Function LoadData(ByVal intOSSAAID As Integer) As String
        On Error Resume Next
        Dim strReturn As String = "OK"
        Dim strSQL As String
        Dim ds As DataSet
        Dim e As Object = Nothing

        strSQL = "SELECT * FROM prodOfficialsPlayoffs WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            'Me.panelStep3.Enabled = False
            'Me.panelStep3Collapsable.Enabled = False
            'Me.panelStep4.Enabled = False
            'Me.panelStep4Collapsable.Enabled = False
            'Me.panelStep5.Enabled = False
            'Me.panelStep5Collapsable.Enabled = False
            txtOSSAAID1.Text = Session("OSSAAID")
            Me.txtOSSAAID1_TextChanged(txtOSSAAID1, e)
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables.Count = 0 Then
            'Me.panelStep3.Enabled = False
            'Me.panelStep3Collapsable.Enabled = False
            'Me.panelStep4.Enabled = False
            'Me.panelStep4Collapsable.Enabled = False
            'Me.panelStep5.Enabled = False
            'Me.panelStep5Collapsable.Enabled = False
            txtOSSAAID1.Text = Session("OSSAAID")
            Me.txtOSSAAID1_TextChanged(txtOSSAAID1, e)
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            'Me.panelStep3.Enabled = False
            'Me.panelStep3Collapsable.Enabled = False
            'Me.panelStep4.Enabled = False
            'Me.panelStep4Collapsable.Enabled = False
            'Me.panelStep5.Enabled = False
            'Me.panelStep5Collapsable.Enabled = False
            txtOSSAAID1.Text = Session("OSSAAID")
            Me.txtOSSAAID1_TextChanged(txtOSSAAID1, e)
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        Else
            ' Load info...
            With ds.Tables(0).Rows(0)
                Me.txtOSSAAID1.Text = .Item("intPlayoffCrewR")
                Me.txtOSSAAID2.Text = .Item("intPlayoffCrewU")
                Me.txtOSSAAID3.Text = .Item("intPlayoffCrewHL")
                Me.txtOSSAAID4.Text = .Item("intPlayoffCrewLJ")
                Me.txtOSSAAID5.Text = .Item("intPlayoffCrewBJ")
                Me.lblOfficialName1.Text = .Item("strPlayoffCrewR")
                Me.lblOfficialName2.Text = .Item("strPlayoffCrewU")
                Me.lblOfficialName3.Text = .Item("strPlayoffCrewHL")
                Me.lblOfficialName4.Text = .Item("strPlayoffCrewLJ")
                Me.lblOfficialName5.Text = .Item("strPlayoffCrewBJ")
                Me.cb6A.Checked = .Item("ysnPlayoffLevel6A")
                Me.cb5A.Checked = .Item("ysnPlayoffLevel5A")
                Me.cb4A.Checked = .Item("ysnPlayoffLevel4A")
                Me.cb3A.Checked = .Item("ysnPlayoffLevel3A")
                Me.cb2A.Checked = .Item("ysnPlayoffLevel2A")
                Me.cbA.Checked = .Item("ysnPlayoffLevelA")
                Me.cbB.Checked = .Item("ysnPlayoffLevelB")
                Me.cbC.Checked = .Item("ysnPlayoffLevelC")
                Me.cb8Man.Checked = .Item("ysnPlayoffLevel8Man")
                Me.cbWeek11.Checked = .Item("ysnPlayoffUnavail01")
                Me.cbWeek12.Checked = .Item("ysnPlayoffUnavail02")
                Me.cbWeek13.Checked = .Item("ysnPlayoffUnavail03")
                Me.cbWeek21.Checked = .Item("ysnPlayoffUnavail04")
                Me.cbWeek22.Checked = .Item("ysnPlayoffUnavail05")
                Me.cbWeek23.Checked = .Item("ysnPlayoffUnavail06")
                Me.cbWeek31.Checked = .Item("ysnPlayoffUnavail07")
                Me.cbWeek32.Checked = .Item("ysnPlayoffUnavail08")
                Me.cbWeek41.Checked = .Item("ysnPlayoffUnavail09")
                Me.cbWeek42.Checked = .Item("ysnPlayoffUnavail10")
                Me.cbWeek43.Checked = .Item("ysnPlayoffUnavail11")
                Me.cbWeek51.Checked = .Item("ysnPlayoffUnavail12")
                Me.cbWeek52.Checked = .Item("ysnPlayoffUnavail13")

                Me.cboHomeTeam.SelectedValue = .Item("intGame10TeamHome")
                Me.cboAwayTeam.SelectedValue = .Item("intGame10TeamAway")

                If .Item("intSchoolIDConflict1") > 0 Then
                    Me.cboTeamConflict1.SelectedValue = .Item("intSchoolIDConflict1")
                End If
                If .Item("intSchoolIDConflict2") > 0 Then
                    Me.cboTeamConflict2.SelectedValue = .Item("intSchoolIDConflict2")
                End If
                If .Item("intSchoolIDConflict3") > 0 Then
                    Me.cboTeamConflict3.SelectedValue = .Item("intSchoolIDConflict3")
                End If
                If .Item("intSchoolIDConflict4") > 0 Then
                    Me.cboTeamConflict4.SelectedValue = .Item("intSchoolIDConflict4")
                End If
                If .Item("intSchoolIDConflict5") > 0 Then
                    Me.cboTeamConflict5.SelectedValue = .Item("intSchoolIDConflict5")
                End If

            End With

        End If

        Return strReturn

    End Function

    Public Sub CreateRecord(ByVal intOSSAAID As Integer, ByVal strPlayoffCrewName As String)
        Dim strSQL As String

        strSQL = "INSERT INTO prodOfficialsPlayoffs (intOSSAAID, strSport, intPlayoffCrewR, strPlayoffCrewR, intGame10TeamHome, intGame10TeamAway, strEmail) VALUES (" & intOSSAAID & ", 'FB', " & intOSSAAID & ", '" & strPlayoffCrewName & "', 10000, 10000, '" & Session("user") & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        Return strReturn
    End Function

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function
#End Region

    Protected Sub cmdGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGoBack.Click
        Response.Redirect("WHMainMenu.aspx")
    End Sub
End Class