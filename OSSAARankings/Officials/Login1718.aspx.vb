Public Class Login1718
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Email") = "" Then

        Else
            lblMessage.Text = "You must enter a valid Email and OSSAAID"
        End If

    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        Session("Email") = txtUsername.Text
        Session("OSSAAID") = txtOSSAAID.Text
        Response.Redirect("OfficialHome.aspx")
    End Sub

End Class