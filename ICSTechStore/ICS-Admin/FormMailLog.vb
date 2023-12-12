Public Class FormMailLog

    Friend ManagerAdd As String
    Friend ProgBar As Integer = 0

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        ' Email functionality for management purposes. Assume the terminal is always-on, connected to the internet

        Label2.Visible = False
        ManagerAdd = TextBox1.Text
        Button3.Enabled = False
        Button3.Text = "Sending"
        TextBox1.Enabled = False
        Mailman()
    End Sub

    Private Sub FormMailer_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        TextBox1.Clear()
        Label2.Visible = False
    End Sub

End Class