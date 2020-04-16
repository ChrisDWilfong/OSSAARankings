Imports System.Data
Imports OSSAARankings.SqlHelper

Partial Class ucScheduleAdd
    Inherits System.Web.UI.UserControl

    Public Sub UpdatePitchCounts(scheduleID As Long)
        Dim strSQL As String = ""
        Dim intPitchCount As Integer = 0
        Dim strPitcherID As String = "0"

        ' Added 2/23/2016...
        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers1")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID1 = 0, intPitchCount1 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount1.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount1.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID1 = " & strPitcherID & ", intPitchCount1 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers2")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID2 = 0, intPitchCount2 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount2.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount2.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID2 = " & strPitcherID & ", intPitchCount2 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers3")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID3 = 0, intPitchCount3 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount3.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount3.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID3 = " & strPitcherID & ", intPitchCount3 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers4")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID4 = 0, intPitchCount4 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount4.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount4.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID4 = " & strPitcherID & ", intPitchCount4 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers5")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID5 = 0, intPitchCount5 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount5.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount5.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID5 = " & strPitcherID & ", intPitchCount5 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers6")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID6 = 0, intPitchCount6 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount6.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount6.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID6 = " & strPitcherID & ", intPitchCount6 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

        strPitcherID = Request.Item("ucSchedule1$ucScheduleAdd1$DropDownListPitchers7")
        If strPitcherID = "0" Then
            strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID7 = 0, intPitchCount7 = 0 WHERE scheduleID = " & scheduleID
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        Else
            If IsNumeric(txtPitchCount7.Text) Then
                intPitchCount = 0
                intPitchCount = CInt(txtPitchCount7.Text)
                If intPitchCount < 300 Then
                    strSQL = strSQL & "UPDATE tblSchedules SET intPitcherID7 = " & strPitcherID & ", intPitchCount7 = " & intPitchCount & " WHERE scheduleID = " & scheduleID
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                End If
            End If
        End If

    End Sub

    Protected Sub cmdSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveChanges.Click
        Dim strValidate As String
        Dim strSQL As String
        Dim strSQLPG As String      ' Post Gender SQL statement...
        Dim strSQLSW As String       ' Swap SQL Statement...
        Dim strSport As String
        Dim intDistrict As Integer
        Dim strGameTime As String
        Dim intScoreMy As Integer = 0
        Dim intScoreOpp As Integer = 0
        Dim strWL As String = "-"
        Dim intTeamIDPG As Long = 0

        Dim intRankMy As Long = 0           ' Added 12/19/2014...
        Dim intRankThem As Long = 0

        Dim strScoreEntered As String = ""       ' CDW added 9/26/2019...

        strSport = Session("memgSport")
        strValidate = Validate(strSport)
        ' Do validation...
        If strValidate = "OK" Then
            ' Get the Scores...
            Try
                intScoreMy = CInt(Me.txtScoreMy.Text)
                If intScoreMy = 0 Then
                    intScoreMy = CInt(Request.Item("ucSchedule1$ucScheduleAdd1$txtScoreMy"))
                End If
            Catch ex As Exception
                intScoreMy = 0
            End Try
            Try
                intScoreOpp = CInt(Me.txtScoreOpp.Text)
                If intScoreOpp = 0 Then
                    intScoreOpp = CInt(Request.Item("ucSchedule1$ucScheduleAdd1$txtScoreOpp"))
                End If
            Catch ex As Exception
                intScoreOpp = 0
            End Try

            If Session("memgResults") = 2 Then
                If (cboGameType.SelectedValue = "NONDIST" Or cboGameType.SelectedValue = "DIST") And strSport = "Wrestling" Then
                    strWL = GetWL(intScoreMy, intScoreOpp)          ' Added 12/10/2104...
                Else
                    strWL = "-"
                End If
            ElseIf Session("memgShowRecord") = 1 Then
                strWL = GetWL(intScoreMy, intScoreOpp)
            Else
                strWL = "-"
            End If

            If Session("memgDistrict") = 1 Then
                If Me.cboSchools.SelectedIndex = 0 Then
                    intDistrict = 0
                Else
                    intDistrict = clsSchedules.IsDistrictGame(Session("memgTeamID"), Me.cboSchools.SelectedValue)
                End If
            Else
                intDistrict = 0
            End If

            strGameTime = Me.cboGameTimeHour.Text & ":" & Me.cboGameTimeMinute.Text & " " & Me.cboGameAMPM.Text

            ' =============================================================================================================
            ' NEW GAME, INSERT...
            If Session("memgScheduleID") = 0 Then           ' NEW GAME...

                intTeamIDPG = clsTeams.GetTeamID(Session("memgPostGender"), Session("memgSchoolID"), clsFunctions.GetCurrentYear)
                Dim intoTeamIDPG As Long = 0
                intoTeamIDPG = clsTeams.GetTeamID(Session("memgPostGender"), SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT schoolID FROM tblTeams WHERE teamID = '" & cboSchools.SelectedValue & "'"), clsFunctions.GetCurrentYear)
                Dim sStatus As String = ""

                sStatus = cboStatus.SelectedValue
                If intScoreMy > 0 Or intScoreOpp > 0 Then           ' 10/31/2014 added...
                    If sStatus = "Select..." Then
                        sStatus = "Final"
                    End If
                End If

                If Me.txtSchool.Text = "" Then          ' BOTH TEAMS SELECTED...

                    Session("memgoSportID") = clsTeams.GetSportIDForTeam(cboSchools.SelectedValue)

                    intRankMy = clsRankings.GetRankingByDate(Session("memgSportID"), Session("memgTeamID"), RadDatePicker1.SelectedDate, Session("memgCurrentWeekIDDisplay"))
                    intRankThem = clsRankings.GetRankingByDate(Session("memgoSportID"), cboSchools.SelectedValue, RadDatePicker1.SelectedDate, 0)

                    strSQL = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, strType, intYear, strGameAddedByWho, tournament, TotalScore, oTotalScore, WL"
                    strSQLPG = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, strType, intYear, strGameAddedByWho, tournament"
                    If intScoreMy > 0 Or intScoreOpp > 0 Then       ' 11/12/2013 added....
                        strSQL = strSQL & ", dtmScore, strScoreByWho"
                    End If

                    If cboSchools.SelectedValue = 0 Then        ' No OSSAA team selected so NO SWAP... 8/2/2013 added...
                        strSQLSW = ""
                    Else
                        If strSport = "Volleyball" Then
                            strSQLSW = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, strType, intYear, strGameAddedByWho, tournament, TotalScore, oTotalScore, WL, strResults"
                        Else
                            strSQLSW = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, strType, intYear, strGameAddedByWho, tournament, TotalScore, oTotalScore, WL"
                        End If
                    End If
                    If intScoreMy > 0 Or intScoreOpp > 0 Then
                        strSQLSW = strSQLSW & ", dtmScore, strScoreByWho"
                    End If
                    If rowResults2.Visible Then
                        strSQL = strSQL & ", strResults"
                    End If

                    ' VALUES...
                    strSQL = strSQL & ", District) VALUES ('" & sStatus & "', " & Session("memgTeamID") & ", " & cboSchools.SelectedValue & ", " & intRankMy & "," & intRankThem & ", '" & Session("memgSportID") & "', '" & Session("memgoSportID") & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & cboGameLocation.SelectedValue & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', " & intScoreMy & ", " & intScoreOpp & ", '" & strWL & "'"
                    If intScoreMy > 0 Or intScoreOpp > 0 Then
                        strSQL = strSQL & ", '" & Now & "', '" & Session("memgWhoIsLoggedIn") & "'"
                        ' CDW added 9/26/2019...
                        strScoreEntered = clsMembers.LogScoreEntered(0, Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), cboSchools.SelectedValue, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)
                    End If
                    'strSQL = strSQL & ")"
                    strSQLPG = strSQLPG & ", District) VALUES ('" & sStatus & "', " & intTeamIDPG & ", " & intoTeamIDPG & ", " & intRankMy & ", " & intRankThem & ", '" & Session("memgPostGender") & "', '" & SwapSportGender(Session("memgoSportID")) & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & cboGameLocation.SelectedValue & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', 0)"

                    If cboSchools.SelectedValue = 0 Then        ' No OSSAA team selected so NO SWAP... 8/2/2013 added...
                        strSQLSW = ""
                    Else
                        If strSport = "Volleyball" Then
                            strSQLSW = strSQLSW & ", District) VALUES ('" & sStatus & "', " & cboSchools.SelectedValue & ", " & Session("memgTeamID") & ", " & intRankThem & ", " & intRankMy & ", '" & Session("memgoSportID") & "', '" & Session("memgSportID") & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', " & intScoreOpp & ", " & intScoreMy & ", '" & clsGames.SwapWL(strWL) & "','" & Me.txtResults.Text & "'"
                            If intScoreMy > 0 Or intScoreOpp > 0 Then
                                strSQLSW = strSQLSW & ", '" & Now & "', '" & Session("memgWhoIsLoggedIn") & "'"
                            End If
                            strSQLSW = strSQLSW & ", 0)"
                        Else
                            strSQLSW = strSQLSW & ", District) VALUES ('" & sStatus & "', " & cboSchools.SelectedValue & ", " & Session("memgTeamID") & ", " & intRankThem & ", " & intRankMy & ", '" & Session("memgoSportID") & "', '" & Session("memgSportID") & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', " & intScoreOpp & ", " & intScoreMy & ", '" & clsGames.SwapWL(strWL) & "'"
                            If intScoreMy > 0 Or intScoreOpp > 0 Then
                                strSQLSW = strSQLSW & ", '" & Now & "', '" & Session("memgWhoIsLoggedIn") & "'"
                            End If
                            strSQLSW = strSQLSW & ", 0)"
                        End If
                    End If

                    If rowResults2.Visible Then
                        strSQL = strSQL & ", '" & txtResults.Text & "'"
                    End If
                    strSQL = strSQL & ", " & intDistrict & ")"

                Else        ' TOURNAMENT GAME???

                    ' Get Rankings for Me and my opponent... 12/19/2014 added...
                    intRankMy = clsRankings.GetRankingByDate(Session("memgSportID"), Session("memgTeamID"), RadDatePicker1.SelectedDate, Session("memgCurrentWeekIDDisplay"))
                    intRankThem = 0

                    ' 1/10/2017 Add GameEntered TimeStamp and ByWho to Tournament games (non selected schools)...
                    If rowResults2.Visible Or (cboGameType.SelectedValue = "TOSSAAS") Then
                        strSQL = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, OtherTeam, strType, intYear, strGameAddedByWho, tournament, TotalScore, oTotalScore, District, WL, strResults"
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = strSQL & ", dtmScore, strScoreByWho"
                        End If
                        strSQL = strSQL & ") VALUES ('" & sStatus & "', " & Session("memgTeamID") & ", 0, " & intRankMy & ", 0, '" & Session("memgSportID") & "', '" & Session("memgoSportID") & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & Me.cboGameLocation.SelectedValue & "','" & Replace(Me.txtSchool.Text, "'", "''") & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', " & intScoreMy & ", " & intScoreOpp & ", " & intDistrict & ", '" & strWL & "', '" & SqlHelper.StripString(txtResults.Text) & "'"
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = strSQL & ", '" & Now & "', '" & Session("memgWhoIsLoggedIn") & "'"
                            ' CDW added 9/26/2019...
                            strScoreEntered = clsMembers.LogScoreEntered(0, Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), 0, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)
                        End If
                        strSQL = strSQL & ")"
                        strSQLPG = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, OtherTeam, strType, intYear, strGameAddedByWho, tournament) VALUES ('" & sStatus & "', " & intTeamIDPG & ", 0, " & intRankMy & ", 0, '" & Session("memgPostGender") & "', '" & SwapSportGender(Session("memgoSportID")) & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & cboGameLocation.SelectedValue & "','" & Replace(Me.txtSchool.Text, "'", "''") & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "')"
                        strSQLSW = ""
                    Else
                        strSQL = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, OtherTeam, strType, intYear, strGameAddedByWho, tournament, TotalScore, oTotalScore, District, WL"
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = strSQL & ", dtmScore, strScoreByWho"
                        End If
                        strSQL = strSQL & ") VALUES ('" & sStatus & "', " & Session("memgTeamID") & ", 0, " & intRankMy & ", 0, '" & Session("memgSportID") & "', '" & Session("memgoSportID") & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & Me.cboGameLocation.SelectedValue & "','" & Replace(Me.txtSchool.Text, "'", "''") & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "', " & intScoreMy & ", " & intScoreOpp & ", " & intDistrict & ",'" & strWL & "'"
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = strSQL & ", '" & Now & "', '" & Session("memgWhoIsLoggedIn") & "'"
                            ' CDW added 9/26/2019...
                            strScoreEntered = clsMembers.LogScoreEntered(0, Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), 0, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)
                        End If
                        strSQL = strSQL & ")"
                        strSQLPG = "INSERT INTO tblSchedules (gStatus, teamID, oTeamID, rank, orank, sportID, oSportID, gameDate, gameTime, Location, OtherTeam, strType, intYear, strGameAddedByWho, tournament) VALUES ('" & sStatus & "', " & intTeamIDPG & ", 0, " & intRankMy & ", 0, '" & Session("memgPostGender") & "', '" & SwapSportGender(Session("memgoSportID")) & "', '" & RadDatePicker1.SelectedDate & "', '" & strGameTime & "', '" & cboGameLocation.SelectedValue & "','" & Replace(Me.txtSchool.Text, "'", "''") & "', '" & cboGameType.SelectedValue & "', " & clsFunctions.GetCurrentYear & ", '" & Session("memgWhoIsLoggedIn") & "', '" & SqlHelper.StripString(txtTournament.Text) & "')"
                        strSQLSW = ""
                    End If
                End If

                ' POST to tblSchedule...
                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)

                ' Get the new ScheduleID...
                Session("memgScheduleID") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT TOP 1 scheduleID FROM tblSchedules WHERE teamID = " & Session("memgTeamID") & " AND sportID = '" & Session("memgSportID") & "' ORDER BY scheduleID DESC")

                If strSport.Contains("Baseball") Then
                    UpdatePitchCounts(Session("memgScheduleID"))
                End If

                ' Removed 1/1/2018.. No longer used...
                'If Session("memgPostGender") <> "" Then
                '    If cbPostGender.Visible = True And cbPostGender.Checked = True Then
                '        ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLPG)
                '        ' Get the Gender xref ScheduleID...
                '        strSQLPG = "SELECT TOP 1 scheduleID FROM tblSchedules WHERE teamID = " & intTeamIDPG & " AND sportID = '" & Session("memgPostGender") & "' AND ysnActive <> 0 ORDER BY scheduleID DESC"
                '        Dim intoScheduleID As Long = 0
                '        intoScheduleID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQLPG)
                '        ' Update the xrefs...
                '        strSQL = "UPDATE tblSchedules SET scheduleIDxrefG = " & intoScheduleID & " WHERE scheduleID = " & Session("memgScheduleID")
                '        ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                '        strSQL = "UPDATE tblSchedules SET scheduleIDxrefG = " & Session("memgScheduleID") & " WHERE scheduleID = " & intoScheduleID
                '        ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                '    End If
                'End If

                ' SWAP games on UPDATE...
                If Me.txtSchool.Text = "" Then
                    If strSQLSW = "" Then
                        ' DO NOT SWAP...
                    Else
                        Try
                            ' Make sure game doesn't exist then ADD game...
                            Dim intSID As Long = 0
                            If cboGameType.SelectedValue.Contains("TOSSAA") Or cboGameType.SelectedValue = "TOURNEY" Or cboGameType.SelectedValue = "DIST" Then
                                ' Could me multiple games in one day... 9/23/2013...
                                strSQL = "SELECT scheduleID FROM tblSchedules WHERE teamID = " & cboSchools.SelectedValue & " AND oTeamID = " & Session("memgTeamID") & " AND (gameDate = '" & RadDatePicker1.SelectedDate & "' AND gameTime = '" & strGameTime & "') AND intYear = " & clsFunctions.GetCurrentYear & " AND ysnActive <> 0"
                            Else
                                strSQL = "SELECT scheduleID FROM tblSchedules WHERE teamID = " & cboSchools.SelectedValue & " AND oTeamID = " & Session("memgTeamID") & " AND gameDate = '" & RadDatePicker1.SelectedDate & "' AND intYear = " & clsFunctions.GetCurrentYear & " AND ysnActive <> 0"
                            End If
                            intSID = ExecuteScalar(SQLConnection, CommandType.Text, strSQL)

                            If intSID = 0 Then  ' No xRef was found so DO THE INSERT of the swapped game...
                                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLSW)
                                Dim intScheduleIDSwap As Long = 0
                                intScheduleIDSwap = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT TOP 1 scheduleID FROM tblSchedules WHERE teamID = " & cboSchools.SelectedValue & " AND sportID = '" & Session("memgoSportID") & "' ORDER BY scheduleID DESC")
                                If intScheduleIDSwap > 0 Then
                                    ' Update the xref's...
                                    strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & intScheduleIDSwap & " WHERE scheduleID = " & Session("memgScheduleID")
                                    ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                                    strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & Session("memgScheduleID") & " WHERE scheduleID = " & intScheduleIDSwap
                                    ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                                End If
                            Else
                                ' TODO : Swapped game was found (@ intSID), so check the scheduleIDxref and update it if = 0...
                                ' Update the xref's...
                                strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & intSID & " WHERE scheduleID = " & Session("memgScheduleID")
                                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                                strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & Session("memgScheduleID") & " WHERE scheduleID = " & intSID
                                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                            End If
                        Catch
                        End Try
                    End If
                End If
                ' =============================================================================================================
                ' EDIT AN EXISTING GAME...
            Else
                ' NOTE : PostGender is not done during and UPDATE...
                Dim oSportID As String = clsTeams.GetSportIDForTeam(Me.cboSchools.SelectedValue)
                Dim strStatus As String

                strStatus = cboStatus.SelectedValue
                If intScoreMy > 0 Or intScoreOpp > 0 Then           ' 10/31/2014 added...
                    If strStatus = "Select..." Then
                        strStatus = "Final"
                    End If
                End If

                If strSport.Contains("Baseball") Then
                    UpdatePitchCounts(Session("memgScheduleID"))
                End If

                ' Calc District Points?
                Dim intaDistrict As Integer = 0
                Dim intoDistrict As Integer = 0

                ' TODO: Is this a District game???
                intaDistrict = clsSchedules.CalculateDistrictPoints(cboGameType.SelectedValue, intScoreMy, intScoreOpp, strStatus, Session("memgSportID"))
                If intaDistrict <> 0 Then
                    intoDistrict = -intaDistrict
                End If

                ' UPDATE the Schedule...
                If Me.txtSchool.Text = "" Or (txtSchool.Text = "TBA" And cboSchools.SelectedIndex > 0) Or ((txtSchool.Text = "State Championship" Or txtSchool.Text = "STATE CHAMPIONSHIP") And cboSchools.SelectedIndex > 0) Or (txtSchool.Text.Contains(" vs ") And cboSchools.SelectedIndex > 0) Then

                    ' Get Rankings for Me and my opponent... 12/19/2014 added...
                    intRankMy = clsRankings.GetRankingByDate(Session("memgSportID"), Session("memgTeamID"), RadDatePicker1.SelectedDate, Session("memgCurrentWeekIDDisplay"))
                    intRankThem = clsRankings.GetRankingByDate(oSportID, cboSchools.SelectedValue, RadDatePicker1.SelectedDate, 0)

                    If rowResults2.Visible Or (cboGameType.SelectedValue = "TOSSAAS") Then
                        ' GET SQL FOR UPDATE...
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = " & Me.cboSchools.SelectedValue & ", rank = " & intRankMy & ", orank = " & intRankThem & ",  osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & cboGameLocation.SelectedValue & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intaDistrict & ", TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", strResults = '" & SqlHelper.StripString(txtResults.Text) & "', WL = '" & strWL & "', OtherTeam = Null, dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleID")
                        Else
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = " & Me.cboSchools.SelectedValue & ", rank = " & intRankMy & ", orank = " & intRankThem & ",  osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & cboGameLocation.SelectedValue & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intaDistrict & ", TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", strResults = '" & SqlHelper.StripString(txtResults.Text) & "', WL = '" & strWL & "', OtherTeam = Null WHERE [scheduleID] = " & Session("memgScheduleID")
                        End If
                        ' CDW added 9/26/2019...
                        strScoreEntered = clsMembers.LogScoreEntered(Session("memgScheduleID"), Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), cboSchools.SelectedValue, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)

                        ' GET SQL FOR SWAP...
                        If strSport = "Volleyball" Then
                            If intScoreMy > 0 Or intScoreOpp > 0 Then
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", rank = " & intRankThem & ", orank = " & intRankMy & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "', strResults = '" & SqlHelper.StripString(txtResults.Text) & "', dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            Else
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", rank = " & intRankThem & ", orank = " & intRankMy & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "', strResults = '" & SqlHelper.StripString(txtResults.Text) & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            End If
                        Else
                            If intScoreMy > 0 Or intScoreOpp > 0 Then
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", rank = " & intRankThem & ", orank = " & intRankMy & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "', dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            Else
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", rank = " & intRankThem & ", orank = " & intRankMy & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            End If
                        End If
                    Else
                        '' ============= FIND XREF ScheduleID....
                        'If Session("memgScheduleIDxref") = 0 And strSport.Contains("Basketball") Then
                        '    If cboGameType.SelectedValue.Contains("TOSSAA") Then
                        '        Session("memgScheduleIDxref") = clsSchedules.FindSwapGameTOSSAA(Session("memgSportID"), Session("memgTeamID"), cboSchools.SelectedValue, cboGameType.SelectedValue)
                        '    Else
                        '        Session("memgScheduleIDxref") = clsSchedules.FindSwapGame(Session("memgSportID"), Session("memgTeamID"), cboSchools.SelectedValue, RadDatePicker1.SelectedDate)
                        '    End If
                        If Session("memgScheduleIDxref") = 0 And cboGameType.SelectedValue.Contains("TOSSAA") And (strSport.Contains("Soccer") Or strSport.Contains("SPSoftball") Or strSport.Contains("Baseball") Or strSport.Contains("Volleyball") Or strSport.Contains("FPSoftball")) Then   ' 5/1/2014 added... Updated 10/8/2014...
                            Session("memgScheduleIDxref") = clsSchedules.FindSwapGameTOSSAA(Session("memgSportID"), Session("memgTeamID"), cboSchools.SelectedValue, cboGameType.SelectedValue)
                            'ElseIf Session("memgScheduleIDxref") = 0 And strSport.Contains("Soccer") Then
                            '    Session("memgScheduleIDxref") = clsSchedules.FindSwapGame(Session("memgSportID"), Session("memgTeamID"), cboSchools.SelectedValue, RadDatePicker1.SelectedDate)
                        End If

                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = " & Me.cboSchools.SelectedValue & ", rank = " & intRankMy & ", orank = " & intRankThem & ", osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & Me.cboGameLocation.SelectedValue & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intaDistrict & ", TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", WL = '" & strWL & "', OtherTeam = Null, dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleID")
                            strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", rank = " & intRankThem & ", orank = " & intRankMy & ", OtherTeam = Null, oTeamID = " & Session("memgTeamID") & ",  sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(Me.cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "', dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                        Else
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = " & Me.cboSchools.SelectedValue & ", rank = " & intRankMy & ", orank = " & intRankThem & ", osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & Me.cboGameLocation.SelectedValue & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intaDistrict & ", TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", WL = '" & strWL & "', OtherTeam = Null WHERE [scheduleID] = " & Session("memgScheduleID")
                            strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", rank = " & intRankThem & ", orank = " & intRankMy & ",  OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(Me.cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                        End If

                        ' CDW added 9/26/2019...
                        strScoreEntered = clsMembers.LogScoreEntered(Session("memgScheduleID"), Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), cboSchools.SelectedValue, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)

                        ' DO A SWAP FOR DUAL STATE WRESTLING...
                        If strSport.Contains("Wrestling") And cboGameType.SelectedValue = "TOSSAASD" Then
                            If intScoreMy > 0 Or intScoreOpp > 0 Then
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "', dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            Else
                                strSQLSW = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & cboSchools.SelectedValue & ", oTeamID = " & Session("memgTeamID") & ", OtherTeam = Null, sportID = '" & oSportID & "', osportID = '" & Session("memgSportID") & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & clsGames.SwapLocation(cboGameLocation.SelectedValue) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', DistrictPoints = " & intoDistrict & ", TotalScore = " & intScoreOpp & ", oTotalScore = " & intScoreMy & ", WL = '" & clsGames.SwapWL(strWL) & "' WHERE [scheduleID] = " & Session("memgScheduleIDxref")
                            End If
                        End If
                    End If
                Else

                    ' Get Rankings for Me and my opponent... 12/19/2014 added...
                    intRankMy = clsRankings.GetRankingByDate(Session("memgSportID"), Session("memgTeamID"), RadDatePicker1.SelectedDate, Session("memgCurrentWeekIDDisplay"))
                    intRankThem = 0

                    If rowResults2.Visible Or (cboGameType.SelectedValue = "TOSSAAS") Then
                        If intScoreMy > 0 Or intScoreOpp > 0 Then
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = 0, rank = " & intRankMy & ", orank = 0, osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & Me.cboGameLocation.SelectedValue & "', OtherTeam = '" & Replace(Me.txtSchool.Text, "'", "''") & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", DistrictPoints = " & intaDistrict & ", strResults = '" & SqlHelper.StripString(txtResults.Text) & "', WL = '" & strWL & "', dtmScore = '" & Now & "', strScoreByWho = '" & Session("memgWhoIsLoggedIn") & "' WHERE [scheduleID] = " & Session("memgScheduleID")
                        Else
                            strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = 0, rank = " & intRankMy & ", orank = 0, osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & Me.cboGameLocation.SelectedValue & "', OtherTeam = '" & Replace(Me.txtSchool.Text, "'", "''") & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ", DistrictPoints = " & intaDistrict & ", strResults = '" & SqlHelper.StripString(txtResults.Text) & "', WL = '" & strWL & "' WHERE [scheduleID] = " & Session("memgScheduleID")
                        End If
                        ' CDW added 9/26/2019...
                        strScoreEntered = clsMembers.LogScoreEntered(Session("memgScheduleID"), Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), 0, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)
                        strSQLSW = ""
                    Else
                        strSQL = "UPDATE tblSchedules SET gStatus = '" & strStatus & "', strType = '" & cboGameType.SelectedValue & "', teamID = " & Session("memgTeamID") & ", oTeamID = 0, rank = " & intRankMy & ", orank = 0, osportID = '" & oSportID & "', gameDate = '" & RadDatePicker1.SelectedDate & "', gameTime = '" & strGameTime & "', Location = '" & Me.cboGameLocation.SelectedValue & "', OtherTeam = '" & SqlHelper.StripString(Replace(Me.txtSchool.Text, "'", "''")) & "', District = " & intDistrict & ", Tournament = '" & SqlHelper.StripString(txtTournament.Text) & "', TotalScore = " & intScoreMy & ", oTotalScore = " & intScoreOpp & ",  DistrictPoints = " & intoDistrict & ", WL = '" & strWL & "' WHERE [scheduleID] = " & Session("memgScheduleID")
                        ' CDW added 9/26/2019...
                        strScoreEntered = clsMembers.LogScoreEntered(Session("memgScheduleID"), Session("memgSportID"), Session("memgMemberID"), Session("memgTeamID"), 0, Session("memgWhoIsLoggedIn"), Now.ToString, intScoreMy, intScoreOpp, RadDatePicker1.SelectedDate.ToString)
                        strSQLSW = ""
                    End If

                End If

                ' UPDATE database...
                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)

                ' LETS MOVE SOME PLAYOFF GAMES TO THE NEXT ROUND...
                ' TODO : Combine these functions, they are pretty much the same....
                If cboGameType.SelectedValue = "TOSSAAD" And strSport.Contains("Basketball") Then
                    ' DISTRICTS Basketball...
                    AdvanceToNextRoundDistrict(Session("memgScheduleID"))
                ElseIf cboGameType.SelectedValue = "TOSSAAR" And strSport.Contains("Basketball") Then
                    ' REGIONALS Basketball...
                    If Session("memgSportID").ToString.Contains("6A") Or Session("memgSportID").ToString.Contains("5A") Then
                        AdvanceToNextRoundRegional6A5A(Session("memgScheduleID"))
                    Else
                        AdvanceToNextRoundRegional(Session("memgScheduleID"))
                    End If
                ElseIf cboGameType.SelectedValue = "TOSSAAA" And strSport.Contains("Basketball") Then
                    ' AREAS Basketball...
                    If Session("memgSportID").ToString.Contains("6A") Or Session("memgSportID").ToString.Contains("5A") Then
                        AdvanceToNextRoundArea6A5A(Session("memgScheduleID"))
                    Else
                        AdvanceToNextRoundArea(Session("memgScheduleID"))
                    End If
                ElseIf cboGameType.SelectedValue = "TOSSAAS" And strSport.Contains("Basketball") Then
                    ' STATE Basketball...
                    If txtSchool.Text = "State Championship" Or txtSchool.Text = "STATE CHAMPIONSHIP" Then
                        If strSQLSW <> "" Then
                            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLSW)
                        End If
                    Else
                        AdvanceToNextRoundState(Session("memgScheduleID"), cboGameType.SelectedValue)
                    End If
                ElseIf cboGameType.SelectedValue = "TOSSAAS" And (strSport.Contains("SPSoftball") Or strSport.Contains("Baseball") Or strSport.Contains("Volleyball") Or strSport.Contains("FPSoftball")) Then
                    ' STATE 
                    If txtSchool.Text = "State Championship" Or txtSchool.Text = "STATE CHAMPIONSHIP" Then
                        If strSQLSW <> "" Then
                            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLSW)
                        End If
                    Else
                        AdvanceToNextRoundState(Session("memgScheduleID"), cboGameType.SelectedValue)       ' Blah...
                    End If
                ElseIf cboGameType.SelectedValue = "TOSSAAS" And strSport.Contains("Soccer") Then
                    ' STATE Soccer...
                    If txtSchool.Text = "State Championship" Or txtSchool.Text = "STATE CHAMPIONSHIP" Then
                        If strSQLSW <> "" Then
                            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLSW)
                        End If
                    Else
                        AdvanceToNextRoundState(Session("memgScheduleID"), cboGameType.SelectedValue)
                    End If
                ElseIf cboGameType.SelectedValue = "TOSSAASD" And strSport.Contains("Wrestling") Then
                    ' TODO : Fix this logic, it is BROKE!
                    'UpdateNextRoundRegionalState(Session("memgScheduleID"), intScoreMy, intScoreOpp, Session("memgTeamID"), "TOSSAASD")
                    AdvanceToNextRoundState(Session("memgScheduleID"), cboGameType.SelectedValue)
                End If

                If Me.txtSchool.Text = "" Or (txtSchool.Text = "TBA" And cboSchools.SelectedIndex > 0) Or (txtSchool.Text.Contains(" vs ") And cboSchools.SelectedIndex > 0) Or (txtSchool.Text = "State Championship" And cboSchools.SelectedIndex > 0) Then
                    ' Non-Playoff so SWAP games on UPDATE...
                    If strSQLSW = "" Then
                    Else
                        Try
                            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQLSW)
                            Dim intScheduleIDSwap As Long = 0
                            intScheduleIDSwap = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT TOP 1 scheduleID FROM tblSchedules WHERE teamID = " & cboSchools.SelectedValue & " AND sportID = '" & Session("memgoSportID") & "' ORDER BY scheduleID DESC")
                            If intScheduleIDSwap > 0 Then
                                ' Update the xref's...
                                strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & intScheduleIDSwap & " WHERE scheduleID = " & Session("memgScheduleID")
                                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                                strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & Session("memgScheduleID") & " WHERE scheduleID = " & intScheduleIDSwap
                                ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
                            Else
                                ' TODO : Find the Matching Game???
                            End If
                        Catch
                        End Try
                    End If
                End If
            End If

            Session("memgWL") = clsTeams.GetCalcWLTeamDisplay(Session("memgTeamID"), True)
            Session("memadd") = 0
            ' Clear fields and close..
            ClearFields()
            Me.Visible = False
            Response.Redirect("Home.aspx?sel=Schedule")
            ' TODO... Refresh the Grid...
        Else
            Me.lblMessage.Text = strValidate
        End If

    End Sub

    Public Sub AdvanceToNextRoundState(intScheduleID As Long, strTypeIn As String)        ' Added 3/5/2014...
        Dim strSQL As String = ""
        Dim strSQLW As String = ""
        Dim strSQLL As String = ""
        Dim intWinner As Long = 0
        Dim intLoser As Long = 0
        Dim TeamWinner As Long = 0
        Dim TeamLoser As Long = 0
        Dim intGameRankingsID As Long = 0
        Dim intGameRankingsNextIDW As Long = 0
        Dim intGameRankingsNextIDL As Long = 0
        Dim ysnTopW As Boolean = False
        Dim ysnTopL As Boolean = False
        Dim strTypeOut As String = strTypeIn

        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            ' Update Next Round Game with Winning (and Losing) team...
            With ds1.Tables(0).Rows(0)
                If .Item("TotalScore") > 0 Or .Item("oTotalScore") > 0 Then
                    ' Get the Winning and Losing teamID's...
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        intWinner = .Item("teamID")
                        TeamWinner = .Item("TeamTop")
                        intLoser = .Item("oTeamID")
                        TeamLoser = .Item("TeamBottom")
                    Else
                        intWinner = .Item("oTeamID")
                        TeamWinner = .Item("TeamBottom")
                        intLoser = .Item("teamID")
                        TeamLoser = .Item("TeamTop")
                    End If

                    ' Get the GameID...
                    intGameRankingsID = .Item("intGame")

                    Select Case intGameRankingsID
                        ' Only games #1 - #4 advance...
                        Case 1101, 1201     ' Game #1...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 4
                            intGameRankingsNextIDL = 0
                        Case 1102, 1202     ' Game #2... 
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 3
                            intGameRankingsNextIDL = 0
                        Case 1103, 1203     ' Game #3...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 3
                            intGameRankingsNextIDL = 0
                        Case 1104, 1204     ' Game #4...
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 2
                            intGameRankingsNextIDL = 0
                        Case 1105, 1205     ' Game #5...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 2
                            intGameRankingsNextIDL = 0
                        Case 1106, 1206     ' Game #6...
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 1
                            intGameRankingsNextIDL = 0
                    End Select

                    Select Case strTypeIn
                        Case "TOSSAA8"
                            strTypeOut = "TOSSAA4"
                        Case "TOSSAA4"
                            strTypeOut = "TOSSAA2"
                        Case "TOSSAASD"
                            strTypeOut = "TOSSAASD"
                        Case Else
                            strTypeOut = "TOSSAAS"
                    End Select

                    ' UPDATE NEXT ROUND WINNER (and swap)...
                    If intGameRankingsNextIDW > 0 Then
                        strSQLW = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDW & " AND strType = '" & strTypeOut & "' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLW = ""
                    End If

                    If strSQLW = "" Then
                    Else
                        Dim dsW As DataSet
                        dsW = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLW)

                        If dsW Is Nothing Then
                        ElseIf dsW.Tables.Count = 0 Then
                        ElseIf dsW.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Winner 1...
                            If ysnTopW Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ", oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Winner Game...
                            If dsW.Tables(0).Rows.Count = 2 Then
                                If ysnTopW Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ",oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If

                        End If
                    End If

                    ' UPDATE NEXT ROUND LOSER (and swap)...
                    If intGameRankingsNextIDL > 0 Then
                        strSQLL = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDL & " AND strType = '" & strTypeOut & "' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLL = ""
                    End If

                    If strSQLL = "" Then

                    Else
                        Dim dsL As DataSet
                        dsL = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLL)

                        If dsL Is Nothing Then
                        ElseIf dsL.Tables.Count = 0 Then
                        ElseIf dsL.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Loser 1...
                            If ysnTopL Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Loser Game...
                            If dsL.Tables(0).Rows.Count = 2 Then
                                If ysnTopL Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        End If
                    End If
                End If
            End With
        End If

    End Sub


    Public Sub AdvanceToNextRoundArea6A5A(intScheduleID As Long)        ' Added 3/5/2014...
        Dim strSQL As String = ""
        Dim strSQLW As String = ""
        Dim strSQLL As String = ""
        Dim intWinner As Long = 0
        Dim intLoser As Long = 0
        Dim TeamWinner As Long = 0
        Dim TeamLoser As Long = 0
        Dim intGameRankingsID As Long = 0
        Dim intGameRankingsNextIDW As Long = 0
        Dim intGameRankingsNextIDL As Long = 0
        Dim ysnTopW As Boolean = False
        Dim ysnTopL As Boolean = False

        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            ' Update Next Round Game with Winning (and Losing) team...
            With ds1.Tables(0).Rows(0)
                If .Item("TotalScore") > 0 Or .Item("oTotalScore") > 0 Then
                    ' Get the Winning and Losing teamID's...
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        intWinner = .Item("teamID")
                        TeamWinner = .Item("TeamTop")
                        intLoser = .Item("oTeamID")
                        TeamLoser = .Item("TeamBottom")
                    Else
                        intWinner = .Item("oTeamID")
                        TeamWinner = .Item("TeamBottom")
                        intLoser = .Item("teamID")
                        TeamLoser = .Item("TeamTop")
                    End If

                    ' Get the GameID...
                    intGameRankingsID = .Item("intGame")

                    Select Case intGameRankingsID
                        ' Only games #1 - #4 advance...
                        Case 6101, 7101, 8101, 9101, 6201, 7201, 8201, 9201     ' Game #1...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 4
                            ysnTopL = False
                            intGameRankingsNextIDL = 0
                        Case 6102, 7102, 8102, 9102, 6202, 7202, 8202, 9202     ' Game #2... 
                            ysnTopW = False
                            intGameRankingsNextIDW = 0
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 3
                        Case 6103, 7103, 8103, 9103, 6203, 7203, 8203, 9203     ' Game #3...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 3
                            ysnTopL = False
                            intGameRankingsNextIDL = 0
                        Case 6104, 7104, 8104, 9104, 6204, 7204, 8204, 9204     ' Game #4...
                            ysnTopW = False
                            intGameRankingsNextIDW = 0
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 2
                    End Select

                    ' UPDATE NEXT ROUND WINNER (and swap)...
                    If intGameRankingsNextIDW > 0 Then
                        strSQLW = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDW & " AND strType = 'TOSSAAA' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLW = ""
                    End If

                    If strSQLW = "" Then
                    Else
                        Dim dsW As DataSet
                        dsW = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLW)

                        If dsW Is Nothing Then
                        ElseIf dsW.Tables.Count = 0 Then
                        ElseIf dsW.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Winner 1...
                            If ysnTopW Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ", oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Winner Game...
                            If dsW.Tables(0).Rows.Count = 2 Then
                                If ysnTopW Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ",oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If

                        End If
                    End If

                    ' UPDATE NEXT ROUND LOSER (and swap)...
                    If intGameRankingsNextIDL > 0 Then
                        strSQLL = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDL & " AND strType = 'TOSSAAA' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLL = ""
                    End If

                    If strSQLL = "" Then

                    Else
                        Dim dsL As DataSet
                        dsL = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLL)

                        If dsL Is Nothing Then
                        ElseIf dsL.Tables.Count = 0 Then
                        ElseIf dsL.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Loser 1...
                            If ysnTopL Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Loser Game...
                            If dsL.Tables(0).Rows.Count = 2 Then
                                If ysnTopL Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        End If
                    End If
                End If
            End With
        End If

    End Sub


    Public Sub AdvanceToNextRoundArea(intScheduleID As Long)        ' Added 2/24/2014...
        Dim strSQL As String = ""
        Dim strSQLW As String = ""
        Dim strSQLL As String = ""
        Dim intWinner As Long = 0
        Dim intLoser As Long = 0
        Dim TeamWinner As Long = 0
        Dim TeamLoser As Long = 0
        Dim intGameRankingsID As Long = 0
        Dim intGameRankingsNextIDW As Long = 0
        Dim intGameRankingsNextIDL As Long = 0
        Dim ysnTopW As Boolean = False
        Dim ysnTopL As Boolean = False

        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            ' Update Next Round Game with Winning (and Losing) team...
            With ds1.Tables(0).Rows(0)
                If .Item("TotalScore") > 0 Or .Item("oTotalScore") > 0 Then
                    ' Get the Winning and Losing teamID's...
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        intWinner = .Item("teamID")
                        TeamWinner = .Item("TeamTop")
                        intLoser = .Item("oTeamID")
                        TeamLoser = .Item("TeamBottom")
                    Else
                        intWinner = .Item("oTeamID")
                        TeamWinner = .Item("TeamBottom")
                        intLoser = .Item("teamID")
                        TeamLoser = .Item("TeamTop")
                    End If

                    ' Get the GameID...
                    intGameRankingsID = .Item("intGame")

                    Select Case intGameRankingsID
                        ' Only games #1 - #4 advance...
                        Case 6101, 7101, 8101, 9101, 6201, 7201, 8201, 9201     ' Game #1...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 2
                            ysnTopL = False
                            intGameRankingsNextIDL = 0
                        Case 6102, 7102, 8102, 9102, 6202, 7202, 8202, 9202     ' Game #2... 
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 1
                            ysnTopL = False
                            intGameRankingsNextIDL = 0
                        Case 6103, 7103, 8103, 9103, 6203, 7203, 8203, 9203     ' Game #3...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 2
                            ysnTopL = False
                            intGameRankingsNextIDL = 0
                        Case 6104, 7104, 8104, 9104, 6204, 7204, 8204, 9204     ' Game #4...
                            ysnTopW = False
                            intGameRankingsNextIDW = 0
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 1
                    End Select

                    ' UPDATE NEXT ROUND WINNER (and swap)...
                    If intGameRankingsNextIDW > 0 Then
                        strSQLW = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDW & " AND strType = 'TOSSAAA' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLW = ""
                    End If

                    If strSQLW = "" Then
                    Else
                        Dim dsW As DataSet
                        dsW = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLW)

                        If dsW Is Nothing Then
                        ElseIf dsW.Tables.Count = 0 Then
                        ElseIf dsW.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Winner 1...
                            If ysnTopW Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ", oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Winner Game...
                            If dsW.Tables(0).Rows.Count = 2 Then
                                If ysnTopW Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ",oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If

                        End If
                    End If

                    ' UPDATE NEXT ROUND LOSER (and swap)...
                    If intGameRankingsNextIDL > 0 Then
                        strSQLL = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDL & " AND strType = 'TOSSAAA' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLL = ""
                    End If

                    If strSQLL = "" Then

                    Else
                        Dim dsL As DataSet
                        dsL = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLL)

                        If dsL Is Nothing Then
                        ElseIf dsL.Tables.Count = 0 Then
                        ElseIf dsL.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Loser 1...
                            If ysnTopL Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Loser Game...
                            If dsL.Tables(0).Rows.Count = 2 Then
                                If ysnTopL Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        End If
                    End If
                End If
            End With
        End If

    End Sub

    Public Sub AdvanceToNextRoundRegional6A5A(intScheduleID As Long)        ' Added 2/27/2014...
        Dim strSQL As String = ""
        Dim strSQLW As String = ""
        Dim strSQLL As String = ""
        Dim intWinner As Long = 0
        Dim intLoser As Long = 0
        Dim TeamWinner As Long = 0
        Dim TeamLoser As Long = 0
        Dim intGameRankingsID As Long = 0
        Dim intGameRankingsNextIDW As Long = 0
        Dim intGameRankingsNextIDL As Long = 0
        Dim ysnTopW As Boolean = False
        Dim ysnTopL As Boolean = False

        'Dim intRound2ID As Long = 0
        'Dim intRound2IDa As Long = 0
        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            ' Update Next Round Game with Winning (and Losing) team...
            With ds1.Tables(0).Rows(0)
                If .Item("TotalScore") > 0 Or .Item("oTotalScore") > 0 Then
                    ' Get the Winning and Losing teamID's...
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        intWinner = .Item("teamID")
                        TeamWinner = .Item("TeamTop")
                        intLoser = .Item("oTeamID")
                        TeamLoser = .Item("TeamBottom")
                    Else
                        intWinner = .Item("oTeamID")
                        TeamWinner = .Item("TeamBottom")
                        intLoser = .Item("teamID")
                        TeamLoser = .Item("TeamTop")
                    End If

                    ' Get the GameID...
                    intGameRankingsID = .Item("intGame")

                    Select Case intGameRankingsID
                        Case 1101, 2101, 3101, 4101, 1201, 2201, 3201, 4201     ' Game #1...To #11
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 10
                            intGameRankingsNextIDL = 0
                        Case 1102, 2102, 3102, 4102, 1202, 2202, 3202, 4202     ' Game #2...To #11
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 9
                            intGameRankingsNextIDL = 0
                        Case 1103, 2103, 3103, 4103, 1203, 2203, 3203, 4203     ' Game #3...To #12
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 9
                            intGameRankingsNextIDL = 0
                        Case 1104, 2104, 3104, 4104, 1204, 2204, 3204, 4204     ' Game #4...To #12
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 8
                            intGameRankingsNextIDL = 0
                        Case 1105, 2105, 3105, 4105, 1205, 2205, 3205, 4205     ' Game #5... To #13
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 8
                            intGameRankingsNextIDL = 0
                        Case 1106, 2106, 3106, 4106, 1206, 2206, 3206, 4206     ' Game #6...To #13
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 7
                            intGameRankingsNextIDL = 0
                        Case 1107, 2107, 3107, 4107, 1207, 2207, 3207, 4207     ' Game #7...To #14
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 7
                            intGameRankingsNextIDL = 0
                        Case 1108, 2108, 3108, 4108, 1208, 2208, 3208, 4208     ' Game #8...To #14
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            intGameRankingsNextIDL = 0
                        Case Else
                            intGameRankingsNextIDW = 0
                            intGameRankingsNextIDL = 0
                    End Select

                    ' UPDATE NEXT ROUND WINNER (and swap)...
                    If intGameRankingsNextIDW > 0 Then
                        strSQLW = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDW & " AND strType = 'TOSSAAR' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLW = ""
                    End If

                    If strSQLW = "" Then
                    Else
                        Dim dsW As DataSet
                        dsW = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLW)

                        If dsW Is Nothing Then
                        ElseIf dsW.Tables.Count = 0 Then
                        ElseIf dsW.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Winner 1...
                            If ysnTopW Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ", oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Winner Game...
                            If dsW.Tables(0).Rows.Count = 2 Then
                                If ysnTopW Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ",oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        End If
                    End If

                    ' UPDATE NEXT ROUND LOSER (and swap)...
                    If intGameRankingsNextIDL > 0 Then
                        strSQLL = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDL & " AND strType = 'TOSSAAR' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLL = ""
                    End If

                    If strSQLL = "" Then

                    Else
                        Dim dsL As DataSet
                        dsL = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLL)

                        If dsL Is Nothing Then
                        ElseIf dsL.Tables.Count = 0 Then
                        ElseIf dsL.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Loser 1...
                            If ysnTopL Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Loser Game...
                            If dsL.Tables(0).Rows.Count = 2 Then
                                If ysnTopL Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If

                        End If
                    End If
                End If
            End With
        End If

    End Sub

    Public Sub AdvanceToNextRoundRegional(intScheduleID As Long)        ' Added 2/20/2014...
        Dim strSQL As String = ""
        Dim strSQLW As String = ""
        Dim strSQLL As String = ""
        Dim intWinner As Long = 0
        Dim intLoser As Long = 0
        Dim TeamWinner As Long = 0
        Dim TeamLoser As Long = 0
        Dim intGameRankingsID As Long = 0
        Dim intGameRankingsNextIDW As Long = 0
        Dim intGameRankingsNextIDL As Long = 0
        Dim ysnTopW As Boolean = False
        Dim ysnTopL As Boolean = False

        'Dim intRound2ID As Long = 0
        'Dim intRound2IDa As Long = 0
        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            ' Update Next Round Game with Winning (and Losing) team...
            With ds1.Tables(0).Rows(0)
                ' Get the Winning and Losing teamID's...
                If .Item("TotalScore") > 0 Or .Item("oTotalScore") > 0 Then
                    If .Item("TotalScore") > .Item("oTotalScore") Then
                        intWinner = .Item("teamID")
                        TeamWinner = .Item("TeamTop")
                        intLoser = .Item("oTeamID")
                        TeamLoser = .Item("TeamBottom")
                    Else
                        intWinner = .Item("oTeamID")
                        TeamWinner = .Item("TeamBottom")
                        intLoser = .Item("teamID")
                        TeamLoser = .Item("TeamTop")
                    End If

                    ' Get the GameID...
                    intGameRankingsID = .Item("intGame")

                    Select Case intGameRankingsID
                        Case 1101, 2101, 3101, 4101, 1201, 2201, 3201, 4201     ' Game #1...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 8
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 11
                        Case 1102, 2102, 3102, 4102, 1202, 2202, 3202, 4202     ' Game #2... 
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 7
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 9
                        Case 1103, 2103, 3103, 4103, 1203, 2203, 3203, 4203     ' Game #3...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 7
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 11
                        Case 1104, 2104, 3104, 4104, 1204, 2204, 3204, 4204     ' Game #4...
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            ysnTopL = False
                            intGameRankingsNextIDL = intGameRankingsID + 9
                        Case 1105, 2105, 3105, 4105, 1205, 2205, 3205, 4205     ' Game #5...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            intGameRankingsNextIDL = 0
                        Case 1106, 2106, 3106, 4106, 1206, 2206, 3206, 4206     ' Game #6...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            intGameRankingsNextIDL = 0
                        Case 1107, 2107, 3107, 4107, 1207, 2207, 3207, 4207     ' Game #7...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            intGameRankingsNextIDL = 0
                        Case 1108, 2108, 3108, 4108, 1208, 2208, 3208, 4208     ' Game #8...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 6
                            intGameRankingsNextIDL = 0
                        Case 1109, 2109, 3109, 4109, 1209, 2209, 3209, 4209     ' Game #9...
                            intGameRankingsNextIDW = 0
                            intGameRankingsNextIDL = 0
                        Case 1110, 2110, 3110, 4110, 1210, 2210, 3210, 4210     ' Game #10...
                            intGameRankingsNextIDW = 0
                            intGameRankingsNextIDL = 0
                        Case 1111, 2111, 3111, 4111, 1211, 2211, 3211, 4211     ' Game #11...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 4
                            intGameRankingsNextIDL = 0
                        Case 1112, 2112, 3112, 4112, 1212, 2212, 3212, 4212     ' Game #12...
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 3
                            intGameRankingsNextIDL = 0
                        Case 1113, 2113, 3113, 4113, 1213, 2213, 3213, 4213     ' Game #13...
                            ysnTopW = True
                            intGameRankingsNextIDW = intGameRankingsID + 3
                            intGameRankingsNextIDL = 0
                        Case 1114, 2114, 3114, 4114, 1214, 2214, 3214, 4214     ' Game #14...
                            ysnTopW = False
                            intGameRankingsNextIDW = intGameRankingsID + 2
                            intGameRankingsNextIDL = 0
                        Case 1115, 2115, 3115, 4115, 1215, 2215, 3215, 4215     ' Game #15...
                            intGameRankingsNextIDW = 0
                            intGameRankingsNextIDL = 0
                        Case 1116, 2116, 3116, 4116, 1216, 2216, 3216, 4216     ' Game #16...
                            intGameRankingsNextIDW = 0
                            intGameRankingsNextIDL = 0
                    End Select

                    ' UPDATE NEXT ROUND WINNER (and swap)...
                    If intGameRankingsNextIDW > 0 Then
                        strSQLW = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDW & " AND strType = 'TOSSAAR' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLW = ""
                    End If

                    If strSQLW = "" Then
                    Else
                        Dim dsW As DataSet
                        dsW = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLW)

                        If dsW Is Nothing Then
                        ElseIf dsW.Tables.Count = 0 Then
                        ElseIf dsW.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Winner 1...
                            If ysnTopW Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ", oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Winner Game...
                            If dsW.Tables(0).Rows.Count = 2 Then
                                If ysnTopW Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamWinner & ",oTeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamWinner & ", TeamID = " & intWinner & " WHERE scheduleID = " & dsW.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        End If
                    End If

                    ' UPDATE NEXT ROUND LOSER (and swap)...
                    If intGameRankingsNextIDL > 0 Then
                        strSQLL = "SELECT * FROM tblSchedules WHERE sportID = '" & .Item("sportID") & "' AND intGame = " & intGameRankingsNextIDL & " AND strType = 'TOSSAAR' AND intYear = " & clsFunctions.GetCurrentYear & " ORDER BY scheduleID"
                    Else
                        strSQLL = ""
                    End If

                    If strSQLL = "" Then

                    Else
                        Dim dsL As DataSet
                        dsL = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQLL)

                        If dsL Is Nothing Then
                        ElseIf dsL.Tables.Count = 0 Then
                        ElseIf dsL.Tables(0).Rows.Count = 0 Then
                        Else
                            ' Loser 1...
                            If ysnTopL Then
                                strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            Else
                                strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(0).Item("scheduleID")
                            End If
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Other Loser Game...
                            If dsL.Tables(0).Rows.Count = 2 Then
                                If ysnTopL Then
                                    strSQL = "UPDATE tblSchedules SET TeamBottom = " & TeamLoser & ", oTeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                Else
                                    strSQL = "UPDATE tblSchedules SET TeamTop = " & TeamLoser & ", TeamID = " & intLoser & " WHERE scheduleID = " & dsL.Tables(0).Rows(1).Item("scheduleID")
                                End If
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If

                        End If
                    End If
                End If
            End With
        End If

    End Sub

    Public Sub AdvanceToNextRoundDistrict(ByVal intScheduleID As Long)
        Dim strSQL As String
        Dim ds As DataSet
        Dim intWinner As Long = 0
        Dim intRound2ID As Long = 0
        Dim intRound2IDa As Long = 0
        Dim ds1 As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            If ds1.Tables(0).Rows(0).Item("TotalScore") > 0 Or ds1.Tables(0).Rows(0).Item("oTotalScore") > 0 Then
                If ds1.Tables(0).Rows(0).Item("intGame") <= 16 Then
                    With ds1.Tables(0).Rows(0)
                        If .Item("TotalScore") > .Item("oTotalScore") Then
                            intWinner = .Item("teamID")
                        Else
                            intWinner = .Item("oTeamID")
                        End If
                        ' Update the Second Round Game with the Winning team...
                        strSQL = "UPDATE tblSchedules SET oTeamID = " & intWinner & ", OtherTeam = Null WHERE oTeamID = 0 AND sportID = '" & .Item("sportID") & "' AND NeutralSiteCoor = '" & .Item("NeutralSiteCoor") & "'"
                        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                        ' Get the Second Round Game we just updated...
                        strSQL = "SELECT * FROM tblSchedules WHERE oTeamID = " & intWinner & " AND sportID = '" & .Item("sportID") & "' AND NeutralSiteCoor = '" & .Item("NeutralSiteCoor") & "' AND intGame > 16"
                        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                    End With

                    If ds Is Nothing Then
                    ElseIf ds.Tables.Count = 0 Then
                    ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Else
                        With ds.Tables(0).Rows(0)
                            ' Swap the game for the winner...
                            intRound2ID = .Item("scheduleID")
                            strSQL = "INSERT INTO tblSchedules (teamID, oTeamID, sportID, osportID, intGame, gameDate, gameTime, Location, NeutralSiteCoor, scheduleIDxref, strType) VALUES ("
                            strSQL = strSQL & .Item("oTeamID") & ", "
                            strSQL = strSQL & .Item("TeamID") & ", "
                            strSQL = strSQL & "'" & .Item("sportID") & "', '" & .Item("sportID") & "', "
                            strSQL = strSQL & .Item("intGame") & ", "
                            strSQL = strSQL & "'" & .Item("gameDate") & "', "
                            strSQL = strSQL & "'" & .Item("gameTime") & "', "
                            strSQL = strSQL & "'" & .Item("Location") & "', "
                            strSQL = strSQL & "'" & .Item("NeutralSiteCoor") & "', "
                            strSQL = strSQL & intRound2ID & ", "
                            strSQL = strSQL & "'" & .Item("strType") & "') "
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Get the ID of the new record...
                            strSQL = "SELECT scheduleID FROM tblSchedules WHERE scheduleIDxref = " & intRound2ID
                            intRound2IDa = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                            ' Now update...
                            strSQL = "UPDATE tblSchedules SET scheduleIDxref = " & intRound2IDa & " WHERE scheduleID = " & intRound2ID
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                        End With
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub UpdateNextRoundRegionalState(ByVal intScheduleID As Long, ByVal intScore1 As Integer, ByVal intScore2 As Integer, ByVal intTeamIDMe As Long, strTypeSource As String)
        Dim strSQL As String
        Dim ds As DataSet
        Dim dsD As DataSet

        Dim intTeamID1 As Long = 0
        Dim intTeamID2 As Long = 0
        Dim intGame As Integer = 0
        Dim intGameNext As Integer = 0
        Dim strSportID As String = ""
        Dim intTeamIDWinner As Long = 0
        Dim intTeamIDLoser As Long = 0
        Dim x As Integer = 0
        Dim intTeamIDTop As Long = 0
        Dim intTeamIDBottom As Long = 0
        Dim dsT As DataSet

        strSQL = "SELECT * FROM tblSchedules WHERE scheduleID = " & intScheduleID
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                intGame = .Item("intGame")
                If intGame > 0 Then
                    If intGame = 1 Or intGame = 2 Then
                        intGameNext = 5
                    ElseIf intGame = 3 Or intGame = 4 Then
                        intGameNext = 6
                    ElseIf intGame = 5 Or intGame = 6 Then
                        intGameNext = 7
                    End If
                    strSportID = .Item("sportID")

                    strSQL = "SELECT TOP 3 * FROM tblSchedules WHERE intGame = " & intGameNext & " AND sportID = '" & strSportID & "' AND strType = '" & strTypeSource & "' ORDER BY NeutralSiteID"
                    dsD = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                    If dsD Is Nothing Then
                    ElseIf dsD.Tables.Count = 0 Then
                    ElseIf dsD.Tables(0).Rows.Count = 0 Then
                    Else
                        ' Get the winning team...
                        If intScore1 > intScore2 Then
                            intTeamIDWinner = .Item("teamID")
                            intTeamIDLoser = .Item("oteamID")
                        ElseIf intScore2 > intScore1 Then
                            intTeamIDWinner = .Item("oteamID")
                            intTeamIDLoser = .Item("teamID")
                        Else
                            intGame = 0         ' Do nothing, it's a dtie so we don't know who won...
                        End If

                        ' Now update to the next round....
                        Select Case intGame
                            Case 1, 3, 5
                                strSQL = "UPDATE tblSchedules SET teamID = " & intTeamIDWinner & " WHERE scheduleID = " & dsD.Tables(0).Rows(0).Item("scheduleID")
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                If dsD.Tables(0).Rows.Count > 1 Then
                                    strSQL = "UPDATE tblSchedules SET oteamID = " & intTeamIDWinner & " WHERE scheduleID = " & dsD.Tables(0).Rows(1).Item("scheduleID")
                                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                End If

                                ' Is it complete?  Then "clear" the dummy semi record...
                                If dsD.Tables(0).Rows.Count > 2 Then
                                    If dsD.Tables(0).Rows(1).Item("teamID") > 0 Then
                                        strSQL = "UPDATE tblSchedules SET ysnActive = 0 WHERE scheduleID = " & dsD.Tables(0).Rows(2).Item("scheduleID")
                                        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                    End If
                                End If

                                ' TODO... Fix this logic...
                                If 1 = 2 Then
                                    ' Now Update tblSportsPlayoffsDetail...
                                    strSQL = "SELECT intTeamTop" & intGame & " AS intTeamTop, intTeamBottom" & intGame & " AS intTeamBottom FROM ossaauser.tblSportsPlayoffsDetail "
                                    strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                    dsT = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                    If dsT Is Nothing Then
                                    ElseIf dsT.Tables.Count = 0 Then
                                    ElseIf dsT.Tables(0).Rows.Count = 0 Then
                                    Else
                                        intTeamIDTop = dsT.Tables(0).Rows(0).Item("intTeamTop")
                                        intTeamIDBottom = dsT.Tables(0).Rows(0).Item("intTeamBottom")

                                        If intTeamIDTop = intTeamIDMe Then
                                            strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                            strSQL = strSQL & "intScoreTop" & intGame & " = " & intScore1 & ", intScoreBottom" & intGame & " = " & intScore2 & " "
                                            strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                            ' Now move on the next team...
                                            If intScore1 < intScore2 Then           ' My Team LOST...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamTop" & intGameNext & " = strTeamBottom" & intGame & ", intTeamTop" & intGameNext & " = intTeamBottom" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            Else                                                ' My Team WON...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamTop" & intGameNext & " = strTeamTop" & intGame & ", intTeamTop" & intGameNext & " = intTeamTop" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            End If

                                        ElseIf intTeamIDBottom = intTeamIDMe Then
                                            strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                            strSQL = strSQL & "intScoreTop" & intGame & " = " & intScore2 & ", intScoreBottom" & intGame & " = " & intScore1 & " "
                                            strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                            ' Now move on the next team...
                                            If intScore1 < intScore2 Then           ' My Team LOST...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamTop" & intGameNext & " = strTeamTop" & intGame & ", intTeamTop" & intGameNext & " = intTeamTop" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            Else                                                ' My Team WON...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamTop" & intGameNext & " = strTeamBottom" & intGame & ", intTeamTop" & intGameNext & " = intTeamBottom" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            End If

                                        Else

                                        End If
                                    End If
                                End If

                            Case 2, 4, 6
                                strSQL = "UPDATE tblSchedules SET oteamID = " & intTeamIDWinner & " WHERE scheduleID = " & dsD.Tables(0).Rows(0).Item("scheduleID")
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                If dsD.Tables(0).Rows.Count > 1 Then
                                    strSQL = "UPDATE tblSchedules SET teamID = " & intTeamIDWinner & " WHERE scheduleID = " & dsD.Tables(0).Rows(1).Item("scheduleID")
                                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                End If

                                ' Is it complete?  Then "clear" the dummy semi record...
                                If dsD.Tables(0).Rows.Count > 2 Then
                                    If dsD.Tables(0).Rows(1).Item("oteamID") > 0 Then
                                        strSQL = "UPDATE tblSchedules SET ysnActive = 0 WHERE scheduleID = " & dsD.Tables(0).Rows(2).Item("scheduleID")
                                        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                    End If
                                End If

                                ' TODO... Fix this logic...
                                If 1 = 2 Then
                                    ' Now Update tblSportsPlayoffsDetail...
                                    strSQL = "SELECT intTeamTop" & intGame & " AS intTeamTop, intTeamBottom" & intGame & " AS intTeamBottom FROM ossaauser.tblSportsPlayoffsDetail "
                                    strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                    dsT = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                    If dsT Is Nothing Then
                                    ElseIf dsT.Tables.Count = 0 Then
                                    ElseIf dsT.Tables(0).Rows.Count = 0 Then
                                    Else
                                        intTeamIDTop = dsT.Tables(0).Rows(0).Item("intTeamTop")
                                        intTeamIDBottom = dsT.Tables(0).Rows(0).Item("intTeamBottom")

                                        If intTeamIDTop = intTeamIDMe Then
                                            strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                            strSQL = strSQL & "intScoreTop" & intGame & " = " & intScore1 & ", intScoreBottom" & intGame & " = " & intScore2 & " "
                                            strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                            ' Now move on the next team...
                                            If intScore1 < intScore2 Then           ' My Team LOST...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamBottom" & intGameNext & " = strTeamBottom" & intGame & ", intTeamBottom" & intGameNext & " = intTeamBottom" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            Else                                                ' My Team WON...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamBottom" & intGameNext & " = strTeamTop" & intGame & ", intTeamBottom" & intGameNext & " = intTeamTop" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            End If

                                        ElseIf intTeamIDBottom = intTeamIDMe Then
                                            strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                            strSQL = strSQL & "intScoreTop" & intGame & " = " & intScore2 & ", intScoreBottom" & intGame & " = " & intScore1 & " "
                                            strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                                            ' Now move on the next team...
                                            If intScore1 > intScore2 Then           ' My Team WON...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamBottom" & intGameNext & " = strTeamBottom" & intGame & ", intTeamBottom" & intGameNext & " = intTeamBottom" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            Else                                                ' My Team LOST...
                                                strSQL = "UPDATE ossaauser.tblSportsPlayoffsDetail SET "
                                                strSQL = strSQL & "strTeamBottom" & intGameNext & " = strTeamTop" & intGame & ", intTeamBottom" & intGameNext & " = intTeamTop" & intGame & " "
                                                strSQL = strSQL & "WHERE strSportGenderKey = '" & dsD.Tables(0).Rows(0).Item("sportID") & "' AND TourneyKey Like '%STATE'"
                                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                                            End If
                                        Else
                                        End If
                                    End If
                                End If
                            Case 7
                                ' Do nothing...
                        End Select
                    End If

                End If
            End With
        End If

    End Sub

    Public Function SwapSportGender(ByVal strSportIn As String) As String
        Dim strSportOut As String = ""
        If strSportIn Is Nothing Then
            strSportOut = ""
        Else
            If strSportIn.Contains("Boys") Then
                strSportOut = strSportIn.Replace("Boys", "Girls")
            ElseIf strSportIn.Contains("Girls") Then
                strSportOut = strSportIn.Replace("Girls", "Boys")
            End If
        End If
        Return strSportOut
    End Function
    Public Sub HeaderChange(ByVal strHeader As String)
        Me.lblHeader.Text = strHeader
    End Sub
    Private Function Validate(strSport As String) As String
        Dim strReturn As String = "OK"

        If RadDatePicker1.SelectedDate Is Nothing Then
            strReturn = "You must select a game date (use MM/DD/YYYY)."
            'ElseIf RadDatePicker1.SelectedDate.ToString Is System.DBNull.Value Then                                ' Added 11/18/2014...
            '    strReturn = "You must select a game date (use MM/DD/YYYY)."
        ElseIf Len(RadDatePicker1.SelectedDate) > 10 Or Len(RadDatePicker1.SelectedDate) <= 5 Then
            strReturn = "Invalid game date (use MM/DD/YYYY)."
        ElseIf (InStr(RadDatePicker1.SelectedDate, "/") = 0 And InStr(RadDatePicker1.SelectedDate, "-") = 0) Then
            strReturn = "Invalid game date (use MM/DD/YYYY)."
        ElseIf Me.cboGameLocation.SelectedIndex = 0 Then
            strReturn = "You must select a Game Site."
        ElseIf Me.cboGameType.SelectedIndex = 0 Then
            strReturn = "You must select a Type."
        ElseIf (Me.cboSchools.SelectedValue = 0 And Me.txtSchool.Text = "") And rowSchools2.Visible And rowTourney4.Visible Then
            txtSchool.Text = "TBA"
            strReturn = "OK"
        ElseIf (Me.cboSchools.SelectedValue = 0 And Me.txtSchool.Text = "") And rowSchools2.Visible Then
            strReturn = "You must select a school."
        Else
            ' Allow OSSAAADMIN to add playoff games...
            If Session("memgRole") = "OSSAAADMIN" Then
                strReturn = "OK"
            Else
                ' DO NOT ALLOW ADDING GAMES FROM PLAYOFFS... 2/21/2014 added...
                If strSport.Contains("Basketball") And cboGameType.SelectedValue.Contains("TOSSAA") And Session("memgScheduleID") = 0 Then
                    strReturn = "You cannot add a new Basketball Playoff game."
                Else
                    strReturn = "OK"
                End If
            End If
        End If

        Return strReturn

    End Function

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intYear As Integer
        Dim ds As DataSet

        If Not IsPostBack Then

            ' Set Date Picker Min and Max range... 7/8/2014...
            Dim minDate As New DateTime(2019, 8, 1, 0, 0, 0, 0)
            Dim maxDate As New DateTime(2020, 5, 30, 0, 0, 0, 0)

            RadDatePicker1.MinDate = minDate
            RadDatePicker1.MaxDate = maxDate

            ' Load the teams for the Schools dropdown...

            If Session("memdsTeams") Is Nothing Then
                intYear = clsFunctions.GetCurrentYear
                ds = clsTeams.GetSportTeamsForSport(Session("memgSportGenderKey"), clsFunctions.GetCurrentYear, Session("memgTeamID"))
                Me.cboSchools.DataSource = ds
                Session("memdsTeams") = ds
                Me.cboSchools.DataTextField = "School"
                Me.cboSchools.DataValueField = "teamID"
                Me.cboSchools.DataBind()
                Dim objItem As New System.Web.UI.WebControls.ListItem
                objItem.Text = "Select School..."
                objItem.Value = 0
                Me.cboSchools.Items.Insert(0, objItem)
            Else
                Me.cboSchools.DataSource = Session("memdsTeams")
                Me.cboSchools.DataTextField = "School"
                Me.cboSchools.DataValueField = "teamID"
                Me.cboSchools.DataBind()
                Dim objItem As New System.Web.UI.WebControls.ListItem
                objItem.Text = "Select School..."
                objItem.Value = 0
                Me.cboSchools.Items.Insert(0, objItem)
            End If

            ' Load the Schedule Types...
            Dim ds1 As DataSet
            ds1 = clsSchedules.GetScheduleGameTypeDataSet(Session("memgSport"))
            If ds1 Is Nothing Then
                ds1 = clsSchedules.GetScheduleGameTypeDataSet(Session("memgSportGenderKey"))
            ElseIf ds1.Tables.Count = 0 Then
                ds1 = clsSchedules.GetScheduleGameTypeDataSet(Session("memgSportGenderKey"))
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
                ds1 = clsSchedules.GetScheduleGameTypeDataSet(Session("memgSportGenderKey"))
            End If
            cboGameType.DataSource = ds1
            cboGameType.DataBind()
            cboGameType.Items.Insert(0, "Select...")
            cboGameType = StripDistrictFromGameType(cboGameType, Session("memgSport"), Session("memgClass"))            ' Added 9/27/2013...

            ' Turn on/off the Post Gender only on a NEW item...
            If Session("memgScheduleID") = 0 Then
                Dim strSportcb As String = ""
                strSportcb = Session("memgSportID")
                If strSportcb Is Nothing Then strSportcb = ""
                lblPostGender.Visible = False
                cbPostGender.Visible = False
                ' Removed 4/4/2019...
                'Try
                '    If strSportcb.Contains("Basketball") Then
                '        lblPostGender.Visible = False
                '        cbPostGender.Visible = False
                '    ElseIf strSportcb.Contains("Golf") Then
                '        lblPostGender.Visible = False
                '        cbPostGender.Visible = False
                '    ElseIf strSportcb.Contains("Boys") Then
                '        lblPostGender.Visible = True
                '        cbPostGender.Visible = True
                '        lblPostGender.Text = "Post to Girls Schedule?"
                '        cbPostGender.Checked = True
                '    ElseIf strSportcb.Contains("Girls") Then
                '        lblPostGender.Visible = True
                '        cbPostGender.Visible = True
                '        lblPostGender.Text = "Post to Boys Schedule?"
                '        cbPostGender.Checked = True
                '    Else
                '        lblPostGender.Visible = False
                '        cbPostGender.Visible = False
                '    End If
                'Catch
                '    lblPostGender.Visible = False
                '    cbPostGender.Visible = False
                'End Try
            End If

        End If

        ' Take away District checkbox from some sports...
        Dim strSport As String
        strSport = Session("memgSport")
        strSport = clsSchedules.GetScheduleSport(strSport)

        If Request.QueryString("sel") = "ScheduleEdit" Then
            If Not IsPostBack Then
                If Request.QueryString("sel") = "ScheduleEdit" Then
                    If Session("memgScheduleID") > 0 Then
                        LoadFields(Session("memgScheduleID"))
                    End If
                End If
            End If
        ElseIf Request.QueryString("sel") = "ScheduleAdd" Then
            Me.txtScoreMy.Text = "0"
            Me.txtScoreOpp.Text = "0"
        End If

        If (cboGameType.SelectedValue = "TOSSAAD" Or cboGameType.SelectedValue = "TOSSAAA" Or cboGameType.SelectedValue = "TOSSAAR" Or cboGameType.SelectedValue = "TOSSAAS" Or cboGameType.SelectedValue = "TOSSAASD") And Session("memgRole") <> "OSSAAADMIN" Then
            cboGameType.Enabled = False
            If cboGameType.SelectedValue = "TOSSAAS" Or cboGameType.SelectedValue = "TOSSAASD" Then
                cboSchools.Enabled = False
                cboGameLocation.Enabled = False
                txtSchool.Enabled = False
            End If
        Else
            cboGameType.Enabled = True
            cboSchools.Enabled = True
            cboGameLocation.Enabled = True
            txtSchool.Enabled = True
        End If

        ' CDW added 10/15/2018...
        If cboGameType.SelectedValue = "TOSSAAS" And Session("memgRole") <> "OSSAAADMIN" Then
            cmdSaveChanges.Enabled = False
        Else
            cmdSaveChanges.Enabled = True
        End If

        ShowScreen(cboGameType.SelectedValue, Session("memgResults"), Session("memgSport"), Session("memgScheduleID"))

        'End If

    End Sub

    Public Shared Function StripDistrictFromGameType(ByVal objGameType As System.Web.UI.WebControls.DropDownList, ByVal strSport As String, ByVal strClass As String) As System.Web.UI.WebControls.DropDownList
        ' Strip out the DIST if not needed... Added 9/27/2013...
        If strSport = "Baseball" Then
			If strClass = "A" Or strClass = "B" Then
				objGameType.Items.FindByValue("DIST").Enabled = False
			End If
		ElseIf strSport = "FPSoftball" Then         ' Added 8/8/2018...
            If strClass = "A" Or strClass = "B" Then
                objGameType.Items.FindByValue("DIST").Enabled = False
            End If
        End If
        Return objGameType
    End Function

    Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        ClearFields()
        Me.Visible = False
        Response.Redirect("Home.aspx?sel=Schedule")
    End Sub

    Private Sub ClearFields()
        On Error Resume Next
        'RadDatePicker1.SelectedDate = Format(Now, "Short Date")
        RadDatePicker1.SelectedDate = Format("8/1/2018", "Short Date")
        Me.cboGameLocation.SelectedIndex = 0
        Me.cboGameTimeHour.SelectedIndex = 0
        Me.cboGameTimeMinute.SelectedIndex = 0
        Me.cboSchools.SelectedIndex = 0
        Me.txtSchool.Text = ""
        cboGameType.SelectedIndex = 0
        txtTournament.Text = ""
        'Me.CheckBoxDistrict.Checked = False
    End Sub

    Public Sub LoadFields(ByVal scheduleID As Long)


        ' Load the Pitcher Dropdowns...

        Dim objSc As New clsSchedule(scheduleID)

        lblID.Text = "&nbsp;" & scheduleID & " - " & objSc.scheduleIDxref
        Me.cboGameLocation.SelectedValue = objSc.location
        RadDatePicker1.SelectedDate = objSc.gamedate
        Me.cboGameTimeHour.SelectedValue = objSc.timeHour
        Me.cboGameTimeMinute.SelectedValue = objSc.timeMin
        Me.cboGameAMPM.SelectedValue = objSc.timeAMPM
        Try
            cboGameType.SelectedValue = objSc.gameType
        Catch

        End Try
        If objSc.oTeamID = 0 Then
            Me.txtSchool.Text = objSc.opposingTeamName
        Else
            Try
                Me.cboSchools.SelectedValue = objSc.oTeamID
            Catch
            End Try
        End If
        Me.txtScoreMy.Text = objSc.scoreMy
        Me.txtScoreOpp.Text = objSc.scoreThem
        Me.cboStatus.SelectedValue = objSc.gameStatus
        Me.txtSchool.Text = objSc.otherTeam
        Me.txtTournament.Text = objSc.tournament

        Session("memgScheduleIDxref") = objSc.scheduleIDxref
        Session("memgScheduleIDxrefG") = objSc.scheduleIDxrefG
        Me.intGame.Text = objSc.intGame

        ShowScreen(cboGameType.SelectedValue, Session("memgResults"), Session("memgSport"), Session("memgScheduleID"))

        If rowResults2.Visible Then
            txtResults.Text = objSc.gResults
        Else
            txtResults.Text = ""
        End If

        DropDownListPitchers1.SelectedValue = objSc.pitcherID1
        DropDownListPitchers2.SelectedValue = objSc.pitcherID2
        DropDownListPitchers3.SelectedValue = objSc.pitcherID3
        DropDownListPitchers4.SelectedValue = objSc.pitcherID4
        DropDownListPitchers5.SelectedValue = objSc.pitcherID5
        DropDownListPitchers6.SelectedValue = objSc.pitcherID6
        DropDownListPitchers7.SelectedValue = objSc.pitcherID7

        If objSc.pitchCount1 > 0 Then
            txtPitchCount1.Text = objSc.pitchCount1
        End If

        If objSc.pitchCount2 > 0 Then
            txtPitchCount2.Text = objSc.pitchCount2
        End If

        If objSc.pitchCount3 > 0 Then
            txtPitchCount3.Text = objSc.pitchCount3
        End If

        If objSc.pitchCount4 > 0 Then
            txtPitchCount4.Text = objSc.pitchCount4
        End If

        If objSc.pitchCount5 > 0 Then
            txtPitchCount5.Text = objSc.pitchCount5
        End If

        If objSc.pitchCount6 > 0 Then
            txtPitchCount6.Text = objSc.pitchCount6
        End If

        If objSc.pitchCount7 > 0 Then
            txtPitchCount7.Text = objSc.pitchCount7
        End If

    End Sub

    Private Sub cboGameType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGameType.SelectedIndexChanged
        ShowScreen(cboGameType.SelectedValue, Session("memgResults"), Session("memgSport"), Session("memgScheduleID"))
    End Sub

    Public Sub ShowScreen(ByVal strGameType As String, ByVal intResult As Integer, ByVal strSport As String, ByVal intScheduleID As Long)

        If strSport = "Wrestling" Then
            If cboGameType.SelectedValue = "TOSSAASD" Then
                intResult = 0
            ElseIf Left(cboGameType.SelectedValue, 1) = "T" Then
                intResult = 1
            Else
                intResult = 0
            End If
        End If

        If strSport Is Nothing Then
            strSport = ""
        End If

        If intResult = 0 Then   ' ENTER SCORE ONLY...
            If Left(cboGameType.SelectedValue, 1) = "T" Then
                ' Score Only and a Tourney...
                rowScore.Visible = True
                rowScoreH.Visible = True
                rowTourney3.Visible = True
                rowTourney4.Visible = True
                rowSchools1.Visible = True
                rowSchools2.Visible = True
                rowSchools3.Visible = True
                rowSchools4.Visible = True
                If strSport.Contains("Volleyball") Then
                    rowResults1.Visible = True
                    rowResults2.Visible = True
                    lblResults.Text = "Match Details"
                Else
                    rowResults1.Visible = False
                    rowResults2.Visible = False
                    lblResults.Text = "RESULTS"
                End If

            ElseIf cboGameType.SelectedValue = "SCRIM" Then
                rowScore.Visible = False
                rowScoreH.Visible = False
                rowTourney3.Visible = True
                rowTourney4.Visible = True
                rowSchools1.Visible = False
                rowSchools2.Visible = False
                rowSchools3.Visible = False
                rowSchools4.Visible = False
                rowResults1.Visible = True
                rowResults2.Visible = True
                lblResults.Text = "RESULTS"
            Else
                If strSport.Contains("Volleyball") Then
                    ' Score and Results...
                    rowScore.Visible = True
                    rowScoreH.Visible = True
                    rowTourney3.Visible = False
                    rowTourney4.Visible = False
                    rowSchools1.Visible = True
                    rowSchools2.Visible = True
                    rowSchools3.Visible = True
                    rowSchools4.Visible = True
                    rowResults1.Visible = True
                    rowResults2.Visible = True
                    lblResults.Text = "Match Details"
                Else
                    ' Score Only and a Non-Tourney...
                    rowScore.Visible = True
                    rowScoreH.Visible = True
                    rowTourney3.Visible = False
                    rowTourney4.Visible = False
                    rowSchools1.Visible = True
                    rowSchools2.Visible = True
                    rowSchools3.Visible = True
                    rowSchools4.Visible = True
                    rowResults1.Visible = False
                    rowResults2.Visible = False
                    lblResults.Text = "RESULTS"
                End If
            End If
        Else                                                    ' intResults <> 0.....
            ' ENTER RESULTS ONLY...
            If (strSport.Contains("Wrestling") And intResult = 1) Or (strSport.Contains("Golf") And intResult = 1) Then           ' Wrestling (Tournament)....
                rowScore.Visible = True
                rowScoreH.Visible = True

                ' Collect the Place...
                If strSport.Contains("Golf") Then
                    lblScoreMy.Text = "TEAM SCORE (avg score per round)"
                Else
                    lblScoreMy.Text = "PLACE"
                End If
                lblScoreMy.Visible = True
                lblScoreTheirs.Visible = False
                lblStatus.Visible = False
                txtScoreMy.Visible = True
                txtScoreOpp.Visible = False

                cboStatus.Visible = False
                rowTourney3.Visible = True
                rowTourney4.Visible = True
                rowSchools1.Visible = False
                rowSchools2.Visible = False
                rowSchools3.Visible = False
                rowSchools4.Visible = False
                rowResults1.Visible = True
                rowResults2.Visible = True

            Else    ' Other intResult = 1 or intResult = 2...
                rowScore.Visible = False
                rowScoreH.Visible = False
                rowTourney3.Visible = True
                rowTourney4.Visible = True
                rowSchools1.Visible = False
                rowSchools2.Visible = False
                rowSchools3.Visible = False
                rowSchools4.Visible = False
                rowResults1.Visible = True
                rowResults2.Visible = True
            End If
        End If

        ' If we are just now adding, don't show...
        If (intScheduleID = 0 And cboGameType.SelectedValue = "Select...") And rowScore.Visible Then
            rowScore.Visible = False
            rowScoreH.Visible = False
        End If

        ' 02/23/2016 added...
        If strSport.Contains("Baseball") Then
            rowPitchers.Visible = True
            rowPitcher1.Visible = True
            rowPitcher2.Visible = True
            rowPitcher3.Visible = True
            rowPitcher4.Visible = True
            rowPitcher5.Visible = True
            rowPitcher6.Visible = True
            rowPitcher7.Visible = True

            Dim ds As DataSet
            Dim strSQL As String = "SELECT rosterID, LastName + ', ' + FirstName AS PlayerName, teamID FROM tblRosters WHERE ysnActive <> 0 AND ysnPitcher <> 0 AND teamID = " & Session("memgTeamID")
            strSQL = strSQL & " UNION SELECT TOP 1 0 AS RosterID, 'Select...' AS PlayerName, 0 AS teamID FROM tblRosters "
            strSQL = strSQL & "ORDER BY teamID, PlayerName"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            DropDownListPitchers1.DataSource = ds
            DropDownListPitchers2.DataSource = ds
            DropDownListPitchers3.DataSource = ds
            DropDownListPitchers4.DataSource = ds
            DropDownListPitchers5.DataSource = ds
            DropDownListPitchers6.DataSource = ds
            DropDownListPitchers7.DataSource = ds
            Try
                DropDownListPitchers1.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers2.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers3.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers4.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers5.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers6.DataBind()
            Catch
            End Try
            Try
                DropDownListPitchers7.DataBind()
            Catch
            End Try
        Else
            rowPitchers.Visible = False
            rowPitcher1.Visible = False
            rowPitcher2.Visible = False
            rowPitcher3.Visible = False
            rowPitcher4.Visible = False
            rowPitcher5.Visible = False
            rowPitcher6.Visible = False
            rowPitcher7.Visible = False
        End If

    End Sub


    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim strSQL As String

        ' TODO : Turn ON again...
        If (Me.intGame.Text <> "0") And (cboGameType.SelectedValue = "TOSSAAD" Or cboGameType.SelectedValue = "TOSSAASD" Or cboGameType.SelectedValue = "TOSSAAA" Or cboGameType.SelectedValue = "TOSSAAR" Or cboGameType.SelectedValue = "TOSSAAS" Or cboGameType.SelectedValue = "TOSSAASD" Or cboGameType.SelectedValue = "TOSSAA32" Or cboGameType.SelectedValue = "TOSSAA16" Or cboGameType.SelectedValue = "TOSSAA8" Or cboGameType.SelectedValue = "TOSSAA4" Or cboGameType.SelectedValue = "TOSSAA2" Or cboGameType.SelectedValue = "TOSSAA") And Session("memgRole") <> "OSSAAADMIN" Then

            Select Case cboGameType.SelectedValue
                Case "TOSSAAD"
                    lblMessage.Text = "You can not delete an OSSAA District Tournament game."
                Case "TOSSAAA"
                    lblMessage.Text = "You can not delete an OSSAA Area Tournament game."
                Case "TOSSAAR"
                    lblMessage.Text = "You can not delete an OSSAA Regional Tournament game."
                Case "TOSSAAS"
                    lblMessage.Text = "You can not delete an OSSAA State Tournament game."
                Case "TOSSAASD"
                    lblMessage.Text = "You can not delete an OSSAA Dual State Tournament game."
                Case "TOSSAA32"
                    lblMessage.Text = "You can not delete an OSSAA Playoffs 1st Round Game"
                Case "TOSSAA16"
                    lblMessage.Text = "You can not delete an OSSAA Playoffs 2nd Round Game"
                Case "TOSSAA8"
                    lblMessage.Text = "You can not delete an OSSAA Quarter Final Game"
                Case "TOSSAA4"
                    lblMessage.Text = "You can not delete an OSSAA Semi-Final Game"
                Case "TOSSAA2"
                    lblMessage.Text = "You can not delete an OSSAA State Championship Game"
                Case "TOSSAA1"
                    lblMessage.Text = "You can not delete an OSSAA Playoffs 1st Round Game"
            End Select

        Else
            strSQL = "UPDATE tblSchedules SET ysnActive = 0 WHERE scheduleID = " & Session("memgScheduleID")
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            ClearFields()
            Me.Visible = False
            ' Recalc W/L record...
            If Session("memgShowRecord") = 1 Then
                Session("memgWL") = clsTeams.GetCalcWLTeamDisplay(Session("memgTeamID"), True)
            End If
            Response.Redirect("Home.aspx?sel=Schedule")
        End If

    End Sub

    Public Function GetWL(ByVal intMyPoints As Integer, ByVal intOppPoints As Integer) As String
        Dim strWL As String
        If intMyPoints > intOppPoints Then
            strWL = "W"
        ElseIf intOppPoints > intMyPoints Then
            strWL = "L"
        Else
            strWL = "-"
        End If
        Return strWL
    End Function

    Private Sub cboSchools_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSchools.SelectedIndexChanged
        Me.txtSchool.Text = ""
    End Sub

End Class

