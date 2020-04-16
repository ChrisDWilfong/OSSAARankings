Public Class clsLog

    Shared Function GetBrowserInfo(objRequestBrowser As String) As String
        On Error Resume Next
        Dim strReturn As String

        'strReturn = objRequestBrowser.Type & " : " & objRequestBrowser.Platform
        strReturn = Left(objRequestBrowser, 499)

        'ltlAllData.Text = "Type = " & Request.Browser.Type & "<br>"
        'ltlAllData.Text &= "Name = " & Request.Browser.Browser & "<br>"
        'ltlAllData.Text &= "Version = " & Request.Browser.Version & "<br>"
        'ltlAllData.Text &= "Major Version = " & Request.Browser.MajorVersion & "<br>"
        'ltlAllData.Text &= "Minor Version = " & Request.Browser.MinorVersion & "<br>"
        'ltlAllData.Text &= "Platform = " & Request.Browser.Platform & "<br>"
        'ltlAllData.Text &= "Is Beta = " & Request.Browser.Beta & "<br>"
        'ltlAllData.Text &= "Is Crawler = " & Request.Browser.Crawler & "<br>"
        'ltlAllData.Text &= "Is AOL = " & Request.Browser.AOL & "<br>"
        'ltlAllData.Text &= "Is Win16 = " & Request.Browser.Win16 & "<br>"
        'ltlAllData.Text &= "Is Win32 = " & Request.Browser.Win32 & "<br>"
        'ltlAllData.Text &= "Supports Frames = " & Request.Browser.Frames & "<br>"
        'ltlAllData.Text &= "Supports Tables = " & Request.Browser.Tables & "<br>"
        'ltlAllData.Text &= "Supports Cookies = " & Request.Browser.Cookies & "<br>"
        'ltlAllData.Text &= "Supports VB Script = " & Request.Browser.VBScript & "<br>"
        'ltlAllData.Text &= "Supports JavaScript = " & Request.Browser.JavaScript & "<br>"
        'ltlAllData.Text &= "Supports Java Applets = " & Request.Browser.JavaApplets & "<br>"
        'ltlAllData.Text &= "CDF = " & Request.Browser.CDF & "<br>"

        Return strReturn

    End Function

    Shared Sub LogEntryForm(strSchoolName As String, intSchoolID As Long, memberID As Long, strSubmittedBy As String, strSport As String, strSQL As String)
        Dim strSQLLog As String = "INSERT INTO prodLogEntryForms (strSchoolName, intSchoolID, memberID, strSport, strSubmittedBy, strSQL) VALUES ('" & strSchoolName & "', " & intSchoolID & ", " & memberID & ",'" & strSport & "', '" & strSubmittedBy & "', '" & strSQL.Replace("'", "") & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQLLog)
    End Sub

    Shared Sub LogSQL(strSQL As String, strIP As String, strEvent As String)
        Dim strSQLLog As String = "INSERT INTO tblSQLLog (strSQL, strIP, strEvent) VALUES "
        strSQLLog = strSQLLog & "('" & strSQL.Replace("'", "") & "','" & strIP & "', '" & strEvent & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQLLog)
    End Sub
    Shared Sub LogUser(ByVal strUserName As String, ByVal strType As String, ByVal intKey As Integer, ByVal strOrganizationType As String, ByVal strSchoolName As String, objRequestBrowser As String)
        Dim strSQL As String

        Dim strBrowser As String = GetBrowserInfo(objRequestBrowser)

        If strSchoolName = "" Then
            strSQL = "INSERT INTO tblSchoolLog (Username, OrganizationType, SchoolId, strBrowser, strType) VALUES ("
        Else
            strSQL = "INSERT INTO tblSchoolLog (Username, OrganizationType, SchoolId, SchoolName, strBrowser, strType) VALUES ("
        End If
        strSQL = strSQL & "'" & strUserName & "', "
        strSQL = strSQL & "'" & strOrganizationType & "', "
        strSQL = strSQL & intKey & ", "
        If strSchoolName = "" Then
        Else
            strSQL = strSQL & "'" & strSchoolName & "', "
        End If
        strSQL = strSQL & "'" & strBrowser & "', "
        strSQL = strSQL & "'" & strType & "')"

        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
        Catch ex As Exception

        End Try

    End Sub

End Class
