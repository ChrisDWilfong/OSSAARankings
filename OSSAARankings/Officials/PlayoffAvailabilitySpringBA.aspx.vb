Partial Class PlayoffAvailabilitySpringBA

    Inherits System.Web.UI.Page
    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "Baseball", clsFunctions.GetCurrentYear)

        If Session("user") Is Nothing Then
            Response.Redirect(objDashboard.gLoginPage)
        End If
        If Session("user") = "" Then
            Response.Redirect(objDashboard.gLoginPage)
        End If

        If Not IsPostBack Then
            LoadData(Session("OSSAAID"))
        End If

        ' Add the YEAR to the appropriate labels and load the detail labels...
        lblPageHeader.Text = "&nbsp;&nbsp;OFFICIALS " & objDashboard.gYear & " SPRING BASEBALL PLAYOFF AVAILABILITY"
        LoadLabels()

    End Sub

    Private Sub LoadLabels()
        lblTournament1.Text = objDashboard.gTourneyName1
        lblThursAB1.Text = objDashboard.gTourney101
        lblThursAB2.Text = objDashboard.gTourney102
        lblFriAB1.Text = objDashboard.gTourney103
        lblFriAB2.Text = objDashboard.gTourney104
        lblSatAB.Text = objDashboard.gTourney105
        lblTournament2.Text = objDashboard.gTourneyName2
        lblThurs2A4A1.Text = objDashboard.gTourney201
        lblThurs2A4A2.Text = objDashboard.gTourney202
        lblFri2A4A1.Text = objDashboard.gTourney203
        lblFri2A4A2.Text = objDashboard.gTourney204
        lblSat2A4A.Text = objDashboard.gTourney205
        lblSat2A4A2.Text = objDashboard.gTourney206

        lblTournament3.Text = objDashboard.gTourneyName3
        lbl6A5A1.Text = objDashboard.gTourney301
        lbl6A5A2.Text = objDashboard.gTourney302
        lbl6A5A3.Text = objDashboard.gTourney303
        lbl6A5A4.Text = objDashboard.gTourney304
        lbl6A5A5.Text = objDashboard.gTourney305
        lbl6A5A6.Text = objDashboard.gTourney306
        If lbl6A5A4.Text = "" Then
            lbl6A5A4.Visible = False
            cb6A5A4.Visible = False
        End If
        If lbl6A5A5.Text = "" Then
            lbl6A5A5.Visible = False
            cb6A5A5.Visible = False
        End If
        If lbl6A5A6.Text = "" Then
            lbl6A5A6.Visible = False
            cb6A5A6.Visible = False
        End If
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
            strSQL = strSQL & "intOSSAAExperience = " & Me.intNumberOfYearsExperience.Text & ", "

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

            If cbLevelPref1.Checked Then
                strSQL = strSQL & "intLevelPrefAB = 1, "
            Else
                strSQL = strSQL & "intLevelPrefAB = 0, "
            End If
            If cbLevelPref2.Checked Then
                strSQL = strSQL & "intLevelPref2A3A4A = 1, "
            Else
                strSQL = strSQL & "intLevelPref2A3A4A = 0, "
            End If
            If cbLevelPref3.Checked Then
                strSQL = strSQL & "intLevelPref5A6A = 1, "
            Else
                strSQL = strSQL & "intLevelPref5A6A = 0, "
            End If

            strSQL = strSQL & "strHSGames = '" & Me.cboHSGames.SelectedValue & "', "
            strSQL = strSQL & "strCOLLevel = '" & Me.cboCollegeExp.SelectedValue & "', "
            strSQL = strSQL & "strHatSize = '" & Me.cboHatSize.SelectedValue & "', "
            strSQL = strSQL & "intStateTournamentsWorked = '" & Me.cboStateAppearances.SelectedValue & "', "

            strSQL = strSQL & "intPlayoffAvail01 = " & IIf(Me.cbThursAB1.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail02 = " & IIf(Me.cbThursAB2.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail03 = " & IIf(Me.cbFriAB1.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail04 = " & IIf(Me.cbFriAB2.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail05 = " & IIf(Me.cbSatAB.Checked = True, 1, 0) & ", "

            strSQL = strSQL & "intPlayoffAvail06 = " & IIf(Me.cbThurs2A4A1.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail07 = " & IIf(Me.cbThurs2A4A2.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail08 = " & IIf(Me.cbFri2A4A1.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail09 = " & IIf(Me.cbFri2A4A2.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail10 = " & IIf(Me.cbSat2A4A.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail11 = " & IIf(Me.cbSat2A4A2.Checked = True, 1, 0) & ", "

            strSQL = strSQL & "intPlayoffAvail12 = " & IIf(Me.cb6A5A1.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail13 = " & IIf(Me.cb6A5A2.Checked = True, 1, 0) & ", "
            strSQL = strSQL & "intPlayoffAvail14 = " & IIf(Me.cb6A5A3.Checked = True, 1, 0) & ", "
            If cb6A5A4.Visible Then strSQL = strSQL & "intPlayoffAvail15 = " & IIf(Me.cb6A5A4.Checked = True, 1, 0) & ", "
            If cb6A5A5.Visible Then strSQL = strSQL & "intPlayoffAvail16 = " & IIf(Me.cb6A5A5.Checked = True, 1, 0) & ", "
            If cb6A5A6.Visible Then strSQL = strSQL & "intPlayoffAvail17 = " & IIf(Me.cb6A5A6.Checked = True, 1, 0) & ", "

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

        strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE intOSSAAID = " & intOSSAAID & " AND strSport = 'BAS' AND intYear = " & clsFunctions.GetCurrentYear
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
                Me.intNumberOfYearsExperience.Text = .Item("intOSSAAExperience")

                ' Playoff Level...
                Me.cbLevel1.Checked = .Item("intLevel1None")
                Me.cbLevel2.Checked = .Item("intLevel2District")
                Me.cbLevel3.Checked = .Item("intLevel3Regional")
                Me.cbLevel4.Checked = .Item("intLevel4State")

                ' Playoff Level Prefered...
                Me.cbLevelPref1.Checked = .Item("intLevelPrefAB")
                Me.cbLevelPref2.Checked = .Item("intLevelPref2A3A4A")
                Me.cbLevelPref3.Checked = .Item("intLevelPref5A6A")

                Me.cboHSGames.SelectedValue = .Item("strHSGames")
                Me.cboCollegeExp.SelectedValue = .Item("strCOLLevel")
                Me.cboHatSize.SelectedValue = .Item("strHatSize")
                Me.cboStateAppearances.SelectedValue = .Item("intStateTournamentsWorked")

                Me.cbThursAB1.Checked = IIf(.Item("intPlayoffAvail01") = 1, True, False)
                Me.cbThursAB2.Checked = IIf(.Item("intPlayoffAvail02") = 1, True, False)
                Me.cbFriAB1.Checked = IIf(.Item("intPlayoffAvail03") = 1, True, False)
                Me.cbFriAB2.Checked = IIf(.Item("intPlayoffAvail04") = 1, True, False)
                Me.cbSatAB.Checked = IIf(.Item("intPlayoffAvail05") = 1, True, False)

                Me.cbThurs2A4A1.Checked = IIf(.Item("intPlayoffAvail06") = 1, True, False)
                Me.cbThurs2A4A2.Checked = IIf(.Item("intPlayoffAvail07") = 1, True, False)
                Me.cbFri2A4A1.Checked = IIf(.Item("intPlayoffAvail08") = 1, True, False)
                Me.cbFri2A4A2.Checked = IIf(.Item("intPlayoffAvail09") = 1, True, False)
                Me.cbSat2A4A.Checked = IIf(.Item("intPlayoffAvail10") = 1, True, False)
                Me.cbSat2A4A2.Checked = IIf(.Item("intPlayoffAvail11") = 1, True, False)

                'Me.cbThurs6A1.Checked = IIf(.Item("intPlayoffAvail11") = 1, True, False)
                'Me.cbThurs6A2.Checked = IIf(.Item("intPlayoffAvail12") = 1, True, False)
                'Me.cbFri6A1.Checked = IIf(.Item("intPlayoffAvail13") = 1, True, False)
                'Me.cbFri6A2.Checked = IIf(.Item("intPlayoffAvail14") = 1, True, False)
                'Me.cbSat6A.Checked = IIf(.Item("intPlayoffAvail15") = 1, True, False)

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

        strSQL = "INSERT INTO " & objDashboard.gTableSource & " (intOSSAAID, strSport, intYear) VALUES (" & intOSSAAID & ", 'BAS', " & clsOfficials.GetDefaultYear & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If Me.intNumberOfYearsExperience.Text = "" Then
            strReturn = "You must select : Number of years as an OSSAA Baseball Umpire."
        ElseIf cboHSGames.SelectedValue = "Select..." Then
            strReturn = "You must select : Number of BASEBALL High School Dates worked THIS SEASON."
        ElseIf cboCollegeExp.SelectedValue = "Select..." Then
            strReturn = "You must select : Jr College/College Baseball THIS SEASON"
        ElseIf cboHatSize.SelectedValue = "Select..." Then
            strReturn = "You must select a HAT SIZE"
        ElseIf cboStateAppearances.SelectedValue = "Select..." Then
            strReturn = "You must select : Number of Appearances at Fall and Spring State Baseball Tournament"
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
#End Region

End Class