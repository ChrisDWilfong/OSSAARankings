Imports System.Data

Partial Class ucViewSchedule

    Inherits System.Web.UI.UserControl

    Shared cboClassList As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        If Request.UserHostAddress.ToString = "72.198.125.78" Then
            clsLog.LogSQL("", Request.UserHostAddress.ToString, "View Schedule")
            'Response.Redirect("http://www.ossaarankings.com/Default.aspx")        ' Greg Goodrich...
        End If

        If Not IsPostBack Then
            If Session("gScoreboardDate") Is Nothing Then
                RadDatePicker1.SelectedDate = Replace(clsFunctions.GetTodaysDate, " 12:00:00 AM", "")
                Session("gScoreboardDate") = RadDatePicker1.SelectedDate
            Else
                RadDatePicker1.SelectedDate = Session("gScoreboardDate")
            End If
            Session("scoreboardscroller") = InitializeDataSet(Session("gScoreboardClass"))
            ' Turn off the dropdowns for the Print version...
            If Session("printOnly") = 1 Then
                Me.rowHeader.Visible = False
                Me.hlPrint.Visible = False
            Else
                hlPrint.Visible = True
            End If
            Session("printOnly") = 0
        End If

        If rowHeader.Visible Then
            If cboClass.SelectedValue = "" Then
                If Session("gScoreboardClass") = "" Then
                Else
                    cboClass.SelectedValue = Session("gScoreboardClass")
                End If
            Else
                Session("gScoreboardClass") = cboClass.SelectedValue
            End If
        End If

        RefreshHeader()

    End Sub

    Public Function InitializeDataSet(strClass As String) As String
        Dim gDate As DateTime
        Dim sqlDate As String
        Dim sportGenderKey As String
        Dim sqlAll As String
        Dim gClass As String = "ALL"
        Dim dsRegular As DataSet

        'gClass = cboClass.SelectedValue
        If strClass Is Nothing Then
            strClass = "ALL"
        Else
            gClass = strClass
        End If
        If gClass = "ALL" Then
            sportGenderKey = Session("gSportGenderKey")
        Else
            sportGenderKey = Session("gSportGenderKey") & gClass
        End If
        gDate = Session("gScoreboardDate")
        sqlDate = DatePart("yyyy", gDate) & "-" & DatePart("m", gDate) & "-" & DatePart("d", gDate) & " 00:00:00"

        sqlAll = clsSchedules.GetScheduleSportDaySQL(sportGenderKey, gClass, sqlDate, "", Session("no"))
        dsRegular = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sqlAll)

        If dsRegular Is Nothing Then
        ElseIf dsRegular.Tables.Count = 0 Then
        ElseIf dsRegular.Tables(0).Rows.Count = 0 Then
        End If

        Dim dsView As New DataView
        dsView = FigureGamesNew(dsRegular)

        GridView1.DataSource = dsView
        GridView1.DataBind()

        Return Session("gSportDisplay") & " Scores"

    End Function

    Private Function FigureGamesNew(ByVal ds As DataSet) As DataView
        Dim strScore As String = ""
        Dim strTeam As String = ""
        Dim stroTeam As String = ""
        Dim strRank As String = ""
        Dim strAt As String = ""
        Dim strGame As String = ""
        Dim strTournament As String = ""
        Dim strDistrict As String = ""
        Dim gStatus As String = ""
        Dim strLink As String = ""

        Dim x As Integer

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                Try
                    gStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), .Item("sportID"))
                Catch ex As Exception
                    gStatus = ""
                End Try
                ' Get Score...
                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then            ' GAME HAS NOT BEEN PLAYED...
                    ' Team...
                    strTeam = "<a href='?sel=teamschedule&t=" & .Item("teamID") & "&op=t&p=1' target='_self' ID='hlTeamID'>" & clsFunctions.ParseSchool(.Item("school")) & "</a>" & " (" & .Item("class")
                    If .Item("rank") > 0 And .Item("rank") <= 20 Then strTeam = strTeam & "-#" & .Item("rank")
                    strTeam = strTeam & ")"
                    ' oTeam...
                    If .Item("oclass") Is System.DBNull.Value Then
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = .Item("OtherTeam") & " "
                        Else
                            stroTeam = "<a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a> "
                        End If
                    Else
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = .Item("OtherTeam") & " "
                        Else
                            stroTeam = "<a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a>" & " (" & .Item("oclass")
                        End If
                    End If
                    If .Item("orank") > 0 And .Item("orank") <= 20 Then stroTeam = stroTeam & "-#" & .Item("orank")
                    If Not .Item("oclass") Is System.DBNull.Value Then
                        stroTeam = stroTeam & ") "
                    End If
                    .Item("strSort") = .Item("school")
                    strScore = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, True, .Item("gameTime"), "")

                ElseIf .Item("TotalScore") > .Item("oTotalScore") Then              ' GAME IS OVER...
                    ' Team...
                    strTeam = "<strong>" & "<a href='?sel=teamschedule&t=" & .Item("teamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(.Item("school")) & "</a>" & " (" & .Item("class")
                    If .Item("rank") > 0 And .Item("rank") <= 20 Then strTeam = strTeam & "-#" & .Item("rank")
                    strTeam = strTeam & ") </strong>"
                    ' oTeam...
                    If .Item("oclass") Is System.DBNull.Value Then
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = .Item("OtherTeam") & " "
                        Else
                            stroTeam = "<a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a> "
                        End If
                    Else
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = .Item("OtherTeam") & " "
                        Else
                            stroTeam = "<a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a>" & " (" & .Item("oclass")
                        End If
                    End If
                    If .Item("orank") > 0 And .Item("orank") <= 20 Then stroTeam = stroTeam & "-#" & .Item("orank")
                    If Not .Item("oclass") Is System.DBNull.Value Then
                        stroTeam = stroTeam & ") "
                    End If

                    .Item("strSort") = .Item("school")
                    If Session("gSportDisplay") = "Wrestling" And .Item("strType") = "TOURNEY" And (.Item("oTotalScore") = 0) Then              ' Added 12/1/2014...
                        strScore = "<strong>Place : " & .Item("TotalScore") & "</strong>"
                    ElseIf .Item("results") Is System.DBNull.Value Then
                        strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>"
                    Else
                        strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>&nbsp;<span style='font-size:8pt'>" & .Item("results") & "</span>"
                    End If

                    ' Added 11/21/2017...
                    If gStatus.Contains("OT") Then
                        strScore = strScore & " (OT)"
                    End If

                Else            ' GAME IS OVER...
                    ' Team...
                    strTeam = "<a href='?sel=teamschedule&t=" & .Item("teamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(.Item("school")) & "</a>" & " (" & .Item("class")
                    If .Item("rank") > 0 And .Item("rank") <= 20 Then strTeam = strTeam & "-#" & .Item("rank")
                    strTeam = strTeam & ") "
                    ' oTeam...
                    If .Item("oclass") Is System.DBNull.Value Then
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = "<strong>" & .Item("OtherTeam") & " </a> "
                        Else
                            stroTeam = "<strong><a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a> "
                        End If
                    Else
                        If .Item("oschool") Is System.DBNull.Value Then
                            stroTeam = "<strong>" & .Item("OtherTeam") & " </a> "
                        Else
                            stroTeam = "<strong><a href='?sel=teamschedule&t=" & .Item("oteamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(IIf(.Item("oschool") Is System.DBNull.Value, .Item("OtherTeam"), .Item("oschool"))) & "</a>" & " (" & .Item("oclass")
                        End If
                    End If

                    If .Item("orank") > 0 And .Item("orank") <= 20 Then stroTeam = stroTeam & "-#" & .Item("orank")
                    If Not .Item("oclass") Is System.DBNull.Value Then
                        stroTeam = stroTeam & ") </strong>"
                    End If

                    ' Added 11/21/2017...
                    If gStatus.Contains("OT") Then
                        strScore = strScore & " (OT)"
                    End If

                    .Item("strSort") = .Item("school")
                    If Session("gSportDisplay") = "Wrestling" And .Item("strType") = "TOURNEY" And (.Item("oTotalScore") = 0) Then              ' Added 12/1/2014...
                        strScore = "<strong>Place : " & .Item("TotalScore") & "</strong>"
                    ElseIf .Item("results") Is System.DBNull.Value Then
                        If gStatus.Contains("OT") Then
                            strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & " - OT" & "</strong>"
                        Else
                            strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>"
                        End If

                    Else
                        If gStatus.Contains("OT") Then
                            strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>&nbsp;<span style='font-size:8pt'>" & .Item("results") & " - OT</span>"
                        Else
                            strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>&nbsp;<span style='font-size:8pt'>" & .Item("results") & "</span>"
                        End If
                    End If

                    End If

                If .Item("Location") Is System.DBNull.Value Then
                    strAt = strAt & " @ "
                ElseIf .Item("Location") = "Away" Then
                    strAt = strAt & " @ "
                Else
                    strAt = strAt & " vs "
                End If

                ' Tournament Info???
                strTournament = ""
                If .Item("strType").ToString.Contains("TOSSAA") Then
                    strTournament = clsSchedules.GetOSSAATourneyType(.Item("strType"), .Item("intGame"), .Item("NeutralSiteCoor"))
                ElseIf Not .Item("Tournament") Is System.DBNull.Value And .Item("Tournament") <> "" Then
                    strTournament = " - " & .Item("Tournament")
                End If

                ' District Game???
                If Not .Item("strType") Is System.DBNull.Value Then
                    If .Item("strType") = "DIST" Then
                        strDistrict = " **"
                    Else
                        strDistrict = ""
                    End If
                Else
                    strDistrict = ""
                End If

                Dim strEmail As String = ""
                If Session("email") = "ossaa" Or Request.QueryString("email") = "ossaa" Then
                    strEmail = "  (" & .Item("strEmail") & ")"
                Else
                    strEmail = ""
                End If

                If .Item("strLink") Is System.DBNull.Value Then
                    strLink = ""
                Else
                    strLink = " " & .Item("strLink")
                End If

                .Item("Game") = strTeam & strAt & stroTeam & strScore & strTournament & strDistrict & strEmail & strLink

                strTeam = ""
                stroTeam = ""
                strAt = ""
                strScore = ""
            End With
        Next

        ' ORDER BY the dataset...
        Dim dsView As New DataView
        dsView = ds.Tables(0).DefaultView
        '''''dsView.Sort = "strSort ASC"          ' 12/1/2016 removed...

        Return dsView

    End Function

    Private Sub cboClass_DataBound(sender As Object, e As System.EventArgs) Handles cboClass.DataBound
        cboClass.Items.Insert(0, "ALL")
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        Session("gScoreboardDate") = RadDatePicker1.SelectedDate
        If rowHeader.Visible Then
            Session("gScoreboardClass") = cboClass.SelectedValue
        End If
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Public Sub RefreshHeader()
        Dim strSport As String = ""
        strSport = Session("gSportDisplay") & " Schedule<br>for " & Session("gScoreboardDate")
        If Session("gScoreboardClass") = "" Or Session("gScoreboardClass") = "ALL" Then
            strSport = strSport & " ALL Classes"
        Else
            strSport = strSport & " Class " & Session("gScoreboardClass")
        End If
        lblSport.Text = strSport
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As System.EventArgs) Handles cmdNext.Click
        ' Added 9/9/2014...
        Dim dtmDate As Date
        dtmDate = RadDatePicker1.SelectedDate
        dtmDate = dtmDate.AddDays(1)
        RadDatePicker1.SelectedDate = dtmDate.ToString.Replace(" 12:00:00 AM", "")
        Session("gScoreboardDate") = RadDatePicker1.SelectedDate
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Private Sub cmdPrev_Click(sender As Object, e As System.EventArgs) Handles cmdPrev.Click
        ' Added 9/9/2014...
        Dim dtmDate As Date
        dtmDate = RadDatePicker1.SelectedDate
        dtmDate = dtmDate.AddDays(-1)
        RadDatePicker1.SelectedDate = dtmDate.ToString.Replace(" 12:00:00 AM", "")
        Session("gScoreboardDate") = RadDatePicker1.SelectedDate
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Private Sub RadDatePicker1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePicker1.SelectedDateChanged
        Session("gScoreboardDate") = RadDatePicker1.SelectedDate
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub
End Class
