Imports System.Data
Imports AjaxControlToolkit

Partial Class ucViewRankingAll58

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

        Dim dtmCurrentDate As Date = Now
        gCurrentYear = clsFunctions.GetCurrentYear

        ' Added 9/9/2013...
        If Request.QueryString("admin") = 1 Or Request.QueryString("admin") = 2 Or Request.QueryString("admin") = 3 Then
            If Request.QueryString("admin") = 2 Then
                dtmCurrentDate = DateAdd(DateInterval.Day, -7, dtmCurrentDate)
            Else
                dtmCurrentDate = DateAdd(DateInterval.Hour, 48, dtmCurrentDate)
            End If
            'GridView1.Columns(4).Visible = True
            'GridView1.Columns(5).Visible = True
            'GridView2.Columns(4).Visible = True
            'GridView2.Columns(5).Visible = True
            'GridView3.Columns(4).Visible = True
            'GridView3.Columns(5).Visible = True
            'GridView4.Columns(4).Visible = True
            'GridView4.Columns(5).Visible = True
        End If

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

        If rankGender = "5d8" Then
            sportGenderKey = "WrestlingDual"
        Else
            sportGenderKey = "Wrestling"
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
        SQL = "SELECT DISTINCT dbo.tblSports.GenderSport1, dbo.tblSports.NumberOfRankingsShow, dbo.tblSports.Class, dbo.tblSports.sportID, dbo.tblSports.SportGenderKey "
        SQL = SQL & "FROM dbo.tblSports INNER JOIN "
        SQL = SQL & "dbo.tblRankingsWeeks ON dbo.tblSports.sportID = dbo.tblRankingsWeeks.sportID "
        SQL = SQL & "WHERE (dbo.tblSports.SportGenderKey = '" & sportGenderKey & "') "
        SQL = SQL & "ORDER BY dbo.tblSports.sportID DESC"

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
                strCaption = strCaption & "Class " & ds1.Tables(0).Rows(x).Item("class") & " " & strSport & "<br>"
                'strCaption = strCaption & " Accumulative (Final 5 Weeks) Rankings " & FormatDateTime(ds1.Tables(0).Rows(x).Item("ShowStartDate"), DateFormat.ShortDate)
                strCaption = strCaption & " Accumulative (Final 5 Weeks) Rankings "

                Select Case x
                    Case 0
                        Me.Label1.Text = strCaption
                    Case 1
                        Me.Label2.Text = strCaption
                    Case 2
                        Me.Label3.Text = strCaption
                    Case 3
                        Me.Label4.Text = strCaption
                End Select

                Dim sid As String = ds1.Tables(0).Rows(x).Item("sportID")

                If sid.Contains("WrestlingDual") Then
                    sql2 = "SELECT TOP " & intNumberOfRankings & " * FROM ossaauser.viewWrestlingDualLast5WeeksOfRankings8 WHERE (sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') "
                Else
                    sql2 = "SELECT TOP " & intNumberOfRankings & " * FROM ossaauser.viewWrestlingLast5WeeksOfRankings WHERE (sportID = '" & ds1.Tables(0).Rows(x).Item("sportID") & "') "
                End If
                sql2 = sql2 & " ORDER BY TotalPoints DESC, School "

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

                End Select

            Next
        End If
    End Sub

    Private Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated

        If Session("printOnly") = 1 Then

        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim pce As PopupControlExtender = TryCast(e.Row.FindControl("PopupControlExtender1"), PopupControlExtender)

                Dim behaviorID As String = "pce_" & e.Row.RowIndex
                pce.BehaviorID = behaviorID

                Dim lblLabel As Label = DirectCast(e.Row.FindControl("lblSchool1"), Label)

                Dim OnMouseOverScript As String = String.Format("$find('{0}').showPopup();", behaviorID)
                Dim OnMouseOutScript As String = String.Format("$find('{0}').hidePopup();", behaviorID)

                lblLabel.Attributes.Add("onmouseover", OnMouseOverScript)
                lblLabel.Attributes.Add("onmouseout", OnMouseOutScript)
            End If

        End If

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowIndex + 1 = 0 Then
        Else
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowIndex + 1 = 0 Then
        Else
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView3_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowIndex + 1 = 0 Then
        Else
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

    Private Sub GridView4_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        If e.Row.RowIndex + 1 = 0 Then
        Else
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub

End Class
