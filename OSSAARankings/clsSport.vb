Public Class clsSport

    Public getSportID As String
    Public getClass As String
    Public getGender As String
    Public getSport As String
    Public getSportGenderKey As String
    Public getGenderSport As String
    Public getSportDisplay As String
    Public getNumberOfRankings As Integer
    Public getNumberOfRankingsShow As Integer
    Public getintRankings As Integer
    Public getintSchedules As Integer
    Public getintDistrictStandings As Integer
    Public getGenderSport1 As String
    Public getSeason As String
    Public getActivityAbb As String
    Public getActivityClassifyAbb As String

    Public Sub New(ByVal strSportID As String)
        Dim ds As DataSet
        Dim strSQL As String

        strSQL = "SELECT * FROM tblSports WHERE sportID = '" & strSportID & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                getSportID = .Item("sportID")
                getClass = .Item("class")
                getGender = .Item("gender")
                getSport = .Item("sport")
                getSportGenderKey = .Item("SportGenderKey")
                getGenderSport = .Item("GenderSport")
                getSportDisplay = .Item("SportDisplay")
                getNumberOfRankings = .Item("NumberOfRankings")
                getNumberOfRankingsShow = .Item("NumberOfRankingsShow")
                getintDistrictStandings = .Item("intDistrictStandings")
                getGenderSport1 = .Item("GenderSport1")
                getSeason = .Item("strSeason")
                getActivityAbb = .Item("strActivityAbb")
                getActivityClassifyAbb = .Item("strActivityClassifyAbb")
            End With
        End If

    End Sub

End Class
