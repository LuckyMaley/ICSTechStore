Imports System.Data.OleDb
Public Class FormProdSold
    Friend SalesAverage As Double
    Friend totalAmount As Double
    Friend totalQuantity As Integer

    Private Sub FormItemSold_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxQuantity.Text = ""
        TextBoxTotal.Text = ""
        TextBoxAvg.Text = ""
        dgw.Rows.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoadSoldItems()
        SaleReport()
    End Sub

    Private Sub LoadSoldItems()
        DBQuery = "SELECT itemDescription, unitPrice, SUM([Quantity]) as prodQuantity, saleDate, (unitPrice * SUM([Quantity])) As TotalAmount FROM Item as I, Sale as P, SaleTemp as PD WHERE I.prodNo = PD.prodNo AND PD.recNo=P.recNo AND DAY(saleDate) =" & Format(DateTimePicker1.Value, "dd") & " Group By itemDescription, unitPrice, [Quantity], saleDate ORder By itemDescription"

        Try
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            totalAmount = 0
            totalQuantity = 0

            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2), DBRead(4))
                totalQuantity += DBRead(2)
                totalAmount += DBRead(4)
            Loop

            TextBoxQuantity.Text = totalQuantity
            TextBoxTotal.Text = Format(totalAmount, "#,##0.00")

            If totalQuantity And totalAmount > 0 Then
                SalesAverage = totalAmount / totalQuantity
                TextBoxAvg.Text = Format(SalesAverage, "#, ##0.00")
            Else : TextBoxAvg.Text = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Function SaleLevel(SalesAverage As Object) As String
        Select Case SalesAverage
            Case Is >= 1000
                SaleLevel = "Top Performance"
            Case Else
                SaleLevel = "Poor Performance"
        End Select
    End Function

    Private Sub SaleReport()
        ' Generates and stores a basic log of daily sales to send via mail
        Try
            Dim SaleLogger As String = Application.StartupPath() & "/DailyLog.txt"
            Dim ICS_writer As New IO.StreamWriter(SaleLogger, True)

            Try
                ICS_writer.Write(Environment.NewLine & Date.Now & " " & Environment.NewLine)
                ICS_writer.Write(Environment.NewLine & "Total Sales Amount for day : R " & totalAmount)
                ICS_writer.Write(Environment.NewLine & "Total Sales Quantity for day : " & totalQuantity)
                ICS_writer.Write(Environment.NewLine & "Average Sale for day : R " & SalesAverage)
                ICS_writer.Write(Environment.NewLine & "Level of Sales : " & SaleLevel(SalesAverage))
                ICS_writer.Write(Environment.NewLine & "==================================================================" & Environment.NewLine)
            Finally
                ICS_writer.Close()
            End Try

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Exclamation, "Could not generate log.")

        End Try
    End Sub

End Class