Public Class EWRankings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Session("EWw") = "Week 8"
		Session("EWy") = clsFunctions.GetCurrentYear

		If Request.QueryString("w") = "Week8" Then
			Session("EWw") = "Week 8"
		ElseIf Request.QueryString("w") = "Week9" Then
			Session("EWw") = "Week 9"
		ElseIf Request.QueryString("w") = "Week10" Then
			Session("EWw") = "Week 10"
		ElseIf Request.QueryString("w") = "Week11" Then
			Session("EWw") = "Week 11"
		ElseIf Request.QueryString("w") = "Week12" Then
			Session("EWw") = "Week 12"
        End If

        If Request.QueryString("y") Is Nothing Then
        Else
            Session("EWy") = Request.QueryString("y")
        End If

		lblHeaderMain.Text = "E/W RANKINGS 20" & Session("EWy") & " (" & Session("EWw") & ")"

	End Sub

End Class