Imports System.Data.OleDb
Module DB

    ' The backend of the project. Makes the system real as possible

    Public DBQuery As String
    Public DBCmd As OleDbCommand
    Public DBRead As OleDbDataReader
    Public DBLink As OleDbConnection
    Public DBJet As String = System.Environment.CurrentDirectory.ToString & "\ICSTechStore.mdb"

    Public Sub DBLinker()
        Try
            DBLink = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBJet & "")
            DBLink.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
