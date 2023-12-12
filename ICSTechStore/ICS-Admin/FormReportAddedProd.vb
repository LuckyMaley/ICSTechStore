Imports System.Data.OleDb
Public Class FormReportAddedProd

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ProdsUpdate()
    End Sub

    Private Sub ProdsUpdate()
        Dim TotQuant As Integer
        Dim TotStock As Integer

        Try
            DBQuery = "SELECT prodDate, itemDescription, prodQuantity, prodCurrent FROM Item as I, ProdIn as S WHERE I.prodNo = S.prodNo AND prodDate >= #" & dtpFrom.Text & "# AND prodDate <=#" & dtpTo.Text & "# Order By prodDate, itemDescription"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            TotQuant = 0
            TotStock = 0

            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2), DBRead(3))
                TotQuant += DBRead(2)
                TotStock += DBRead(2)
            Loop

            LabelQuant.Text = Format(TotQuant, "#,##0")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

End Class