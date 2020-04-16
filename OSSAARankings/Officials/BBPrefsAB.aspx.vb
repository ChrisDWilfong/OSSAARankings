Public Class BBPrefsAB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userEmail") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If
    End Sub

End Class