Public Class FBSchedule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            EnableObjects(False)
            Session.Timeout = 60
        End If

        If Session("id") Is Nothing Then
            EnableObjects(False)
        End If

    End Sub

    Public Sub LoadData()
        Dim strSQL As String
        Dim ds As DataSet
        Dim ds1 As DataSet

        strSQL = "SELECT * FROM ossaauser.tblOfficialsAvailabilityFB WHERE strEmail = '" & Session("gEmail") & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                Session("id") = .Item("id")
                Try
                    txtName.Text = .Item("strName")
                Catch
                    txtName.Text = ""
                End Try
                Try
                    txtOSSAAID.Text = .Item("strOSSAAID")
                Catch
                    txtOSSAAID.Text = ""
                End Try
                Try
                    cboWH.SelectedValue = .Item("strWH")
                Catch
                    cboWH.SelectedIndex = 0
                End Try
                'Try
                '    txtWH1.Text = .Item("strOSSAAIDWH")
                'Catch
                '    txtWH1.Text = ""
                'End Try
                Try
                    txtWH2.Text = .Item("strNameWH")
                Catch
                    txtWH2.Text = ""
                End Try
            End With

            ' Set everything white...
            WebDateChooser1.Value = Nothing
            Try
                DropDownList1.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser1.BackColor = Drawing.Color.White
            DropDownList1.BackColor = Drawing.Color.White

            WebDateChooser2.Value = Nothing
            Try
                DropDownList2.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser2.BackColor = Drawing.Color.White
            DropDownList2.BackColor = Drawing.Color.White

            WebDateChooser3.Value = Nothing
            Try
                DropDownList3.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser3.BackColor = Drawing.Color.White
            DropDownList3.BackColor = Drawing.Color.White

            WebDateChooser4.Value = Nothing
            Try
                DropDownList4.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser4.BackColor = Drawing.Color.White
            DropDownList4.BackColor = Drawing.Color.White

            WebDateChooser5.Value = Nothing
            Try
                DropDownList5.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser5.BackColor = Drawing.Color.White
            DropDownList5.BackColor = Drawing.Color.White

            WebDateChooser6.Value = Nothing
            Try
                DropDownList6.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser6.BackColor = Drawing.Color.White
            DropDownList6.BackColor = Drawing.Color.White

            WebDateChooser7.Value = Nothing
            Try
                DropDownList7.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser7.BackColor = Drawing.Color.White
            DropDownList7.BackColor = Drawing.Color.White

            WebDateChooser8.Value = Nothing
            Try
                DropDownList8.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser8.BackColor = Drawing.Color.White
            DropDownList8.BackColor = Drawing.Color.White

            WebDateChooser9.Value = Nothing
            Try
                DropDownList9.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser9.BackColor = Drawing.Color.White
            DropDownList9.BackColor = Drawing.Color.White

            WebDateChooser10.Value = Nothing
            Try
                DropDownList10.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser10.BackColor = Drawing.Color.White
            DropDownList10.BackColor = Drawing.Color.White

            WebDateChooser11.Value = Nothing
            Try
                DropDownList11.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser11.BackColor = Drawing.Color.White
            DropDownList11.BackColor = Drawing.Color.White

            WebDateChooser12.Value = Nothing
            Try
                DropDownList12.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser12.BackColor = Drawing.Color.White
            DropDownList12.BackColor = Drawing.Color.White

            WebDateChooser13.Value = Nothing
            Try
                DropDownList13.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser13.BackColor = Drawing.Color.White
            DropDownList13.BackColor = Drawing.Color.White

            WebDateChooser14.Value = Nothing
            Try
                DropDownList14.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser14.BackColor = Drawing.Color.White
            DropDownList14.BackColor = Drawing.Color.White

            WebDateChooser15.Value = Nothing
            Try
                DropDownList15.SelectedIndex = 0
            Catch
            End Try
            WebDateChooser15.BackColor = Drawing.Color.White
            DropDownList15.BackColor = Drawing.Color.White

            ' Now load the detail..
            strSQL = "SELECT * FROM ossaauser.tblOfficialsAvailabilityDetailFB WHERE HeaderID = " & Session("id") & " ORDER BY dtmGame"
            ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds1 Is Nothing Then
            ElseIf ds1.Tables.Count = 0 Then
            ElseIf ds1.Tables(0).Rows.Count = 0 Then
            Else
                Dim x As Integer
                For x = 0 To ds1.Tables(0).Rows.Count - 1
                    Select Case x
                        Case 0
                            WebDateChooser1.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList1.Items.Count > 0 Then
                                DropDownList1.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                ' Set this, the value will be loaded on the DataBound event of the DropDown...
                                Session("intSchoolID1") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser1.BackColor = Drawing.Color.Yellow
                            DropDownList1.BackColor = Drawing.Color.Yellow
                        Case 1
                            WebDateChooser2.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList2.Items.Count > 0 Then
                                DropDownList2.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID2") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser2.BackColor = Drawing.Color.Yellow
                            DropDownList2.BackColor = Drawing.Color.Yellow
                        Case 2
                            WebDateChooser3.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList3.Items.Count > 0 Then
                                DropDownList3.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID3") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser3.BackColor = Drawing.Color.Yellow
                            DropDownList3.BackColor = Drawing.Color.Yellow
                        Case 3
                            WebDateChooser4.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList4.Items.Count > 0 Then
                                DropDownList4.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID4") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser4.BackColor = Drawing.Color.Yellow
                            DropDownList4.BackColor = Drawing.Color.Yellow
                        Case 4
                            WebDateChooser5.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList5.Items.Count > 0 Then
                                DropDownList5.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID5") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser5.BackColor = Drawing.Color.Yellow
                            DropDownList5.BackColor = Drawing.Color.Yellow
                        Case 5
                            WebDateChooser6.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList6.Items.Count > 0 Then
                                DropDownList6.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID6") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser6.BackColor = Drawing.Color.Yellow
                            DropDownList6.BackColor = Drawing.Color.Yellow
                        Case 6
                            WebDateChooser7.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList7.Items.Count > 0 Then
                                DropDownList7.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID7") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser7.BackColor = Drawing.Color.Yellow
                            DropDownList7.BackColor = Drawing.Color.Yellow
                        Case 7
                            WebDateChooser8.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList8.Items.Count > 0 Then
                                DropDownList8.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID8") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser8.BackColor = Drawing.Color.Yellow
                            DropDownList8.BackColor = Drawing.Color.Yellow
                        Case 8
                            WebDateChooser9.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList9.Items.Count > 0 Then
                                DropDownList9.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID9") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser9.BackColor = Drawing.Color.Yellow
                            DropDownList9.BackColor = Drawing.Color.Yellow
                        Case 9
                            WebDateChooser10.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList10.Items.Count > 0 Then
                                DropDownList10.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID10") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser10.BackColor = Drawing.Color.Yellow
                            DropDownList10.BackColor = Drawing.Color.Yellow
                        Case 10
                            WebDateChooser11.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList11.Items.Count > 0 Then
                                DropDownList11.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID11") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser11.BackColor = Drawing.Color.Yellow
                            DropDownList11.BackColor = Drawing.Color.Yellow
                        Case 11
                            WebDateChooser12.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList12.Items.Count > 0 Then
                                DropDownList12.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID12") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser12.BackColor = Drawing.Color.Yellow
                            DropDownList12.BackColor = Drawing.Color.Yellow
                        Case 12
                            WebDateChooser13.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList13.Items.Count > 0 Then
                                DropDownList13.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID13") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser13.BackColor = Drawing.Color.Yellow
                            DropDownList13.BackColor = Drawing.Color.Yellow
                        Case 13
                            WebDateChooser14.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList14.Items.Count > 0 Then
                                DropDownList14.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID14") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser14.BackColor = Drawing.Color.Yellow
                            DropDownList14.BackColor = Drawing.Color.Yellow
                        Case 14
                            WebDateChooser15.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList15.Items.Count > 0 Then
                                DropDownList15.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID15") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            WebDateChooser15.BackColor = Drawing.Color.Yellow
                            DropDownList15.BackColor = Drawing.Color.Yellow
                    End Select
                Next
            End If
        End If
    End Sub

    Public Sub SaveData(id As Integer)
        Dim strSQL As String = ""


        If cboWH.SelectedValue = "No" Then
            strSQL = "UPDATE ossaauser.tblOfficialsAvailabilityFB SET strName = '" & Me.txtName.Text & "', strEmail = '" & Me.txtEmail.Text & "', strOSSAAID = '" & Me.txtOSSAAID.Text & "', strWH = '" & cboWH.SelectedValue & "', strNameWH = '" & txtWH2.Text & "' WHERE Id = " & id
        Else
            strSQL = "UPDATE ossaauser.tblOfficialsAvailabilityFB SET strName = '" & Me.txtName.Text & "', strEmail = '" & Me.txtEmail.Text & "', strOSSAAID = '" & Me.txtOSSAAID.Text & "', strWH = '" & cboWH.SelectedValue & "', strNameWH = '' WHERE Id = " & id
        End If
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        strSQL = "DELETE FROM ossaauser.tblOfficialsAvailabilityDetailFB WHERE HeaderId = " & id
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        ' Insert the new stuff...
        If DropDownList1.SelectedIndex > 0 Then
            If WebDateChooser1.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser1.Text & "', " & DropDownList1.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList2.SelectedIndex > 0 Then
            If WebDateChooser2.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser2.Text & "', " & DropDownList2.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList3.SelectedIndex > 0 Then
            If WebDateChooser3.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser3.Text & "', " & DropDownList3.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList4.SelectedIndex > 0 Then
            If WebDateChooser4.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser4.Text & "', " & DropDownList4.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList5.SelectedIndex > 0 Then
            If WebDateChooser5.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser5.Text & "', " & DropDownList5.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList6.SelectedIndex > 0 Then
            If WebDateChooser6.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser6.Text & "', " & DropDownList6.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList7.SelectedIndex > 0 Then
            If WebDateChooser7.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser7.Text & "', " & DropDownList7.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList8.SelectedIndex > 0 Then
            If WebDateChooser8.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser8.Text & "', " & DropDownList8.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList9.SelectedIndex > 0 Then
            If WebDateChooser9.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser9.Text & "', " & DropDownList9.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList10.SelectedIndex > 0 Then
            If WebDateChooser10.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser10.Text & "', " & DropDownList10.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList11.SelectedIndex > 0 Then
            If WebDateChooser11.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser11.Text & "', " & DropDownList11.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList12.SelectedIndex > 0 Then
            If WebDateChooser12.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser12.Text & "', " & DropDownList12.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList13.SelectedIndex > 0 Then
            If WebDateChooser13.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser13.Text & "', " & DropDownList13.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList14.SelectedIndex > 0 Then
            If WebDateChooser14.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser14.Text & "', " & DropDownList14.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList15.SelectedIndex > 0 Then
            If WebDateChooser15.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityDetailFB (HeaderID, dtmGame, intSchoolID) VALUES (" & id & ", '" & WebDateChooser15.Text & "', " & DropDownList15.SelectedValue & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If


    End Sub
    Public Sub EnableObjects(ysnVisible As Boolean)

        row001.Visible = ysnVisible
        row002.Visible = ysnVisible
        row003.Visible = ysnVisible
        rowHeader.Visible = ysnVisible
        row1.Visible = ysnVisible
        row2.Visible = ysnVisible
        row3.Visible = ysnVisible
        row4.Visible = ysnVisible
        row5.Visible = ysnVisible
        row6.Visible = ysnVisible
        row7.Visible = ysnVisible
        row8.Visible = ysnVisible
        row9.Visible = ysnVisible
        row10.Visible = ysnVisible
        row11.Visible = ysnVisible
        row12.Visible = ysnVisible
        row13.Visible = ysnVisible
        row14.Visible = ysnVisible
        row15.Visible = ysnVisible
        rowSave.Visible = ysnVisible
        rowHelp.Visible = ysnVisible

        If ysnVisible = False Then
            'rowWH1.Visible = False
            rowWH2.Visible = False
        End If

    End Sub

    Private Sub DropDownList15_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList15.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList15.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList15.Items.Insert(0, objItem)

        DropDownList15.SelectedValue = Session("intSchoolID15")

    End Sub

    Private Sub DropDownList1_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList1.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList1.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList1.Items.Insert(0, objItem)

        DropDownList1.SelectedValue = Session("intSchoolID1")

    End Sub

    Private Sub DropDownList2_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList2.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList2.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList2.Items.Insert(0, objItem)

        DropDownList2.SelectedValue = Session("intSchoolID2")

    End Sub

    Private Sub DropDownList3_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList3.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList3.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList3.Items.Insert(0, objItem)

        DropDownList3.SelectedValue = Session("intSchoolID3")

    End Sub

    Private Sub DropDownList4_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList4.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList4.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList4.Items.Insert(0, objItem)

        DropDownList4.SelectedValue = Session("intSchoolID4")

    End Sub

    Private Sub DropDownList5_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList5.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList5.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList5.Items.Insert(0, objItem)

        DropDownList5.SelectedValue = Session("intSchoolID5")

    End Sub

    Private Sub DropDownList6_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList6.DataBound
        On Error Resume Next

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList6.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList6.Items.Insert(0, objItem)

        DropDownList6.SelectedValue = Session("intSchoolID6")

    End Sub

    Private Sub DropDownList7_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList7.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList7.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList7.Items.Insert(0, objItem)

        DropDownList7.SelectedValue = Session("intSchoolID7")

    End Sub

    Private Sub DropDownList8_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList8.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList8.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList8.Items.Insert(0, objItem)

        DropDownList8.SelectedValue = Session("intSchoolID8")

    End Sub

    Private Sub DropDownList9_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList9.DataBound

        Dim objItem9 As New System.Web.UI.WebControls.ListItem
        objItem9.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem9.Value = 0
        DropDownList9.Items.Insert(0, objItem9)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList9.Items.Insert(0, objItem)

        DropDownList9.SelectedValue = Session("intSchoolID9")

    End Sub

    Private Sub DropDownList10_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList10.DataBound

        Dim objItem10 As New System.Web.UI.WebControls.ListItem
        objItem10.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem10.Value = 0
        DropDownList10.Items.Insert(0, objItem10)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList10.Items.Insert(0, objItem)

        DropDownList10.SelectedValue = Session("intSchoolID10")

    End Sub

    Private Sub DropDownList11_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList11.DataBound

        Dim objItem11 As New System.Web.UI.WebControls.ListItem
        objItem11.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem11.Value = 0
        DropDownList11.Items.Insert(0, objItem11)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList11.Items.Insert(0, objItem)

        DropDownList11.SelectedValue = Session("intSchoolID11")

    End Sub

    Private Sub DropDownList12_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList12.DataBound

        Dim objItem12 As New System.Web.UI.WebControls.ListItem
        objItem12.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem12.Value = 0
        DropDownList12.Items.Insert(0, objItem12)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList12.Items.Insert(0, objItem)

        DropDownList12.SelectedValue = Session("intSchoolID12")

    End Sub

    Private Sub DropDownList13_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList13.DataBound

        Dim objItem13 As New System.Web.UI.WebControls.ListItem
        objItem13.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem13.Value = 0
        DropDownList13.Items.Insert(0, objItem13)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList13.Items.Insert(0, objItem)

        DropDownList13.SelectedValue = Session("intSchoolID13")

    End Sub

    Private Sub DropDownList14_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList14.DataBound

        Dim objItem14 As New System.Web.UI.WebControls.ListItem
        objItem14.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem14.Value = 0
        DropDownList14.Items.Insert(0, objItem14)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList14.Items.Insert(0, objItem)

        DropDownList14.SelectedValue = Session("intSchoolID14")

    End Sub

    Private Sub cboWH_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboWH.SelectedIndexChanged
        If cboWH.SelectedValue = "No" Then
            'rowWH1.Visible = True
            rowWH2.Visible = True
        Else
            'rowWH1.Visible = False
            rowWH2.Visible = False
        End If
    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        Dim strSQL As String = ""
        Dim id As Integer = 0

        If txtEmail.Text = "" Then
            EnableObjects(False)
        Else
            ' Does this email exist?
            id = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT ID FROM ossaauser.tblOfficialsAvailabilityFB WHERE strEmail = '" & txtEmail.Text & "'")
            If id = 0 Then
                ' Insert record...
                strSQL = "INSERT INTO ossaauser.tblOfficialsAvailabilityFB (strEmail) VALUES ('" & Me.txtEmail.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            Session("gEmail") = txtEmail.Text
            EnableObjects(True)
            LoadData()
            If cboWH.SelectedValue = "No" Then
                'rowWH1.Visible = True
                rowWH2.Visible = True
            Else
                'rowWH1.Visible = False
                rowWH2.Visible = False
            End If

        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strMessage As String = "OK"

        strMessage = VerifyData()
        If strMessage = "OK" Then
            SaveData(Session("id"))
            LoadData()
            lblMessage.Text = "Changes saved."
        Else
            lblMessage.Text = strMessage
        End If
    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"
        If cboWH.SelectedValue = "Select..." Then
            strReturn = "You must select 'Are You A White Hat?'"
        ElseIf txtName.Text = "" Then
            strReturn = "You must enter your NAME."
        ElseIf txtEmail.Text = "" Then
            strReturn = "You must enter your EMAIL."
        ElseIf txtOSSAAID.Text = "" Then
            strReturn = "You must enter you OSSAAID#."
        ElseIf cboWH.SelectedValue = "No" And txtWH2.Text = "" Then
            strReturn = "You must enter your WHITE HAT'S NAME."
        Else

        End If
        Return strReturn
    End Function
End Class