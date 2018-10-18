<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBody
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
		Me.FileList = New System.Windows.Forms.ListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CancelSelectionButton = New System.Windows.Forms.Button()
		Me.ConfirmSelectionButton = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'FileList
		'
		Me.FileList.BackColor = System.Drawing.Color.White
		Me.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.FileList.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FileList.FormattingEnabled = True
		Me.FileList.ItemHeight = 21
		Me.FileList.Location = New System.Drawing.Point(12, 29)
		Me.FileList.Name = "FileList"
		Me.FileList.Size = New System.Drawing.Size(403, 296)
		Me.FileList.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(403, 17)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Select the desired form."
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'CancelSelectionButton
		'
		Me.CancelSelectionButton.Location = New System.Drawing.Point(335, 340)
		Me.CancelSelectionButton.Name = "CancelSelectionButton"
		Me.CancelSelectionButton.Size = New System.Drawing.Size(75, 23)
		Me.CancelSelectionButton.TabIndex = 2
		Me.CancelSelectionButton.Text = "Cancel"
		Me.CancelSelectionButton.UseVisualStyleBackColor = True
		'
		'ConfirmSelectionButton
		'
		Me.ConfirmSelectionButton.Location = New System.Drawing.Point(254, 340)
		Me.ConfirmSelectionButton.Name = "ConfirmSelectionButton"
		Me.ConfirmSelectionButton.Size = New System.Drawing.Size(75, 23)
		Me.ConfirmSelectionButton.TabIndex = 3
		Me.ConfirmSelectionButton.Text = "Confirm"
		Me.ConfirmSelectionButton.UseVisualStyleBackColor = True
		'
		'SelectBody
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(427, 380)
		Me.Controls.Add(Me.ConfirmSelectionButton)
		Me.Controls.Add(Me.CancelSelectionButton)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.FileList)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SelectBody"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Choose Form"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FileList As ListBox
	Friend WithEvents Label1 As Label
	Friend WithEvents CancelSelectionButton As Button
	Friend WithEvents ConfirmSelectionButton As Button
End Class
