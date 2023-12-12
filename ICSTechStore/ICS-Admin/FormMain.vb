Public Class FormMain

    ' Students: 217071140, 217079204

    ' Welcome to our ISTN2IP Group Project (ICS Tech Store)
    ' The project is a model example for a real-world scenario based in UKZN, see Documentation for more info
    ' This project incorporates all concepts covered in the course and beyond
    ' A database is used locally.
    ' Admin Login with access control, Create Sales, Read Inventory/Generate Reports, Update Inventory/Registered Students, Delete Inventory Items
    ' Contains custom interface with common form elements, input validation, many custom sub procedures and functions

    ' The ICS-Admin Folder contains all the forms for the system
    ' The Modules Folder contains the important backend for the Database and Email feature

    ' There are two admin-levels, the 'super' admin, who has access to all the features
    ' Username = admin1
    ' Password = admin1

    ' The 'normal' admin, has access to limited features
    ' Username = admin2
    ' Password = admin2
    '

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel2.Spring = True
        FormLogin.Hide()
    End Sub

    Private Sub SaleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaleToolStripMenuItem.Click, ToolStripButton1.Click
        FormSale.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripButton3.Click
        FormStudentReg.ShowDialog()
    End Sub

    Private Sub Quit_Click(sender As System.Object, e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AddNewProductsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewProductsToolStripMenuItem.Click, ToolStripButton6.Click
        FormInventory.ShowDialog()
    End Sub

    Private Sub AvailableStocksToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AvailableStocksToolStripMenuItem.Click
        FormAvailStock.ShowDialog()
    End Sub

    Private Sub InventoryAddProd_Click(sender As System.Object, e As System.EventArgs) Handles StocksInToolStripMenuItem.Click
        FormReportAddedProd.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click, ToolStripButton2.Click
        FormProdSold.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click, ToolStripButton4.Click
        FormMailLog.ShowDialog()
    End Sub

    Private Sub ViewDevicesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewDevicesToolStripMenuItem.Click, ToolStripButton5.Click
        FormLaptops.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.ShowDialog()
    End Sub

End Class




