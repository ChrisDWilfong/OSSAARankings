Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Public Class EligibleOfficialsPlayoffs
    Inherits System.Web.UI.Page

    ' NEWSEASON (Basketball) : Change the Date Headings on the Grid...

    Protected Sub cmdGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGo.Click
        Dim strOrderByClause As String
        Dim strMessage As String = ""
        Dim strSQL As String

        strOrderByClause = Me.RadioButtonList1.SelectedValue

        If strOrderByClause = "OfficialRating" Then strOrderByClause = "dblRatingBasketball DESC"
        If strOrderByClause = "OfficialClass" Then strOrderByClause = "strClassBasketball"
        If strOrderByClause = "intYearsBasketball" Then strOrderByClause = "intYearsBasketball DESC"

        ' NEWSEASON (Basketball) : Change this view...
        strSQL = "SELECT TOP 1000 * FROM viewOfficialsBasketballEligibleAvailablePlayoffs ORDER BY " & strOrderByClause

        Dim intCount As Integer
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, "SELECT Count(*) AS intCount FROM viewOfficialsBasketballEligibleAvailablePlayoffs")

        Me.lblMessage.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & intCount & " Eligible Officials " & strMessage

        Me.SqlDataSource1.SelectCommand = strSQL
        Me.SqlDataSource1.DataBind()

    End Sub

    Private Sub EligibleOfficialsPlayoffs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Server.ScriptTimeout = 300
    End Sub

    Private Sub EligibleOfficials_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("l") = "ossaastaff" Then
            Session("user") = "ossaastaff"
        End If

        If UCase(Session("user")) = System.Configuration.ConfigurationManager.AppSettings("OfficialLogin") Or Session("user") = "ossaaobserver" Or Session("user") = "ossaacord" Or Session("user") = "ossaasup" Or Session("user") = "ossaaAD" Or Session("user") = "ossaaprincipal" Or Session("user") = "ossaastaff" Then
        Else
            'Response.Redirect("LoginPlayoffE.aspx")
        End If

        If Not IsPostBack Then
            Me.RadioButtonList1.SelectedIndex = 0
        End If

    End Sub


End Class