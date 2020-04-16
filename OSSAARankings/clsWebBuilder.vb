Public Class clsWebBuilder

    Shared Function BuildPage(strSite As String, strType As String, strTableWidth As String) As String
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim strResult As String = ""
        Dim x As Integer

        strSQL = "SELECT [Id], [strDescription], [strLink], [strLineType] FROM [tblDashboardLinks] WHERE (([strSite] = '" & strSite & "') AND ([strType] = '" & strType & "') AND ([intYear] = " & clsFunctions.GetCurrentYear & ") AND (intSort > 0)) ORDER BY intSort DESC"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            strResult = "<table runat='server' style='width: " & strTableWidth & ";'>"

            For x = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(x).Item("strLineType") = "RedHeading" Then
                    If x = 0 Then
                        ' Skip it...
                    Else
                        strResult = strResult & "<tr><td>&nbsp;</td></tr>"
                    End If
                End If
                strResult = strResult & "<tr>"
                Select Case ds.Tables(0).Rows(x).Item("strLineType")
                    Case "RedHeading"
                        strResult = strResult & "<td style='color: White; font-family: Arial; font-size: medium; background-color: maroon; height:28px;'><strong>&nbsp;" & ds.Tables(0).Rows(x).Item("strDescription") & "</strong></td>"
                    Case "Text"
                        strResult = strResult & "<td><span style='font-size: 14px; font-family: Arial; color:Black;'>" & ds.Tables(0).Rows(x).Item("strDescription") & "</span></td>"
                    Case "TextBold"
                        strResult = strResult & "<td><span style='font-size: 14px; font-family: Arial; color:Black;'><strong>" & ds.Tables(0).Rows(x).Item("strDescription") & "</strong></span></td>"
                    Case "Link"
                        strResult = strResult & "<td>&nbsp;<img width='10' height='10' src='Button.gif' />&nbsp;<a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'><span style='font-size: 14px; font-family: Arial;'>" & ds.Tables(0).Rows(x).Item("strDescription") & "</span></a></td>"
                    Case "LinkBold"
                        strResult = strResult & "<td>&nbsp;<img width='10' height='10' src='Button.gif' />&nbsp;<a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'><span style='font-size: 14px; font-family: Arial;'><strong>" & ds.Tables(0).Rows(x).Item("strDescription") & "</strong></span></a></td>"
                    Case "LinkImage"
                        strResult = strResult & "<td>&nbsp;<img width='10' height='10' src='Button.gif' />&nbsp;<a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'><img src='" & ds.Tables(0).Rows(x).Item("strDescription") & "'></img></a></td>"
                    Case Else
                        strResult = strResult & "<td>&nbsp;</td>"
                End Select
                strResult = strResult & "</tr>"
            Next

            strResult = strResult & "</table>"

        End If

        Return strResult

    End Function
End Class
