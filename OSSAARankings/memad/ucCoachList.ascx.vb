Public Class ucCoachList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("madgCoachName") = "" Then
            Response.Redirect("adLogin.aspx")
        End If

        Dim strSQL As String
        Dim ds As DataSet

        strSQL = clsMembers.GetMembersFromSchoolSQL(Session("madgSchoolID"), clsFunctions.GetCurrentYear)
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub

End Class