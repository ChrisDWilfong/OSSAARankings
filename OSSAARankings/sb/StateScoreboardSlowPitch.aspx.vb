Public Class StateScoreboardSlowPitch
    Inherits System.Web.UI.Page

    Dim strSchoolName1a As String
    Dim strSchoolName1b As String
    Dim strSchoolName2a As String
    Dim strSchoolName2b As String
    Dim strSchoolName3a As String
    Dim strSchoolName3b As String
    Dim strSchoolName4a As String
    Dim strSchoolName4b As String

    Dim intScore1a As Integer = 0
    Dim intScore1b As Integer = 0
    Dim intScore2a As Integer = 0
    Dim intScore2b As Integer = 0
    Dim intScore3a As Integer = 0
    Dim intScore3b As Integer = 0
    Dim intScore4a As Integer = 0
    Dim intScore4b As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Request.QueryString("y") Is Nothing Then
                Session("gYear") = System.Configuration.ConfigurationManager.AppSettings("intYear")
            Else
                Session("gYear") = CInt(Request.QueryString("y"))
            End If
            Session("intCounter") = 0
        End If

        If Session("gYear") Is Nothing Then Session("gYear") = System.Configuration.ConfigurationManager.AppSettings("intYear")

        Me.lblHeader.Text = "20" & Session("gYear") & " OSSAA Slow-Pitch State Championships Scoreboard"

        ' Header Updates...
        lblClassAHeader.Text = "Class A State Tournament @ ASA HOF Stadium/OKC: May 4"
        lblClass2AHeader.Text = "Class 2A State Tournament @ ASA HOF Stadium/OKC: May 4"
        lblClass3AHeader.Text = "Class 3A State Tournament @ ASA HOF Stadium/OKC: May 4"
        lblClass4AHeader.Text = "Class 4A State Tournament @ ASA HOF Stadium/OKC: May 3"
        lblClass5AHeader.Text = "Class 5A State Tournament @ ASA HOF Stadium/OKC: May 3"
        lblClass6AHeader.Text = "Class 6A State Tournament @ ASA HOF Stadium/OKC: May 3"

        ' Add the id=???
        UpdateGames()

    End Sub

    Public Sub UpdateGames()

        ' Refresh all...
        ClearVariables()
        lblBoysA.Text = UpdateClass("SPSoftballA")
        ClearVariables()
        lblBoys2A.Text = UpdateClass("SPSoftball2A")
        ClearVariables()
        lblBoys3A.Text = UpdateClass("SPSoftball3A")
        ClearVariables()
        lblBoys4A.Text = UpdateClass("SPSoftball4A")
        ClearVariables()
        lblBoys5A.Text = UpdateClass("SPSoftball5A")
        ClearVariables()
        lblBoys6A.Text = UpdateClass("SPSoftball6A")

    End Sub

    Public Sub ClearVariables()

        strSchoolName1a = ""
        strSchoolName1b = ""
        strSchoolName2a = ""
        strSchoolName2b = ""
        strSchoolName3a = ""
        strSchoolName3b = ""
        strSchoolName4a = ""
        strSchoolName4b = ""

        intScore1a = 0
        intScore1b = 0
        intScore2a = 0
        intScore2b = 0
        intScore3a = 0
        intScore3b = 0
        intScore4a = 0
        intScore4b = 0

    End Sub

    Public Function UpdateClass(strSportKey As String) As String
        Dim strResult As String = ""
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim intGame As Integer = 0
        Dim intGameNo As Integer = 0
        Dim x As Integer = 0

        strSQL = GetSQLString(strSportKey)

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                intGameNo = ds.Tables(0).Rows(x).Item("intGame")
                If intGame = ds.Tables(0).Rows(x).Item("intSort") Then
                    ' Skip it, we already have it...
                Else
                    intGame = ds.Tables(0).Rows(x).Item("intSort")
                    If intGame = 1 Then
                        If intGameNo = 1101 Or intGameNo = 1201 Then
                            strSchoolName1a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName1b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore1a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore1b = ds.Tables(0).Rows(x).Item("oTotalScore")
                        ElseIf intGameNo = 1102 Or intGameNo = 1202 Then
                            strSchoolName2a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName2b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore2a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore2b = ds.Tables(0).Rows(x).Item("oTotalScore")
                        ElseIf intGameNo = 1103 Or intGameNo = 1203 Then
                            strSchoolName3a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName3b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore3a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore3b = ds.Tables(0).Rows(x).Item("oTotalScore")
                        ElseIf intGameNo = 1104 Or intGameNo = 1204 Then
                            strSchoolName4a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName4b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore4a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore4b = ds.Tables(0).Rows(x).Item("oTotalScore")
                        End If
                        strResult += "<table ID='" & strSportKey & "'>"
                        strResult += "<tr><td style='text-align:Center;'><img src='images/BasketballScoreboardQ.gif' width='250px'></td></tr>"

                        If intGameNo = 1101 Or intGameNo = 1201 Then
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName1a, strSchoolName1b) & "</td></tr>"
                        ElseIf intGameNo = 1102 Or intGameNo = 1202 Then
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName2a, strSchoolName2b) & "</td></tr>"
                        ElseIf intGameNo = 1103 Or intGameNo = 1203 Then
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName3a, strSchoolName3b) & "</td></tr>"
                        ElseIf intGameNo = 1104 Or intGameNo = 1204 Then
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName4a, strSchoolName4b) & "</td></tr>"
                        End If
                    End If
                    If intGame = 2 Then
                        If intGameNo = 1101 Or intGameNo = 1201 Then
                            strSchoolName1a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName1b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore1a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore1b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName1a, strSchoolName1b) & "</td></tr>"
                        ElseIf intGameNo = 1102 Or intGameNo = 1202 Then
                            strSchoolName2a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName2b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore2a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore2b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName2a, strSchoolName2b) & "</td></tr>"
                        ElseIf intGameNo = 1103 Or intGameNo = 1203 Then
                            strSchoolName3a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName3b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore3a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore3b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName3a, strSchoolName3b) & "</td></tr>"
                        ElseIf intGameNo = 1104 Or intGameNo = 1204 Then
                            strSchoolName4a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName4b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore4a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore4b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName4a, strSchoolName4b) & "</td></tr>"
                        End If
                    End If
                    If intGame = 3 Then
                        If intGameNo = 1101 Or intGameNo = 1201 Then
                            strSchoolName1a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName1b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore1a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore1b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName1a, strSchoolName1b) & "</td></tr>"
                        ElseIf intGameNo = 1102 Or intGameNo = 1202 Then
                            strSchoolName2a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName2b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore2a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore2b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName2a, strSchoolName2b) & "</td></tr>"
                        ElseIf intGameNo = 1103 Or intGameNo = 1203 Then
                            strSchoolName3a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName3b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore3a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore3b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName3a, strSchoolName3b) & "</td></tr>"
                        ElseIf intGameNo = 1104 Or intGameNo = 1204 Then
                            strSchoolName4a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName4b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore4a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore4b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName4a, strSchoolName4b) & "</td></tr>"
                        End If
                    End If
                    If intGame = 4 Then
                        If intGameNo = 1101 Or intGameNo = 1201 Then
                            strSchoolName1a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName1b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore1a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore1b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName1a, strSchoolName1b) & "</td></tr>"
                        ElseIf intGameNo = 1102 Or intGameNo = 1202 Then
                            strSchoolName2a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName2b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore2a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore2b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName2a, strSchoolName2b) & "</td></tr>"
                        ElseIf intGameNo = 1103 Or intGameNo = 1203 Then
                            strSchoolName3a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName3b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore3a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore3b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName3a, strSchoolName3b) & "</td></tr>"
                        ElseIf intGameNo = 1104 Or intGameNo = 1204 Then
                            strSchoolName4a = ds.Tables(0).Rows(x).Item("SchoolName")
                            strSchoolName4b = ds.Tables(0).Rows(x).Item("oSchoolName")
                            intScore4a = ds.Tables(0).Rows(x).Item("TotalScore")
                            intScore4b = ds.Tables(0).Rows(x).Item("oTotalScore")
                            strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName4a, strSchoolName4b) & "</td></tr>"
                        End If
                    End If
                    If intGame = 5 Then
                        strResult += "<tr><td style='text-align:Center;'><img src='images/BasketballScoreboardS.gif' width='250px'></td></tr>"
                    End If

                    If intGame = 5 Or intGame = 6 Then

                        If intGameNo = 1105 Or intGameNo = 1205 Then
                            If intScore1a = 0 And intScore1b = 0 And intScore2a = 0 And intScore2b = 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            ElseIf intScore1a > 0 And intScore1b > 0 And intScore2a > 0 And intScore2b > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            ElseIf intScore1a > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName2a, strSchoolName2b) & "</td></tr>"
                            ElseIf intScore2a > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName1a, strSchoolName1b) & "</td></tr>"
                            Else
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            End If
                        Else    ' intGameNo = 1106 or intGameNo = 1206...
                            If intScore3a = 0 And intScore3b = 0 And intScore4a = 0 And intScore4b = 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            ElseIf intScore3a > 0 And intScore3b > 0 And intScore4a > 0 And intScore4b > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            ElseIf intScore3a > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName4a, strSchoolName4b) & "</td></tr>"
                            ElseIf intScore4a > 0 Then
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), strSchoolName3a, strSchoolName3b) & "</td></tr>"
                            Else
                                strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                            End If
                        End If
                    End If
                    If intGame = 7 Then
                        strResult += "<tr><td style='text-align:Center;'><img src='images/BasketballScoreboardC.gif' width='250px'></td></tr>"
                        strResult += "<tr><td style='text-align:Center;'>" & ReturnLine(ds.Tables(0).Rows(x), "", "") & "</td></tr>"
                        strResult += "</table>"
                    End If
                End If
            Next
        End If

        Return strResult

    End Function

    Public Function ReturnLine(dr As DataRow, strSchoolName1 As String, strSchoolName2 As String) As String
        Dim strResult As String = ""
        Dim strVS As String = ""

        If dr.Item("intGame") = 1107 Or dr.Item("intGame") = 1207 Then
            strVS = "TBD"
        Else
            If strSchoolName1 = "" And strSchoolName2 = "" Then
                strVS = ""
            Else
                strVS = strSchoolName1 & "/" & strSchoolName2
            End If
        End If

        If dr.Item("teamID") = 0 And dr.Item("oteamID") = 0 Then
            strResult = dr.Item("OtherTeam") & " @ " & dr.Item("strComments") & " @ " & dr.Item("gameTime")
        ElseIf dr.Item("TotalScore") = 0 And dr.Item("oTotalScore") = 0 Then
            If dr.Item("teamID") = 0 Then
                ' Let's get the first school...
                strSchoolName1 = strVS
                strSchoolName2 = dr.Item("oSchoolName")
            ElseIf dr.Item("oteamID") = 0 Then
                strSchoolName1 = dr.Item("SchoolName")
                strSchoolName2 = strVS
            Else
                strSchoolName1 = dr.Item("SchoolName")
                strSchoolName2 = dr.Item("oSchoolName")
            End If
            strResult = strSchoolName1 & " vs " & strSchoolName2 & " @ " & dr.Item("strComments") & " @ " & dr.Item("gameTime")
        Else
            If dr.Item("TotalScore") > dr.Item("oTotalScore") Then
                strResult = dr.Item("SchoolName") & " <strong><span style='color:Red;'>" & dr.Item("TotalScore") & "</span></strong>  " & dr.Item("oSchoolName") & " <strong><span style='color:Red;'>" & dr.Item("oTotalScore") & "</span></strong>"
            Else
                strResult = dr.Item("oSchoolName") & " <strong><span style='color:Red;'>" & dr.Item("oTotalScore") & "</span></strong>  " & dr.Item("SchoolName") & " <strong><span style='color:Red;'>" & dr.Item("TotalScore") & "</span></strong>"
            End If
            If InStr(dr.Item("gStatus"), "OT") > 0 Then
                strResult = strResult & "<strong> - Ex/Inn</strong>"
            End If
            If dr.Item("strLink") Is System.DBNull.Value Then
            Else
                strResult = strResult & " <a href='" & dr.Item("strLink") & "' target='_blank'>Stats</a>"
            End If
        End If
        Return strResult
    End Function


    Public Function GetSQLString(strSportKey As String) As String
        Dim strSQL As String = ""
        strSQL = "SELECT *, tblTeams.SchoolName, tblTeams_1.SchoolName AS oSchoolName "
        strSQL += "FROM tblSchedules LEFT OUTER JOIN "
        strSQL += "tblTeams ON tblSchedules.teamID = tblTeams.teamID LEFT OUTER JOIN "
        strSQL += "tblTeams AS tblTeams_1 ON tblSchedules.oTeamID = tblTeams_1.teamID "
        strSQL += "WHERE (tblSchedules.strType = 'TOSSAAS') AND (tblSchedules.intYear = " & clsFunctions.GetCurrentYear() & ") AND (tblSchedules.sportID = '" & strSportKey & "') "
        strSQL += "ORDER BY tblSchedules.intSort"
        Return strSQL
    End Function

End Class