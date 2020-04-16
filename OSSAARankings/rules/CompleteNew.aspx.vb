Public Class CompleteNew
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("key") = "DONE"
    End Sub

End Class