Imports System.Data

Partial Class ucRankingsPreviousDetails

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

        Dim dtmCurrentDate As String = Now
        gCurrentYear = clsFunctions.GetCurrentYear

        If Request.QueryString("sID") Is Nothing Then       ' Passed from Print Version...
            sportID = Session("gSportID")
            rankGender = Session("gGender")
            rankSport = Session("gSport")
            sportGenderKey = Session("gSportGenderKey")
            'Me.hlPrint.Visible = False
        Else
            sportID = Request.QueryString("sID")
            rankGender = Request.QueryString("g")
            rankSport = Request.QueryString("s")
            sportGenderKey = Request.QueryString("spGK")
            ' Get the Print Hyperlink...
            'Me.hlPrint.NavigateUrl = "PrintRankings.aspx?sel=tr"
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

        'dtmCurrentDate = "2013-08-20 00:00:00.000"

        ' Scroll through weeks...
        SQL = "SELECT tblSports.Class, tblSports.Gender, tblSports.Sport, tblSports.sportID, tblSports.GenderSport1, preseason, showstartdate, tblrankingsweeks.showenddate, tblrankingsweeks.showstartdate, tblrankingsweeks.weekNo, tblRankingsWeeks.Static, "
        SQL = SQL & "tblRankingsWeeks.showWL, tblRankingsWeeks.showPoints, tblSports.NumberOfRankingsShow, tblSports.Sport, tblSports.Gender "
        SQL = SQL & "FROM tblSports INNER JOIN tblRankingsWeeks ON tblSports.sportID = tblRankingsWeeks.sportID "
        SQL = SQL & "WHERE ((tblrankingsweeks.ShowStartDate <= '" & dtmCurrentDate & "' AND tblrankingsweeks.ShowEndDate >= '" & dtmCurrentDate & "')) "
        'SQL = SQL & " AND (Gender = '" & rankGender & "') AND (Sport = '" & rankSport & "')"
        SQL = SQL & " AND (tblSports.SportGenderKey = '" & sportGenderKey & "')"
        SQL = SQL & " AND (tblRankingsWeeks.intYear = " & gCurrentYear & ") AND tblSports.intRankings = 1"
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
                strCaption = ""
                strCaption = strCaption & "Class " & ds1.Tables(0).Rows(x).Item("class") & " " & ds1.Tables(0).Rows(x).Item("GenderSport1")
                If ds1.Tables(0).Rows(x).Item("Static") Then
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " Rankings"
                Else
                    strCaption = strCaption & " " & ds1.Tables(0).Rows(x).Item("weekno") & " Rankings as of " & FormatDateTime(ds1.Tables(0).Rows(x).Item("ShowStartDate"), DateFormat.ShortDate)
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

                ' Data source...
                sql2 = "SELECT tblRankings.ID, tblRankings.Points AS Points, tblRankings.Rank AS Rank, tblRankings.schoolID, CASE tblRankings.NumOne WHEN 0 THEN tblRankings.School ELSE tblRankings.School + ' (' + CAST(tblRankings.NumOne AS varchar) + ')' END AS School, tblRankings.teamID, tblRankings.WL "
                sql2 = sql2 & "FROM tblRankings INNER JOIN tblTeams ON tblRankings.teamID = tblTeams.teamID INNER JOIN "
                sql2 = sql2 & "tblRankingsWeeks ON tblRankings.WeekID = tblRankingsWeeks.wID "
                sql2 = sql2 & "WHERE (tblTeams.sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') AND (tblRankings.Rank <= " & intNumberOfRankings & ") AND "
                sql2 = sql2 & "((tblrankingsweeks.ShowStartDate <= '" & dtmCurrentDate & "' AND tblrankingsweeks.ShowEndDate >= '" & dtmCurrentDate & "'"
                sql2 = sql2 & ")) "
                sql2 = sql2 & " ORDER BY Points DESC, School "

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
                            'Me.GridView1.Caption = strCaption
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
                            'Me.GridView2.Caption = strCaption
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

End Class
