Imports System.Data.OleDb
Public Class FormProcessSale

    ' An extension of FormSale

    Dim TotalAmt As Double
    Dim QuantAmt As Double

    Private Sub FormPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxAmount.Text = FormSale.LabelCost.Text
        FormMain.ToolStripStatusLabel2.Text = "Processing Sale"
    End Sub

    Private Sub ButtonProcSale_Click(sender As System.Object, e As System.EventArgs) Handles ButtonProcSale.Click

        TextBoxChange.Text = Format(Val(TextBoxCash.Text) - Val(TextBoxAmount.Text), "#,##0.00")

        If TextBoxCash.Text = "" Then
            MsgBox("Please Enter Amount! ", MsgBoxStyle.Information, "Payment")
            TextBoxCash.Focus()
            Exit Sub
        ElseIf Val(TextBoxCash.Text) < Val(TextBoxAmount.Text) Then
            MsgBox("Cash Insufficient. Insert more Rands!", MsgBoxStyle.Exclamation, "Payment")
            TextBoxCash.SelectAll()
            TextBoxCash.Focus()
            Exit Sub
        Else

            FormSale.AddSale()
            PaymentProc()
            ButtonPrintRec.Visible = True
            ButtonProcSale.Enabled = False
            Button2.Visible = True
        End If

        Panel1.Visible = True
        Label7.Text = Format(Date.Now, "Short Date")
        Label9.Text = Format(Date.Now, "Long Time")

        FormRec.Label7.Text = Format(Date.Now, "Short Date")
        FormRec.Label9.Text = Format(Date.Now, "Long Time")
        FormRec.Panel1.Visible = True

        lblInvoice.Text = FormSale.LabelRec.Text
        FormRec.lblInvoice.Text = FormSale.LabelRec.Text

        TotalAmtCalc()
        VatAmt()
        CashTime()
        LoadReceipt()
        FormSale.txtSearch.Focus()
        GroupBox1.Enabled = False
        ButtonProcSale.Enabled = False
        LabelStu = FormSale.LabelStudent
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FormMain.ToolStripStatusLabel2.Text = "Ready"
        Me.Dispose()
        FormSale.Dispose()
    End Sub

    Private Sub CashPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCash.KeyPress
        ' Nice validation here
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub PaymentProc()
        TextBoxCash.Text = TextBoxCash.Text.Replace(",", "")

        Try
            DBQuery = "INSERT INTO PAYMENT(recNo,[Cash],[Change]) VALUES('" & FormSale.LabelRec.Text & "','" & TextBoxCash.Text & "', '" & TextBoxChange.Text & "')"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub VatAmt()
        Try
            DBQuery = "Select VatAmount, NonVatAmount FROM Sale WHERE recNo = '" & FormSale.LabelRec.Text & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then
                zarVat.Text = Format(DBRead("VatAmount"), "#,##0.00")
                subTot.Text = Format(DBRead("NonVatAmount"), "#,##0.00")

                FormRec.zarVat.Text = Format(DBRead("VatAmount"), "#,##0.00")
                FormRec.subTot.Text = Format(DBRead("NonVatAmount"), "#,##0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub TotalAmtCalc()
        Try
            DBQuery = "Select TotalAmount FROM Sale WHERE recNo = '" & FormSale.LabelRec.Text & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then
                amtTotal.Text = Format(DBRead("TotalAmount"), "#,##0.00")

                FormRec.amtTotal.Text = Format(DBRead("TotalAmount"), "#,##0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub CashTime()
        Try
            DBQuery = "SELECT * FROM PAYMENT WHERE recNo = '" & FormSale.LabelRec.Text & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

            If DBRead.Read = True Then
                recCash.Text = Format(DBRead("Cash"), "#,##0.00")
                returnChn.Text = Format(DBRead("Change"), "#,##0.00")

                FormRec.recCash.Text = Format(DBRead("Cash"), "#,##0.00")
                FormRec.returnChn.Text = Format(DBRead("Change"), "#,##0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub LoadReceipt()
        Dim x As Integer = 0
        Dim Y As Integer = 0

        Try
            DBQuery = "SELECT itemDescription, itemPrice, [Quantity], saleDate, (unitPrice * [Quantity]) as TotalPrice FROM [Item] as I, SaleTemp as PD, Sale as P WHERE I.prodNo = PD.prodNo And PD.recNo = P.recNo AND P.recNo = '" & FormSale.LabelRec.Text & "' ORDER By itemDescription"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            FormRec.dgw.Rows.Clear()
            TotalAmt = 0.0
            QuantAmt = 0.0

            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead("Quantity"), DBRead("itemDescription"), DBRead("itemPrice"), DBRead("TotalPrice"))
                FormRec.dgw.Rows.Add(DBRead("Quantity"), DBRead("itemDescription"), DBRead("itemPrice"), DBRead("TotalPrice"))
                TotalAmt += DBRead("TotalPrice")
                QuantAmt += DBRead(2)
                dgw.Height += 19
                FormRec.dgw.Height += 19
                x += 19
            Loop

            Y = x - 30
            dgw.Height = dgw.Height - 20
            Panel1.Height = Panel1.Height + Y
            FormRec.Panel1.Height = Panel1.Height + Y
            Me.Height = Me.Height + Y
            FormRec.Height = FormRec.Height + Y

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub ButtonPrintRec_Click(sender As System.Object, e As System.EventArgs) Handles ButtonPrintRec.Click
        FormRec.ShowDialog()
    End Sub

End Class