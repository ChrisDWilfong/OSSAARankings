Public Class adPictures
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If txtLogin.Text = "" Then
        Else
            Session("login") = txtLogin.Text
        End If
        If Session("login") = "" Then
            GridView1.Visible = False
            cmdGo.Visible = True
            txtLogin.Visible = True
        ElseIf Session("login") = "ossaarocks" Then
            GridView1.Visible = True
            cmdGo.Visible = False
            txtLogin.Visible = False
        End If
    End Sub

End Class