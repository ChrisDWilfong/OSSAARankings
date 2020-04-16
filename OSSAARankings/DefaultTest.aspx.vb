Public Class DefaultTest
    Inherits System.Web.UI.Page

    Public MenuIndexRankings As Integer = 0
    Public MenuIndexSchedulesPlayoffs As Integer = 1
    Public MenuIndexSchedulesByClass As Integer = 1
    Public MenuIndexSchedulesByDate As Integer = 2
    Public MenuIndexDistrictStandings As Integer = 3
    Public MenuIndexSchools As Integer = 4
    Public MenuIndexCoaches As Integer = 5
    Public MenuIndexAthleticDirectors As Integer = 6
    Public MenuIndexSchedulesByClass14 As Integer = 7
    Public MenuIndexSchedulesByClass15 As Integer = 8
    Public MenuIndexSchedulesByClass16 As Integer = 9
    Public MenuIndexSchedulesByClass17 As Integer = 10
    Public MenuIndexSchedulesByClass18 As Integer = 11

    Private Sub Page_Error(sender As Object, e As System.EventArgs) Handles Me.Error
        On Error Resume Next
        Dim objErr As Exception = Server.GetLastError.GetBaseException
        Dim strSQL As String

        strSQL = "INSERT INTO dbo.Errors (errDescription, URL, RequestMethod, HostAddress, UserAgent, AllHTTP) VALUES ('" & objErr.Message.Replace("'", "") & "', '" & Request.Url.ToString & "', '" & Request.ServerVariables("REQUEST_METHOD") & "', '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Session("gUserName") & "', '" & objErr.StackTrace.ToString & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Page.ClientTarget = "Uplevel"           ' Added 11/20/2013 to resolve IE 11 compatibility problem...

        'Response.Redirect("http://ossaarankings.mobi")

        If 1 = 1 Then
        Else
            Dim strControlName1 As String = ""
            Dim objControlRight1 As UserControl
            Session("gGender") = Request.QueryString("g")
            Session("gSport") = Request.QueryString("sp")
            Session("gSportGenderKey") = Request.QueryString("spGK")
            strControlName1 = "ucViewHomePageTest.ascx"
            LeftAccordion.SelectedIndex = MenuIndexRankings
            If strControlName1 = "" Then
            Else
                objControlRight1 = CType(LoadControl(strControlName1), UserControl)
                objControlRight1.Session.Add("gGender", Session("gGender"))
                objControlRight1.Session.Add("gSport", Session("gSport"))
                objControlRight1.Session.Add("sel", Session("sel"))
                objControlRight1.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
				objControlRight1.Session.Add("gTeamID", Session("gTeamID"))
				If CInt(Session("gYear")) <= 15 Then Session("gYear") = "16"
				objControlRight1.Session.Add("gYear", Session("gYear"))             ' 6/2014 added...
                PlaceHolderRightPane.Controls.Add(objControlRight1)
            End If
            Exit Sub
        End If

        Session("sel") = Request.QueryString("sel")

        ' Added 8/18/2014...
        Session("email") = Request.QueryString("email")

        ' Load content of LEFT PANE...
        Dim objControl1 As New UserControl
        objControl1 = CType(LoadControl("ucSportsListRankings.ascx"), UserControl)
        PlaceHolderRankings.Controls.Add(objControl1)

        'Dim objControl1_14 As New UserControl
        'objControl1_14 = CType(LoadControl("ucSportsListRankings14.ascx"), UserControl)
        'PlaceHolderRankings14.Controls.Add(objControl1_14)

        '''''Dim objControl2a As New UserControl
        '''''objControl2a = CType(LoadControl("ucSportsListSchedulesPlayoffs.ascx"), UserControl)
        '''''PlaceHolderSchedulesPlayoffs.Controls.Add(objControl2a)

        Dim objControl2 As New UserControl
        objControl2 = CType(LoadControl("ucSportsListSchedulesClass.ascx"), UserControl)
        PlaceHolderSchedulesClass.Controls.Add(objControl2)

        Dim objControl2_14 As New UserControl
        objControl2_14 = CType(LoadControl("ucSportsListSchedulesClass14.ascx"), UserControl)
        PlaceHolderSchedulesClass14.Controls.Add(objControl2_14)

        Dim objControl2_15 As New UserControl
        objControl2_15 = CType(LoadControl("ucSportsListSchedulesClass15.ascx"), UserControl)
        PlaceHolderSchedulesClass15.Controls.Add(objControl2_15)

        Dim objControl2_16 As New UserControl
        objControl2_16 = CType(LoadControl("ucSportsListSchedulesClass16.ascx"), UserControl)
        PlaceHolderSchedulesClass16.Controls.Add(objControl2_16)

        Dim objControl2_17 As New UserControl
        objControl2_17 = CType(LoadControl("ucSportsListSchedulesClass17.ascx"), UserControl)
        PlaceHolderSchedulesClass17.Controls.Add(objControl2_17)

        Dim objControl2_18 As New UserControl
        objControl2_18 = CType(LoadControl("ucSportsListSchedulesClass18.ascx"), UserControl)
        PlaceHolderSchedulesClass18.Controls.Add(objControl2_18)

        ' CDW added 6/2019...
        Dim objControl2_19 As New UserControl
        objControl2_19 = CType(LoadControl("ucSportsListSchedulesClass19.ascx"), UserControl)
        PlaceHolderSchedulesClass19.Controls.Add(objControl2_19)

        Dim objControl3 As New UserControl
        objControl3 = CType(LoadControl("ucSportsListSchedules.ascx"), UserControl)
        PlaceHolderSchedules.Controls.Add(objControl3)

        Dim objControl4 As New UserControl
        objControl4 = CType(LoadControl("ucSportsListDistricts.ascx"), UserControl)
        PlaceHolderDistrictStandings.Controls.Add(objControl4)

        Dim objControl5 As New UserControl
        objControl5 = CType(LoadControl("ucSportsListSchools.ascx"), UserControl)
        PlaceHolderSchools.Controls.Add(objControl5)


        ' Load the content of the RIGHT PANE...
        Dim objControlRight As UserControl
        Dim objControlHeader As UserControl
        Dim objControlHeader1 As UserControl
        Dim objControlOther As UserControl

        Dim strControlName As String = ""
        Select Case Session("sel")
            ' =================================================== 0
            Case "rankings"
                Session("gGender") = Request.QueryString("g")
                Session("gSport") = Request.QueryString("sp")
                Session("gSportGenderKey") = Request.QueryString("spGK")

                If Request.QueryString("y") Is Nothing Then
                    Session("gYear") = clsFunctions.GetCurrentYear
                ElseIf Request.QueryString("y") = "0" Then
                    Session("gYear") = clsFunctions.GetCurrentYear
                Else
                    Session("gYear") = Request.QueryString("y")
                End If

                If Session("gYear") = clsFunctions.GetCurrentYear Then
                    If Session("gGender") = "5" Or Session("gGender") = "5d" Then
                        strControlName = "ucViewRankingAll5.ascx"
                    ElseIf Session("gGender") = "5d8" Then
                        strControlName = "ucViewRankingAll58.ascx"
                    Else
                        strControlName = "ucViewRankingAll.ascx"
                    End If
                    LeftAccordion.SelectedIndex = MenuIndexRankings
                    'ElseIf Session("gYear") = clsFunctions.GetCurrentYear - 1 Then
                    '    strControlName = "ucViewRankingAll.ascx"
                    '    LeftAccordion.SelectedIndex = MenuIndexRankings14
                Else
                    If Session("gGender") = "5" Or Session("gGender") = "5d" Then
                        strControlName = "ucViewRankingAll5.ascx"
                    ElseIf Session("gGender") = "5d8" Then
                        strControlName = "ucViewRankingAll58.ascx"
                    Else
                        strControlName = "ucViewRankingAll.ascx"
                    End If
                    LeftAccordion.SelectedIndex = MenuIndexRankings
                End If

            ' =================================================== 1
            Case "schedulesPlayoffs"
                Select Case Request.QueryString("spgk")
                    Case "FPSoftballD"
                        strControlName = "ucViewScheduleFPDistricts.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FPSoftballR"
                        strControlName = "ucViewScheduleFPRegionals.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FPSoftballS"
                        strControlName = "ucViewScheduleFPState.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "BaseballFallD"
                        strControlName = "ucViewScheduleFBBDistricts.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "BaseballFallR"
                        strControlName = "ucViewScheduleFBBRegionals.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "BaseballFallS"
                        strControlName = "ucViewScheduleFBBState.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FootballWeek1"
                        strControlName = "ucViewScheduleFBWeek1.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FootballWeek2"
                        strControlName = "ucViewScheduleFBWeek2.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FootballWeek3"
                        strControlName = "ucViewScheduleFBWeek3.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "FootballWeek4"
                        strControlName = "ucViewScheduleFBWeek4.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case "VolleyballS"
                        strControlName = "ucViewScheduleVBState.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexSchedulesPlayoffs
                    Case Else
                End Select

            Case "tss"
                If Session("gYear") = clsFunctions.GetCurrentYear Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                ElseIf Session("gYear") = 16 Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass16
                ElseIf Session("gYear") = 15 Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass15
                ElseIf Session("gYear") = 14 Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass14
                Else
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                End If

            Case "schedulesClass", "schedulesClass14", "schedulesClass15", "schedulesClass16", "schedulesClass17"
                Session("gSportGenderKey") = Request.QueryString("spGK")
                Session("gSportDisplay") = clsSports.GetGenderSportFromSGK(Session("gSportGenderKey"))
                If Request.QueryString("y") Is Nothing Then
                    Session("gYear") = clsFunctions.GetCurrentYear
                ElseIf Request.QueryString("y") = "0" Then
                    Session("gYear") = clsFunctions.GetCurrentYear
                Else
                    Session("gYear") = Request.QueryString("y")
                End If
                If Request.QueryString("keep") = 1 Then
                    ' This was sent from a Close Schedule...
                Else
                    Session("gScoreboardClass") = ""
                End If

                If Session("gYear") = clsFunctions.GetCurrentYear Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                ElseIf Session("gYear") = 16 Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass16
                ElseIf Session("gYear") = 15 Then
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass15
					'''''ElseIf Session("gYear") = 14 Then
					'''''    strControlName = "ucViewScheduleClass.ascx"
					'''''    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass14
				Else
                    strControlName = "ucViewScheduleClass.ascx"
                    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                End If

            Case "ScheduleTeam"
                Session("gTeamID") = Request.QueryString("t")
                strControlName = "ucViewTeamSchedule.ascx"
                LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass

                'If Session("gYear") = clsFunctions.GetCurrentYear Then
                '    strControlName = "ucViewScheduleClass.ascx"
                '    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                'ElseIf Session("gYear") = 15 Then
                '    strControlName = "ucViewScheduleClass.ascx"
                '    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass15
                'ElseIf Session("gYear") = 14 Then
                '    strControlName = "ucViewScheduleClass.ascx"
                '    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass14
                'Else
                '    strControlName = "ucViewScheduleClass.ascx"
                '    LeftAccordion.SelectedIndex = MenuIndexSchedulesByClass
                'End If
                objControlHeader = CType(LoadControl("ucViewTeamHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)

            Case "schedules"
                Session("gSportGenderKey") = Request.QueryString("spGK")
                Session("gSportDisplay") = clsSports.GetGenderSportFromSGK(Session("gSportGenderKey"))
                Session("email") = Request.QueryString("email")         ' 8/18/2014 added...
                ' 9/28/2015 added...
                If Request.QueryString("no") = 1 Then
                    Session("no") = 1
                Else
                    Session("no") = 0
                End If
                strControlName = "ucViewSchedule.ascx"
                LeftAccordion.SelectedIndex = MenuIndexSchedulesByDate

            Case "schools"
            Case "teamschedule"
                Session("gTeamID") = Request.QueryString("t")
                Session("gSportGenderKey") = Request.QueryString("spGK")
                Session("gSportID") = clsTeams.GetSportIDForTeam(Session("gTeamID"))
                strControlName = "ucViewTeamSchedule.ascx"
                LeftAccordion.SelectedIndex = MenuIndexSchedulesByDate
                objControlHeader = CType(LoadControl("ucViewTeamHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)

            ' =================================================== 4
            Case "districts"
                Select Case Request.QueryString("spgk")
                    Case "Baseball"
                        strControlName = "ucDistrictStandingsBaseball.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case "Football"
                        strControlName = "ucDistrictStandingsFootball.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case "SoccerBoys"
                        strControlName = "ucDistrictStandingsSoccerBoys.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case "SoccerGirls"
                        strControlName = "ucDistrictStandingsSoccerGirls.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case "FPSoftball"
                        'If Request.QueryString("live") = 1 Then
                        strControlName = "ucDistrictStandingsFastPitchLive.ascx"
                        'Else
                        'strControlName = "ucDistrictStandingsFastPitch.ascx"
                        'End If
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case "WrestlingDual"
                        strControlName = "ucDistrictStandingsWrestlingDual.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                    Case Else
                        strControlName = "ucDistrictStandingsNA.ascx"
                        LeftAccordion.SelectedIndex = MenuIndexDistrictStandings
                End Select
            ' =================================================== 5
            Case "ssch"         ' School Schedule...
                Session("gSchoolID") = Request.QueryString("sc")
                Session("gTeamID") = Request.QueryString("t")
                Session("gSportID") = clsTeams.GetSportIDForTeam(Session("gTeamID"))
                LeftAccordion.SelectedIndex = MenuIndexSchools
                objControlHeader = CType(LoadControl("ucViewSchoolHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)
                objControlOther = CType(LoadControl("ucViewSchoolMenu.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlOther)
                If Session("gTeamID") Is Nothing Then
                    strControlName = ""
                Else
                    strControlName = "ucViewTeamSchedule.ascx"
                    objControlHeader1 = CType(LoadControl("ucViewTeamHeader.ascx"), UserControl)
                    PlaceHolderRightPane.Controls.Add(objControlHeader1)
                End If

            Case "sros"
                Session("gSchoolID") = Request.QueryString("sc")
                Session("gTeamID") = Request.QueryString("t")
                LeftAccordion.SelectedIndex = MenuIndexSchools
                objControlHeader = CType(LoadControl("ucViewSchoolHeader.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlHeader)
                objControlOther = CType(LoadControl("ucViewSchoolMenu.ascx"), UserControl)
                PlaceHolderRightPane.Controls.Add(objControlOther)
                If Session("gTeamID") Is Nothing Then
                    strControlName = ""
                Else
                    strControlName = "ucViewTeamRoster.ascx"
                    objControlHeader1 = CType(LoadControl("ucViewTeamHeader.ascx"), UserControl)
                    PlaceHolderRightPane.Controls.Add(objControlHeader1)
                End If
            Case Else
                Session("gGender") = Request.QueryString("g")
                Session("gSport") = Request.QueryString("sp")
                Session("gSportGenderKey") = Request.QueryString("spGK")
                strControlName = "ucViewHomePageTest.ascx"
                LeftAccordion.SelectedIndex = MenuIndexRankings
        End Select

        If strControlName = "" Then
        Else
            objControlRight = CType(LoadControl(strControlName), UserControl)
            objControlRight.Session.Add("gGender", Session("gGender"))
            objControlRight.Session.Add("gSport", Session("gSport"))
            objControlRight.Session.Add("sel", Session("sel"))
            objControlRight.Session.Add("gSportGenderKey", Session("gSportGenderKey"))
            objControlRight.Session.Add("gTeamID", Session("gTeamID"))
            PlaceHolderRightPane.Controls.Add(objControlRight)
        End If

    End Sub

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()>
    Public Shared Function GetDynamicContent(ByVal contextKey As String) As String
        ' Added 11/6/2013...
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim x As Integer

        strSQL = clsSchedules.GetScheduleTeamSQL(contextKey)
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        ds = clsSchedules.ChangeDatasetSchedule(ds, True, 0, False, False)

        Dim b As New StringBuilder()

        b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ")
        b.Append("width:650px; font-size:8pt; font-family:Verdana;' cellspacing='0' cellpadding='4'>")
        b.Append("<tr><td colspan='4' style='background-color:Maroon; color:white;'>")
        b.Append("<b>View Schedule : " & clsTeams.GetSchoolNameFromTeamID(contextKey) & "</b>")
        b.Append("</td></tr>")
        b.Append("<tr><td style='width:150px;'><b>Date</b></td>")
        b.Append("<td style='width:200px;'><b>Opponent</b></td>")
        b.Append("<td style='width:120px;'><b>Results</b></td>")
        ' Added GetTop20Record 8/24/2015...
        b.Append("<td rowspan='100' style='width:200px;vertical-align:top;'><b>RECORDS</b><br>" & clsTeams.GetTop20Record(contextKey, 20, clsFunctions.GetCurrentYear) & "</td>")
        b.Append("</tr>")

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                b.Append("<tr>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Date").ToString() & "</td>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Opposing Team").ToString() & "</td>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Results").ToString() & "</td>")
                b.Append("</tr>")
            Next
        End If

        b.Append("</table>")
        Return b.ToString()

    End Function

End Class