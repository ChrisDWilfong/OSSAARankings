Public Class SiteLogin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") = "" Then
            Me.lblWelcome.Text = "Please login"
        Else
            Select Case Session("usertype")
                Case "SUPER"
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & " (Superintendent)</b> at <b>" & Session("school") & "</b>&nbsp;"
                Case "PRINCIPAL"
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & " (Principal)</b> at <b>" & Session("school") & "</b>&nbsp;"
                Case "AD"
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & " (Athletic Director)</b> at <b>" & Session("school") & "</b>&nbsp;"
                Case "OSSAA"
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & " (OSSAA Staff)</b> at <b>" & Session("school") & "</b>&nbsp;"
                Case "OSSAAADMIN"
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & " (OSSAA Staff-Admin)</b> at <b>" & Session("school") & "</b>&nbsp;"
                Case Else
                    Me.lblWelcome.Text = "Welcome <b>" & Session("user") & "</b> at <b>" & Session("school") & "</b>&nbsp;"
            End Select

        End If
    End Sub

End Class