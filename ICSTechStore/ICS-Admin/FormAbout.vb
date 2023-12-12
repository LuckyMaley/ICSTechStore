Public Class FormAbout

    Private Sub ButtonClose_Click(sender As System.Object, e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub FormAbout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.Opacity = 0
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        ' Another Animation effect

        Dim opacityFade As Single

        Me.Opacity += 0.03
        If Me.Opacity = 100 Then
            Timer1.Stop()
        End If

        For opacityFade = 0 To 1 Step 0.01
            Me.Opacity = opacityFade
            Me.Refresh()
            System.Threading.Thread.Sleep(10)
        Next opacityFade
        Me.Opacity = 1
        Timer1.Enabled = False
    End Sub

End Class