' (c)2015 smntsn. Simple, dirty, cheap code for my central power management system.
' 4 Relays and an Arduino controls home electricity over ethernet.
'Arduino has its own code

'Alpha stage!

Public Class Form1

    Dim ArduinoAdr As String
    Dim ON1 As String
    Dim ON2 As String
    Dim ON3 As String
    Dim ON4 As String
    Dim OFF1 As String
    Dim OFF2 As String
    Dim OFF3 As String
    Dim OFF4 As String
    Dim TimerRelayStatus As String


    Public Class GlobalVariables
        'This area will be implemented in near future. Maybe maybe not ! :/
        'Public Shared UserName As String = "smntsn"
        'Public Shared UserAge As Integer = 99    

        ''I Hate Using Global Variables. I Hate Easy Way! :P
    End Class


    Private Sub Button1on_Click(sender As Object, e As EventArgs) Handles Button1on.Click
        ON1 = "http://" & ArduinoAdr & "/?ON1"
        WebBrowser1.Navigate(ON1)
        Button1on.Enabled = False
        Button1off.Enabled = False
        Timer1.Enabled = True
        Label2.ForeColor = Color.Green

    End Sub

    Private Sub Button1off_Click(sender As Object, e As EventArgs) Handles Button1off.Click
        OFF1 = "http://" & ArduinoAdr & "/?OFF1"
        WebBrowser1.Navigate(OFF1)
        Button1on.Enabled = False
        Button1off.Enabled = False
        Timer1.Enabled = True
        Label2.ForeColor = Color.Red

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ArduinoAdr = TextBox1.Text

    End Sub

    Private Sub Button2on_Click(sender As Object, e As EventArgs) Handles Button2on.Click
        ON2 = "http://" & ArduinoAdr & "/?ON2"
        WebBrowser2.Navigate(ON2)

        Button2on.Enabled = False
        Button2off.Enabled = False
        Timer1.Enabled = True
        Label3.ForeColor = Color.Green

    End Sub

    Private Sub Button2off_Click(sender As Object, e As EventArgs) Handles Button2off.Click
        OFF2 = "http://" & ArduinoAdr & "/?OFF2"
        WebBrowser2.Navigate(OFF2)
        Button2on.Enabled = False
        Button2off.Enabled = False
        Timer1.Enabled = True
        Label3.ForeColor = Color.Red
    End Sub

    Private Sub Button3on_Click(sender As Object, e As EventArgs) Handles Button3on.Click
        ON3 = "http://" & ArduinoAdr & "/?ON3"
        WebBrowser3.Navigate(ON3)
        Button3on.Enabled = False
        Button3off.Enabled = False
        Timer1.Enabled = True
        Label4.ForeColor = Color.Green

    End Sub

    Private Sub Button3off_Click(sender As Object, e As EventArgs) Handles Button3off.Click
        OFF3 = "http://" & ArduinoAdr & "/?OFF3"
        WebBrowser3.Navigate(OFF3)
        Button3on.Enabled = False
        Button3off.Enabled = False
        Timer1.Enabled = True
        Label4.ForeColor = Color.Red
    End Sub

    Private Sub Button4on_Click(sender As Object, e As EventArgs) Handles Button4on.Click
        ON4 = "http://" & ArduinoAdr & "/?ON4"
        WebBrowser4.Navigate(ON4)
        Button4on.Enabled = False
        Button4off.Enabled = False
        Timer1.Enabled = True
        Label5.ForeColor = Color.Green

    End Sub

    Private Sub Button4off_Click(sender As Object, e As EventArgs) Handles Button4off.Click
        OFF4 = "http://" & ArduinoAdr & "/?OFF4"
        WebBrowser4.Navigate(OFF4)
        Button4on.Enabled = False
        Button4off.Enabled = False
        Timer1.Enabled = True
        Label5.ForeColor = Color.Red
    End Sub

    Private Sub ButtonAllOn_Click(sender As Object, e As EventArgs) Handles ButtonAllOn.Click
        ON1 = "http://" & ArduinoAdr & "/?ON1"
        ON2 = "http://" & ArduinoAdr & "/?ON2"
        ON3 = "http://" & ArduinoAdr & "/?ON3"
        ON4 = "http://" & ArduinoAdr & "/?ON4"
        TimerRelayStatus = "makeOn"
        Timer1r.Enabled = True


    End Sub

    Private Sub ButtonAllOff_Click(sender As Object, e As EventArgs) Handles ButtonAllOff.Click
        OFF1 = "http://" & ArduinoAdr & "/?OFF1"
        OFF2 = "http://" & ArduinoAdr & "/?OFF2"
        OFF3 = "http://" & ArduinoAdr & "/?OFF3"
        OFF4 = "http://" & ArduinoAdr & "/?OFF4"
        TimerRelayStatus = "makeOff"
        Timer1r.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick, MyBase.Load
        Button1on.Enabled = True
        Button1off.Enabled = True
        Button2on.Enabled = True
        Button2off.Enabled = True
        Button3on.Enabled = True
        Button3off.Enabled = True
        Button4on.Enabled = True
        Button4off.Enabled = True
        Timer1.Enabled = False

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer1r.Tick
        If TimerRelayStatus = "makeOn" Then
            WebBrowser1.Navigate(ON1)
            Label2.ForeColor = Color.Green
        Else
            WebBrowser1.Navigate(OFF1)
            Label2.ForeColor = Color.Red
        End If
        Timer2r.Enabled = True
        Timer1r.Enabled = False
    End Sub

    Private Sub Timer2r_Tick(sender As Object, e As EventArgs) Handles Timer2r.Tick
        If TimerRelayStatus = "makeOn" Then
            WebBrowser2.Navigate(ON2)
            Label3.ForeColor = Color.Green
        Else
            WebBrowser2.Navigate(OFF2)
            Label3.ForeColor = Color.Red
        End If


        Timer2r.Enabled = False
            Timer3r.Enabled = True
    End Sub

    Private Sub Timer3r_Tick(sender As Object, e As EventArgs) Handles Timer3r.Tick
        If TimerRelayStatus = "makeOn" Then
            WebBrowser3.Navigate(ON3)
            Label4.ForeColor = Color.Green
        Else
            WebBrowser3.Navigate(OFF3)
            Label4.ForeColor = Color.Red
        End If
        Timer3r.Enabled = False
        Timer4r.Enabled = True
    End Sub

    Private Sub Timer4r_Tick(sender As Object, e As EventArgs) Handles Timer4r.Tick
        If TimerRelayStatus = "makeOn" Then
            WebBrowser4.Navigate(ON4)
            Label5.ForeColor = Color.Green
        Else
            WebBrowser4.Navigate(OFF4)
            Label5.ForeColor = Color.Red
        End If
        Timer4r.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate("http://" & ArduinoAdr)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            NumericUpDown8.Enabled = True
            NumericUpDown7.Enabled = True
            NumericUpDown6.Enabled = True
            NumericUpDown5.Enabled = True
            Label19.Enabled = True
            Label18.Enabled = True
            Label17.Enabled = True
            Label16.Enabled = True
        Else
            NumericUpDown8.Enabled = False
            NumericUpDown7.Enabled = False
            NumericUpDown6.Enabled = False
            NumericUpDown5.Enabled = False
            Label19.Enabled = False
            Label18.Enabled = False
            Label17.Enabled = False
            Label16.Enabled = False

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Timing functions will be here
    End Sub
End Class
