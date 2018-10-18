<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KnowledgeBase
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
		Me.TopicsMenu = New System.Windows.Forms.TreeView()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TopicsMenu
		'
		Me.TopicsMenu.BackColor = System.Drawing.SystemColors.Window
		Me.TopicsMenu.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TopicsMenu.Location = New System.Drawing.Point(0, 0)
		Me.TopicsMenu.Name = "TopicsMenu"
		Me.TopicsMenu.Size = New System.Drawing.Size(175, 767)
		Me.TopicsMenu.TabIndex = 0
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.TopicsMenu)
		Me.SplitContainer1.Size = New System.Drawing.Size(854, 767)
		Me.SplitContainer1.SplitterDistance = 175
		Me.SplitContainer1.TabIndex = 1
		'
		'KnowledgeBase
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(854, 767)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Name = "KnowledgeBase"
		Me.ShowIcon = False
		Me.Text = "Knowing is half the battle!"
		Me.TopMost = True
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents TopicsMenu As TreeView
	Friend WithEvents SplitContainer1 As SplitContainer
End Class
