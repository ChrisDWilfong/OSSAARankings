Imports System.Data

Partial Class ucViewScheduleClass

    Inherits System.Web.UI.UserControl
    Shared cboClassList As String
    Shared showYear As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.UserHostAddress.ToString = "72.198.125.78" Then
            clsLog.LogSQL("", Request.UserHostAddress.ToString, "View Schedule Class")
            'Response.Redirect("http://www.ossaarankings.com/Default.aspx")        ' Greg Goodrich...
        End If

        Try
            If Session("gYear") Is Nothing Then
                Session("gYear") = clsFunctions.GetCurrentYear
            ElseIf Session("gYear") = "" Then
                Session("gYear") = clsFunctions.GetCurrentYear
            End If
        Catch
            Session("gYear") = clsFunctions.GetCurrentYear
        End Try

        If Not IsPostBack Then
            Session("scoreboardscrollerClass") = InitializeDataSet(Session("gScoreboardClass"))
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

        Select Case Session("sel")
            Case "tss"
                PanelScheduleTeam.Visible = True
            Case Else
                PanelScheduleTeam.Visible = False
        End Select

        RefreshHeader()

    End Sub
    Private Sub cboClass_DataBound(sender As Object, e As System.EventArgs) Handles cboClass.DataBound
        cboClass.Items.Insert(0, "Select...")
    End Sub

    Protected Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Dim strURL As String = ""

        Try
            If Session("gYear") <> clsFunctions.GetCurrentYear Then
                strURL = "Default.aspx?sel=schedulesClass" & "&spGK=" & Session("gSportGenderKey") & "&keep=1&y=" & Session("gYear")
            Else
                strURL = "Default.aspx?sel=schedulesClass" & "&spGK=" & Session("gSportGenderKey") & "&keep=1"
            End If
        Catch
            strURL = "Default.aspx?sel=schedulesClass" & "&spGK=" & Session("gSportGenderKey") & "&keep=1"
        End Try

        Response.Redirect(strURL)
    End Sub

    Public Function InitializeDataSet(gClass As String) As String
        Dim sportGenderKey As String
        Dim sportID As String
        Dim dsRegular As DataSet
        Dim x As Integer
        Dim strSchoolDisplay As String

        If Not Session("gSportGenderKey") Is Nothing Then
            sportGenderKey = Session("gSportGenderKey")
        Else
            sportGenderKey = ""
        End If

        If Not Session("gSportID") Is Nothing Then
            sportID = Session("gSportID")
        Else
            sportID = ""
        End If

        If sportID = "" Then
            sportID = sportGenderKey & gClass
        End If

        'dsRegular = clsTeams.GetSportTeamsForClass(sportID, clsFunctions.GetCurrentYear, 0, "", Session("memgPlayoffsRegionals"))
        dsRegular = clsTeams.GetSportTeamsForClass(sportID, Session("gYear"), 0, "", Session("memgPlayoffsRegionals"))

        If dsRegular Is Nothing Then
        ElseIf dsRegular.Tables.Count = 0 Then
        ElseIf dsRegular.Tables(0).Rows.Count = 0 Then
        Else
            Dim dt0 As New DataTable
            dt0.Columns.Add("strTeam")
            Dim dt1 As New DataTable
            dt1.Columns.Add("strTeam")
            Dim dt2 As New DataTable
            dt2.Columns.Add("strTeam")
            Dim dt3 As New DataTable
            dt3.Columns.Add("strTeam")
            Dim dr As DataRow = Nothing

            For x = 0 To dsRegular.Tables(0).Rows.Count - 1
                If Session("printOnly") = 1 Then
                    ' No HyperLinks in Print Version...
                    If sportGenderKey.Contains("Cheer") Or sportGenderKey.Contains("CrossCountry") Or sportGenderKey.Contains("Swimming") Then
                        strSchoolDisplay = dsRegular.Tables(0).Rows(x).Item("SchoolAbb")
                    Else
                        strSchoolDisplay = dsRegular.Tables(0).Rows(x).Item("SchoolAbb") & " (" & dsRegular.Tables(0).Rows(x).Item("WL") & ")"
                    End If
                Else
                    ' Do HyperLinks...
                    If sportGenderKey.Contains("Cheer") Or sportGenderKey.Contains("CrossCountry") Or sportGenderKey.Contains("Swimming") Then
                        strSchoolDisplay = "<a href='?sel=tss&t=" & dsRegular.Tables(0).Rows(x).Item("teamID") & "&op=t&p=1' target='_self'>" & dsRegular.Tables(0).Rows(x).Item("SchoolAbb") & "</a>"
                    ElseIf sportGenderKey.Contains("Golf") Then
                        If dsRegular.Tables(0).Rows(x).Item("avgGolfScore") = 0 Then
                            strSchoolDisplay = "<a href='?sel=tss&t=" & dsRegular.Tables(0).Rows(x).Item("teamID") & "&op=t&p=1' target='_self'>" & dsRegular.Tables(0).Rows(x).Item("SchoolAbb") & " (-)" & "</a>"
                        Else
                            strSchoolDisplay = "<a href='?sel=tss&t=" & dsRegular.Tables(0).Rows(x).Item("teamID") & "&op=t&p=1' target='_self'>" & dsRegular.Tables(0).Rows(x).Item("SchoolAbb") & " (" & dsRegular.Tables(0).Rows(x).Item("avgGolfScore") & " avg)" & "</a>"
                        End If
                    Else
                        strSchoolDisplay = "<a href='?sel=tss&t=" & dsRegular.Tables(0).Rows(x).Item("teamID") & "&op=t&p=1' target='_self'>" & dsRegular.Tables(0).Rows(x).Item("SchoolAbb") & " (" & dsRegular.Tables(0).Rows(x).Item("WL") & ")" & "</a>"
                    End If
                End If
                Select Case x Mod 4
                    Case 0
                        dr = dt0.NewRow
                        dr(0) = strSchoolDisplay
                        dt0.Rows.Add(dr)
                    Case 1
                        dr = dt1.NewRow
                        dr(0) = strSchoolDisplay
                        dt1.Rows.Add(dr)
                    Case 2
                        dr = dt2.NewRow
                        dr(0) = strSchoolDisplay
                        dt2.Rows.Add(dr)
                    Case 3
                        dr = dt3.NewRow
                        dr(0) = strSchoolDisplay
                        dt3.Rows.Add(dr)
                End Select
            Next

            GridView0.DataSource = dt0
            GridView0.DataBind()

            GridView1.DataSource = dt1
            GridView1.DataBind()

            GridView2.DataSource = dt2
            GridView2.DataBind()

            GridView3.DataSource = dt3
            GridView3.DataBind()

        End If

        Return Session("gSportDisplay") & " Scores"

    End Function

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        If rowHeader.Visible Then
            Session("gScoreboardClass") = cboClass.SelectedValue
        End If
        Session("scoreboardscrollerClass") = InitializeDataSet(Session("gScoreboardClass"))
        RefreshHeader()
    End Sub

    Public Sub RefreshHeader()
        Dim strSport As String = ""
        Dim strYear As String = ""

        strYear = clsFunctions.GetCurrentYearDisplay(Session("gSportDisplay"), Session("gYear"))
        strSport = strYear & " " & Session("gSportDisplay") & " Schedules "
        If Session("gScoreboardClass") = "" Or Session("gScoreboardClass") = "ALL" Then
            If cboClass.SelectedValue = "" Then
            ElseIf cboClass.SelectedValue = "Select..." Then
            Else
                strSport = strSport & "for ALL Classes"
            End If
        Else
            If cboClass.SelectedValue = "Select..." Then
            Else
                strSport = strSport & "for Class " & Session("gScoreboardClass")
            End If
        End If
        lblSport.Text = strSport

    End Sub


End Class
