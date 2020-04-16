Public Class ucTestContent
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Me.Label1.Text = Now & " page load"
            Me.Label2.Text = Now & " page load 2 (0)"
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As System.EventArgs) Handles cmdRefresh.Click
        Me.Label2.Text = Now
    End Sub
End Class