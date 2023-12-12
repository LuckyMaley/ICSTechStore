<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonStock = New System.Windows.Forms.Button()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBumpUp = New System.Windows.Forms.TextBox()
        Me.TextQuant = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextPrice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextSize = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextProdCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextProdNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonStock
        '
        Me.ButtonStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ButtonStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStock.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStock.ForeColor = System.Drawing.Color.White
        Me.ButtonStock.Location = New System.Drawing.Point(170, 382)
        Me.ButtonStock.Name = "ButtonStock"
        Me.ButtonStock.Size = New System.Drawing.Size(117, 37)
        Me.ButtonStock.TabIndex = 6
        Me.ButtonStock.Text = "Stock In"
        Me.ButtonStock.UseVisualStyleBackColor = False
        '
        'ButtonSearch
        '
        Me.ButtonSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ButtonSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearch.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSearch.ForeColor = System.Drawing.Color.White
        Me.ButtonSearch.Location = New System.Drawing.Point(12, 382)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(117, 37)
        Me.ButtonSearch.TabIndex = 2
        Me.ButtonSearch.Text = "Search Inventory"
        Me.ButtonSearch.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBumpUp)
        Me.GroupBox1.Controls.Add(Me.TextQuant)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextPrice)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextSize)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextProdCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextProdNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product Information"
        '
        'TextDesc
        '
        Me.TextDesc.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDesc.Location = New System.Drawing.Point(89, 86)
        Me.TextDesc.Name = "TextDesc"
        Me.TextDesc.Size = New System.Drawing.Size(151, 25)
        Me.TextDesc.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Description :"
        '
        'TextBumpUp
        '
        Me.TextBumpUp.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextBumpUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBumpUp.Location = New System.Drawing.Point(89, 223)
        Me.TextBumpUp.Name = "TextBumpUp"
        Me.TextBumpUp.Size = New System.Drawing.Size(151, 25)
        Me.TextBumpUp.TabIndex = 6
        Me.TextBumpUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextQuant
        '
        Me.TextQuant.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextQuant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextQuant.Location = New System.Drawing.Point(89, 148)
        Me.TextQuant.Name = "TextQuant"
        Me.TextQuant.Size = New System.Drawing.Size(151, 25)
        Me.TextQuant.TabIndex = 4
        Me.TextQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Bump Level :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Quantity :"
        '
        'TextPrice
        '
        Me.TextPrice.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPrice.Location = New System.Drawing.Point(90, 186)
        Me.TextPrice.Name = "TextPrice"
        Me.TextPrice.Size = New System.Drawing.Size(151, 25)
        Me.TextPrice.TabIndex = 5
        Me.TextPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Unit Price :"
        '
        'TextSize
        '
        Me.TextSize.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSize.Location = New System.Drawing.Point(89, 117)
        Me.TextSize.Name = "TextSize"
        Me.TextSize.Size = New System.Drawing.Size(151, 25)
        Me.TextSize.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Size :"
        '
        'TextProdCode
        '
        Me.TextProdCode.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextProdCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProdCode.Location = New System.Drawing.Point(89, 53)
        Me.TextProdCode.Name = "TextProdCode"
        Me.TextProdCode.Size = New System.Drawing.Size(151, 25)
        Me.TextProdCode.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Code :"
        '
        'TextProdNo
        '
        Me.TextProdNo.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextProdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProdNo.Location = New System.Drawing.Point(89, 22)
        Me.TextProdNo.Name = "TextProdNo"
        Me.TextProdNo.Size = New System.Drawing.Size(151, 25)
        Me.TextProdNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item No :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(275, 63)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(42, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add New Products"
        '
        'FormInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(299, 433)
        Me.Controls.Add(Me.ButtonStock)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FormInventory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBumpUp As System.Windows.Forms.TextBox
    Friend WithEvents TextQuant As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextSize As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextProdCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextProdNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonStock As System.Windows.Forms.Button
End Class
