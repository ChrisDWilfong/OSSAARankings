Public Class MemberChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Session("user") = "" Then
                Response.Redirect("MemberLogin.aspx")
            End If
        End If
    End Sub

    Protected Sub cmdDone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDone.Click
        If Session("usertype") = "SUPER" Then
            Response.Redirect("MemberInfoSup.aspx")
        ElseIf Session("usertype") = "PRINCIPAL" Then
            Response.Redirect("MemberInfoPrin.aspx")
        ElseIf Session("usertype") = "AD" Then
            Response.Redirect("MemberInfoAD.aspx")
        ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
            Response.Redirect("MemberInfoOSSAA.aspx")
        Else
            Response.Redirect("MemberLogin.aspx")
        End If
    End Sub

    Protected Sub cmdSavePassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSavePassword.Click
        SavePassword()
    End Sub

    Public Sub SavePassword()
        Dim strSQL As String = ""
        If Me.txtPassword.Text = "" Then
            Me.lblMessage.Text = "You must type in a Password."
        ElseIf Me.txtPassword1.Text = "" Then
            Me.lblMessage.Text = "You must retype your Password."
        Else
            If txtPasswordCurrent.Text <> Session("password") Then
                Me.lblMessage.Text = "Invalid Current Password typed in.  Change canceled."
            Else
                If Me.txtPassword.Text = Me.txtPassword1.Text Then
                    Dim strPW As String = txtPassword.Text
                    If strPW.Length > 5 Then
                        If clsMembership.IsLoginADuplicate(Session("user"), strPW, Session("key"), Session("usertype"), Session("confirmed")) Then
                            Me.lblMessage.Text = "This is a duplicate username/password combination.  Please use another password."
                        Else
                            ' Change it...
                            If Session("usertype") = "SUPER" Then
                                strSQL = "UPDATE tblSchool SET Password1 = '" & strPW & "' WHERE Id = " & Session("key")
                            ElseIf Session("usertype") = "PRINCIPAL" Then
                                strSQL = "UPDATE tblSchool SET Password2 = '" & strPW & "' WHERE Id = " & Session("key")
                            ElseIf Session("usertype") = "AD" Then
                                strSQL = "UPDATE tblSchool SET Password3 = '" & strPW & "' WHERE Id = " & Session("key")
                            ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                                strSQL = "UPDATE tblSchool SET Password = '" & strPW & "' WHERE Id = " & Session("key")
                            End If
                            Try
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                                Me.lblMessage.Text = "Your password has been changed."
                                Session("password") = strPW
                            Catch
                                Me.lblMessage.Text = "There was a problem changing your password (#20033)"
                            End Try
                        End If
                    Else
                        Me.lblMessage.Text = "Your password must be atleast 6 characters long."
                    End If
                Else
                    Me.lblMessage.Text = "You retyped your password incorrectly."
                End If
            End If
        End If
    End Sub

End Class