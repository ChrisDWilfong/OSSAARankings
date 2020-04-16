Public Class MemberHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        'Me.lblStep.Text = "OSSAA Information"
        'Me.lblTitle.Text = "Please enter your school's Junior High #2 Principal's information..."

        If Not IsPostBack Or Session("usertype") = "OSSAAADMIN" Then
            Select Case Session("usertype")
                Case "SUPER"
                    If Session("confirmed") = 0 Then
                        Response.Redirect("MemberInfoSup.aspx")
                    Else
                        myPlaceHolder.Controls.Clear()
                        Dim c As Control
                        c = LoadControl("ucHomeSNew.ascx")
                        myPlaceHolder.Controls.Add(c)
                    End If
                Case "PRINCIPAL"
                    If Session("confirmed") = 0 Then
                        Response.Redirect("MemberInfoPrin.aspx")
                    Else
                        myPlaceHolder.Controls.Clear()
                        Dim c As Control
                        c = LoadControl("ucHomePNew.ascx")
                        myPlaceHolder.Controls.Add(c)
                    End If
                Case "AD"
                    If Session("confirmed") = 0 Then
                        Response.Redirect("MemberInfoAD.aspx")
                    Else
                        myPlaceHolder.Controls.Clear()
                        Dim c As Control
                        c = LoadControl("ucHomeADNew.ascx")
                        myPlaceHolder.Controls.Add(c)
                    End If
                Case "OSSAAADMIN"
                    myPlaceHolder.Controls.Clear()
                    Dim c As Control
                    c = LoadControl("ucHomeOSSAAAdminNew.ascx")
                    myPlaceHolder.Controls.Add(c)
                Case Else
                    Response.Redirect("MemberLogin.aspx")
            End Select
        End If
    End Sub


    Private Sub MemberHome_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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
End Class