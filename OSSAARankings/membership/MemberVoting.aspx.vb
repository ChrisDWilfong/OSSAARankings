Public Class MemberVoting
    Inherits System.Web.UI.Page
    ' Notes: 
    '   11/2/2010 : Added Multi Dropdown...
    '   11/1/2010 : Added VotingStreetAddress...
    '
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
            Else
                If Session("usertype") <> "SUPER" Then
                    Response.Redirect("MemberLogin.aspx")
                End If
            End If
        End If

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

        Me.lblStep.Text = "Voting Delegate Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Voting Delegate information..."

        If Not IsPostBack Then
            If Session("multi") > 0 Then
                Dim ds1 As DataSet
                Dim strSQL1 As String = "SELECT Id, SchoolName FROM tblSchool WHERE intMulti = " & Session("key") & " ORDER BY SchoolName"
                ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL1)
                If ds1 Is Nothing Then
                ElseIf ds1.Tables.Count = 0 Then
                ElseIf ds1.Tables(0).Rows.Count = 0 Then
                Else
                    Me.cboMulti.DataSource = ds1
                    Me.cboMulti.DataTextField = "SchoolName"
                    Me.cboMulti.DataValueField = "Id"
                    Me.cboMulti.DataBind()
                End If
                Dim objItem As New System.Web.UI.WebControls.ListItem
                objItem.Value = 0
                objItem.Text = "Select..."
                cboMulti.Items.Insert(0, objItem)
            Else
                Me.lblMulti.Visible = False
                Me.cboMulti.Visible = False
            End If
        End If

        ' Load the data...
        If Not IsPostBack Then
            If Session("multi") > 0 Then
                ' Don't load anything yet...
            Else
                LoadSchool(Session("key"))
            End If
        End If

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Private Sub MemberVoting_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

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

    Protected Sub cmdSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveChanges.Click
        Dim strSQL As New StringBuilder
        Dim strSQLInsert As New StringBuilder

        ' Validate the Position...
        If DropDownList1.SelectedValue = "Select..." And txtOther.Text = "" Then
            lblPositionRequired.Visible = True
        Else
            lblPositionRequired.Visible = False
        End If

        Dim strMrMs As String = Me.cboMrMsSup.SelectedValue
        If strMrMs = "Select..." Then strMrMs = "Mr"

        ' APPEND query...
        Dim intID As Integer = 0
        strSQLInsert.Append("INSERT INTO tblSchoolSync ")
        strSQLInsert.Append("(VotingMrMs, VotingFirst, VotingLast, VotingMailingAddress, ")
        strSQLInsert.Append("VotingStreetAddress, VotingPhoneSchool, ")
        strSQLInsert.Append("VotingPhoneSchoolExt, VotingPhoneCell, VotingPhoneFax, VotingEmail, ")
        strSQLInsert.Append("MailingCity, MailingState, MailingZip, dtmStampVoting, ")
        strSQLInsert.Append("intSync5, dtmSync, intSchoolID, strChangedBy, strUserType, ")
        strSQLInsert.Append("VotingPosition, VotingOther")

        strSQLInsert.Append(") VALUES (")

        strSQLInsert.Append("'" & strMrMs & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtFirstNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtLastNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtCellSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingCitySup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingStateSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingZipSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Now & "', ")
        strSQLInsert.Append("1, ")

        strSQLInsert.Append("'" & Now & "', ")
        Try
            intID = Session("intSchoolID")
        Catch
            intID = 0
        End Try
        strSQLInsert.Append(intID & ", ")
        strSQLInsert.Append("'" & Session("user") & "', ")
        strSQLInsert.Append("'" & Session("usertype") & "', ")

        If DropDownList1.SelectedValue = "Select..." Then
            strSQLInsert.Append("'', ")
        ElseIf Me.txtOther.Text <> "" Then
            strSQLInsert.Append("'', ")
        Else
            strSQLInsert.Append("'" & Me.DropDownList1.SelectedValue & "', ")
        End If
        strSQLInsert.Append("'" & Me.txtOther.Text & "'")
        strSQLInsert.Append(")")

        ' UPDATE query...
        strSQL.Append("UPDATE tblSchool SET VotingMrMs = '" & strMrMs & "' ")
        strSQL.Append(", VotingFirst = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingLast = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingMailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingStreetAddress = '" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "'")
        strSQL.Append(", VotingPhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingPhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

        strSQL.Append(", VotingPhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingPhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
        strSQL.Append(", VotingEmail = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCitySup.Text, "'", "") & "' ")
        strSQL.Append(", MailingState = '" & Replace(Me.txtMailingStateSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZipSup.Text, "'", "") & "'")

        strSQL.Append(", dtmStampVoting = '" & Now & "'")

        If DropDownList1.SelectedValue = "Select..." Then
            strSQL.Append(", VotingPosition = ''")
        ElseIf Me.txtOther.Text <> "" Then
            strSQL.Append(", VotingPosition = ''")
        Else
            strSQL.Append(", VotingPosition = '" & Me.DropDownList1.SelectedValue & "'")
        End If

        strSQL.Append(", VotingOther = '" & Me.txtOther.Text & "'")

        If Session("multi") > 0 Then
            strSQL.Append(" WHERE Id = " & cboMulti.SelectedValue)
        Else
            strSQL.Append(" WHERE Id = " & Session("key"))
        End If

        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)
            Me.lblMessage.Text = "Changes saved."
        Catch
            Me.lblMessage.Text = "Change failed."
        End Try

    End Sub

    Public Sub LoadSchool(ByVal intKey As Integer)
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT VotingMrMs, VotingFirst, VotingLast, VotingMailingAddress, VotingPhoneSchool, VotingPhoneSchoolExt, VotingPhoneCell, VotingPhoneFax, VotingEmail, MailingCity, MailingState, MailingZip, VotingPosition, VotingOther, VotingStreetAddress, intSchoolID "
        strSQL = strSQL & "FROM tblSchool WHERE Id = " & intKey

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            ' Load it!...
            With ds.Tables(0).Rows(0)
                If Not .Item("VotingPosition") Is System.DBNull.Value Then
                    Try
                        DropDownList1.SelectedValue = .Item("VotingPosition")
                    Catch
                        DropDownList1.SelectedIndex = 0
                    End Try
                End If
                If .Item("VotingOther") Is System.DBNull.Value Then
                ElseIf .Item("VotingOther") = "" Then
                Else
                    txtOther.Text = .Item("VotingOther")
                End If
                If Not .Item("VotingMrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("VotingMrMs")
                End If
                If Not .Item("VotingFirst") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("VotingFirst")
                End If
                If Not .Item("VotingLast") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("VotingLast")
                End If
                If Not .Item("VotingMailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("VotingMailingAddress")
                End If
                If Not .Item("VotingPhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("VotingPhoneSchool")
                End If
                If Not .Item("VotingPhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("VotingPhoneSchoolExt")
                End If
                If Not .Item("VotingPhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("VotingPhoneCell")
                End If
                If Not .Item("VotingPhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("VotingPhoneFax")
                End If
                If Not .Item("VotingEmail") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("VotingEmail")
                End If

                If Not .Item("MailingCity") Is System.DBNull.Value Then
                    txtMailingCitySup.Text = .Item("MailingCity")
                End If
                If Not .Item("MailingState") Is System.DBNull.Value Then
                    txtMailingStateSup.Text = .Item("MailingState")
                End If
                If Not .Item("MailingZip") Is System.DBNull.Value Then
                    txtMailingZipSup.Text = .Item("MailingZip")
                End If

                If Not .Item("VotingStreetAddress") Is System.DBNull.Value Then
                    txtPhysicalAddress.Text = .Item("VotingStreetAddress")
                End If
                If Not .Item("MailingCity") Is System.DBNull.Value Then
                    txtPhysicalCity.Text = .Item("MailingCity")
                End If
                If Not .Item("MailingState") Is System.DBNull.Value Then
                    txtPhysicalState.Text = .Item("MailingState")
                End If
                If Not .Item("MailingZip") Is System.DBNull.Value Then
                    txtPhysicalZip.Text = .Item("MailingZip")
                End If
                Session("intSchoolID") = .Item("intSchoolID")
            End With
        End If
    End Sub

    Public Sub LoadSelection(ByVal strSelection As String, ByVal intKey As Integer)
        Dim strSQL As String = ""
        Dim ds As DataSet

        Select Case strSelection
            Case "Superintendent"
                strSQL = "SELECT AdminSuperMrMs, AdminSuperFirst, AdminSuperLast, AdminSuperMailingAddress, AdminSuperStreetAddress, AdminSuperPhoneSchool, AdminSuperPhoneSchoolExt, AdminSuperPhoneCell, AdminSuperPhoneFax, AdminSuperEmail, MailingCity, MailingState, MailingZip, intSchoolID "
                'strSQL = strSQL & "FROM tblSchool WHERE Id = " & Session("key")
                strSQL = strSQL & "FROM tblSchool WHERE Id = " & intKey

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                If ds Is Nothing Then
                ElseIf ds.Tables.Count = 0 Then
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                Else
                    ' Load it!...
                End If
                With ds.Tables(0).Rows(0)
                    ClearFields()
                    If Not .Item("AdminSuperMrMs") Is System.DBNull.Value Then
                        cboMrMsSup.SelectedValue = .Item("AdminSuperMrMs")
                    End If
                    If Not .Item("AdminSuperFirst") Is System.DBNull.Value Then
                        txtFirstNameSup.Text = .Item("AdminSuperFirst")
                    End If
                    If Not .Item("AdminSuperLast") Is System.DBNull.Value Then
                        txtLastNameSup.Text = .Item("AdminSuperLast")
                    End If
                    If Not .Item("AdminSuperMailingAddress") Is System.DBNull.Value Then
                        txtMailingAddressSup.Text = .Item("AdminSuperMailingAddress")
                    End If
                    If Not .Item("AdminSuperStreetAddress") Is System.DBNull.Value Then
                        txtPhysicalAddress.Text = .Item("AdminSuperStreetAddress")
                    End If
                    If Not .Item("AdminSuperPhoneSchool") Is System.DBNull.Value Then
                        txtSchoolPhoneSup.Text = .Item("AdminSuperPhoneSchool")
                    End If
                    If Not .Item("AdminSuperPhoneSchoolExt") Is System.DBNull.Value Then
                        txtSchoolPhoneSupExt.Text = .Item("AdminSuperPhoneSchoolExt")
                    End If
                    If Not .Item("AdminSuperPhoneCell") Is System.DBNull.Value Then
                        txtCellSup.Text = .Item("AdminSuperPhoneCell")
                    End If
                    If Not .Item("AdminSuperPhoneFax") Is System.DBNull.Value Then
                        txtSchoolFaxSup.Text = .Item("AdminSuperPhoneFax")
                    End If
                    If Not .Item("AdminSuperEmail") Is System.DBNull.Value Then
                        txtSchoolEmailSup.Text = .Item("AdminSuperEmail")
                    End If
                    If Not .Item("MailingCity") Is System.DBNull.Value Then
                        txtMailingCitySup.Text = .Item("MailingCity")
                    End If
                    If Not .Item("MailingState") Is System.DBNull.Value Then
                        txtMailingStateSup.Text = .Item("MailingState")
                    End If
                    If Not .Item("MailingZip") Is System.DBNull.Value Then
                        txtMailingZipSup.Text = .Item("MailingZip")
                    End If
                    Session("intSchoolID") = .Item("intSchoolID")
                End With

            Case "High School Principal"
                strSQL = "SELECT AdminPrincipalMrMs, AdminPrincipalFirst, AdminPrincipalLast, AdminPrincipalMailingAddress, AdminPrincipalStreetAddress, AdminPrincipalPhoneSchool, AdminPrincipalPhoneSchoolExt, AdminPrincipalPhoneCell, AdminPrincipalPhoneFax, AdminPrincipalEmail, MailingCity, MailingState, MailingZip, intSchoolID "
                strSQL = strSQL & "FROM tblSchool WHERE Id = " & intKey
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                If ds Is Nothing Then
                ElseIf ds.Tables.Count = 0 Then
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                Else
                    ' Load it!...
                End If
                With ds.Tables(0).Rows(0)
                    ClearFields()
                    If Not .Item("AdminPrincipalMrMs") Is System.DBNull.Value Then
                        cboMrMsSup.SelectedValue = .Item("AdminPrincipalMrMs")
                    End If
                    If Not .Item("AdminPrincipalFirst") Is System.DBNull.Value Then
                        txtFirstNameSup.Text = .Item("AdminPrincipalFirst")
                    End If
                    If Not .Item("AdminPrincipalLast") Is System.DBNull.Value Then
                        txtLastNameSup.Text = .Item("AdminPrincipalLast")
                    End If
                    If Not .Item("AdminPrincipalMailingAddress") Is System.DBNull.Value Then
                        txtMailingAddressSup.Text = .Item("AdminPrincipalMailingAddress")
                    End If
                    If Not .Item("AdminPrincipalStreetAddress") Is System.DBNull.Value Then
                        txtPhysicalAddress.Text = .Item("AdminPrincipalStreetAddress")
                    End If
                    If Not .Item("AdminPrincipalPhoneSchool") Is System.DBNull.Value Then
                        txtSchoolPhoneSup.Text = .Item("AdminPrincipalPhoneSchool")
                    End If
                    If Not .Item("AdminPrincipalPhoneSchoolExt") Is System.DBNull.Value Then
                        txtSchoolPhoneSupExt.Text = .Item("AdminPrincipalPhoneSchoolExt")
                    End If
                    If Not .Item("AdminPrincipalPhoneCell") Is System.DBNull.Value Then
                        txtCellSup.Text = .Item("AdminPrincipalPhoneCell")
                    End If
                    If Not .Item("AdminPrincipalPhoneFax") Is System.DBNull.Value Then
                        txtSchoolFaxSup.Text = .Item("AdminPrincipalPhoneFax")
                    End If
                    If Not .Item("AdminPrincipalEmail") Is System.DBNull.Value Then
                        txtSchoolEmailSup.Text = .Item("AdminPrincipalEmail")
                    End If
                    If Not .Item("MailingCity") Is System.DBNull.Value Then
                        txtMailingCitySup.Text = .Item("MailingCity")
                    End If
                    If Not .Item("MailingState") Is System.DBNull.Value Then
                        txtMailingStateSup.Text = .Item("MailingState")
                    End If
                    If Not .Item("MailingZip") Is System.DBNull.Value Then
                        txtMailingZipSup.Text = .Item("MailingZip")
                    End If
                    Session("intSchoolID") = .Item("intSchoolID")
                End With

            Case "Athletic Director"
                strSQL = "SELECT AdminADMrMs, AdminADFirst, AdminADLast, AdminADMailingAddress, AdminADStreetAddress, AdminADPhoneSchool, AdminADPhoneSchoolExt, AdminADPhoneCell, AdminADPhoneFax, AdminADEmail, MailingCity, MailingState, MailingZip, intSchoolID "
                strSQL = strSQL & "FROM tblSchool WHERE Id = " & intKey
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                If ds Is Nothing Then
                ElseIf ds.Tables.Count = 0 Then
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                Else
                    ' Load it!...
                End If
                With ds.Tables(0).Rows(0)
                    ClearFields()
                    If Not .Item("AdminADMrMs") Is System.DBNull.Value Then
                        cboMrMsSup.SelectedValue = .Item("AdminADMrMs")
                    End If
                    If Not .Item("AdminADFirst") Is System.DBNull.Value Then
                        txtFirstNameSup.Text = .Item("AdminADFirst")
                    End If
                    If Not .Item("AdminADLast") Is System.DBNull.Value Then
                        txtLastNameSup.Text = .Item("AdminADLast")
                    End If
                    If Not .Item("AdminADMailingAddress") Is System.DBNull.Value Then
                        txtMailingAddressSup.Text = .Item("AdminADMailingAddress")
                    End If
                    If Not .Item("AdminADStreetAddress") Is System.DBNull.Value Then
                        txtPhysicalAddress.Text = .Item("AdminADStreetAddress")
                    End If
                    If Not .Item("AdminADPhoneSchool") Is System.DBNull.Value Then
                        txtSchoolPhoneSup.Text = .Item("AdminADPhoneSchool")
                    End If
                    If Not .Item("AdminADPhoneSchoolExt") Is System.DBNull.Value Then
                        txtSchoolPhoneSupExt.Text = .Item("AdminADPhoneSchoolExt")
                    End If
                    If Not .Item("AdminADPhoneCell") Is System.DBNull.Value Then
                        txtCellSup.Text = .Item("AdminADPhoneCell")
                    End If
                    If Not .Item("AdminADPhoneFax") Is System.DBNull.Value Then
                        txtSchoolFaxSup.Text = .Item("AdminADPhoneFax")
                    End If
                    If Not .Item("AdminADEmail") Is System.DBNull.Value Then
                        txtSchoolEmailSup.Text = .Item("AdminADEmail")
                    End If
                    If Not .Item("MailingCity") Is System.DBNull.Value Then
                        txtMailingCitySup.Text = .Item("MailingCity")
                    End If
                    If Not .Item("MailingState") Is System.DBNull.Value Then
                        txtMailingStateSup.Text = .Item("MailingState")
                    End If
                    If Not .Item("MailingZip") Is System.DBNull.Value Then
                        txtMailingZipSup.Text = .Item("MailingZip")
                    End If
                    Session("intSchoolID") = .Item("intSchoolID")
                End With

            Case Else
        End Select

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedValue = "Select..." Then
        Else
            Me.txtOther.Text = ""
            If Session("multi") > 0 Then
                If DropDownList1.SelectedValue = "Superintendent" Then
                    ' Load yourself...
                    LoadSelection(DropDownList1.SelectedValue, Session("key"))
                Else
                    LoadSelection(DropDownList1.SelectedValue, cboMulti.SelectedValue)
                End If
            Else
                LoadSelection(DropDownList1.SelectedValue, Session("key"))
            End If
        End If
    End Sub

    Protected Sub cmdCancelChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelChanges.Click
        Response.Redirect("MemberHome.aspx")
    End Sub

    Public Sub ClearFields()
        cboMrMsSup.SelectedIndex = 0
        txtFirstNameSup.Text = ""
        txtLastNameSup.Text = ""
        txtMailingAddressSup.Text = ""
        txtPhysicalAddress.Text = ""
        txtSchoolPhoneSup.Text = ""
        txtSchoolPhoneSupExt.Text = ""
        txtCellSup.Text = ""
        txtSchoolFaxSup.Text = ""
        txtSchoolEmailSup.Text = ""
        txtMailingCitySup.Text = ""
        txtMailingStateSup.Text = ""
        txtMailingZipSup.Text = ""
    End Sub

    Protected Sub cboMulti_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboMulti.SelectedIndexChanged
        If cboMulti.SelectedIndex > 0 Then
            ClearFields()
            LoadSchool(cboMulti.SelectedValue)
        End If
    End Sub
End Class