Public Class LoginOfficials
    Inherits System.Web.UI.Page

    ' NOTE 3/8/2016 changed from Login.aspx...

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("login") = "ossaasup" Or Request.QueryString("login") = "ossaaAD" Or Request.QueryString("login") = "ossaaprincipal" Or Request.QueryString("login") = "ossaastaff" Then
            Session("user") = Request.QueryString("login")
            Response.Redirect("EligibleOfficials.aspx")
        End If
    End Sub

    Protected Sub cmdLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLogin.Click
        If Me.txtUsername.Text = "ossaaobserver" Or UCase(txtUsername.Text) = System.Configuration.ConfigurationManager.AppSettings("OfficialLogin") Or txtUsername.Text = "ossaaadministrator" Or txtUsername.Text = "ossaaAD" Or txtUsername.Text = "ossaaprincipal" Or txtUsername.Text = "ossaastaff" Then
            Session("user") = txtUsername.Text
            Response.Redirect("EligibleOfficials.aspx")
        Else
            lblMessage.Text = "Invalid Code."
        End If
    End Sub
End Class