Public Class MemberChangeUsername
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Session("user") = "" Then
                Response.Redirect("MemberLogin.aspx")
            Else
                Me.txtUserNameCurrent.Text = Session("user")
            End If
        End If
    End Sub

    Protected Sub cmdDone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDone.Click
        If Session("usertype") = "SUPER" Then
            Response.Redirect("MemberHome.aspx")
        ElseIf Session("usertype") = "PRINCIPAL" Then
            Response.Redirect("MemberHome.aspx")
        ElseIf Session("usertype") = "AD" Then
            Response.Redirect("MemberHome.aspx")
        Else
            Response.Redirect("MemberLogin.aspx")
        End If
    End Sub

    Protected Sub cmdSaveUsername_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveUsername.Click
        SaveUserName()
        Session("user") = Me.txtUserName.Text
    End Sub

    Protected Sub cmdSavePassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSavePassword.Click
        SavePassword()
    End Sub

    Public Sub SaveUserName()
        If txtUserName.Text = "" Then
            Me.lblMessage.Text = "You must enter a New Username."
            ' Is it a duplicate username/password...
            If clsMembership.IsLoginADuplicate("", "", 0, "", False) Then
                ' Change the Username...
                Me.lblMessage.Text = "Username changed."
            Else
                Me.lblMessage.Text = "Retyped username does not match."
            End If
        End If
    End Sub

    Public Sub SavePassword()

    End Sub

End Class