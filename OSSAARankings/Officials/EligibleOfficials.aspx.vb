Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Partial Class EligibleOfficials
    Inherits System.Web.UI.Page

    Protected Sub cmdGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGo.Click
        Dim strOrderByClause As String = ""
        Dim strMessage As String = ""
        Dim strSQL As String = ""

        If ConfigurationManager.AppSettings("ShowEligibleOfficials") = 0 Then
            lblMessage.Text = "Currently unavailable."
            Exit Sub
        End If

        strOrderByClause = Me.RadioButtonList1.SelectedValue

        strSQL = clsOfficials.GetEligibleOfficialsSQL(cboSports.SelectedValue, strOrderByClause, False, strMessage)

        Me.lblMessage.Text = strMessage

        Me.SqlDataSource1.SelectCommand = strSQL
        Me.SqlDataSource1.DataBind()

    End Sub

    Private Sub EligibleOfficials_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("l") = "ossaastaff" Or Request.QueryString("l") = "ossaacoach" Then      ' 9/18/2014... Added ossaacoach... 
            Session("user") = "ossaastaff"
        End If

        If UCase(Session("user")) = System.Configuration.ConfigurationManager.AppSettings("OfficialLogin") Or Session("user") = "ossaaobserver" Or Session("user") = "ossaacord" Or Session("user") = "ossaasup" Or Session("user") = "ossaaAD" Or Session("user") = "ossaaprincipal" Or Session("user") = "ossaastaff" Then
        Else
            'Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            Me.RadioButtonList1.SelectedIndex = 0
        End If

    End Sub

    Private Sub UltraWebGrid1_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.RowEventArgs) Handles UltraWebGrid1.InitializeRow

    End Sub
End Class