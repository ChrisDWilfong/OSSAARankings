Imports System.Data
Imports SqlHelper

Partial Class ucViewRanking

    Inherits System.Web.UI.UserControl
    Dim gCurrentYear As Integer = 8

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        Dim sql2 As String
        Dim weekID As Integer
        Dim sportID As Integer
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim x As Integer
        Dim rankGender As String
        Dim rankSport As String
        Dim strCaption As String
        Dim intNumberOfRankings As Integer
        Dim strSport As String
        Dim strClass As String

        Try
            weekID = Request.QueryString("w")
        Catch ex As Exception
            weekID = 0
        End Try
        weekID = 107          ' TODO : Added 12/2012...
        sportID = Request.QueryString("sID")
        rankGender = Request.QueryString("g")
        rankSport = Request.QueryString("s")

        ' TODO...
        weekID = 233          ' TODO : Added 12/2012...
        sportID = 12
        rankGender = "Girls"
        rankSport = "Basketball"

        ' Default Gender / Sport...
        If sportID = 0 Then
            sportID = Session("gSportID")
        End If
        If rankGender = "" Then
            If Session("gGender") = "" Then
                rankGender = ConfigurationManager.AppSettings.Item("DefaultRankingGender")
            Else
                rankGender = Session("gGender")
            End If
        End If
        If rankSport = "" Then
            If Session("gSport") = "" Then
                rankSport = ConfigurationManager.AppSettings.Item("DefaultRankingSport")
            Else
                rankSport = Session("gSport")
            End If
        End If

            ' Scroll through weeks...
            SQL = "SELECT Class, Gender, Sport, tblsports.sportID, preseason, showstartdate, tblrankingsweeks.showenddate, tblrankingsweeks.showstartdate, tblrankingsweeks.weekNo, tblRankingsWeeks.Static, "
            SQL = SQL & "tblRankingsWeeks.showWL, tblRankingsWeeks.showPoints, tblSports.NumberOfRankingsShow, tblSports.Sport, tblSports.Gender "
            SQL = SQL & "FROM tblSports INNER JOIN tblRankingsWeeks ON tblSports.sportID = tblRankingsWeeks.sportID "
            If weekID > 0 Then
                SQL = SQL & "WHERE tblrankingsweeks.wID = '" & weekID & "'"
            Else
                SQL = SQL & "WHERE ((tblrankingsweeks.ShowStartDate < '" & Now & "' AND tblrankingsweeks.ShowEndDate > '" & Now & "' AND tblRankingsWeeks.Static = 0) OR (tblRankingsWeeks.Static = 1)) "
            End If
            If sportID > 0 Then
                SQL = SQL & " AND (tblSports.sportID = " & sportID & ")"
            Else
                SQL = SQL & " AND (Gender = '" & rankGender & "') AND (Sport = '" & rankSport & "')"
            End If
            SQL = SQL & " AND (tblRankingsWeeks.intYear = " & gCurrentYear & ")"
            SQL = SQL & " ORDER BY Sort"

        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, SQL)

            ' Sport Header...
            Try
                If ds1.Tables(0).Rows(0).Item("Gender") = "" Then
                    strSport = ds1.Tables(0).Rows(0).Item("Sport")
                Else
                    strSport = ds1.Tables(0).Rows(0).Item("Gender") & " " & ds1.Tables(0).Rows(0).Item("Sport")
                End If
            Catch
                strSport = ""
            End Try
            Me.lblSport.Text = strSport

            For x = 0 To ds1.Tables(0).Rows.Count - 1
                intNumberOfRankings = ds1.Tables(0).Rows(x).Item("NumberOfRankingsShow")
                ' Caption...
                strCaption = "<b>"
                If ds1.Tables(0).Rows(x).Item("gender") = "" Then
                    strCaption = strCaption & "Class " & ds1.Tables(0).Rows(x).Item("class") & " " & ds1.Tables(0).Rows(x).Item("sport")
                Else
                    strCaption = strCaption & "Class " & ds1.Tables(0).Rows(x).Item("class") & " " & ds1.Tables(0).Rows(x).Item("gender") & " " & ds1.Tables(0).Rows(x).Item("sport")
                End If
                If ds1.Tables(0).Rows(x).Item("Static") Then
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " Rankings"
                Else
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " Rankings as of " & FormatDateTime(ds1.Tables(0).Rows(x).Item("ShowStartDate"), DateFormat.ShortDate)
                End If
                strCaption = strCaption & "</b>"

                ' Data source...
            sql2 = "SELECT tblRankings.ID, tblRankings.Points AS Points, tblRankings.Rank AS Rank, tblRankings.schoolID, tblRankings.School, tblRankings.teamID, tblRankings.WL, tblTeams.WLOverride "
                sql2 = sql2 & "FROM tblRankings INNER JOIN tblTeams ON tblRankings.teamID = tblTeams.teamID INNER JOIN "
                sql2 = sql2 & "tblRankingsWeeks ON tblRankings.WeekID = tblRankingsWeeks.wID "
                sql2 = sql2 & "WHERE (tblTeams.sportID = " & ds1.Tables(0).Rows(x).Item("sportID") & ") AND (tblRankings.Rank <= " & intNumberOfRankings & ") AND "
                If weekID > 0 Then
                    sql2 = sql2 & "((tblrankingsweeks.wID = '" & weekID & "'"
                Else
                    sql2 = sql2 & "((tblrankingsweeks.ShowStartDate < '" & Now & "' AND tblrankingsweeks.ShowEndDate > '" & Now & "'"
                End If
                sql2 = sql2 & " AND tblRankingsWeeks.Static = 0) OR (tblRankingsWeeks.Static = 1)) "
                sql2 = sql2 & " ORDER BY Points DESC "

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sql2)

                Select Case x
                    Case 0
                        If ds Is Nothing Then
                            Me.GridView1.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView1.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView1.Visible = False
                        Else
                            Me.GridView1.DataSource = ds
                            Me.GridView1.Caption = strCaption
                            Me.GridView1.DataBind()
                        End If

                    Case 1
                        If ds Is Nothing Then
                            Me.GridView2.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView2.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView2.Visible = False
                        Else
                            Me.GridView2.DataSource = ds
                            Me.GridView2.Caption = strCaption
                            Me.GridView2.DataBind()
                        End If

                    Case 2
                        If ds Is Nothing Then
                            Me.GridView3.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView3.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView3.Visible = False
                        Else
                            Me.GridView3.DataSource = ds
                            Me.GridView3.Caption = strCaption
                            Me.GridView3.DataBind()
                        End If

                    Case 3
                        If ds Is Nothing Then
                            Me.GridView4.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView4.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView4.Visible = False
                        Else
                            Me.GridView4.DataSource = ds
                            Me.GridView4.Caption = strCaption
                            Me.GridView4.DataBind()
                        End If

                    Case 4
                        If ds Is Nothing Then
                            Me.GridView5.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView5.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView5.Visible = False
                        Else
                            Me.GridView5.DataSource = ds
                            Me.GridView5.Caption = strCaption
                            Me.GridView5.DataBind()
                        End If

                    Case 5
                        If ds Is Nothing Then
                            Me.GridView6.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView6.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView6.Visible = False
                        Else
                            Me.GridView6.DataSource = ds
                            Me.GridView6.Caption = strCaption
                            Me.GridView6.DataBind()
                        End If

                    Case 6
                        If ds Is Nothing Then
                            Me.GridView7.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView7.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView7.Visible = False
                        Else
                            Me.GridView7.DataSource = ds
                            Me.GridView7.Caption = strCaption
                            Me.GridView7.DataBind()
                        End If

                    Case 7
                        If ds Is Nothing Then
                            Me.GridView8.Visible = False
                        ElseIf ds.Tables.Count = 0 Then
                            Me.GridView8.Visible = False
                        ElseIf ds.Tables(0).Rows.Count = 0 Then
                            Me.GridView8.Visible = False
                        Else
                            Me.GridView8.DataSource = ds
                            Me.GridView8.Caption = strCaption
                            Me.GridView8.DataBind()
                        End If
                End Select

            Next

    End Sub

End Class
