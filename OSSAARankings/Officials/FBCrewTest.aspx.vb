Partial Class FBCrewTest
    Inherits System.Web.UI.Page
    '
    ' TODO : Pull cboLocation from tblCrewTestLocations table (8/21/2017)...
    '
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("admin") = 1 Then
            If Not IsPostBack Then
                EnableObjects(False)
            End If
        Else
            If Not IsPostBack Then
                EnableObjects(False)
            End If
            'lblMessage.Text = "Site is closed."
            'cmdGo.Enabled = False
            'cmdSave.Enabled = False
            'Exit Sub
        End If

    End Sub

    Public Function LoadData() As String
        Dim strSQL As String
        Dim ds As DataSet
        Dim strResult As String = "OK"

        strSQL = "SELECT * FROM prodOfficials WHERE intOSSAAID > 0 AND strEmail = '" & Session("gEmail") & "'"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            strResult = "Invalid Email information."
        ElseIf ds.Tables.Count = 0 Then
            strResult = "Invalid Email information."
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strResult = "Invalid Email information."
        Else
            With ds.Tables(0).Rows(0)
                Session("id") = .Item("id")

                If CInt(.Item("intOSSAAID")) > 0 Then
                    Try
                        txtName.Text = .Item("strFirstName") & " " & .Item("strLastName")
                        txtName.Enabled = False
                    Catch
                        txtName.Text = ""
                    End Try
                    Try
                        txtOSSAAID.Text = .Item("intOSSAAID")
                        txtOSSAAID.Enabled = False
                    Catch
                        txtOSSAAID.Text = ""
                    End Try
                    Try
                        txtAreaCoord.Text = .Item("strCoordinator")
                    Catch
                        txtAreaCoord.Text = ""
                    End Try
                    ' Added 8/14/2017...
                    Try
                        cboLocation.SelectedValue = .Item("intCrewTestLocation")
                    Catch ex As Exception
                        cboLocation.SelectedValue = 0
                    End Try

                    If .Item("dtmStampCrewTest") Is System.DBNull.Value Then
                        lblMessage.Text = "Please submit your Area Coordinator information."
                    Else
                        lblMessage.Text = "YOUR INFORMATION HAS BEEN SUBMITTED TO THE OSSAA."
                    End If

                    Try
                        If .Item("ysnCurrentFootball") = True Then
                        Else
                            lblMessage.Text = "You are not currently enrolled as a football official."
                            EnableObjects(False)
                        End If
                    Catch
                    End Try

                Else
                    lblMessage.Text = "INVALID OSSAAID #"
                    EnableObjects(False)
                End If
            End With
        End If

        Return strResult

    End Function

    Public Sub SaveData(id As Integer)
        Dim strSQL As String = ""
        Dim strMessage As String

        strMessage = VerifyData()

        If strMessage = "OK" Then
            strSQL = "UPDATE prodOfficials SET intCrewTestLocation = " & cboLocation.SelectedValue & ", strCoordinator = '" & Replace(txtAreaCoord.Text, "'", "") & "', dtmStampCrewTest = '" & Now & "' WHERE Id = " & Session("id")
            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                lblMessage.Text = "YOUR INFORMATION HAS BEEN SUBMITTED TO THE OSSAA."
            Catch
                lblMessage.Text = "There was a problem saving your information.  Close your browser and try again."
            End Try
        Else
            lblMessage.Text = strMessage
        End If

    End Sub
    Public Sub EnableObjects(ysnVisible As Boolean)

        row001.Visible = ysnVisible
        row002.Visible = ysnVisible
        row003.Visible = ysnVisible
        row004.Visible = ysnVisible
        rowSave.Visible = ysnVisible

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        Dim strSQL As String = ""
        Dim id As Integer = 0
        Dim strResult As String = "OK"

        If txtEmail.Text = "" Then
            EnableObjects(False)
        Else
            Session("gEmail") = txtEmail.Text
            EnableObjects(True)
            strResult = LoadData()
            If strResult = "OK" Then
                lblMessage.Text = ""
            Else
                lblMessage.Text = strResult
                EnableObjects(False)
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strMessage As String = "OK"

        strMessage = VerifyData()
        If strMessage = "OK" Then
            SaveData(Session("id"))
            LoadData()
            lblMessage.Text = "YOUR INFORMATION HAS BEEN SUBMITTED TO THE OSSAA."
        Else
            lblMessage.Text = strMessage
        End If

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If txtName.Text = "" Then
            strReturn = "You must enter your NAME."
        ElseIf txtEmail.Text = "" Then
            strReturn = "You must enter your EMAIL."
        ElseIf txtOSSAAID.Text = "" Then
            strReturn = "You must enter your OSSAAID#."
        ElseIf txtAreaCoord.Text = "" Then
            strReturn = "You must enter your AREA COORDINATOR info."
        ElseIf cboLocation.SelectedValue = 0 Then
            strReturn = "You must select a TEST DATE/LOCATION."
        Else
            strReturn = "OK"
        End If

        Return strReturn
    End Function
End Class