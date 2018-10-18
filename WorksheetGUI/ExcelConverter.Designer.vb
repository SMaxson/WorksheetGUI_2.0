<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcelConverter
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
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.ExtraAccuracyCheckBox = New System.Windows.Forms.CheckBox()
		Me.saveWorksheetDialog = New System.Windows.Forms.SaveFileDialog()
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(72, 29)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(132, 23)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Load Excel Document"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(96, 118)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 23)
		Me.Button2.TabIndex = 1
		Me.Button2.Text = "Convert!"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		Me.OpenFileDialog1.Filter = "Excel Workbooks|*.xls*|All files|*.*"
		'
		'ExtraAccuracyCheckBox
		'
		Me.ExtraAccuracyCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ExtraAccuracyCheckBox.Location = New System.Drawing.Point(72, 58)
		Me.ExtraAccuracyCheckBox.Name = "ExtraAccuracyCheckBox"
		Me.ExtraAccuracyCheckBox.Size = New System.Drawing.Size(158, 54)
		Me.ExtraAccuracyCheckBox.TabIndex = 2
		Me.ExtraAccuracyCheckBox.Text = "Extra Accuracy (Uses more styles, so it may be harder to edit the code later on)"
		Me.ExtraAccuracyCheckBox.UseVisualStyleBackColor = True
		'
		'saveWorksheetDialog
		'
		Me.saveWorksheetDialog.Filter = "xslt files (*.xslt)|*.xslt|All files (*.*)|*.*"""
		Me.saveWorksheetDialog.Title = "Choose a Shell File name and Directory"
		'
		'ExcelConverter
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(285, 153)
		Me.Controls.Add(Me.ExtraAccuracyCheckBox)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Name = "ExcelConverter"
		Me.ShowIcon = False
		Me.Text = "ExcelConverter"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents ExtraAccuracyCheckBox As CheckBox
	Friend WithEvents saveWorksheetDialog As SaveFileDialog
End Class
