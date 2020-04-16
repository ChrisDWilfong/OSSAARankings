Public Class adSports
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtLogin.Text = "" Then
        Else
            Session("login") = txtLogin.Text
        End If
        If Session("login") = "" Then
            GridView1.Visible = False
        ElseIf Session("login") = "ossaarocks" Then
            GridView1.Visible = True
        End If
    End Sub

End Class