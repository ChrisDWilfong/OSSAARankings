Imports Telerik.Web.UI

Public Class EntryFormsList2
    Inherits System.Web.UI.UserControl

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
        ElseIf Session("entryFormSchoolNameSelected") <> Session("entryFormSchoolName") Then
            Session("entryFormSchoolNameSelected") = Session("entryFormSchoolName")
            RadGrid1.DataSourceID = "SqlDataSource1"
        End If

        If Not IsPostBack Then
            strHide = "HIDE"
        End If

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
        Dim objValue1 As Object = objParent.FindControl("hiddenFormYN1").Value

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
            If objValue = "Y" Or objValue1 = "Y" Then
                If objSportLabel.Text = "Basketball" Then
                    strResult = "<strong>FACILITY FORM SUBMITTED</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                Else
                    If objSportLabel.text = "Cheerleading" Then
                        If objValue = "Y" And objValue1 = "N" Then
                            strResult = "<strong>Participating : COMPETITIVE = YES : GAME DAY = NO</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                        ElseIf objValue = "N" And objValue1 = "Y" Then
                            strResult = "<strong>Participating : COMPETITIVE = NO : GAME DAY = YES</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                        Else
                            strResult = "<strong>Participating : COMPETITIVE = YES : GAME DAY = YES</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                        End If
                    Else
                        strResult = "<strong>YES Participating</strong> (submitted on : " & IIf(objParent.FindControl("hiddenFormStamp").Value = "", Now, objParent.FindControl("hiddenFormStamp").Value) & ") " & strComplete
                    End If
                End If
                objColor = Drawing.Color.White
                If objComplete = "N" Or objComplete = "NO" Or strResult.Contains("YES Part") Then
                    objParent.BackColor = Drawing.Color.Green
                ElseIf objSportLabel.text = "Cheerleading" And (objValue = "Y" Or objValue1 = "Y") Then
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
                objParent.BackColor = Drawing.Color.LightGreen      ' Changed 7/17/2018...
                'If objComplete = "N" Then
                '    objParent.BackColor = Drawing.Color.LightGreen
                'Else
                '    objParent.BackColor = Drawing.Color.Transparent
                'End If
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

            ' Get the Cell Info of the Edit Hyperlink... 6/21/2018...
            'Dim objHyperlink As Object = objParent.Parent.Parent.Parent.Columns(0)
            Dim isActive As Object = objParent.FindControl("HiddenActive").Value

            'If isActive = 1 Then
            '    objParent.Parent.Parent.Parent.Columns(0).EditText = "Enter Form Details"
            'Else
            '    objParent.Parent.Parent.Parent.Columns(0).EditText = "Not Currently Open"
            'End If

        End If

    End Sub

    Public Function SportGenderKeyMatch(strSportGenderKey As String) As String
        ' TURN ON THE SPORTS FOR THE COACH...
        Dim strReturn As String = "FAILED"
        Dim ds As New DataSet
        Dim x As Integer = 0
        Dim strSportID As String = ""
        ds = Session("memdsCoachesSports")

        If ds Is Nothing Then
            strReturn = "FAILED"
        ElseIf ds.Tables.Count = 0 Then
            strReturn = "FAILED"
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            strReturn = "FAILED"
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                strSportID = ds.Tables(0).Rows(x).Item("SportGenderKey")
                If strSportID = strSportGenderKey Then
                    strReturn = "OK"
                    Exit For
                ElseIf strSportGenderKey = "CheerleadingGD" And strSportID = "Cheerleading" Then    ' CDW added 7/29/2019 to account for GameDay in the coaches dropdown list of Entry Forms...
                    strReturn = "OK"
                    Exit For
                ElseIf strSportID.Contains("Basketball") And strSportGenderKey.Contains("Basketball") Then
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

    Private Sub RadGrid1_EditCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.EditCommand
        ' CDW added 7/18/2019...
        If ConfigurationManager.AppSettings("EntryFormsActive") = "0" Then
            e.Canceled = True
        Else
        End If
    End Sub




    'Protected Sub updProgress_Init(sender As Object, e As EventArgs)
    '    Dim methodInfo As System.Reflection.MethodInfo = GetType(ScriptManager).GetMethods(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance).Where(Function(i) i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First()
    '    methodInfo.Invoke(ScriptManager.GetCurrent(Page), New Object() {TryCast(sender, UpdatePanel)})
    'End Sub
End Class
