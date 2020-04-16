Public Class testPayPal
    Inherits System.Web.UI.Page
    Public strPayPalButton As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            strPayPalButton = GetPayPalButtonCode()
        End If
    End Sub

    Public Function GetPayPalButtonCode() As String
        Dim strSQL As String = ""

        strSQL = strSQL & "<form action='https://www.paypal.com/cgi-bin/webscr' method='post' target='_top'>"
        strSQL = strSQL & "<input type='hidden' name='cmd' value='_s-xclick'>"
        strSQL = strSQL & "<input type='hidden' name='hosted_button_id' value='SHZ3B3TYMK7PU'>"
        strSQL = strSQL & "<table>"
        strSQL = strSQL & "<tr><td><input type='hidden' name='on0' value='Time of Movie'><span style='font-family:Verdana;'>Time of Movie</style></td></tr>"
        strSQL = strSQL & "<tr><td><select name='os0'>"
        'strSQL = strSQL & "<option value='Movie5'>Matinee $5.00 USD</option>"
        strSQL = strSQL & "<option value='Movie6'>Matinee $6.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie7'>Matinee $7.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie8'>Matinee $8.00 USD</option>"
        strSQL = strSQL & "<option value='Movie9'>Evening Movie $9.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie10'>Evening $10.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie11'>Evening $11.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie12'>Evening $12.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie13'>Evening $13.00 USD</option>"
        'strSQL = strSQL & "<option value='Movie14'>Evening $14.00 USD</option>"
        strSQL = strSQL & "</select> </td></tr>"
        'strSQL = strSQL & "<tr><td><input type='hidden' name='on1' value='# of Tickets'># of Tickets</td></tr><tr><td><input type='text' name='os1' maxlength='200'></td></tr>"
        strSQL = strSQL & "<tr><td><input type='text' name='quantity' style='width:40;'></td></tr>"
        strSQL = strSQL & "</table>"
        strSQL = strSQL & "<input type='hidden' name='currency_code' value='USD'>"
        'strSQL = strSQL & "<input type='hidden' name='quantity' value='15'>"
        strSQL = strSQL & "<input type='image' src='https://www.paypalobjects.com/en_US/i/btn/btn_buynowCC_LG.gif' border='0' name='submit' alt='PayPal - The safer, easier way to pay online!'>"
        strSQL = strSQL & "<img alt='' border='0' src='https://www.paypalobjects.com/en_US/i/scr/pixel.gif' width='1' height='1'>"
        strSQL = strSQL & "</form>"

        Return strSQL

    End Function
End Class