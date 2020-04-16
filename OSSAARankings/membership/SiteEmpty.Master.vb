Public Class SiteEmpty
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") = "" Then
            Me.lblWelcome.Text = "Please login"
        Else
            Me.lblWelcome.Text = "Welcome <b>" & Session("user") & "</b> at <b>" & Session("school") & "</b>&nbsp;"
        End If
    End Sub

End Class