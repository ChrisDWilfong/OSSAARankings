Public Class OfficialEdit
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("LoginWH.aspx")
        End If

        If Not IsPostBack Then
            Session("OfficialsReportId") = 0
        End If

        lblHeader.Text = ConfigurationManager.AppSettings("CurrentYearFall") & " OSSAA GAME REPORT FOR VARSITY GAMES"
        Session("gYear") = clsFunctions.GetCurrentYear

    End Sub

    Private Sub cboHomeTeam_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHomeTeam.DataBound
        cboHomeTeam.SelectedValue = 0
    End Sub

    Private Sub cboAwayTeam_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAwayTeam.DataBound
        cboAwayTeam.SelectedValue = 0
    End Sub

    Protected Sub cmdEditWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEditWeek.Click
        On Error Resume Next
        ' Load the week information...
        Dim intID As Integer = 0

        intID = Me.cboWeek.SelectedValue

        If intID = 0 Or intID = 1 Then
            lblMessage.Text = "You must select a week."
        Else
            Dim ds As DataSet
            Dim strSQL As String
            strSQL = "SELECT * FROM tblOfficialsReportsFootball WHERE Id = " & intID

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                If 1 = 2 Then
                    'If CheckTime(ds.Tables(0).Rows(0).Item("dtmStamp")) <> "OK" Then
                    Me.lblMessage.Text = "You cannot change a game 72 hours after it was created."
                Else
                    Me.lblMessage.Text = ""
                    ClearFields()
                    Me.cboWeekNew.Enabled = False
                    With ds.Tables(0).Rows(0)
                        Session("OfficialsReportId") = .Item("Id")
                        Me.cboWeekNew.Visible = False
                        Me.txtWeek.Visible = True
                        Me.txtWeek.Text = .Item("intWeek")
                        Session("showWeek") = .Item("intWeek")
                        Me.txtKey.Text = .Item("intKey")
                        Me.datGame.Value = .Item("datGame")
                        Me.cboHomeTeam.SelectedValue = .Item("intTeamHome")
                        If .Item("intTeamHome") = 0 Then
                            txtOtherHomeTeam.Text = .Item("strTeamHome")
                        Else
                            txtOtherHomeTeam.Text = ""
                        End If
                        Me.cboAwayTeam.SelectedValue = .Item("intTeamAway")
                        If .Item("intTeamAway") = 0 Then
                            txtOtherAwayTeam.Text = .Item("strTeamAway")
                        Else
                            txtOtherAwayTeam.Text = ""
                        End If
                        Me.txtLocation.Text = .Item("strNeutralLocation")
                        Me.cboFieldCleared.SelectedValue = .Item("strFieldReady")
                        Me.cboHalftimeLength.SelectedValue = .Item("intHalftimeLength")
                        Me.cboHomeTeamReady.SelectedValue = .Item("strTeamReadyHome")
                        Me.cboAwayTeamReady.SelectedValue = .Item("strTeamReadyAway")
                        Me.txtSideLineProblems.Text = .Item("strProblemsSidelineDetailsHome")
                        Me.cboEjections.SelectedValue = .Item("strEjections")
                        Me.txtTotalFoulsHome.Text = .Item("intFoulsTotalHome")
                        Me.txtTotalFoulsAway.Text = .Item("intFoulsTotalAway")
                        Me.txtTotalUnFoulsHome.Text = .Item("intFoulsUnsportHome")
                        Me.txtTotalUnFoulsAway.Text = .Item("intFoulsUnsportAway")
                        Me.cboExperienceFacility.SelectedValue = .Item("intRateFacility")
                        Me.cboExperienceHomeTeam.SelectedValue = .Item("intRateTeamHome")
                        Me.cboExperienceVisitorsTeam.SelectedValue = .Item("intRateTeamAway")
                        Me.strAdditionalComments.Text = .Item("strProblemsAdditional")

                        Me.txtCrew1.Text = .Item("intOSSAAIDCrew1")
                        Me.txtCrew2.Text = .Item("intOSSAAIDCrew2")
                        Me.txtCrew3.Text = .Item("intOSSAAIDCrew3")
                        Me.txtCrew4.Text = .Item("intOSSAAIDCrew4")
                        Me.txtCrew5.Text = .Item("intOSSAAIDCrew5")

                        ' Removed 9/4/2013...
                        ''Me.intFKTD.Text = .Item("intFKTD")
                        ''Me.intFKMins.Text = .Item("intFKMins")

                        LoadCrew(Session("OSSAAID"))
                    End With
                End If
            End If
        End If

    End Sub

    Public Function CheckTime(ByVal dtmIn As Date) As String
        Dim strReturn As String = "OK"

        'If DateDiff(DateInterval.Hour, dtmIn, Now) > 72 Then
        'strReturn = "FAILED"
        'End If

        Return strReturn

    End Function

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
        Catch

        End Try

        Return strTemp
    End Function

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        DoSave()
    End Sub

    Public Sub DoSave()
        On Error Resume Next
        Dim strSQL As String
        Dim intId As Long = 0
        Dim strMessage As String = ""
        Dim strTeamHome As String
        Dim strTeamAway As String
        Dim intTeamHome As Long
        Dim intTeamAway As Long

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            lblMessage.Text = strMessage
        Else
            ' Check to see if we are using the Selected Team(s) or Typed in Team(s)...
            strTeamHome = ""
            strTeamAway = ""
            intTeamHome = 0
            intTeamAway = 0

            If Me.txtOtherHomeTeam.Text = "" Then
                intTeamHome = Me.cboHomeTeam.SelectedValue
                strTeamHome = Me.cboHomeTeam.SelectedItem.Text
            Else
                intTeamHome = 0
                strTeamHome = ParseString(txtOtherHomeTeam.Text)
            End If

            If Me.txtOtherAwayTeam.Text = "" Then
                intTeamAway = Me.cboAwayTeam.SelectedValue
                strTeamAway = Me.cboAwayTeam.SelectedItem.Text
            Else
                intTeamAway = 0
                strTeamAway = ParseString(txtOtherAwayTeam.Text)
            End If

            If Session("OfficialsReportId") = 0 Then
                strSQL = "SELECT Id FROM tblOfficialsReportsFootball WHERE intKey = " & cboWeekNew.SelectedValue & " And intWhiteHatOSSAAID = " & Session("OSSAAID") & " AND intYear = " & Session("gYear")
                intId = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If intId > 0 Then
                    Me.lblMessage.Text = "Duplicate week."
                Else
                    strSQL = "INSERT INTO tblOfficialsReportsFootball (intWeek, intKey, intWhiteHatOSSAAID, strWhiteHatName, datGame, "
                    strSQL = strSQL & "intTeamHome, intTeamAway, strTeamHome, strTeamAway, strNeutralLocation, strFieldReady, "
                    strSQL = strSQL & "intHalftimeLength, strTeamReadyHome, strTeamReadyAway, strProblemsSidelineDetailsHome, "
                    strSQL = strSQL & "strEjections, intFoulsTotalHome, intFoulsTotalAway, intFoulsUnsportHome, intFoulsUnsportAway, intRateFacility, "

                    If Me.txtCrew1.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew1.Text) Then
                            strSQL = strSQL & "intOSSAAIDCrew1, "
                        End If
                    End If

                    If Me.txtCrew2.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew2.Text) Then
                            strSQL = strSQL & "intOSSAAIDCrew2, "
                        End If
                    End If

                    If Me.txtCrew3.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew3.Text) Then
                            strSQL = strSQL & "intOSSAAIDCrew3, "
                        End If
                    End If

                    If Me.txtCrew4.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew4.Text) Then
                            strSQL = strSQL & "intOSSAAIDCrew4, "
                        End If
                    End If

                    If Me.txtCrew5.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew5.Text) Then
                            strSQL = strSQL & "intOSSAAIDCrew5, "
                        End If
                    End If

                    strSQL = strSQL & "intOSSAAIDCrewWH, "

                    'If Me.intFKMins.Text = "" Then
                    'Else
                    '    If IsNumeric(Me.intFKMins.Text) Then
                    '        strSQL = strSQL & "intFKMins, "
                    '    End If
                    'End If

                    'If Me.intFKTD.Text = "" Then
                    'Else
                    '    If IsNumeric(Me.intFKTD.Text) Then
                    '        strSQL = strSQL & "intFKTD, "
                    '    End If
                    'End If

                    strSQL = strSQL & "intRateTeamHome, intRateTeamAway, strSubmittedBy, strProblemsAdditional) VALUES ("
                    Session("showWeek") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intWeek FROM tblOfficialsWeeksFootball WHERE intKey = " & Me.cboWeekNew.SelectedValue)
                    strSQL = strSQL & Session("showWeek") & ", "
                    strSQL = strSQL & Me.cboWeekNew.SelectedValue & ", "
                    strSQL = strSQL & Session("OSSAAID") & ", "
                    strSQL = strSQL & "'" & Session("OfficialName") & "', "
                    If datGame.Value = "1900-01-01" Then
                        strSQL = strSQL & "'" & Now.ToShortDateString & "', "
                    ElseIf datGame.Text = "Null" Then
                        strSQL = strSQL & "'" & Now.ToShortDateString & "', "
                    Else
                        strSQL = strSQL & "'" & datGame.Value & "', "
                    End If
                    strSQL = strSQL & intTeamHome & ", "
                    strSQL = strSQL & intTeamAway & ", "
                    strSQL = strSQL & "'" & strTeamHome & "', "
                    strSQL = strSQL & "'" & strTeamAway & "', "
                    strSQL = strSQL & "'" & ParseString(Me.txtLocation.Text) & "', "
                    strSQL = strSQL & "'" & Me.cboFieldCleared.SelectedValue & "', "
                    strSQL = strSQL & Me.cboHalftimeLength.SelectedValue & ", "
                    strSQL = strSQL & "'" & Me.cboHomeTeamReady.SelectedValue & "', "
                    strSQL = strSQL & "'" & Me.cboAwayTeamReady.SelectedValue & "', "
                    strSQL = strSQL & "'" & ParseString(Me.txtSideLineProblems.Text) & "', "
                    strSQL = strSQL & "'" & Me.cboEjections.SelectedValue & "', "
                    strSQL = strSQL & Me.txtTotalFoulsHome.Text & ", "
                    strSQL = strSQL & Me.txtTotalFoulsAway.Text & ", "
                    strSQL = strSQL & Me.txtTotalUnFoulsHome.Text & ", "
                    strSQL = strSQL & Me.txtTotalUnFoulsAway.Text & ", "
                    strSQL = strSQL & Me.cboExperienceFacility.SelectedValue & ", "

                    If Me.txtCrew1.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew1.Text) Then
                            strSQL = strSQL & Me.txtCrew1.Text & ", "
                        End If
                    End If

                    If Me.txtCrew2.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew2.Text) Then
                            strSQL = strSQL & Me.txtCrew2.Text & ", "
                        End If
                    End If

                    If Me.txtCrew3.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew3.Text) Then
                            strSQL = strSQL & Me.txtCrew3.Text & ", "
                        End If
                    End If

                    If Me.txtCrew4.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew4.Text) Then
                            strSQL = strSQL & Me.txtCrew4.Text & ", "
                        End If
                    End If

                    If Me.txtCrew5.Text = "" Then
                    Else
                        If IsNumeric(Me.txtCrew5.Text) Then
                            strSQL = strSQL & Me.txtCrew5.Text & ", "
                        End If
                    End If

                    strSQL = strSQL & Session("OSSAAID") & ", "

                    ''If Me.intFKMins.Text = "" Then
                    ''Else
                    ''    If IsNumeric(Me.intFKMins.Text) Then
                    ''        strSQL = strSQL & Me.intFKMins.Text & ", "
                    ''    End If
                    ''End If

                    ''If Me.intFKTD.Text = "" Then
                    ''Else
                    ''    If IsNumeric(Me.intFKTD.Text) Then
                    ''        strSQL = strSQL & Me.intFKTD.Text & ", "
                    ''    End If
                    ''End If

                    strSQL = strSQL & Me.cboExperienceHomeTeam.SelectedValue & ", "
                    strSQL = strSQL & Me.cboExperienceVisitorsTeam.SelectedValue & ", "
                    strSQL = strSQL & "'" & Session("user") & "', "
                    strSQL = strSQL & "'" & ParseString(Me.strAdditionalComments.Text) & "')"

                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                    Me.cboWeek.DataBind()
                    Me.lblMessage.Text = "New Week Added."
                    Me.lblMessage1.Text = "New Week Added."
                End If
            Else
                strSQL = "UPDATE tblOfficialsReportsFootball SET "
                If datGame.Value = "1900-01-01" Then
                    strSQL = strSQL & "datGame = '" & Now.ToShortDateString & "', "
                ElseIf datGame.Text = "Null" Then
                    strSQL = strSQL & "datGame = '" & Now.ToShortDateString & "', "
                Else
                    strSQL = strSQL & "datGame = '" & Me.datGame.Value & "', "
                End If
                strSQL = strSQL & "intTeamHome = " & intTeamHome & ", "
                strSQL = strSQL & "intTeamAway = " & intTeamAway & ", "
                strSQL = strSQL & "strTeamHome = '" & ParseString(strTeamHome) & "', "
                strSQL = strSQL & "strTeamAway = '" & ParseString(strTeamAway) & "', "
                strSQL = strSQL & "strNeutralLocation = '" & Me.txtLocation.Text & "', "
                strSQL = strSQL & "strFieldReady = '" & Me.cboFieldCleared.SelectedValue & "', "
                strSQL = strSQL & "intHalftimeLength = " & Me.cboHalftimeLength.SelectedValue & ", "

                strSQL = strSQL & "strTeamReadyHome = '" & Me.cboHomeTeamReady.SelectedValue & "', "
                strSQL = strSQL & "strTeamReadyAway = '" & Me.cboAwayTeamReady.SelectedValue & "', "

                strSQL = strSQL & "strProblemsSidelineDetailsHome = '" & ParseString(Me.txtSideLineProblems.Text) & "', "
                strSQL = strSQL & "strEjections = '" & Me.cboEjections.SelectedValue & "', "
                strSQL = strSQL & "intFoulsTotalHome = " & Me.txtTotalFoulsHome.Text & ", "
                strSQL = strSQL & "intFoulsTotalAway = " & Me.txtTotalFoulsAway.Text & ", "
                strSQL = strSQL & "intFoulsUnsportHome = " & Me.txtTotalUnFoulsHome.Text & ", "
                strSQL = strSQL & "intFoulsUnsportAway = " & Me.txtTotalUnFoulsAway.Text & ", "

                strSQL = strSQL & "intRateFacility = " & Me.cboExperienceFacility.SelectedValue & ", "
                strSQL = strSQL & "intRateTeamHome = " & Me.cboExperienceHomeTeam.SelectedValue & ", "
                strSQL = strSQL & "intRateTeamAway = " & Me.cboExperienceVisitorsTeam.SelectedValue & ", "
                strSQL = strSQL & "strSubmittedBy = '" & Session("user") & "', "

                If Me.txtCrew1.Text = "" Then
                Else
                    If IsNumeric(Me.txtCrew1.Text) Then
                        strSQL = strSQL & "intOSSAAIDCrew1 = " & Me.txtCrew1.Text & ", "
                    End If
                End If

                If Me.txtCrew2.Text = "" Then
                Else
                    If IsNumeric(Me.txtCrew2.Text) Then
                        strSQL = strSQL & "intOSSAAIDCrew2 = " & Me.txtCrew2.Text & ", "
                    End If
                End If

                If Me.txtCrew3.Text = "" Then
                Else
                    If IsNumeric(Me.txtCrew3.Text) Then
                        strSQL = strSQL & "intOSSAAIDCrew3 = " & Me.txtCrew3.Text & ", "
                    End If
                End If

                If Me.txtCrew4.Text = "" Then
                Else
                    If IsNumeric(Me.txtCrew4.Text) Then
                        strSQL = strSQL & "intOSSAAIDCrew4 = " & Me.txtCrew4.Text & ", "
                    End If
                End If

                If Me.txtCrew5.Text = "" Then
                Else
                    If IsNumeric(Me.txtCrew5.Text) Then
                        strSQL = strSQL & "intOSSAAIDCrew5 = " & Me.txtCrew5.Text & ", "
                    End If
                End If

                strSQL = strSQL & "intOSSAAIDCrewWH = " & Session("OSSAAID") & ", "

                ''If Me.intFKMins.Text = "" Then
                ''Else
                ''    If IsNumeric(Me.intFKMins.Text) Then
                ''        strSQL = strSQL & "intFKMins = " & Me.intFKMins.Text & ", "
                ''    End If
                ''End If

                ''If Me.intFKTD.Text = "" Then
                ''Else
                ''    If IsNumeric(Me.intFKTD.Text) Then
                ''        strSQL = strSQL & "intFKTD = " & Me.intFKTD.Text & ", "
                ''    End If
                ''End If

                strSQL = strSQL & "strProblemsAdditional = '" & ParseString(Me.strAdditionalComments.Text) & "' "

                strSQL = strSQL & "WHERE Id = " & Session("OfficialsReportId")

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                Me.cboWeek.DataBind()

                Me.lblMessage.Text = "Changes Saved."

            End If

            ' ================================ ALLOW THEM TO ENTER THE OFFICIAL BUT SEND AN EMAIL TO SHEREE...
            Dim strSubject As String
            ' Let's verify that the Crew are all Eligible...
            If clsOfficials.IsEligibleOfficialFootball(CLng(txtCrew1.Text), True) Like "FAILED%" Then
                strSubject = "WHITE HAT (" & Session("OSSAAID") & ") ENTERED INELIGIBLE OFFICIAL : " & txtCrew1.Text & " (FOR WEEK " & Session("showWeek") & ")"
                ' CDW removed 3/5/2019...
                '''''clsEmail.SendEmail(Me, "", "sriddell@ossaa.com", "cwilfong@ossaa.com", strSubject)
            End If

            If clsOfficials.IsEligibleOfficialFootball(CLng(txtCrew2.Text), True) Like "FAILED%" Then
                strSubject = "WHITE HAT (" & Session("OSSAAID") & ") ENTERED INELIGIBLE OFFICIAL : " & txtCrew2.Text & " (FOR WEEK " & Session("showWeek") & ")"
                ' CDW removed 3/5/2019...
                '''''clsEmail.SendEmail(Me, "", "sriddell@ossaa.com", "cwilfong@ossaa.com", strSubject)
            End If

            If clsOfficials.IsEligibleOfficialFootball(CLng(txtCrew3.Text), True) Like "FAILED%" Then
                strSubject = "WHITE HAT (" & Session("OSSAAID") & ") ENTERED INELIGIBLE OFFICIAL : " & txtCrew3.Text & " (FOR WEEK " & Session("showWeek") & ")"
                ' CDW removed 3/5/2019...
                '''''clsEmail.SendEmail(Me, "", "sriddell@ossaa.com", "cwilfong@ossaa.com", strSubject)
            End If

            If clsOfficials.IsEligibleOfficialFootball(CLng(txtCrew4.Text), True) Like "FAILED%" Then
                strSubject = "WHITE HAT (" & Session("OSSAAID") & ") ENTERED INELIGIBLE OFFICIAL : " & txtCrew4.Text & " (FOR WEEK " & Session("showWeek") & ")"
                ' CDW removed 3/5/2019...
                '''''clsEmail.SendEmail(Me, "", "sriddell@ossaa.com", "cwilfong@ossaa.com", strSubject)
            End If

            If clsOfficials.IsEligibleOfficialFootball(CLng(txtCrew5.Text), True) Like "FAILED%" Then
                strSubject = "WHITE HAT (" & Session("OSSAAID") & ") ENTERED INELIGIBLE OFFICIAL : " & txtCrew5.Text & " (FOR WEEK " & Session("showWeek") & ")"
                ' CDW removed 3/5/2019...
                '''''clsEmail.SendEmail(Me, "", "sriddell@ossaa.com", "cwilfong@ossaa.com", strSubject)
            End If

        End If

    End Sub

    Public Sub ClearFields()
        On Error Resume Next

        Me.cboWeekNew.SelectedValue = -1
        Me.txtKey.Text = ""
        Me.datGame.Value = ""
        Me.cboHomeTeam.SelectedValue = 0
        Me.cboAwayTeam.SelectedValue = 0
        Me.txtOtherHomeTeam.Text = ""
        Me.txtOtherAwayTeam.Text = ""
        Me.txtLocation.Text = ""
        Me.cboFieldCleared.SelectedValue = "NONE"
        Me.cboHalftimeLength.SelectedValue = 0
        Me.cboHomeTeamReady.SelectedValue = "NONE"
        Me.cboAwayTeamReady.SelectedValue = "NONE"
        Me.txtSideLineProblems.Text = ""
        Me.cboEjections.SelectedValue = "NONE"
        Me.txtTotalFoulsHome.Text = 0
        Me.txtTotalFoulsAway.Text = 0
        Me.txtTotalUnFoulsHome.Text = 0
        Me.txtTotalUnFoulsAway.Text = 0
        Me.cboExperienceFacility.SelectedValue = 0
        Me.cboExperienceHomeTeam.SelectedValue = 0
        Me.cboExperienceVisitorsTeam.SelectedValue = 0
        Me.strAdditionalComments.Text = ""
        Me.cboWeekNew.Enabled = True
        Me.txtCrew1.Text = ""
        Me.txtCrew2.Text = ""
        Me.txtCrew3.Text = ""
        Me.txtCrew4.Text = ""
        Me.txtCrew5.Text = ""
        ''Me.intFKMins.Text = ""
        ''Me.intFKTD.Text = ""

    End Sub

    Public Function VerifyFields() As String
        Dim strReturn As String = "OK"

        If cboWeekNew.SelectedValue = -1 And txtWeek.Text = "" Then
            strReturn = "You must select a WEEK."
        ElseIf datGame.Text = "" Then
            strReturn = "You must select a GAME DATE."
        ElseIf (cboHomeTeam.SelectedValue = 0 And txtOtherHomeTeam.Text = "") Then
            strReturn = "You must select a HOME TEAM."
        ElseIf (cboAwayTeam.SelectedValue = 0 And txtOtherAwayTeam.Text = "") Then
            strReturn = "You must select a VISITING TEAM."
        ElseIf cboFieldCleared.SelectedValue = "NONE" Then
            strReturn = "You must select a FIELDS READY AND START TIME value."
        ElseIf cboHalftimeLength.SelectedValue = 0 Then
            strReturn = "You must select a HALFTIME LENGTH."
        ElseIf cboHomeTeamReady.SelectedValue = "NONE" Then
            strReturn = "You must answer the HOME TEAM READY question."
        ElseIf cboAwayTeamReady.SelectedValue = "NONE" Then
            strReturn = "You must answer the VISITING TEAM READY question."
        ElseIf cboEjections.SelectedValue = "NONE" Then
            strReturn = "You must answer the EJECTIONS question."
        ElseIf txtTotalFoulsHome.Text = "0" And txtTotalFoulsAway.Text = "0" And txtTotalUnFoulsHome.Text = "0" And txtTotalUnFoulsAway.Text = "0" Then
            strReturn = "You must enter a value for fouls."
        ElseIf Me.cboExperienceFacility.SelectedValue = 0 Then
            strReturn = "You must enter a FACILITY rating."
        ElseIf Me.cboExperienceHomeTeam.SelectedValue = 0 Then
            strReturn = "You must enter a HOME TEAM rating."
        ElseIf Me.cboExperienceVisitorsTeam.SelectedValue = 0 Then
            strReturn = "You must enter a VISITING TEAM rating."
        ElseIf Me.txtCrew1.Text = "" Then
            strReturn = "You must enter CREW (R)."
        ElseIf Me.txtCrew2.Text = "" Then
            strReturn = "You must enter CREW (U)."
        ElseIf Me.txtCrew3.Text = "" Then
            strReturn = "You must enter CREW (LJ)."
        ElseIf Me.txtCrew4.Text = "" Then
            strReturn = "You must enter CREW (BJ)."
        ElseIf Me.txtCrew5.Text = "" Then
            strReturn = "You must enter CREW (HL)."
        ElseIf Me.txtTotalFoulsHome.Text = "" Then
            strReturn = "Total Fouls (Home)"
        ElseIf Me.txtTotalFoulsAway.Text = "" Then
            strReturn = "Total Fouls (Away)"
        ElseIf Me.txtTotalUnFoulsHome.Text = "" Then
            strReturn = "Total Unsportsmanlike Fouls (Home)"
        ElseIf Me.txtTotalUnFoulsAway.Text = "" Then
            strReturn = "Total Unsportsmanlike Fouls (Away)"
            'ElseIf datGame.Value = "1900-01-01" Then
            'strReturn = "Please enter a game date."
            'ElseIf datGame.Text = "Null" Then
            'strReturn = "Please enter a game date."
        Else
            strReturn = "OK"
        End If
        Return strReturn
    End Function

    Protected Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        Session("OfficialsReportId") = 0
        Me.cboWeekNew.Visible = True
        Me.txtWeek.Visible = False
        ClearFields()
        LoadCrew(Session("OSSAAID"))
        Me.lblMessage.Text = "Update New Week Information."
    End Sub

    Protected Sub cmdSave1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave1.Click
        DoSave()
    End Sub

    Public Sub LoadCrew(ByVal intOSSAAID As Integer)
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT TOP 1 intOSSAAIDCrew1, intOSSAAIDCrew2, intOSSAAIDCrew3, intOSSAAIDCrew4, intOSSAAIDCrew5 FROM prodOfficials WHERE intOSSAAID = " & intOSSAAID
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                If Not .Item("intOSSAAIDCrew1") Is System.DBNull.Value Then
                    If Me.txtCrew1.Text = "" Then
                        Me.txtCrew1.Text = .Item("intOSSAAIDCrew1")
                    End If
                End If
                If Not .Item("intOSSAAIDCrew2") Is System.DBNull.Value Then
                    If Me.txtCrew2.Text = "" Then
                        Me.txtCrew2.Text = .Item("intOSSAAIDCrew2")
                    End If
                End If
                If Not .Item("intOSSAAIDCrew3") Is System.DBNull.Value Then
                    If Me.txtCrew3.Text = "" Then
                        Me.txtCrew3.Text = .Item("intOSSAAIDCrew3")
                    End If
                End If
                If Not .Item("intOSSAAIDCrew4") Is System.DBNull.Value Then
                    If Me.txtCrew4.Text = "" Then
                        Me.txtCrew4.Text = .Item("intOSSAAIDCrew4")
                    End If
                End If
                If Not .Item("intOSSAAIDCrew5") Is System.DBNull.Value Then
                    If Me.txtCrew5.Text = "" Then
                        Me.txtCrew5.Text = .Item("intOSSAAIDCrew5")
                    End If
                End If
            End With
        End If

    End Sub

    Private Sub cboWeek_DataBound(sender As Object, e As System.EventArgs) Handles cboWeek.DataBound
        Me.cboWeek.Items.Insert(0, "Select...")
    End Sub
End Class