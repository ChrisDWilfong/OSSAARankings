Public Class MemberHelp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

        If Session("confirmed") = 0 Then
            If Session("usertype") = "SUPER" Then
                Response.Redirect("MemberInfoSup.aspx")
            ElseIf Session("usertype") = "PRINCIPAL" Then
                Response.Redirect("MemberInfoPrin.aspx")
            ElseIf Session("usertype") = "AD" Then
                Response.Redirect("MemberInfoAD.aspx")
            End If
        End If

    End Sub

    Private Sub MemberHelp_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("usertype") = "SUPER" Then
            Me.MasterPageFile = "SiteMembership.Master"
        ElseIf Session("usertype") = "PRINCIPAL" Then
            Me.MasterPageFile = "SiteP.Master"
        ElseIf Session("usertype") = "AD" Then
            Me.MasterPageFile = "SiteAD.Master"
        ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
            Me.MasterPageFile = "SiteOSSAAAdmin.Master"
        Else
            Me.MasterPageFile = "SiteLogin.Master"
        End If
    End Sub
End Class