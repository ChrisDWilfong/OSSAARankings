Public Class ucSportsListSchools
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadData()
        End If

    End Sub

    Public Sub LoadData()
        On Error Resume Next

        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer

        '''''strSQL = "SELECT DISTINCT SchoolMatch1 AS strSchool, schoolID FROM tblSchools ORDER BY SchoolMatch1"       ' OLD...
        strSQL = "SELECT DISTINCT SchoolName AS strSchool, schoolID FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                CheckForNewGroup(ds.Tables(0).Rows(x), x)
                Dim objItem As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                'Dim objItem1 As New Infragistics.Web.UI.NavigationControls.ExplorerBarItem
                objItem.Text = ds.Tables(0).Rows(x).Item("strSchool")
                objItem.Value = ds.Tables(0).Rows(x).Item("schoolID")
                objItem.Expanded = False
                objItem.NavigateUrl = "?sel=ssch" & "&sc=" & ds.Tables(0).Rows(x).Item("schoolID") & "&st=OK"
                ExplorerBarSchoolsList.Groups(ExplorerBarSchoolsList.Groups.Count - 1).Items.Add(objItem)
            Next
        End If
    End Sub

    Public Sub CheckForNewGroup(dRow As System.Data.DataRow, intRow As Integer)
        Dim strLetter As String = ""

        Try
            strLetter = Left(dRow.Item("strSchool"), 1)
            strLetter = UCase(strLetter)
        Catch
        End Try

        If intRow = 0 Or Session("letter") <> strLetter Then
            If ExplorerBarSchoolsList.Groups.Count = 0 Then
                ' Add Group...
                Dim objGroup As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                objGroup.Text = strLetter
                objGroup.Expanded = False
                'objGroup.NavigateUrl = "?sel=schools&l=" & strLetter
                ExplorerBarSchoolsList.Groups.Add(objGroup)

            ElseIf InStr(ExplorerBarSchoolsList.Groups(ExplorerBarSchoolsList.Groups.Count - 1).Text, strLetter) > 0 Then
                ' Do nothing, it already exists...
            Else
                ' Add Group...
                Dim objGroup As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                objGroup.Text = strLetter
                objGroup.Expanded = False
                'objGroup.NavigateUrl = "?sel=schools&l=" & strLetter
                ExplorerBarSchoolsList.Groups.Add(objGroup)
            End If
        End If

    End Sub

End Class