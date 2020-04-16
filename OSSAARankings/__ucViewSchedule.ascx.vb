Imports System.Data

Partial Class ucViewSchedule

    Inherits System.Web.UI.UserControl

    Shared cboClassList As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("gScoreboardDate") Is Nothing Then
                WebDatePicker1.Value = clsFunctions.GetTodaysDate
                Session("gScoreboardDate") = WebDatePicker1.Value
            Else
                WebDatePicker1.Value = Session("gScoreboardDate")
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
                    Try
                        cboClass.SelectedValue = Session("gScoreboardClass")
                    Catch
                    End Try
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
        Dim gClass As String
        Dim dsRegular As DataSet

        'gClass = cboClass.SelectedValue
        gClass = strClass
        If gClass = "ALL" Then
            sportGenderKey = Session("gSportGenderKey")
        Else
            sportGenderKey = Session("gSportGenderKey") & gClass
        End If
        gDate = Session("gScoreboardDate")
        sqlDate = DatePart("yyyy", gDate) & "-" & DatePart("m", gDate) & "-" & DatePart("d", gDate) & " 00:00:00"

        sqlAll = clsSchedules.GetScheduleSportDaySQL(sportGenderKey, gClass, sqlDate, "")
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

        Dim x As Integer

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                Try
                    gStatus = .Item("gStatus")
                Catch ex As Exception
                    gStatus = ""
                End Try
                ' Get Score...
                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                    ' Team...
                    strTeam = "<a href='?sel=teamschedule&t=" & .Item("teamID") & "&op=t&p=1' target='_self'>" & clsFunctions.ParseSchool(.Item("school")) & "</a>" & " (" & .Item("class")
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

                ElseIf .Item("TotalScore") > .Item("oTotalScore") Then
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

                Else
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

                    .Item("strSort") = .Item("school")
                    If Session("gSportDisplay") = "Wrestling" And .Item("strType") = "TOURNEY" And (.Item("oTotalScore") = 0) Then              ' Added 12/1/2014...
                        strScore = "<strong>Place : " & .Item("TotalScore") & "</strong>"
                    ElseIf .Item("results") Is System.DBNull.Value Then
                        strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>"
                    Else
                        strScore = "<strong>" & .Item("TotalScore") & "-" & .Item("oTotalScore") & "</strong>&nbsp;<span style='font-size:8pt'>" & .Item("results") & "</span>"
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

                .Item("Game") = strTeam & strAt & stroTeam & strScore & strTournament & strDistrict & strEmail

                strTeam = ""
                stroTeam = ""
                strAt = ""
                strScore = ""
            End With
        Next

        ' ORDER BY the dataset...
        Dim dsView As New DataView
        dsView = ds.Tables(0).DefaultView
        dsView.Sort = "strSort ASC"

        Return dsView

    End Function

    Private Sub cboClass_DataBound(sender As Object, e As System.EventArgs) Handles cboClass.DataBound
        cboClass.Items.Insert(0, "ALL")
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        Session("gScoreboardDate") = WebDatePicker1.Value
        'Session("gScoreboardDate") = WebDatePicker1.Date
        If rowHeader.Visible Then
            Session("gScoreboardClass") = cboClass.SelectedValue
        End If
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    'Private Sub WebDatePicker1_ValueChanged(sender As Object, e As Infragistics.WebUI.WebSchedule.WebDateChooser.WebDateChooserEventArgs) Handles WebDatePicker1.ValueChanged
    '    Session("gScoreboardDate") = WebDatePicker1.Value
    '    Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
    '    RefreshHeader()
    'End Sub

    Public Sub RefreshHeader()

        Dim strSport As String = ""
        '''''strSport = clsFunctions.GetDisplaySport(Session("gSportGenderKey")) & " Schedule<br>for " & Session("gScoreboardDate")
        strSport = Session("gSportDisplay") & " Schedule<br>for " & Session("gScoreboardDate")
        If Session("gScoreboardClass") = "" Or Session("gScoreboardClass") = "ALL" Then
            strSport = strSport & " ALL Classes"
        Else
            strSport = strSport & " Class " & Session("gScoreboardClass")
        End If
        lblSport.Text = strSport
    End Sub

    Private Sub WebDatePicker1_TextChanged(sender As Object, e As System.EventArgs) Handles WebDatePicker1.TextChanged
        Session("gScoreboardDate") = WebDatePicker1.Value
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As System.EventArgs) Handles cmdNext.Click
        ' Added 9/9/2014...
        Dim dtmDate As Date
        dtmDate = WebDatePicker1.Date
        dtmDate = dtmDate.AddDays(1)
        WebDatePicker1.Date = dtmDate
        Session("gScoreboardDate") = WebDatePicker1.Value
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Private Sub cmdPrev_Click(sender As Object, e As System.EventArgs) Handles cmdPrev.Click
        ' Added 9/9/2014...
        Dim dtmDate As Date
        dtmDate = WebDatePicker1.Date
        dtmDate = dtmDate.AddDays(-1)
        WebDatePicker1.Date = dtmDate
        Session("gScoreboardDate") = WebDatePicker1.Value
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub
End Class
