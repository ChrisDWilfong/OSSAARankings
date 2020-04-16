Imports System.Data

Partial Class ucViewScheduleFBBDistricts

    Inherits System.Web.UI.UserControl
    Shared cboClassList As String
    Shared strKey1 As String
    Shared strKey2 As String
    Shared strKey3 As String
    Shared strKey4 As String
    Shared intDistricts As Integer = 16
    Shared gSportGenderKey As String = "BaseballFall"
    Shared gSportDisplay As String = "Baseball (Fall)"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gSportGenderKey") = gSportGenderKey
        Session("gSportDisplay") = gSportDisplay

        If Not IsPostBack Then
            Session("scoreboardscrollerClass") = InitializeDataSet(Session("gScoreboardClass"), intDistricts)
            ' Turn off the dropdowns for the Print version...
            If Session("printOnly") = 1 Then
                Me.rowHeader.Visible = False
            Else
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
    Private Sub cboClass_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClass.DataBound
        cboClass.Items.Insert(0, "Select...")
    End Sub

    Public Function InitializeDataSet(ByVal strSportID As String, ByVal intRows As Integer) As String
        Dim strReturn As String = ""
        Dim x As Integer
        Dim y As Integer
        Dim strSQL As String
        Dim strSpan As String = "<span style='font-family:Segoe UI, Verdana, Helvetica, sans-serif; font-size:12pt; font-weight:normal;'>"
        Dim strBullet As String = "<img src='../images/ig_treeBlack_box.gif'>&nbsp;"
        Dim strSpanBold As String = "<span style='font-family:Segoe UI, Verdana, Helvetica, sans-serif; font-weight:bold; font-size:14pt'>"
        Dim ds As DataSet
        Dim dsHeader As DataSet
        Dim strHeader As String
        Dim strDetail As String
        Dim strGame As String = ""

        strSQL = "SELECT teamID, schoolID, sportID, playoffsDistrict, ysnHostDistrict, SchoolName "
        strSQL = strSQL & "FROM dbo.tblTeams "
        strSQL = strSQL & "WHERE (sportID = '" & gSportGenderKey & strSportID & "') AND (playoffsDistrict > 0) "
        strSQL = strSQL & "ORDER BY playoffsDistrict"

        dsHeader = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        strSQL = "SELECT tblTeams.SchoolName, tblTeams_1.SchoolName AS oSchoolName, dbo.tblTeams.playoffsDistrict, "
        strSQL = strSQL & "dbo.tblTeams.ysnHostDistrict, dbo.tblSchedules.teamID, dbo.tblSchedules.oTeamID, dbo.tblSchedules.sportID, "
        strSQL = strSQL & "dbo.tblSports.strPlayoffsScheduleShowDistricts, dbo.tblSchedules.gamedate, dbo.tblSchedules.gametime, "
        strSQL = strSQL & "dbo.tblSchedules.OtherTeam, dbo.tblSchedules.Location, dbo.tblSchedules.Tournament, dbo.tblSchedules.TotalScore, "
        strSQL = strSQL & "dbo.tblSchedules.oTotalScore, dbo.tblSchedules.WL, dbo.tblSchedules.scheduleID "
        strSQL = strSQL & "FROM dbo.tblSchedules LEFT OUTER JOIN dbo.tblTeams AS tblTeams_1 "
        strSQL = strSQL & "ON dbo.tblSchedules.oTeamID = tblTeams_1.teamID LEFT OUTER JOIN dbo.tblSports "
        strSQL = strSQL & "ON dbo.tblSchedules.sportID = dbo.tblSports.sportID RIGHT OUTER JOIN dbo.tblTeams "
        strSQL = strSQL & "ON dbo.tblSchedules.teamID = dbo.tblTeams.teamID "
        strSQL = strSQL & "WHERE ((dbo.tblTeams.sportID = '" & gSportGenderKey & strSportID & "') AND (dbo.tblTeams.playoffsDistrict > 0)) "
        strSQL = strSQL & "AND (dbo.tblSchedules.strType = 'TOSSAAD') AND (dbo.tblSchedules.ysnActive > 0) "
        strSQL = strSQL & "ORDER BY dbo.tblTeams.playoffsDistrict, tblSchedules.gameDate, tblSchedules.gameTime, tblTeams.ysnHostDistrict"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        For x = 0 To intRows - 1
            strHeader = ""
            strDetail = ""
            strKey1 = ""
            strKey2 = ""
            strKey3 = ""
            strKey4 = ""

            ' Get the Header...
            For y = 0 To dsHeader.Tables(0).Rows.Count - 1
                If dsHeader.Tables(0).Rows(y).Item("playoffsDistrict") = (x + 1) Then
                    If dsHeader.Tables(0).Rows(y).Item("ysnHostDistrict") <> 0 Then
                        'strHeader = strSpanBold & "District #" & (x + 1) & " @ " & dsHeader.Tables(0).Rows(y).Item("SchoolName") & "</span><br>"
                        strHeader = strSpanBold & "District @ " & dsHeader.Tables(0).Rows(y).Item("SchoolName") & "</span><br>"
                    End If
                End If
            Next
            If strHeader = "" Then
                strHeader = strSpanBold & "District #" & (x + 1) & "</span><br>"
            End If

            For y = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(y).Item("playoffsDistrict") = (x + 1) Then
                    If IsDuplicateGame(ds.Tables(0).Rows(y).Item("TeamID"), ds.Tables(0).Rows(y).Item("oTeamID"), ds.Tables(0).Rows(y).Item("TotalScore"), ds.Tables(0).Rows(y).Item("oTotalScore"), ds.Tables(0).Rows(y).Item("gamedate"), ds.Tables(0).Rows(y).Item("gametime")) Then
                        ' Skip it...
                    Else
                        ' Get the Results...
                        If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                            strGame = "<strong>" & ds.Tables(0).Rows(y).Item("SchoolName") & "</strong>"
                        ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                            strGame = ds.Tables(0).Rows(y).Item("SchoolName")
                        Else
                            strGame = ds.Tables(0).Rows(y).Item("SchoolName")
                        End If
                        ' Opponent...
                        If ds.Tables(0).Rows(y).Item("oSchoolName") Is System.DBNull.Value Then
                            If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                                strGame = strGame & " vs <strong>" & ds.Tables(0).Rows(y).Item("OtherTeam") & "</strong>"
                            Else
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            End If
                        Else
                            If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("oSchoolName")
                            ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                                strGame = strGame & " vs <strong>" & ds.Tables(0).Rows(y).Item("oSchoolName") & "</strong>"
                            Else
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("oSchoolName")
                            End If
                        End If
                        ' Score...
                        If ds.Tables(0).Rows(y).Item("TotalScore") = 0 And ds.Tables(0).Rows(y).Item("oTotalScore") = 0 Then
                            strGame = strGame & " " & ds.Tables(0).Rows(y).Item("gameDate") & " @ " & ds.Tables(0).Rows(y).Item("gameTime")
                        Else
                            strGame = strGame & " <strong><span style='color:maroon;'>" & ds.Tables(0).Rows(y).Item("TotalScore") & "-" & ds.Tables(0).Rows(y).Item("oTotalScore") & "</span></strong>"
                        End If
                        strDetail = strDetail & strBullet & strSpan & strGame & "</span><br>"
                    End If
                End If
            Next y
            strReturn = strReturn & strHeader & strDetail
            strReturn = strReturn & "<hr><br>"
        Next x

        Return strReturn
    End Function

    Public Function IsDuplicateGame(ByVal teamID As Long, ByVal oTeamID As Long, ByVal totalScore As Integer, ByVal ototalScore As Integer, ByVal dtmDate As Date, ByVal strTime As String) As Boolean
        Dim ysnDuplicate As Boolean = False
        Dim strKey As String = ""
        Dim strKeySwap As String = ""

        strKey = CStr(teamID) & "-" & CStr(oTeamID) & "-" & CStr(totalScore) & "-" & CStr(ototalScore) & "-" & CStr(dtmDate) & "-" & strTime
        strKeySwap = CStr(oTeamID) & "-" & CStr(teamID) & "-" & CStr(ototalScore) & "-" & CStr(totalScore) & "-" & CStr(dtmDate) & "-" & strTime

        ' First, compare against the keys...
        If strKey1 = "" Then
            ysnDuplicate = False
        Else
            If strKey1 = strKey Then
                ysnDuplicate = True
            Else
                If strKey2 = strKey Then
                    ysnDuplicate = True
                Else
                    If strKey3 = strKey Then
                        ysnDuplicate = True
                    Else
                        If strKey4 = strKey Then
                            ysnDuplicate = True
                        Else
                            ysnDuplicate = False
                        End If
                    End If
                End If
            End If
        End If

        ' Now get the next key for next time...
        If strKey1 = "" Then
            strKey1 = strKeySwap
        ElseIf strKey2 = "" Then
            strKey2 = strKeySwap
        ElseIf strKey3 = "" Then
            strKey3 = strKeySwap
        Else
            strKey4 = strKeySwap
        End If

        Return ysnDuplicate
    End Function

    Private Sub cboClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        If rowHeader.Visible Then
            Session("gScoreboardClass") = cboClass.SelectedValue
        End If
        Session("content") = InitializeDataSet(cboClass.SelectedValue, intDistricts)
        RefreshHeader()
    End Sub

    Public Sub RefreshHeader()
        Dim strSport As String = ""
        strSport = "Baseball (Fall) Schedules "
        If Session("gScoreboardClass") = "" Or Session("gScoreboardClass") = "ALL" Then
            If cboClass.SelectedValue = "" Then
            ElseIf cboClass.SelectedValue = "Select..." Then
            Else
                strSport = strSport & "for ALL Classes"
            End If
        Else
            strSport = strSport & "for Class " & Session("gScoreboardClass")
        End If
        lblSport.Text = strSport
    End Sub

End Class
