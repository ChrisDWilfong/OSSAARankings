Imports System.Data

Partial Class ucViewScheduleFBWeek2

    Inherits System.Web.UI.UserControl

    Shared cboClassList As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gSportDisplay") = "Football"
        Session("gSportGenderKey") = "Football"

        If Not IsPostBack Then
            Session("scoreboardscroller") = InitializeDataSet(Session("gScoreboardClass"))
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

    Public Function InitializeDataSet(ByVal strClass As String) As String
        Dim sportGenderKey As String
        Dim sqlAll As String
        Dim gClass As String
        Dim dsRegular As DataSet

        gClass = strClass
        If gClass = "ALL" Then
            sportGenderKey = Session("gSportGenderKey")
        Else
            sportGenderKey = Session("gSportGenderKey") & gClass
        End If

        sqlAll = clsSchedules.GetScheduleSportDaySQL(sportGenderKey, gClass, "", "WEEK2", 0)
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
                    strScore = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, True, .Item("gameTime"), .Item("gameDate"))

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
                    If .Item("results") Is System.DBNull.Value Then
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
                    If .Item("results") Is System.DBNull.Value Then
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
                strDistrict = ""

                .Item("Game") = strTeam & strAt & stroTeam & strScore & strTournament & strDistrict

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

    Private Sub cboClass_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClass.DataBound
        cboClass.Items.Insert(0, "ALL")
    End Sub

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        If rowHeader.Visible Then
            Session("gScoreboardClass") = cboClass.SelectedValue
        End If
        Session("scoreboardscroller") = InitializeDataSet(cboClass.SelectedValue)
        RefreshHeader()
    End Sub

    Public Sub RefreshHeader()

        Dim strSport As String = ""
        strSport = "Playoffs Week #2 " & Session("gSportDisplay") & " Schedule"
        If Session("gScoreboardClass") = "" Or Session("gScoreboardClass") = "ALL" Then
            strSport = strSport & " ALL Classes"
        Else
            strSport = strSport & " Class " & Session("gScoreboardClass")
        End If
        lblSport.Text = strSport
    End Sub

End Class
