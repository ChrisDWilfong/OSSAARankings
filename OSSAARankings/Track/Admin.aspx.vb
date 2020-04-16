Public Class Admin
    Inherits System.Web.UI.Page

    Public strTableRegionalSites As String = "tblTrackRegionalSites"
    Public strTableRegionalSitesCalc As String = "tblTrackRegionalSitesCalc"
    Public strViewTrackParticipants As String = "viewTrackParticipants"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        ' NOTE
        ' - Creates the content for 'tblTrackRegionalSitesCalc' which contains all of the distances
        '   between the regional sites and the schools (via Google)...
        '
        Dim strSQL As String = ""
        Dim dsSites As DataSet
        Dim ds As DataSet
        Dim strClass As String = ""
        Dim strZipCodeSite As String = ""
        Dim strZipCodeSchool As String = ""
        Dim intMiles As Long = 0
        Dim x As Integer = 0
        Dim y As Integer = 0

        strClass = cboClasses.SelectedValue

        If strClass = "NONE" Then
            lblMessage.Text = "You must select a CLASS."
        Else
            ' Delete Existing...
            strSQL = "DELETE FROM " & strTableRegionalSitesCalc & " WHERE strClass = '" & strClass & "' AND intYear = " & clsFunctions.GetCurrentYear()
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

            ' Scroll thru the sites...
            strSQL = "SELECT * FROM " & strTableRegionalSites & " WHERE strClass = '" & strClass & "' AND intYear = " & clsFunctions.GetCurrentYear()
            dsSites = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

            If dsSites Is Nothing Then
                lblMessage.Text = "No Regional sites found."
            ElseIf dsSites.Tables.Count = 0 Then
                lblMessage.Text = "No Regional sites found."
            ElseIf dsSites.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = "No Regional sites found."
            Else
                For x = 0 To dsSites.Tables(0).Rows.Count - 1
                    strZipCodeSite = dsSites.Tables(0).Rows(x).Item("strZipCode")

                    ' NOTE intYear = CurrentYear() is in the view...
                    strSQL = "SELECT * FROM " & strViewTrackParticipants & " WHERE strClass = '" & strClass & "' ORDER BY strSchool"
                    ' Let's scroll thru the schools...
                    ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

                    If ds Is Nothing Then
                        lblMessage.Text = "No Schools found."
                    ElseIf ds.Tables.Count = 0 Then
                        lblMessage.Text = "No Schools found."
                    ElseIf ds.Tables(0).Rows.Count = 0 Then
                        lblMessage.Text = "No Schools found."
                    Else
                        ' Scroll thru the SCHOOLS...
                        For y = 0 To ds.Tables(0).Rows.Count - 1
                            ' Get miles...
                            intMiles = 0
                            strZipCodeSchool = ds.Tables(0).Rows(y).Item("strZipCode")
                            intMiles = clsGoogleMaps.GetMiles(strZipCodeSite, strZipCodeSchool)
                            ' INSERT the records...
                            If intMiles = 0 Then
                                ' Skip...
                            Else
                                If intMiles = 9999 Then intMiles = 0
                                strSQL = "INSERT INTO " & strTableRegionalSitesCalc & " (strClass, intMiles, idRegionalSite, idSchool, strSchoolRegional, strSchool, strZipCodeRegional, strZipCode) VALUES ("
                                strSQL = strSQL & "'" & strClass & "', "
                                strSQL = strSQL & intMiles & ", "
                                strSQL = strSQL & dsSites.Tables(0).Rows(x).Item("Id") & ", "
                                strSQL = strSQL & ds.Tables(0).Rows(y).Item("idSchool") & ", "
                                strSQL = strSQL & "'" & UCase(dsSites.Tables(0).Rows(x).Item("strSchool")) & "', "
                                strSQL = strSQL & "'" & ds.Tables(0).Rows(y).Item("strSchool") & "', "
                                strSQL = strSQL & "'" & UCase(dsSites.Tables(0).Rows(x).Item("strZipCode")) & "', "
                                strSQL = strSQL & "'" & ds.Tables(0).Rows(y).Item("strZipCode") & "')"
                                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                            End If
                        Next
                    End If
                Next
                lblMessage.Text = strClass & " - Process complete."
            End If

        End If

    End Sub
End Class