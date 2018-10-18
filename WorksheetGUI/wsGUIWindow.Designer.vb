<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class wsGUIWindow
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wsGUIWindow))
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.undoButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.redoButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NewWorksheetPairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.newStandaloneFormButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.DealPackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ImageOverlayWorksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.openWorksheetOption = New System.Windows.Forms.ToolStripMenuItem()
		Me.openForEdit = New System.Windows.Forms.ToolStripMenuItem()
		Me.openXMLOption = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CloseCurrentFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ChooseStoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.UndoAllChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.ConversionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ConvertToAppSchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ConvertFromAppSchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.MakeFormEditableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ConvertExcelButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.UpdateOldCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CreateBodyForCreditAppButtonFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.dealPackInsertionButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.FixSpecialCharactersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ConvertSavedImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.FormDisplayStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.TextEditorToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.refreshButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.quickLoadButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.lCompanyIDInput = New System.Windows.Forms.ToolStripComboBox()
		Me.SalesQuoteCalculationTypeBox = New System.Windows.Forms.ToolStripComboBox()
		Me.openWorksheetDialog = New System.Windows.Forms.OpenFileDialog()
		Me.saveWorksheetDialog = New System.Windows.Forms.SaveFileDialog()
		Me.showStatus = New System.Windows.Forms.ToolStripStatusLabel()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.cursorPositionLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.pageBottomIndicatorLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.colorPicker = New System.Windows.Forms.ColorDialog()
		Me.refreshTimer = New System.Windows.Forms.Timer(Me.components)
		Me.openXMLDialog = New System.Windows.Forms.OpenFileDialog()
		Me.displayAreaSourceWindow = New System.Windows.Forms.WebBrowser()
		Me.displayAreaSourceBox = New System.Windows.Forms.TextBox()
		Me.displayAreaSourceBoxRich = New System.Windows.Forms.RichTextBox()
		Me.displayArea1 = New System.Windows.Forms.WebBrowser()
		Me.editorToolPanel = New System.Windows.Forms.Panel()
		Me.editorTabControl = New System.Windows.Forms.TabControl()
		Me.editorGeneralTools = New System.Windows.Forms.TabPage()
		Me.editorSplitPanel = New System.Windows.Forms.SplitContainer()
		Me.editorSplitSubPanel = New System.Windows.Forms.Panel()
		Me.blorp = New System.Windows.Forms.Button()
		Me.blockElementControlPanel = New System.Windows.Forms.Panel()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.heightUnitBox = New System.Windows.Forms.ComboBox()
		Me.heightBox = New System.Windows.Forms.NumericUpDown()
		Me.widthUnitBox = New System.Windows.Forms.ComboBox()
		Me.widthBox = New System.Windows.Forms.NumericUpDown()
		Me.marginButton = New System.Windows.Forms.Button()
		Me.bgColorDropButton = New System.Windows.Forms.Button()
		Me.bgColorButtonHTML = New System.Windows.Forms.Button()
		Me.paddingButton = New System.Windows.Forms.Button()
		Me.borderLeftButton = New System.Windows.Forms.Button()
		Me.borderTopButton = New System.Windows.Forms.Button()
		Me.borderBottomButton = New System.Windows.Forms.Button()
		Me.borderRightButton = New System.Windows.Forms.Button()
		Me.textControlPanel = New System.Windows.Forms.Panel()
		Me.fontColorDropButton = New System.Windows.Forms.Button()
		Me.fontColorButton = New System.Windows.Forms.Button()
		Me.fontFamilyBox = New System.Windows.Forms.ComboBox()
		Me.alignJustifyButton = New System.Windows.Forms.Button()
		Me.alignRightButton = New System.Windows.Forms.Button()
		Me.alignCenterButton = New System.Windows.Forms.Button()
		Me.alignLeftButton = New System.Windows.Forms.Button()
		Me.fontUnitBox = New System.Windows.Forms.ComboBox()
		Me.underlineButton = New System.Windows.Forms.Button()
		Me.italicButton = New System.Windows.Forms.Button()
		Me.boldButton = New System.Windows.Forms.Button()
		Me.fontSizeBox = New System.Windows.Forms.NumericUpDown()
		Me.saveButton = New System.Windows.Forms.Button()
		Me.setHTML = New System.Windows.Forms.Button()
		Me.currentElement = New System.Windows.Forms.RichTextBox()
		Me.editorBasicStyles = New System.Windows.Forms.TabPage()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.basicStylesSilverButton = New System.Windows.Forms.Button()
		Me.basicStyleButtonBlack = New System.Windows.Forms.Button()
		Me.basicStyleButtonAnswer = New System.Windows.Forms.Button()
		Me.editorTableTab = New System.Windows.Forms.TabPage()
		Me.htmlTabPageCellBox = New System.Windows.Forms.GroupBox()
		Me.colspanBox = New System.Windows.Forms.NumericUpDown()
		Me.rowspanBox = New System.Windows.Forms.NumericUpDown()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.htmlTabPageRowBox = New System.Windows.Forms.GroupBox()
		Me.htmlTabPageColumnBox = New System.Windows.Forms.GroupBox()
		Me.columnInsertLeft = New System.Windows.Forms.Button()
		Me.columnInsertRight = New System.Windows.Forms.Button()
		Me.htmlTabPageTableBox = New System.Windows.Forms.GroupBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.htmlTableColumns = New System.Windows.Forms.NumericUpDown()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
		Me.ComboBox2 = New System.Windows.Forms.ComboBox()
		Me.tableWidthBox = New System.Windows.Forms.NumericUpDown()
		Me.Button6 = New System.Windows.Forms.Button()
		Me.Button7 = New System.Windows.Forms.Button()
		Me.Button8 = New System.Windows.Forms.Button()
		Me.Button9 = New System.Windows.Forms.Button()
		Me.openForEditDialog = New System.Windows.Forms.OpenFileDialog()
		Me.textPrintDelay = New System.Windows.Forms.Timer(Me.components)
		Me.createNewTablePanel = New System.Windows.Forms.Panel()
		Me.createNewTableButton = New System.Windows.Forms.Button()
		Me.newTableColumns = New System.Windows.Forms.NumericUpDown()
		Me.newTableRows = New System.Windows.Forms.NumericUpDown()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.openBGPicture = New System.Windows.Forms.OpenFileDialog()
		Me.htmlBGColorPicker = New System.Windows.Forms.ColorDialog()
		Me.htmlFontColorPicker = New System.Windows.Forms.ColorDialog()
		Me.cursorPositionTimer = New System.Windows.Forms.Timer(Me.components)
		Me.TypingCountdown = New System.Windows.Forms.Timer(Me.components)
		Me.DoubleClickTimer = New System.Windows.Forms.Timer(Me.components)
		Me.LeftToolStrip = New System.Windows.Forms.ToolStrip()
		Me.displayStyleButton = New System.Windows.Forms.ToolStripButton()
		Me.autoRefreshButton = New System.Windows.Forms.ToolStripButton()
		Me.previewPageBreaksButton = New System.Windows.Forms.ToolStripButton()
		Me.viewSourceButton = New System.Windows.Forms.ToolStripButton()
		Me.editModeButton = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.chromepreviewbutton = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.overlayModeButton = New System.Windows.Forms.ToolStripButton()
		Me.ViewTagCreatorButton = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.TakeScreenshot = New System.Windows.Forms.ToolStripButton()
		Me.LeftSplitContainer = New System.Windows.Forms.SplitContainer()
		Me.MenuStrip1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.editorToolPanel.SuspendLayout()
		Me.editorTabControl.SuspendLayout()
		Me.editorGeneralTools.SuspendLayout()
		CType(Me.editorSplitPanel, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.editorSplitPanel.Panel1.SuspendLayout()
		Me.editorSplitPanel.Panel2.SuspendLayout()
		Me.editorSplitPanel.SuspendLayout()
		Me.editorSplitSubPanel.SuspendLayout()
		Me.blockElementControlPanel.SuspendLayout()
		CType(Me.heightBox, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.widthBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.textControlPanel.SuspendLayout()
		CType(Me.fontSizeBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.editorBasicStyles.SuspendLayout()
		Me.GroupBox4.SuspendLayout()
		Me.editorTableTab.SuspendLayout()
		Me.htmlTabPageCellBox.SuspendLayout()
		CType(Me.colspanBox, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.rowspanBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.htmlTabPageColumnBox.SuspendLayout()
		Me.htmlTabPageTableBox.SuspendLayout()
		CType(Me.htmlTableColumns, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tableWidthBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.createNewTablePanel.SuspendLayout()
		CType(Me.newTableColumns, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.newTableRows, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.LeftToolStrip.SuspendLayout()
		CType(Me.LeftSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.LeftSplitContainer.Panel1.SuspendLayout()
		Me.LeftSplitContainer.SuspendLayout()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.undoButton, Me.redoButton, Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem, Me.refreshButton, Me.quickLoadButton, Me.lCompanyIDInput, Me.SalesQuoteCalculationTypeBox})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.MenuStrip1.Size = New System.Drawing.Size(1247, 27)
		Me.MenuStrip1.TabIndex = 1
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'undoButton
		'
		Me.undoButton.Enabled = False
		Me.undoButton.Image = CType(resources.GetObject("undoButton.Image"), System.Drawing.Image)
		Me.undoButton.Name = "undoButton"
		Me.undoButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
		Me.undoButton.Size = New System.Drawing.Size(28, 23)
		Me.undoButton.ToolTipText = "Undo"
		'
		'redoButton
		'
		Me.redoButton.Enabled = False
		Me.redoButton.Image = CType(resources.GetObject("redoButton.Image"), System.Drawing.Image)
		Me.redoButton.Name = "redoButton"
		Me.redoButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.redoButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
		Me.redoButton.Size = New System.Drawing.Size(28, 23)
		Me.redoButton.ToolTipText = "Redo"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWorksheetPairToolStripMenuItem, Me.openWorksheetOption, Me.openForEdit, Me.openXMLOption, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.CloseCurrentFileToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 23)
		Me.FileToolStripMenuItem.Text = "File"
		'
		'NewWorksheetPairToolStripMenuItem
		'
		Me.NewWorksheetPairToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
		Me.NewWorksheetPairToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newStandaloneFormButton, Me.DealPackToolStripMenuItem, Me.ImageOverlayWorksheetToolStripMenuItem})
		Me.NewWorksheetPairToolStripMenuItem.Name = "NewWorksheetPairToolStripMenuItem"
		Me.NewWorksheetPairToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
		Me.NewWorksheetPairToolStripMenuItem.Text = "New"
		'
		'newStandaloneFormButton
		'
		Me.newStandaloneFormButton.Name = "newStandaloneFormButton"
		Me.newStandaloneFormButton.Size = New System.Drawing.Size(209, 22)
		Me.newStandaloneFormButton.Text = "Standalone Worksheet"
		'
		'DealPackToolStripMenuItem
		'
		Me.DealPackToolStripMenuItem.Name = "DealPackToolStripMenuItem"
		Me.DealPackToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
		Me.DealPackToolStripMenuItem.Text = "Deal Pack"
		'
		'ImageOverlayWorksheetToolStripMenuItem
		'
		Me.ImageOverlayWorksheetToolStripMenuItem.Name = "ImageOverlayWorksheetToolStripMenuItem"
		Me.ImageOverlayWorksheetToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
		Me.ImageOverlayWorksheetToolStripMenuItem.Text = "Image Overlay Worksheet"
		'
		'openWorksheetOption
		'
		Me.openWorksheetOption.Name = "openWorksheetOption"
		Me.openWorksheetOption.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
		Me.openWorksheetOption.Size = New System.Drawing.Size(245, 22)
		Me.openWorksheetOption.Text = "Open..."
		'
		'openForEdit
		'
		Me.openForEdit.Name = "openForEdit"
		Me.openForEdit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
			Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
		Me.openForEdit.Size = New System.Drawing.Size(245, 22)
		Me.openForEdit.Text = "Open for editing..."
		Me.openForEdit.Visible = False
		'
		'openXMLOption
		'
		Me.openXMLOption.BackColor = System.Drawing.SystemColors.Control
		Me.openXMLOption.Name = "openXMLOption"
		Me.openXMLOption.Size = New System.Drawing.Size(245, 22)
		Me.openXMLOption.Text = "Choose Test XML..."
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(242, 6)
		'
		'SaveToolStripMenuItem
		'
		Me.SaveToolStripMenuItem.Enabled = False
		Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
		Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
		Me.SaveToolStripMenuItem.Text = "Save"
		'
		'SaveAsToolStripMenuItem
		'
		Me.SaveAsToolStripMenuItem.Enabled = False
		Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
		Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
		Me.SaveAsToolStripMenuItem.Text = "Save As..."
		'
		'CloseCurrentFileToolStripMenuItem
		'
		Me.CloseCurrentFileToolStripMenuItem.Name = "CloseCurrentFileToolStripMenuItem"
		Me.CloseCurrentFileToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
		Me.CloseCurrentFileToolStripMenuItem.Text = "Close current file"
		'
		'EditToolStripMenuItem
		'
		Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChooseStoreToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.UndoAllChangesToolStripMenuItem, Me.ToolStripSeparator2, Me.ConversionsToolStripMenuItem})
		Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
		Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
		Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 23)
		Me.EditToolStripMenuItem.Text = "Edit"
		'
		'ChooseStoreToolStripMenuItem
		'
		Me.ChooseStoreToolStripMenuItem.Name = "ChooseStoreToolStripMenuItem"
		Me.ChooseStoreToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
		Me.ChooseStoreToolStripMenuItem.Text = "Choose Store..."
		'
		'SettingsToolStripMenuItem
		'
		Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
		Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
		Me.SettingsToolStripMenuItem.Text = "Settings"
		'
		'UndoAllChangesToolStripMenuItem
		'
		Me.UndoAllChangesToolStripMenuItem.Name = "UndoAllChangesToolStripMenuItem"
		Me.UndoAllChangesToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
		Me.UndoAllChangesToolStripMenuItem.Text = "Undo All Changes"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
		'
		'ConversionsToolStripMenuItem
		'
		Me.ConversionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConvertToAppSchemaToolStripMenuItem, Me.ConvertFromAppSchemaToolStripMenuItem, Me.MakeFormEditableToolStripMenuItem, Me.ConvertExcelButton, Me.UpdateOldCodeToolStripMenuItem, Me.CreateBodyForCreditAppButtonFormToolStripMenuItem, Me.dealPackInsertionButton, Me.FixSpecialCharactersToolStripMenuItem, Me.ConvertSavedImageToolStripMenuItem})
		Me.ConversionsToolStripMenuItem.Name = "ConversionsToolStripMenuItem"
		Me.ConversionsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
		Me.ConversionsToolStripMenuItem.Text = "Conversions"
		'
		'ConvertToAppSchemaToolStripMenuItem
		'
		Me.ConvertToAppSchemaToolStripMenuItem.Name = "ConvertToAppSchemaToolStripMenuItem"
		Me.ConvertToAppSchemaToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.ConvertToAppSchemaToolStripMenuItem.Text = "Convert to AppSchema"
		'
		'ConvertFromAppSchemaToolStripMenuItem
		'
		Me.ConvertFromAppSchemaToolStripMenuItem.Name = "ConvertFromAppSchemaToolStripMenuItem"
		Me.ConvertFromAppSchemaToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.ConvertFromAppSchemaToolStripMenuItem.Text = "Convert from AppSchema"
		Me.ConvertFromAppSchemaToolStripMenuItem.Visible = False
		'
		'MakeFormEditableToolStripMenuItem
		'
		Me.MakeFormEditableToolStripMenuItem.Name = "MakeFormEditableToolStripMenuItem"
		Me.MakeFormEditableToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.MakeFormEditableToolStripMenuItem.Text = "Make form editable (BETA)"
		'
		'ConvertExcelButton
		'
		Me.ConvertExcelButton.Name = "ConvertExcelButton"
		Me.ConvertExcelButton.Size = New System.Drawing.Size(278, 22)
		Me.ConvertExcelButton.Text = "Excel to worksheet"
		'
		'UpdateOldCodeToolStripMenuItem
		'
		Me.UpdateOldCodeToolStripMenuItem.Name = "UpdateOldCodeToolStripMenuItem"
		Me.UpdateOldCodeToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.UpdateOldCodeToolStripMenuItem.Text = "Update Old Code"
		'
		'CreateBodyForCreditAppButtonFormToolStripMenuItem
		'
		Me.CreateBodyForCreditAppButtonFormToolStripMenuItem.Name = "CreateBodyForCreditAppButtonFormToolStripMenuItem"
		Me.CreateBodyForCreditAppButtonFormToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.CreateBodyForCreditAppButtonFormToolStripMenuItem.Text = "Create Body for CreditAppButton form"
		'
		'dealPackInsertionButton
		'
		Me.dealPackInsertionButton.Name = "dealPackInsertionButton"
		Me.dealPackInsertionButton.Size = New System.Drawing.Size(278, 22)
		Me.dealPackInsertionButton.Text = "Mass Deal Pack Update"
		'
		'FixSpecialCharactersToolStripMenuItem
		'
		Me.FixSpecialCharactersToolStripMenuItem.Name = "FixSpecialCharactersToolStripMenuItem"
		Me.FixSpecialCharactersToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.FixSpecialCharactersToolStripMenuItem.Text = "Fix Special Characters"
		'
		'ConvertSavedImageToolStripMenuItem
		'
		Me.ConvertSavedImageToolStripMenuItem.Name = "ConvertSavedImageToolStripMenuItem"
		Me.ConvertSavedImageToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
		Me.ConvertSavedImageToolStripMenuItem.Text = "Convert Saved Image"
		'
		'ViewToolStripMenuItem
		'
		Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormDisplayStyleToolStripMenuItem})
		Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
		Me.ViewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
		Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 23)
		Me.ViewToolStripMenuItem.Text = "View"
		'
		'FormDisplayStyleToolStripMenuItem
		'
		Me.FormDisplayStyleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextEditorToolsToolStripMenuItem})
		Me.FormDisplayStyleToolStripMenuItem.Name = "FormDisplayStyleToolStripMenuItem"
		Me.FormDisplayStyleToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
		Me.FormDisplayStyleToolStripMenuItem.Text = "Toolbars"
		'
		'TextEditorToolsToolStripMenuItem
		'
		Me.TextEditorToolsToolStripMenuItem.CheckOnClick = True
		Me.TextEditorToolsToolStripMenuItem.Name = "TextEditorToolsToolStripMenuItem"
		Me.TextEditorToolsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
		Me.TextEditorToolsToolStripMenuItem.Text = "Text Editor Tools"
		'
		'HelpToolStripMenuItem
		'
		Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
		Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
		Me.HelpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
		Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 23)
		Me.HelpToolStripMenuItem.Text = "Help"
		'
		'AboutToolStripMenuItem
		'
		Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
		Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
		Me.AboutToolStripMenuItem.Text = "About"
		'
		'refreshButton
		'
		Me.refreshButton.Name = "refreshButton"
		Me.refreshButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
		Me.refreshButton.Size = New System.Drawing.Size(58, 23)
		Me.refreshButton.Text = "Refresh"
		'
		'quickLoadButton
		'
		Me.quickLoadButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.quickLoadButton.BackColor = System.Drawing.SystemColors.ControlDark
		Me.quickLoadButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.quickLoadButton.Name = "quickLoadButton"
		Me.quickLoadButton.Size = New System.Drawing.Size(142, 23)
		Me.quickLoadButton.Text = "Attempt Quick Load"
		'
		'lCompanyIDInput
		'
		Me.lCompanyIDInput.AutoSize = False
		Me.lCompanyIDInput.Margin = New System.Windows.Forms.Padding(15, 0, 1, 0)
		Me.lCompanyIDInput.Name = "lCompanyIDInput"
		Me.lCompanyIDInput.Size = New System.Drawing.Size(250, 23)
		'
		'SalesQuoteCalculationTypeBox
		'
		Me.SalesQuoteCalculationTypeBox.Items.AddRange(New Object() {"Loan", "Cash", "Balloon", "Lease", "OnePay"})
		Me.SalesQuoteCalculationTypeBox.Margin = New System.Windows.Forms.Padding(15, 0, 1, 0)
		Me.SalesQuoteCalculationTypeBox.Name = "SalesQuoteCalculationTypeBox"
		Me.SalesQuoteCalculationTypeBox.Size = New System.Drawing.Size(121, 23)
		Me.SalesQuoteCalculationTypeBox.Text = "Loan"
		'
		'openWorksheetDialog
		'
		Me.openWorksheetDialog.DefaultExt = "xslt"
		Me.openWorksheetDialog.Filter = "xslt files (*.xslt)|*.xslt|All files (*.*)|*.*"""
		Me.openWorksheetDialog.RestoreDirectory = True
		'
		'saveWorksheetDialog
		'
		Me.saveWorksheetDialog.Filter = "xslt files (*.xslt)|*.xslt|All files (*.*)|*.*"""
		Me.saveWorksheetDialog.Title = "Choose a Shell File name and Directory"
		'
		'showStatus
		'
		Me.showStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.showStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.showStatus.Name = "showStatus"
		Me.showStatus.Size = New System.Drawing.Size(1232, 17)
		Me.showStatus.Spring = True
		Me.showStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'StatusStrip1
		'
		Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.showStatus, Me.cursorPositionLabel, Me.pageBottomIndicatorLabel})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 786)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.StatusStrip1.Size = New System.Drawing.Size(1247, 22)
		Me.StatusStrip1.TabIndex = 2
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'cursorPositionLabel
		'
		Me.cursorPositionLabel.Name = "cursorPositionLabel"
		Me.cursorPositionLabel.Size = New System.Drawing.Size(0, 17)
		'
		'pageBottomIndicatorLabel
		'
		Me.pageBottomIndicatorLabel.Name = "pageBottomIndicatorLabel"
		Me.pageBottomIndicatorLabel.Size = New System.Drawing.Size(0, 17)
		'
		'colorPicker
		'
		Me.colorPicker.AnyColor = True
		Me.colorPicker.FullOpen = True
		'
		'refreshTimer
		'
		Me.refreshTimer.Interval = 3000
		'
		'openXMLDialog
		'
		Me.openXMLDialog.DefaultExt = "xslt"
		Me.openXMLDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
		Me.openXMLDialog.InitialDirectory = "Desktop"
		Me.openXMLDialog.RestoreDirectory = True
		'
		'displayAreaSourceWindow
		'
		Me.displayAreaSourceWindow.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.displayAreaSourceWindow.Location = New System.Drawing.Point(220, 14)
		Me.displayAreaSourceWindow.MinimumSize = New System.Drawing.Size(750, 0)
		Me.displayAreaSourceWindow.Name = "displayAreaSourceWindow"
		Me.displayAreaSourceWindow.Size = New System.Drawing.Size(806, 781)
		Me.displayAreaSourceWindow.TabIndex = 0
		Me.displayAreaSourceWindow.Url = New System.Uri("", System.UriKind.Relative)
		Me.displayAreaSourceWindow.Visible = False
		'
		'displayAreaSourceBox
		'
		Me.displayAreaSourceBox.AcceptsReturn = True
		Me.displayAreaSourceBox.AcceptsTab = True
		Me.displayAreaSourceBox.AllowDrop = True
		Me.displayAreaSourceBox.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.displayAreaSourceBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.displayAreaSourceBox.Location = New System.Drawing.Point(220, 27)
		Me.displayAreaSourceBox.MaxLength = 2147483647
		Me.displayAreaSourceBox.MinimumSize = New System.Drawing.Size(750, 4)
		Me.displayAreaSourceBox.Multiline = True
		Me.displayAreaSourceBox.Name = "displayAreaSourceBox"
		Me.displayAreaSourceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.displayAreaSourceBox.Size = New System.Drawing.Size(806, 781)
		Me.displayAreaSourceBox.TabIndex = 0
		Me.displayAreaSourceBox.Visible = False
		'
		'displayAreaSourceBoxRich
		'
		Me.displayAreaSourceBoxRich.AcceptsTab = True
		Me.displayAreaSourceBoxRich.AutoWordSelection = True
		Me.displayAreaSourceBoxRich.BackColor = System.Drawing.SystemColors.InactiveCaptionText
		Me.displayAreaSourceBoxRich.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.displayAreaSourceBoxRich.ForeColor = System.Drawing.SystemColors.InactiveCaption
		Me.displayAreaSourceBoxRich.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.displayAreaSourceBoxRich.Location = New System.Drawing.Point(220, 27)
		Me.displayAreaSourceBoxRich.MinimumSize = New System.Drawing.Size(750, 4)
		Me.displayAreaSourceBoxRich.Name = "displayAreaSourceBoxRich"
		Me.displayAreaSourceBoxRich.ReadOnly = True
		Me.displayAreaSourceBoxRich.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
		Me.displayAreaSourceBoxRich.ShowSelectionMargin = True
		Me.displayAreaSourceBoxRich.Size = New System.Drawing.Size(806, 781)
		Me.displayAreaSourceBoxRich.TabIndex = 0
		Me.displayAreaSourceBoxRich.Text = ""
		Me.displayAreaSourceBoxRich.Visible = False
		'
		'displayArea1
		'
		Me.displayArea1.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.displayArea1.Location = New System.Drawing.Point(220, 27)
		Me.displayArea1.MinimumSize = New System.Drawing.Size(750, 0)
		Me.displayArea1.Name = "displayArea1"
		Me.displayArea1.ScriptErrorsSuppressed = True
		Me.displayArea1.Size = New System.Drawing.Size(806, 781)
		Me.displayArea1.TabIndex = 0
		Me.displayArea1.Url = New System.Uri("", System.UriKind.Relative)
		Me.displayArea1.Visible = False
		'
		'editorToolPanel
		'
		Me.editorToolPanel.Controls.Add(Me.editorTabControl)
		Me.editorToolPanel.Dock = System.Windows.Forms.DockStyle.Top
		Me.editorToolPanel.Location = New System.Drawing.Point(0, 27)
		Me.editorToolPanel.Name = "editorToolPanel"
		Me.editorToolPanel.Size = New System.Drawing.Size(1247, 108)
		Me.editorToolPanel.TabIndex = 4
		Me.editorToolPanel.Visible = False
		'
		'editorTabControl
		'
		Me.editorTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
		Me.editorTabControl.Controls.Add(Me.editorGeneralTools)
		Me.editorTabControl.Controls.Add(Me.editorBasicStyles)
		Me.editorTabControl.Controls.Add(Me.editorTableTab)
		Me.editorTabControl.Dock = System.Windows.Forms.DockStyle.Fill
		Me.editorTabControl.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.editorTabControl.ItemSize = New System.Drawing.Size(62, 18)
		Me.editorTabControl.Location = New System.Drawing.Point(0, 0)
		Me.editorTabControl.Name = "editorTabControl"
		Me.editorTabControl.SelectedIndex = 0
		Me.editorTabControl.Size = New System.Drawing.Size(1247, 108)
		Me.editorTabControl.TabIndex = 43
		'
		'editorGeneralTools
		'
		Me.editorGeneralTools.BackColor = System.Drawing.SystemColors.ControlDarkDark
		Me.editorGeneralTools.Controls.Add(Me.editorSplitPanel)
		Me.editorGeneralTools.Location = New System.Drawing.Point(4, 22)
		Me.editorGeneralTools.Name = "editorGeneralTools"
		Me.editorGeneralTools.Padding = New System.Windows.Forms.Padding(3)
		Me.editorGeneralTools.Size = New System.Drawing.Size(1239, 82)
		Me.editorGeneralTools.TabIndex = 0
		Me.editorGeneralTools.Text = "Home"
		'
		'editorSplitPanel
		'
		Me.editorSplitPanel.BackColor = System.Drawing.SystemColors.ControlLight
		Me.editorSplitPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.editorSplitPanel.Location = New System.Drawing.Point(3, 3)
		Me.editorSplitPanel.Name = "editorSplitPanel"
		'
		'editorSplitPanel.Panel1
		'
		Me.editorSplitPanel.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
		Me.editorSplitPanel.Panel1.Controls.Add(Me.editorSplitSubPanel)
		Me.editorSplitPanel.Panel1.Controls.Add(Me.setHTML)
		'
		'editorSplitPanel.Panel2
		'
		Me.editorSplitPanel.Panel2.Controls.Add(Me.currentElement)
		Me.editorSplitPanel.Size = New System.Drawing.Size(1233, 76)
		Me.editorSplitPanel.SplitterDistance = 897
		Me.editorSplitPanel.SplitterWidth = 12
		Me.editorSplitPanel.TabIndex = 10
		'
		'editorSplitSubPanel
		'
		Me.editorSplitSubPanel.Controls.Add(Me.blorp)
		Me.editorSplitSubPanel.Controls.Add(Me.blockElementControlPanel)
		Me.editorSplitSubPanel.Controls.Add(Me.textControlPanel)
		Me.editorSplitSubPanel.Controls.Add(Me.saveButton)
		Me.editorSplitSubPanel.Location = New System.Drawing.Point(0, 2)
		Me.editorSplitSubPanel.Name = "editorSplitSubPanel"
		Me.editorSplitSubPanel.Size = New System.Drawing.Size(849, 74)
		Me.editorSplitSubPanel.TabIndex = 42
		'
		'blorp
		'
		Me.blorp.BackColor = System.Drawing.Color.Blue
		Me.blorp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.blorp.Font = New System.Drawing.Font("Impact", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.blorp.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.blorp.Location = New System.Drawing.Point(738, 38)
		Me.blorp.Name = "blorp"
		Me.blorp.Size = New System.Drawing.Size(73, 39)
		Me.blorp.TabIndex = 18
		Me.blorp.Text = "Blorp"
		Me.blorp.UseVisualStyleBackColor = False
		'
		'blockElementControlPanel
		'
		Me.blockElementControlPanel.BackColor = System.Drawing.SystemColors.ControlDark
		Me.blockElementControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.blockElementControlPanel.Controls.Add(Me.Label14)
		Me.blockElementControlPanel.Controls.Add(Me.heightUnitBox)
		Me.blockElementControlPanel.Controls.Add(Me.heightBox)
		Me.blockElementControlPanel.Controls.Add(Me.widthUnitBox)
		Me.blockElementControlPanel.Controls.Add(Me.widthBox)
		Me.blockElementControlPanel.Controls.Add(Me.marginButton)
		Me.blockElementControlPanel.Controls.Add(Me.bgColorDropButton)
		Me.blockElementControlPanel.Controls.Add(Me.bgColorButtonHTML)
		Me.blockElementControlPanel.Controls.Add(Me.paddingButton)
		Me.blockElementControlPanel.Controls.Add(Me.borderLeftButton)
		Me.blockElementControlPanel.Controls.Add(Me.borderTopButton)
		Me.blockElementControlPanel.Controls.Add(Me.borderBottomButton)
		Me.blockElementControlPanel.Controls.Add(Me.borderRightButton)
		Me.blockElementControlPanel.Location = New System.Drawing.Point(294, 0)
		Me.blockElementControlPanel.Name = "blockElementControlPanel"
		Me.blockElementControlPanel.Size = New System.Drawing.Size(308, 78)
		Me.blockElementControlPanel.TabIndex = 39
		'
		'Label14
		'
		Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(157, 3)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(51, 33)
		Me.Label14.TabIndex = 39
		Me.Label14.Text = "Width / Height"
		'
		'heightUnitBox
		'
		Me.heightUnitBox.BackColor = System.Drawing.Color.White
		Me.heightUnitBox.FormattingEnabled = True
		Me.heightUnitBox.Items.AddRange(New Object() {"em", "px", "pt", "vw", "vh", "%"})
		Me.heightUnitBox.Location = New System.Drawing.Point(259, 25)
		Me.heightUnitBox.Name = "heightUnitBox"
		Me.heightUnitBox.Size = New System.Drawing.Size(39, 21)
		Me.heightUnitBox.TabIndex = 38
		Me.heightUnitBox.Text = "px"
		'
		'heightBox
		'
		Me.heightBox.DecimalPlaces = 1
		Me.heightBox.Location = New System.Drawing.Point(208, 26)
		Me.heightBox.Maximum = New Decimal(New Integer() {980, 0, 0, 0})
		Me.heightBox.Name = "heightBox"
		Me.heightBox.Size = New System.Drawing.Size(49, 22)
		Me.heightBox.TabIndex = 37
		Me.heightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'widthUnitBox
		'
		Me.widthUnitBox.BackColor = System.Drawing.Color.White
		Me.widthUnitBox.FormattingEnabled = True
		Me.widthUnitBox.Items.AddRange(New Object() {"em", "px", "pt", "vw", "vh", "%"})
		Me.widthUnitBox.Location = New System.Drawing.Point(259, 1)
		Me.widthUnitBox.Name = "widthUnitBox"
		Me.widthUnitBox.Size = New System.Drawing.Size(39, 21)
		Me.widthUnitBox.TabIndex = 36
		Me.widthUnitBox.Text = "px"
		'
		'widthBox
		'
		Me.widthBox.DecimalPlaces = 1
		Me.widthBox.Location = New System.Drawing.Point(208, 2)
		Me.widthBox.Maximum = New Decimal(New Integer() {980, 0, 0, 0})
		Me.widthBox.Name = "widthBox"
		Me.widthBox.Size = New System.Drawing.Size(49, 22)
		Me.widthBox.TabIndex = 35
		Me.widthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'marginButton
		'
		Me.marginButton.BackColor = System.Drawing.SystemColors.Control
		Me.marginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.marginButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.marginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.marginButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.marginButton.Location = New System.Drawing.Point(139, 40)
		Me.marginButton.Name = "marginButton"
		Me.marginButton.Size = New System.Drawing.Size(62, 29)
		Me.marginButton.TabIndex = 34
		Me.marginButton.Text = "Margins"
		Me.marginButton.UseVisualStyleBackColor = False
		'
		'bgColorDropButton
		'
		Me.bgColorDropButton.BackColor = System.Drawing.SystemColors.Control
		Me.bgColorDropButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.bgColorDropButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.bgColorDropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.bgColorDropButton.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bgColorDropButton.ForeColor = System.Drawing.SystemColors.ControlDark
		Me.bgColorDropButton.Location = New System.Drawing.Point(137, 4)
		Me.bgColorDropButton.Name = "bgColorDropButton"
		Me.bgColorDropButton.Size = New System.Drawing.Size(15, 29)
		Me.bgColorDropButton.TabIndex = 31
		Me.bgColorDropButton.Text = "V"
		Me.bgColorDropButton.UseVisualStyleBackColor = False
		'
		'bgColorButtonHTML
		'
		Me.bgColorButtonHTML.BackColor = System.Drawing.SystemColors.Control
		Me.bgColorButtonHTML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.bgColorButtonHTML.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.bgColorButtonHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.bgColorButtonHTML.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bgColorButtonHTML.Location = New System.Drawing.Point(71, 4)
		Me.bgColorButtonHTML.Name = "bgColorButtonHTML"
		Me.bgColorButtonHTML.Size = New System.Drawing.Size(67, 29)
		Me.bgColorButtonHTML.TabIndex = 30
		Me.bgColorButtonHTML.Text = "BG Color"
		Me.bgColorButtonHTML.UseVisualStyleBackColor = False
		'
		'paddingButton
		'
		Me.paddingButton.BackColor = System.Drawing.SystemColors.Control
		Me.paddingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.paddingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.paddingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.paddingButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.paddingButton.Location = New System.Drawing.Point(71, 40)
		Me.paddingButton.Name = "paddingButton"
		Me.paddingButton.Size = New System.Drawing.Size(62, 29)
		Me.paddingButton.TabIndex = 29
		Me.paddingButton.Text = "Padding"
		Me.paddingButton.UseVisualStyleBackColor = False
		'
		'borderLeftButton
		'
		Me.borderLeftButton.BackColor = System.Drawing.Color.White
		Me.borderLeftButton.BackgroundImage = CType(resources.GetObject("borderLeftButton.BackgroundImage"), System.Drawing.Image)
		Me.borderLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.borderLeftButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.borderLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.borderLeftButton.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.borderLeftButton.Location = New System.Drawing.Point(4, 39)
		Me.borderLeftButton.Name = "borderLeftButton"
		Me.borderLeftButton.Size = New System.Drawing.Size(29, 29)
		Me.borderLeftButton.TabIndex = 28
		Me.borderLeftButton.Text = "BL"
		Me.borderLeftButton.UseVisualStyleBackColor = False
		'
		'borderTopButton
		'
		Me.borderTopButton.BackColor = System.Drawing.Color.White
		Me.borderTopButton.BackgroundImage = CType(resources.GetObject("borderTopButton.BackgroundImage"), System.Drawing.Image)
		Me.borderTopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.borderTopButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.borderTopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.borderTopButton.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.borderTopButton.Location = New System.Drawing.Point(4, 4)
		Me.borderTopButton.Name = "borderTopButton"
		Me.borderTopButton.Size = New System.Drawing.Size(29, 29)
		Me.borderTopButton.TabIndex = 27
		Me.borderTopButton.Text = "BT"
		Me.borderTopButton.UseVisualStyleBackColor = False
		'
		'borderBottomButton
		'
		Me.borderBottomButton.BackColor = System.Drawing.Color.White
		Me.borderBottomButton.BackgroundImage = CType(resources.GetObject("borderBottomButton.BackgroundImage"), System.Drawing.Image)
		Me.borderBottomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.borderBottomButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.borderBottomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.borderBottomButton.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.borderBottomButton.Location = New System.Drawing.Point(36, 4)
		Me.borderBottomButton.Name = "borderBottomButton"
		Me.borderBottomButton.Size = New System.Drawing.Size(29, 29)
		Me.borderBottomButton.TabIndex = 26
		Me.borderBottomButton.Text = "BB"
		Me.borderBottomButton.UseVisualStyleBackColor = False
		'
		'borderRightButton
		'
		Me.borderRightButton.BackColor = System.Drawing.Color.White
		Me.borderRightButton.BackgroundImage = CType(resources.GetObject("borderRightButton.BackgroundImage"), System.Drawing.Image)
		Me.borderRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.borderRightButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.borderRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.borderRightButton.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.borderRightButton.Location = New System.Drawing.Point(36, 39)
		Me.borderRightButton.Name = "borderRightButton"
		Me.borderRightButton.Size = New System.Drawing.Size(29, 29)
		Me.borderRightButton.TabIndex = 25
		Me.borderRightButton.Text = "BR"
		Me.borderRightButton.UseVisualStyleBackColor = False
		'
		'textControlPanel
		'
		Me.textControlPanel.BackColor = System.Drawing.SystemColors.ControlDark
		Me.textControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.textControlPanel.Controls.Add(Me.fontColorDropButton)
		Me.textControlPanel.Controls.Add(Me.fontColorButton)
		Me.textControlPanel.Controls.Add(Me.fontFamilyBox)
		Me.textControlPanel.Controls.Add(Me.alignJustifyButton)
		Me.textControlPanel.Controls.Add(Me.alignRightButton)
		Me.textControlPanel.Controls.Add(Me.alignCenterButton)
		Me.textControlPanel.Controls.Add(Me.alignLeftButton)
		Me.textControlPanel.Controls.Add(Me.fontUnitBox)
		Me.textControlPanel.Controls.Add(Me.underlineButton)
		Me.textControlPanel.Controls.Add(Me.italicButton)
		Me.textControlPanel.Controls.Add(Me.boldButton)
		Me.textControlPanel.Controls.Add(Me.fontSizeBox)
		Me.textControlPanel.Location = New System.Drawing.Point(0, 0)
		Me.textControlPanel.Name = "textControlPanel"
		Me.textControlPanel.Size = New System.Drawing.Size(294, 78)
		Me.textControlPanel.TabIndex = 40
		'
		'fontColorDropButton
		'
		Me.fontColorDropButton.BackColor = System.Drawing.SystemColors.Control
		Me.fontColorDropButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.fontColorDropButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.fontColorDropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.fontColorDropButton.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fontColorDropButton.ForeColor = System.Drawing.SystemColors.ControlDark
		Me.fontColorDropButton.Location = New System.Drawing.Point(270, 4)
		Me.fontColorDropButton.Name = "fontColorDropButton"
		Me.fontColorDropButton.Size = New System.Drawing.Size(15, 29)
		Me.fontColorDropButton.TabIndex = 33
		Me.fontColorDropButton.Text = "V"
		Me.fontColorDropButton.UseVisualStyleBackColor = False
		'
		'fontColorButton
		'
		Me.fontColorButton.BackColor = System.Drawing.SystemColors.Control
		Me.fontColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.fontColorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.fontColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.fontColorButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fontColorButton.Location = New System.Drawing.Point(198, 4)
		Me.fontColorButton.Name = "fontColorButton"
		Me.fontColorButton.Size = New System.Drawing.Size(73, 29)
		Me.fontColorButton.TabIndex = 32
		Me.fontColorButton.Text = "Font Color"
		Me.fontColorButton.UseVisualStyleBackColor = False
		'
		'fontFamilyBox
		'
		Me.fontFamilyBox.BackColor = System.Drawing.Color.White
		Me.fontFamilyBox.FormattingEnabled = True
		Me.fontFamilyBox.Items.AddRange(New Object() {"Arial", "Brush Script Mt", "Calibri (Body)", "Century", "Comic Sans MS", "Georgia", "Old English Text MT"})
		Me.fontFamilyBox.Location = New System.Drawing.Point(6, 11)
		Me.fontFamilyBox.Name = "fontFamilyBox"
		Me.fontFamilyBox.Size = New System.Drawing.Size(90, 21)
		Me.fontFamilyBox.TabIndex = 24
		'
		'alignJustifyButton
		'
		Me.alignJustifyButton.BackColor = System.Drawing.Color.White
		Me.alignJustifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.alignJustifyButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.alignJustifyButton.Image = CType(resources.GetObject("alignJustifyButton.Image"), System.Drawing.Image)
		Me.alignJustifyButton.Location = New System.Drawing.Point(208, 39)
		Me.alignJustifyButton.Name = "alignJustifyButton"
		Me.alignJustifyButton.Size = New System.Drawing.Size(26, 29)
		Me.alignJustifyButton.TabIndex = 23
		Me.alignJustifyButton.UseVisualStyleBackColor = False
		'
		'alignRightButton
		'
		Me.alignRightButton.BackColor = System.Drawing.Color.White
		Me.alignRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.alignRightButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.alignRightButton.Image = CType(resources.GetObject("alignRightButton.Image"), System.Drawing.Image)
		Me.alignRightButton.Location = New System.Drawing.Point(176, 39)
		Me.alignRightButton.Name = "alignRightButton"
		Me.alignRightButton.Size = New System.Drawing.Size(26, 29)
		Me.alignRightButton.TabIndex = 22
		Me.alignRightButton.UseVisualStyleBackColor = False
		'
		'alignCenterButton
		'
		Me.alignCenterButton.BackColor = System.Drawing.Color.White
		Me.alignCenterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.alignCenterButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.alignCenterButton.Image = CType(resources.GetObject("alignCenterButton.Image"), System.Drawing.Image)
		Me.alignCenterButton.Location = New System.Drawing.Point(144, 39)
		Me.alignCenterButton.Name = "alignCenterButton"
		Me.alignCenterButton.Size = New System.Drawing.Size(26, 29)
		Me.alignCenterButton.TabIndex = 21
		Me.alignCenterButton.UseVisualStyleBackColor = False
		'
		'alignLeftButton
		'
		Me.alignLeftButton.BackColor = System.Drawing.Color.White
		Me.alignLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.alignLeftButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.alignLeftButton.Image = CType(resources.GetObject("alignLeftButton.Image"), System.Drawing.Image)
		Me.alignLeftButton.Location = New System.Drawing.Point(112, 39)
		Me.alignLeftButton.Name = "alignLeftButton"
		Me.alignLeftButton.Size = New System.Drawing.Size(26, 29)
		Me.alignLeftButton.TabIndex = 20
		Me.alignLeftButton.UseVisualStyleBackColor = False
		'
		'fontUnitBox
		'
		Me.fontUnitBox.BackColor = System.Drawing.Color.White
		Me.fontUnitBox.FormattingEnabled = True
		Me.fontUnitBox.Items.AddRange(New Object() {"em", "px", "pt", "vw", "vh"})
		Me.fontUnitBox.Location = New System.Drawing.Point(153, 11)
		Me.fontUnitBox.Name = "fontUnitBox"
		Me.fontUnitBox.Size = New System.Drawing.Size(39, 21)
		Me.fontUnitBox.TabIndex = 19
		'
		'underlineButton
		'
		Me.underlineButton.BackColor = System.Drawing.SystemColors.Control
		Me.underlineButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.underlineButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.underlineButton.Location = New System.Drawing.Point(70, 39)
		Me.underlineButton.Name = "underlineButton"
		Me.underlineButton.Size = New System.Drawing.Size(26, 29)
		Me.underlineButton.TabIndex = 15
		Me.underlineButton.Text = "U"
		Me.underlineButton.UseVisualStyleBackColor = False
		'
		'italicButton
		'
		Me.italicButton.BackColor = System.Drawing.SystemColors.Control
		Me.italicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.italicButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.italicButton.Location = New System.Drawing.Point(38, 39)
		Me.italicButton.Name = "italicButton"
		Me.italicButton.Size = New System.Drawing.Size(26, 29)
		Me.italicButton.TabIndex = 14
		Me.italicButton.Text = "I"
		Me.italicButton.UseVisualStyleBackColor = False
		'
		'boldButton
		'
		Me.boldButton.BackColor = System.Drawing.SystemColors.Control
		Me.boldButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.boldButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.boldButton.Location = New System.Drawing.Point(6, 39)
		Me.boldButton.Name = "boldButton"
		Me.boldButton.Size = New System.Drawing.Size(26, 29)
		Me.boldButton.TabIndex = 13
		Me.boldButton.Text = "B"
		Me.boldButton.UseVisualStyleBackColor = False
		'
		'fontSizeBox
		'
		Me.fontSizeBox.DecimalPlaces = 1
		Me.fontSizeBox.Location = New System.Drawing.Point(102, 12)
		Me.fontSizeBox.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.fontSizeBox.Name = "fontSizeBox"
		Me.fontSizeBox.Size = New System.Drawing.Size(49, 22)
		Me.fontSizeBox.TabIndex = 11
		Me.fontSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'saveButton
		'
		Me.saveButton.BackColor = System.Drawing.SystemColors.Control
		Me.saveButton.BackgroundImage = Global.WorksheetGUI.My.Resources.Resources.FloppyDisc
		Me.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.saveButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.saveButton.Location = New System.Drawing.Point(817, 44)
		Me.saveButton.Name = "saveButton"
		Me.saveButton.Size = New System.Drawing.Size(26, 29)
		Me.saveButton.TabIndex = 17
		Me.saveButton.UseVisualStyleBackColor = False
		'
		'setHTML
		'
		Me.setHTML.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.setHTML.Location = New System.Drawing.Point(1360, 1)
		Me.setHTML.Name = "setHTML"
		Me.setHTML.Size = New System.Drawing.Size(68, 27)
		Me.setHTML.TabIndex = 16
		Me.setHTML.Text = "Set HTML"
		Me.setHTML.UseVisualStyleBackColor = True
		Me.setHTML.Visible = False
		'
		'currentElement
		'
		Me.currentElement.Dock = System.Windows.Forms.DockStyle.Fill
		Me.currentElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.currentElement.Location = New System.Drawing.Point(0, 0)
		Me.currentElement.Name = "currentElement"
		Me.currentElement.Size = New System.Drawing.Size(324, 76)
		Me.currentElement.TabIndex = 0
		Me.currentElement.Text = ""
		Me.currentElement.WordWrap = False
		'
		'editorBasicStyles
		'
		Me.editorBasicStyles.BackColor = System.Drawing.SystemColors.ControlDarkDark
		Me.editorBasicStyles.Controls.Add(Me.GroupBox4)
		Me.editorBasicStyles.Location = New System.Drawing.Point(4, 22)
		Me.editorBasicStyles.Name = "editorBasicStyles"
		Me.editorBasicStyles.Padding = New System.Windows.Forms.Padding(3)
		Me.editorBasicStyles.Size = New System.Drawing.Size(1239, 82)
		Me.editorBasicStyles.TabIndex = 3
		Me.editorBasicStyles.Text = "Basic CSS"
		'
		'GroupBox4
		'
		Me.GroupBox4.BackColor = System.Drawing.SystemColors.ControlDark
		Me.GroupBox4.Controls.Add(Me.basicStylesSilverButton)
		Me.GroupBox4.Controls.Add(Me.basicStyleButtonBlack)
		Me.GroupBox4.Controls.Add(Me.basicStyleButtonAnswer)
		Me.GroupBox4.Location = New System.Drawing.Point(3, 4)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(254, 75)
		Me.GroupBox4.TabIndex = 3
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "Common"
		'
		'basicStylesSilverButton
		'
		Me.basicStylesSilverButton.BackColor = System.Drawing.Color.Silver
		Me.basicStylesSilverButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.basicStylesSilverButton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.basicStylesSilverButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.basicStylesSilverButton.Location = New System.Drawing.Point(87, 16)
		Me.basicStylesSilverButton.Name = "basicStylesSilverButton"
		Me.basicStylesSilverButton.Size = New System.Drawing.Size(75, 23)
		Me.basicStylesSilverButton.TabIndex = 2
		Me.basicStylesSilverButton.Text = "Silver"
		Me.basicStylesSilverButton.UseVisualStyleBackColor = False
		'
		'basicStyleButtonBlack
		'
		Me.basicStyleButtonBlack.BackColor = System.Drawing.Color.Black
		Me.basicStyleButtonBlack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.basicStyleButtonBlack.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.basicStyleButtonBlack.ForeColor = System.Drawing.Color.White
		Me.basicStyleButtonBlack.Location = New System.Drawing.Point(6, 45)
		Me.basicStyleButtonBlack.Name = "basicStyleButtonBlack"
		Me.basicStyleButtonBlack.Size = New System.Drawing.Size(75, 23)
		Me.basicStyleButtonBlack.TabIndex = 1
		Me.basicStyleButtonBlack.Text = "Black"
		Me.basicStyleButtonBlack.UseVisualStyleBackColor = False
		'
		'basicStyleButtonAnswer
		'
		Me.basicStyleButtonAnswer.BackColor = System.Drawing.SystemColors.Control
		Me.basicStyleButtonAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.basicStyleButtonAnswer.Font = New System.Drawing.Font("Segoe UI", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.basicStyleButtonAnswer.Location = New System.Drawing.Point(6, 16)
		Me.basicStyleButtonAnswer.Name = "basicStyleButtonAnswer"
		Me.basicStyleButtonAnswer.Size = New System.Drawing.Size(75, 23)
		Me.basicStyleButtonAnswer.TabIndex = 0
		Me.basicStyleButtonAnswer.Text = "   Answer   "
		Me.basicStyleButtonAnswer.UseVisualStyleBackColor = False
		'
		'editorTableTab
		'
		Me.editorTableTab.BackColor = System.Drawing.SystemColors.ControlDarkDark
		Me.editorTableTab.Controls.Add(Me.htmlTabPageCellBox)
		Me.editorTableTab.Controls.Add(Me.htmlTabPageRowBox)
		Me.editorTableTab.Controls.Add(Me.htmlTabPageColumnBox)
		Me.editorTableTab.Controls.Add(Me.htmlTabPageTableBox)
		Me.editorTableTab.Location = New System.Drawing.Point(4, 22)
		Me.editorTableTab.Name = "editorTableTab"
		Me.editorTableTab.Padding = New System.Windows.Forms.Padding(3)
		Me.editorTableTab.Size = New System.Drawing.Size(1239, 82)
		Me.editorTableTab.TabIndex = 2
		Me.editorTableTab.Text = "HTML Table"
		'
		'htmlTabPageCellBox
		'
		Me.htmlTabPageCellBox.BackColor = System.Drawing.SystemColors.ControlDark
		Me.htmlTabPageCellBox.Controls.Add(Me.colspanBox)
		Me.htmlTabPageCellBox.Controls.Add(Me.rowspanBox)
		Me.htmlTabPageCellBox.Controls.Add(Me.Label13)
		Me.htmlTabPageCellBox.Controls.Add(Me.Label12)
		Me.htmlTabPageCellBox.Location = New System.Drawing.Point(712, 4)
		Me.htmlTabPageCellBox.Name = "htmlTabPageCellBox"
		Me.htmlTabPageCellBox.Size = New System.Drawing.Size(253, 75)
		Me.htmlTabPageCellBox.TabIndex = 5
		Me.htmlTabPageCellBox.TabStop = False
		Me.htmlTabPageCellBox.Text = "Cell"
		'
		'colspanBox
		'
		Me.colspanBox.Location = New System.Drawing.Point(85, 11)
		Me.colspanBox.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.colspanBox.Name = "colspanBox"
		Me.colspanBox.Size = New System.Drawing.Size(40, 22)
		Me.colspanBox.TabIndex = 35
		Me.colspanBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'rowspanBox
		'
		Me.rowspanBox.Location = New System.Drawing.Point(85, 35)
		Me.rowspanBox.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
		Me.rowspanBox.Name = "rowspanBox"
		Me.rowspanBox.Size = New System.Drawing.Size(40, 22)
		Me.rowspanBox.TabIndex = 36
		Me.rowspanBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.Location = New System.Drawing.Point(6, 36)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(59, 15)
		Me.Label13.TabIndex = 38
		Me.Label13.Text = "RowSpan"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(6, 12)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(51, 15)
		Me.Label12.TabIndex = 37
		Me.Label12.Text = "ColSpan"
		'
		'htmlTabPageRowBox
		'
		Me.htmlTabPageRowBox.BackColor = System.Drawing.SystemColors.ControlDark
		Me.htmlTabPageRowBox.Location = New System.Drawing.Point(556, 4)
		Me.htmlTabPageRowBox.Name = "htmlTabPageRowBox"
		Me.htmlTabPageRowBox.Size = New System.Drawing.Size(150, 75)
		Me.htmlTabPageRowBox.TabIndex = 4
		Me.htmlTabPageRowBox.TabStop = False
		Me.htmlTabPageRowBox.Text = "Row"
		'
		'htmlTabPageColumnBox
		'
		Me.htmlTabPageColumnBox.BackColor = System.Drawing.SystemColors.ControlDark
		Me.htmlTabPageColumnBox.Controls.Add(Me.columnInsertLeft)
		Me.htmlTabPageColumnBox.Controls.Add(Me.columnInsertRight)
		Me.htmlTabPageColumnBox.Location = New System.Drawing.Point(297, 4)
		Me.htmlTabPageColumnBox.Name = "htmlTabPageColumnBox"
		Me.htmlTabPageColumnBox.Size = New System.Drawing.Size(253, 75)
		Me.htmlTabPageColumnBox.TabIndex = 3
		Me.htmlTabPageColumnBox.TabStop = False
		Me.htmlTabPageColumnBox.Text = "Column"
		'
		'columnInsertLeft
		'
		Me.columnInsertLeft.BackColor = System.Drawing.SystemColors.Control
		Me.columnInsertLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.columnInsertLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.columnInsertLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.columnInsertLeft.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.columnInsertLeft.Location = New System.Drawing.Point(6, 41)
		Me.columnInsertLeft.Name = "columnInsertLeft"
		Me.columnInsertLeft.Size = New System.Drawing.Size(82, 29)
		Me.columnInsertLeft.TabIndex = 31
		Me.columnInsertLeft.Text = "Insert Left"
		Me.columnInsertLeft.UseVisualStyleBackColor = False
		'
		'columnInsertRight
		'
		Me.columnInsertRight.BackColor = System.Drawing.SystemColors.Control
		Me.columnInsertRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.columnInsertRight.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.columnInsertRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.columnInsertRight.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.columnInsertRight.Location = New System.Drawing.Point(94, 41)
		Me.columnInsertRight.Name = "columnInsertRight"
		Me.columnInsertRight.Size = New System.Drawing.Size(82, 29)
		Me.columnInsertRight.TabIndex = 30
		Me.columnInsertRight.Text = "Insert Right"
		Me.columnInsertRight.UseVisualStyleBackColor = False
		'
		'htmlTabPageTableBox
		'
		Me.htmlTabPageTableBox.BackColor = System.Drawing.SystemColors.ControlDark
		Me.htmlTabPageTableBox.Controls.Add(Me.Label17)
		Me.htmlTabPageTableBox.Controls.Add(Me.htmlTableColumns)
		Me.htmlTabPageTableBox.Controls.Add(Me.Label2)
		Me.htmlTabPageTableBox.Controls.Add(Me.ComboBox1)
		Me.htmlTabPageTableBox.Controls.Add(Me.NumericUpDown1)
		Me.htmlTabPageTableBox.Controls.Add(Me.ComboBox2)
		Me.htmlTabPageTableBox.Controls.Add(Me.tableWidthBox)
		Me.htmlTabPageTableBox.Controls.Add(Me.Button6)
		Me.htmlTabPageTableBox.Controls.Add(Me.Button7)
		Me.htmlTabPageTableBox.Controls.Add(Me.Button8)
		Me.htmlTabPageTableBox.Controls.Add(Me.Button9)
		Me.htmlTabPageTableBox.Location = New System.Drawing.Point(4, 4)
		Me.htmlTabPageTableBox.Name = "htmlTabPageTableBox"
		Me.htmlTabPageTableBox.Size = New System.Drawing.Size(287, 75)
		Me.htmlTabPageTableBox.TabIndex = 2
		Me.htmlTabPageTableBox.TabStop = False
		Me.htmlTabPageTableBox.Text = "Table"
		'
		'Label17
		'
		Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label17.Location = New System.Drawing.Point(2, 48)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(63, 21)
		Me.Label17.TabIndex = 54
		Me.Label17.Text = "Columns"
		'
		'htmlTableColumns
		'
		Me.htmlTableColumns.Location = New System.Drawing.Point(60, 47)
		Me.htmlTableColumns.Maximum = New Decimal(New Integer() {980, 0, 0, 0})
		Me.htmlTableColumns.Name = "htmlTableColumns"
		Me.htmlTableColumns.Size = New System.Drawing.Size(49, 22)
		Me.htmlTableColumns.TabIndex = 53
		Me.htmlTableColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(138, 14)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(51, 33)
		Me.Label2.TabIndex = 52
		Me.Label2.Text = "Width / Height"
		'
		'ComboBox1
		'
		Me.ComboBox1.BackColor = System.Drawing.Color.White
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Items.AddRange(New Object() {"em", "px", "pt", "vw", "vh", "%"})
		Me.ComboBox1.Location = New System.Drawing.Point(240, 36)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(39, 21)
		Me.ComboBox1.TabIndex = 51
		Me.ComboBox1.Text = "px"
		'
		'NumericUpDown1
		'
		Me.NumericUpDown1.DecimalPlaces = 1
		Me.NumericUpDown1.Location = New System.Drawing.Point(189, 37)
		Me.NumericUpDown1.Maximum = New Decimal(New Integer() {980, 0, 0, 0})
		Me.NumericUpDown1.Name = "NumericUpDown1"
		Me.NumericUpDown1.Size = New System.Drawing.Size(49, 22)
		Me.NumericUpDown1.TabIndex = 50
		Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'ComboBox2
		'
		Me.ComboBox2.BackColor = System.Drawing.Color.White
		Me.ComboBox2.FormattingEnabled = True
		Me.ComboBox2.Items.AddRange(New Object() {"em", "px", "pt", "vw", "vh", "%"})
		Me.ComboBox2.Location = New System.Drawing.Point(240, 12)
		Me.ComboBox2.Name = "ComboBox2"
		Me.ComboBox2.Size = New System.Drawing.Size(39, 21)
		Me.ComboBox2.TabIndex = 49
		Me.ComboBox2.Text = "px"
		'
		'tableWidthBox
		'
		Me.tableWidthBox.DecimalPlaces = 1
		Me.tableWidthBox.Location = New System.Drawing.Point(189, 13)
		Me.tableWidthBox.Maximum = New Decimal(New Integer() {980, 0, 0, 0})
		Me.tableWidthBox.Name = "tableWidthBox"
		Me.tableWidthBox.Size = New System.Drawing.Size(49, 22)
		Me.tableWidthBox.TabIndex = 48
		Me.tableWidthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Button6
		'
		Me.Button6.BackColor = System.Drawing.Color.White
		Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
		Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Button6.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button6.Location = New System.Drawing.Point(71, 14)
		Me.Button6.Name = "Button6"
		Me.Button6.Size = New System.Drawing.Size(29, 29)
		Me.Button6.TabIndex = 43
		Me.Button6.Text = "BL"
		Me.Button6.UseVisualStyleBackColor = False
		'
		'Button7
		'
		Me.Button7.BackColor = System.Drawing.Color.White
		Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
		Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Button7.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button7.Location = New System.Drawing.Point(4, 14)
		Me.Button7.Name = "Button7"
		Me.Button7.Size = New System.Drawing.Size(29, 29)
		Me.Button7.TabIndex = 42
		Me.Button7.Text = "BT"
		Me.Button7.UseVisualStyleBackColor = False
		'
		'Button8
		'
		Me.Button8.BackColor = System.Drawing.Color.White
		Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
		Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Button8.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button8.Location = New System.Drawing.Point(36, 14)
		Me.Button8.Name = "Button8"
		Me.Button8.Size = New System.Drawing.Size(29, 29)
		Me.Button8.TabIndex = 41
		Me.Button8.Text = "BB"
		Me.Button8.UseVisualStyleBackColor = False
		'
		'Button9
		'
		Me.Button9.BackColor = System.Drawing.Color.White
		Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
		Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Button9.FlatAppearance.BorderColor = System.Drawing.Color.Black
		Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Button9.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button9.Location = New System.Drawing.Point(103, 14)
		Me.Button9.Name = "Button9"
		Me.Button9.Size = New System.Drawing.Size(29, 29)
		Me.Button9.TabIndex = 40
		Me.Button9.Text = "BR"
		Me.Button9.UseVisualStyleBackColor = False
		'
		'openForEditDialog
		'
		Me.openForEditDialog.DefaultExt = "xslt"
		Me.openForEditDialog.RestoreDirectory = True
		'
		'textPrintDelay
		'
		Me.textPrintDelay.Interval = 10
		'
		'createNewTablePanel
		'
		Me.createNewTablePanel.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.createNewTablePanel.BackColor = System.Drawing.SystemColors.ControlLight
		Me.createNewTablePanel.Controls.Add(Me.createNewTableButton)
		Me.createNewTablePanel.Controls.Add(Me.newTableColumns)
		Me.createNewTablePanel.Controls.Add(Me.newTableRows)
		Me.createNewTablePanel.Controls.Add(Me.Label4)
		Me.createNewTablePanel.Controls.Add(Me.Label3)
		Me.createNewTablePanel.Location = New System.Drawing.Point(935, 112)
		Me.createNewTablePanel.Name = "createNewTablePanel"
		Me.createNewTablePanel.Size = New System.Drawing.Size(144, 78)
		Me.createNewTablePanel.TabIndex = 13
		Me.createNewTablePanel.Visible = False
		'
		'createNewTableButton
		'
		Me.createNewTableButton.BackColor = System.Drawing.Color.MediumBlue
		Me.createNewTableButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.createNewTableButton.ForeColor = System.Drawing.Color.White
		Me.createNewTableButton.Location = New System.Drawing.Point(21, 54)
		Me.createNewTableButton.Name = "createNewTableButton"
		Me.createNewTableButton.Size = New System.Drawing.Size(108, 23)
		Me.createNewTableButton.TabIndex = 4
		Me.createNewTableButton.Text = "Create!"
		Me.createNewTableButton.UseVisualStyleBackColor = False
		'
		'newTableColumns
		'
		Me.newTableColumns.Location = New System.Drawing.Point(83, 32)
		Me.newTableColumns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.newTableColumns.Name = "newTableColumns"
		Me.newTableColumns.Size = New System.Drawing.Size(58, 20)
		Me.newTableColumns.TabIndex = 3
		Me.newTableColumns.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'newTableRows
		'
		Me.newTableRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.newTableRows.Location = New System.Drawing.Point(83, 6)
		Me.newTableRows.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.newTableRows.Name = "newTableRows"
		Me.newTableRows.Size = New System.Drawing.Size(58, 20)
		Me.newTableRows.TabIndex = 2
		Me.newTableRows.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Label4
		'
		Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Label4.Location = New System.Drawing.Point(3, 29)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(74, 23)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Columns:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label3
		'
		Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.Label3.Location = New System.Drawing.Point(3, 3)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(74, 23)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Rows:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'openBGPicture
		'
		Me.openBGPicture.Filter = "Images|*.*"
		Me.openBGPicture.Title = "Open your desired background image."
		'
		'htmlBGColorPicker
		'
		Me.htmlBGColorPicker.AnyColor = True
		Me.htmlBGColorPicker.FullOpen = True
		Me.htmlBGColorPicker.SolidColorOnly = True
		'
		'htmlFontColorPicker
		'
		Me.htmlFontColorPicker.AnyColor = True
		Me.htmlFontColorPicker.FullOpen = True
		Me.htmlFontColorPicker.SolidColorOnly = True
		'
		'cursorPositionTimer
		'
		Me.cursorPositionTimer.Enabled = True
		Me.cursorPositionTimer.Interval = 50
		'
		'TypingCountdown
		'
		Me.TypingCountdown.Interval = 2000
		'
		'DoubleClickTimer
		'
		Me.DoubleClickTimer.Interval = 150
		'
		'LeftToolStrip
		'
		Me.LeftToolStrip.BackColor = System.Drawing.SystemColors.Control
		Me.LeftToolStrip.Dock = System.Windows.Forms.DockStyle.Left
		Me.LeftToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.LeftToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.displayStyleButton, Me.autoRefreshButton, Me.previewPageBreaksButton, Me.viewSourceButton, Me.editModeButton, Me.ToolStripSeparator3, Me.chromepreviewbutton, Me.ToolStripSeparator4, Me.overlayModeButton, Me.ViewTagCreatorButton, Me.ToolStripSeparator5, Me.TakeScreenshot})
		Me.LeftToolStrip.Location = New System.Drawing.Point(0, 0)
		Me.LeftToolStrip.MinimumSize = New System.Drawing.Size(75, 50)
		Me.LeftToolStrip.Name = "LeftToolStrip"
		Me.LeftToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		Me.LeftToolStrip.Size = New System.Drawing.Size(112, 272)
		Me.LeftToolStrip.TabIndex = 3
		Me.LeftToolStrip.Text = "ToolStrip1"
		'
		'displayStyleButton
		'
		Me.displayStyleButton.AutoSize = False
		Me.displayStyleButton.AutoToolTip = False
		Me.displayStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.displayStyleButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.displayStyleButton.Name = "displayStyleButton"
		Me.displayStyleButton.Size = New System.Drawing.Size(75, 19)
		Me.displayStyleButton.Text = "Portrait"
		Me.displayStyleButton.ToolTipText = "This indicates what document type the preview is currently rendering at. The opti" &
	"ons are Portrait, Landscape, Legal, and None."
		'
		'autoRefreshButton
		'
		Me.autoRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.autoRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.autoRefreshButton.Name = "autoRefreshButton"
		Me.autoRefreshButton.Size = New System.Drawing.Size(109, 19)
		Me.autoRefreshButton.Text = "Auto Refresh"
		Me.autoRefreshButton.ToolTipText = "If active, this will periodically refresh your document. "
		'
		'previewPageBreaksButton
		'
		Me.previewPageBreaksButton.AutoToolTip = False
		Me.previewPageBreaksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.previewPageBreaksButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.previewPageBreaksButton.Name = "previewPageBreaksButton"
		Me.previewPageBreaksButton.Size = New System.Drawing.Size(109, 19)
		Me.previewPageBreaksButton.Text = "Page Breaks"
		Me.previewPageBreaksButton.ToolTipText = "Preview the page breaks  in the document. "
		'
		'viewSourceButton
		'
		Me.viewSourceButton.AutoToolTip = False
		Me.viewSourceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.viewSourceButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.viewSourceButton.Name = "viewSourceButton"
		Me.viewSourceButton.Size = New System.Drawing.Size(109, 19)
		Me.viewSourceButton.Text = "View Source"
		Me.viewSourceButton.ToolTipText = "Shows the transformed Source Code that results from performing the XSLT trasnform" &
	"ation specifled in your file."
		'
		'editModeButton
		'
		Me.editModeButton.AutoToolTip = False
		Me.editModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.editModeButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.editModeButton.Name = "editModeButton"
		Me.editModeButton.Size = New System.Drawing.Size(109, 19)
		Me.editModeButton.Text = "Design Mode"
		Me.editModeButton.ToolTipText = "Activates the edit mode."
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(109, 6)
		'
		'chromepreviewbutton
		'
		Me.chromepreviewbutton.BackColor = System.Drawing.SystemColors.ControlLight
		Me.chromepreviewbutton.Image = CType(resources.GetObject("chromepreviewbutton.Image"), System.Drawing.Image)
		Me.chromepreviewbutton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.chromepreviewbutton.Name = "chromepreviewbutton"
		Me.chromepreviewbutton.Size = New System.Drawing.Size(109, 35)
		Me.chromepreviewbutton.Text = "Preview in Chrome"
		Me.chromepreviewbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
		'
		'ToolStripSeparator4
		'
		Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
		Me.ToolStripSeparator4.Size = New System.Drawing.Size(109, 6)
		'
		'overlayModeButton
		'
		Me.overlayModeButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.overlayModeButton.Name = "overlayModeButton"
		Me.overlayModeButton.Size = New System.Drawing.Size(109, 19)
		Me.overlayModeButton.Text = "Overlay Mode"
		Me.overlayModeButton.Visible = False
		'
		'ViewTagCreatorButton
		'
		Me.ViewTagCreatorButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ViewTagCreatorButton.BackColor = System.Drawing.SystemColors.Control
		Me.ViewTagCreatorButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ViewTagCreatorButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ViewTagCreatorButton.Name = "ViewTagCreatorButton"
		Me.ViewTagCreatorButton.Size = New System.Drawing.Size(109, 19)
		Me.ViewTagCreatorButton.Text = "View Tag Creator"
		Me.ViewTagCreatorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
		'
		'ToolStripSeparator5
		'
		Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
		Me.ToolStripSeparator5.Size = New System.Drawing.Size(109, 6)
		'
		'TakeScreenshot
		'
		Me.TakeScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.TakeScreenshot.Name = "TakeScreenshot"
		Me.TakeScreenshot.Size = New System.Drawing.Size(109, 19)
		Me.TakeScreenshot.Text = "Screenshot Button"
		'
		'LeftSplitContainer
		'
		Me.LeftSplitContainer.BackColor = System.Drawing.SystemColors.Control
		Me.LeftSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Left
		Me.LeftSplitContainer.Location = New System.Drawing.Point(0, 135)
		Me.LeftSplitContainer.Name = "LeftSplitContainer"
		Me.LeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'LeftSplitContainer.Panel1
		'
		Me.LeftSplitContainer.Panel1.Controls.Add(Me.LeftToolStrip)
		Me.LeftSplitContainer.Size = New System.Drawing.Size(112, 651)
		Me.LeftSplitContainer.SplitterDistance = 274
		Me.LeftSplitContainer.SplitterWidth = 5
		Me.LeftSplitContainer.TabIndex = 3
		'
		'wsGUIWindow
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Silver
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.ClientSize = New System.Drawing.Size(1247, 808)
		Me.Controls.Add(Me.LeftSplitContainer)
		Me.Controls.Add(Me.createNewTablePanel)
		Me.Controls.Add(Me.editorToolPanel)
		Me.Controls.Add(Me.displayAreaSourceBoxRich)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.displayArea1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Controls.Add(Me.displayAreaSourceWindow)
		Me.Controls.Add(Me.displayAreaSourceBox)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "wsGUIWindow"
		Me.Text = "Worksheet Previewer"
		Me.TransparencyKey = System.Drawing.Color.Tomato
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.editorToolPanel.ResumeLayout(False)
		Me.editorTabControl.ResumeLayout(False)
		Me.editorGeneralTools.ResumeLayout(False)
		Me.editorSplitPanel.Panel1.ResumeLayout(False)
		Me.editorSplitPanel.Panel2.ResumeLayout(False)
		CType(Me.editorSplitPanel, System.ComponentModel.ISupportInitialize).EndInit()
		Me.editorSplitPanel.ResumeLayout(False)
		Me.editorSplitSubPanel.ResumeLayout(False)
		Me.blockElementControlPanel.ResumeLayout(False)
		CType(Me.heightBox, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.widthBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.textControlPanel.ResumeLayout(False)
		CType(Me.fontSizeBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.editorBasicStyles.ResumeLayout(False)
		Me.GroupBox4.ResumeLayout(False)
		Me.editorTableTab.ResumeLayout(False)
		Me.htmlTabPageCellBox.ResumeLayout(False)
		Me.htmlTabPageCellBox.PerformLayout()
		CType(Me.colspanBox, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.rowspanBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.htmlTabPageColumnBox.ResumeLayout(False)
		Me.htmlTabPageTableBox.ResumeLayout(False)
		CType(Me.htmlTableColumns, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tableWidthBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.createNewTablePanel.ResumeLayout(False)
		CType(Me.newTableColumns, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.newTableRows, System.ComponentModel.ISupportInitialize).EndInit()
		Me.LeftToolStrip.ResumeLayout(False)
		Me.LeftToolStrip.PerformLayout()
		Me.LeftSplitContainer.Panel1.ResumeLayout(False)
		Me.LeftSplitContainer.Panel1.PerformLayout()
		CType(Me.LeftSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
		Me.LeftSplitContainer.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents NewWorksheetPairToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents newStandaloneFormButton As ToolStripMenuItem
	Friend WithEvents DealPackToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents openWorksheetOption As ToolStripMenuItem
	Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents openWorksheetDialog As OpenFileDialog
	Friend WithEvents FormDisplayStyleToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents saveWorksheetDialog As SaveFileDialog
	Friend WithEvents showStatus As ToolStripStatusLabel
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents refreshButton As ToolStripMenuItem
	Friend WithEvents colorPicker As ColorDialog
	Friend WithEvents refreshTimer As Timer
	Friend WithEvents openXMLOption As ToolStripMenuItem
	Friend WithEvents openXMLDialog As OpenFileDialog
	Friend WithEvents displayAreaSourceWindow As WebBrowser
	Friend WithEvents displayAreaSourceBox As TextBox
	Friend WithEvents displayAreaSourceBoxRich As RichTextBox
	Friend WithEvents ToolStripContainer1 As ToolStripContainer
	Friend WithEvents displayArea1 As WebBrowser
	Friend WithEvents TextEditorToolsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents editorToolPanel As Panel
	Friend WithEvents openForEdit As ToolStripMenuItem
	Friend WithEvents openForEditDialog As OpenFileDialog
	Friend WithEvents editorSplitPanel As SplitContainer
	Friend WithEvents underlineButton As Button
	Friend WithEvents italicButton As Button
	Friend WithEvents boldButton As Button
	Friend WithEvents fontSizeBox As NumericUpDown
	Friend WithEvents currentElement As RichTextBox
	Friend WithEvents setHTML As Button
	Friend WithEvents saveButton As Button
	Friend WithEvents blorp As Button
	Friend WithEvents textPrintDelay As Timer
	Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents fontUnitBox As ComboBox
	Friend WithEvents alignJustifyButton As Button
	Friend WithEvents alignRightButton As Button
	Friend WithEvents alignCenterButton As Button
	Friend WithEvents alignLeftButton As Button
	Friend WithEvents fontFamilyBox As ComboBox
	Friend WithEvents borderLeftButton As Button
	Friend WithEvents borderTopButton As Button
	Friend WithEvents borderBottomButton As Button
	Friend WithEvents borderRightButton As Button
	Friend WithEvents createNewTablePanel As Panel
	Friend WithEvents newTableColumns As NumericUpDown
	Friend WithEvents newTableRows As NumericUpDown
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents createNewTableButton As Button
	Friend WithEvents openBGPicture As OpenFileDialog
	Friend WithEvents UndoAllChangesToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents quickLoadButton As ToolStripMenuItem
	Friend WithEvents htmlBGColorPicker As ColorDialog
	Friend WithEvents paddingButton As Button
	Friend WithEvents bgColorDropButton As Button
	Friend WithEvents bgColorButtonHTML As Button
	Friend WithEvents htmlFontColorPicker As ColorDialog
	Friend WithEvents fontColorDropButton As Button
	Friend WithEvents fontColorButton As Button
	Friend WithEvents marginButton As Button
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Label13 As Label
	Friend WithEvents Label12 As Label
	Friend WithEvents rowspanBox As NumericUpDown
	Friend WithEvents colspanBox As NumericUpDown
	Friend WithEvents CloseCurrentFileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents textControlPanel As Panel
	Friend WithEvents blockElementControlPanel As Panel
	Friend WithEvents cursorPositionLabel As ToolStripStatusLabel
	Friend WithEvents cursorPositionTimer As Timer
	Friend WithEvents pageBottomIndicatorLabel As ToolStripStatusLabel
	Friend WithEvents Label14 As Label
	Friend WithEvents heightUnitBox As ComboBox
	Friend WithEvents heightBox As NumericUpDown
	Friend WithEvents widthUnitBox As ComboBox
	Friend WithEvents widthBox As NumericUpDown
	Friend WithEvents editorSplitSubPanel As Panel
	Friend WithEvents undoButton As ToolStripMenuItem
	Friend WithEvents redoButton As ToolStripMenuItem
	Friend WithEvents editorTabControl As TabControl
	Friend WithEvents editorGeneralTools As TabPage
	Friend WithEvents editorTableTab As TabPage
	Friend WithEvents htmlTabPageRowBox As GroupBox
	Friend WithEvents htmlTabPageColumnBox As GroupBox
	Friend WithEvents htmlTabPageTableBox As GroupBox
	Friend WithEvents ChooseStoreToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents TypingCountdown As Timer
	Friend WithEvents editorBasicStyles As TabPage
	Friend WithEvents GroupBox4 As GroupBox
	Friend WithEvents basicStylesSilverButton As Button
	Friend WithEvents basicStyleButtonBlack As Button
	Friend WithEvents basicStyleButtonAnswer As Button
	Friend WithEvents DoubleClickTimer As Timer
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
	Friend WithEvents ConversionsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ConvertToAppSchemaToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ConvertFromAppSchemaToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents MakeFormEditableToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ConvertExcelButton As ToolStripMenuItem
	Friend WithEvents ImageOverlayWorksheetToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents UpdateOldCodeToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents CreateBodyForCreditAppButtonFormToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Label2 As Label
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents NumericUpDown1 As NumericUpDown
	Friend WithEvents ComboBox2 As ComboBox
	Friend WithEvents tableWidthBox As NumericUpDown
	Friend WithEvents Button6 As Button
	Friend WithEvents Button7 As Button
	Friend WithEvents Button8 As Button
	Friend WithEvents Button9 As Button
	Friend WithEvents Label17 As Label
	Friend WithEvents htmlTableColumns As NumericUpDown
	Friend WithEvents htmlTabPageCellBox As GroupBox
	Friend WithEvents columnInsertRight As Button
	Friend WithEvents columnInsertLeft As Button
	Friend WithEvents lCompanyIDInput As ToolStripComboBox
	Friend WithEvents dealPackInsertionButton As ToolStripMenuItem
	Friend WithEvents FixSpecialCharactersToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SalesQuoteCalculationTypeBox As ToolStripComboBox
	Friend WithEvents ConvertSavedImageToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents LeftToolStrip As ToolStrip
	Friend WithEvents displayStyleButton As ToolStripButton
	Friend WithEvents autoRefreshButton As ToolStripButton
	Friend WithEvents previewPageBreaksButton As ToolStripButton
	Friend WithEvents viewSourceButton As ToolStripButton
	Friend WithEvents editModeButton As ToolStripButton
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents chromepreviewbutton As ToolStripButton
	Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
	Friend WithEvents overlayModeButton As ToolStripButton
	Friend WithEvents ViewTagCreatorButton As ToolStripButton
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents TakeScreenshot As ToolStripButton
	Friend WithEvents LeftSplitContainer As SplitContainer
End Class
