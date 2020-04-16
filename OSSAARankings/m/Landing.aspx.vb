Public Class Landing
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intButtonHeight As Integer = 60
        Dim intButtonFontSize As Integer = 12

        ' Set the SIZE...
        If Request.UserAgent.ToUpper.Contains("IPHONE") Then
            lblHeader.Style("font-size") = "1.6em"
            intButtonHeight = 70
            intButtonFontSize = 14
            ButtonsChange(intButtonHeight, intButtonFontSize)
            LinkButton1.Text = "<br><br>OSSAARankings.com"
            LinkButton2.Text = "<br><br>COACHES LOGIN"
            LinkButton3.Text = "<br><br>ATHLETIC DIRECTOR LOGIN"
        ElseIf Request.UserAgent.ToUpper.Contains("ANDROID") Then
            lblHeader.Style("font-size") = "4.0em"
            intButtonHeight = 130
            intButtonFontSize = 40
            ButtonsChange(intButtonHeight, intButtonFontSize)
            LinkButton1.Text = "<br><br><br><br><br>OSSAARankings.com"
            LinkButton2.Text = "<br><br><br><br><br>COACHES LOGIN"
            LinkButton3.Text = "<br><br><br><br><br>ATHLETIC DIRECTOR LOGIN"
        ElseIf Request.UserAgent.ToUpper.Contains("WINDOWS PHONE") Then
            intButtonHeight = 40
            intButtonFontSize = 14
            ButtonsChange(intButtonHeight, intButtonFontSize)
            LinkButton1.Text = "<br>OSSAARankings.com"
            LinkButton2.Text = "<br>COACHES LOGIN"
            LinkButton3.Text = "<br>ATHLETIC DIRECTOR LOGIN"
            lblHeader.Style("font-size") = "1.25em"
        ElseIf Request.UserAgent.ToUpper.Contains("IPAD") Then
            lblHeader.Style("font-size") = "2.5em"
            intButtonHeight = 60
            intButtonFontSize = 16
            ButtonsChange(intButtonHeight, intButtonFontSize)
        End If

        'lblHeader.Text = "OSSAARankings.com"
        lblHeader.Visible = False

    End Sub

    Public Sub ButtonsChange(intButtonHeight As Integer, intButtonFontSize As Integer)
        On Error Resume Next
        Dim x As Integer = 0

        For x = 0 To 3
            Dim objControl As System.Web.UI.WebControls.LinkButton
            objControl = FindControl("LinkButton" & x)
            objControl.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
            objControl.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Next

    End Sub

End Class