<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagCreator
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
		Me.SearchBox = New System.Windows.Forms.TextBox()
		Me.TagPreviewTextBox = New System.Windows.Forms.TextBox()
		Me.TagTextBox = New System.Windows.Forms.TextBox()
		Me.ResultList = New System.Windows.Forms.ListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'SearchBox
		'
		Me.SearchBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SearchBox.Location = New System.Drawing.Point(3, 3)
		Me.SearchBox.Name = "SearchBox"
		Me.SearchBox.Size = New System.Drawing.Size(218, 23)
		Me.SearchBox.TabIndex = 0
		'
		'TagPreviewTextBox
		'
		Me.TagPreviewTextBox.Enabled = False
		Me.TagPreviewTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TagPreviewTextBox.ForeColor = System.Drawing.Color.MidnightBlue
		Me.TagPreviewTextBox.Location = New System.Drawing.Point(3, 61)
		Me.TagPreviewTextBox.Name = "TagPreviewTextBox"
		Me.TagPreviewTextBox.Size = New System.Drawing.Size(218, 23)
		Me.TagPreviewTextBox.TabIndex = 1
		Me.TagPreviewTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'TagTextBox
		'
		Me.TagTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TagTextBox.ForeColor = System.Drawing.Color.DarkBlue
		Me.TagTextBox.Location = New System.Drawing.Point(3, 32)
		Me.TagTextBox.Name = "TagTextBox"
		Me.TagTextBox.Size = New System.Drawing.Size(218, 23)
		Me.TagTextBox.TabIndex = 2
		'
		'ResultList
		'
		Me.ResultList.BackColor = System.Drawing.SystemColors.ControlDark
		Me.ResultList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ResultList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ResultList.FormattingEnabled = True
		Me.ResultList.ItemHeight = 15
		Me.ResultList.Location = New System.Drawing.Point(3, 116)
		Me.ResultList.Name = "ResultList"
		Me.ResultList.Size = New System.Drawing.Size(218, 334)
		Me.ResultList.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(3, 100)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(45, 13)
		Me.Label1.TabIndex = 4
		Me.Label1.Text = "Results:"
		'
		'TagCreator
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ResultList)
		Me.Controls.Add(Me.TagTextBox)
		Me.Controls.Add(Me.TagPreviewTextBox)
		Me.Controls.Add(Me.SearchBox)
		Me.Name = "TagCreator"
		Me.Size = New System.Drawing.Size(224, 453)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents SearchBox As TextBox
	Friend WithEvents TagPreviewTextBox As TextBox
	Friend WithEvents TagTextBox As TextBox
	Friend WithEvents ResultList As ListBox
	Friend WithEvents Label1 As Label
End Class
