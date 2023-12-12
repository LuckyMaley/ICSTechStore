Imports System.Data.OleDb
Public Class FormLogin

    'Also serves as the splash screen

    Friend CurrentUser As String

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogin.Click
        Login()
    End Sub

    Private Sub Usernam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxUser.GotFocus
        'AcceptButton = ButtonLogin
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        FormStudentReg.Show()
    End Sub

    Private Sub Usernam_MouseClick(sender As System.Object, e As System.EventArgs) Handles TextBoxUser.MouseClick
        If TextBoxUser.Text = "Username" Then
            TextBoxUser.Clear()
            TextBoxUser.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Pwd_MouseClick(sender As System.Object, e As System.EventArgs) Handles TextBoxPassword.MouseClick
        If TextBoxPassword.Text = "Password" Then
            TextBoxPassword.Clear()
            TextBoxPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Pwd_Leave(sender As System.Object, e As System.EventArgs) Handles TextBoxPassword.Leave
        If TextBoxPassword.Text = "" Then
            TextBoxPassword.Text = "Password"
            TextBoxPassword.ForeColor = Color.Silver
            TextBoxPassword.PasswordChar = ""
        End If
    End Sub

    Private Sub Usernam_Leave(sender As System.Object, e As System.EventArgs) Handles TextBoxUser.Leave
        If TextBoxUser.Text = "" Then
            TextBoxUser.Text = "Username"
            TextBoxUser.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBoxPassword.PasswordChar = ""
        Else
            TextBoxPassword.PasswordChar = "•"
        End If
    End Sub

    Private Sub FormLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer2.Start()
        TextBoxPassword.PasswordChar = ""
        TextBoxUser.SelectionStart = 0
        'Me.ActiveControl = AcceptButton
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

        ' Nice Animation effect

        Dim opacityFade As Single
        Me.Opacity += 0.03
        If Me.Opacity = 100 Then
            Timer2.Stop()
        End If

        For opacityFade = 0 To 1 Step 0.01
            Me.Opacity = opacityFade
            Me.Refresh()
            System.Threading.Thread.Sleep(10)
        Next opacityFade

        Me.Opacity = 1
        Timer2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonExit.Click
        Application.Exit()
    End Sub

    Private Sub Pwd_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBoxPassword.TextChanged
        TextBoxPassword.PasswordChar = "•"
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        ' Demonstrates external linking, assuming the internet is connected and site is up

        Dim ICSReg As String = "https://ics.ukzn.ac.za/wp-content/uploads/2018/01/ICSUserReg-1.pdf"
        Process.Start(ICSReg)
    End Sub

    Private Sub Usernam_Enter(sender As System.Object, e As System.EventArgs) Handles TextBoxUser.Enter

        If TextBoxUser.Text = "Username" Then
            TextBoxUser.Text = ""
            TextBoxUser.ForeColor = Color.Black
        End If

    End Sub

    Private Sub Pwd_Enter(sender As System.Object, e As System.EventArgs) Handles TextBoxPassword.Enter

        If TextBoxPassword.Text = "Password" Then
            TextBoxPassword.Text = ""
            TextBoxPassword.ForeColor = Color.Black
        End If

    End Sub

    Private Sub Login()

        ' Login Functionality with user type and access control based on that designation

        Try
            DBQuery = "SELECT * FROM Admin WHERE Username = '" & TextBoxUser.Text & "' AND passWd = '" & TextBoxPassword.Text & "'"
            DBLinker()
            DBCmd = New OleDbCommand(DBQuery, DBLink)
            DBRead = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DBRead.Read = True Then

                If DBRead("role") = "SuperAdmin" Then
                    FormMain.Show()
                    CurrentUser = DBRead("role")
                    FormMain.ToolStripStatusLabel1.Text = "ICS Tech Store - Logged In: " & CurrentUser
                    TextBoxUser.Text = ""
                    TextBoxPassword.Text = ""
                    Me.Refresh()
                ElseIf DBRead("role") = "Admin" Then
                    FormMain.Show()
                    FormMain.ToolStripButton3.Visible = False
                    FormMain.ToolStripButton4.Visible = False
                    FormMain.ToolStripButton6.Visible = False
                    FormMain.ToolStripMenuItem2.Enabled = False
                    FormMain.ToolStripMenuItem3.Enabled = False
                    FormMain.AddNewProductsToolStripMenuItem.Enabled = False
                    FormMain.StocksInToolStripMenuItem.Enabled = False
                    CurrentUser = DBRead("role")
                    FormMain.ToolStripStatusLabel1.Text = "ICS Tech Store - Logged In: " & CurrentUser
                    TextBoxUser.Text = ""
                    TextBoxPassword.Text = ""
                    Me.Refresh()
                End If

            Else
                MsgBox("Username or Password not valid!", MsgBoxStyle.Critical, "Login")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DBCmd.Dispose()
            DBLink.Close()
        End Try
    End Sub

End Class