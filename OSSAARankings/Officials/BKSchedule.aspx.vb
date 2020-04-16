Partial Class BKSchedule
    Inherits System.Web.UI.Page

    Dim objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'EnableObjects(False)
        'lblMessage.Text = "No longer available."
        'Exit Sub

        If Not IsPostBack Then
            EnableObjects(False)
        End If

        objDashboard = New clsDashboard("SCHEDULE", "Basketball", clsFunctions.GetCurrentYear)

        Dim strReturn As String = "OK"

        If strReturn = "OK" Then
            If Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
                If txtEmail.Text = "" Then
                Else
                    EnableObjects(True)
                End If
            ElseIf Now < objDashboard.gReadyDate Then
                Me.lblMessage.Text = "Officials Basketball Schedule Entry will be available " & objDashboard.gReadyDate.ToLongDateString & " @ " & objDashboard.gReadyTime
            Else
                Me.lblMessage.Text = "This option is now closed."
            End If
        Else
            ' NOTHING...
        End If


    End Sub

    Public Sub LoadData()
        Dim strSQL As String
        Dim ds As DataSet
        Dim ds1 As DataSet

        strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE strEmail = '" & Session("gEmail") & "'"
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
            strSQL = "SELECT * FROM " & objDashboard.gTableSourceDetail & " WHERE HeaderID = " & Session("id") & " ORDER BY dtmGame"
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
                            cboGameTime1.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType1.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime1.BackColor = Drawing.Color.Yellow
                            cboGameType1.BackColor = Drawing.Color.Yellow
                            WebDateChooser1.BackColor = Drawing.Color.Yellow
                            DropDownList1.BackColor = Drawing.Color.Yellow
                        Case 1
                            WebDateChooser2.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList2.Items.Count > 0 Then
                                DropDownList2.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID2") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime2.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType2.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime2.BackColor = Drawing.Color.Yellow
                            cboGameType2.BackColor = Drawing.Color.Yellow
                            WebDateChooser2.BackColor = Drawing.Color.Yellow
                            DropDownList2.BackColor = Drawing.Color.Yellow
                        Case 2
                            WebDateChooser3.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList3.Items.Count > 0 Then
                                DropDownList3.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID3") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime3.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType3.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime3.BackColor = Drawing.Color.Yellow
                            cboGameType3.BackColor = Drawing.Color.Yellow
                            WebDateChooser3.BackColor = Drawing.Color.Yellow
                            DropDownList3.BackColor = Drawing.Color.Yellow
                        Case 3
                            WebDateChooser4.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList4.Items.Count > 0 Then
                                DropDownList4.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID4") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime4.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType4.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime4.BackColor = Drawing.Color.Yellow
                            cboGameType4.BackColor = Drawing.Color.Yellow
                            WebDateChooser4.BackColor = Drawing.Color.Yellow
                            DropDownList4.BackColor = Drawing.Color.Yellow
                        Case 4
                            WebDateChooser5.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList5.Items.Count > 0 Then
                                DropDownList5.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID5") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime5.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType5.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime5.BackColor = Drawing.Color.Yellow
                            cboGameType5.BackColor = Drawing.Color.Yellow
                            WebDateChooser5.BackColor = Drawing.Color.Yellow
                            DropDownList5.BackColor = Drawing.Color.Yellow
                        Case 5
                            WebDateChooser6.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList6.Items.Count > 0 Then
                                DropDownList6.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID6") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime6.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType6.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime6.BackColor = Drawing.Color.Yellow
                            cboGameType6.BackColor = Drawing.Color.Yellow
                            WebDateChooser6.BackColor = Drawing.Color.Yellow
                            DropDownList6.BackColor = Drawing.Color.Yellow
                        Case 6
                            WebDateChooser7.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList7.Items.Count > 0 Then
                                DropDownList7.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID7") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime7.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType7.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime7.BackColor = Drawing.Color.Yellow
                            cboGameType7.BackColor = Drawing.Color.Yellow
                            WebDateChooser7.BackColor = Drawing.Color.Yellow
                            DropDownList7.BackColor = Drawing.Color.Yellow
                        Case 7
                            WebDateChooser8.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList8.Items.Count > 0 Then
                                DropDownList8.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID8") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime8.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType8.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime8.BackColor = Drawing.Color.Yellow
                            cboGameType8.BackColor = Drawing.Color.Yellow
                            WebDateChooser8.BackColor = Drawing.Color.Yellow
                            DropDownList8.BackColor = Drawing.Color.Yellow
                        Case 8
                            WebDateChooser9.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList9.Items.Count > 0 Then
                                DropDownList9.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID9") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime9.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType9.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime9.BackColor = Drawing.Color.Yellow
                            cboGameType9.BackColor = Drawing.Color.Yellow
                            WebDateChooser9.BackColor = Drawing.Color.Yellow
                            DropDownList9.BackColor = Drawing.Color.Yellow
                        Case 9
                            WebDateChooser10.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList10.Items.Count > 0 Then
                                DropDownList10.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID10") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime10.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType10.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime10.BackColor = Drawing.Color.Yellow
                            cboGameType10.BackColor = Drawing.Color.Yellow
                            WebDateChooser10.BackColor = Drawing.Color.Yellow
                            DropDownList10.BackColor = Drawing.Color.Yellow
                        Case 10
                            WebDateChooser11.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList11.Items.Count > 0 Then
                                DropDownList11.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID11") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime11.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType11.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime11.BackColor = Drawing.Color.Yellow
                            cboGameType11.BackColor = Drawing.Color.Yellow
                            WebDateChooser11.BackColor = Drawing.Color.Yellow
                            DropDownList11.BackColor = Drawing.Color.Yellow
                        Case 11
                            WebDateChooser12.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList12.Items.Count > 0 Then
                                DropDownList12.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID12") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime12.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType12.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime12.BackColor = Drawing.Color.Yellow
                            cboGameType12.BackColor = Drawing.Color.Yellow
                            WebDateChooser12.BackColor = Drawing.Color.Yellow
                            DropDownList12.BackColor = Drawing.Color.Yellow
                        Case 12
                            WebDateChooser13.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList13.Items.Count > 0 Then
                                DropDownList13.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID13") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime13.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType13.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime13.BackColor = Drawing.Color.Yellow
                            cboGameType13.BackColor = Drawing.Color.Yellow
                            WebDateChooser13.BackColor = Drawing.Color.Yellow
                            DropDownList13.BackColor = Drawing.Color.Yellow
                        Case 13
                            WebDateChooser14.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList14.Items.Count > 0 Then
                                DropDownList14.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID14") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime14.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType14.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime14.BackColor = Drawing.Color.Yellow
                            cboGameType14.BackColor = Drawing.Color.Yellow
                            WebDateChooser14.BackColor = Drawing.Color.Yellow
                            DropDownList14.BackColor = Drawing.Color.Yellow
                        Case 14
                            WebDateChooser15.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList15.Items.Count > 0 Then
                                DropDownList15.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID15") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime15.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType15.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime15.BackColor = Drawing.Color.Yellow
                            cboGameType15.BackColor = Drawing.Color.Yellow
                            WebDateChooser15.BackColor = Drawing.Color.Yellow
                            DropDownList15.BackColor = Drawing.Color.Yellow
                        Case 15
                            WebDateChooser16.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList16.Items.Count > 0 Then
                                DropDownList16.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID16") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime16.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType16.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime16.BackColor = Drawing.Color.Yellow
                            cboGameType16.BackColor = Drawing.Color.Yellow
                            WebDateChooser16.BackColor = Drawing.Color.Yellow
                            DropDownList16.BackColor = Drawing.Color.Yellow
                        Case 16
                            WebDateChooser17.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList17.Items.Count > 0 Then
                                DropDownList17.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID17") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime17.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType17.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime17.BackColor = Drawing.Color.Yellow
                            cboGameType17.BackColor = Drawing.Color.Yellow
                            WebDateChooser17.BackColor = Drawing.Color.Yellow
                            DropDownList17.BackColor = Drawing.Color.Yellow
                        Case 17
                            WebDateChooser18.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList18.Items.Count > 0 Then
                                DropDownList18.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID18") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime18.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType18.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime18.BackColor = Drawing.Color.Yellow
                            cboGameType18.BackColor = Drawing.Color.Yellow
                            WebDateChooser18.BackColor = Drawing.Color.Yellow
                            DropDownList18.BackColor = Drawing.Color.Yellow
                        Case 18
                            WebDateChooser19.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList19.Items.Count > 0 Then
                                DropDownList19.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID19") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime19.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType19.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime19.BackColor = Drawing.Color.Yellow
                            cboGameType19.BackColor = Drawing.Color.Yellow
                            WebDateChooser19.BackColor = Drawing.Color.Yellow
                            DropDownList19.BackColor = Drawing.Color.Yellow
                        Case 19
                            WebDateChooser20.Value = ds1.Tables(0).Rows(x).Item("dtmGame")
                            If DropDownList20.Items.Count > 0 Then
                                DropDownList20.SelectedValue = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            Else
                                Session("intSchoolID20") = ds1.Tables(0).Rows(x).Item("intSchoolID")
                            End If
                            cboGameTime20.SelectedValue = ds1.Tables(0).Rows(x).Item("strWhen")
                            cboGameType20.SelectedValue = ds1.Tables(0).Rows(x).Item("strType")
                            cboGameTime20.BackColor = Drawing.Color.Yellow
                            cboGameType20.BackColor = Drawing.Color.Yellow
                            WebDateChooser20.BackColor = Drawing.Color.Yellow
                            DropDownList20.BackColor = Drawing.Color.Yellow
                    End Select
                Next
            End If
        End If
    End Sub

    Public Sub SaveData(ByVal id As Integer)
        Dim strSQL As String = ""

        strSQL = "UPDATE " & objDashboard.gTableSource & " SET strName = '" & Me.txtName.Text & "', strEmail = '" & Me.txtEmail.Text & "', strOSSAAID = '" & Me.txtOSSAAID.Text & "' WHERE Id = " & id
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        strSQL = "DELETE FROM " & objDashboard.gTableSourceDetail & " WHERE HeaderId = " & id
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        ' Insert the new stuff...
        If DropDownList1.SelectedIndex > 0 Then
            If WebDateChooser1.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser1.Text & "', " & DropDownList1.SelectedValue & ", '" & cboGameType1.SelectedValue & "', '" & cboGameTime1.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList2.SelectedIndex > 0 Then
            If WebDateChooser2.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser2.Text & "', " & DropDownList2.SelectedValue & ", '" & cboGameType2.SelectedValue & "', '" & cboGameTime2.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList3.SelectedIndex > 0 Then
            If WebDateChooser3.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser3.Text & "', " & DropDownList3.SelectedValue & ", '" & cboGameType3.SelectedValue & "', '" & cboGameTime3.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList4.SelectedIndex > 0 Then
            If WebDateChooser4.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser4.Text & "', " & DropDownList4.SelectedValue & ", '" & cboGameType4.SelectedValue & "', '" & cboGameTime4.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList5.SelectedIndex > 0 Then
            If WebDateChooser5.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser5.Text & "', " & DropDownList5.SelectedValue & ", '" & cboGameType5.SelectedValue & "', '" & cboGameTime5.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList6.SelectedIndex > 0 Then
            If WebDateChooser6.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser6.Text & "', " & DropDownList6.SelectedValue & ", '" & cboGameType6.SelectedValue & "', '" & cboGameTime6.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList7.SelectedIndex > 0 Then
            If WebDateChooser7.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser7.Text & "', " & DropDownList7.SelectedValue & ", '" & cboGameType7.SelectedValue & "', '" & cboGameTime7.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList8.SelectedIndex > 0 Then
            If WebDateChooser8.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser8.Text & "', " & DropDownList8.SelectedValue & ", '" & cboGameType8.SelectedValue & "', '" & cboGameTime8.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList9.SelectedIndex > 0 Then
            If WebDateChooser9.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser9.Text & "', " & DropDownList9.SelectedValue & ", '" & cboGameType9.SelectedValue & "', '" & cboGameTime9.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList10.SelectedIndex > 0 Then
            If WebDateChooser10.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser10.Text & "', " & DropDownList10.SelectedValue & ", '" & cboGameType10.SelectedValue & "', '" & cboGameTime10.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList11.SelectedIndex > 0 Then
            If WebDateChooser11.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser11.Text & "', " & DropDownList11.SelectedValue & ", '" & cboGameType11.SelectedValue & "', '" & cboGameTime11.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList12.SelectedIndex > 0 Then
            If WebDateChooser12.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser12.Text & "', " & DropDownList12.SelectedValue & ", '" & cboGameType12.SelectedValue & "', '" & cboGameTime12.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList13.SelectedIndex > 0 Then
            If WebDateChooser13.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser13.Text & "', " & DropDownList13.SelectedValue & ", '" & cboGameType13.SelectedValue & "', '" & cboGameTime13.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList14.SelectedIndex > 0 Then
            If WebDateChooser14.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser14.Text & "', " & DropDownList14.SelectedValue & ", '" & cboGameType14.SelectedValue & "', '" & cboGameTime14.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList15.SelectedIndex > 0 Then
            If WebDateChooser15.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser15.Text & "', " & DropDownList15.SelectedValue & ", '" & cboGameType15.SelectedValue & "', '" & cboGameTime15.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList16.SelectedIndex > 0 Then
            If WebDateChooser16.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser16.Text & "', " & DropDownList16.SelectedValue & ", '" & cboGameType16.SelectedValue & "', '" & cboGameTime16.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList17.SelectedIndex > 0 Then
            If WebDateChooser17.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser17.Text & "', " & DropDownList17.SelectedValue & ", '" & cboGameType17.SelectedValue & "', '" & cboGameTime17.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList18.SelectedIndex > 0 Then
            If WebDateChooser18.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser18.Text & "', " & DropDownList18.SelectedValue & ", '" & cboGameType18.SelectedValue & "', '" & cboGameTime18.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList19.SelectedIndex > 0 Then
            If WebDateChooser19.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser19.Text & "', " & DropDownList19.SelectedValue & ", '" & cboGameType19.SelectedValue & "', '" & cboGameTime19.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

        If DropDownList20.SelectedIndex > 0 Then
            If WebDateChooser20.Value Is Nothing Then
                ' Do nothing...
            Else
                strSQL = "INSERT INTO " & objDashboard.gTableSourceDetail & " (HeaderID, dtmGame, intSchoolID, strType, strWhen) VALUES (" & id & ", '" & WebDateChooser20.Text & "', " & DropDownList20.SelectedValue & ", '" & cboGameType20.SelectedValue & "', '" & cboGameTime20.SelectedValue & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If
        End If

    End Sub
    Public Sub EnableObjects(ByVal ysnVisible As Boolean)

        row001.Visible = ysnVisible
        row002.Visible = ysnVisible
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
        row16.Visible = ysnVisible
        row17.Visible = ysnVisible
        row18.Visible = ysnVisible
        row19.Visible = ysnVisible
        row20.Visible = ysnVisible
        rowSave.Visible = ysnVisible
        rowHelp.Visible = ysnVisible

    End Sub

    Private Sub DropDownList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.DataBound

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

    Private Sub DropDownList2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.DataBound

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

    Private Sub DropDownList3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.DataBound

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

    Private Sub DropDownList4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList4.DataBound

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

    Private Sub DropDownList5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList5.DataBound

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

    Private Sub DropDownList6_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList6.DataBound
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

    Private Sub DropDownList7_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList7.DataBound

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

    Private Sub DropDownList8_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList8.DataBound

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

    Private Sub DropDownList9_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList9.DataBound

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

    Private Sub DropDownList10_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList10.DataBound

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

    Private Sub DropDownList11_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList11.DataBound

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

    Private Sub DropDownList12_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList12.DataBound

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

    Private Sub DropDownList13_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList13.DataBound

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

    Private Sub DropDownList14_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList14.DataBound

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

    Private Sub DropDownList15_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList15.DataBound

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

    Private Sub DropDownList16_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList16.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList16.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList16.Items.Insert(0, objItem)

        DropDownList16.SelectedValue = Session("intSchoolID16")

    End Sub

    Private Sub DropDownList17_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList17.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList17.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList17.Items.Insert(0, objItem)

        DropDownList17.SelectedValue = Session("intSchoolID17")

    End Sub

    Private Sub DropDownList18_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList18.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList18.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList18.Items.Insert(0, objItem)

        DropDownList18.SelectedValue = Session("intSchoolID18")

    End Sub

    Private Sub DropDownList19_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList19.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList19.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList19.Items.Insert(0, objItem)

        DropDownList19.SelectedValue = Session("intSchoolID19")

    End Sub

    Private Sub DropDownList20_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList20.DataBound

        Dim objItem1 As New System.Web.UI.WebControls.ListItem
        objItem1.Text = "NON-OSSAA MEMBER SCHOOL"
        objItem1.Value = 0
        DropDownList20.Items.Insert(0, objItem1)

        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Text = "No site selected..."
        objItem.Value = -1
        DropDownList20.Items.Insert(0, objItem)

        DropDownList20.SelectedValue = Session("intSchoolID20")

    End Sub

    Private Sub cmdGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        Dim strSQL As String = ""
        Dim id As Integer = 0

        If txtEmail.Text = "" Then
            EnableObjects(False)
        Else

            If Now >= objDashboard.gStartDate And Now <= objDashboard.gEndDate Then
                ' Does this email exist?
                id = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT ID FROM " & objDashboard.gTableSource & " WHERE strEmail = '" & txtEmail.Text & "'")
                If id = 0 Then
                    ' Insert record...
                    strSQL = "INSERT INTO " & objDashboard.gTableSource & " (strEmail) VALUES ('" & Me.txtEmail.Text & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                End If

                Session("gEmail") = txtEmail.Text
                EnableObjects(True)
                ClearObjects()
                LoadData()
            ElseIf Now < objDashboard.gReadyDate Then
                Me.lblMessage.Text = "Officials Basketball Schedule Entry will be available " & objDashboard.gReadyDate.ToLongDateString & " @ " & objDashboard.gReadyTime
            Else
                Me.lblMessage.Text = "This option is now closed."
            End If

        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim strMessage As String = "OK"

        strMessage = VerifyData()
        If strMessage = "OK" Then
            SaveData(Session("id"))
            ClearObjects()
            LoadData()
            lblMessage.Text = "Changes saved."
        Else
            lblMessage.Text = strMessage
        End If
    End Sub

    Public Sub ClearObjects()
        On Error Resume Next
        DropDownList1.SelectedIndex = -1
        DropDownList2.SelectedIndex = -1
        DropDownList3.SelectedIndex = -1
        DropDownList4.SelectedIndex = -1
        DropDownList5.SelectedIndex = -1
        DropDownList6.SelectedIndex = -1
        DropDownList7.SelectedIndex = -1
        DropDownList8.SelectedIndex = -1
        DropDownList9.SelectedIndex = -1
        DropDownList10.SelectedIndex = -1
        DropDownList11.SelectedIndex = -1
        DropDownList12.SelectedIndex = -1
        DropDownList13.SelectedIndex = -1
        DropDownList14.SelectedIndex = -1
        DropDownList15.SelectedIndex = -1
        DropDownList16.SelectedIndex = -1
        DropDownList17.SelectedIndex = -1
        DropDownList18.SelectedIndex = -1
        DropDownList19.SelectedIndex = -1
        DropDownList20.SelectedIndex = -1
        WebDateChooser1.Value = System.DBNull.Value
        WebDateChooser2.Value = System.DBNull.Value
        WebDateChooser3.Value = System.DBNull.Value
        WebDateChooser4.Value = System.DBNull.Value
        WebDateChooser5.Value = System.DBNull.Value
        WebDateChooser6.Value = System.DBNull.Value
        WebDateChooser7.Value = System.DBNull.Value
        WebDateChooser8.Value = System.DBNull.Value
        WebDateChooser9.Value = System.DBNull.Value
        WebDateChooser10.Value = System.DBNull.Value
        WebDateChooser11.Value = System.DBNull.Value
        WebDateChooser12.Value = System.DBNull.Value
        WebDateChooser13.Value = System.DBNull.Value
        WebDateChooser14.Value = System.DBNull.Value
        WebDateChooser15.Value = System.DBNull.Value
        WebDateChooser16.Value = System.DBNull.Value
        WebDateChooser17.Value = System.DBNull.Value
        WebDateChooser18.Value = System.DBNull.Value
        WebDateChooser19.Value = System.DBNull.Value
        WebDateChooser20.Value = System.DBNull.Value
        cboGameTime1.SelectedIndex = -1
        cboGameTime2.SelectedIndex = -1
        cboGameTime3.SelectedIndex = -1
        cboGameTime4.SelectedIndex = -1
        cboGameTime5.SelectedIndex = -1
        cboGameTime6.SelectedIndex = -1
        cboGameTime7.SelectedIndex = -1
        cboGameTime8.SelectedIndex = -1
        cboGameTime9.SelectedIndex = -1
        cboGameTime10.SelectedIndex = -1
        cboGameTime11.SelectedIndex = -1
        cboGameTime12.SelectedIndex = -1
        cboGameTime13.SelectedIndex = -1
        cboGameTime14.SelectedIndex = -1
        cboGameTime15.SelectedIndex = -1
        cboGameTime16.SelectedIndex = -1
        cboGameTime17.SelectedIndex = -1
        cboGameTime18.SelectedIndex = -1
        cboGameTime19.SelectedIndex = -1
        cboGameTime20.SelectedIndex = -1
        cboGameType1.SelectedValue = -1
        cboGameType2.SelectedValue = -1
        cboGameType3.SelectedValue = -1
        cboGameType4.SelectedValue = -1
        cboGameType5.SelectedValue = -1
        cboGameType6.SelectedValue = -1
        cboGameType7.SelectedValue = -1
        cboGameType8.SelectedValue = -1
        cboGameType9.SelectedValue = -1
        cboGameType10.SelectedValue = -1
        cboGameType11.SelectedValue = -1
        cboGameType12.SelectedValue = -1
        cboGameType13.SelectedValue = -1
        cboGameType14.SelectedValue = -1
        cboGameType15.SelectedValue = -1
        cboGameType16.SelectedValue = -1
        cboGameType17.SelectedValue = -1
        cboGameType18.SelectedValue = -1
        cboGameType19.SelectedValue = -1
        cboGameType20.SelectedValue = -1
    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"
        If txtName.Text = "" Then
            strReturn = "You must enter your NAME."
        ElseIf txtEmail.Text = "" Then
            strReturn = "You must enter your EMAIL."
        ElseIf txtOSSAAID.Text = "" Then
            strReturn = "You must enter you OSSAAID#."
        Else

        End If
        Return strReturn
    End Function
End Class