Imports Microsoft.VisualBasic
Imports System.Data

Public Class clsSchool

    Public getSchool As String
    Public getAddress As String
    Public getCity As String
    Public getState As String
    Public getZip As String
    'Public getMascotImage As String
    Public getMascot As String
    'Public getColor1 As String
    'Public getColor2 As String

    Public Sub New(ByVal strSchool As String, ByVal intSchoolID As Integer)
        Dim strSQL As String
        Dim ds As DataSet

        If intSchoolID = 0 Then
            strSQL = "SELECT * FROM tblSchool WHERE SchoolName = '" & strSchool & "'"
        Else
            strSQL = "SELECT * FROM tblSchool WHERE schoolID = " & intSchoolID
        End If

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                getSchool = .Item("schoolName")
                Try
                    getAddress = .Item("StreetAddress")
                Catch
                    getAddress = ""
                End Try
                Try
                    getCity = .Item("StreetCity")
                Catch
                    getCity = ""
                End Try
                Try
                    getState = .Item("StreetState")
                Catch
                    getState = ""
                End Try
                Try
                    getZip = .Item("StreetZip")
                Catch
                    getZip = ""
                End Try
                If .Item("Schoolmascot") Is System.DBNull.Value Then getMascot = "" Else getMascot = .Item("Schoolmascot")
                'If .Item("mascotimage") Is System.DBNull.Value Then getMascotImage = "" Else getMascotImage = .Item("mascotImage")
                'If getMascotImage = "" Then
                'Else
                '    getMascotImage = "~/images/mascots/" & getMascotImage
                'End If
                'If .Item("TeamColor1") Is System.DBNull.Value Then getColor1 = "" Else getColor1 = .Item("TeamColor1")
                'If .Item("TeamColor2") Is System.DBNull.Value Then getColor2 = "" Else getColor2 = .Item("TeamColor2")
            End With
        End If

        ' OLD...
        ' ''If intSchoolID = 0 Then
        ' ''    strSQL = "SELECT * FROM tblSchools WHERE school = '" & strSchool & "'"
        ' ''Else
        ' ''    strSQL = "SELECT * FROM tblSchools WHERE schoolID = " & intSchoolID
        ' ''End If

        ' ''ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        ' ''If ds Is Nothing Then
        ' ''ElseIf ds.Tables.Count = 0 Then
        ' ''ElseIf ds.Tables(0).Rows.Count = 0 Then
        ' ''Else
        ' ''    With ds.Tables(0).Rows(0)
        ' ''        getSchool = .Item("school")
        ' ''        getAddress = .Item("address")
        ' ''        getCity = .Item("city")
        ' ''        getState = .Item("state")
        ' ''        getZip = .Item("zip")
        ' ''        If .Item("mascot") Is System.DBNull.Value Then getMascot = "" Else getMascot = .Item("mascot")
        ' ''        If .Item("mascotimage") Is System.DBNull.Value Then getMascotImage = "" Else getMascotImage = .Item("mascotImage")
        ' ''        If getMascotImage = "" Then
        ' ''        Else
        ' ''            getMascotImage = "~/images/mascots/" & getMascotImage
        ' ''        End If
        ' ''        If .Item("TeamColor1") Is System.DBNull.Value Then getColor1 = "" Else getColor1 = .Item("TeamColor1")
        ' ''        If .Item("TeamColor2") Is System.DBNull.Value Then getColor2 = "" Else getColor2 = .Item("TeamColor2")
        ' ''    End With
        ' ''End If


    End Sub

    Shared Function LoadSchedulesListAll(schoolID As Long) As DataSet
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT tblTeams.teamID, tblTeams.sportID, tblSports.SportGenderKey, tblSports.GenderSport1, dbo.tblSports.Class AS strClass "
        strSQL = strSQL & "FROM tblTeams INNER JOIN tblSports ON tblTeams.sportID = tblSports.sportID "
        ' TODO DEBUG... Change this...
        strSQL = strSQL & "WHERE tblTeams.schoolID = " & schoolID & " AND tblTeams.intYear = " & clsFunctions.GetCurrentYear
        strSQL = strSQL & "ORDER BY tblSports.GenderSport1"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds
    End Function


End Class
