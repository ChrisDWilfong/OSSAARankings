Public Class OSSAAPassAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("sessionYear") = clsFunctions.GetCurrentYear      ' Added 7/27/2018...

        If Request.QueryString("sort") Is Nothing Then
            Session("sort") = "%"
        End If

        If Request.QueryString("sort") Is Nothing Then
            ' Do nothing...
        Else

            If Request.QueryString("sort") <> Session("sort") Then
                cboSchools.SelectedValue = Session("schoolID")
                Session("sort") = Request.QueryString("sort")
            End If
        End If

    End Sub
    Protected Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        If Me.cboSchools.SelectedItem.Text = "Select..." Then
            Me.lblMessage.Text = "Please select an organization."
        Else
            ' Insert a blank Record...
            Dim strSQL As String
            strSQL = "INSERT INTO tblPassDetails ([PassHeaderID], [Type], [Position], [Status], [intYear], [strCategory]) VALUES ("
            strSQL = strSQL & Me.cboSchools.SelectedValue & ", 'OSSAA', 'None', 'Approved', " & clsFunctions.GetCurrentYear & ", 'OSSAA')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub cmdAddNewOrganization_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNewOrganization.Click
        If Me.txtOrganization.Text = "" Then
            lblMessage.Text = "You must enter a new Organization Name."
        Else
            If CheckForDuplicate(txtOrganization.Text) Then
                lblMessage.Text = "Duplicate organization."
            Else
                Dim strSQL As String
                strSQL = InsertHeaderRecord(Me.txtOrganization.Text, Me.txtAddress.Text, Me.txtCity.Text, Me.txtState.Text, Me.txtZip.Text, Me.txtAttn.Text)
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                cboSchools.DataSourceID = "SqlDataSource1"
                cboSchools.DataBind()
                UpdatePanel1.Update()
                lblMessage.Text = "Organization added."
            End If
        End If
    End Sub

    Public Function InsertHeaderRecord(ByVal strOrganization As String, strAddress As String, strCity As String, strState As String, strZip As String, strAttn As String) As String
        Dim strSQL As String
        strSQL = "INSERT INTO tblPassHeader ([strSchool], [strSchoolAddress], [strSchoolCity], [strSchoolState], [strSchoolZip], [strName], [strTitle], [strCategory], [dtmSubmittedDateTime], [strSubmittedBy], [intYear], [dtmPassesApproved], [dtmInvoiceApproved], [dtmInvoicePrinted], [dtmSubmitted], [schoolID]) VALUES ("
        strSQL = strSQL & "'" & Replace(strOrganization, "'", "") & "', '" & strAddress & "', '" & strCity & "', '" & IIf(strState = "", "OK", strState) & "', '" & strZip & "', '" & strAttn & "',  'OSSAA', 'OSSAA', '" & Format(Now, "Short Date") & "', 'BEV', " & clsFunctions.GetCurrentYear & ", '" & Now & "', '" & Now & "', '" & Now & "', '" & Now & "', 1)"
        Return strSQL
    End Function

    Public Function CheckForDuplicate(ByVal strOrganization As String) As Boolean
        Dim ysnValue As Boolean = False
        Dim strSQL As String
        Dim intReturn As Integer = 0

        strSQL = "SELECT Id FROM tblPassHeader WHERE strSchool = '" & Replace(strOrganization, "'", "") & "' And strCategory = 'OSSAA' AND intYear = " & clsFunctions.GetCurrentYear
        intReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If intReturn = 0 Then
            ysnValue = False
        Else
            ysnValue = True
        End If

        Return ysnValue

    End Function

    Protected Sub cmdRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRefresh.Click
        'Response.Redirect("http://www.ossaa.net/apps/ossaapasses/admin/ossaapassadmin.aspx")
        Response.Redirect("~/admin/OSSAApassadmin.aspx")
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim strSQL As String

        strSQL = "Select tblPassHeader.strSchool FROM tblPassDetails INNER JOIN "
        strSQL = strSQL & "tblPassHeader ON tblPassDetails.PassHeaderId = tblPassHeader.Id "
        strSQL = strSQL & "WHERE (tblPassDetails.FirstName = '" & Me.txtFirstName.Text & "' And tblPassDetails.LastName = '" & Me.txtLastName.Text & "') OR (tblPassDetails.SpouseFirstName = '" & Me.txtFirstName.Text & "' And tblPassDetails.SpouseLastName = '" & Me.txtLastName.Text & "') AND (tblPassHeader.strCategory = 'OSSAA')"

        Dim strSchool As String = ""
        strSchool = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If strSchool = "" Or strSchool = "Select..." Then
            Me.lblMessageSearch.Text = "That name was NOT found."
        Else
            Me.lblMessageSearch.Text = "That name WAS found at : " & strSchool
        End If

    End Sub

    Private Sub cboSchools_DataBound(sender As Object, e As System.EventArgs) Handles cboSchools.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = -1
        objItem.Text = "Select..."
        Me.cboSchools.Items.Insert(0, objItem)
    End Sub

    Protected Sub cboSchools_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSchools.SelectedIndexChanged

        If cboSchools.SelectedItem.Text = "Select..." Then
            Me.txtAttn.Text = ""
            Me.txtAddress.Text = ""
            Me.txtCity.Text = ""
            Me.txtOrganization.Text = ""
            Me.txtState.Text = ""
            Me.txtZip.Text = ""
        Else
            Session("schoolID") = cboSchools.SelectedValue
            Session("school") = cboSchools.SelectedItem.Text
            Session("sort") = "%"

            ' GET ADDRESS INFO???
            Dim strSQL As String
            Dim ds As DataSet
            strSQL = "SELECT * FROM tblPassHeader WHERE Id = " & cboSchools.SelectedValue
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                Me.txtAddress.Text = IIf(ds.Tables(0).Rows(0).Item("strSchoolAddress") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strSchoolAddress"))
                Me.txtOrganization.Text = IIf(ds.Tables(0).Rows(0).Item("strSchool") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strSchool"))
                Me.txtCity.Text = IIf(ds.Tables(0).Rows(0).Item("strSchoolCity") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strSchoolCity"))
                Me.txtState.Text = IIf(ds.Tables(0).Rows(0).Item("strSchoolState") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strSchoolState"))
                Me.txtZip.Text = IIf(ds.Tables(0).Rows(0).Item("strSchoolZip") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strSchoolZip"))
                Me.txtAttn.Text = IIf(ds.Tables(0).Rows(0).Item("strName") Is System.DBNull.Value, "", ds.Tables(0).Rows(0).Item("strName"))
            End If
        End If
    End Sub

    Protected Sub cmdInvoice_Click(sender As Object, e As EventArgs) Handles cmdInvoice.Click
        Dim intHeaderId As Integer = 0
        'Dim strPath = "http://ossaapasses.ossaa.net"
        'Dim strPath = "http://localhost:50652"
        Dim strPath = "http://www.ossaa.com"

        Dim url As String = strPath & "/PreviewAdmin.aspx?i=" & cboSchools.SelectedValue
        Dim script As String = "window.open('" & url & "','importWindow', 'width=700, height=500,top=' +(screen.availHeight-500)/2 + ',left=' + (screen.availWidth-700)/2+ ', resizable=yes, scrollbars=yes,modal=yes');"
        ScriptManager.RegisterStartupScript(Me.Page, Page.GetType(), "OpenPopup", script, True)
    End Sub

    Protected Sub cmdSaveChanges_Click(sender As Object, e As EventArgs) Handles cmdSaveChanges.Click
        Dim strSQL As String
        strSQL = "UPDATE tblPassHeader SET "
        If Trim(Me.txtAddress.Text) = "" Then
        Else
            strSQL = strSQL & "strSchoolAddress = '" & Me.txtAddress.Text & "', "
        End If
        If Trim(Me.txtCity.Text) = "" Then
        Else
            strSQL = strSQL & "strSchoolCity = '" & Me.txtCity.Text & "', "
        End If
        If Trim(Me.txtState.Text) = "" Then
        Else
            strSQL = strSQL & "strSchoolState = '" & Me.txtState.Text & "', "
        End If
        If Trim(Me.txtZip.Text) = "" Then
        Else
            strSQL = strSQL & "strSchoolZip = '" & Me.txtZip.Text & "', "
        End If
        If Trim(Me.txtAttn.Text) = "" Then
        Else
            strSQL = strSQL & "strName = '" & Me.txtAttn.Text & "', "
        End If

        strSQL = strSQL & "strSchool = '" & Me.txtOrganization.Text & "' "
        strSQL = strSQL & "WHERE Id = " & Me.cboSchools.SelectedValue

        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        Me.lblMessage.Text = "Changes saved."
    End Sub

    Private Sub GridView1_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblMessage.Text = ""
    End Sub

    Private Sub GridView1_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strSQL As String
        Dim strSchool As String = ""

        strFirstName = e.NewValues(0).ToString
        strLastName = e.NewValues(1).ToString

        strSQL = "SELECT strSchool FROM ossaauser.viewPassHeaderWithDetailsCurrentYear WHERE UPPER(FirstName) = '" & strFirstName.ToUpper & "' AND UPPER(LastName) = '" & strLastName.ToUpper & "'"
        Try
            strSchool = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strSchool = ""
        End Try
        If strSchool = "" Then
        Else
            lblMessage.Text = "THIS IS A DUPLICATE : " & strSchool
        End If

    End Sub
End Class