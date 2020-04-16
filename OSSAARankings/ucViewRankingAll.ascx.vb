Imports System.Data
Imports AjaxControlToolkit

Partial Class ucViewRankingAll

    Inherits System.Web.UI.UserControl
    Dim gCurrentYear As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        Dim sql2 As String
        Dim sportID As String
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim x As Integer
        Dim rankGender As String
        Dim rankSport As String
        Dim sportGenderKey As String
        Dim strCaption As String
        Dim intNumberOfRankings As Integer
        Dim strSport As String
        Dim intYear As Integer = clsFunctions.GetCurrentYear
        Dim strYear As String

        If Request.UserHostAddress.ToString = "72.198.125.78" Then
            clsLog.LogSQL("", Request.UserHostAddress.ToString, "View Ranking")
            'Response.Redirect("http://www.ossaarankings.com/Default.aspx")        ' Greg Goodrich...
        End If

        ' Print Version???
        Try
            If Session("printOnly") = 1 Then
                hlPrint.Visible = False
            Else
                hlPrint.Visible = True
            End If
        Catch
            hlPrint.Visible = True
        End Try
        Session("printOnly") = 0

        Dim dtmCurrentDate As Date = Now
        gCurrentYear = clsFunctions.GetCurrentYear

        ' Added 9/9/2013...
        If Request.QueryString("admin") = 1 Or Request.QueryString("admin") = 2 Or Request.QueryString("admin") = 3 Then
            hlPrint.Visible = False
            If Request.QueryString("admin") = 2 Then
                dtmCurrentDate = DateAdd(DateInterval.Day, -7, dtmCurrentDate)
            Else
                dtmCurrentDate = DateAdd(DateInterval.Hour, 48, dtmCurrentDate)
            End If
            GridView1.Columns(4).Visible = True
            GridView1.Columns(5).Visible = True
            GridView2.Columns(4).Visible = True
            GridView2.Columns(5).Visible = True
            GridView3.Columns(4).Visible = True
            GridView3.Columns(5).Visible = True
            GridView4.Columns(4).Visible = True
            GridView4.Columns(5).Visible = True
            GridView5.Columns(4).Visible = True
            GridView5.Columns(5).Visible = True
            GridView6.Columns(4).Visible = True
            GridView6.Columns(5).Visible = True
            GridView7.Columns(4).Visible = True
            GridView7.Columns(5).Visible = True
            GridView8.Columns(4).Visible = True
            GridView8.Columns(5).Visible = True
        End If

        If Request.QueryString("sID") Is Nothing Then       ' Passed from Print Version...
            sportID = Session("gSportID")
            rankGender = Session("gGender")
            rankSport = Session("gSport")
            sportGenderKey = Session("gSportGenderKey")
            intYear = Session("gYear")
            'Me.hlPrint.Visible = False
        Else
            sportID = Request.QueryString("sID")
            rankGender = Request.QueryString("g")
            rankSport = Request.QueryString("s")
            sportGenderKey = Request.QueryString("spGK")
            intYear = Session("gYear")
            ' Get the Print Hyperlink...
            'Me.hlPrint.NavigateUrl = "PrintRankings.aspx?sel=tr"
        End If

        If Request.QueryString("admin") = 4 Then
            ' Get the Date for the week we are looking for... Added 11/24/2014...
            Dim currentDate As String
            Try
                currentDate = Request.QueryString("cdat")
                dtmCurrentDate = currentDate
            Catch ex As Exception
                currentDate = dtmCurrentDate
            End Try
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
        SQL = "SELECT tblSports.Class, tblSports.Gender, tblSports.Sport, tblSports.sportID, tblSports.GenderSport1, showstartdate, tblrankingsweeks.showenddate, tblrankingsweeks.showstartdate, tblrankingsweeks.weekNo, tblRankingsWeeks.Static, "
        SQL = SQL & "tblRankingsWeeks.showWL, tblRankingsWeeks.showPoints, tblRankingsWeeks.wID AS WeekID, tblSports.NumberOfRankingsShow, tblSports.Sport, tblSports.Gender "
        SQL = SQL & "FROM tblSports INNER JOIN tblRankingsWeeks ON tblSports.sportID = tblRankingsWeeks.sportID "

        If intYear = gCurrentYear Then
            SQL = SQL & "WHERE ((tblrankingsweeks.ShowStartDate <= '" & dtmCurrentDate & "' AND tblrankingsweeks.ShowEndDate >= '" & dtmCurrentDate & "')) "
            SQL = SQL & " AND (tblSports.SportGenderKey = '" & sportGenderKey & "')"
        Else
            SQL = SQL & "WHERE (tblSports.SportGenderKey = '" & sportGenderKey & "')"
        End If
        ' Changed 6/25/2014...

        ' NOTE : Current year rankings are dependent on intRankings flag.  Previous years ARE NOT....
        If intYear = gCurrentYear Then
            SQL = SQL & " AND (tblRankingsWeeks.intYear = " & gCurrentYear & ") AND tblSports.intRankings = 1"
        Else
            SQL = SQL & " AND (tblRankingsWeeks.intYear = " & intYear & " AND tblRankingsWeeks.Static = 1)"
        End If

        SQL = SQL & " ORDER BY Sort"

        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, SQL)

        If ds1 Is Nothing Then
            strSport = clsFunctions.GetDisplaySport(sportGenderKey) & " Rankings"
            Me.lblSport.Text = strSport
            Me.lblSportSubHeader.Visible = True
        ElseIf ds1.Tables.Count = 0 Then
            strSport = clsFunctions.GetDisplaySport(sportGenderKey) & " Rankings"
            Me.lblSport.Text = strSport
            Me.lblSportSubHeader.Visible = True
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
            strSport = clsFunctions.GetDisplaySport(sportGenderKey) & " Rankings"
            Me.lblSport.Text = strSport
            Me.lblSportSubHeader.Visible = True
        Else
            Me.lblSportSubHeader.Visible = False
            ' Sport Header...
            Try
                strSport = ds1.Tables(0).Rows(0).Item("GenderSport1") & " Rankings"
            Catch
                strSport = ""
            End Try
            Me.lblSport.Text = strSport

            For x = 0 To ds1.Tables(0).Rows.Count - 1
                If Request.QueryString("all") = 1 Then
                    intNumberOfRankings = 100
                Else
                    intNumberOfRankings = ds1.Tables(0).Rows(x).Item("NumberOfRankingsShow")
                End If

                ' Caption...
                strYear = clsFunctions.GetCurrentYearDisplay(ds1.Tables(0).Rows(x).Item("GenderSport1"), intYear)
                strCaption = ""
                strCaption = strCaption & strYear & " Class " & ds1.Tables(0).Rows(x).Item("class") & " " & ds1.Tables(0).Rows(x).Item("GenderSport1")
                If ds1.Tables(0).Rows(x).Item("Static") Then
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " OSSAARankings"
                Else
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " <br>OSSAARankings as of " & FormatDateTime(ds1.Tables(0).Rows(x).Item("ShowStartDate"), DateFormat.ShortDate)
                End If

                Select Case x
                    Case 0
                        Me.Label1.Text = strCaption
                    Case 1
                        Me.Label2.Text = strCaption
                    Case 2
                        Me.Label3.Text = strCaption
                    Case 3
                        Me.Label4.Text = strCaption
                    Case 4
                        Me.Label5.Text = strCaption
                    Case 5
                        Me.Label6.Text = strCaption
                    Case 6
                        Me.Label7.Text = strCaption
                    Case 7
                        Me.Label8.Text = strCaption
                End Select

                Dim sid As String = ds1.Tables(0).Rows(x).Item("sportID")

                ' Data source...
                If Request.QueryString("admin") = 3 Then
                    sql2 = "SELECT dbo.tblCoachesRanks.teamID AS Id, SUM(dbo.tblCoachesRanks.Points) AS Points, 0 AS Rank, 0 AS PrevWeek, 0 AS RankDiff, dbo.tblTeams.schoolID, dbo.tblTeams.SchoolName AS School, "
                    sql2 = sql2 & "dbo.tblTeams.teamID, dbo.tblTeams.WL "
                    sql2 = sql2 & "FROM dbo.tblCoachesRanks INNER JOIN "
                    sql2 = sql2 & "dbo.tblRankingsWeeks ON dbo.tblCoachesRanks.WeekID = dbo.tblRankingsWeeks.wID INNER JOIN "
                    sql2 = sql2 & "dbo.tblTeams ON dbo.tblCoachesRanks.teamID = dbo.tblTeams.teamID "
                    sql2 = sql2 & "WHERE (dbo.tblRankingsWeeks.sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') AND (dbo.tblRankingsWeeks.ShowStartDate <= '" & dtmCurrentDate & "') AND "
                    sql2 = sql2 & "(dbo.tblRankingsWeeks.ShowEndDate >= '" & dtmCurrentDate & "') AND (dbo.tblCoachesRanks.Rank <= " & intNumberOfRankings & ") "
                    sql2 = sql2 & "GROUP BY dbo.tblCoachesRanks.teamID, dbo.tblTeams.schoolID, dbo.tblTeams.SchoolName, dbo.tblTeams.teamID, dbo.tblTeams.WL "
                    sql2 = sql2 & "ORDER BY Points DESC"
                Else
                    sql2 = "SELECT tblRankings.ID, tblRankings.Points AS Points, tblRankings.Rank AS Rank, tblRankings.PrevWeek, tblRankings.PrevWeek - tblRankings.Rank AS RankDiff, tblRankings.schoolID, CASE tblRankings.NumOne WHEN 0 THEN tblRankings.School ELSE tblRankings.School + ' (' + CAST(tblRankings.NumOne AS varchar) + ')' END AS School, "
                    ' Changed 12/18/2013...
                    'sql2 = sql2 & "tblRankings.teamID, tblRankings.WL "
                    sql2 = sql2 & "tblRankings.teamID, dbo.GetTeamWL(tblRankings.teamID) AS WL "
                    sql2 = sql2 & "FROM tblRankings INNER JOIN tblTeams ON tblRankings.teamID = tblTeams.teamID INNER JOIN "
                    sql2 = sql2 & "tblRankingsWeeks ON tblRankings.WeekID = tblRankingsWeeks.wID "
                    If intYear = gCurrentYear Then
                        If sid.Contains("Wrestling") Then
                            sql2 = sql2 & "WHERE (WeekID = " & ds1.Tables(0).Rows(x).Item("WeekID") & ") AND (tblRankings.Rank <= " & intNumberOfRankings & ") "
                        Else
                            sql2 = sql2 & "WHERE (tblTeams.sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') AND (tblRankings.Rank <= " & intNumberOfRankings & ") AND "
                            sql2 = sql2 & "((tblrankingsweeks.ShowStartDate <= '" & dtmCurrentDate & "' AND tblrankingsweeks.ShowEndDate >= '" & dtmCurrentDate & "'"
                            sql2 = sql2 & ")) "
                        End If
                    Else
                        ' Added 11/19/2014...
                        If sid.Contains("Wrestling") Then
                            sql2 = sql2 & "WHERE (WeekID = " & ds1.Tables(0).Rows(x).Item("WeekID") & ") AND (tblRankings.Rank <= " & intNumberOfRankings & ") "
                        Else
                            sql2 = sql2 & "WHERE (tblTeams.sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') AND (tblRankings.Rank <= " & intNumberOfRankings & ") AND "
                            sql2 = sql2 & "(tblrankingsweeks.Static = 1 AND tblRankingsWeeks.intYear = " & intYear & ") "
                        End If
                    End If
                    sql2 = sql2 & " ORDER BY Points DESC, School "
                End If

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sql2)

                Dim strSportID As String = ""
                strSportID = ds1.Tables(0).Rows(x).Item("sportID")

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
                            'Me.GridView1.Caption = strCaption
                            Me.GridView1.DataBind()
                            If strSportID.Contains("Swimming") Then
                                GridView1.Columns(2).Visible = False
                            End If
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
                            'Me.GridView2.Caption = strCaption
                            Me.GridView2.DataBind()
                            If strSportID.Contains("Swimming") Then
                                GridView2.Columns(2).Visible = False
                            End If
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
                            'Me.GridView3.Caption = strCaption
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
                            'Me.GridView4.Caption = strCaption
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
                            'Me.GridView5.Caption = strCaption
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
                            'Me.GridView6.Caption = strCaption
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
                            'Me.GridView7.Caption = strCaption
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
                            'Me.GridView8.Caption = strCaption
                            Me.GridView8.DataBind()
                        End If
                End Select

            Next
        End If
    End Sub

    ' CDW removed 3/26/2015...
    'Private Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated

    '    If Session("printOnly") = 1 Then

    '    Else
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            Dim pce As PopupControlExtender = TryCast(e.Row.FindControl("PopupControlExtender1"), PopupControlExtender)

    '            Dim behaviorID As String = "pce_" & e.Row.RowIndex
    '            pce.BehaviorID = behaviorID

    '            Dim lblLabel As Label = DirectCast(e.Row.FindControl("lblSchool1"), Label)

    '            Dim OnMouseOverScript As String = String.Format("$find('{0}').showPopup();", behaviorID)
    '            Dim OnMouseOutScript As String = String.Format("$find('{0}').hidePopup();", behaviorID)

    '            lblLabel.Attributes.Add("onmouseover", OnMouseOverScript)
    '            lblLabel.Attributes.Add("onmouseout", OnMouseOutScript)
    '        End If

    '    End If

    'End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView4_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView5_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView6_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView6.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView7_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView7.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView8_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView8.RowDataBound
        If Request.QueryString("admin") = 3 Then
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub
End Class
