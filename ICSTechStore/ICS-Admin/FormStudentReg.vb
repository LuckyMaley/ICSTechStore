Imports System.Data.OleDb
Public Class FormStudentReg

    Dim addStu As Boolean
    Dim updateStu As Boolean
    Public search As Boolean

    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        AddCustomer()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub Stu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxStuNo.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub FormRegister_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        TextBoxStuNo.Clear()
        TextBoxName.Clear()
        ComboBoxCollege.SelectedIndex = -1
    End Sub

    Private Sub FormRegister_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ButtonSave.Enabled = False
    End Sub

    Private Sub TextBoxStuNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxStuNo.TextChanged, TextBoxName.TextChanged, ComboBoxCollege.SelectedIndexChanged
        If Not TextBoxStuNo.Text = "" And Not TextBoxName.Text = "" And Not ComboBoxCollege.SelectedIndex = -1 Then
            ButtonSave.Enabled = True
        End If
    End Sub

    Private Sub AddCustomer()
        Try
            DBQuery = "INSERT INTO Student(stuName, college, stuNumber) Values('" & TextBoxName.Text & "', '" & ComboBoxCollege.SelectedItem & "', '" & TextBoxStuNo.Text & "')"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            Dim i As Integer
            i = DBCmd.ExecuteNonQuery

            If i > 0 Then
                MsgBox("Student Added", MsgBoxStyle.Information, "Add Student")
                ButtonSave.Enabled = False
            Else
                MsgBox("Failed to add customer", MsgBoxStyle.Critical, "Add Student")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtCustNo.Text = ""
        TextBoxName.Text = ""
        TextBoxStuNo.Text = ""
        ComboBoxCollege.SelectedIndex = -1
    End Sub

    Private Sub EnabledButton()
        ButtonClose.Enabled = True
    End Sub

End Class