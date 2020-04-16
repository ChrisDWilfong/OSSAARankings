Imports System.Data

Partial Class ucViewScheduleFBBState

    Inherits System.Web.UI.UserControl
    Shared cboClassList As String
    Shared strKey1 As String
    Shared strKey2 As String
    Shared strKey3 As String
    Shared strKey4 As String
    Shared intStates As Integer = 8
    Shared gSportGenderKey As String = "BaseballFall"
    Shared gTourneyKey As String = "BaseballFallSTATE"
    Shared gSportDisplay As String = "Baseball (Fall)"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gSportGenderKey") = gSportGenderKey
        Session("gSportDisplay") = gSportDisplay

        If Not IsPostBack Then
            Session("scoreboardscrollerClass") = InitializeDataSet(Session("gScoreboardClass"), intStates)
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
        Dim y As Integer
        Dim strSQL As String
        Dim strSpan As String = "<span style='font-family:Segoe UI, Verdana, Helvetica, sans-serif; font-size:10pt; font-weight:normal;'>"
        Dim strBullet As String = "<img src='../images/ig_treeBlack_box.gif'>&nbsp;"
        Dim strSpanBold As String = "<span style='font-family:Segoe UI, Verdana, Helvetica, sans-serif; font-weight:bold; font-size:12pt;'>"
        Dim ds As DataSet
        Dim strHeader As String
        Dim strDetail As String
        Dim strGame As String = ""

        strSQL = "SELECT tblTeams.SchoolName, tblTeams_1.SchoolName AS oSchoolName, dbo.tblTeams.playoffsState, "
        strSQL = strSQL & "dbo.tblTeams.ysnHostState, dbo.tblSchedules.teamID, dbo.tblSchedules.oTeamID, dbo.tblSchedules.sportID, "
        strSQL = strSQL & "dbo.tblSports.strPlayoffsScheduleShowState, dbo.tblSchedules.gamedate, dbo.tblSchedules.gametime, dbo.tblSchedules.intGame, "
        strSQL = strSQL & "dbo.tblSchedules.OtherTeam, dbo.tblSchedules.Location, dbo.tblSchedules.Tournament, dbo.tblSchedules.TotalScore, "
        strSQL = strSQL & "dbo.tblSchedules.oTotalScore, dbo.tblSchedules.scheduleID, dbo.tblTeams.WL AS WL, tblTeams_1.WL AS oWL "
        strSQL = strSQL & "FROM dbo.tblSchedules LEFT OUTER JOIN dbo.tblTeams AS tblTeams_1 "
        strSQL = strSQL & "ON dbo.tblSchedules.oTeamID = tblTeams_1.teamID LEFT OUTER JOIN dbo.tblSports "
        strSQL = strSQL & "ON dbo.tblSchedules.sportID = dbo.tblSports.sportID LEFT OUTER JOIN dbo.tblTeams "
        strSQL = strSQL & "ON dbo.tblSchedules.teamID = dbo.tblTeams.teamID "
        strSQL = strSQL & "WHERE (dbo.tblSchedules.sportID = '" & gSportGenderKey & strSportID & "') "
        strSQL = strSQL & "AND (dbo.tblSchedules.strType = 'TOSSAAS') AND (dbo.tblSchedules.ysnActive > 0) "
        strSQL = strSQL & "ORDER BY tblSchedules.NeutralSiteID, tblSchedules.gameDate, tblSchedules.intGame"

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        'For x = 0 To intRows - 1
        strHeader = ""
        strDetail = ""
        strKey1 = ""
        strKey2 = ""
        strKey3 = ""
        strKey4 = ""

        For y = 0 To ds.Tables(0).Rows.Count - 1
            ' Header...
            strHeader = ""
            If y = 0 Then
                strHeader = strSpanBold & "<br>State Quarterfinals @ " & GetLocation(ds.Tables(0).Rows(y).Item("SportID"), gTourneyKey, "Q") & "</span><br>"
            ElseIf y = 8 Then
                strHeader = strSpanBold & "<br>State Semi-Finals @ " & GetLocation(ds.Tables(0).Rows(y).Item("SportID"), gTourneyKey, "S") & "</span><br>"
            ElseIf y = 11 Then
                strHeader = strSpanBold & "<br>State Championship @ " & GetLocation(ds.Tables(0).Rows(y).Item("SportID"), gTourneyKey, "F") & "</span><br>"
            End If
            If IsDuplicateGame(ds.Tables(0).Rows(y).Item("TeamID"), ds.Tables(0).Rows(y).Item("oTeamID"), ds.Tables(0).Rows(y).Item("TotalScore"), ds.Tables(0).Rows(y).Item("oTotalScore"), ds.Tables(0).Rows(y).Item("gamedate"), ds.Tables(0).Rows(y).Item("gametime")) Then
                ' Skip it...
            Else
                ' Get the Results...
                If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                    strGame = "<strong>" & ds.Tables(0).Rows(y).Item("SchoolName") & " (" & ds.Tables(0).Rows(y).Item("WL") & ")" & "</strong>"
                ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                    strGame = ds.Tables(0).Rows(y).Item("SchoolName") & " (" & ds.Tables(0).Rows(y).Item("WL") & ")"
                Else
                    Try
                        If ds.Tables(0).Rows(y).Item("WL") Is System.DBNull.Value Then
                            strGame = ds.Tables(0).Rows(y).Item("SchoolName")
                        Else
                            strGame = ds.Tables(0).Rows(y).Item("SchoolName") & " (" & ds.Tables(0).Rows(y).Item("WL") & ")"
                        End If
                    Catch
                        strGame = ""
                    End Try
                End If
                ' Semi-Final or Final with no scores...
                If ds.Tables(0).Rows(y).Item("oSchoolName") Is System.DBNull.Value Then
                    If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                        If ds.Tables(0).Rows(y).Item("OtherTeam") = "BYE" Then
                            strGame = strGame & " (BYE)"
                        Else
                            If ds.Tables(0).Rows(y).Item("OtherTeam") = "State Championship" Or ds.Tables(0).Rows(y).Item("teamID") = 0 Then
                                strGame = strGame & " " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            Else
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            End If
                        End If
                    ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                        strGame = strGame & " vs <strong>" & ds.Tables(0).Rows(y).Item("OtherTeam") & "</strong>"
                    Else
                        Try
                            If ds.Tables(0).Rows(y).Item("OtherTeam") = "State Championship" Or ds.Tables(0).Rows(y).Item("teamID") = 0 Then
                                strGame = strGame & " " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            Else
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("OtherTeam")
                            End If
                        Catch
                            strGame = ""
                        End Try
                    End If
                Else
                    ' =====================
                    If ds.Tables(0).Rows(y).Item("TotalScore") > ds.Tables(0).Rows(y).Item("oTotalScore") Then
                        strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("oSchoolName") & " (" & ds.Tables(0).Rows(y).Item("oWL") & ")"
                    ElseIf ds.Tables(0).Rows(y).Item("TotalScore") < ds.Tables(0).Rows(y).Item("oTotalScore") Then
                        strGame = strGame & " vs <strong>" & ds.Tables(0).Rows(y).Item("oSchoolName") & " (" & ds.Tables(0).Rows(y).Item("oWL") & ")" & "</strong>"
                    Else
                        If ds.Tables(0).Rows(y).Item("oSchoolName") = "BYE" Then
                            strGame = strGame & " (BYE)"
                        Else
                            If ds.Tables(0).Rows(y).Item("oSchoolName") = "State Championship" Or ds.Tables(0).Rows(y).Item("teamID") = 0 Then
                                strGame = strGame & " " & ds.Tables(0).Rows(y).Item("oSchoolName") & " (" & ds.Tables(0).Rows(y).Item("oWL") & ")"
                            Else
                                strGame = strGame & " vs " & ds.Tables(0).Rows(y).Item("oSchoolName") & " (" & ds.Tables(0).Rows(y).Item("oWL") & ")"
                            End If
                        End If
                    End If
                End If
                ' Score...
                If ds.Tables(0).Rows(y).Item("TotalScore") = 0 And ds.Tables(0).Rows(y).Item("oTotalScore") = 0 Then
                    If strGame.Contains("BYE") Then
                        ' No date/time...
                    Else
                        strGame = strGame & " " & ds.Tables(0).Rows(y).Item("gameDate") & " @ " & ds.Tables(0).Rows(y).Item("gameTime")
                    End If
                Else
                    strGame = strGame & " <strong><span style='color:maroon;'>" & ds.Tables(0).Rows(y).Item("TotalScore") & "-" & ds.Tables(0).Rows(y).Item("oTotalScore") & "</span></strong>"
                End If
                ' Add header...
                If strHeader = "" Then
                Else
                    strDetail = strDetail & strHeader
                End If
                strDetail = strDetail & strBullet & strSpan & strGame & "</span><br>"
            End If
            'End If
        Next y
        strReturn = strReturn & strDetail
        strReturn = strReturn & "<hr><br>"
        'Next x

        Return strReturn
    End Function

    Public Function GetLocation(ByVal strSportGenderKey As String, ByVal strTourneyKey As String, ByVal strLevel As String)
        Dim strLocation As String = ""
        Dim strAt As String = ""
        Dim ds As DataSet
        Dim strSQL As String
        strSQL = "SELECT * FROM ossaauser.tblSportsPlayoffsDetail WHERE TourneyKey = '" & strTourneyKey & "' AND strSportGenderKey = '" & strSportGenderKey & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Try
                strAt = ds.Tables(0).Rows(0).Item("strAt")
            Catch
            End Try

            Select Case strLevel
                Case "Q"
                    Try
                        strLocation = ds.Tables(0).Rows(0).Item("strGameNoTop1")
                    Catch
                    End Try
                    If strLocation = "" Then strLocation = strAt
                Case "S"
                    Try
                        strLocation = ds.Tables(0).Rows(0).Item("strGameNoTop5")
                    Catch
                    End Try
                    If strLocation = "" Then strLocation = strAt
                Case "F"
                    Try
                        strLocation = ds.Tables(0).Rows(0).Item("strGameNoTop7")
                    Catch
                    End Try
                    If strLocation = "" Then strLocation = strAt
            End Select
        End If
        strLocation = strLocation.Replace("@", "")
        Return strLocation
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
        Session("content") = InitializeDataSet(cboClass.SelectedValue, intStates)
        RefreshHeader()
    End Sub

    Public Sub RefreshHeader()
        Dim strSport As String = ""
        strSport = Session("gSportDisplay") & " State Schedules "
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
