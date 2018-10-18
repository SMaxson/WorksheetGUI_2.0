<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DealPackInserter
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
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
		Me.components = New System.ComponentModel.Container()
		Me.DealPackFilesList = New System.Windows.Forms.ListBox()
		Me.DealPackFileListContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.DealPackFilesRemoveAll = New System.Windows.Forms.ToolStripMenuItem()
		Me.FileSelectBox = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ConfirmButton = New System.Windows.Forms.Button()
		Me.CancelButton = New System.Windows.Forms.Button()
		Me.DealPackFileListContextMenu.SuspendLayout()
		Me.SuspendLayout()
		'
		'DealPackFilesList
		'
		Me.DealPackFilesList.ContextMenuStrip = Me.DealPackFileListContextMenu
		Me.DealPackFilesList.FormattingEnabled = True
		Me.DealPackFilesList.Location = New System.Drawing.Point(3, 88)
		Me.DealPackFilesList.Name = "DealPackFilesList"
		Me.DealPackFilesList.Size = New System.Drawing.Size(543, 355)
		Me.DealPackFilesList.TabIndex = 0
		'
		'DealPackFileListContextMenu
		'
		Me.DealPackFileListContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.DealPackFilesRemoveAll})
		Me.DealPackFileListContextMenu.Name = "ContextMenuStrip1"
		Me.DealPackFileListContextMenu.ShowImageMargin = False
		Me.DealPackFileListContextMenu.Size = New System.Drawing.Size(194, 48)
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(193, 22)
		Me.ToolStripMenuItem1.Text = "Remove Selected Deal Pack"
		'
		'DealPackFilesRemoveAll
		'
		Me.DealPackFilesRemoveAll.Name = "DealPackFilesRemoveAll"
		Me.DealPackFilesRemoveAll.Size = New System.Drawing.Size(193, 22)
		Me.DealPackFilesRemoveAll.Text = "Remove All"
		'
		'FileSelectBox
		'
		Me.FileSelectBox.Location = New System.Drawing.Point(3, 33)
		Me.FileSelectBox.Name = "FileSelectBox"
		Me.FileSelectBox.Size = New System.Drawing.Size(543, 20)
		Me.FileSelectBox.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(3, 14)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(50, 16)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Insert:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(3, 69)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(37, 16)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "Into:"
		'
		'ConfirmButton
		'
		Me.ConfirmButton.Location = New System.Drawing.Point(409, 449)
		Me.ConfirmButton.Name = "ConfirmButton"
		Me.ConfirmButton.Size = New System.Drawing.Size(137, 29)
		Me.ConfirmButton.TabIndex = 4
		Me.ConfirmButton.Text = "NIKE (Just Do It)"
		Me.ConfirmButton.UseVisualStyleBackColor = True
		'
		'CancelButton
		'
		Me.CancelButton.Location = New System.Drawing.Point(266, 449)
		Me.CancelButton.Name = "CancelButton"
		Me.CancelButton.Size = New System.Drawing.Size(137, 29)
		Me.CancelButton.TabIndex = 5
		Me.CancelButton.Text = "Clear"
		Me.CancelButton.UseVisualStyleBackColor = True
		'
		'DealPackInserter
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.CancelButton)
		Me.Controls.Add(Me.ConfirmButton)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.FileSelectBox)
		Me.Controls.Add(Me.DealPackFilesList)
		Me.Name = "DealPackInserter"
		Me.Size = New System.Drawing.Size(549, 486)
		Me.DealPackFileListContextMenu.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents DealPackFilesList As ListBox
	Friend WithEvents FileSelectBox As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents ConfirmButton As Button
	Friend WithEvents CancelButton As Button
	Friend WithEvents DealPackFileListContextMenu As ContextMenuStrip
	Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
	Friend WithEvents DealPackFilesRemoveAll As ToolStripMenuItem
End Class
