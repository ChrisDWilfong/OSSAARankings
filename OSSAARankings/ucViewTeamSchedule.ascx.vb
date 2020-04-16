Imports System.Data

Partial Class ucViewTeamSchedule
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objTeamInfo As New clsTeam(Session("gTeamID"))

        ' Show/Hide Details...
        If Session("gSportID") Is Nothing Then
            GridView1.Columns(4).Visible = False
        Else
            If Session("gSportID").ToString.Contains("Volleyball") Then
                GridView1.Columns(4).Visible = True
            Else
                GridView1.Columns(4).Visible = False
            End If
        End If

        If Session("gSportID") Is Nothing Then
            lblDistrict.Visible = False
        Else
            If Session("gSportID").ToString.Contains("FPSoftball") Or Session("gSportID").ToString.Contains("Football") Then
                lblDistrict.Visible = True
            Else
                lblDistrict.Visible = False
            End If
            lblPlayoffs.Text = clsSports.GetPlayoffSchedule(Session("gSportID"))
        End If

        InitializeGrid(objTeamInfo.getSport, Session("gTeamID"))
        hlPrint.NavigateUrl = "PrintSchedule.aspx?sel=ts&t=" & Session("gTeamID")


        If Session("printOnly") = 1 Then
            hlPrint.Visible = False
        Else
            hlPrint.Visible = True
        End If

        Session("printOnly") = 0

    End Sub

    Public Sub InitializeGrid(ByVal sport As String, ByVal tmID As Integer)
        Dim sql As String
        Dim ds As DataSet

        sql = clsSchedules.GetScheduleTeamSQL(tmID)
        ' Get initial dataset...
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sql)

        ' Change the dataset...
        ds = ChangeDatasetPublic(ds)

        ' Bind new dataset ....
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

    End Sub

    Public Function ChangeDatasetPublic(ByVal ds As DataSet) As DataSet
        Dim x As Integer
        Dim strOpposingTeam As String
        Dim strShortDate As String
        Dim strWL As String
        Dim intCurrentRanking As Integer
        Dim strRanking As String
        Dim strAt As String
        Dim gStatus As String

        For x = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(x)
                ' Date...
                strShortDate = Format(.Item("gameDate"), "MM/dd/yy")
                Try
                    gStatus = clsSchedules.FilterGameStatus(.Item("gStatus"), .Item("sportID"))
                Catch ex As Exception
                    gStatus = ""
                End Try

                ' Opposing Team...
                If (Not .Item("OtherTeam") Is System.DBNull.Value And Not .Item("Opposing Team") Is System.DBNull.Value) And (Not .Item("OtherTeam") Is System.DBNull.Value And Not .Item("OtherTeam").ToString.Contains("State Championship")) Then
                    Try
                        If .Item("OtherTeam") = "" Then
                            strOpposingTeam = "TBA"
                        Else
                            strOpposingTeam = .Item("OtherTeam")
                        End If
                    Catch
                        strOpposingTeam = "TBA"
                    End Try

                ElseIf .Item("Opposing Team") Is System.DBNull.Value Then
                    strOpposingTeam = ""

                ElseIf .Item("Opposing Team") = "" Then
                    strOpposingTeam = "TBA"

                Else
                    ' Get the ranking....
                    intCurrentRanking = .Item("oRank")

                    If intCurrentRanking > 0 Then
                        strRanking = " # " & intCurrentRanking
                    Else
                        strRanking = ""
                    End If
                    ' Get the location...
                    If .Item("location") Is System.DBNull.Value Then
                        strAt = ""
                    ElseIf .Item("location") = "Away" Then
                        strAt = "@ "
                    Else
                        strAt = ""
                    End If

                    If strRanking = "" Then
                        If .Item("oTeamID") = 0 Then
                            strOpposingTeam = strAt & .Item("Opposing Team")
                        Else
                            strOpposingTeam = strAt & "<a href='?sel=teamschedule&t=" & .Item("oTeamID") & "' target='_self'>" & .Item("Opposing Team") & " (" & Trim(.Item("Class")) & ")</a>"
                        End If
                    Else
                        If .Item("oTeamID") = 0 Then
                            strOpposingTeam = strAt & .Item("Opposing Team")
                        Else
                            strOpposingTeam = strAt & "<a href='?sel=teamschedule&t=" & .Item("oTeamID") & "' target='_self'>" & .Item("Opposing Team") & " (" & Trim(.Item("Class")) & "-" & Trim(strRanking) & ")</a>"
                        End If
                    End If
                End If

                strOpposingTeam = strOpposingTeam.Replace(" High School", "")
                If .Item("strType").ToString.Contains("TOSSAA") Then
                    strOpposingTeam = strOpposingTeam & " @ " & clsSchedules.GetOSSAATourneyType(.Item("strType"), .Item("intGame"), .Item("NeutralSiteCoor"))
                ElseIf .Item("Tournament") Is System.DBNull.Value Then
                ElseIf .Item("Tournament") = "" Then
                Else
                    strOpposingTeam = strOpposingTeam & " @ " & .Item("Tournament")
                End If

                ' District?
                If .Item("strType") = "DIST" Then
                    strOpposingTeam = strOpposingTeam & " **"
                End If
                .Item("Opposing Team") = strOpposingTeam

                ' Results...
                strWL = ""

                If .Item("TotalScore") = 0 And .Item("oTotalScore") = 0 Then
                    .Item("Date") = strShortDate.Replace("12:00:00 AM", "") & " @ " & .Item("Time")
                    Try
                        If .Item("sportID") Is System.DBNull.Value Then
                            .Item("Results") = clsSports.GetNoScore(.Item("teamSportID"), .Item("strType"), gStatus, False, "", "")
                        Else
                            .Item("Results") = clsSports.GetNoScore(.Item("sportID"), .Item("strType"), gStatus, False, "", "")
                        End If
                    Catch
                        ' FIX THIS???
                        .Item("Results") = "No Results"
                    End Try
                Else
                    If .Item("teamSportID") = "Wrestling" Then      ' Added 12/1/2014...
                        strWL = ""
                    ElseIf .Item("TotalScore") > .Item("oTotalScore") Then
                        strWL = "W"
                    Else
                        strWL = "L"
                    End If

                    If gStatus.Contains("Final (") Or gStatus.Contains("OT") Then
                        .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & strWL & " " & gStatus
                    Else
                        If .Item("teamSportID") = "Wrestling" And .Item("strType") = "TOURNEY" And (.Item("oTotalScore") = 0) Then          ' Added 12/1/2014...
                            .Item("Results") = "Place : " & .Item("TotalScore")
                        Else
                            .Item("Results") = .Item("TotalScore") & "-" & .Item("oTotalScore") & " " & strWL
                        End If
                    End If
                    .Item("Date") = strShortDate.Replace("12:00:00 AM", "")

                End If

            End With
        Next

        Return ds
    End Function

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ' Turn off the Hyperlink for non-OSSAA teams...
        Dim objHL As New HyperLink
        Dim strHL As String = ""

        Try
            objHL = e.Row.Cells(2).Controls(0)
            strHL = objHL.Text
        Catch
        End Try

        If Session("printOnly") = 1 Then
            objHL.Enabled = False
        ElseIf strHL.Contains("t=0") Then
            objHL.Enabled = False
        ElseIf strHL.Contains("t=") Then
            objHL.Enabled = True
        Else
            objHL.Enabled = False
        End If

    End Sub
End Class
