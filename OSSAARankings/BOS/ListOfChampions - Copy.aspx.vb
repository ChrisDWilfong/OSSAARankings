
Public Class ListOfChampions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("BootstrapScores") = clsPageObjects.GetGamesList("BaseballFall", Now.ToShortDateString)
        Session("BootstrapScores") = Session("BootstrapScores") & clsPageObjects.GetGamesList("FPSoftball", Now.ToShortDateString)
        Session("BootstrapScores") = Session("BootstrapScores") & clsPageObjects.GetGamesList("Volleyball", Now.ToShortDateString)

        Session("menuListOfChampions") = clsMenusNew.BuildMenuListOfChampions()

        If Request.QueryString("st") Is Nothing Then
        Else
            If Request.QueryString("st") <> Session("LOCState") Then
                Session("LOCState") = Request.QueryString("st")
                Session("LOCStateName") = clsBSData.GetStateString(Request.QueryString("st"))
                Dim cboSport As DropDownList = FindControl("CboSport")
                cboSport.DataTextField = "strTextField"
                cboSport.DataValueField = "strValueField"
                cboSport.DataSource = clsBSData.GetDataSourceDropDown_Sports(Session("LOCState"))
                cboSport.DataBind()
            End If
        End If

    End Sub

    Public Sub RefreshGrid(strState As String, strSportGenderKey As String, strYear As String)
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM LOCview_StateChampions WHERE strState = '" & strState & "' AND strSportGenderKey = '" & strSportGenderKey & "' AND intYear = " & strYear & " ORDER BY intSortClass"
        Session("BootstrapCardHeader") = clsPageObjects.GetBootstrapCardHeaderStateChampions01
        Session("BootstrapRows") = clsPageObjects.GetBootstrapCardRowsWithDetailStateChampions01(strState, strSportGenderKey, strYear, strSQL, "strDisplayResults", "strCoaches")
    End Sub

    'Protected Sub CboState_Load(sender As Object, e As EventArgs)
    '    'Dim cboState As DropDownList = FindControl("CboState")
    '    Dim cboState As DropDownList = sender
    '    If cboState.Items.Count > 0 Then
    '    Else
    '        cboState.DataTextField = "strTextField"
    '        cboState.DataValueField = "strValueField"
    '        cboState.DataSource = clsBSData.GetDataSourceDropDown_States
    '        cboState.DataBind()
    '    End If
    'End Sub

    'Protected Sub CboState_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim cboSport As DropDownList = FindControl("CboSport")
    '    cboSport.DataTextField = "strTextField"
    '    cboSport.DataValueField = "strValueField"
    '    cboSport.DataSource = clsBSData.GetDataSourceDropDown_Sports(sender.SelectedValue)
    '    cboSport.DataBind()
    'End Sub

    'Protected Sub CboState_DataBound(sender As Object, e As EventArgs)
    '    sender.Items.Insert(0, "Select state...")
    'End Sub

    Protected Sub CboSport_DataBound(sender As Object, e As EventArgs)
        sender.Items.Insert(0, "Select Sport...")
    End Sub

    Protected Sub CboYear_DataBound(sender As Object, e As EventArgs)
        sender.Items.Insert(0, "Select Year...")
    End Sub

    Protected Sub CboSport_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Dim cboState As DropDownList = FindControl("CboState")
        Dim cboYear As DropDownList = FindControl("CboYear")
        cboYear.DataTextField = "strTextField"
        cboYear.DataValueField = "strValueField"
        cboYear.DataSource = clsBSData.GetDataSourceDropDown_Years(Session("LOCState"), sender.SelectedValue)
        cboYear.DataBind()
    End Sub

    Protected Sub CboYear_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim cboState As DropDownList = FindControl("CboState")
        Dim cboSport As DropDownList = FindControl("CboSport")
        RefreshGrid(Session("LOCState"), cboSport.SelectedValue, sender.SelectedValue)
    End Sub
End Class