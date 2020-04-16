Public Class ScoreScroller
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSQL = clsSchedules.GetScheduleSportDaySQL(DropDownClass.SelectedValue, "", "09/27/2019", "", 100, True)
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        RadRotator1.DataSource = ds
        RadRotator1.DataBind()
    End Sub

End Class