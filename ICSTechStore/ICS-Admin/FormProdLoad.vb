Imports System.Data.OleDb
Public Class FormProdLoad

    Private Sub frmLoadItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadItem()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Search()
    End Sub

    Private Sub dgw_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellDoubleClick
        If FormInventory.search = True Then
            FormInventory.TextProdNo.Text = dgw.CurrentRow.Cells(0).Value
            FormInventory.search = False
            Me.Close()
        End If

        If FormSale.SaleSearch = True Then
            FormSale.txtSearch.Text = dgw.CurrentRow.Cells(0).Value
            FormSale.SaleSearch = False
            Me.Close()
        End If
    End Sub

    Private Sub LoadItem()
        Try
            DBQuery = "SELECT prodNo, ItemCode, itemDescription, stockOnHand FROM Item Order By itemDescription"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2), DBRead(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub Search()
        Try
            DBQuery = "SELECT prodNo, ItemCode, itemDescription, stockOnHand FROM Item WHERE itemDescription LIKE '" & TextBox1.Text & "%' Order By itemDescription"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2), DBRead(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

End Class