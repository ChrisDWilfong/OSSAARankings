Public Class ucSwimResults
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblHeaderMain.Text = "20" & clsFunctions.GetCurrentYear - 1 & "- 20" & clsFunctions.GetCurrentYear & " SWIM MEET RESULTS - OSSAARankings.com"
        Me.lblContent.Text = GetSwimResults()

    End Sub

    Public Function GetSwimResults() As String
        Dim strPC As String = ""
        Dim strSQL As String = ""
        Dim x As Integer
        Dim ds As DataSet

        strSQL = "SELECT * FROM tblDashboardLinks WHERE strSite = 'OSSAARankings' AND strType = 'SwimResults' AND intYear = " & clsFunctions.GetCurrentYear() & " AND intSort <> 0 ORDER BY intSort"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    strPC = strPC & "<style='font-size:small'><a href='" & ds.Tables(0).Rows(x).Item("strLink") & "' target='_blank'>" & ds.Tables(0).Rows(x).Item("strDescription") & "</a></style></br>"
                End With
            Next
        End If

        Return strPC
    End Function

End Class