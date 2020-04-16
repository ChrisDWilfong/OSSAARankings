Public Class ucContactUs
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblHeaderMain.Text = "Contact Information for " & Session("memgSportDisplay")
        Dim x As Integer
        Dim ds As DataSet
        Dim strContact As String = ""
        ds = clsSports.GetContactsDataset(Session("memgSport"))
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strContact = strContact & " * " & ds.Tables(0).Rows(x).Item("strContact") & "<br>"
            Next
        End If
        lblContent.Text = strContact
    End Sub

End Class