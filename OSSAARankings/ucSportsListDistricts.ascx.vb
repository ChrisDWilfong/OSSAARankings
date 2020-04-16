Public Class ucSportsListDistricts
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim ds As DataSet
            Dim x As Integer
            Dim strSQL As String
            Dim strDisplaySport As String = ""

            strSQL = "SELECT DISTINCT SportGenderKey, GenderSport1, GenderSport, Sport, Gender FROM tblSports WHERE intDistrictStandings > 0 ORDER BY GenderSport1"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                    objGroupBar.Value = ds.Tables(0).Rows(x).Item("GenderSport")
                    strDisplaySport = ds.Tables(0).Rows(x).Item("GenderSport1")
                    If strDisplaySport = "Baseball" Then
                        strDisplaySport = "Baseball (6A-4A)"
                    ElseIf strDisplaySport = "Fast Pitch" Then
                        strDisplaySport = "Fast Pitch (6A-2A)"
                    Else
                    End If
                    objGroupBar.Text = strDisplaySport
                    objGroupBar.NavigateUrl = "?sel=districts&spgk=" & ds.Tables(0).Rows(x).Item("SportGenderKey")
                    Me.ExplorerBarSportsListD.Groups.Add(objGroupBar)
                Next x
            End If

        End If
    End Sub

End Class