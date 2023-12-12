Imports System.Data.OleDb
Public Class FormRec

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Me.PrintDialog1.ShowDialog() Then
            Me.PrintForm1.PrinterSettings = PrintDialog1.PrinterSettings
            Button1.Visible = False
            Try
                Me.PrintForm1.Print()
            Catch ex As Exception
                MsgBox("Could not connect to Printer", MsgBoxStyle.Exclamation, "Print Receipt")
            End Try
        End If
    End Sub

    Private Sub FormRec_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LabelStu.Text = FormSale.LabelStudent.Text
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FormMain.ToolStripStatusLabel2.Text = "Ready"
        Me.Dispose()
        FormSale.Dispose()
        FormProcessSale.Dispose()
    End Sub

End Class