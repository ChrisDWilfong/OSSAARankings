Public Class MemberInfoOSSAA
    Inherits System.Web.UI.Page

    ' Notes: 
    '   11/1/2010: Added VotingStreetAddress
    '

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblStep.Text = "Superintendent Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Superintendent information..."

        If Not IsPostBack Then
            If Session("usertype") <> "OSSAA" And Session("usertype") <> "OSSAAADMIN" Then
                Response.Redirect("MemberLogin.aspx")
            End If
        End If

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminSuperMrMs, AdminSuperFirst, AdminSuperLast, AdminSuperMailingAddress, AdminSuperStreetAddress, AdminSuperPhoneSchool, AdminSuperPhoneSchoolExt, AdminSuperPhoneCell, AdminSuperPhoneFax, AdminSuperEmail, MailingCity, MailingState, MailingZip "
            strSQL = strSQL & "FROM tblSchool WHERE Id = " & Session("key")
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                ' Load it!...
            End If
            With ds.Tables(0).Rows(0)
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

                If Not .Item("AdminSuperStreetAddress") Is System.DBNull.Value Then
                    txtPhysicalAddress.Text = .Item("AdminSuperStreetAddress")
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
            End With
        End If

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Protected Sub cmdSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveChanges.Click
        Dim strSQL As New StringBuilder
        Dim strMrMs As String = Me.cboMrMsSup.SelectedValue
        If strMrMs = "Select..." Then strMrMs = "Mr"

        If clsMembership.IsLoginADuplicate(Me.txtSchoolEmailSup.Text, Session("password"), Session("key"), Session("usertype"), Session("confirmed")) Then
            Me.lblMessage.Text = "Save canceled.  This is a duplicate username/password combination."
        Else
            strSQL.Append("UPDATE tblSchool SET AdminSuperMrMs = '" & strMrMs & "' ")
            strSQL.Append(", AdminSuperFirst = '" & Me.txtFirstNameSup.Text & "' ")
            strSQL.Append(", AdminSuperLast = '" & Me.txtLastNameSup.Text & "' ")
            strSQL.Append(", AdminSuperMailingAddress = '" & Me.txtMailingAddressSup.Text & "' ")
            strSQL.Append(", AdminSuperStreetAddress = '" & Me.txtPhysicalAddress.Text & "' ")

            strSQL.Append(", AdminSuperPhoneSchool = '" & Me.txtSchoolPhoneSup.Text & "' ")
            strSQL.Append(", AdminSuperPhoneSchoolExt = '" & Me.txtSchoolPhoneSupExt.Text & "' ")

            strSQL.Append(", AdminSuperPhoneCell = '" & Me.txtCellSup.Text & "' ")
            strSQL.Append(", AdminSuperPhoneFax = '" & Me.txtSchoolFaxSup.Text & "' ")
            strSQL.Append(", AdminSuperEmail = '" & Me.txtSchoolEmailSup.Text & "' ")
            strSQL.Append(", Username1 = '" & Me.txtSchoolEmailSup.Text & "' ")
            strSQL.Append(", MailingCity = '" & Me.txtMailingCitySup.Text & "' ")
            strSQL.Append(", MailingState = '" & Me.txtMailingStateSup.Text & "' ")
            strSQL.Append(", MailingZip = '" & Me.txtMailingZipSup.Text & "'")
            strSQL.Append(", dtmStampAdmin = '" & Now & "'")

            strSQL.Append(" WHERE Id = " & Session("key"))

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
                Session("user") = Me.txtSchoolEmailSup.Text
                Me.lblMessage.Text = "Changes saved."
            Catch
                Me.lblMessage.Text = "Change failed."
            End Try
        End If

    End Sub

    Private Sub MemberInfoSup_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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

    Protected Sub cmdChangeUsername_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeUsername.Click
        Response.Redirect("MemberChangePassword.aspx")
    End Sub

    Protected Sub cmdCancelChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelChanges.Click
        Response.Redirect("MemberHome.aspx")
    End Sub
End Class