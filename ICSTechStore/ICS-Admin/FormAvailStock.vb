Imports System.Data.OleDb
Public Class FormAvailStock

    Private Sub FormAvailStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetProd()
    End Sub

    Private Sub GetProd()

        Dim TotalItems As Integer

        Try
            DBQuery = "SELECT itemDescription, unitPrice, stockOnHand FROM ITEM Where stockOnHand > 0 Order By itemDescription"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

            dgw.Rows.Clear()
            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2))
                TotalItems += DBRead(2)
            Loop
            LabelTotalStocks.Text = TotalItems
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

End Class