Partial Class PlayoffAvailabilityFP
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "SoftballFP", clsFunctions.GetCurrentYear)

        If Session("user") = "" Then
            Response.Redirect(objDashboard.gLoginPage)
        End If

        If Not IsPostBack Then
            LoadData(Session("OSSAAID"))
        End If

        lblPageHeader.Text = "&nbsp;&nbsp;OFFICIALS " & objDashboard.gYear & " FAST PITCH PLAYOFF AVAILABILITY"
        lblInstructionsStep1a.Text = "Number of " & objDashboard.gYear & " FAST PITCH High School Dates worked through September 24th"
        LoadLabels()

    End Sub

    Private Sub LoadLabels()

        lblTourneyName.Text = objDashboard.gTourneyName1

        lblWedAB.Text = objDashboard.gTourney101
        lblThursAB.Text = objDashboard.gTourney102
        lblFriAB.Text = objDashboard.gTourney103
        lblSatAB.Text = objDashboard.gTourney104

        lblWed.Text = objDashboard.gTourney201
        lblThurs.Text = objDashboard.gTourney202
        lblFri.Text = objDashboard.gTourney203
        lblSat.Text = objDashboard.gTourney204

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

    Protected Sub cmdGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGoBack.Click
        Response.Redirect(objDashboard.gLoginPage)
    End Sub

#Region "Functions"

    Public Function SaveData(ByVal intOSSAAID As Integer) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String

        strReturn = VerifyData()

        If strReturn = "OK" Then
            strSQL = "UPDATE " & objDashboard.gTableSource & " SET "

            ' Experience Level This Season...
            strSQL = strSQL & "intOSSAAExperience = " & GetYearsOfExperience(intOSSAAID) & ", "
            strSQL = strSQL & "intStateTournamentsWorked = " & Me.intNumberOfStateTournaments.Text & ", "

            If cbLevel2.Checked = 0 And cbLevel3.Checked = 0 And cbLevel4.Checked = 0 Then
                strSQL = strSQL & "intLevel1None = 1, "
            Else
                If cbLevel1.Checked Then
                    strSQL = strSQL & "intLevel1None = 1, "
                Else
                    strSQL = strSQL & "intLevel1None = 0, "
                End If
                If cbLevel2.Checked Then
                    strSQL = strSQL & "intLevel2District = 1, "
                Else
                    strSQL = strSQL & "intLevel2District = 0, "
                End If
                If cbLevel3.Checked Then
                    strSQL = strSQL & "intLevel3Regional = 1, "
                Else
                    strSQL = strSQL & "intLevel3Regional = 0, "
                End If
                If cbLevel4.Checked Then
                    strSQL = strSQL & "intLevel4State = 1, "
                Else
                    strSQL = strSQL & "intLevel4State = 0, "
                End If
            End If

            strSQL = strSQL & "strHSGames = '" & Me.cboHSGames.SelectedValue & "', "
            strSQL = strSQL & "strHatSize = '" & Me.cboHatSize.SelectedValue & "', "            ' CDW added 9/20/2017...

            ' Availability...
            strSQL = strSQL & "intPlayoffAvail01 = " & IIf(Me.cbThursAB.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail02 = " & IIf(Me.cbFriAB.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail03 = " & IIf(Me.cbSatAB.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail04 = " & IIf(Me.cbThurs.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail05 = " & IIf(Me.cbFri.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail06 = " & IIf(Me.cbSat.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail07 = " & IIf(Me.cbWedAB.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail08 = " & IIf(Me.cbWed.Checked = True, 1, 0) & ", "

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

            strSQL = strSQL & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                strReturn = "Changes Saved."
            Catch
                strReturn = "FAILED"
            End Try
        Else
            ' Return message...
        End If

        Return strReturn

    End Function

    Public Function LoadData(ByVal intOSSAAID As Integer) As String
        On Error Resume Next
        Dim strReturn As String = "OK"
        Dim strSQL As String
        Dim ds As DataSet
        Dim e As Object

        strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        Else
            ' Load info...
            With ds.Tables(0).Rows(0)
                ' Playoff Level...
                'Me.intNumberOfYearsExperience.Text = .Item("intOSSAAExperience")
                Me.intNumberOfStateTournaments.Text = .Item("intStateTournamentsWorked")

                ' Playoff Level...
                Me.cbLevel1.Checked = .Item("intLevel1None")
                Me.cbLevel2.Checked = .Item("intLevel2District")
                Me.cbLevel3.Checked = .Item("intLevel3Regional")
                Me.cbLevel4.Checked = .Item("intLevel4State")

                Me.cboHSGames.SelectedValue = .Item("strHSGames")
                Me.cboHatSize.SelectedValue = .Item("strHatSize")   ' 9/20/2017 added...

                Me.cbThursAB.Checked = IIf(.Item("intPlayoffAvail01") = 1, True, False)
                Me.cbFriAB.Checked = IIf(.Item("intPlayoffAvail02") = 1, True, False)
                Me.cbSatAB.Checked = IIf(.Item("intPlayoffAvail03") = 1, True, False)
                Me.cbThurs.Checked = IIf(.Item("intPlayoffAvail04") = 1, True, False)
                Me.cbFri.Checked = IIf(.Item("intPlayoffAvail05") = 1, True, False)
                Me.cbSat.Checked = IIf(.Item("intPlayoffAvail06") = 1, True, False)
                Me.cbWedAB.Checked = IIf(.Item("intPlayoffAvail07") = 1, True, False)
                Me.cbWed.Checked = IIf(.Item("intPlayoffAvail08") = 1, True, False)

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

        strSQL = "INSERT INTO " & objDashboard.gTableSource & " (intOSSAAID, strSport, intYear) VALUES (" & intOSSAAID & ", 'SBF', " & clsFunctions.GetCurrentYear & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If cboHSGames.SelectedValue = "Select..." Then
            strReturn = "You must select : Number of FAST PITCH High School Dates worked THIS SEASON."
        ElseIf Me.intNumberOfStateTournaments.Text = "" Then
            strReturn = "You must select : Number of State Fast Pitch Tournaments worked."
        ElseIf cboHatSize.SelectedValue = "Select..." Then
            strReturn = "You must select : A FITTED HAT SIZE."
        Else
            strReturn = "OK"
        End If

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
            strTemp = strTemp.Replace("UPDATE ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function

    Public Function GetYearsOfExperience(intOSSAAID As Long) As Integer
        Dim strSQL As String
        Dim intYears As Integer = 0

        Try
            strSQL = "SELECT intYearsSoftball FROM prodOfficials WHERE intOSSAAID = " & intOSSAAID
            intYears = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            intYears = 0
        End Try

        Return intYears

    End Function
#End Region

End Class