﻿Imports Telerik.Web.UI

Public Class EntryFormsEdit
    Inherits System.Web.UI.UserControl
    Private _dataItem As Object = Nothing

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next

        'Dim objScriptManager As Object = sender.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.FindControl("ScriptManager1")
        'objScriptManager.Register

        If Session("selectedID") = _dataItem(2) Then
            ' Do nothing...
        Else
            Session("selectedID") = _dataItem(2)
            Session("selectedSport") = _dataItem(5)

            Select Case Session("selectedSport")
                Case "BaseballFall", "Baseball"
                    LoadBaseball()
                    tblBaseball.Visible = True
                Case "Basketball", "BasketballBoys", "BasketballGirls"
                    LoadBasketball()
                    tblBasketball.Visible = True
                Case "Cheerleading"
                    LoadCheerleading()
                    tblCheerleading.Visible = True
                Case "CrossCountryBoys"
                    LoadCrossCountry("Boys")
                    tblCrossCountryBoys.Visible = True
                Case "CrossCountryGirls"
                    LoadCrossCountry("Girls")
                    tblCrossCountryGirls.Visible = True
                Case "GolfBoys"
                    LoadGolf("Boys")
                    tblGolfBoys.Visible = True
                Case "GolfGirls"
                    LoadGolf("Girls")
                    tblGolfGirls.Visible = True
                Case "FPSoftball"
                    LoadFPSoftball()
                    tblFPSoftball.Visible = True
                Case "SPSoftball"
                    LoadSPSoftball()
                    tblSPSoftball.Visible = True
                Case "Volleyball"
                    LoadVolleyball()
                    tblVolleyball.Visible = True
                Case "SwimmingBoys"
                    LoadSwimming("Boys")
                    tblSwimmingBoys.Visible = True
                Case "SwimmingGirls"
                    LoadSwimming("Girls")
                    tblSwimmingGirls.Visible = True
                Case "TennisBoys"
                    LoadTennis("Boys")
                    tblTennisBoys.Visible = True
                Case "TennisGirls"
                    LoadTennis("Girls")
                    tblTennisGirls.Visible = True
            End Select
        End If

        If Not IsPostBack Then
            EnableAllControls()
        End If

    End Sub
#End Region

#Region "VerifySave"
    Public Function VerifySave(strSport As String) As String
        Dim strResult As String = "OK"

        Select Case strSport
            Case "Basketball", "BasketballBoys", "BasketballGirls"
                If RadDropDownListParticipatingBasketball.SelectedValue = "N" Then
                    If (TextBoxSubmittedByBasketball.Text = "" And TextBoxSubmittedByBasketball.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingBasketball.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf RadDropDownListBasketball1.SelectedValue = "-" Or TextBoxBasketball1.Text = "" Or TextBoxBasketball2.Text = "" Or TextBoxBasketball3.Text = "" Or TextBoxBasketball4.Text = "" Or TextBoxBasketball5.Text = "" Or TextBoxBasketball6.Text = "" Or TextBoxBasketball7.Text = "" Or TextBoxBasketball8.Text = "" Or TextBoxBasketball9.Text = "" Or TextBoxBasketball10.Text = "" Or TextBoxBasketball11.Text = "" Or TextBoxBasketball12.Text = "" Or TextBoxSubmittedByBasketball.Text = "" Or TextBoxSubmittedByBasketball.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "Baseball", "BaseballFall"
                If RadDropDownListParticipatingBaseball.SelectedValue = "N" And RadDropDownListParticipatingBaseballFall.SelectedValue = "N" Then
                    If (TextBoxSubmittedByBaseball.Text = "" Or TextBoxSubmittedByBaseball.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingBaseball.SelectedValue = "-" Or RadDropDownListParticipatingBaseballFall.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf RadDropDownListBaseball1.SelectedValue = "-" Or RadDropDownListBaseball2.SelectedValue = "-" Or RadDropDownListBaseball3.SelectedValue = "-" Or RadDropDownListBaseball4.SelectedValue = "-" Or RadDropDownListBaseball5.SelectedValue = "-" Or RadDropDownListBaseball6.SelectedValue = "-" Or RadDropDownListBaseball7.SelectedValue = "-" Or RadDropDownListBaseball8.SelectedValue = "-" Or RadDropDownListBaseball9.SelectedValue = "-" Or RadDropDownListBaseball10.SelectedValue = "-" Or RadDropDownListBaseball11.SelectedValue = "-" Or RadDropDownListBaseball12.SelectedValue = "-" Or RadDropDownListBaseball13.SelectedValue = "-" Or RadDropDownListBaseball14.SelectedValue = "-" Or TextBoxBaseball1.Text = "" Or TextBoxBaseball2.Text = "" Or TextBoxBaseball3.Text = "" Or TextBoxBaseball4.Text = "" Or TextBoxBaseball5.Text = "" Or TextBoxSubmittedByBaseball.Text = "" Or TextBoxSubmittedByBaseball.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "CrossCountryBoys"
                If RadDropDownListParticipatingCrossCountryBoys.SelectedValue = "N" Then
                    If (TextBoxSubmittedByCrossCountryBoys.Text = "" Or TextBoxSubmittedByCrossCountryBoys.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingCrossCountryBoys.SelectedValue = "-" Or RadDropDownListParticipatingCrossCountryBoys.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxCrossCountryBoys1.Text = "" Or TextBoxSubmittedByCrossCountryBoys.Text = "" Or TextBoxSubmittedByCrossCountryBoys.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving (At least 1 participant and Submitted by)."
                Else
                    strResult = "OK"
                End If
            Case "CrossCountryGirls"
                If RadDropDownListParticipatingCrossCountryGirls.SelectedValue = "N" Then
                    If (TextBoxSubmittedByCrossCountryGirls.Text = "" Or TextBoxSubmittedByCrossCountryGirls.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingCrossCountryGirls.SelectedValue = "-" Or RadDropDownListParticipatingCrossCountryGirls.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxCrossCountryGirls1.Text = "" Or TextBoxSubmittedByCrossCountryGirls.Text = "" Or TextBoxSubmittedByCrossCountryGirls.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving (At least 1 participant and Submitted by)."
                Else
                    strResult = "OK"
                End If
            Case "FPSoftball"
                If RadDropDownListParticipatingFPSoftball.SelectedValue = "N" Then
                    If (TextBoxSubmittedByFPSoftball.Text = "" Or TextBoxSubmittedByFPSoftball.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingFPSoftball.SelectedValue = "-" Or RadDropDownListParticipatingFPSoftball.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf RadDropDownListFPSoftball1.SelectedValue = "-" Or RadDropDownListFPSoftball2.SelectedValue = "-" Or RadDropDownListFPSoftball3.SelectedValue = "-" Or RadDropDownListFPSoftball4.SelectedValue = "-" Or RadDropDownListFPSoftball5.SelectedValue = "-" Or RadDropDownListFPSoftball6.SelectedValue = "-" Or RadDropDownListFPSoftball7.SelectedValue = "-" Or RadDropDownListFPSoftball8.SelectedValue = "-" Or TextBoxFPSoftball1.Text = "" Or TextBoxFPSoftball2.Text = "" Or TextBoxFPSoftball3.Text = "" Or TextBoxFPSoftball4.Text = "" Or TextBoxFPSoftball5.Text = "" Or TextBoxSubmittedByFPSoftball.Text = "" Or TextBoxSubmittedByFPSoftball.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "GolfBoys"
                If RadDropDownListParticipatingGolfBoys.SelectedValue = "N" Then
                    If (TextBoxSubmittedByGolfBoys.Text = "" Or TextBoxSubmittedByGolfBoys.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingGolfBoys.SelectedValue = "-" Or RadDropDownListParticipatingGolfBoys.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf txtGolfBoys1.Text = "" Or TextBoxSubmittedByGolfBoys.Text = "" Or TextBoxSubmittedByGolfBoys.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving (At least 1 participant and Submitted by)."
                Else
                    strResult = "OK"
                End If
            Case "GolfGirls"
                If RadDropDownListParticipatingGolfGirls.SelectedValue = "N" Then
                    If (TextBoxSubmittedByGolfGirls.Text = "" Or TextBoxSubmittedByGolfGirls.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingGolfGirls.SelectedValue = "-" Or RadDropDownListParticipatingGolfGirls.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf txtGolfGirls1.Text = "" Or TextBoxSubmittedByGolfGirls.Text = "" Or TextBoxSubmittedByGolfGirls.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving (At least 1 participant and Submitted by)."
                Else
                    strResult = "OK"
                End If
            Case "SPSoftball"
                If RadDropDownListParticipatingSPSoftball.SelectedValue = "N" Then
                    If (TextBoxSubmittedBySPSoftball.Text = "" Or TextBoxSubmittedBySPSoftball.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingSPSoftball.SelectedValue = "-" Or RadDropDownListParticipatingSPSoftball.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf RadDropDownListSPSoftball1.SelectedValue = "-" Or RadDropDownListSPSoftball2.SelectedValue = "-" Or RadDropDownListSPSoftball3.SelectedValue = "-" Or RadDropDownListSPSoftball4.SelectedValue = "-" Or RadDropDownListSPSoftball5.SelectedValue = "-" Or RadDropDownListSPSoftball6.SelectedValue = "-" Or RadDropDownListSPSoftball7.SelectedValue = "-" Or RadDropDownListSPSoftball8.SelectedValue = "-" Or RadDropDownListSPSoftball9.SelectedValue = "-" Or TextBoxSPSoftball1.Text = "" Or TextBoxSPSoftball2.Text = "" Or TextBoxSPSoftball3.Text = "" Or TextBoxSPSoftball4.Text = "" Or TextBoxSPSoftball5.Text = "" Or TextBoxSubmittedBySPSoftball.Text = "" Or TextBoxSubmittedBySPSoftball.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "Volleyball"
                If RadDropDownListParticipatingVolleyball.SelectedValue = "N" Then
                    If (TextBoxSubmittedByVolleyball.Text = "" Or TextBoxSubmittedByVolleyball.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingVolleyball.SelectedValue = "-" Or RadDropDownListParticipatingVolleyball.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxSubmittedByVolleyball.Text = "" Or TextBoxSubmittedByVolleyball.Text = "Enter your name" Or RadDropDownListVolleyballHosting.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "SwimmingBoys"
                If RadDropDownListParticipatingSwimmingBoys.SelectedValue = "N" Then
                    If (TextBoxSubmittedBySwimmingBoys.Text = "" Or TextBoxSubmittedBySwimmingBoys.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingSwimmingBoys.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxSubmittedBySwimmingBoys.Text = "" Or TextBoxSubmittedBySwimmingBoys.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "SwimmingGirls"
                If RadDropDownListParticipatingSwimmingGirls.SelectedValue = "N" Then
                    If (TextBoxSubmittedBySwimmingGirls.Text = "" Or TextBoxSubmittedBySwimmingGirls.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingSwimmingGirls.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxSubmittedBySwimmingGirls.Text = "" Or TextBoxSubmittedBySwimmingGirls.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "TennisBoys"
                If RadDropDownListParticipatingTennisBoys.SelectedValue = "N" Then
                    If (TextBoxSubmittedByTennisBoys.Text = "" Or TextBoxSubmittedByTennisBoys.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingTennisBoys.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxSubmittedByTennisBoys.Text = "" Or TextBoxSubmittedByTennisBoys.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case "TennisGirls"
                If RadDropDownListParticipatingTennisGirls.SelectedValue = "N" Then
                    If (TextBoxSubmittedByTennisGirls.Text = "" Or TextBoxSubmittedByTennisGirls.Text = "Enter your name") Then
                        strResult = "You must enter SUBMITTED BY below."
                    Else
                        strResult = "OK"
                    End If
                ElseIf RadDropDownListParticipatingTennisGirls.SelectedValue = "-" Then
                    strResult = "You must complete the form before saving."
                ElseIf TextBoxSubmittedByTennisGirls.Text = "" Or TextBoxSubmittedByTennisGirls.Text = "Enter your name" Then
                    strResult = "You must complete the form before saving."
                Else
                    strResult = "OK"
                End If
            Case Else
        End Select
        Return strResult
    End Function
#End Region

#Region "Enable Controls by Sport"
    Private Sub EnableBasketballControls(ysnEnabled As Boolean)
        RadDropDownListBasketball1.Enabled = ysnEnabled
        TextBoxBasketball1.Enabled = ysnEnabled
        TextBoxBasketball2.Enabled = ysnEnabled
        TextBoxBasketball3.Enabled = ysnEnabled
        TextBoxBasketball4.Enabled = ysnEnabled
        TextBoxBasketball5.Enabled = ysnEnabled
        TextBoxBasketball6.Enabled = ysnEnabled
        TextBoxBasketball7.Enabled = ysnEnabled
        TextBoxBasketball8.Enabled = ysnEnabled
        TextBoxBasketball9.Enabled = ysnEnabled
        TextBoxBasketball10.Enabled = ysnEnabled
        TextBoxBasketball11.Enabled = ysnEnabled
        TextBoxBasketball12.Enabled = ysnEnabled
    End Sub
#End Region

#Region "Load Data"
    ' ========================================================================================================== LOAD DATA...
    Private Sub LoadBaseball()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            If ds.Tables(0).Rows(0).Item("strActivityAbb") = "BAF" Then
                RadDropDownListParticipatingBaseballFall.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
                Session("idBaseballFall") = ds.Tables(0).Rows(0).Item("ID")
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, "SELECT EntryFormYN FROM prodParticipation WHERE SchoolID = " & Session("entryFormSchoolID") & " AND intYear = " & clsFunctions.GetCurrentYear & " AND strActivityAbb = 'BAS'")
            Else
                RadDropDownListParticipatingBaseballFall.SelectedValue = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, "SELECT EntryFormYN FROM prodParticipation WHERE SchoolID = " & Session("entryFormSchoolID") & " AND intYear = " & clsFunctions.GetCurrentYear & " AND strActivityAbb = 'BAF'")
                Session("idBaseballFall") = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, "SELECT Id FROM prodParticipation WHERE SchoolID = " & Session("entryFormSchoolID") & " AND intYear = " & clsFunctions.GetCurrentYear & " AND strActivityAbb = 'BAF'")
            End If
            Session("idBaseball") = ds.Tables(0).Rows(0).Item("ID")
            RadDropDownListParticipatingBaseball.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListBaseball1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            RadDropDownListBaseball2.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion2")
            RadDropDownListBaseball3.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion3")
            RadDropDownListBaseball4.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion4")
            RadDropDownListBaseball5.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion5")
            RadDropDownListBaseball6.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion6")
            RadDropDownListBaseball7.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion7")
            RadDropDownListBaseball8.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion8")
            RadDropDownListBaseball9.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion9")
            RadDropDownListBaseball10.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion10")
            RadDropDownListBaseball11.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion11")
            RadDropDownListBaseball12.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion12")
            RadDropDownListBaseball13.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion13")
            RadDropDownListBaseball14.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion14")
            TextBoxSubmittedByBaseball.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
            TextBoxBaseball1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            TextBoxBaseball2.Text = ds.Tables(0).Rows(0).Item("intValue2")
            TextBoxBaseball3.Text = ds.Tables(0).Rows(0).Item("intValue3")
            TextBoxBaseball4.Text = ds.Tables(0).Rows(0).Item("intValue4")
            TextBoxBaseball5.Text = ds.Tables(0).Rows(0).Item("intValue5")
            TextBoxBaseballComments.Text = ds.Tables(0).Rows(0).Item("strComments")
        End If

    End Sub
    Private Sub LoadBasketball()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Session("selectedID") = ds.Tables(0).Rows(0).Item("ID")
            RadDropDownListParticipatingBasketball.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListBasketball1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            TextBoxSubmittedByBasketball.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
            TextBoxBasketball1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            TextBoxBasketball2.Text = ds.Tables(0).Rows(0).Item("intValue2")
            TextBoxBasketball3.Text = ds.Tables(0).Rows(0).Item("intValue3")
            TextBoxBasketball4.Text = ds.Tables(0).Rows(0).Item("intValue4")
            TextBoxBasketball5.Text = ds.Tables(0).Rows(0).Item("intValue5")
            TextBoxBasketball6.Text = ds.Tables(0).Rows(0).Item("intValue6")
            TextBoxBasketball7.Text = ds.Tables(0).Rows(0).Item("intValue7")
            TextBoxBasketball8.Text = ds.Tables(0).Rows(0).Item("intValue8")
            TextBoxBasketball9.Text = ds.Tables(0).Rows(0).Item("intValue9")
            TextBoxBasketball10.Text = ds.Tables(0).Rows(0).Item("intValue10")
            TextBoxBasketball11.Text = ds.Tables(0).Rows(0).Item("intValue11")
            TextBoxBasketball12.Text = ds.Tables(0).Rows(0).Item("intValue12")
            TextBoxBasketballComments1.Text = ds.Tables(0).Rows(0).Item("strComments")
            TextBoxBasketballComments2.Text = ds.Tables(0).Rows(0).Item("strCommentsMore")
        End If
    End Sub

    Private Sub LoadCheerleading()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Cheerleading...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            RadDropDownListParticipatingCheerleading.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListCoEdSquad.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            TextBoxSubmittedByCheerleading.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
        End If

    End Sub

    Private Sub LoadCrossCountry(strGender As String)
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim dsH As DataSet
        Dim x As Integer

        ' Header record...
        strSQL = "SELECT EntryFormYN, strSubmittedBy FROM prodParticipation WHERE Id = " & Session("selectedID")
        dsH = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
        If strGender = "Boys" Then
            RadDropDownListParticipatingCrossCountryBoys.SelectedValue = dsH.Tables(0).Rows(0).Item("EntryFormYN")
            TextBoxSubmittedByCrossCountryBoys.Text = dsH.Tables(0).Rows(0).Item("strSubmittedBy")
        Else
            RadDropDownListParticipatingCrossCountryGirls.SelectedValue = dsH.Tables(0).Rows(0).Item("EntryFormYN")
            TextBoxSubmittedByCrossCountryGirls.Text = dsH.Tables(0).Rows(0).Item("strSubmittedBy")
        End If


        ' Detail records..
        strSQL = "SELECT * FROM prodParticipationPlayers WHERE ysnActive <> 0 AND IdParticipation = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim objTextBox As New Web.UI.WebControls.TextBox
                If strGender = "Boys" Then
                    objTextBox = FindControl("txtCrossCountryBoys" & (x + 1))
                Else
                    objTextBox = FindControl("txtCrossCountryGirls" & (x + 1))
                End If
                If objTextBox Is Nothing Then
                Else
                    objTextBox.Text = ds.Tables(0).Rows(x).Item("strPlayer")
                End If
            Next
        End If
    End Sub

    Private Sub LoadFPSoftball()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Session("selectedID") = ds.Tables(0).Rows(0).Item("ID")
            RadDropDownListParticipatingFPSoftball.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListFPSoftball1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            RadDropDownListFPSoftball2.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion2")
            RadDropDownListFPSoftball3.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion3")
            RadDropDownListFPSoftball4.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion4")
            RadDropDownListFPSoftball5.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion5")
            RadDropDownListFPSoftball6.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion6")
            RadDropDownListFPSoftball7.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion7")
            RadDropDownListFPSoftball8.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion8")
            RadDropDownListFPSoftballHosting.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion9")
            TextBoxSubmittedByFPSoftball.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
            TextBoxFPSoftball1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            TextBoxFPSoftball2.Text = ds.Tables(0).Rows(0).Item("intValue2")
            TextBoxFPSoftball3.Text = ds.Tables(0).Rows(0).Item("intValue3")
            TextBoxFPSoftball4.Text = ds.Tables(0).Rows(0).Item("intValue4")
            TextBoxFPSoftball5.Text = ds.Tables(0).Rows(0).Item("intValue5")
            TextBoxFPSoftballComments.Text = ds.Tables(0).Rows(0).Item("strComments")
        End If

    End Sub

    Private Sub LoadSPSoftball()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Session("selectedID") = ds.Tables(0).Rows(0).Item("ID")
            RadDropDownListParticipatingSPSoftball.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListSPSoftball1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            RadDropDownListSPSoftball2.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion2")
            RadDropDownListSPSoftball3.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion3")
            RadDropDownListSPSoftball4.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion4")
            RadDropDownListSPSoftball5.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion5")
            RadDropDownListSPSoftball6.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion6")
            RadDropDownListSPSoftball7.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion7")
            RadDropDownListSPSoftball8.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion8")
            RadDropDownListSPSoftball9.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion9")
            RadDropDownListSPSoftballHosting.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion10")
            TextBoxSubmittedBySPSoftball.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
            TextBoxSPSoftball1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            TextBoxSPSoftball2.Text = ds.Tables(0).Rows(0).Item("intValue2")
            TextBoxSPSoftball3.Text = ds.Tables(0).Rows(0).Item("intValue3")
            TextBoxSPSoftball4.Text = ds.Tables(0).Rows(0).Item("intValue4")
            TextBoxSPSoftball5.Text = ds.Tables(0).Rows(0).Item("intValue5")
            TextBoxSPSoftballComments.Text = ds.Tables(0).Rows(0).Item("strComments")
        End If

    End Sub

    Private Sub LoadVolleyball()
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Volleyball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            RadDropDownListParticipatingVolleyball.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
            RadDropDownListVolleyballHosting.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
            TextBoxSubmittedByVolleyball.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
        End If

    End Sub
    Private Sub LoadGolf(strGender As String)
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim dsH As DataSet
        Dim x As Integer

        ' Header record...
        strSQL = "SELECT EntryFormYN, strSubmittedBy FROM prodParticipation WHERE Id = " & Session("selectedID")
        dsH = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
        If strGender = "Boys" Then
            RadDropDownListParticipatingGolfBoys.SelectedValue = dsH.Tables(0).Rows(0).Item("EntryFormYN")
            TextBoxSubmittedByGolfBoys.Text = dsH.Tables(0).Rows(0).Item("strSubmittedBy")
        Else
            RadDropDownListParticipatingGolfGirls.SelectedValue = dsH.Tables(0).Rows(0).Item("EntryFormYN")
            TextBoxSubmittedByGolfGirls.Text = dsH.Tables(0).Rows(0).Item("strSubmittedBy")
        End If

        ' Detail records..
        strSQL = "SELECT * FROM prodParticipationPlayers WHERE ysnActive <> 0 AND IdParticipation = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim objTextBox As New Web.UI.WebControls.TextBox
                If strGender = "Boys" Then
                    objTextBox = FindControl("txtGolfBoys" & (x + 1))
                Else
                    objTextBox = FindControl("txtGolfGirls" & (x + 1))
                End If
                If objTextBox Is Nothing Then
                Else
                    objTextBox.Text = ds.Tables(0).Rows(x).Item("strPlayer")
                End If
            Next
        End If
    End Sub

    Private Sub LoadSwimming(strGender As String)
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Session("selectedID") = ds.Tables(0).Rows(0).Item("ID")
            If strGender = "Boys" Then
                RadDropDownListParticipatingSwimmingBoys.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
                TextBoxSwimmingBoysComments.Text = ds.Tables(0).Rows(0).Item("strComments")
                TextBoxSubmittedBySwimmingBoys.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
                TextBoxSwimmingBoys1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            Else
                RadDropDownListParticipatingSwimmingGirls.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
                TextBoxSwimmingGirlsComments.Text = ds.Tables(0).Rows(0).Item("strComments")
                TextBoxSubmittedBySwimmingGirls.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
                TextBoxSwimmingGirls1.Text = ds.Tables(0).Rows(0).Item("intValue1")
            End If
        End If

    End Sub

    Private Sub LoadTennis(strGender As String)
        Dim strSQL As String = ""
        Dim ds As DataSet

        strSQL = "SELECT * FROM prodParticipation WHERE Id = " & Session("selectedID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

        ' Load Baseball...
        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Session("selectedID") = ds.Tables(0).Rows(0).Item("ID")
            If strGender = "Boys" Then
                RadDropDownListParticipatingTennisBoys.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
                TextBoxTennisBoysComments.Text = ds.Tables(0).Rows(0).Item("strComments")
                TextBoxSubmittedByTennisBoys.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
                RadDropDownListTennisBoys1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
                RadDropDownListTennisBoys2.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion2")
                RadDropDownListTennisBoys3.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion3")
                RadDropDownListTennisBoys4.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion4")
            Else
                RadDropDownListParticipatingTennisGirls.SelectedValue = ds.Tables(0).Rows(0).Item("EntryFormYN")
                TextBoxTennisGirlsComments.Text = ds.Tables(0).Rows(0).Item("strComments")
                TextBoxSubmittedByTennisGirls.Text = ds.Tables(0).Rows(0).Item("strSubmittedBy")
                RadDropDownListTennisGirls1.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion1")
                RadDropDownListTennisGirls2.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion2")
                RadDropDownListTennisGirls3.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion3")
                RadDropDownListTennisGirls4.SelectedValue = ds.Tables(0).Rows(0).Item("strYNQuestion4")
            End If

        End If
    End Sub
#End Region

#Region "Save Commands"
    ' ======================================================================================================== SAVE DATA...
    Private Sub cmdSaveBasketball_Click(sender As Object, e As EventArgs) Handles cmdSaveBasketball.Click

        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then

            ' IS THIS COMPLETE?
            If RadDropDownListBasketball1.SelectedValue = "N" Then
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByBasketball.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                lblMessageBasketballHeader.Text = "Save complete. Click DONE below."
                lblMessageBasketball.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            Else
                strOK = "OK"
            End If

            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Dim intValue2 As Long = 0
                Dim intValue3 As Long = 0
                Dim intValue4 As Long = 0
                Dim intValue5 As Long = 0
                Dim intValue6 As Long = 0
                Dim intValue7 As Long = 0
                Dim intValue8 As Long = 0
                Dim intValue9 As Long = 0
                Dim intValue10 As Long = 0
                Dim intValue11 As Long = 0
                Dim intValue12 As Long = 0
                Try
                    intValue1 = CLng(TextBoxBasketball1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try
                Try
                    intValue2 = CLng(TextBoxBasketball2.Text)
                Catch ex As Exception
                    intValue2 = 0
                End Try
                Try
                    intValue3 = CLng(TextBoxBasketball3.Text)
                Catch ex As Exception
                    intValue3 = 0
                End Try
                Try
                    intValue4 = CLng(TextBoxBasketball4.Text)
                Catch ex As Exception
                    intValue4 = 0
                End Try
                Try
                    intValue5 = CLng(TextBoxBasketball5.Text)
                Catch ex As Exception
                    intValue5 = 0
                End Try
                Try
                    intValue6 = CLng(TextBoxBasketball6.Text)
                Catch ex As Exception
                    intValue6 = 0
                End Try
                Try
                    intValue7 = CLng(TextBoxBasketball7.Text)
                Catch ex As Exception
                    intValue7 = 0
                End Try
                Try
                    intValue8 = CLng(TextBoxBasketball8.Text)
                Catch ex As Exception
                    intValue8 = 0
                End Try
                Try
                    intValue9 = CLng(TextBoxBasketball9.Text)
                Catch ex As Exception
                    intValue9 = 0
                End Try
                Try
                    intValue10 = CLng(TextBoxBasketball10.Text)
                Catch ex As Exception
                    intValue10 = 0
                End Try
                Try
                    intValue11 = CLng(TextBoxBasketball11.Text)
                Catch ex As Exception
                    intValue11 = 0
                End Try
                Try
                    intValue12 = CLng(TextBoxBasketball12.Text)
                Catch ex As Exception
                    intValue12 = 0
                End Try
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "EntryFormYN = '" & RadDropDownListParticipatingBasketball.SelectedValue & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListBasketball1.SelectedValue & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxBasketballComments1.Text) & "', "
                strSQL += "strCommentsMore = '" & clsFunctions.StringValidate(TextBoxBasketballComments2.Text) & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByBasketball.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & ", "
                strSQL += "intValue2 = " & intValue2 & ", "
                strSQL += "intValue3 = " & intValue3 & ", "
                strSQL += "intValue4 = " & intValue4 & ", "
                strSQL += "intValue5 = " & intValue5 & ", "
                strSQL += "intValue6 = " & intValue6 & ", "
                strSQL += "intValue7 = " & intValue7 & ", "
                strSQL += "intValue8 = " & intValue8 & ", "
                strSQL += "intValue9 = " & intValue9 & ", "
                strSQL += "intValue10 = " & intValue10 & ", "
                strSQL += "intValue11 = " & intValue11 & ", "
                strSQL += "intValue12 = " & intValue12 & " "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByBasketball.Text), strSQL)
                lblMessageBasketballHeader.Text = "Save complete. Click DONE below."
                lblMessageBasketball.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageBasketballHeader.Text = strResult
            lblMessageBasketball.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveBaseball_Click(sender As Object, e As EventArgs) Handles cmdSaveBaseball.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"

        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then

            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingBaseball.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text) & "',  EntryFormStamp = '" & Now & "' WHERE Id = " & Session("idBaseball")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text), strSQL)
                lblMessageBaseballHeader.Text = "Save complete. Click DONE below."
                lblMessageBaseball.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If RadDropDownListParticipatingBaseballFall.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("idBaseballFall")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text), strSQL)
                lblMessageBaseballHeader.Text = "Save complete. Click DONE below."
                lblMessageBaseball.Text = "Save complete. Click DONE below."
            End If

            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Dim intValue2 As Long = 0
                Dim intValue3 As Long = 0
                Dim intValue4 As Long = 0
                Dim intValue5 As Long = 0
                Try
                    intValue1 = CLng(TextBoxBaseball1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try
                Try
                    intValue2 = CLng(TextBoxBaseball2.Text)
                Catch ex As Exception
                    intValue2 = 0
                End Try
                Try
                    intValue3 = CLng(TextBoxBaseball3.Text)
                Catch ex As Exception
                    intValue3 = 0
                End Try
                Try
                    intValue4 = CLng(TextBoxBaseball4.Text)
                Catch ex As Exception
                    intValue4 = 0
                End Try
                Try
                    intValue5 = CLng(TextBoxBaseball5.Text)
                Catch ex As Exception
                    intValue5 = 0
                End Try
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListBaseball1.SelectedValue & "', "
                strSQL += "strYNQuestion2 = '" & RadDropDownListBaseball2.SelectedValue & "', "
                strSQL += "strYNQuestion3 = '" & RadDropDownListBaseball3.SelectedValue & "', "
                strSQL += "strYNQuestion4 = '" & RadDropDownListBaseball4.SelectedValue & "', "
                strSQL += "strYNQuestion5 = '" & RadDropDownListBaseball5.SelectedValue & "', "
                strSQL += "strYNQuestion6 = '" & RadDropDownListBaseball6.SelectedValue & "', "
                strSQL += "strYNQuestion7 = '" & RadDropDownListBaseball7.SelectedValue & "', "
                strSQL += "strYNQuestion8 = '" & RadDropDownListBaseball8.SelectedValue & "', "
                strSQL += "strYNQuestion9 = '" & RadDropDownListBaseball9.SelectedValue & "', "
                strSQL += "strYNQuestion10 = '" & RadDropDownListBaseball10.SelectedValue & "', "
                strSQL += "strYNQuestion11 = '" & RadDropDownListBaseball11.SelectedValue & "', "
                strSQL += "strYNQuestion12 = '" & RadDropDownListBaseball12.SelectedValue & "', "
                strSQL += "strYNQuestion13 = '" & RadDropDownListBaseball13.SelectedValue & "', "
                strSQL += "strYNQuestion14 = '" & RadDropDownListBaseball14.SelectedValue & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxBaseballComments.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & ", "
                strSQL += "intValue2 = " & intValue2 & ", "
                strSQL += "intValue3 = " & intValue3 & ", "
                strSQL += "intValue4 = " & intValue4 & ", "
                strSQL += "intValue5 = " & intValue5 & " "
                strSQL += "WHERE Id = " & Session("idBaseball")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

                If RadDropDownListParticipatingBaseballFall.SelectedValue = "Y" Then
                    strSQL = "UPDATE prodParticipation SET "
                    strSQL += "EntryFormYN = 'Y', "
                    strSQL += "EntryFormStamp = '" & Now & "' "
                    strSQL += "WHERE Id = " & Session("idBaseballFall")
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text), strSQL)
                End If

                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByBaseball.Text), strSQL)
                lblMessageBaseballHeader.Text = "Save complete. Click DONE below."
                lblMessageBaseball.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageBaseballHeader.Text = strResult
            lblMessageBaseball.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveCheerleading_Click(sender As Object, e As EventArgs) Handles cmdSaveCheerleading.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingCheerleading.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCheerleading.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCheerleading.Text), strSQL)
                lblMessageCheerleadingHeader.Text = "Save complete. Click DONE below."
                lblMessageCheerleading.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCheerleading.Text) & "', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListCoEdSquad.SelectedValue & "' "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCheerleading.Text), strSQL)
                lblMessageCheerleadingHeader.Text = "Save complete. Click DONE below."
                lblMessageCheerleading.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageCheerleadingHeader.Text = strResult
            lblMessageCheerleading.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveCrossCountryBoys_Click(sender As Object, e As EventArgs) Handles cmdSaveCrossCountryBoys.Click
        SaveCrossCountry("Boys")
    End Sub
    Private Sub cmdSaveCrossCountryGirls_Click(sender As Object, e As EventArgs) Handles cmdSaveCrossCountryGirls.Click
        SaveCrossCountry("Girls")
    End Sub

    Private Sub cmdSaveFPSoftball_Click(sender As Object, e As EventArgs) Handles cmdSaveFPSoftball.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingFPSoftball.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByFPSoftball.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByFPSoftball.Text), strSQL)
                lblMessageFastPitchHeader.Text = "Save complete. Click DONE below."
                lblMessageFastPitch.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Dim intValue2 As Long = 0
                Dim intValue3 As Long = 0
                Dim intValue4 As Long = 0
                Dim intValue5 As Long = 0
                Try
                    intValue1 = CLng(TextBoxFPSoftball1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try
                Try
                    intValue2 = CLng(TextBoxFPSoftball2.Text)
                Catch ex As Exception
                    intValue2 = 0
                End Try
                Try
                    intValue3 = CLng(TextBoxFPSoftball3.Text)
                Catch ex As Exception
                    intValue3 = 0
                End Try
                Try
                    intValue4 = CLng(TextBoxFPSoftball4.Text)
                Catch ex As Exception
                    intValue4 = 0
                End Try
                Try
                    intValue5 = CLng(TextBoxFPSoftball5.Text)
                Catch ex As Exception
                    intValue5 = 0
                End Try
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListFPSoftball1.SelectedValue & "', "
                strSQL += "strYNQuestion2 = '" & RadDropDownListFPSoftball2.SelectedValue & "', "
                strSQL += "strYNQuestion3 = '" & RadDropDownListFPSoftball3.SelectedValue & "', "
                strSQL += "strYNQuestion4 = '" & RadDropDownListFPSoftball4.SelectedValue & "', "
                strSQL += "strYNQuestion5 = '" & RadDropDownListFPSoftball5.SelectedValue & "', "
                strSQL += "strYNQuestion6 = '" & RadDropDownListFPSoftball6.SelectedValue & "', "
                strSQL += "strYNQuestion7 = '" & RadDropDownListFPSoftball7.SelectedValue & "', "
                strSQL += "strYNQuestion8 = '" & RadDropDownListFPSoftball8.SelectedValue & "', "
                strSQL += "strYNQuestion9 = '" & RadDropDownListFPSoftballHosting.SelectedValue & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByFPSoftball.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxFPSoftballComments.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & ", "
                strSQL += "intValue2 = " & intValue2 & ", "
                strSQL += "intValue3 = " & intValue3 & ", "
                strSQL += "intValue4 = " & intValue4 & ", "
                strSQL += "intValue5 = " & intValue5 & " "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByFPSoftball.Text), strSQL)
                lblMessageFastPitchHeader.Text = "Save complete. Click DONE below."
                lblMessageFastPitch.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageFastPitchHeader.Text = strResult
            lblMessageFastPitch.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveSPSoftball_Click(sender As Object, e As EventArgs) Handles cmdSaveSPSoftball.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingFPSoftball.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySPSoftball.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySPSoftball.Text), strSQL)
                lblMessageSlowPitchHeader.Text = "Save complete. Click DONE below."
                lblMessageSlowPitch.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Dim intValue2 As Long = 0
                Dim intValue3 As Long = 0
                Dim intValue4 As Long = 0
                Dim intValue5 As Long = 0
                Try
                    intValue1 = CLng(TextBoxSPSoftball1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try
                Try
                    intValue2 = CLng(TextBoxSPSoftball2.Text)
                Catch ex As Exception
                    intValue2 = 0
                End Try
                Try
                    intValue3 = CLng(TextBoxSPSoftball3.Text)
                Catch ex As Exception
                    intValue3 = 0
                End Try
                Try
                    intValue4 = CLng(TextBoxSPSoftball4.Text)
                Catch ex As Exception
                    intValue4 = 0
                End Try
                Try
                    intValue5 = CLng(TextBoxSPSoftball5.Text)
                Catch ex As Exception
                    intValue5 = 0
                End Try
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListSPSoftball1.SelectedValue & "', "
                strSQL += "strYNQuestion2 = '" & RadDropDownListSPSoftball2.SelectedValue & "', "
                strSQL += "strYNQuestion3 = '" & RadDropDownListSPSoftball3.SelectedValue & "', "
                strSQL += "strYNQuestion4 = '" & RadDropDownListSPSoftball4.SelectedValue & "', "
                strSQL += "strYNQuestion5 = '" & RadDropDownListSPSoftball5.SelectedValue & "', "
                strSQL += "strYNQuestion6 = '" & RadDropDownListSPSoftball6.SelectedValue & "', "
                strSQL += "strYNQuestion7 = '" & RadDropDownListSPSoftball7.SelectedValue & "', "
                strSQL += "strYNQuestion8 = '" & RadDropDownListSPSoftball8.SelectedValue & "', "
                strSQL += "strYNQuestion9 = '" & RadDropDownListSPSoftball9.SelectedValue & "', "
                strSQL += "strYNQuestion10 = '" & RadDropDownListSPSoftballHosting.SelectedValue & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySPSoftball.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxSPSoftballComments.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & ", "
                strSQL += "intValue2 = " & intValue2 & ", "
                strSQL += "intValue3 = " & intValue3 & ", "
                strSQL += "intValue4 = " & intValue4 & ", "
                strSQL += "intValue5 = " & intValue5 & " "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySPSoftball.Text), strSQL)
                lblMessageSlowPitchHeader.Text = "Save complete. Click DONE below."
                lblMessageSlowPitch.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageSlowPitchHeader.Text = strResult
            lblMessageSlowPitch.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveGolfBoys_Click(sender As Object, e As EventArgs) Handles cmdSaveGolfBoys.Click
        SaveGolf("Boys")
    End Sub

    Private Sub cmdSaveGolfGirls_Click(sender As Object, e As EventArgs) Handles cmdSaveGolfGirls.Click
        SaveGolf("Girls")
    End Sub

    Private Sub SaveGolf(strGender As String)
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If (RadDropDownListParticipatingGolfBoys.SelectedValue = "Y" And strGender = "Boys") Or (RadDropDownListParticipatingGolfGirls.SelectedValue = "Y" And strGender = "Girls") Then

            Else
                ' Write the No...
                If strGender = "Boys" Then
                    strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByGolfBoys.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                Else
                    strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByGolfGirls.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                End If
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                If strGender = "Boys" Then
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByGolfBoys.Text), strSQL)
                    lblMessageGolfBoysHeader.Text = "Save complete. Click DONE below."
                    lblMessageGolfBoys.Text = "Save complete. Click DONE below."
                Else
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByGolfGirls.Text), strSQL)
                    lblMessageGolfGirlsHeader.Text = "Save complete. Click DONE below."
                    lblMessageGolfGirls.Text = "Save complete. Click DONE below."
                End If
                strOK = "DONE"
            End If

            If strOK = "OK" Then

                Dim strPlayer As String = ""

                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                If strGender = "Boys" Then
                    strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByGolfBoys.Text) & "', "
                Else
                    strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByGolfGirls.Text) & "', "
                End If
                strSQL += "EntryFormStamp = '" & Now & "' "
                strSQL += "WHERE Id = " & Session("selectedID")

                ' Do the Header Record update....
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

                ' Delete existing records in detail table...
                'strSQL = "DELETE FROM prodParticipationPlayers WHERE idParticipation = " & Session("selectedID")
                strSQL = "UPDATE prodParticipationPlayers SET ysnActive = 0 WHERE idParticipation = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

                ' Now Update the Detail records...

                If strGender = "Boys" Then
                    InsertIntoDetail(Session("selectedID"), txtGolfBoys1.Text, 1)
                    InsertIntoDetail(Session("selectedID"), txtGolfBoys2.Text, 2)
                    InsertIntoDetail(Session("selectedID"), txtGolfBoys3.Text, 3)
                    InsertIntoDetail(Session("selectedID"), txtGolfBoys4.Text, 4)
                    InsertIntoDetail(Session("selectedID"), txtGolfBoys5.Text, 5)
                Else
                    InsertIntoDetail(Session("selectedID"), txtGolfGirls1.Text, 1)
                    InsertIntoDetail(Session("selectedID"), txtGolfGirls2.Text, 2)
                    InsertIntoDetail(Session("selectedID"), txtGolfGirls3.Text, 3)
                    InsertIntoDetail(Session("selectedID"), txtGolfGirls4.Text, 4)
                    InsertIntoDetail(Session("selectedID"), txtGolfGirls5.Text, 5)
                End If
                If strGender = "Boys" Then
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByGolfBoys.Text), strSQL)
                    lblMessageGolfBoysHeader.Text = "Save complete. Click DONE below."
                    lblMessageGolfBoys.Text = "Save complete. Click DONE below."
                Else
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByGolfGirls.Text), strSQL)
                    lblMessageGolfGirlsHeader.Text = "Save complete. Click DONE below."
                    lblMessageGolfGirls.Text = "Save complete. Click DONE below."
                End If
            Else
                ' DO nothing...
            End If
        Else
            If strGender = "Boys" Then
                lblMessageGolfBoysHeader.Text = strResult
                lblMessageGolfBoys.Text = strResult
            Else
                lblMessageGolfGirlsHeader.Text = strResult
                lblMessageGolfGirls.Text = strResult
            End If
        End If

    End Sub

    Private Sub SaveCrossCountry(strGender As String)
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If (RadDropDownListParticipatingCrossCountryBoys.SelectedValue = "Y" And strGender = "Boys") Or (RadDropDownListParticipatingCrossCountryGirls.SelectedValue = "Y" And strGender = "Girls") Then

            Else
                ' Write the No...
                If strGender = "Boys" Then
                    strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryBoys.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                Else
                    strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryGirls.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                End If
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                If strGender = "Boys" Then
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryBoys.Text), strSQL)
                    lblMessageCrossCountryBoysHeader.Text = "Save complete. Click DONE below."
                    lblMessageCrossCountryBoys.Text = "Save complete. Click DONE below."
                Else
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryGirls.Text), strSQL)
                    lblMessageCrossCountryGirlsHeader.Text = "Save complete. Click DONE below."
                    lblMessageCrossCountryGirls.Text = "Save complete. Click DONE below."
                End If
                strOK = "DONE"
            End If

            If strOK = "OK" Then

                Dim strPlayer As String = ""

                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                If strGender = "Boys" Then
                    strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryBoys.Text) & "', "
                Else
                    strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryGirls.Text) & "', "
                End If
                strSQL += "EntryFormStamp = '" & Now & "' "
                strSQL += "WHERE Id = " & Session("selectedID")

                ' Do the Header Record update....
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

                If strGender = "Boys" Then
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryBoys.Text), strSQL)
                Else
                    clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByCrossCountryGirls.Text), strSQL)
                End If
                ' Delete existing records in detail table...
                strSQL = "UPDATE prodParticipationPlayers SET ysnActive = 0 WHERE idParticipation = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)

                ' Now Update the Detail records...

                If strGender = "Boys" Then
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys1.Text, 1)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys2.Text, 2)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys3.Text, 3)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys4.Text, 4)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys5.Text, 5)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys6.Text, 6)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys7.Text, 7)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys8.Text, 8)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys9.Text, 9)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys10.Text, 10)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys11.Text, 11)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryBoys12.Text, 12)
                Else
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls1.Text, 1)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls2.Text, 2)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls3.Text, 3)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls4.Text, 4)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls5.Text, 5)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls6.Text, 6)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls7.Text, 7)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls8.Text, 8)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls9.Text, 9)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls10.Text, 10)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls11.Text, 11)
                    InsertIntoDetail(Session("selectedID"), TextBoxCrossCountryGirls12.Text, 12)
                End If
                If strGender = "Boys" Then
                    lblMessageCrossCountryBoysHeader.Text = "Save complete. Click DONE below."
                    lblMessageCrossCountryBoys.Text = "Save complete. Click DONE below."
                Else
                    lblMessageCrossCountryGirlsHeader.Text = "Save complete. Click DONE below."
                    lblMessageCrossCountryGirls.Text = "Save complete. Click DONE below."
                End If
            Else
                ' DO nothing...
            End If
        Else
            If strGender = "Boys" Then
                lblMessageCrossCountryBoysHeader.Text = strResult
                lblMessageCrossCountryBoys.Text = strResult
            Else
                lblMessageCrossCountryGirlsHeader.Text = strResult
                lblMessageCrossCountryGirls.Text = strResult
            End If
        End If

    End Sub

    Private Sub cmdSaveVolleyball_Click(sender As Object, e As EventArgs) Handles cmdSaveVolleyball.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingVolleyball.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByVolleyball.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByVolleyball.Text), strSQL)
                lblMessageVolleyballHeader.Text = "Save complete. Click DONE below."
                lblMessageVolleyball.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByVolleyball.Text) & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListVolleyballHosting.SelectedValue & "' "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByVolleyball.Text), strSQL)
                lblMessageVolleyballHeader.Text = "Save complete. Click DONE below."
                lblMessageVolleyball.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageVolleyballHeader.Text = strResult
            lblMessageVolleyball.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveSwimmingBoys_Click(sender As Object, e As EventArgs) Handles cmdSaveSwimmingBoys.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingSwimmingBoys.SelectedValue = "Y" Then
            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySwimmingBoys.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySwimmingBoys.Text), strSQL)
                strOK = "DONE"
                lblMessageSwimmingBoysHeader.Text = "Save complete. Click DONE below."
                lblMessageSwimmingBoys.Text = "Save complete. Click DONE below."
            End If


            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Try
                    intValue1 = CLng(TextBoxSwimmingBoys1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try

                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySwimmingBoys.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxSwimmingBoysComments.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & " "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySwimmingBoys.Text), strSQL)
                lblMessageSwimmingBoysHeader.Text = "Save complete. Click DONE below."
                lblMessageSwimmingBoys.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageSwimmingBoysHeader.Text = strResult
            lblMessageSwimmingBoys.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveSwimmingGirls_Click(sender As Object, e As EventArgs) Handles cmdSaveSwimmingGirls.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingSwimmingGirls.SelectedValue = "Y" Then
            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySwimmingGirls.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySwimmingGirls.Text), strSQL)
                strOK = "DONE"
                lblMessageSwimmingGirlsHeader.Text = "Save complete. Click DONE below."
                lblMessageSwimmingGirls.Text = "Save complete. Click DONE below."
            End If


            If strOK = "OK" Then
                Dim intValue1 As Long = 0
                Try
                    intValue1 = CLng(TextBoxSwimmingGirls1.Text)
                Catch ex As Exception
                    intValue1 = 0
                End Try

                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedBySwimmingGirls.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxSwimmingGirlsComments.Text) & "', "
                strSQL += "intValue1 = " & intValue1 & " "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedBySwimmingGirls.Text), strSQL)
                lblMessageSwimmingGirlsHeader.Text = "Save complete. Click DONE below."
                lblMessageSwimmingGirls.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageSwimmingGirlsHeader.Text = strResult
            lblMessageSwimmingGirls.Text = strResult
        End If

    End Sub


    Private Sub cmdSaveTennisBoys_Click(sender As Object, e As EventArgs) Handles cmdSaveTennisBoys.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingTennisBoys.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByTennisBoys.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByTennisBoys.Text), strSQL)
                lblMessageTennisBoysHeader.Text = "Save complete. Click DONE below."
                lblMessageTennisBoys.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListTennisBoys1.SelectedValue & "', "
                strSQL += "strYNQuestion2 = '" & RadDropDownListTennisBoys2.SelectedValue & "', "
                strSQL += "strYNQuestion3 = '" & RadDropDownListTennisBoys3.SelectedValue & "', "
                strSQL += "strYNQuestion4 = '" & RadDropDownListTennisBoys4.SelectedValue & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByTennisBoys.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxTennisBoysComments.Text) & "' "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByTennisBoys.Text), strSQL)
                lblMessageTennisBoysHeader.Text = "Save complete. Click DONE below."
                lblMessageTennisBoys.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageTennisBoysHeader.Text = strResult
            lblMessageTennisBoys.Text = strResult
        End If

    End Sub

    Private Sub cmdSaveTennisGirls_Click(sender As Object, e As EventArgs) Handles cmdSaveTennisGirls.Click
        Dim strSQL As String = ""
        Dim strOK As String = "OK"
        Dim strResult As String = VerifySave(Session("selectedSport"))

        If strResult = "OK" Then
            ' IS THIS COMPLETE?
            If RadDropDownListParticipatingTennisGirls.SelectedValue = "Y" Then

            Else
                ' Write the No...
                strSQL = "UPDATE prodParticipation SET EntryFormYN = 'N', strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByTennisGirls.Text) & "', EntryFormStamp = '" & Now & "' WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByTennisGirls.Text), strSQL)
                lblMessageTennisGirlsHeader.Text = "Save complete. Click DONE below."
                lblMessageTennisGirls.Text = "Save complete. Click DONE below."
                strOK = "DONE"
            End If

            If strOK = "OK" Then
                ' Create UPDATE SQL Statement...
                strSQL = "UPDATE prodParticipation SET "
                strSQL += "EntryFormYN = 'Y', "
                strSQL += "EntryFormStamp = '" & Now & "', "
                strSQL += "strYNQuestion1 = '" & RadDropDownListTennisGirls1.SelectedValue & "', "
                strSQL += "strYNQuestion2 = '" & RadDropDownListTennisGirls2.SelectedValue & "', "
                strSQL += "strYNQuestion3 = '" & RadDropDownListTennisGirls3.SelectedValue & "', "
                strSQL += "strYNQuestion4 = '" & RadDropDownListTennisGirls4.SelectedValue & "', "
                strSQL += "strSubmittedBy = '" & clsFunctions.StringValidate(TextBoxSubmittedByTennisGirls.Text) & "', "
                strSQL += "strComments = '" & clsFunctions.StringValidate(TextBoxTennisGirlsComments.Text) & "' "
                strSQL += "WHERE Id = " & Session("selectedID")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
                clsLog.LogEntryForm(Session("entryFormSchoolName"), Session("entryFormSchoolID"), Session("entryFormMemberID"), clsFunctions.StringValidate(TextBoxSubmittedByTennisGirls.Text), strSQL)
                lblMessageTennisGirlsHeader.Text = "Save complete. Click DONE below."
                lblMessageTennisGirls.Text = "Save complete. Click DONE below."
            Else
                ' DO nothing...
            End If
        Else
            lblMessageTennisGirlsHeader.Text = strResult
            lblMessageTennisGirls.Text = strResult
        End If

    End Sub
#End Region

#Region "Cancel Buttons"
    ' ======================================================================================================== CANCEL DATA...
    Private Sub cmdCancelBaseball_Click(sender As Object, e As EventArgs) Handles cmdCancelBaseball.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelCheerleading_Click(sender As Object, e As EventArgs) Handles cmdCancelCheerleading.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelCrossCountryBoys_Click(sender As Object, e As EventArgs) Handles cmdCancelCrossCountryBoys.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelFPSoftball_Click(sender As Object, e As EventArgs) Handles cmdCancelFPSoftball.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelVolleyball_Click(sender As Object, e As EventArgs) Handles cmdCancelVolleyball.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelSwimmingBoys_Click(sender As Object, e As EventArgs) Handles cmdCancelSwimmingBoys.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelSwimmingGirls_Click(sender As Object, e As EventArgs) Handles cmdCancelSwimmingGirls.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelTennisBoys_Click(sender As Object, e As EventArgs) Handles cmdCancelTennisBoys.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelTennisGirls_Click(sender As Object, e As EventArgs) Handles cmdCancelTennisGirls.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelBasketball_Click(sender As Object, e As EventArgs) Handles cmdCancelBasketball.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelGolfBoys_Click(sender As Object, e As EventArgs) Handles cmdCancelGolfBoys.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelGolfGirls_Click(sender As Object, e As EventArgs) Handles cmdCancelGolfGirls.Click
        Session("selectedID") = 0
    End Sub

    Private Sub cmdCancelSPSoftball_Click(sender As Object, e As EventArgs) Handles cmdCancelSPSoftball.Click
        Session("selectedID") = 0
    End Sub
#End Region

#Region "Misc Functions"
    Private Sub InsertIntoDetail(selectedID As Long, strPlayer As String, intSort As Integer)
        Dim strSQL As String = "INSERT INTO prodParticipationPlayers "

        If strPlayer = "" Then
        Else
            strPlayer = clsFunctions.StringValidateSQL(strPlayer)
            strSQL = strSQL & " (idParticipation, strPlayer, intSort, ysnActive) VALUES (" & selectedID & ", '" & strPlayer & "'," & intSort & ", 1)"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
        End If

    End Sub

    Private Sub RadDropDownListParticipatingTennisBoys_SelectedIndexChanged(sender As Object, e As DropDownListEventArgs) Handles RadDropDownListParticipatingTennisBoys.SelectedIndexChanged
        If RadDropDownListParticipatingTennisBoys.SelectedValue = "N" Then
            RadDropDownListTennisBoys1.SelectedValue = "N"
            RadDropDownListTennisBoys2.SelectedValue = "N"
            RadDropDownListTennisBoys3.SelectedValue = "N"
            RadDropDownListTennisBoys4.SelectedValue = "N"
        End If
    End Sub

    Private Sub RadDropDownListParticipatingTennisGirls_SelectedIndexChanged(sender As Object, e As DropDownListEventArgs) Handles RadDropDownListParticipatingTennisGirls.SelectedIndexChanged
        If RadDropDownListParticipatingTennisGirls.SelectedValue = "N" Then
            RadDropDownListTennisGirls1.SelectedValue = "N"
            RadDropDownListTennisGirls2.SelectedValue = "N"
            RadDropDownListTennisGirls3.SelectedValue = "N"
            RadDropDownListTennisGirls4.SelectedValue = "N"
        End If
    End Sub

    Public Property DataItem() As Object
        Get
            Return Me._dataItem
        End Get

        Set(ByVal value As Object)
            Me._dataItem = value
        End Set

    End Property

    'Protected Sub UpdatePanelFE1_Unload(sender As Object, e As EventArgs)
    '    Dim methodInfo As System.Reflection.MethodInfo = GetType(ScriptManager).GetMethods(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance).Where(Function(i) i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First()
    '    methodInfo.Invoke(ScriptManager.GetCurrent(Page), New Object() {TryCast(sender, UpdatePanel)})
    'End Sub
#End Region

#Region "Enable Controls (REMOVE)"
    Public Function EnableAllControls() As String
        ' Only show Save button when everything is completed....
        Select Case Session("selectedSport")
            Case "Basketball", "BasketballBoys", "BasketballGirls"
                If RadDropDownListParticipatingBasketball.SelectedValue = "N" And (TextBoxSubmittedByBasketball.Text <> "" And TextBoxSubmittedByBasketball.Text <> "Enter your name") Then
                    'cmdSaveBasketball.Enabled = True
                    'cmdSaveBasketball.ForeColor = Drawing.Color.Green
                    'cmdSaveBasketball.Font.Bold = True
                    EnableBasketballControls(False)
                ElseIf (RadDropDownListParticipatingBasketball.SelectedValue = "-" Or RadDropDownListParticipatingBasketball.SelectedValue = "C" Or RadDropDownListParticipatingBasketball.SelectedValue = "A") And (RadDropDownListBasketball1.SelectedValue = "-" Or TextBoxBasketball1.Text = "" Or TextBoxBasketball2.Text = "" Or TextBoxBasketball3.Text = "" Or TextBoxBasketball4.Text = "" Or TextBoxBasketball5.Text = "" Or TextBoxBasketball6.Text = "" Or TextBoxBasketball7.Text = "" Or TextBoxBasketball8.Text = "" Or TextBoxBasketball9.Text = "" Or TextBoxBasketball10.Text = "" Or TextBoxBasketball11.Text = "" Or TextBoxBasketball12.Text = "" Or TextBoxSubmittedByBasketball.Text = "" Or TextBoxSubmittedByBasketball.Text = "Enter your name") Then
                    'cmdSaveBasketball.Enabled = False
                    'cmdSaveBasketball.ForeColor = Drawing.Color.LightGray
                    'cmdSaveBasketball.Font.Bold = False
                    EnableBasketballControls(True)
                Else
                    'cmdSaveBasketball.Enabled = True
                    'cmdSaveBasketball.ForeColor = Drawing.Color.Green
                    'cmdSaveBasketball.Font.Bold = True
                    EnableBasketballControls(False)
                End If
            Case "BaseballFall", "Baseball"
                'If RadDropDownListBaseball1.SelectedValue <> "N" And (RadDropDownListBaseball1.SelectedValue = "-" Or RadDropDownListBaseball2.SelectedValue = "-" Or RadDropDownListBaseball3.SelectedValue = "-" Or RadDropDownListBaseball4.SelectedValue = "-" Or RadDropDownListBaseball5.SelectedValue = "-" Or RadDropDownListBaseball6.SelectedValue = "-" Or RadDropDownListBaseball7.SelectedValue = "-" Or RadDropDownListBaseball8.SelectedValue = "-" Or RadDropDownListBaseball9.SelectedValue = "-" Or RadDropDownListBaseball10.SelectedValue = "-" Or RadDropDownListBaseball11.SelectedValue = "-" Or RadDropDownListBaseball12.SelectedValue = "-" Or RadDropDownListBaseball13.SelectedValue = "-" Or RadDropDownListBaseball14.SelectedValue = "-" Or TextBoxBaseball1.Text = "" Or TextBoxBaseball2.Text = "" Or TextBoxBaseball3.Text = "" Or TextBoxBaseball4.Text = "" Or TextBoxBaseball5.Text = "" Or TextBoxSubmittedByBaseball.Text = "" Or TextBoxSubmittedByBaseball.Text = "Enter your name") Then
                '    cmdSaveBaseball.Enabled = False
                '    cmdSaveBaseball.ForeColor = Drawing.Color.LightGray
                '    cmdSaveBaseball.Font.Bold = False
                'Else
                '    cmdSaveBaseball.Enabled = True
                '    cmdSaveBaseball.ForeColor = Drawing.Color.Green
                '    cmdSaveBaseball.Font.Bold = True
                'End If
            Case "Cheerleading"
                'If RadDropDownListParticipatingCheerleading.SelectedValue <> "N" And (RadDropDownListCoEdSquad.SelectedValue = "-" Or TextBoxSubmittedByCheerleading.Text = "" Or TextBoxSubmittedByCheerleading.Text = "Enter your name") Then
                '    cmdSaveCheerleading.Enabled = False
                '    cmdSaveCheerleading.ForeColor = Drawing.Color.LightGray
                '    cmdSaveCheerleading.Font.Bold = False
                'Else
                '    cmdSaveCheerleading.Enabled = True
                '    cmdSaveCheerleading.ForeColor = Drawing.Color.Green
                '    cmdSaveCheerleading.Font.Bold = True
                'End If
            Case "CrossCountryBoys"
                'If RadDropDownListParticipatingCrossCountryBoys.SelectedValue <> "N" And (txtCrossCountryBoys1.Text = "" Or TextBoxSubmittedByCrossCountryBoys.Text = "" Or TextBoxSubmittedByCrossCountryBoys.Text = "Enter your name") Then
                '    cmdSaveCrossCountryBoys.Enabled = False
                '    cmdSaveCrossCountryBoys.ForeColor = Drawing.Color.LightGray
                '    cmdSaveCrossCountryBoys.Font.Bold = False
                'Else
                '    cmdSaveCrossCountryBoys.Enabled = True
                '    cmdSaveCrossCountryBoys.ForeColor = Drawing.Color.Green
                '    cmdSaveCrossCountryBoys.Font.Bold = True
                'End If
            Case "CrossCountryGirls"
                'If RadDropDownListParticipatingCrossCountryGirls.SelectedValue <> "N" And (txtCrossCountryGirls1.Text = "" Or TextBoxSubmittedByCrossCountryGirls.Text = "" Or TextBoxSubmittedByCrossCountryGirls.Text = "Enter your name") Then
                '    cmdSaveCrossCountryGirls.Enabled = False
                '    cmdSaveCrossCountryGirls.ForeColor = Drawing.Color.LightGray
                '    cmdSaveCrossCountryGirls.Font.Bold = False
                'Else
                '    cmdSaveCrossCountryGirls.Enabled = True
                '    cmdSaveCrossCountryGirls.ForeColor = Drawing.Color.Green
                '    cmdSaveCrossCountryGirls.Font.Bold = True
                'End If
            Case "FPSoftball"
                'If RadDropDownListFPSoftball1.SelectedValue <> "N" And (RadDropDownListFPSoftball1.SelectedValue = "-" Or RadDropDownListFPSoftball2.SelectedValue = "-" Or RadDropDownListFPSoftball3.SelectedValue = "-" Or RadDropDownListFPSoftball4.SelectedValue = "-" Or RadDropDownListFPSoftball5.SelectedValue = "-" Or RadDropDownListFPSoftball6.SelectedValue = "-" Or RadDropDownListFPSoftball7.SelectedValue = "-" Or RadDropDownListFPSoftball8.SelectedValue = "-" Or RadDropDownListFPSoftballHosting.SelectedValue = "-" Or TextBoxFPSoftball1.Text = "" Or TextBoxFPSoftball2.Text = "" Or TextBoxFPSoftball3.Text = "" Or TextBoxFPSoftball4.Text = "" Or TextBoxFPSoftball5.Text = "" Or TextBoxSubmittedByFPSoftball.Text = "" Or TextBoxSubmittedByFPSoftball.Text = "Enter your name") Then
                '    cmdSaveFPSoftball.Enabled = False
                '    cmdSaveFPSoftball.ForeColor = Drawing.Color.LightGray
                '    cmdSaveFPSoftball.Font.Bold = False
                'Else
                '    cmdSaveFPSoftball.Enabled = True
                '    cmdSaveFPSoftball.ForeColor = Drawing.Color.Green
                '    cmdSaveFPSoftball.Font.Bold = True
                'End If
            Case "SPSoftball"
                'If RadDropDownListSPSoftball1.SelectedValue <> "N" And (RadDropDownListSPSoftball1.SelectedValue = "-" Or RadDropDownListSPSoftball2.SelectedValue = "-" Or RadDropDownListSPSoftball3.SelectedValue = "-" Or RadDropDownListSPSoftball4.SelectedValue = "-" Or RadDropDownListSPSoftball5.SelectedValue = "-" Or RadDropDownListSPSoftball6.SelectedValue = "-" Or RadDropDownListSPSoftball7.SelectedValue = "-" Or RadDropDownListSPSoftball8.SelectedValue = "-" Or RadDropDownListSPSoftball9.SelectedValue = "-" Or RadDropDownListSPSoftballHosting.SelectedValue = "-" Or TextBoxSPSoftball1.Text = "" Or TextBoxSPSoftball2.Text = "" Or TextBoxSPSoftball3.Text = "" Or TextBoxSPSoftball4.Text = "" Or TextBoxSPSoftball5.Text = "" Or TextBoxSubmittedBySPSoftball.Text = "" Or TextBoxSubmittedBySPSoftball.Text = "Enter your name") Then
                '    cmdSaveSPSoftball.Enabled = False
                '    cmdSaveSPSoftball.ForeColor = Drawing.Color.LightGray
                '    cmdSaveSPSoftball.Font.Bold = False
                'Else
                '    cmdSaveSPSoftball.Enabled = True
                '    cmdSaveSPSoftball.ForeColor = Drawing.Color.Green
                '    cmdSaveSPSoftball.Font.Bold = True
                'End If
            Case "Volleyball"
                'If RadDropDownListParticipatingVolleyball.SelectedValue <> "N" And (RadDropDownListVolleyballHosting.SelectedValue = "-" Or TextBoxSubmittedByVolleyball.Text = "" Or TextBoxSubmittedByVolleyball.Text = "Enter your name") Then
                '    cmdSaveVolleyball.Enabled = False
                '    cmdSaveVolleyball.ForeColor = Drawing.Color.LightGray
                '    cmdSaveVolleyball.Font.Bold = False
                'Else
                '    cmdSaveVolleyball.Enabled = True
                '    cmdSaveVolleyball.ForeColor = Drawing.Color.Green
                '    cmdSaveVolleyball.Font.Bold = True
                'End If
            Case "SwimmingBoys", "SwimmingGirls", "Swimming"
                'If RadDropDownListParticipatingSwimmingB.SelectedValue <> "-" And RadDropDownListParticipatingSwimmingG.SelectedValue <> "-" Then
                '    cmdSaveSwimming.Enabled = True
                '    cmdSaveSwimming.ForeColor = Drawing.Color.Green
                '    cmdSaveSwimming.Font.Bold = True
                'Else
                '    cmdSaveSwimming.Enabled = False
                '    cmdSaveSwimming.ForeColor = Drawing.Color.LightGray
                '    cmdSaveSwimming.Font.Bold = False
                'End If
            Case "TennisBoys", "TennisGirls"
                'If RadDropDownListParticipatingTennisB.SelectedValue <> "N" Then
                '    cmdSaveTennis.Enabled = False
                '    cmdSaveTennis.ForeColor = Drawing.Color.LightGray
                '    cmdSaveTennis.Font.Bold = False
                'Else
                '    cmdSaveTennis.Enabled = True
                '    cmdSaveTennis.ForeColor = Drawing.Color.Green
                '    cmdSaveTennis.Font.Bold = True
                'End If
            Case Else
        End Select
        Return ""
    End Function

    'Private Sub EntryFormsEdit1_Init(sender As Object, e As EventArgs) Handles Me.Init
    '    '    'On Error Resume Next
    '    '    'Dim objScriptManager As Object = sender.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.FindControl("ScriptManager1")
    '    '    'objScriptManager.Remove(Me.UpdatePanelFE1)
    '    '    'objScriptManager.add(Me.UpdatePanelFE1)
    '    '    'sender.Controls.Remove(Me.UpdatePanelFE1)
    '    '    'sender.Controls.Add(Me.UpdatePanelFE1)

    'End Sub

    'Protected Sub UpdatePanelFE112_Unload(sender As Object, e As EventArgs)
    '    Dim methodInfo As System.Reflection.MethodInfo = GetType(ScriptManager).GetMethods(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance).Where(Function(i) i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First()
    '    methodInfo.Invoke(ScriptManager.GetCurrent(Page), New Object() {TryCast(sender, UpdatePanel)})
    'End Sub
#End Region

End Class

