Public Class StateScoreboardSwimmingMOBI
    Inherits System.Web.UI.Page

    Public Function GetSQLStringSelection(ByVal strKey As String, ByVal strSelection As String) As String
        Dim strSQL As String
        strSQL = "SELECT tblPlayoffDetail.txtLink "
        strSQL = strSQL & "FROM tblPlayoffHeader INNER JOIN "
        strSQL = strSQL & "tblPlayoffDetail ON tblPlayoffHeader.Id = tblPlayoffDetail.intEvent "
        strSQL = strSQL & "WHERE tblPlayoffHeader.strType = '" & strKey & "' AND tblPlayoffDetail.strTeam1 = '" & strSelection & "' "
        Return strSQL
    End Function



    Public Function GetLink(ByVal strKey As String, ByVal strSelection As String) As String
        Dim strSQL As String = ""
        Dim strReturn As Object = ""

        strSQL = GetSQLStringSelection(strKey, strSelection)

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, Data.CommandType.Text, strSQL)
            If strReturn = "" Then strReturn = "No Results"
        Catch
            strReturn = "No Results"
        End Try

        Return strReturn
    End Function

    Protected Sub cbo6AG_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo6AG.SelectedIndexChanged
        txtClass6AGInd.Text = GetLink("Swimming6AG", cbo6AG.SelectedItem.Text)
    End Sub

    Protected Sub cbo6AB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo6AB.SelectedIndexChanged
        txtClass6ABInd.Text = GetLink("Swimming6AB", cbo6AB.SelectedItem.Text)
    End Sub

    Protected Sub cbo5AG_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo5AG.SelectedIndexChanged
        txtClass5AGInd.Text = GetLink("Swimming5AG", cbo5AG.SelectedItem.Text)
    End Sub

    Protected Sub cbo5AB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo5AB.SelectedIndexChanged
        txtClass5ABInd.Text = GetLink("Swimming5AB", cbo5AB.SelectedItem.Text)
    End Sub

    Private Sub frmSwimming_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmSwimming.Load
        If Not IsPostBack Then
            Me.cbo6AG.DataSource = Me.SqlDataSource2
            Me.cbo6AG.DataBind()
            Me.cbo6AB.DataSource = Me.SqlDataSource1
            Me.cbo6AB.DataBind()
            Me.cbo5AG.DataSource = Me.SqlDataSource4
            Me.cbo5AG.DataBind()
            Me.cbo5AB.DataSource = Me.SqlDataSource3
            Me.cbo5AB.DataBind()
        End If
    End Sub
End Class