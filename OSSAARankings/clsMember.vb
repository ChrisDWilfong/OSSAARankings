Public Class clsMember

    Public gFirstName As String
    Public gLastName As String
    Public gFullName As String
    Public gUsername As String
    Public gPassword As String
    Public gEmailMain As String
    Public gEmailAlt As String
    Public gPhoneMain As String
    Public gPhoneAlt As String
    Public gMemberID As Long

    Public gRole As String
    Public gTitle As String
    Public gSchool As String
    Public gSchoolID As Long
    Public gGender As String
    Public gClass As String
    Public gSport As String
    Public gGenderClassSport As String

    Public Sub New(ByVal intMemberID As Long, ysnAD As Boolean)
        Dim strSQL As String = ""
        Dim ds As DataSet

        ' ''If ysnAD = False Then
        ' ''    strSQL = strSQL & "SELECT tblMembers.*, tblSchools.School, tblSports.Class, tblSports.Gender, tblSports.Sport "
        ' ''    strSQL = strSQL & "FROM tblTeams INNER JOIN "
        ' ''    'strSQL = strSQL & "tblCoachTeams ON tblTeams.teamID = tblCoachTeams.TeamID INNER JOIN "
        ' ''    strSQL = strSQL & "tblSchool ON tblTeams.schoolID = tblSchool.schoolID INNER JOIN "
        ' ''    strSQL = strSQL & "tblSports ON tblTeams.sportID = tblSports.sportID "
        ' ''    'strSQL = strSQL & "RIGHT OUTER JOIN "
        ' ''    'strSQL = strSQL & "tblMembers ON tblCoachTeams.CoachID = tblMembers.MemberID "
        ' ''Else
        ' ''    strSQL = strSQL & "SELECT tblMembers.*, tblSchool.SchoolAbb AS school FROM tblMembers INNER JOIN "
        ' ''    strSQL = strSQL & "tblSchool ON tblMembers.SchoolID = tblSchool.schoolID "
        ' ''End If

        If ysnAD Then
            strSQL = "SELECT TOP 1 0 AS memberID, schoolID, AdminADFirst AS FirstName, AdminADLast AS LastName, AdminADEmail AS Username, "
            strSQL = strSQL & "Password3 AS Password, 'Athletic Director' AS Title, SchoolName AS School, 'AD' AS Role, "
            strSQL = strSQL & "AdminADEmail AS emailMain, AdminADEmail AS emailAlt, AdminADPhoneCell AS phoneMain, AdminADPhoneSchool AS phoneAlt"
            strSQL = strSQL & " FROM tblSchool WHERE schoolID = " & intMemberID
        Else
            strSQL = "SELECT TOP 1 dbo.tblSchool.SchoolAbb AS School, dbo.tblMembers.MemberID, dbo.tblMembers.Username, dbo.tblMembers.Password, dbo.tblMembers.Role, "
            strSQL = strSQL & "dbo.tblMembers.SchoolID, dbo.tblMembers.FirstName, dbo.tblMembers.LastName, dbo.tblMembers.Title, dbo.tblMembers.emailMain, dbo.tblMembers.emailAlt, "
            strSQL = strSQL & "dbo.tblMembers.phoneMain, dbo.tblMembers.phoneAlt, dbo.tblMembers.homePhone, dbo.tblMembers.reqRecord, dbo.tblMembers.intYear, dbo.tblMembers.tschool, "
            strSQL = strSQL & "dbo.tblMembers.intActive, dbo.tblMembers.Username1, dbo.tblMembers.Password1, dbo.tblMembers.intRankings, dbo.tblMembers.dtmStamp, "
            strSQL = strSQL & "dbo.tblSchool.SchoolName "
            strSQL = strSQL & "FROM dbo.tblSchool INNER JOIN "
            strSQL = strSQL & "dbo.tblMembers ON dbo.tblSchool.schoolID = dbo.tblMembers.SchoolID "
            strSQL = strSQL & "WHERE (dbo.tblMembers.MemberID = " & intMemberID & " AND dbo.tblMembers.intActive <> 0)"
        End If

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                gMemberID = .Item("memberID")
                gSchoolID = .Item("schoolID")
                gFullName = .Item("FirstName") & " " & .Item("LastName")
                Try
                    gFirstName = .Item("FirstName")
                Catch
                    gFirstName = ""
                End Try
                Try
                    gLastName = .Item("LastName")
                Catch
                    gLastName = ""
                End Try
                Try
                    gUsername = .Item("Username")
                Catch
                    gUsername = ""
                End Try
                Try
                    gPassword = .Item("Password")
                Catch
                    gPassword = ""
                End Try
                Try
                    gTitle = .Item("Title")
                Catch
                    gTitle = ""
                End Try
                If .Item("School") Is System.DBNull.Value Then
                    gSchool = 0
                Else
                    gSchool = .Item("School")
                End If
                'If ysnAD = False Then
                '    If .Item("Gender") Is System.DBNull.Value Then
                '        gGender = ""
                '    Else
                '        gGender = .Item("Gender")
                '    End If
                '    If .Item("Class") Is System.DBNull.Value Then
                '        gClass = ""
                '    Else
                '        gClass = .Item("Class")
                '    End If
                '    If .Item("Sport") Is System.DBNull.Value Then

                '    Else
                '        gSport = .Item("Sport")
                '    End If
                '    gGenderClassSport = gGender & " " & gGender & " " & gSport
                'End If

                Try
                    gRole = .Item("Role")
                Catch
                    gRole = ""
                End Try

                If .Item("emailMain") Is System.DBNull.Value Then
                    gEmailMain = ""
                Else
                    gEmailMain = .Item("emailMain")
                End If
                If .Item("emailAlt") Is System.DBNull.Value Then
                    gEmailAlt = ""
                Else
                    gEmailAlt = .Item("emailAlt")
                End If
                If .Item("phoneMain") Is System.DBNull.Value Then
                    gPhoneMain = ""
                Else
                    gPhoneMain = .Item("phoneMain")
                End If
                If .Item("phoneAlt") Is System.DBNull.Value Then
                    gPhoneAlt = ""
                Else
                    gPhoneAlt = .Item("phoneAlt")
                End If
            End With
        End If

    End Sub

End Class
