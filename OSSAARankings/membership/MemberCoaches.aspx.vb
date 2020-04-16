Public Class MemberCoaches
    Inherits System.Web.UI.Page

    ' Notes: 
    '   11/1/2010: Added VotingStreetAddress
    '

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
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

        Me.lblStep.Text = "List of High School Head Coaches - " & Session("school")
        Me.lblTitle.Text = "Please enter your High School's Head Coaches."
        Me.lblFooter.Text = clsMembership.GetCopyright

        ' Update Coaches Ratings of Officials information...ONLY NEEDED DURING/AFTER BASKETBALL SEASON...
        ''Me.lblOfficials.Text = clsFunctions.GetCoachesRatingsOfOfficials(Session("school"))

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

    Protected Sub cmdAddNewRequest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNewRequest.Click
        clsMembership.AutomaticallyAddDetail("Coach", Session("key"), True, "", "ADMIN", 1)
        GridView2.DataBind()
    End Sub

    Private Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating

        For Each de As DictionaryEntry In e.NewValues
            ' Check for Empty values...
            If de.Key = "FirstName" Then
                If de.Value Is Nothing Then
                    lblMessage.Text = "You must enter a First Name (or Cancel)..."
                    e.Cancel = True
                End If
            End If
            If de.Key = "LastName" Then
                If de.Value Is Nothing Then
                    lblMessage.Text = "You must enter a Last Name (or Cancel)..."
                    e.Cancel = True
                End If
            End If
            If de.Key = "Position" Then
                If de.Value = "Select..." Then
                    lblMessage.Text = "You must select a Position (or Cancel)..."
                    e.Cancel = True
                End If
            End If
            If de.Key = "Email" Then
                If de.Value Is Nothing Then
                    lblMessage.Text = "You must enter an Email (or Cancel)..."
                    e.Cancel = True
                End If
            End If
            If de.Key = "CoachType" Then
                If de.Value = "Select..." Then
                    lblMessage.Text = "You must select a Coach Type (or Cancel)..."
                    e.Cancel = True
                End If
            End If
        Next
    End Sub

End Class