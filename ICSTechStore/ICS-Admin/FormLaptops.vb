Public Class FormLaptops

    Private Sub ListBoxDevice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBoxDevice.SelectedIndexChanged
        If ListBoxDevice.SelectedIndex = 0 Then
            TextBox1.Text = "High-End Laptop suitable for the most resource-intensive tasks. Features an Intel i7 Processor with speeds up to 3 Ghz, 8 GB RAM and a 1 TB HDD." & Environment.NewLine & Environment.NewLine & "Windows 10 and Office 365 Pre-installed" & Environment.NewLine & "Free technical support from ICS Help Desk"
            PictureBox1.Image = My.Resources.Dell
        ElseIf ListBoxDevice.SelectedIndex = 1 Then
            TextBox1.Text = "Mid-Range Laptop suitable for everyday use. Features an Intel i5 Processor with speeds up to 2.5 Ghz, 4 GB RAM and a 500 GB HDD." & Environment.NewLine & Environment.NewLine & "Windows 10 and Office 365 Pre-installed" & Environment.NewLine & "Free technical support from ICS Help Desk"
            PictureBox1.Image = My.Resources.HP
        ElseIf ListBoxDevice.SelectedIndex = 2 Then
            TextBox1.Text = "Entry-Level Laptop suitable for lightweight duties. Features an Intel Celeron Processor with speeds up to 1.6 Ghz, 2 GB RAM and a 500 GB HDD." & Environment.NewLine & Environment.NewLine & "Windows 10 and Office 365 Pre-installed" & Environment.NewLine & "Free technical support from ICS Help Desk"
            PictureBox1.Image = My.Resources.Lenovo
        ElseIf ListBoxDevice.SelectedIndex = 3 Then
            TextBox1.Text = "Portable device suitable for mobile computing. Processor with speeds up to 1.5 Ghz, 1 GB RAM and 8 GB Internal Storage." & Environment.NewLine & Environment.NewLine & "Device only. No Sim/Data Card Included. Latest Android OS installed" & Environment.NewLine & "Free technical support from ICS Help Desk"
            PictureBox1.Image = My.Resources.Tab
        End If
    End Sub

    Private Sub Devices_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        TextBox1.Clear()
        PictureBox1.Image = Nothing
        ListBoxDevice.SelectedIndex = -1
    End Sub

End Class