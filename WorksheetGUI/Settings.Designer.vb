<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
		Me.settingsTabs = New System.Windows.Forms.TabControl()
		Me.debugPage = New System.Windows.Forms.TabPage()
		Me.surpressScriptErrorsCheckbox = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.autoRefreshCheckbox = New System.Windows.Forms.CheckBox()
		Me.refreshRateInput = New System.Windows.Forms.NumericUpDown()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.appearancePage = New System.Windows.Forms.TabPage()
		Me.codingBuddyReadAllCheck = New System.Windows.Forms.CheckBox()
		Me.codingBuddyFrame = New System.Windows.Forms.GroupBox()
		Me.PictureBox9 = New System.Windows.Forms.PictureBox()
		Me.RadioButton9 = New System.Windows.Forms.RadioButton()
		Me.PictureBox8 = New System.Windows.Forms.PictureBox()
		Me.RadioButton8 = New System.Windows.Forms.RadioButton()
		Me.PictureBox7 = New System.Windows.Forms.PictureBox()
		Me.RadioButton7 = New System.Windows.Forms.RadioButton()
		Me.PictureBox6 = New System.Windows.Forms.PictureBox()
		Me.RadioButton6 = New System.Windows.Forms.RadioButton()
		Me.PictureBox5 = New System.Windows.Forms.PictureBox()
		Me.RadioButton5 = New System.Windows.Forms.RadioButton()
		Me.PictureBox4 = New System.Windows.Forms.PictureBox()
		Me.RadioButton4 = New System.Windows.Forms.RadioButton()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.RadioButton3 = New System.Windows.Forms.RadioButton()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.RadioButton2 = New System.Windows.Forms.RadioButton()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.RadioButton1 = New System.Windows.Forms.RadioButton()
		Me.codingBuddyActiveCheck = New System.Windows.Forms.CheckBox()
		Me.AppearanceTab = New System.Windows.Forms.TabPage()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.backgroundImageDemo = New System.Windows.Forms.PictureBox()
		Me.backgroundColorDemo = New System.Windows.Forms.Panel()
		Me.backgroundImageRadioButton = New System.Windows.Forms.RadioButton()
		Me.backgroundColorRadioButton = New System.Windows.Forms.RadioButton()
		Me.colorSetList = New System.Windows.Forms.ComboBox()
		Me.colorSetLabel = New System.Windows.Forms.Label()
		Me.editorPage = New System.Windows.Forms.TabPage()
		Me.drawSelectedElementChildren = New System.Windows.Forms.CheckBox()
		Me.drawSelectedElement = New System.Windows.Forms.CheckBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.settingsCancelButton = New System.Windows.Forms.Button()
		Me.settingsAcceptButton = New System.Windows.Forms.Button()
		Me.settingsTabs.SuspendLayout()
		Me.debugPage.SuspendLayout()
		CType(Me.refreshRateInput, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.appearancePage.SuspendLayout()
		Me.codingBuddyFrame.SuspendLayout()
		CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.AppearanceTab.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.backgroundImageDemo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.editorPage.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'settingsTabs
		'
		Me.settingsTabs.Controls.Add(Me.debugPage)
		Me.settingsTabs.Controls.Add(Me.appearancePage)
		Me.settingsTabs.Controls.Add(Me.AppearanceTab)
		Me.settingsTabs.Controls.Add(Me.editorPage)
		Me.settingsTabs.Dock = System.Windows.Forms.DockStyle.Fill
		Me.settingsTabs.Location = New System.Drawing.Point(0, 0)
		Me.settingsTabs.Name = "settingsTabs"
		Me.settingsTabs.SelectedIndex = 0
		Me.settingsTabs.Size = New System.Drawing.Size(360, 580)
		Me.settingsTabs.TabIndex = 0
		'
		'debugPage
		'
		Me.debugPage.BackColor = System.Drawing.SystemColors.Control
		Me.debugPage.Controls.Add(Me.surpressScriptErrorsCheckbox)
		Me.debugPage.Controls.Add(Me.Label4)
		Me.debugPage.Controls.Add(Me.autoRefreshCheckbox)
		Me.debugPage.Controls.Add(Me.refreshRateInput)
		Me.debugPage.Controls.Add(Me.Label3)
		Me.debugPage.Controls.Add(Me.Label2)
		Me.debugPage.Controls.Add(Me.Label1)
		Me.debugPage.Location = New System.Drawing.Point(4, 22)
		Me.debugPage.Name = "debugPage"
		Me.debugPage.Padding = New System.Windows.Forms.Padding(3)
		Me.debugPage.Size = New System.Drawing.Size(352, 554)
		Me.debugPage.TabIndex = 0
		Me.debugPage.Text = "Debug"
		'
		'surpressScriptErrorsCheckbox
		'
		Me.surpressScriptErrorsCheckbox.AutoSize = True
		Me.surpressScriptErrorsCheckbox.Location = New System.Drawing.Point(128, 89)
		Me.surpressScriptErrorsCheckbox.Name = "surpressScriptErrorsCheckbox"
		Me.surpressScriptErrorsCheckbox.Size = New System.Drawing.Size(15, 14)
		Me.surpressScriptErrorsCheckbox.TabIndex = 6
		Me.surpressScriptErrorsCheckbox.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(17, 90)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(105, 13)
		Me.Label4.TabIndex = 5
		Me.Label4.Text = "Supress Script Errors"
		'
		'autoRefreshCheckbox
		'
		Me.autoRefreshCheckbox.AutoSize = True
		Me.autoRefreshCheckbox.Location = New System.Drawing.Point(105, 23)
		Me.autoRefreshCheckbox.Name = "autoRefreshCheckbox"
		Me.autoRefreshCheckbox.Size = New System.Drawing.Size(15, 14)
		Me.autoRefreshCheckbox.TabIndex = 4
		Me.autoRefreshCheckbox.UseVisualStyleBackColor = True
		'
		'refreshRateInput
		'
		Me.refreshRateInput.DecimalPlaces = 1
		Me.refreshRateInput.Location = New System.Drawing.Point(105, 55)
		Me.refreshRateInput.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
		Me.refreshRateInput.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.refreshRateInput.Name = "refreshRateInput"
		Me.refreshRateInput.Size = New System.Drawing.Size(120, 20)
		Me.refreshRateInput.TabIndex = 1
		Me.refreshRateInput.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(17, 24)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(69, 13)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "Auto Refresh"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(224, 57)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(47, 13)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "seconds"
		Me.Label2.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(16, 57)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(70, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Refresh Rate"
		'
		'appearancePage
		'
		Me.appearancePage.BackColor = System.Drawing.SystemColors.Control
		Me.appearancePage.Controls.Add(Me.codingBuddyReadAllCheck)
		Me.appearancePage.Controls.Add(Me.codingBuddyFrame)
		Me.appearancePage.Controls.Add(Me.codingBuddyActiveCheck)
		Me.appearancePage.Location = New System.Drawing.Point(4, 22)
		Me.appearancePage.Name = "appearancePage"
		Me.appearancePage.Padding = New System.Windows.Forms.Padding(3)
		Me.appearancePage.Size = New System.Drawing.Size(352, 554)
		Me.appearancePage.TabIndex = 1
		Me.appearancePage.Text = "Coding Buddy"
		'
		'codingBuddyReadAllCheck
		'
		Me.codingBuddyReadAllCheck.AutoSize = True
		Me.codingBuddyReadAllCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.codingBuddyReadAllCheck.Location = New System.Drawing.Point(22, 33)
		Me.codingBuddyReadAllCheck.Name = "codingBuddyReadAllCheck"
		Me.codingBuddyReadAllCheck.Size = New System.Drawing.Size(289, 16)
		Me.codingBuddyReadAllCheck.TabIndex = 5
		Me.codingBuddyReadAllCheck.Text = "Coding Buddy reads all error messages,  not just recognized ones"
		Me.codingBuddyReadAllCheck.UseMnemonic = False
		Me.codingBuddyReadAllCheck.UseVisualStyleBackColor = True
		'
		'codingBuddyFrame
		'
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox9)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton9)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox8)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton8)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox7)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton7)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox6)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton6)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox5)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton5)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox4)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton4)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox3)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton3)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox2)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton2)
		Me.codingBuddyFrame.Controls.Add(Me.PictureBox1)
		Me.codingBuddyFrame.Controls.Add(Me.RadioButton1)
		Me.codingBuddyFrame.Location = New System.Drawing.Point(8, 56)
		Me.codingBuddyFrame.Name = "codingBuddyFrame"
		Me.codingBuddyFrame.Size = New System.Drawing.Size(336, 463)
		Me.codingBuddyFrame.TabIndex = 4
		Me.codingBuddyFrame.TabStop = False
		Me.codingBuddyFrame.Text = "Coding Buddies"
		'
		'PictureBox9
		'
		Me.PictureBox9.Image = Global.WorksheetGUI.My.Resources.Resources.Sabreman_Blinking
		Me.PictureBox9.Location = New System.Drawing.Point(262, 391)
		Me.PictureBox9.Name = "PictureBox9"
		Me.PictureBox9.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox9.TabIndex = 18
		Me.PictureBox9.TabStop = False
		'
		'RadioButton9
		'
		Me.RadioButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton9.Location = New System.Drawing.Point(14, 391)
		Me.RadioButton9.Name = "RadioButton9"
		Me.RadioButton9.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton9.TabIndex = 17
		Me.RadioButton9.TabStop = True
		Me.RadioButton9.Text = "Sabreman (Quiet option)"
		Me.RadioButton9.UseVisualStyleBackColor = True
		'
		'PictureBox8
		'
		Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
		Me.PictureBox8.Location = New System.Drawing.Point(262, 345)
		Me.PictureBox8.Name = "PictureBox8"
		Me.PictureBox8.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox8.TabIndex = 16
		Me.PictureBox8.TabStop = False
		'
		'RadioButton8
		'
		Me.RadioButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton8.Location = New System.Drawing.Point(14, 345)
		Me.RadioButton8.Name = "RadioButton8"
		Me.RadioButton8.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton8.TabIndex = 15
		Me.RadioButton8.TabStop = True
		Me.RadioButton8.Text = "Navi"
		Me.RadioButton8.UseVisualStyleBackColor = True
		'
		'PictureBox7
		'
		Me.PictureBox7.Image = Global.WorksheetGUI.My.Resources.Resources.Peppy
		Me.PictureBox7.Location = New System.Drawing.Point(262, 299)
		Me.PictureBox7.Name = "PictureBox7"
		Me.PictureBox7.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox7.TabIndex = 14
		Me.PictureBox7.TabStop = False
		'
		'RadioButton7
		'
		Me.RadioButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton7.Location = New System.Drawing.Point(14, 299)
		Me.RadioButton7.Name = "RadioButton7"
		Me.RadioButton7.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton7.TabIndex = 13
		Me.RadioButton7.TabStop = True
		Me.RadioButton7.Text = "Peppy"
		Me.RadioButton7.UseVisualStyleBackColor = True
		'
		'PictureBox6
		'
		Me.PictureBox6.Image = Global.WorksheetGUI.My.Resources.Resources.Banjo_Blinking
		Me.PictureBox6.Location = New System.Drawing.Point(262, 253)
		Me.PictureBox6.Name = "PictureBox6"
		Me.PictureBox6.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox6.TabIndex = 12
		Me.PictureBox6.TabStop = False
		'
		'RadioButton6
		'
		Me.RadioButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton6.Location = New System.Drawing.Point(14, 253)
		Me.RadioButton6.Name = "RadioButton6"
		Me.RadioButton6.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton6.TabIndex = 11
		Me.RadioButton6.TabStop = True
		Me.RadioButton6.Text = "Banjo"
		Me.RadioButton6.UseVisualStyleBackColor = True
		'
		'PictureBox5
		'
		Me.PictureBox5.Image = Global.WorksheetGUI.My.Resources.Resources.Klungo_Blinking
		Me.PictureBox5.Location = New System.Drawing.Point(262, 203)
		Me.PictureBox5.Name = "PictureBox5"
		Me.PictureBox5.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox5.TabIndex = 10
		Me.PictureBox5.TabStop = False
		'
		'RadioButton5
		'
		Me.RadioButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton5.Location = New System.Drawing.Point(14, 203)
		Me.RadioButton5.Name = "RadioButton5"
		Me.RadioButton5.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton5.TabIndex = 9
		Me.RadioButton5.TabStop = True
		Me.RadioButton5.Text = "Klungo"
		Me.RadioButton5.UseVisualStyleBackColor = True
		'
		'PictureBox4
		'
		Me.PictureBox4.Image = Global.WorksheetGUI.My.Resources.Resources.Jamjars_Speaking
		Me.PictureBox4.Location = New System.Drawing.Point(262, 157)
		Me.PictureBox4.Name = "PictureBox4"
		Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox4.TabIndex = 8
		Me.PictureBox4.TabStop = False
		'
		'RadioButton4
		'
		Me.RadioButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton4.Location = New System.Drawing.Point(14, 157)
		Me.RadioButton4.Name = "RadioButton4"
		Me.RadioButton4.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton4.TabIndex = 7
		Me.RadioButton4.TabStop = True
		Me.RadioButton4.Text = "JamJars"
		Me.RadioButton4.UseVisualStyleBackColor = True
		'
		'PictureBox3
		'
		Me.PictureBox3.Image = Global.WorksheetGUI.My.Resources.Resources.Kazooie_Blinking
		Me.PictureBox3.Location = New System.Drawing.Point(262, 111)
		Me.PictureBox3.Name = "PictureBox3"
		Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox3.TabIndex = 6
		Me.PictureBox3.TabStop = False
		'
		'RadioButton3
		'
		Me.RadioButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton3.Location = New System.Drawing.Point(14, 111)
		Me.RadioButton3.Name = "RadioButton3"
		Me.RadioButton3.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton3.TabIndex = 5
		Me.RadioButton3.TabStop = True
		Me.RadioButton3.Text = "Kazooie"
		Me.RadioButton3.UseVisualStyleBackColor = True
		'
		'PictureBox2
		'
		Me.PictureBox2.Image = Global.WorksheetGUI.My.Resources.Resources.Bottles_Blinking
		Me.PictureBox2.Location = New System.Drawing.Point(262, 65)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox2.TabIndex = 4
		Me.PictureBox2.TabStop = False
		'
		'RadioButton2
		'
		Me.RadioButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton2.Location = New System.Drawing.Point(14, 65)
		Me.RadioButton2.Name = "RadioButton2"
		Me.RadioButton2.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton2.TabIndex = 3
		Me.RadioButton2.TabStop = True
		Me.RadioButton2.Text = "Bottles"
		Me.RadioButton2.UseVisualStyleBackColor = True
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.WorksheetGUI.My.Resources.Resources.Mumbo_Blinking
		Me.PictureBox1.InitialImage = Nothing
		Me.PictureBox1.Location = New System.Drawing.Point(262, 19)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox1.TabIndex = 2
		Me.PictureBox1.TabStop = False
		'
		'RadioButton1
		'
		Me.RadioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
		Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RadioButton1.Location = New System.Drawing.Point(14, 18)
		Me.RadioButton1.Name = "RadioButton1"
		Me.RadioButton1.Size = New System.Drawing.Size(132, 40)
		Me.RadioButton1.TabIndex = 1
		Me.RadioButton1.TabStop = True
		Me.RadioButton1.Text = "Mumbo Jumbo"
		Me.RadioButton1.UseVisualStyleBackColor = True
		'
		'codingBuddyActiveCheck
		'
		Me.codingBuddyActiveCheck.AutoSize = True
		Me.codingBuddyActiveCheck.Location = New System.Drawing.Point(22, 15)
		Me.codingBuddyActiveCheck.Name = "codingBuddyActiveCheck"
		Me.codingBuddyActiveCheck.Size = New System.Drawing.Size(114, 17)
		Me.codingBuddyActiveCheck.TabIndex = 3
		Me.codingBuddyActiveCheck.Text = "Use Coding Buddy"
		Me.codingBuddyActiveCheck.UseMnemonic = False
		Me.codingBuddyActiveCheck.UseVisualStyleBackColor = True
		'
		'AppearanceTab
		'
		Me.AppearanceTab.BackColor = System.Drawing.SystemColors.Control
		Me.AppearanceTab.Controls.Add(Me.GroupBox1)
		Me.AppearanceTab.Controls.Add(Me.colorSetList)
		Me.AppearanceTab.Controls.Add(Me.colorSetLabel)
		Me.AppearanceTab.Location = New System.Drawing.Point(4, 22)
		Me.AppearanceTab.Name = "AppearanceTab"
		Me.AppearanceTab.Padding = New System.Windows.Forms.Padding(3)
		Me.AppearanceTab.Size = New System.Drawing.Size(352, 554)
		Me.AppearanceTab.TabIndex = 2
		Me.AppearanceTab.Text = "Appearance"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.backgroundImageDemo)
		Me.GroupBox1.Controls.Add(Me.backgroundColorDemo)
		Me.GroupBox1.Controls.Add(Me.backgroundImageRadioButton)
		Me.GroupBox1.Controls.Add(Me.backgroundColorRadioButton)
		Me.GroupBox1.Location = New System.Drawing.Point(8, 7)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(336, 173)
		Me.GroupBox1.TabIndex = 2
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Window Background"
		'
		'backgroundImageDemo
		'
		Me.backgroundImageDemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.backgroundImageDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.backgroundImageDemo.Cursor = System.Windows.Forms.Cursors.Hand
		Me.backgroundImageDemo.Location = New System.Drawing.Point(130, 65)
		Me.backgroundImageDemo.Name = "backgroundImageDemo"
		Me.backgroundImageDemo.Size = New System.Drawing.Size(200, 100)
		Me.backgroundImageDemo.TabIndex = 3
		Me.backgroundImageDemo.TabStop = False
		'
		'backgroundColorDemo
		'
		Me.backgroundColorDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.backgroundColorDemo.Cursor = System.Windows.Forms.Cursors.Hand
		Me.backgroundColorDemo.Location = New System.Drawing.Point(130, 12)
		Me.backgroundColorDemo.Name = "backgroundColorDemo"
		Me.backgroundColorDemo.Size = New System.Drawing.Size(200, 47)
		Me.backgroundColorDemo.TabIndex = 2
		'
		'backgroundImageRadioButton
		'
		Me.backgroundImageRadioButton.AutoSize = True
		Me.backgroundImageRadioButton.Location = New System.Drawing.Point(34, 65)
		Me.backgroundImageRadioButton.Name = "backgroundImageRadioButton"
		Me.backgroundImageRadioButton.Size = New System.Drawing.Size(54, 17)
		Me.backgroundImageRadioButton.TabIndex = 1
		Me.backgroundImageRadioButton.TabStop = True
		Me.backgroundImageRadioButton.Text = "Image"
		Me.backgroundImageRadioButton.UseVisualStyleBackColor = True
		'
		'backgroundColorRadioButton
		'
		Me.backgroundColorRadioButton.AutoSize = True
		Me.backgroundColorRadioButton.Location = New System.Drawing.Point(34, 19)
		Me.backgroundColorRadioButton.Name = "backgroundColorRadioButton"
		Me.backgroundColorRadioButton.Size = New System.Drawing.Size(75, 17)
		Me.backgroundColorRadioButton.TabIndex = 0
		Me.backgroundColorRadioButton.TabStop = True
		Me.backgroundColorRadioButton.Text = "Solid Color"
		Me.backgroundColorRadioButton.UseVisualStyleBackColor = True
		'
		'colorSetList
		'
		Me.colorSetList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.colorSetList.FormattingEnabled = True
		Me.colorSetList.Items.AddRange(New Object() {"Default", "Electric"})
		Me.colorSetList.Location = New System.Drawing.Point(138, 198)
		Me.colorSetList.Name = "colorSetList"
		Me.colorSetList.Size = New System.Drawing.Size(121, 23)
		Me.colorSetList.TabIndex = 1
		Me.colorSetList.Text = "Default"
		'
		'colorSetLabel
		'
		Me.colorSetLabel.AutoSize = True
		Me.colorSetLabel.Location = New System.Drawing.Point(82, 202)
		Me.colorSetLabel.Name = "colorSetLabel"
		Me.colorSetLabel.Size = New System.Drawing.Size(53, 13)
		Me.colorSetLabel.TabIndex = 0
		Me.colorSetLabel.Text = "Color Set:"
		'
		'editorPage
		'
		Me.editorPage.BackColor = System.Drawing.SystemColors.Control
		Me.editorPage.Controls.Add(Me.drawSelectedElementChildren)
		Me.editorPage.Controls.Add(Me.drawSelectedElement)
		Me.editorPage.Location = New System.Drawing.Point(4, 22)
		Me.editorPage.Name = "editorPage"
		Me.editorPage.Padding = New System.Windows.Forms.Padding(3)
		Me.editorPage.Size = New System.Drawing.Size(352, 554)
		Me.editorPage.TabIndex = 3
		Me.editorPage.Text = "Editor"
		'
		'drawSelectedElementChildren
		'
		Me.drawSelectedElementChildren.AutoSize = True
		Me.drawSelectedElementChildren.Location = New System.Drawing.Point(22, 45)
		Me.drawSelectedElementChildren.Name = "drawSelectedElementChildren"
		Me.drawSelectedElementChildren.Size = New System.Drawing.Size(281, 17)
		Me.drawSelectedElementChildren.TabIndex = 1
		Me.drawSelectedElementChildren.Text = "Draw outline around selected element's child elements"
		Me.drawSelectedElementChildren.UseVisualStyleBackColor = True
		'
		'drawSelectedElement
		'
		Me.drawSelectedElement.AutoSize = True
		Me.drawSelectedElement.Location = New System.Drawing.Point(22, 22)
		Me.drawSelectedElement.Name = "drawSelectedElement"
		Me.drawSelectedElement.Size = New System.Drawing.Size(204, 17)
		Me.drawSelectedElement.TabIndex = 0
		Me.drawSelectedElement.Text = "Draw outline around selected element"
		Me.drawSelectedElement.UseVisualStyleBackColor = True
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.settingsCancelButton)
		Me.Panel1.Controls.Add(Me.settingsAcceptButton)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 542)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(360, 38)
		Me.Panel1.TabIndex = 1
		'
		'settingsCancelButton
		'
		Me.settingsCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.settingsCancelButton.Location = New System.Drawing.Point(197, 5)
		Me.settingsCancelButton.Name = "settingsCancelButton"
		Me.settingsCancelButton.Size = New System.Drawing.Size(75, 23)
		Me.settingsCancelButton.TabIndex = 1
		Me.settingsCancelButton.Text = "Cancel"
		Me.settingsCancelButton.UseVisualStyleBackColor = True
		Me.settingsCancelButton.Visible = False
		'
		'settingsAcceptButton
		'
		Me.settingsAcceptButton.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.settingsAcceptButton.Location = New System.Drawing.Point(278, 5)
		Me.settingsAcceptButton.Name = "settingsAcceptButton"
		Me.settingsAcceptButton.Size = New System.Drawing.Size(75, 23)
		Me.settingsAcceptButton.TabIndex = 0
		Me.settingsAcceptButton.Text = "Done"
		Me.settingsAcceptButton.UseVisualStyleBackColor = True
		'
		'Settings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(360, 580)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.settingsTabs)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.Name = "Settings"
		Me.Text = "Settings"
		Me.settingsTabs.ResumeLayout(False)
		Me.debugPage.ResumeLayout(False)
		Me.debugPage.PerformLayout()
		CType(Me.refreshRateInput, System.ComponentModel.ISupportInitialize).EndInit()
		Me.appearancePage.ResumeLayout(False)
		Me.appearancePage.PerformLayout()
		Me.codingBuddyFrame.ResumeLayout(False)
		CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.AppearanceTab.ResumeLayout(False)
		Me.AppearanceTab.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.backgroundImageDemo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.editorPage.ResumeLayout(False)
		Me.editorPage.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents settingsTabs As TabControl
	Friend WithEvents debugPage As TabPage
	Friend WithEvents appearancePage As TabPage
	Friend WithEvents refreshRateInput As NumericUpDown
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents settingsCancelButton As Button
	Friend WithEvents settingsAcceptButton As Button
	Friend WithEvents codingBuddyFrame As GroupBox
	Friend WithEvents PictureBox6 As PictureBox
	Friend WithEvents RadioButton6 As RadioButton
	Friend WithEvents PictureBox5 As PictureBox
	Friend WithEvents RadioButton5 As RadioButton
	Friend WithEvents PictureBox4 As PictureBox
	Friend WithEvents RadioButton4 As RadioButton
	Friend WithEvents PictureBox3 As PictureBox
	Friend WithEvents RadioButton3 As RadioButton
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents RadioButton2 As RadioButton
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents RadioButton1 As RadioButton
	Friend WithEvents codingBuddyActiveCheck As CheckBox
	Friend WithEvents PictureBox7 As PictureBox
	Friend WithEvents RadioButton7 As RadioButton
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents autoRefreshCheckbox As CheckBox
	Friend WithEvents surpressScriptErrorsCheckbox As CheckBox
	Friend WithEvents Label4 As Label
	Friend WithEvents AppearanceTab As TabPage
	Friend WithEvents colorSetLabel As Label
	Friend WithEvents colorSetList As ComboBox
	Friend WithEvents editorPage As TabPage
	Friend WithEvents drawSelectedElementChildren As CheckBox
	Friend WithEvents drawSelectedElement As CheckBox
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents backgroundImageDemo As PictureBox
	Friend WithEvents backgroundColorDemo As Panel
	Friend WithEvents backgroundImageRadioButton As RadioButton
	Friend WithEvents backgroundColorRadioButton As RadioButton
	Friend WithEvents PictureBox8 As PictureBox
	Friend WithEvents RadioButton8 As RadioButton
	Friend WithEvents codingBuddyReadAllCheck As CheckBox
	Friend WithEvents PictureBox9 As PictureBox
	Friend WithEvents RadioButton9 As RadioButton
End Class
