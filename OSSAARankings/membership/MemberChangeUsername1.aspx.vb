Public Class MemberChangeUsername1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ChangePassword1_ChangedPassword(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangePassword1.ChangedPassword

        If ChangePassword1.NewPassword = "password" Then


        Else

        End If

    End Sub
End Class