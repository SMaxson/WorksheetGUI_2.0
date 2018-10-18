<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dealPackDialog
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.confirmButton = New System.Windows.Forms.Button()
		Me.cancelButton1 = New System.Windows.Forms.Button()
		Me.CheckBox1 = New System.Windows.Forms.CheckBox()
		Me.createDealPackDialog = New System.Windows.Forms.SaveFileDialog()
		Me.tradePanel = New System.Windows.Forms.Panel()
		Me.tradeBox1 = New System.Windows.Forms.CheckBox()
		Me.usedPanel = New System.Windows.Forms.Panel()
		Me.usedBox1 = New System.Windows.Forms.CheckBox()
		Me.newPanel = New System.Windows.Forms.Panel()
		Me.newBox1 = New System.Windows.Forms.CheckBox()
		Me.appSchemaPanel = New System.Windows.Forms.Panel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.newLabel1 = New System.Windows.Forms.Label()
		Me.usedLabel1 = New System.Windows.Forms.Label()
		Me.tradeLabel1 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.number1 = New System.Windows.Forms.Label()
		Me.deleteButton1 = New System.Windows.Forms.Button()
		Me.MainFrame = New System.Windows.Forms.Panel()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.coBuyerPanel = New System.Windows.Forms.Panel()
		Me.coBuyerBox1 = New System.Windows.Forms.CheckBox()
		Me.coBuyerLabel1 = New System.Windows.Forms.Label()
		Me.tradePanel.SuspendLayout()
		Me.usedPanel.SuspendLayout()
		Me.newPanel.SuspendLayout()
		Me.appSchemaPanel.SuspendLayout()
		Me.MainFrame.SuspendLayout()
		Me.coBuyerPanel.SuspendLayout()
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
		Me.TextBox1.Location = New System.Drawing.Point(252, 66)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.Size = New System.Drawing.Size(314, 20)
		Me.TextBox1.TabIndex = 0
		Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(235, 36)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(331, 27)
		Me.Label1.TabIndex = 10
		Me.Label1.Text = "Choose the body files for your deal pack."
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'confirmButton
		'
		Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.confirmButton.Location = New System.Drawing.Point(539, 527)
		Me.confirmButton.Name = "confirmButton"
		Me.confirmButton.Size = New System.Drawing.Size(75, 23)
		Me.confirmButton.TabIndex = 15
		Me.confirmButton.Text = "Create!"
		Me.confirmButton.UseVisualStyleBackColor = True
		'
		'cancelButton1
		'
		Me.cancelButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cancelButton1.Location = New System.Drawing.Point(620, 527)
		Me.cancelButton1.Name = "cancelButton1"
		Me.cancelButton1.Size = New System.Drawing.Size(75, 23)
		Me.cancelButton1.TabIndex = 16
		Me.cancelButton1.Text = "Cancel"
		Me.cancelButton1.UseVisualStyleBackColor = True
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = True
		Me.CheckBox1.BackColor = System.Drawing.Color.Firebrick
		Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.CheckBox1.Location = New System.Drawing.Point(17, 6)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
		Me.CheckBox1.TabIndex = 18
		Me.CheckBox1.UseVisualStyleBackColor = False
		'
		'createDealPackDialog
		'
		Me.createDealPackDialog.DefaultExt = "xslt"
		Me.createDealPackDialog.Filter = "xslt files (*.xslt)|*.xslt|All files (*.*)|*.*"
		Me.createDealPackDialog.Title = "Choose a Shell File name and Directory"
		'
		'tradePanel
		'
		Me.tradePanel.BackColor = System.Drawing.Color.Gold
		Me.tradePanel.Controls.Add(Me.tradeBox1)
		Me.tradePanel.Location = New System.Drawing.Point(88, 66)
		Me.tradePanel.Name = "tradePanel"
		Me.tradePanel.Size = New System.Drawing.Size(40, 29)
		Me.tradePanel.TabIndex = 39
		'
		'tradeBox1
		'
		Me.tradeBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.tradeBox1.AutoSize = True
		Me.tradeBox1.Location = New System.Drawing.Point(14, 6)
		Me.tradeBox1.Name = "tradeBox1"
		Me.tradeBox1.Size = New System.Drawing.Size(15, 14)
		Me.tradeBox1.TabIndex = 69
		Me.tradeBox1.UseVisualStyleBackColor = True
		'
		'usedPanel
		'
		Me.usedPanel.BackColor = System.Drawing.Color.MediumTurquoise
		Me.usedPanel.Controls.Add(Me.usedBox1)
		Me.usedPanel.Location = New System.Drawing.Point(50, 66)
		Me.usedPanel.Name = "usedPanel"
		Me.usedPanel.Size = New System.Drawing.Size(34, 29)
		Me.usedPanel.TabIndex = 38
		'
		'usedBox1
		'
		Me.usedBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.usedBox1.AutoSize = True
		Me.usedBox1.Location = New System.Drawing.Point(10, 6)
		Me.usedBox1.Name = "usedBox1"
		Me.usedBox1.Size = New System.Drawing.Size(15, 14)
		Me.usedBox1.TabIndex = 69
		Me.usedBox1.UseVisualStyleBackColor = True
		'
		'newPanel
		'
		Me.newPanel.BackColor = System.Drawing.Color.PaleGreen
		Me.newPanel.Controls.Add(Me.newBox1)
		Me.newPanel.Location = New System.Drawing.Point(13, 66)
		Me.newPanel.Name = "newPanel"
		Me.newPanel.Size = New System.Drawing.Size(33, 29)
		Me.newPanel.TabIndex = 37
		'
		'newBox1
		'
		Me.newBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.newBox1.AutoSize = True
		Me.newBox1.Location = New System.Drawing.Point(9, 6)
		Me.newBox1.Name = "newBox1"
		Me.newBox1.Size = New System.Drawing.Size(15, 14)
		Me.newBox1.TabIndex = 37
		Me.newBox1.UseVisualStyleBackColor = True
		'
		'appSchemaPanel
		'
		Me.appSchemaPanel.BackColor = System.Drawing.Color.Firebrick
		Me.appSchemaPanel.Controls.Add(Me.CheckBox1)
		Me.appSchemaPanel.Location = New System.Drawing.Point(131, 66)
		Me.appSchemaPanel.Name = "appSchemaPanel"
		Me.appSchemaPanel.Size = New System.Drawing.Size(49, 29)
		Me.appSchemaPanel.TabIndex = 40
		'
		'Label2
		'
		Me.Label2.BackColor = System.Drawing.Color.PaleGreen
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(13, 26)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(33, 37)
		Me.Label2.TabIndex = 41
		Me.Label2.Text = "New Only"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label3
		'
		Me.Label3.BackColor = System.Drawing.Color.MediumTurquoise
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(50, 26)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(34, 37)
		Me.Label3.TabIndex = 42
		Me.Label3.Text = "Used Only"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label4
		'
		Me.Label4.BackColor = System.Drawing.Color.Gold
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(88, 26)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(40, 37)
		Me.Label4.TabIndex = 43
		Me.Label4.Text = "Trade Only"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label5
		'
		Me.Label5.BackColor = System.Drawing.Color.Firebrick
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.Label5.Location = New System.Drawing.Point(131, 26)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(49, 37)
		Me.Label5.TabIndex = 44
		Me.Label5.Text = "App Schema"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'newLabel1
		'
		Me.newLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.newLabel1.ForeColor = System.Drawing.Color.MediumSeaGreen
		Me.newLabel1.Location = New System.Drawing.Point(605, 66)
		Me.newLabel1.Name = "newLabel1"
		Me.newLabel1.Size = New System.Drawing.Size(21, 19)
		Me.newLabel1.TabIndex = 45
		Me.newLabel1.Text = "N"
		Me.newLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.newLabel1.Visible = False
		'
		'usedLabel1
		'
		Me.usedLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.usedLabel1.ForeColor = System.Drawing.Color.DodgerBlue
		Me.usedLabel1.Location = New System.Drawing.Point(623, 66)
		Me.usedLabel1.Name = "usedLabel1"
		Me.usedLabel1.Size = New System.Drawing.Size(21, 20)
		Me.usedLabel1.TabIndex = 61
		Me.usedLabel1.Text = "U"
		Me.usedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.usedLabel1.Visible = False
		'
		'tradeLabel1
		'
		Me.tradeLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tradeLabel1.ForeColor = System.Drawing.Color.DarkKhaki
		Me.tradeLabel1.Location = New System.Drawing.Point(640, 66)
		Me.tradeLabel1.Name = "tradeLabel1"
		Me.tradeLabel1.Size = New System.Drawing.Size(21, 20)
		Me.tradeLabel1.TabIndex = 78
		Me.tradeLabel1.Text = "T"
		Me.tradeLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tradeLabel1.Visible = False
		'
		'Button1
		'
		Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button1.Location = New System.Drawing.Point(12, 527)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(33, 23)
		Me.Button1.TabIndex = 94
		Me.Button1.Text = "+"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'number1
		'
		Me.number1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.number1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.number1.Location = New System.Drawing.Point(225, 68)
		Me.number1.Name = "number1"
		Me.number1.Size = New System.Drawing.Size(23, 19)
		Me.number1.TabIndex = 98
		Me.number1.Text = "1"
		Me.number1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'deleteButton1
		'
		Me.deleteButton1.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.deleteButton1.Location = New System.Drawing.Point(571, 66)
		Me.deleteButton1.Name = "deleteButton1"
		Me.deleteButton1.Size = New System.Drawing.Size(28, 20)
		Me.deleteButton1.TabIndex = 112
		Me.deleteButton1.Text = "Del"
		Me.deleteButton1.UseVisualStyleBackColor = True
		'
		'MainFrame
		'
		Me.MainFrame.AutoScroll = True
		Me.MainFrame.Controls.Add(Me.coBuyerLabel1)
		Me.MainFrame.Controls.Add(Me.Label20)
		Me.MainFrame.Controls.Add(Me.coBuyerPanel)
		Me.MainFrame.Controls.Add(Me.deleteButton1)
		Me.MainFrame.Controls.Add(Me.number1)
		Me.MainFrame.Controls.Add(Me.tradeLabel1)
		Me.MainFrame.Controls.Add(Me.usedLabel1)
		Me.MainFrame.Controls.Add(Me.newLabel1)
		Me.MainFrame.Controls.Add(Me.Label5)
		Me.MainFrame.Controls.Add(Me.Label4)
		Me.MainFrame.Controls.Add(Me.Label3)
		Me.MainFrame.Controls.Add(Me.Label2)
		Me.MainFrame.Controls.Add(Me.Label1)
		Me.MainFrame.Controls.Add(Me.TextBox1)
		Me.MainFrame.Controls.Add(Me.appSchemaPanel)
		Me.MainFrame.Controls.Add(Me.tradePanel)
		Me.MainFrame.Controls.Add(Me.usedPanel)
		Me.MainFrame.Controls.Add(Me.newPanel)
		Me.MainFrame.Dock = System.Windows.Forms.DockStyle.Top
		Me.MainFrame.Location = New System.Drawing.Point(0, 0)
		Me.MainFrame.Name = "MainFrame"
		Me.MainFrame.Size = New System.Drawing.Size(707, 511)
		Me.MainFrame.TabIndex = 128
		'
		'Label20
		'
		Me.Label20.BackColor = System.Drawing.Color.MediumPurple
		Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.Label20.Location = New System.Drawing.Point(184, 26)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(43, 37)
		Me.Label20.TabIndex = 129
		Me.Label20.Text = "CoBuyer Only"
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'coBuyerPanel
		'
		Me.coBuyerPanel.BackColor = System.Drawing.Color.MediumPurple
		Me.coBuyerPanel.Controls.Add(Me.coBuyerBox1)
		Me.coBuyerPanel.Location = New System.Drawing.Point(184, 66)
		Me.coBuyerPanel.Name = "coBuyerPanel"
		Me.coBuyerPanel.Size = New System.Drawing.Size(43, 29)
		Me.coBuyerPanel.TabIndex = 128
		'
		'coBuyerBox1
		'
		Me.coBuyerBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.coBuyerBox1.AutoSize = True
		Me.coBuyerBox1.Location = New System.Drawing.Point(15, 6)
		Me.coBuyerBox1.Name = "coBuyerBox1"
		Me.coBuyerBox1.Size = New System.Drawing.Size(15, 14)
		Me.coBuyerBox1.TabIndex = 37
		Me.coBuyerBox1.UseVisualStyleBackColor = True
		'
		'coBuyerLabel1
		'
		Me.coBuyerLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.coBuyerLabel1.ForeColor = System.Drawing.Color.DarkOrchid
		Me.coBuyerLabel1.Location = New System.Drawing.Point(656, 66)
		Me.coBuyerLabel1.Name = "coBuyerLabel1"
		Me.coBuyerLabel1.Size = New System.Drawing.Size(21, 20)
		Me.coBuyerLabel1.TabIndex = 130
		Me.coBuyerLabel1.Text = "2"
		Me.coBuyerLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.coBuyerLabel1.Visible = False
		'
		'dealPackDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
		Me.ClientSize = New System.Drawing.Size(707, 562)
		Me.Controls.Add(Me.MainFrame)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.cancelButton1)
		Me.Controls.Add(Me.confirmButton)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dealPackDialog"
		Me.ShowIcon = False
		Me.Text = "Deal Pack Powers, Activate!"
		Me.tradePanel.ResumeLayout(False)
		Me.tradePanel.PerformLayout()
		Me.usedPanel.ResumeLayout(False)
		Me.usedPanel.PerformLayout()
		Me.newPanel.ResumeLayout(False)
		Me.newPanel.PerformLayout()
		Me.appSchemaPanel.ResumeLayout(False)
		Me.appSchemaPanel.PerformLayout()
		Me.MainFrame.ResumeLayout(False)
		Me.MainFrame.PerformLayout()
		Me.coBuyerPanel.ResumeLayout(False)
		Me.coBuyerPanel.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents confirmButton As Button
	Friend WithEvents cancelButton1 As Button
	Friend WithEvents CheckBox1 As CheckBox
	Friend WithEvents createDealPackDialog As SaveFileDialog
	Friend WithEvents tradePanel As Panel
	Friend WithEvents tradeBox1 As CheckBox
	Friend WithEvents usedPanel As Panel
	Friend WithEvents usedBox1 As CheckBox
	Friend WithEvents newPanel As Panel
	Friend WithEvents newBox1 As CheckBox
	Friend WithEvents appSchemaPanel As Panel
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents newLabel1 As Label
	Friend WithEvents usedLabel1 As Label
	Friend WithEvents tradeLabel1 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents number1 As Label
	Friend WithEvents deleteButton1 As Button
	Friend WithEvents MainFrame As Panel
	Friend WithEvents Label20 As Label
	Friend WithEvents coBuyerPanel As Panel
	Friend WithEvents coBuyerBox1 As CheckBox
	Friend WithEvents coBuyerLabel1 As Label
End Class
