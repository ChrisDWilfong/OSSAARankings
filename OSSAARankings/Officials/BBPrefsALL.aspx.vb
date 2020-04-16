Public Class BBPrefsALL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strUserEmail As String

        If Session("userEmail") = "" Then
            strUserEmail = ""
            strUserEmail = Request.QueryString("user")
            If strUserEmail = "" Then
                Response.Redirect("LoginBBPref.aspx")
            Else
                Session("userEmail") = strUserEmail
            End If
        Else
            ' Move on...
        End If

    End Sub

End Class