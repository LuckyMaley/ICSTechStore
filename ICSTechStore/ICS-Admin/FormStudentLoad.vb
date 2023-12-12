Imports System.Data.OleDb
Public Class FormStudentLoad

    Private Sub dgw_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellDoubleClick
        If FormStudentReg.search = True Then
            FormStudentReg.txtCustNo.Text = dgw.CurrentRow.Cells(0).Value
            Me.Close()
        End If

        If FormSale.IssaStudent = True Then
            FormSale.LabelCustNo.Text = dgw.CurrentRow.Cells(0).Value
            FormSale.LabelStudent.Text = dgw.CurrentRow.Cells(1).Value
            FormProcessSale.LabelStu.Text = "Student  :  " & dgw.CurrentRow.Cells(1).Value
            FormSale.IssaStudent = False
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        SearchStudent()
    End Sub

    Private Sub FormCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetStudent()
    End Sub

    Private Sub GetStudent()
        Try
            DBQuery = "SELECT CustomerNo, stuName, college FROM Student Order By stuName"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()

            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2))
            Loop

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub SearchStudent()
        Try
            DBQuery = "SELECT CustomerNo, stuName, college FROM Student WHERE stuName LIKE '" & TextBox1.Text & "%' Order By stuName"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()

            Do While DBRead.Read = True
                dgw.Rows.Add(DBRead(0), DBRead(1), DBRead(2))
            Loop

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

End Class