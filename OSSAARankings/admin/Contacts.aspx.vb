Partial Class Contacts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("key") <> "883JEEty2323" Then
            'Response.Redirect("http://www.ossaarankings.com")
        End If
        If Not IsPostBack Then
            Session("ShowHeader") = "Yes"
        End If
    End Sub

    Private Sub DropDownList1_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList1.DataBound
        DropDownList1.Items.Insert(0, "Select...")
    End Sub

    Private Sub DropDownList2_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList2.DataBound
        DropDownList2.Items.Insert(0, "Select...")
    End Sub

    Private Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        If Session("ShowHeader") = "Yes" Then
            Dim ds As DataSet
            Dim strSQL As String
            lblAD.Visible = True
            lblHSP.Visible = True
            strSQL = "SELECT * FROM tblSchool WHERE SchoolName = '" & DropDownList1.SelectedValue & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
                lblAD.Text = "<strong>Athletic Director :</strong> N/A"
                lblHSP.Text = "<strong>Principal :</strong> N/A"
            ElseIf ds.Tables.Count = 0 Then
                lblAD.Text = "<strong>Athletic Director :</strong> N/A"
                lblHSP.Text = "<strong>Principal :</strong> N/A"
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                lblAD.Text = "<strong>Athletic Director :</strong> N/A"
                lblHSP.Text = "<strong>Principal :</strong> N/A"
            Else
                If ds.Tables(0).Rows(0).Item("AdminADFirst") Is DBNull.Value Then
                    lblAD.Text = "<strong>Athletic Director :</strong> "
                ElseIf ds.Tables(0).Rows(0).Item("AdminADFirst") = "" Then
                    lblAD.Text = "<strong>Athletic Director :</strong> "
                Else
                    lblAD.Text = "<strong>Athletic Director :</strong> " & ds.Tables(0).Rows(0).Item("AdminADFirst") & " " & ds.Tables(0).Rows(0).Item("AdminADLast") & " - <strong>School :</strong> " & ds.Tables(0).Rows(0).Item("AdminADPhoneSchool") & " - <strong>Cell :</strong> " & ds.Tables(0).Rows(0).Item("AdminADPhoneCell") & " - <strong>Email :</strong> " & ds.Tables(0).Rows(0).Item("AdminADEmail")
                End If
                If ds.Tables(0).Rows(0).Item("AdminPrincipalFirst") Is DBNull.Value Then
                    lblHSP.Text = "<strong>Principal :</strong> "
                ElseIf ds.Tables(0).Rows(0).Item("AdminPrincipalFirst") = "" Then
                    lblHSP.Text = "<strong>Principal :</strong> "
                Else
                    lblHSP.Text = "<strong>Principal :</strong> " & ds.Tables(0).Rows(0).Item("AdminPrincipalFirst") & " " & ds.Tables(0).Rows(0).Item("AdminADLast") & " - <strong>School :</strong> " & ds.Tables(0).Rows(0).Item("AdminPrincipalPhoneSchool") & " - <strong>Cell :</strong> " & ds.Tables(0).Rows(0).Item("AdminPrincipalPhoneCell") & " - <strong>Email :</strong> " & ds.Tables(0).Rows(0).Item("AdminPrincipalEmail")
                End If
            End If
        Else
            lblAD.Text = "<strong>Coaches : </strong>" & DropDownList2.SelectedItem.Text
            lblAD.Visible = True
            lblHSP.Visible = False
        End If
    End Sub

    Private Sub DropDownList2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        Session("ShowHeader") = "No"
        GridView1.DataSourceID = "SqlDataSource4"
        GridView1.DataBind()
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("ShowHeader") = "Yes"
        GridView1.DataSourceID = "SqlDataSource1"
        GridView1.DataBind()
    End Sub
End Class