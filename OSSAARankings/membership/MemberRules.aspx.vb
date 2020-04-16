Public Class MemberRules
    Inherits System.Web.UI.Page

    ' Notes: 
    '   11/1/2010: Added VotingStreetAddress
    '

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        Me.lblStep.Text = "List of Rules Meetings taken - " & Session("school")
        Me.lblTitle.Text = ""

    End Sub

    Private Sub MemberInfoAD_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        If Session("usertype") = "SUPER" Then
            Me.MasterPageFile = "SiteMembership.Master"
        ElseIf Session("usertype") = "PRINCIPAL" Then
            Me.MasterPageFile = "SiteP.Master"
        ElseIf Session("usertype") = "AD" Then
            Me.MasterPageFile = "SiteAD.Master"
        ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
            Me.MasterPageFile = "SiteOSSAAAdmin.Master"
        Else
            Response.Redirect("MemberLogin.aspx")
        End If
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If InStr(e.Row.Cells(0).Text, "NONE") > 0 Then
            e.Row.Cells(0).Font.Bold = False
        Else
            e.Row.Cells(0).Font.Bold = True
        End If
    End Sub
End Class