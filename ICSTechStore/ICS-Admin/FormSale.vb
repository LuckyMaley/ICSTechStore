Imports System.Data.OleDb
Public Class FormSale

    ' The major part of the system

    Dim ProdQuant As Integer
    Dim ProdCode As String
    Dim ProdDesc As String
    Dim StockPrice As Double
    Dim TotPrice As Double
    Dim TotCost As Double
    Dim ProdNo As Integer
    Dim ProdDelete As Integer
    Dim ExclVat As Double
    Dim IncVat As Double
    Dim IssaQuant As Boolean

    Friend SaleProgress As Boolean

    Public SaleSearch As Boolean
    Public IssaStudent As Boolean

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LabelTime.Text = Format(Date.Now, "Long Time")
    End Sub

    Private Sub FormSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldate.Text = Format(Date.Now, "Long Date")
        RecNo()
        Label5.Text = FormLogin.CurrentUser
        FormMain.ToolStripStatusLabel2.Text = "Sale in Progress"
    End Sub

    Private Sub Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If QuantAvail() = True Then
            ProdInfo()
        End If
    End Sub

    Private Sub AddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddItem.Click
        SaleSearch = True
        FormProdLoad.ShowDialog()
    End Sub

    Private Sub Quantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextQuant.KeyPress

        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
        txtSearch.Focus()
    End Sub

    Private Sub Quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextQuant.TextChanged
        IssaQuant = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextQuant.Focus()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        ClearCurrent()
        FormMain.ToolStripStatusLabel2.Text = "Ready"
        Me.Dispose()
    End Sub

    Private Sub Payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPay.Click
        Dim ProdCounter As Integer
        ProdCounter = dgw.RowCount

        If ProdCounter > 0 And LabelStudent.Text <> "Default" Then
            FormProcessSale.ShowDialog()
        Else : MsgBox("There are no items added to sale / No Student loaded", MsgBoxStyle.Critical, "Blank Fields")
        End If
    End Sub

    Private Sub LoadStudent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCust.Click
        IssaStudent = True
        FormStudentLoad.ShowDialog()
    End Sub

    Private Function QuantAvail() As Boolean
        Try
            DBQuery = "SELECT stockOnHand FROM ITEM WHERE prodNo = " & Val(txtSearch.Text) & ""
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

            If DBRead.Read = True Then

                If Val(TextQuant.Text) <= DBRead(0) Then
                    QuantAvail = True
                Else
                    MsgBox("Insuficient items available", MsgBoxStyle.Critical, "Update Products")
                    txtSearch.Clear()
                    TextQuant.Clear()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Function

    Private Sub RecNo()
        Try
            DBQuery = "SELECT recNo FROm Sale Order By recNo desc"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

            If DBRead.Read = True Then
                LabelRec.Text = Val(DBRead(0)) + 1

            Else
                LabelRec.Text = 1000000
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub ProdInfo()
        Try
            DBQuery = "SELECT ItemCode, itemDescription, stockOnHand, unitPrice, prodNo FROM ITEM Where prodNo = " & Val(txtSearch.Text) & ""
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

            If DBRead.Read = True Then
                ProdCode = DBRead(0)
                ProdDesc = DBRead(1)
                StockPrice = DBRead(3)
                ProdNo = DBRead(4)

                If IssaQuant = True Then
                    Try
                        ProdQuant = TextQuant.Text
                    Catch ex As Exception
                        Me.ErrorProvider1.SetError(Me.TextQuant, "Quantity must be numeric")
                    End Try

                    TextQuant.Text = ""
                    IssaQuant = False
                Else
                    ProdQuant = 1
                End If

            End If

            If DBRead("stockOnHand") <> 0 Then
                TotPrice = ProdQuant * StockPrice
                TotCost += TotPrice
                LabelCost.Text = TotCost
                TempSale()
                DecreaseQuant()
                dgw.Rows.Add(ProdQuant, ProdCode, ProdDesc, StockPrice, TotPrice)
                txtSearch.Text = ""
                SaleProgress = True

            Else : MsgBox("No Stock Available", MsgBoxStyle.Critical, "Update Products")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub TempSale()
        Try
            DBQuery = "INSERT INTO SaleTemp(recNo, prodNo, itemPrice, Quantity) Values('" & LabelRec.Text & "', '" & ProdNo & "', '" & StockPrice & "', '" & ProdQuant & "')"
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

    Private Sub DecreaseQuant()
        Try
            DBQuery = "Update Item SET stockOnHand = stockOnHand - '" & ProdQuant & "' WHERE prodNo = " & ProdNo & ""
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

    Private Sub ProdCodeDelete()
        Try
            DBQuery = "SELECT prodNo FROM item Where ItemCode = '" & dgw.CurrentRow.Cells(1).Value & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then
                ProdDelete = DBRead(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub SaleTempDelete()
        Try
            DBQuery = "DELETE FROM SaleTemp WHERE itemNo = " & ProdDelete & " AND recNo = '" & LabelRec.Text & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub IncreaseQuant()
        Try
            DBQuery = "Update Item SET stockOnHand = stockOnHand + '" & dgw.CurrentRow.Cells(0).Value & "' WHERE prodNo = " & ProdDelete & ""
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

    Public Sub AddSale()
        IncVat = Format((LabelCost.Text * 0.15), "#,##0.00")
        ExclVat = Format(LabelCost.Text - IncVat, "#,##0.00")
        Try
            DBQuery = "INSERT INTO Sale(recNo, saleDate, POSTime, NonVatAmount, VatAmount, TotalAmount) VALUES('" & LabelRec.Text & "', '" & Format(Date.Now, "Short Date") & "', '" & Format(Date.Now, "Long Time") & "', '" & ExclVat & "', '" & IncVat & "', '" & LabelCost.Text & "')"
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

    Private Sub ClearCurrent()
        Dim ItemCounter As Integer
        ItemCounter = dgw.RowCount

        If ItemCounter > 0 Then

            Do
                ProdCodeDelete()
                IncreaseQuant()
                dgw.Rows.Remove(dgw.SelectedRows.Item(0))
                ItemCounter = ItemCounter - 1
            Loop Until ItemCounter = 0

            If ItemCounter = 0 Then
                LabelCost.Text = "0.00"
                TotCost = 0
                RecNo()
                txtSearch.Focus()
            End If

            Try
                DBQuery = "DELETE FROM SaleTemp WHERE recNo = '" & LabelRec.Text & "'"
                DBLinker()
                DBCmd = New OleDbCommand(DBQuery, DBLink)
                Dim i As Integer
                i = DBCmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Item Deleted", MsgBoxStyle.Information, "Delete Item")
                Else
                    MsgBox("Failed to Delete item", MsgBoxStyle.Critical, "Delete Item")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
            DBCmd.Dispose()
            DBLink.Close()

        ElseIf ItemCounter = 0 Then
            Me.Dispose()
        End If
    End Sub

End Class