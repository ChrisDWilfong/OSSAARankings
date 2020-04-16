Public Class clsLinks

    Shared Function GetLinks(strSite As String, strType As String, intYear As Integer) As String
        Dim strLinks As String = ""
        Dim ds As DataSet
        Dim strSQL As String = ""
        Dim x As Integer = 0

        strSQL = "SELECT Id, strDescription, strLink, intSort FROM tblDashboardLinks WHERE strSite = '" & strSite & "' AND strType = '" & strType & "' AND intYear = " & intYear & " AND intSort > 0 ORDER BY intSort DESC"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strLinks = strLinks & "<tr><td>"
                strLinks = strLinks & "<img src='images/ArrowRight1.gif' />&nbsp;"
                strLinks = strLinks & "<span class='titleHeader'>"
                strLinks = strLinks & "<a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'>"
                strLinks = strLinks & ds.Tables(0).Rows(x).Item("strDescription")
                strLinks = strLinks & "</a></span></td></tr>"
            Next

        End If

        Return strLinks
    End Function

    Shared Function GetLinksNoTable(strSite As String, strType As String, intYear As Integer) As String
        Dim strLinks As String = ""
        Dim ds As DataSet
        Dim strSQL As String = ""
        Dim x As Integer = 0

        strSQL = "SELECT Id, strDescription, strLink, intSort FROM tblDashboardLinks WHERE strSite = '" & strSite & "' AND strType = '" & strType & "' AND intYear = " & intYear & " AND intSort > 0 ORDER BY intSort DESC"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strLinks = strLinks & "<img src='images/ArrowRight1.gif' />&nbsp;"
                strLinks = strLinks & "<span class='titleHeader'>"
                strLinks = strLinks & "<a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'>"
                strLinks = strLinks & ds.Tables(0).Rows(x).Item("strDescription")
                strLinks = strLinks & "</a></span><br>"
            Next

        End If

        Return strLinks

    End Function

End Class
