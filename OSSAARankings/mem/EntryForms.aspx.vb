
Imports Telerik.Web.UI


Public Class EntryForms
    Inherits System.Web.UI.Page

    Shared strHide As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("entryFormSchoolName") = "" Then
            'Session("entryFormSchoolID") = 122
            'Session("entryFormSchoolName") = "KINGFISHER"
            Session("entryFormSchoolID") = 9999
            Session("entryFormSchoolName") = ""
        ElseIf Session("entryFormSchoolName") Is Nothing Then
            Session("entryFormSchoolID") = 9999
            Session("entryFormSchoolName") = ""
        End If

        If Not IsPostBack Then
            strHide = "HIDE"
        End If

        RadGrid1.Rebind()

    End Sub

    Public Sub GetDropDownValue(sender As Object, e As Object)
        Dim objColor As Object = Drawing.Color.Black
        Dim strResult As String = ""
        Dim strComplete As String = ""
        Dim objComplete As Object

        ' Let's set the value of the DropDown...
        Dim objParent As Object
        objParent = sender.Parent
        Dim objDropDown As Object

        ' Get the DropDown object...
        objDropDown = objParent.FindControl("cboEntryFormYN")

        ' What is the value supposed to be...
        Dim objValue As Object = objParent.FindControl("hiddenFormYN").Value

        ' Set it...
        objDropDown.SelectedValue = objValue
        objComplete = objParent.FindControl("hiddenFormComplete").value

        Dim objSportLabel As Object = objParent.FindControl("lblDetailHeader")
        Try
            Dim strSportLabel As String = objSportLabel.text
            If strSportLabel.Contains("Basketball") Then
                objSportLabel.Text = "Basketball"
            End If
        Catch ex As Exception

        End Try

        Dim objSportGenderKey As Object = objParent.FindControl("hiddenSportGenderKey").value

        If Session("entryFormMemberID") > 0 Then        ' It is a Member/Coach Login..
            If SportGenderKeyMatch(objSportGenderKey) = "OK" Then
                objParent.Parent.Display = True
            Else
                objParent.Parent.Display = False
            End If
        Else
            objParent.Parent.Display = True
        End If

        strComplete = ""

        If objParent.Parent.Display = True Then
            If objValue = "Y" Then
                If objSportLabel.Text = "Basketball" Then
                    strResult = "<strong>FACILITY FORM SUBMITTED</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                Else
                    strResult = "<strong>YES Participating</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                End If

                objColor = Drawing.Color.White
                If objComplete = "N" Then
                    objParent.BackColor = Drawing.Color.Green
                Else
                    objParent.BackColor = Drawing.Color.Transparent
                End If

            ElseIf objValue = "N" Then
                If objSportLabel.Text = "Basketball" Then
                    strResult = "<strong>NOT HOSTING PLAYOFFS</strong> (submitted on :  " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                    objColor = Drawing.Color.DarkGray
                    objParent.BackColor = Drawing.Color.Gray
                Else
                    strResult = "<strong>NOT Participating</strong> (submitted on :  " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                    ' HIDE OBJECT???
                    'objColor = Drawing.Color.Red
                    'If strHide = "HIDE" Then objParent.Parent.Display = False
                    'objParent.BackColor = Drawing.Color.Orange
                    objColor = Drawing.Color.Gray
                    objParent.BackColor = Drawing.Color.LightGray
                End If

            ElseIf objValue = "C" Or objValue = "A" Then
                strResult = "<strong>FACILITY FORM SUBMITTED</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                objColor = Drawing.Color.White
                If objComplete = "N" Then
                    objParent.BackColor = Drawing.Color.LightGreen
                Else
                    objParent.BackColor = Drawing.Color.Transparent
                End If
            ElseIf objValue = "U" Then
                strResult = "<strong>UNDECIDED</strong>"
                objColor = Drawing.Color.Black
                objParent.BackColor = Drawing.Color.Yellow

            Else
                'objComplete.Value = ""
                objParent.BackColor = Drawing.Color.Transparent
            End If

            Dim objDetail As Object = objParent.FindControl("lblDetailFooter")
            objDetail.Text = strResult
            objDetail.ForeColor = objColor
        End If

    End Sub

    Public Function SportGenderKeyMatch(strSportGenderKey As String) As String
        ' TURN ON THE SPORTS FOR THE COACH...
        Dim strReturn As String = "FAILED"
        Dim ds As New DataSet
        Dim x As Integer = 0
        ds = Session("memdsCoachesSports")

        If ds Is Nothing Then
            strReturn = "FAILED"
        ElseIf ds.Tables.Count = 0 Then
            strReturn = "FAILED"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strReturn = "FAILED"
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(x).Item("sportID") = strSportGenderKey Then
                    strReturn = "OK"
                    Exit For
                End If
            Next
        End If
        Return strReturn
    End Function
    Shared Sub HideUnhide(sender As Object, e As Object)

        If sender.SelectedValue = "UNHIDE" Then
            strHide = "UNHIDE"
        Else
            strHide = "HIDE"
        End If

        ' Refresh the Grid....
        sender.Parent.Parent.FindControl("RadGrid1").Databind()

    End Sub

    Private Sub RadGrid1_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        Session("selectedID") = 0
    End Sub

End Class
