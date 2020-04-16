Public Class MemberPlayoffPassSup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        Me.lblStep.Text = "OSSAA 2018-2019 Playoff Passes"

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Private Sub MemberPlayoffs_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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

#Region "Imported Object"

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        clsMembership.AutomaticallyAddDetail(Session("category"), Session("key"), True, "Board", "", 0)
        GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        Me.lblInvoiceTotal.Text = clsMembership.InvoiceTotalString(Session("key"))
    End Sub

    Private Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Select Case Session("category")
            Case "Superintendent"
                For Each de As DictionaryEntry In e.Values
                    If de.Key = "Position" Then
                        e.Cancel = clsMembership.DeleteTheRow(Session("category"), de.Value)
                    End If
                Next
            Case Else
        End Select
    End Sub

    Private Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        Me.lblInvoiceTotal.Text = clsMembership.InvoiceTotalString(Session("key"))
    End Sub


    Private Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating


        ' Make sure the Proper fields are automatically updated...
        Dim strValidSpouse As String = ""
        Dim strSpouse As String = ""
        Dim strPosition As String = "Board"         ' Default Position...

        Select Case Session("category")
            Case "Superintendent"

                ' Get the position to NOT DELETE...
                For Each deo As DictionaryEntry In e.OldValues
                    If deo.Key = "Position" Then
                        If deo.Value = "Superintendent" Then
                            strPosition = deo.Value
                        End If
                    End If
                Next

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
                    ' Superitendent has to be charged...
                    If strPosition = "Superintendent" Then
                        If de.Key = "SpouseFirstName" Then
                            strValidSpouse = strValidSpouse & de.Value
                        End If
                        If de.Key = "SpouseLastName" Then
                            strValidSpouse = strValidSpouse & de.Value
                        End If
                    End If
                    ' Check to see if the Spouse has been requested...
                    If de.Key = "SpouseFirstName" Then
                        strSpouse = strSpouse & de.Value
                    End If
                    If de.Key = "SpouseLastName" Then
                        strSpouse = strSpouse & de.Value
                    End If

                Next

                ' Populate some of the default values...
                For Each de1 As DictionaryEntry In e.OldValues
                    If de1.Key = "intCost" Then
                        If strValidSpouse = "" Then
                            de1.Value = "0"
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "0")
                        Else
                            de1.Value = "10"
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "10")
                        End If
                    ElseIf de1.Key = "SpousePaidStatus" Then
                        If strValidSpouse = "" Then
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "FREE")
                        Else
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "UNPAID")
                        End If
                    ElseIf de1.Key = "SpouseStatus" Then
                        If strSpouse = "" Then
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "")
                        Else
                            e.NewValues.Insert(e.NewValues.Count, de1.Key, "Requested")
                        End If
                    End If
                Next

            Case Else
        End Select

    End Sub

    Public Function CreateParameters() As String
        Dim strReturn As String = ""
        strReturn = "k=" & Session("key")
        strReturn = strReturn & "&c=" & Session("category")
        strReturn = strReturn & "&i=" & Session("invoice")
        strReturn = strReturn & "&e=" & Session("email")
        strReturn = strReturn & "&s=" & Session("school")
        strReturn = strReturn & "&cl=" & Session("class")
        strReturn = strReturn & "&t=" & Session("type")
        strReturn = strReturn & "&t2=" & Session("type2")
        Return strReturn
    End Function
#End Region

End Class