Imports System.Data.OleDb
Public Class FormInventory

    Dim addProd As Boolean
    Dim getStocksOnHand As Integer
    Public search As Boolean

    Private Sub ButtonSearchClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        search = True
        FormProdLoad.ShowDialog()
    End Sub

    Private Sub ProdNoText(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextProdNo.TextChanged
        If search = True Then
            GetProdInfo()
            search = False
        End If
    End Sub

    Private Sub FormItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        EnabledButton()
        DisabledText()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStock.Click
        AddProdsUpdate()
    End Sub

    Private Sub GetQuantity()
        Try
            DBQuery = "SELECT stockOnHand FROM Item WHERE prodNo = " & TextProdNo.Text & ""
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then
                getStocksOnHand = DBRead(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub AddProdsUpdate()
        If TextProdNo.Text = "" Then
            MsgBox("Please select product from 'Search Inventory' to update.", MsgBoxStyle.Critical, "Update Products")
            Exit Sub
        End If
        Dim strStocksIn As String
        strStocksIn = InputBox("Enter number of items : ", "Update Products")
        TextQuant.Text = Val(TextQuant.Text) + Val(strStocksIn)
        Try
            DBQuery = "INSERT INTO ProdIn(prodNo, prodQuantity, prodDate, prodCurrent) VALUES('" & TextProdNo.Text & "', '" & strStocksIn & "', '" & Format(Date.Now, "Short Date") & "', " & TextQuant.Text & ")"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            Dim i As Integer

            i = DBCmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Products added successfully", MsgBoxStyle.Information, "Update Products")
                Updateproduct()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub UpdateItem()
        TextPrice.Text = TextPrice.Text.Replace(",", "")
        Try
            DBQuery = "UPDATE Item SET ItemCode = '" & TextProdCode.Text & "', itemDescription = '" & TextDesc.Text & "', itemSize ='" & TextSize.Text & "', stockOnHand = '" & TextQuant.Text & "', unitPrice = '" & TextPrice.Text & "', bumpLevel = '" & TextBumpUp.Text & "' WHERE prodNo = " & TextProdNo.Text & ""
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            Dim i As Integer
            i = DBCmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Inventory Updated", MsgBoxStyle.Information, "Update Item")
            Else
                MsgBox("Failed to update Inventory", MsgBoxStyle.Information, "Update Item")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub GetProdInfo()
        Try
            DBQuery = "SELECT ItemCode, itemDescription, itemSize, stockOnHand, unitPrice, bumpLevel FROm Item Where prodNo = " & TextProdNo.Text & ""
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then
                TextProdCode.Text = DBRead(0)
                TextDesc.Text = DBRead(1)
                TextSize.Text = DBRead(2)
                TextQuant.Text = DBRead(3)
                TextPrice.Text = DBRead(4)
                TextBumpUp.Text = DBRead(5)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        TextProdNo.Text = ""
        TextProdCode.Text = ""
        TextDesc.Text = ""
        TextSize.Text = ""
        TextQuant.Text = ""
        TextPrice.Text = ""
        TextBumpUp.Text = ""
    End Sub

    Private Sub DisabledText()
        TextProdNo.Enabled = False
        TextProdCode.Enabled = False
        TextDesc.Enabled = False
        TextSize.Enabled = False
        TextQuant.Enabled = False
        TextPrice.Enabled = False
        TextBumpUp.Enabled = False
    End Sub

    Private Sub EnabledButton()
        ButtonSearch.Enabled = True
    End Sub

    Private Sub Updateproduct()
        GetQuantity()
        UpdateItem()
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

End Class