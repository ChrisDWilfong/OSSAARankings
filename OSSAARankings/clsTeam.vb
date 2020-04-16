Imports System.Data
Imports Microsoft.VisualBasic

Public Class clsTeam

    Public getSportGenderDisplay As String
    Public getSportGenderDisplay1 As String
    Public getSportGenderKey As String
    Public getSportGenderKey1 As String
    Public getMemberID As Long
    Public getSportID As String
    Public getSportID1 As String
    Public getSchoolID As Integer
    Public getTeamID As Integer
    Public getSchool As String
    Public getSchoolDisplay As String
    Public getHeadCoach As String
    Public getClass As String
    Public getClass1 As String
    Public getGender As String
    Public getSport As String
    Public getSportWithClass As String
    Public getSportWithClass1 As String
    Public getWL As String
    Public getW As String
    Public getL As String
    Public getMascot As String
    Public getDistrict As Integer
    'Public getSportImage As String
    'Public getSportImageMember As String
    Public getCurrentRecord As String
    Public getCurrentRank As String
    Public getPlayoffSchedule As String          ' 11/4/2013 added...
    Public getTeamPicture As String
    Public getTeamPictureShow As Boolean
    Public getShowRecord As Integer
    Public getShowRanking As Integer
    Public getResults As Integer
    Public getPostGender As String
    Public getPlayoffsState As Integer
    Public getPlayoffsArea As Integer
    Public getPlayoffsRegional As Integer
    Public getPlayoffsDistrict As Integer

    Public Sub New(ByVal intTeamID As Integer)
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT dbo.tblTeams.teamID, dbo.tblTeams.sportID, dbo.tblTeams.sportID1, dbo.tblTeams.memberID, dbo.tblTeams.District, dbo.tblTeams.TeamPicture, dbo.tblTeams.TeamPictureView, dbo.tblTeams.playoffsDistrict, dbo.tblTeams.playoffsRegional, dbo.tblTeams.playoffsArea, dbo.tblTeams.playoffsState, dbo.tblSports.Class, dbo.tblSports.Gender, "
        strSQL = strSQL & "dbo.tblSports.Sport, dbo.tblSports.SportGenderKey, dbo.tblSports.GenderSport, dbo.tblSports.SportDisplay, dbo.tblSports.GenderSport1, "
        strSQL = strSQL & "dbo.tblSports.strSchedulesTable, dbo.tblSports.intShowRecord, dbo.tblSports.intRankings, dbo.tblSports.intResults, dbo.tblSports.strPostGender, dbo.tblSports.strPlayoffSchedule, dbo.tblSchool.schoolID, "
        strSQL = strSQL & "dbo.tblSchool.SchoolAbb AS School, dbo.tblTeams.SchoolName AS schoolDisplay, dbo.tblTeams.W, dbo.tblTeams.L, dbo.tblMembers.FirstName, "
        strSQL = strSQL & "dbo.tblMembers.LastName, dbo.tblMembers.FirstName + ' ' + dbo.tblMembers.LastName AS FullName "
        strSQL = strSQL & "FROM dbo.tblTeams INNER JOIN "
        strSQL = strSQL & "dbo.tblSports ON dbo.tblTeams.sportID = dbo.tblSports.sportID INNER JOIN "
        strSQL = strSQL & "dbo.tblSchool ON dbo.tblTeams.schoolID = dbo.tblSchool.schoolID LEFT OUTER JOIN "
        strSQL = strSQL & "dbo.tblMembers ON dbo.tblTeams.memberID = dbo.tblMembers.MemberID "
        strSQL = strSQL & "WHERE dbo.tblTeams.teamID = " & intTeamID

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                getSportGenderDisplay = .Item("GenderSport1")

                getSportGenderKey = .Item("SportGenderKey")
                If getSportGenderKey = "Wrestling" Then
                    getSportGenderKey1 = "WrestlingDual"
                    getSportGenderDisplay1 = "Wrestling (Dual)"
                Else
                    getSportGenderKey1 = ""
                    getSportGenderDisplay1 = ""
                End If
                getSportID = .Item("sportID")
                If .Item("sportID1") Is System.DBNull.Value Then
                    getSportID1 = ""
                Else
                    getSportID1 = .Item("sportID1")
                End If
                getTeamID = .Item("teamID")
                getMemberID = .Item("memberID")
                getSchoolID = .Item("schoolID")
                getSchool = .Item("school")
                getDistrict = .Item("district")
                getSchoolDisplay = .Item("schoolDisplay")
                getPlayoffsDistrict = .Item("playoffsDistrict")
                getPlayoffsRegional = .Item("playoffsRegional")
                getPlayoffsArea = .Item("playoffsArea")
                getPlayoffsState = .Item("playoffsState")
                If .Item("strPlayoffSchedule") Is System.DBNull.Value Then
                    getPlayoffSchedule = ""
                Else
                    getPlayoffSchedule = .Item("strPlayoffSchedule")
                End If
                If .Item("strPostGender") Is System.DBNull.Value Then
                    getPostGender = ""
                Else
                    getPostGender = .Item("strPostGender")
                End If
                If .Item("teamPicture") Is System.DBNull.Value Then
                    getTeamPicture = ""
                Else
                    getTeamPicture = .Item("teamPicture")
                End If
                getTeamPictureShow = .Item("TeamPictureView")           ' 8/9/2103 added...
                If .Item("LastName") Is System.DBNull.Value Then
                    getHeadCoach = "Info Not Available"
                ElseIf .Item("LastName") = "Coach" Then
                    getHeadCoach = "Info Not Available"
                Else
                    getHeadCoach = .Item("FirstName") & " " & .Item("LastName")
                End If
                getClass = .Item("Class")
                ' 10/31/2013 added...
                If .Item("sportID1") Is System.DBNull.Value Then
                    getClass1 = ""
                Else
                    Dim strSportID1 As String = .Item("sportID1")
                    If strSportID1.Contains("2A") Then
                        getClass1 = "2A"
                    ElseIf strSportID1.Contains("3A") Then
                        getClass1 = "3A"
                    ElseIf strSportID1.Contains("4A") Then
                        getClass1 = "4A"
                    ElseIf strSportID1.Contains("5A") Then
                        getClass1 = "5A"
                    ElseIf strSportID1.Contains("6A") Then
                        getClass1 = "6A"
                    End If
                End If
                getSport = .Item("Sport")
                If getSport = "Basketball" Or getSport = "Track" Or getSport = "Tennis" Or getSport = "Golf" Or getSport = "Soccer" Then
                    getGender = .Item("Gender")
                Else
                    getGender = ""
                End If

                ' Calculate Wins and Losses...
                Dim intWins As Integer = 0
                Dim intLosses As Integer = 0
                clsTeams.GetCalcWLTeam(.Item("teamID"), intWins, intLosses, True)
                getW = intWins
                getL = intLosses
                getWL = intWins & "-" & intLosses
                getCurrentRecord = "Current Record (" & getWL & ")"
                getMascot = ""

                getCurrentRank = clsRankings.GetCurrentRank(.Item("sportID"), .Item("teamID"), Now)

                If getGender = "" Then
                    'If getSport = "Volleyball" Then         ' Temporary 8/14/2015...
                    '    getSportWithClass = "Class " & getClass & " (tentitive) " & getSportGenderDisplay
                    '    getSportWithClass1 = "Class " & getClass1 & " (tentitive) " & getSportGenderDisplay1
                    'Else
                    getSportWithClass = "Class " & getClass & " " & getSportGenderDisplay
                    getSportWithClass1 = "Class " & getClass1 & " " & getSportGenderDisplay1
                    'End If
                Else
                getSportWithClass = "Class " & getClass & " " & getGender & " " & getSportGenderDisplay
                getSportWithClass1 = "Class " & getClass1 & " " & getSportGenderDisplay1
                End If

                    getShowRecord = .Item("intShowRecord")
                    getShowRanking = .Item("intRankings")
                    getResults = .Item("intResults")

                    '                getSportImage = "images/" & getSport & ".gif"
                    '               getSportImageMember = "../images/" & getSport & ".gif"

            End With
        End If

    End Sub

End Class
