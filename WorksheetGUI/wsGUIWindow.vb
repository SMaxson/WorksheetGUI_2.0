Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Web.UI.HtmlControls
Imports mshtml
Imports System.Text.RegularExpressions

Public Class wsGUIWindow
	Public Shared refreshRate As Integer = 3000
	Public Shared autoRefresh As Boolean
	Public Shared bgColor As Color
	Public Shared bgImage As String = ""
	Public Shared supressScriptErrors As Boolean
	Public banksyInputFile As XmlDocument = New XmlDocument
	Public colorButton As Color = Color.DeepSkyBlue
	Public colorGray1 As Color = Color.Gainsboro
	Public colorGray2 As Color = SystemColors.Control
	Public colorGray3 As Color = SystemColors.ControlLight
	Public colorGray4 As Color = Color.Silver
	Public colorGray5 As Color = SystemColors.ControlDark
	Public colorText As Color = SystemColors.ControlText
	Public WithEvents displayArea As New WSWebbrowser
	Public WithEvents cefBrowser As CefSharp.WinForms.ChromiumWebBrowser
	Public WithEvents codingBuddy As New CodingBuddyControl
	Public displayStyle As Integer = 1
	Public groupDictionary As New Dictionary(Of String, String)
	Public overlayMode As Boolean = False
	Public pathDictionary As New Dictionary(Of String, String)
	Public previewPageBreaks As Boolean
	Public targetElement As System.Windows.Forms.HtmlElement
	Public targetXSL As String
	Public targetWorksheet As New Worksheet.ShellFile
	Public unsavedChanges As Boolean = False
	Dim activeElementHTML As String
	Public BorderWidth As Integer
	Dim classGenerator As ClassGenerator = Nothing
	Private currentElementEditEnabled As Boolean = True
	Dim displayWidth As Integer = 750
	Dim WithEvents doc As System.Windows.Forms.HtmlDocument
	Dim editMode As Boolean
	Dim elementChanged As Boolean = False
	Dim elementBackup As String = ""
	Dim erFile As String
	Dim erFolder As String
	Dim erLine As String
	Dim erPos As String
	Dim erSourceURI As String
	Dim errorMessage As String
	Dim newFileType As Integer = 1
	Dim newStoreID As String = "1"
	Dim newStoreName As String = ""
	Dim outputBodyFileName As String
	Dim originalPos As Point
	Dim originalSize As Size
	Dim currentPos As Point
	Dim currentSize As Size
	Dim outputXSL As String
	Dim parentElementHTML As String = ""
	Dim manualChangeElement As System.Windows.Forms.HtmlElement
	Dim _skipPreviewKeyDown As Boolean = False
	Dim Settings As XsltSettings = New XsltSettings(True, True)
	Dim settingsDirectory As String
	Dim settingsFile As XmlDocument
	Dim styleGenerator As StyleGenerator = Nothing
	Dim WithEvents tagCreator As New TagCreator
	Dim targetBody As String
	Dim targetBodyContent As String
	Dim targetXML As String
	Public TitlebarHeight As Integer
	Dim undoHistory As UndoStack = New UndoStack
	Dim xmlresolver As New System.Xml.XmlUrlResolver
	Dim xslt As New XslCompiledTransform()
	Dim xslEditableTagDictionary As New Dictionary(Of String, String)
	Dim xslTagDictionary As New Dictionary(Of String, String)
	Dim xslValueOfDictionary As New Dictionary(Of Integer, String)
	Dim xslIfDictionary As New Dictionary(Of Integer, String)
	Dim xslChooseDictionary As New Dictionary(Of Integer, String)
	Dim WithEvents documentScroll As mshtml.HTMLWindow2
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Controls.Add(displayArea)
		editorToolPanel.BringToFront()
		LeftSplitContainer.SendToBack()
		StatusStrip1.SendToBack()
		MainMenuStrip.SendToBack()
		BorderWidth = (Me.Width - Me.ClientSize.Width) / 2
		TitlebarHeight = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
		bgColor = Color.FromArgb(0, 64, 128)
		targetXML = "C:\Projects\WorksheetsGit\Worksheets\Test\WorksheetTestWithCreditApp.xml"
		targetXSL = "C:\Projects\WorksheetsGit\Worksheets\FoxValleyFord\FoxValleyFord_PurchaseAgreement.xslt"
		openWorksheetDialog.Filter = "xslt files (*.xslt)|*.xslt|All files (*.*)|*.*"
		openWorksheetDialog.FilterIndex = 1
		autoRefresh = False
		previewPageBreaks = False
		editMode = False
		supressScriptErrors = True
		settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\UserSettings.xml")
		For Each line As String In IO.File.ReadAllLines("C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\groupDictionary.txt")
			Dim parts() As String = line.Split("~")
			groupDictionary.Add(parts(0), parts(1))
		Next
		For Each line As String In IO.File.ReadAllLines("C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\pathDictionary.txt")
			Dim parts() As String = line.Split("~")
			pathDictionary.Add(parts(0), parts(1))
		Next
		For Each line As String In IO.File.ReadAllLines("C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\dealershipList.txt")
			Dim parts() As String = line.Split("~")
			lCompanyIDInput.Items.Add(String.Format("{0}", parts(1)))
		Next

		If System.IO.File.Exists(settingsDirectory) Then
			settingsFile = New XmlDocument
			settingsFile.Load(settingsDirectory)
			Dim root As XmlNode = settingsFile.DocumentElement
			refreshRate = Integer.Parse(root.SelectSingleNode("RefreshRate").InnerText)
			refreshTimer.Interval = refreshRate
			bgColor = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("BackGroundColor").InnerText)
			If root.SelectSingleNode("CodingBuddy") IsNot Nothing Then
				codingBuddy.codingBuddyID = Integer.Parse(root.SelectSingleNode("CodingBuddy").InnerText)
			End If
			If root.SelectSingleNode("CodingBuddyActive") IsNot Nothing Then
				codingBuddy.codingBuddyActive = root.SelectSingleNode("CodingBuddyActive").InnerText
			End If
			If root.SelectSingleNode("CodingBuddyReadAll") IsNot Nothing Then
				codingBuddy.codingBuddyReadAll = root.SelectSingleNode("CodingBuddyReadAll").InnerText
			End If
			If root.SelectSingleNode("DrawSelect") IsNot Nothing Then
				CanvasForm.drawSelect = root.SelectSingleNode("DrawSelect").InnerText
			End If
			If root.SelectSingleNode("DrawSelectChildren") IsNot Nothing Then
				CanvasForm.drawSelectChildren = root.SelectSingleNode("DrawSelectChildren").InnerText
			End If
			If root.SelectSingleNode("bgImage") IsNot Nothing Then
				bgImage = root.SelectSingleNode("bgImage").InnerText
				If File.Exists(bgImage) Then
					Try
						Me.BackgroundImage = Image.FromFile(bgImage)
					Catch ex As Exception
					End Try
				End If
			End If

			Dim oldColorButton = colorButton
			Dim oldColorGray1 = colorGray1
			Dim oldColorGray2 = colorGray2
			Dim oldColorGray3 = colorGray3
			Dim oldColorGray4 = colorGray4
			Dim oldColorGray5 = colorGray5
			Dim oldColorText = colorText

			If root.SelectSingleNode("ButtonColor") IsNot Nothing Then
				colorButton = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ButtonColor").InnerText)
			End If
			If root.SelectSingleNode("ColorGray1") IsNot Nothing Then
				colorGray1 = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorGray1").InnerText)
			End If
			If root.SelectSingleNode("ColorGray2") IsNot Nothing Then
				colorGray2 = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorGray2").InnerText)
			End If
			If root.SelectSingleNode("ColorGray3") IsNot Nothing Then
				colorGray3 = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorGray3").InnerText)
			End If
			If root.SelectSingleNode("ColorGray4") IsNot Nothing Then
				colorGray4 = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorGray4").InnerText)
			End If
			If root.SelectSingleNode("ColorGray5") IsNot Nothing Then
				colorGray5 = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorGray5").InnerText)
			End If
			If root.SelectSingleNode("ColorText") IsNot Nothing Then
				colorText = System.Drawing.ColorTranslator.FromHtml(root.SelectSingleNode("ColorText").InnerText)
			End If
			UpdateAllColors(oldColorGray1, oldColorGray2, oldColorGray3, oldColorGray4, oldColorGray5, oldColorButton, oldColorText)
		End If

		editorTabControl.TabPages.Remove(editorTableTab)
		Me.BackColor = bgColor
		Me.Controls.Add(codingBuddy)
		codingBuddy.Anchor = AnchorStyles.Bottom
		codingBuddy.Location = New Point(259, 695)
		codingBuddy.BringToFront()
		codingBuddy.Visible = False

		If codingBuddy.isFirstUse = True Then codingBuddy.buddyIntroSpeech()

		MoveCanvas()
		CanvasForm.Show(Me)
		'Tutorial.Show(Me)
		'Tutorial.Visible = False

		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledError
		LeftSplitContainer.Panel2.Controls.Add(tagCreator)
		tagCreator.Dock = DockStyle.Fill
		tagCreator.Visible = False







        'CEFSHARP TEST
        Dim cefSet As New CefSharp.WinForms.CefSettings
        CefSharp.Cef.Initialize(cefSet)
		cefBrowser = New CefSharp.WinForms.ChromiumWebBrowser("about:blank")
		With cefBrowser
			.Dock = DockStyle.None
			.Anchor = AnchorStyles.Top
		End With


		Me.Controls.Add(cefBrowser)
		cefBrowser.SendToBack()


		'CEFSHARP TEST

	End Sub

	Public Sub UpdateAllColors(OldColorGray1 As Color, OldColorGray2 As Color, OldColorGray3 As Color, OldColorGray4 As Color, OldColorGray5 As Color, OldColorButton As Color, OldColorText As Color)
		For j As Integer = 0 To Me.Controls.Count - 1
			Dim t = Me.Controls.Item(j)
			For i As Integer = 0 To t.Controls.Count - 1
				Dim t2 = t.Controls.Item(i)
				If t2.HasChildren Then
					For k As Integer = 0 To t2.Controls.Count - 1
						Dim t3 = t2.Controls.Item(k)
						If t3.HasChildren Then
							For l As Integer = 0 To t3.Controls.Count - 1
								Dim t4 = t3.Controls.Item(l)
								For m As Integer = 0 To t4.Controls.Count - 1
									If t4.HasChildren Then
										Dim t5 = t4.Controls.Item(m)
										For n As Integer = 0 To t5.Controls.Count - 1
											If t5.HasChildren Then
												Dim t6 = t5.Controls.Item(n)
												For o As Integer = 0 To t6.Controls.Count - 1
													If t6.HasChildren Then
														Dim t7 = t6.Controls.Item(o)
														For p As Integer = 0 To t7.Controls.Count - 1
															If t7.HasChildren Then
																Dim t8 = t7.Controls.Item(p)
																For q As Integer = 0 To t8.Controls.Count - 1
																	If t8.HasChildren Then
																		Dim t9 = t8.Controls.Item(q)
																		For r As Integer = 0 To t9.Controls.Count - 1
																			UpdateColors(t9.Controls.Item(r), OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
																		Next
																		UpdateColors(t9, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
																	End If
																Next
																UpdateColors(t8, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
															End If
														Next
														UpdateColors(t7, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
													End If
												Next
												UpdateColors(t6, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
											End If
										Next
										UpdateColors(t5, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
									End If
								Next
								UpdateColors(t4, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
							Next
						End If
						UpdateColors(t3, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
					Next
				End If
				UpdateColors(t2, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
			Next
			UpdateColors(t, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)
		Next
		UpdateColors(Me, OldColorGray1, OldColorGray2, OldColorGray3, OldColorGray4, OldColorGray5, OldColorButton, OldColorText)

	End Sub

	Public Sub UpdateColors(target As Control, OldColorGray1 As Color, OldColorGray2 As Color, OldColorGray3 As Color, OldColorGray4 As Color, OldColorGray5 As Color, OldColorButton As Color, OldColorText As Color)
		Dim t = target
		For i As Integer = 0 To t.Controls.Count - 1
			If Not t.Controls.Item(i).Equals(displayArea) And Not t.Equals(displayArea) Then
				If t.Controls.Item(i).BackColor = OldColorGray1 Then
					t.Controls.Item(i).BackColor = colorGray1
					t.Controls.Item(i).ForeColor = colorText
				ElseIf t.Controls.Item(i).BackColor = OldColorButton Then
					t.Controls.Item(i).BackColor = colorButton
					t.Controls.Item(i).ForeColor = colorText
				ElseIf t.Controls.Item(i).BackColor = OldColorGray2 Then
					t.Controls.Item(i).BackColor = colorGray2
					t.Controls.Item(i).ForeColor = colorText
				ElseIf t.Controls.Item(i).BackColor = OldColorGray3 Then
					t.Controls.Item(i).BackColor = colorGray3
					t.Controls.Item(i).ForeColor = colorText
				ElseIf t.Controls.Item(i).BackColor = OldColorGray4 Then
					t.Controls.Item(i).BackColor = colorGray4
					t.Controls.Item(i).ForeColor = colorText
				ElseIf t.Controls.Item(i).BackColor = OldColorGray5 Then
					t.Controls.Item(i).BackColor = colorGray5
					t.Controls.Item(i).ForeColor = colorText
				End If
				t.Controls.Item(i).Refresh()
			End If
		Next
	End Sub

	Private Sub Form1_Close(sender As Object, e As EventArgs) Handles MyBase.Closed
		clearBackups()
		saveSettings()
	End Sub

	Private Sub openWorksheetDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openWorksheetDialog.FileOk
		targetXSL = openWorksheetDialog.FileName.ToString()
		targetWorksheet.Load(openWorksheetDialog.FileName.ToString())
		loadWorksheet(targetXSL)
	End Sub

	Private Sub openWorksheetOption_Click(sender As Object, e As EventArgs) Handles openWorksheetOption.Click
		openWorksheetDialog.ShowDialog(Me)
	End Sub

	Private Sub displayArea_DocumentCompleted(sender As Object, e As CefSharp.FrameLoadEndEventArgs) Handles cefBrowser.FrameLoadEnd
		DocumentCompleted()
	End Sub

	Private Sub DocumentCompleted()
		'doc = displayArea.Document
		'Dim temp As mshtml.IHTMLDocument2 = doc.DomDocument
		'documentScroll = temp.parentWindow
		'MoveCanvas()

		'If displayArea.Document.Body IsNot Nothing Then targetElement = displayArea.Document.Body
	End Sub

	Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click
		Try
			displayArea.Stop()
			loadWorksheet(targetXSL)
		Catch ex As Exception
			errorMessage = ex.Message.ToString
			handleError(ex)
		End Try
	End Sub

	Private Sub saveWorksheetDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles saveWorksheetDialog.FileOk
		Dim outputShellFileName = saveWorksheetDialog.FileName.ToString()
		Dim outputBodyFileName = Strings.Left(outputShellFileName, InStrRev(outputShellFileName, "\", -1, CompareMethod.Text)).ToString & "body\" & Strings.Right(outputShellFileName, (outputShellFileName.Length - InStrRev(outputShellFileName, "\", -1, CompareMethod.Text))).Replace(".xslt", "_Body.xslt")

		Dim outputShell As New Worksheet.ShellFile
		outputShell.CreateShell(outputBodyFileName)

		Dim outputBody As New Worksheet.BodyFile
		outputBody.CreateBody(outputBodyFileName, )

		Select Case newFileType
			Case 1
				WriteWorksheet(outputShellFileName, outputShell.ReturnCode)
				WriteWorksheet(outputBodyFileName, outputBody.ReturnCode)
		End Select

		targetXSL = outputShellFileName
		targetWorksheet.Load(outputShellFileName)
		editMode = True
		editModeButton.BackColor = colorButton
		loadWorksheetForEdit()
		unsavedChanges = False
		Me.Text = Strings.Right(targetXSL, targetXSL.Length - InStrRev(targetXSL, "\", -1, CompareMethod.Text)) & " - Worksheet Previewer"
	End Sub

	Private Sub displayStyleButton_Click(sender As Object, e As EventArgs) Handles displayStyleButton.Click
		If displayStyle = 1 Then
			displayStyle = 2
			displayStyleButton.Text = "Landscape"
			displayWidth = 980
		ElseIf displayStyle = 2 Then
			displayStyle = 3
			displayStyleButton.Text = "Legal"
			displayWidth = 750
		ElseIf displayStyle = 3 Then
			displayStyle = 4
			displayStyleButton.Text = "None"
			displayWidth = ClientSize.Width - LeftToolStrip.Width * 2
		Else
			displayStyle = 1
			displayStyleButton.Text = "Portrait"
			displayWidth = 750
		End If
		Me.Refresh()
	End Sub

	Private Sub Form1_Paint(ByVal sender As Object,
	ByVal e As PaintEventArgs) Handles MyBase.Paint
		If cefBrowser IsNot Nothing Then


			Dim displayAreaVertLocation As Int32
			Dim displayAreaHorLocation As Int32
			Dim speechPanelHorLocation As Int32
			If editorToolPanel.Visible = False Then
				cefBrowser.Height = ClientSize.Height - MenuStrip1.Height - StatusStrip1.Height
				displayAreaVertLocation = ((ClientSize.Height - cefBrowser.Height) \ 2) + 1
			Else
				cefBrowser.Height = ClientSize.Height - MenuStrip1.Height - StatusStrip1.Height - editorToolPanel.Height
				displayAreaVertLocation = ((ClientSize.Height - cefBrowser.Height + editorToolPanel.Height) \ 2) + 1
			End If
			displayAreaHorLocation = (ClientSize.Width - cefBrowser.Width + LeftToolStrip.Width) \ 2
			speechPanelHorLocation = (ClientSize.Width - codingBuddy.Width + LeftToolStrip.Width) \ 2

			cefBrowser.Width = displayWidth + SystemInformation.VerticalScrollBarWidth * 2

			cefBrowser.Location = New Point((displayAreaHorLocation),
							 (displayAreaVertLocation))


			displayArea.Visible = False



			codingBuddy.Location = New Point(speechPanelHorLocation, codingBuddy.Location.Y)

			StatusStrip1.Width = ClientSize.Width

			MoveCanvas()
		End If
	End Sub

	Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
		'Dim lastEdit = File.GetLastWriteTimeUtc(targetXSL)
		'Dim lastLoad As Date = DateTime.UtcNow
		'If lastEdit > lastLoad Then
		If autoRefresh = True Then
			Call refreshButton_Click(sender, e)
		End If
		'End If
	End Sub

	Private Sub autoRefreshButton_Click(sender As Object, e As EventArgs) Handles autoRefreshButton.Click
		If autoRefresh = False Then
			autoRefresh = True
			autoRefreshButton.BackColor = colorButton
			refreshTimer.Enabled = True
		Else
			autoRefresh = False
			autoRefreshButton.BackColor = colorGray2
			refreshTimer.Enabled = False
		End If
	End Sub

	Private Sub previewPageBreaks_Click(sender As Object, e As EventArgs) Handles previewPageBreaksButton.Click
		If previewPageBreaks = False Then
			previewPageBreaks = True
			previewPageBreaksButton.BackColor = colorButton
		Else
			previewPageBreaks = False
			previewPageBreaksButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub openXMLOption_Click(sender As Object, e As EventArgs) Handles openXMLOption.Click
		openXMLDialog.ShowDialog(Me)
	End Sub

	Private Sub openXMLDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openXMLDialog.FileOk
		targetXML = openXMLDialog.FileName.ToString()
		refreshButton.PerformClick()
	End Sub

	Private Sub IndividualFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles newStandaloneFormButton.Click
		newFileType = 1
		saveWorksheetDialog.ShowDialog(Me)
	End Sub

	Private Sub viewSource_Click(sender As Object, e As EventArgs) Handles viewSourceButton.Click
		cefBrowser.GetBrowser.MainFrame.ViewSource()
	End Sub

	Private Sub DealPackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DealPackToolStripMenuItem.Click
		newFileType = 2
		Dim dealPackForm As New dealPackDialog
		dealPackForm.StartPosition = FormStartPosition.CenterParent
		dealPackForm.ShowDialog(Me)
		loadWorksheet(targetXSL)
		dealPackForm.Dispose()
	End Sub

	Private Sub TextEditorToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextEditorToolsToolStripMenuItem.Click
		If editorToolPanel.Visible = True Then
			editorToolPanel.Visible = False
		Else
			editorToolPanel.Visible = True
		End If
		MoveCanvas()
	End Sub

	Private Sub openForEdit_Click(sender As Object, e As EventArgs) Handles openForEdit.Click
		openForEditDialog.ShowDialog(Me)
	End Sub

	Private Sub openForEditDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openForEditDialog.FileOk
		targetXSL = openForEditDialog.FileName.ToString()
		targetWorksheet.Load(openForEditDialog.FileName.ToString())
		loadWorksheetForEdit()
	End Sub

	Public Function ChooseIncludedFile(bodyFiles As List(Of String)) As String
		Dim w As String
		If bodyFiles.Count > 1 Then
			SelectBody.BodyFileList = bodyFiles
			SelectBody.ShowDialog(Me)
			w = SelectBody.Selected
		ElseIf bodyFiles.Count > 0 Then
			w = bodyFiles(0)
		Else
			w = targetXSL
		End If
		Return w
	End Function

	Public Sub loadWorksheetForEdit()
		autoRefresh = False
		autoRefreshButton.BackColor = colorGray2
		refreshTimer.Enabled = False
		If Not targetXSL.Contains("_body.xslt") Then
			targetBody = ChooseIncludedFile(targetWorksheet.GetFiles)
		Else
			targetBody = targetXSL
		End If
		Call loadBodyForEdit(targetBody)
	End Sub

	Private Sub loadBodyForEdit(ws As String)
		'Try
		Dim targetBodyContents As String = ""
		Dim editXSLFramework = "C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\editFramework.xslt"
		Dim bodyFile As New Worksheet.BodyFile
		bodyFile.Load(ws)
		bodyFile.PrepareBodyForEdit(errorMessage, xslValueOfDictionary, xslChooseDictionary, xslIfDictionary)
		xslValueOfDictionary.Clear()
		xslChooseDictionary.Clear()
		xslIfDictionary.Clear()
		Dim HTMLoutput = TransformWorksheet(editXSLFramework)
		bodyFile.Load(ws)
		targetBodyContents = bodyFile.PrepareBodyForEdit(errorMessage, xslValueOfDictionary, xslChooseDictionary, xslIfDictionary)

		editMode = True
		editModeButton.BackColor = colorButton
		displayArea.ActiveXInstance.Document.DesignMode = "On"
		Dim separatorTags As String() = {"<html>", "</html>"}
		bodyFile.Load(ws)

		Dim targetBodySandwich = targetBodyContents
		separatorTags = {"<body>", "</body>"}
		Dim targetBodySandwichPatty As String()
		targetBodySandwichPatty = HTMLoutput.Split(separatorTags, StringSplitOptions.None)

		HTMLoutput = targetBodySandwichPatty(0) & "<body><html><div id=""EditMe"">" & targetBodySandwich & "</div></html></body>" & targetBodySandwichPatty(2)
		displayArea.Document.OpenNew(True)
		displayArea.Document.Write(HTMLoutput)
		'TEST
		Dim idNum As Integer = 0
		For Each el As System.Windows.Forms.HtmlElement In displayArea.Document.All
			If Not IsNothing(el.Id) Then
				If el.Id = "EditMe" Then
					Continue For
				ElseIf el.Id.Length > 0 Then
					el.SetAttribute("origID", el.Id)
				End If
			End If
			el.Id = "editID" & idNum
			idNum += 1
		Next
		'END TEST

		displayArea.Document.Window.AttachEventHandler("onscroll", AddressOf document_Scroll)
		autoRefresh = False
		autoRefreshButton.BackColor = colorGray2
		refreshTimer.Enabled = False
		editorToolPanel.Visible = True
		MoveCanvas()
	End Sub


	Private Sub createInputButton_Click(sender As Object, e As EventArgs)
		Dim newElement = displayArea.Document.CreateElement("input")
		styleGenerator = New StyleGenerator()
		newElement.SetAttribute("type", "text")
		newElement.SetAttribute("classname", "w99 f14 ac bold nobo nobg")
		If (targetElement IsNot Nothing) Then
			Try
				targetElement.AppendChild(newElement)
			Catch ex As Exception
				MsgBox("Unable to place element there." & vbCrLf & ex.Message.ToString)
			End Try
		Else
			MsgBox("Not sure where to put element.")
		End If
	End Sub

	Private Sub Document_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs) Handles doc.MouseDown
		Try
			If (displayArea.Document IsNot Nothing) Then
				Dim newTargetElement = TryCast(displayArea.Document.GetElementFromPoint((Cursor.Position - displayArea.Location - New Point(0 + BorderWidth, TitlebarHeight + BorderWidth) - Me.Location)), System.Windows.Forms.HtmlElement)
				If overlayMode = True And displayArea.Document.Body IsNot Nothing Then
					Dim currentPos As Point = GetCursorPositionInDocument()
					If currentPos.X > 0 And currentPos.X < displayWidth And currentPos.Y > 0 Then
						CanvasForm.DrawDragRectangle(currentPos)
						RemoveHandler doc.MouseUp, AddressOf Overlay_MouseUp
						RemoveHandler doc.LosingFocus, AddressOf Overlay_MouseLeave
						AddHandler doc.MouseUp, AddressOf Overlay_MouseUp
					Else
						RemoveHandler doc.MouseUp, AddressOf Overlay_MouseUp
						RemoveHandler doc.LosingFocus, AddressOf Overlay_MouseLeave
					End If
				Else
					If DoubleClickTimer.Enabled Then
						If newTargetElement = targetElement Then targetElement = targetElement.Parent
					Else
						targetElement = newTargetElement
						DoubleClickTimer.Enabled = True
					End If
					If Not IsNothing(newTargetElement) And Not IsNothing(newTargetElement.Parent) Then ElementSelect(targetElement)
					MoveCanvas()
				End If
			End If
		Catch ex As Exception
		End Try
	End Sub

	Private Sub Overlay_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
		targetElement = displayArea.Document.Body.GetElementsByTagName("content").Item(0)
		ElementSelect(displayArea.Document.Body.GetElementsByTagName("content").Item(0))
		Dim currentPos As Point = GetCursorPositionInDocument()
		If currentPos.X > 0 And currentPos.X < displayWidth And currentPos.Y > 0 Then

			Dim locsize As List(Of Point) = CanvasForm.DragRectangleStop(currentPos)
			If locsize(1).X > 1 And locsize(1).Y > 1 Then
				Dim styles As String() = {"position", "absolute", "top", locsize(0).Y & "px", "left", locsize(0).X & "px", "height", locsize(1).Y & "px", "width", locsize(1).X & "px", "z-index", "10", "background-color", "red"}
				Dim other As String() = {"classname", "f14 ab"}

				undoHistory.AddChange(targetElement)
				Dim newElement = displayArea.Document.CreateElement("div")
				If other.Length > 1 Then
					For i As Integer = 0 To (other.Count / 2) - 1
						newElement.SetAttribute(other.ElementAt(i * 2), other.ElementAt(i * 2 + 1))
					Next
				End If
				If styles.Length > 1 Then
					For i As Integer = 0 To (styles.Count / 2) - 1
						updateStyle(styles.ElementAt(i * 2), styles.ElementAt(i * 2 + 1), newElement)
					Next
				End If
				newElement.InnerText = " "
				If (targetElement IsNot Nothing) Then
					Try
						targetElement.AppendChild(newElement)
					Catch ex As Exception
						MsgBox("Unable to place element there." & vbCrLf & ex.Message.ToString)
					End Try
				Else
					MsgBox("Not sure where to put element.")
				End If
				MoveCanvas()
			End If
			Dim temp As IHTMLDocument2 = doc.DomDocument
			temp.designMode = "Off"
		Else
			CanvasForm.DragRectangleStop(GetCursorPositionInDocument)
		End If
		RemoveHandler doc.MouseUp, AddressOf Overlay_MouseUp
		doc.Focus()
	End Sub

	Private Sub Overlay_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
		CanvasForm.DragRectangleStop(GetCursorPositionInDocument)
		RemoveHandler doc.MouseUp, AddressOf Overlay_MouseUp
		RemoveHandler doc.LosingFocus, AddressOf Overlay_MouseLeave
		Dim temp As IHTMLDocument2 = doc.DomDocument
		temp.designMode = "Off"
	End Sub

	Public Sub ElementSelect(element As System.Windows.Forms.HtmlElement)
		If (displayArea.Document IsNot Nothing) Then
			Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
			Dim TitlebarHeight As Integer = (Me.Height - Me.ClientSize.Height - BorderWidth)
			Try
				targetElement = element
				UpdateCurrentElement(targetElement)
				If editorToolPanel.Visible = True Then
					Dim temp As IHTMLElement2 = targetElement.DomElement
					Dim temp2 As IHTMLElement3 = targetElement.DomElement
					targetElement.Focus()
					Select Case targetElement.TagName.ToLower
						Case "xslvalueof"
							temp2.contentEditable = "false"
						Case "xslif"
							temp2.contentEditable = "false"
						Case "xslchoose"
							temp2.contentEditable = "false"
						Case Else
							temp2.contentEditable = "false"
							'temp2.contentEditable = "true"
							temp2.setActive()
					End Select

					'temp.attachEventHandler("onresize", ElementResizeStart)
					'temp2.attachEventHandler("resizestart", ElementResizeStart)
					'temp2.attachEventHandler("onresizeend", ElementResizeEnd)
					elementChanged = False
					If targetElement.Parent IsNot Nothing Then
						parentElementHTML = targetElement.Parent.OuterHtml
					End If
					RemoveHandler targetElement.LosingFocus, AddressOf elementLosingFocus
					AddHandler targetElement.LosingFocus, AddressOf elementLosingFocus
					EditorPanelHomePagePopulate(targetElement)
					EditorPanelTablePagePopulate(targetElement)
				End If
				MoveCanvas()
			Catch ex As Exception
				handleError(ex)
			End Try
		End If
	End Sub

	Private Function ElementResizeStart()
		originalSize = targetElement.ClientRectangle.Size
		originalPos = targetElement.ClientRectangle.Location
		showStatus.Text = originalPos.ToString & originalSize.ToString
		Return 0
	End Function
	Private Function ElementResizeEnd()
		Dim temp As mshtml.IHTMLElement3 = targetElement.DomElement
		temp.dragDrop()

		If Not (targetElement.ClientRectangle.Size = originalSize And targetElement.ClientRectangle.Location = originalPos) Then
            MsgBox("Stuff moved")
        Else
			MsgBox(targetElement.ClientRectangle.Size.ToString & originalSize.ToString & " | " & targetElement.ClientRectangle.Location.ToString & originalPos.ToString)
		End If
		Return 0
	End Function

	Private Sub EditorPanelHomePagePopulate(element As System.Windows.Forms.HtmlElement)
		Dim temp As IHTMLElement2 = element.DomElement
		If temp.currentStyle.fontSize IsNot Nothing Then
			Try
				fontSizeBox.Value = Val(temp.currentStyle.fontSize.ToString)
				fontUnitBox.Text = Strings.Right(temp.currentStyle.fontSize.ToString, 2)
				fontFamilyBox.Text = temp.currentStyle.fontFamily.ToString.Substring(0, 1).ToUpper & temp.currentStyle.fontFamily.ToString.Substring(1)
			Catch ex As Exception
				MsgBox(ex.Message.ToString)
			End Try
		End If
		If temp.currentStyle.fontWeight > 400 Then
			boldButton.BackColor = colorButton
		Else
			boldButton.BackColor = colorGray2
		End If
		If temp.currentStyle.fontStyle = "italic" Then
			italicButton.BackColor = colorButton
		Else
			italicButton.BackColor = colorGray2
		End If
		If temp.currentStyle.textDecoration = "underline" Then
			underlineButton.BackColor = colorButton
		Else
			underlineButton.BackColor = colorGray2
		End If
		alignLeftButton.BackColor = colorGray2
		alignRightButton.BackColor = colorGray2
		alignCenterButton.BackColor = colorGray2
		alignJustifyButton.BackColor = colorGray2
		Select Case temp.currentStyle.textAlign
			Case "left"
				alignLeftButton.BackColor = colorButton
			Case "right"
				alignRightButton.BackColor = colorButton
			Case "center"
				alignCenterButton.BackColor = colorButton
			Case "justify"
				alignJustifyButton.BackColor = colorButton
			Case Else
				alignLeftButton.BackColor = colorButton
		End Select
		If Not temp.currentStyle.borderTopStyle = "none" Then
			borderTopButton.BackColor = colorButton
			borderTopButton.FlatAppearance.BorderSize = 2
			borderTopButton.FlatAppearance.BorderColor = colorButton
		Else
			borderTopButton.BackColor = colorGray2
			borderTopButton.FlatAppearance.BorderSize = 1
			borderTopButton.FlatAppearance.BorderColor = Color.Black
		End If
		If Not temp.currentStyle.borderRightStyle = "none" Then
			borderRightButton.BackColor = colorButton
			borderRightButton.FlatAppearance.BorderSize = 2
			borderRightButton.FlatAppearance.BorderColor = colorButton
		Else
			borderRightButton.BackColor = colorGray2
			borderRightButton.FlatAppearance.BorderSize = 1
			borderRightButton.FlatAppearance.BorderColor = Color.Black
		End If
		If Not temp.currentStyle.borderBottomStyle = "none" Then
			borderBottomButton.BackColor = colorButton
			borderBottomButton.FlatAppearance.BorderSize = 2
			borderBottomButton.FlatAppearance.BorderColor = colorButton
		Else
			borderBottomButton.BackColor = colorGray2
			borderBottomButton.FlatAppearance.BorderSize = 1
			borderBottomButton.FlatAppearance.BorderColor = Color.Black
		End If
		If Not temp.currentStyle.borderLeftStyle = "none" Then
			borderLeftButton.BackColor = colorButton
			borderLeftButton.FlatAppearance.BorderSize = 2
			borderLeftButton.FlatAppearance.BorderColor = colorButton
		Else
			borderLeftButton.BackColor = colorGray2
			borderLeftButton.FlatAppearance.BorderSize = 1
			borderLeftButton.FlatAppearance.BorderColor = Color.Black
		End If
		widthBox.Value = Val(temp.currentStyle.width.ToString)
		heightBox.Value = Val(temp.currentStyle.height.ToString)
		If temp.currentStyle.width.ToString.Contains("%") Then
			widthUnitBox.Text = "%"
		ElseIf temp.currentStyle.width.Tolower.Contains("auto") Then
			widthUnitBox.Text = "auto"
		Else
			widthUnitBox.Text = Strings.Right(temp.currentStyle.width.ToString, 2)
		End If
		If temp.currentStyle.height.ToString.Contains("%") Then
			heightUnitBox.Text = "%"
		ElseIf temp.currentStyle.height.Tolower.Contains("auto") Then
			heightUnitBox.Text = "auto"
		Else
			heightUnitBox.Text = Strings.Right(temp.currentStyle.height.ToString, 2)
		End If
	End Sub

	Private Sub EditorPanelTablePagePopulate(element As System.Windows.Forms.HtmlElement)
		If element.IsTableElement Then
			Dim t As IHTMLElement2 = element.GetParentTable.DomElement
			Dim tbl As mshtml.HTMLTable = element.GetParentTable.DomElement
			Dim tempTD As mshtml.HTMLTableCell = element.DomElement
			htmlTableColumns.Value = tbl.GetCols

			colspanBox.Value = tempTD.colSpan
			rowspanBox.Value = tempTD.rowSpan

			If Not editorTabControl.TabPages.Contains(editorTableTab) Then
				editorTabControl.TabPages.Insert(editorTabControl.TabCount, editorTableTab)
			End If
			tableWidthBox.Value = Val(t.currentStyle.width.ToString)
		Else
			editorTabControl.TabPages.Remove(editorTableTab)
		End If
	End Sub

	Public Function GetCursorPositionInDocument() As Point
		Try
			Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
			Dim BrowserOffsetX As Integer = 0
			Dim BrowserOffsetY As Integer = 0
            Dim cursorPos As Point = New Point(0, 0)
            'If cefBrowser.GetBrowser.HasDocument() Then
            '    Dim Task = cefBrowser.GetBrowser.FocusedFrame.EvaluateScriptAsync("(function() { var body = document.body; return body; })();", vbNull)

            '    Task.ContinueWith(t >=
            '    {
            '        If(!t.IsFaulted)
            '        {
            '            Dim response = t.Result
            '    EvaluateJavaScriptResult = response.Success?(response.Result ?? "null") : response.Message
            '        }
            '    }, TaskScheduler.FromCurrentSynchronizationContext())
            '    If Not cefBrowser.ClientRectangle.Width > cefBrowser.Document.Body.ClientRectangle.Width Then
            '        BrowserOffsetX = SystemInformation.VerticalScrollBarWidth
            '    Else
            '        BrowserOffsetX = SystemInformation.VerticalScrollBarWidth / 2
            '    End If
            '    Dim BrowserOffset As Point = New Point(BrowserOffsetX, BrowserOffsetY)
            '    cursorPos = Cursor.Position - displayArea.Location - New Point(0, TitlebarHeight) - Me.Location - New Point(BorderWidth, BorderWidth) - BrowserOffset
            '    If displayArea.Document IsNot Nothing Then
            '        If displayArea.Document.Body IsNot Nothing Then
            '            cursorPos.Y += displayArea.Document.Body.ScrollTop
            '        End If
            '        If displayArea.Document.Body IsNot Nothing Then
            '            cursorPos.X += displayArea.Document.Body.ScrollLeft
            '        End If
            '    End If
            '    If cursorPos.X > 0 And cursorPos.X < displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX Then
            '        cursorPos.X = cursorPos.X
            '    ElseIf cursorPos.X < 0 Then
            '        cursorPos.X = 0
            '    ElseIf cursorPos.X > displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX Then
            '        cursorPos.X = displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX
            '    End If
            'End If
            'If displayArea.Document.Body IsNot Nothing Then
            '    If Not displayArea.ClientRectangle.Width > displayArea.Document.Body.ClientRectangle.Width Then
            '        BrowserOffsetX = SystemInformation.VerticalScrollBarWidth
            '    Else
            '        BrowserOffsetX = SystemInformation.VerticalScrollBarWidth / 2
            '    End If
            '    Dim BrowserOffset As Point = New Point(BrowserOffsetX, BrowserOffsetY)
            '    cursorPos = Cursor.Position - displayArea.Location - New Point(0, TitlebarHeight) - Me.Location - New Point(BorderWidth, BorderWidth) - BrowserOffset
            '    If displayArea.Document IsNot Nothing Then
            '        If displayArea.Document.Body IsNot Nothing Then
            '            cursorPos.Y += displayArea.Document.Body.ScrollTop
            '        End If
            '        If displayArea.Document.Body IsNot Nothing Then
            '            cursorPos.X += displayArea.Document.Body.ScrollLeft
            '        End If
            '    End If
            '    If cursorPos.X > 0 And cursorPos.X < displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX Then
            '        cursorPos.X = cursorPos.X
            '    ElseIf cursorPos.X < 0 Then
            '        cursorPos.X = 0
            '    ElseIf cursorPos.X > displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX Then
            '        cursorPos.X = displayArea.Document.Body.ScrollRectangle.Width - BrowserOffsetX
            '    End If
            'End If
            Return cursorPos
		Catch ex As Exception
			errorMessage = ex.Message
			handleError(ex)
			Return New Point(0, 0)
		End Try
	End Function

	Private Sub fontSizeBox_Click(sender As Object, e As EventArgs) Handles fontSizeBox.Click
		changeFontSize()
	End Sub
	Private Sub fontSizeBox_KeyUp(sender As Object, e As EventArgs) Handles fontSizeBox.KeyUp
		changeFontSize()
	End Sub

	Private Sub changeFontSize()
		undoHistory.AddChange(targetElement)
		Dim temp As IHTMLElement2 = targetElement.DomElement
		If targetElement.Style IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(targetElement.Style.ToString)
			styleGenerator.SetStyle("font-size", fontSizeBox.Value.ToString & fontUnitBox.Text)
			targetElement.Style = styleGenerator.GetStyleString()
		ElseIf temp.currentStyle IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(temp.currentStyle.ToString)
			styleGenerator.SetStyle("font-size", fontSizeBox.Value.ToString & fontUnitBox.Text)
			targetElement.Style = styleGenerator.GetStyleString()
		End If
		UpdateCurrentElement(targetElement)
		styleGenerator.Clear()
	End Sub

	Private Sub updateClass(targetClass As String, Optional element As System.Windows.Forms.HtmlElement = Nothing)
		If element = Nothing Then element = targetElement
		undoHistory.AddChange(targetElement)
		classGenerator = New ClassGenerator()
		classGenerator.ParseClassString(element.GetAttribute("classname"))
		classGenerator.SetClass(targetClass)
		element.SetAttribute("classname", classGenerator.GetClassString())
		UpdateCurrentElement(targetElement)
		classGenerator.Clear()
	End Sub

	Private Sub removeClass(targetClass As String, Optional element As System.Windows.Forms.HtmlElement = Nothing)
		If element = Nothing Then element = targetElement
		undoHistory.AddChange(targetElement)
		Dim temp As IHTMLElement2 = element.DomElement
		If element.GetAttribute("classname").ToString.Length > 0 Then
			classGenerator = New ClassGenerator()
			classGenerator.ParseClassString(element.GetAttribute("classname"))
			classGenerator.RemoveClass(targetClass)
			element.SetAttribute("classname", classGenerator.GetClassString())
		ElseIf temp.GetAttribute("classname").ToString.Length > 0 Then
			classGenerator = New ClassGenerator()
			classGenerator.ParseClassString(temp.GetAttribute("classname"))
			classGenerator.RemoveClass(targetClass)
			element.SetAttribute("classname", classGenerator.GetClassString())
		End If
		UpdateCurrentElement(targetElement)
		classGenerator.Clear()
	End Sub

	Private Function HasClass(targetClass As String, Optional element As System.Windows.Forms.HtmlElement = Nothing) As Boolean
		If element = Nothing Then element = targetElement
		Dim temp As Boolean
		classGenerator = New ClassGenerator()
		classGenerator.ParseClassString(element.GetAttribute("classname").ToString)
		temp = classGenerator.ContainsClass(targetClass)
		classGenerator.Clear()
		Return temp
	End Function

	Private Overloads Sub updateStyle(targetStyle As String, newValue As String, Optional element As System.Windows.Forms.HtmlElement = Nothing)
		If element Is Nothing Then
			undoHistory.AddChange(targetElement)
			element = targetElement
		End If

		Dim temp As IHTMLElement2 = element.DomElement
		If element.Style IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(element.Style.ToString)
			styleGenerator.SetStyle(targetStyle, newValue)
			element.Style = styleGenerator.GetStyleString()
		ElseIf temp.currentStyle IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(temp.currentStyle.ToString)
			styleGenerator.SetStyle(targetStyle, newValue)
			element.Style = styleGenerator.GetStyleString()
		Else
			Try
				styleGenerator = New StyleGenerator()
				styleGenerator.SetStyle(targetStyle, newValue)
				element.Style = styleGenerator.GetStyleString()
			Catch ex As Exception
				handleError(ex)
			End Try
		End If
		UpdateCurrentElement(targetElement)
		If styleGenerator IsNot Nothing Then styleGenerator.Clear()
	End Sub

	Private Overloads Sub updateStyle(elements As List(Of mshtml.IHTMLElement), targetStyle As String, newValue As String)
		If elements Is Nothing Then
			Exit Sub
		End If

		For Each element In elements
			Dim temp As IHTMLElement2 = element.DomElement
			If element.style IsNot Nothing Then
				styleGenerator = New StyleGenerator()
				styleGenerator.ParseStyleString(element.style.toString)
				styleGenerator.SetStyle(targetStyle, newValue)
				element.setAttribute("style", styleGenerator.GetStyleString())
			ElseIf temp.currentStyle IsNot Nothing Then
				styleGenerator = New StyleGenerator()
				styleGenerator.ParseStyleString(temp.currentStyle.ToString)
				styleGenerator.SetStyle(targetStyle, newValue)
				element.setAttribute("style", styleGenerator.GetStyleString())
			Else
				Try
					styleGenerator = New StyleGenerator()
					styleGenerator.SetStyle(targetStyle, newValue)
					element.setAttribute("style", styleGenerator.GetStyleString())
				Catch ex As Exception
					handleError(ex)
				End Try
			End If
		Next
		UpdateCurrentElement(targetElement)
		If styleGenerator IsNot Nothing Then styleGenerator.Clear()
	End Sub

	Private Function removeStyle(targetStyle As String)
		undoHistory.AddChange(targetElement)
		Dim temp As IHTMLElement2 = targetElement.DomElement
		If targetElement.Style IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(targetElement.Style.ToString)
			styleGenerator.RemoveStyle(targetStyle)
			targetElement.Style = styleGenerator.GetStyleString()
		ElseIf temp.currentStyle IsNot Nothing Then
			styleGenerator = New StyleGenerator()
			styleGenerator.ParseStyleString(temp.currentStyle.ToString)
			styleGenerator.RemoveStyle(targetStyle)
			targetElement.Style = styleGenerator.GetStyleString()
		End If
		UpdateCurrentElement(targetElement)
		styleGenerator.Clear()
		Return 0
	End Function

	Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles boldButton.Click
		If boldButton.BackColor = colorGray2 Then
			'updateStyle("font-weight", "bold")
			cefBrowser.GetBrowser.FocusedFrame.ExecuteJavaScriptAsync("alert('boopadee-dooper');")
			cefBrowser.GetBrowser.FocusedFrame.ExecuteJavaScriptAsync("document.activeElement.style.fontWeight = 'bold';")
			boldButton.BackColor = colorButton
		Else
			cefBrowser.GetBrowser.FocusedFrame.ExecuteJavaScriptAsync("alert('boopadee-dooper');")
			cefBrowser.GetBrowser.FocusedFrame.ExecuteJavaScriptAsync("document.activeElement.style.fontWeight = 'normal';")
			'updateStyle("font-weight", "normal")
			boldButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub refreshRateButton_Click(sender As Object, e As EventArgs)
		Try
			Dim newRefreshRate = InputBox("Choose your refresh rate (In seconds).", "Refresh Rate", refreshRate / 1000)
			If Integer.TryParse(newRefreshRate, newRefreshRate) Then
				refreshRate = newRefreshRate * 1000
				refreshTimer.Interval = refreshRate
			Else
				MsgBox("This Is Not a valid refresh rate.")
			End If
		Catch ex As Exception
		End Try
	End Sub

	Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
		If targetBody Is Nothing Then
			MsgBox("There is no file selected to save to.")
		Else
			Using sr As StreamReader = File.OpenText(targetBody)
				Do While sr.Peek() >= 0
					targetBodyContent = sr.ReadToEnd
				Loop
			End Using

			Dim separatorTags As String() = {"<html>", "</html>"}
			Dim targetBodySandwich As String()
			Dim targetBodySandwichPatty As String
			targetBodySandwich = targetBodyContent.Split(separatorTags, StringSplitOptions.None)
			Dim fixHTML As New HtmlAgilityPack.HtmlDocument
			fixHTML.LoadHtml(displayArea.DocumentText)
			fixHTML.OptionOutputAsXml = True
			fixHTML.OptionWriteEmptyNodes = True
			fixHTML.OptionOutputOriginalCase = False
			targetBodySandwichPatty = "<html>" & fixHTML.GetElementbyId("EditMe").InnerHtml.ToString & "</html>"
			Dim outputXSLT As String = targetBodySandwich(0) & targetBodySandwichPatty & targetBodySandwich(2)
			outputXSLT = outputXSLT.Replace("<?xml:namespace prefix = ""xsl"" />", "").Replace("></xsl:value-of>", "/>").Replace("&nbsp;", "&#160;").Replace("& ", "&amp; ").Replace("contenteditable=""true""", "").Replace("&amp;nbsp;", "&#160;")

			outputXSLT = outputXSLT.Replace("xslif", "xsl:if").Replace("xslchoose", "xsl:choose").Replace("xslattribute", "xsl:attribute").Replace("xslwhen", "xsl:when").Replace("xslotherwise", "xsl:otherwise")
			outputXSLT = outputXSLT.Replace("<xslvalueof>", "<xsl:value-of select=").Replace("</xslvalueof>", " />")
			outputXSLT = outputXSLT.Replace("<xslvariable>", "<xsl:variable").Replace("</xslvariable>", " />")
			outputXSLT = outputXSLT.Replace("&quot;", """")

			Do While targetBodySandwich(1).Contains("<xsl:variable")
				Dim startIndex As Integer = targetBodySandwich(1).IndexOf("<xsl:variable")
				Dim endIndex As Integer = targetBodySandwich(1).IndexOf(">", startIndex)
				targetBodySandwich(1) = targetBodySandwich(1).Remove(endIndex - 1, 2)
				targetBodySandwich(1) = targetBodySandwich(1).Insert(endIndex - 1, "</xslvariable>")
				targetBodySandwich(1) = targetBodySandwich(1).Remove(startIndex, 13)
				targetBodySandwich(1) = targetBodySandwich(1).Insert(startIndex, "<xslvariable>")
			Loop

			Dim xslWriteSetttings As XmlWriterSettings = New XmlWriterSettings
			xslWriteSetttings.Indent = Formatting.Indented
			xslWriteSetttings.IndentChars = ControlChars.Tab
			xslWriteSetttings.ConformanceLevel = ConformanceLevel.Fragment
			Using sw As XmlWriter = XmlTextWriter.Create(targetBody, xslWriteSetttings)
				sw.WriteRaw(outputXSLT)
			End Using

			unsavedChanges = False
			ActiveForm.Text = ActiveForm.Text.Replace("● ", "")
		End If

	End Sub

	Private Sub createSpanButton_Click(sender As Object, e As EventArgs)
		Dim newElement = displayArea.Document.CreateElement("span")
		newElement.SetAttribute("class", "f14")
		If (targetElement IsNot Nothing) Then
			Try
				targetElement.AppendChild(newElement)
			Catch ex As Exception
				MsgBox("Unable to place element there." & vbCrLf & ex.Message.ToString)
			End Try
		Else
			MsgBox("Not sure where to put element.")
		End If
	End Sub

	Private Sub ChooseStoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseStoreToolStripMenuItem.Click
		Try
			Dim newNewStoreID = InputBox("Enter the Store ID # for the store you would like to preview forms as. Do not include the Pod Number.", "Choose lCompanyID", newStoreID)
			If Integer.TryParse(newNewStoreID, newNewStoreID) Then
				newStoreID = newNewStoreID
			Else
				MsgBox("This is not a valid dealership ID. Dealership ID should be a numeric value.")
			End If
			loadWorksheet(targetXSL)
		Catch ex As Exception
		End Try
	End Sub

	Private Sub handleError(Optional ex As Exception = Nothing, Optional errorMessageString As String = "")
		codingBuddy.erSourceURI = erSourceURI
		codingBuddy.handleError(ex, errorMessageString)
		showStatus.Text = codingBuddy.fullErrorMessage
	End Sub

	Public Shared Sub saveSettings()
		If Not System.IO.Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools")) Then
			System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer"))
		End If
		Dim SettingsList As New Dictionary(Of String, Object) From
			{
				{"RefreshRate", wsGUIWindow.refreshRate},
				{"BackGroundColor", ColorTranslator.ToHtml(wsGUIWindow.bgColor)},
				{"CodingBuddy", wsGUIWindow.codingBuddy.codingBuddyID},
				{"CodingBuddyActive", wsGUIWindow.codingBuddy.codingBuddyActive},
				{"CodingBuddyReadAll", wsGUIWindow.codingBuddy.codingBuddyReadAll},
				{"SupressScriptErrors", supressScriptErrors},
				{"ButtonColor", ColorTranslator.ToHtml(wsGUIWindow.colorButton)},
				{"ColorText", ColorTranslator.ToHtml(wsGUIWindow.colorText)},
				{"ColorGray1", ColorTranslator.ToHtml(wsGUIWindow.colorGray1)},
				{"ColorGray2", ColorTranslator.ToHtml(wsGUIWindow.colorGray2)},
				{"ColorGray3", ColorTranslator.ToHtml(wsGUIWindow.colorGray3)},
				{"ColorGray4", ColorTranslator.ToHtml(wsGUIWindow.colorGray4)},
				{"ColorGray5", ColorTranslator.ToHtml(wsGUIWindow.colorGray5)},
				{"bgImage", bgImage},
				{"DrawSelect", CanvasForm.drawSelect},
				{"DrawSelectChildren", CanvasForm.drawSelectChildren}
			}

		Dim sw As StreamWriter = File.CreateText(wsGUIWindow.settingsDirectory)
		Using xw As XmlWriter = XmlWriter.Create(sw)
			xw.WriteStartDocument()
			xw.WriteWhitespace(vbCrLf)
			xw.WriteStartElement("Settings")
			xw.WriteWhitespace(vbCrLf)
			For i As Integer = 0 To SettingsList.Keys.Count - 1
				xw.WriteWhitespace(vbTab)
				xw.WriteElementString(SettingsList.Keys(i), SettingsList.Values(i))
				xw.WriteWhitespace(vbCrLf)
			Next
			xw.WriteEndDocument()
			xw.Close()
		End Using
		sw.Close()
	End Sub

	Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
		Using SettingsInstance As New Settings
			Me.AddOwnedForm(SettingsInstance)
			SettingsInstance.ShowDialog()
			Me.RemoveOwnedForm(SettingsInstance)
		End Using
	End Sub


	Public Sub loadWorksheet(wsFileName As String)
		Dim HTMLoutput = TransformWorksheet(wsFileName)
		Me.Text = Strings.Right(targetXSL, targetXSL.Length - InStrRev(targetXSL, "\", -1, CompareMethod.Text)) & " - Worksheet Previewer"
		'displayArea.Document.OpenNew(True)
		'displayArea.Document.Write(HTMLoutput)


		'TEST
		'System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\Temp"))
		'Dim tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\Temp\chrometest.html")
		'WriteWorksheet(tempPath, HTMLoutput)

		CefSharp.WebBrowserExtensions.LoadHtml(cefBrowser, HTMLoutput, "http://test/")

		DocumentCompleted()
		'Dim temp As mshtml.IHTMLDocument2 = displayArea.Document.DomDocument
		'documentScroll = temp.parentWindow
		'displayArea.Document.Window.AttachEventHandler("onscroll", AddressOf document_Scroll)
	End Sub

	Private Sub italicButton_Click(sender As Object, e As EventArgs) Handles italicButton.Click
		If italicButton.BackColor = colorGray2 Then
			updateStyle("font-style", "italic")
			italicButton.BackColor = colorButton
		Else
			updateStyle("font-style", "normal")
			italicButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub underlineButton_Click(sender As Object, e As EventArgs) Handles underlineButton.Click
		If underlineButton.BackColor = colorGray2 Then
			updateStyle("text-decoration", "underline")
			underlineButton.BackColor = colorButton
		Else
			updateStyle("text-decoration", "none")
			underlineButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub alignLeftButton_Click(sender As Object, e As EventArgs) Handles alignLeftButton.Click
		If alignLeftButton.BackColor = colorGray2 Then
			removeClass("justify")
			removeClass("ac")
			removeClass("ar")
			updateClass("al")
			alignLeftButton.BackColor = colorButton
			alignCenterButton.BackColor = colorGray2
			alignRightButton.BackColor = colorGray2
			alignJustifyButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub alignCenterButton_Click(sender As Object, e As EventArgs) Handles alignCenterButton.Click
		If alignCenterButton.BackColor = colorGray2 Then
			removeClass("al")
			removeClass("justify")
			removeClass("ar")
			updateClass("ac")
			alignCenterButton.BackColor = colorButton
			alignLeftButton.BackColor = colorGray2
			alignRightButton.BackColor = colorGray2
			alignJustifyButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub alignRightButton_Click(sender As Object, e As EventArgs) Handles alignRightButton.Click
		If alignRightButton.BackColor = colorGray2 Then
			removeClass("al")
			removeClass("ac")
			removeClass("justify")
			updateClass("ar")
			alignRightButton.BackColor = colorButton
			alignLeftButton.BackColor = colorGray2
			alignCenterButton.BackColor = colorGray2
			alignJustifyButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub alignJustifyButton_Click(sender As Object, e As EventArgs) Handles alignJustifyButton.Click
		If alignJustifyButton.BackColor = colorGray2 Then
			removeClass("al")
			removeClass("ac")
			removeClass("ar")
			updateClass("justify")
			alignJustifyButton.BackColor = colorButton
			alignRightButton.BackColor = colorGray2
			alignCenterButton.BackColor = colorGray2
			alignLeftButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub createCheckboxButton_Click(sender As Object, e As EventArgs)
		Dim newElement = displayArea.Document.CreateElement("input")
		styleGenerator = New StyleGenerator()
		styleGenerator.SetStyle("border", "0")
		newElement.Style = styleGenerator.GetStyleString()
		styleGenerator.Clear()
		newElement.SetAttribute("type", "checkbox")
		If (targetElement IsNot Nothing) Then
			Try
				targetElement.AppendChild(newElement)
			Catch ex As Exception
				MsgBox("Unable to place element there." & vbCrLf & ex.Message.ToString)
			End Try
		Else
			MsgBox("Not sure where to put element.")
		End If
	End Sub

	Private Sub fontFamilyBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fontFamilyBox.Click
		updateStyle("font-family", fontFamilyBox.Text)
	End Sub

	Private Sub fontFamilyBox_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles fontFamilyBox.KeyUp
		updateStyle("font-family", fontFamilyBox.Text)
	End Sub

	Private Sub createNewTableButton_Click(sender As Object, e As EventArgs) Handles createNewTableButton.Click
		Dim rows = newTableRows.Value
		Dim cols = newTableColumns.Value
		Dim newTable = displayArea.Document.CreateElement("table")
		styleGenerator = New StyleGenerator()
		styleGenerator.SetStyle("width", "100%")
		styleGenerator.SetStyle("border", "0")
		newTable.Style = styleGenerator.GetStyleString()
		styleGenerator.Clear()
		For i As Integer = 1 To rows
			Dim newRow = displayArea.Document.CreateElement("tr")
			For c As Integer = 1 To cols
				Dim newCell = displayArea.Document.CreateElement("td")
				updateClass("ab", newCell)
				styleGenerator = New StyleGenerator()
				If i = 1 And c < cols Then styleGenerator.SetStyle("width", 100 / cols & "%")
				newCell.Style = styleGenerator.GetStyleString()
				styleGenerator.Clear()
				newCell.InnerText = " "
				newRow.AppendChild(newCell)
			Next
			newTable.AppendChild(newRow)
		Next
		InsertHTMLElement(newTable)
		updateClass("w100", newTable)
		updateClass("f14", newTable)
		createNewTablePanel.Visible = False
	End Sub

	Private Sub BackgroundImageToolStripMenuItem_Click(sender As Object, e As EventArgs)
		openBGPicture.ShowDialog(Me)
	End Sub

	Private Sub openBGPicture_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles openBGPicture.FileOk
		Try
			Me.BackgroundImage = Image.FromFile(openBGPicture.FileName)
			bgImage = openBGPicture.FileName
		Catch ex As Exception
			showStatus.Text = "Not able to load image."
		End Try
	End Sub

	Public Sub fixUnderscore()
		Try
			Dim tempReader = File.OpenText(targetXSL)
			Dim tempText = tempReader.ReadToEnd
			tempReader.Close()
			tempText = tempText.Replace("__", "_")
			Dim sw As StreamWriter = File.CreateText(targetXSL)
			sw.Write(tempText)
			sw.Close()
		Catch ex As Exception
			errorMessage = ex.Message.ToString
			handleError(ex)
		End Try
	End Sub

	Public Sub fixReferences()
		backupWorksheet(targetXSL)
		Dim tempReader = File.OpenText(targetXSL)
		Dim tempText = tempReader.ReadToEnd
		tempReader.Close()
		Dim formContentCorrected = ""
		Dim stream_reader As New IO.StringReader(tempText)
		Dim line As String
		Try
			line = stream_reader.ReadLine()
			Do While Not (line Is Nothing)
				If line.Length > 0 Then
					If line.Contains("<xsl:include") Or line.Contains("<include ") Then
						line = FixPath(line)
					End If

				End If
				formContentCorrected &= line & vbCrLf
				line = stream_reader.ReadLine()
			Loop
			stream_reader.Close()
		Catch ex As Exception
			errorMessage = ex.Message.ToString
			handleError(ex)
		End Try
		Dim sw As StreamWriter = File.CreateText(targetXSL)
		sw.Write(formContentCorrected)
		sw.Close()
		loadWorksheet(targetXSL)
	End Sub

	Private Function FixPath(e As String, Optional shellFile As String = "") As System.String
		If Not shellFile.Length > 1 Then
			shellFile = targetXSL
		End If
		Dim inputString As String = e.Replace("\", "/")
		Dim outputString As String = ""
		Dim separatorTags As String() = {""""}
		Dim parts As String()
		Dim fileName As String
		Dim dictionaryValue As String = ""
		shellFile = shellFile.Replace("\", "/")
		Dim shellFolder As String = Strings.Left(shellFile, InStrRev(shellFile, "/", -1, CompareMethod.Text))
		Dim completePath As String = ""
		parts = inputString.Split(separatorTags, StringSplitOptions.None)
		fileName = Strings.Right(parts(1), parts(1).Length - InStrRev(parts(1), "/", -1, CompareMethod.Text))
		If parts(1).StartsWith("/body/") Then
			parts(1) = parts(1).Replace("/body/", "body/")
		End If
		completePath = Path.GetFullPath(shellFolder + parts(1))
		If File.Exists(completePath) Then
			outputString = parts(0) & """" & parts(1) & """" & parts(2)
			Return outputString
		Else
			If parts(1).StartsWith("../_body/") Then
				parts(1) = parts(1).Replace("../_body/", "../_Generic/body/")
			End If
			completePath = Path.Combine(shellFolder, parts(1))
			If File.Exists(completePath) Then
				outputString = parts(0) & """" & parts(1) & """" & parts(2)
				outputString = outputString.Replace("__", "_")
				Return outputString
			Else
				completePath = Path.Combine("C:/Projects/WorksheetsGit/Worksheets/_Generic/body/" + fileName)
				If File.Exists(completePath) Then
					outputString = parts(0) & """../_Generic/body/" & fileName & """" & parts(2)
					outputString = outputString.Replace("__", "_")
					Return outputString
				End If
				If parts(1).ToLower.Contains("creditapp") Then
					parts(1) = "../_CreditApplication/" & parts(1)
				Else
					If parts(1).Contains("_") Then
						If pathDictionary.ContainsKey(LCase(Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1))) Then
							pathDictionary.TryGetValue(LCase(Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1)), dictionaryValue)
							parts(1) = "../" & dictionaryValue & "/body/" & fileName
						Else
							Dim isGroup As Boolean = False
							For i As Integer = 0 To groupDictionary.Keys.Count - 1
								If parts(1).ToLower.Contains(groupDictionary.Keys(i)) Then
									parts(1) = groupDictionary.Values(i) & "/body/" & fileName
									Dim temp = Path.GetFullPath("C:/Projects/WorksheetsGit/Worksheets/" + parts(1))
									If File.Exists(temp) Then
										parts(1) = "../" & groupDictionary.Values(i) & "/body/" & fileName
										isGroup = True
									End If
								End If
							Next
							If Not isGroup = True Then
								parts(1) = "../" & Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1) & "/body/" & fileName
							End If
						End If
					End If
				End If
			End If
			outputString = parts(0) & """" & parts(1) & """" & parts(2)
			outputString = outputString.Replace("__", "_")
		End If
		Return outputString
	End Function

	Private Sub quickLoadButton_Click(sender As Object, e As EventArgs) Handles quickLoadButton.Click
		Dim foundWindow As Boolean = False
		For Each p As Process In Process.GetProcesses
			If p.MainWindowTitle.ToLower.Contains("worksheetsgit") And p.MainWindowTitle.ToLower.Contains("visual studio code") Then
				foundWindow = True
				Dim openFileName = p.MainWindowTitle.Replace("● ", "")
				openFileName = Strings.Left(openFileName, InStr(openFileName.ToLower, ".xslt", CompareMethod.Text) + 4)
				Dim openFilePath As String = GetWorksheetPath(openFileName, True).Replace("/", "\")
				openFilePath = openFilePath.Replace("_body.xslt", ".xslt").Replace("_Body.xslt", ".xslt").Replace("_body2.xslt", ".xslt").Replace("_Body2.xslt", ".xslt").Replace("_body3.xslt", ".xslt").Replace("_Body3.xslt", ".xslt").Replace("_body4.xslt", ".xslt").Replace("_Body4.xslt", ".xslt")
				openFilePath = openFilePath.Replace("\body\", "\").Replace("\Body\", "\")

				If File.Exists(openFilePath) Then
					targetXSL = openFilePath
					targetWorksheet.Load(openFilePath)
					loadWorksheet(targetXSL)
				Else
					MsgBox("Not able to locate the file via quick load. Please open your worksheet manually with the 'Open Worksheet' option in the File menu drop down." & vbCrLf & openFilePath, MsgBoxStyle.Exclamation, "Quick Load Failure")
				End If
				Exit For
			End If
		Next
		If foundWindow = False Then MsgBox("Either Visual Studio Code is not active, or you do not have the Worksheet Solution open at the WorksheetsGit level. ")
	End Sub

	Public Function GetWorksheetPath(WorksheetFileName As String, Optional GetFullPath As Boolean = False) As String
		Dim fileName = WorksheetFileName.Replace("\", "/")
		fileName = fileName.Replace("_body.xslt", ".xslt").Replace("_Body.xslt", ".xslt").Replace("_body2.xslt", ".xslt").Replace("_Body2.xslt", ".xslt").Replace("_body3.xslt", ".xslt").Replace("_Body3.xslt", ".xslt").Replace("_body4.xslt", ".xslt").Replace("_Body4.xslt", ".xslt")
		fileName = fileName.Replace("/body/", "/").Replace("/Body/", "/")
		Dim filePath As String = ""
		Dim dictionaryValue As String = ""
		Dim gitFolder As String = "C:/Projects/WorksheetsGit/Worksheets/"
		fileName = Strings.Right(fileName, fileName.Length - InStrRev(fileName, "/", -1, CompareMethod.Text))
		If File.Exists(gitFolder & "_CreditApplication/" & fileName) Then
			filePath = "_CreditApplication/" & fileName
		ElseIf File.Exists(gitFolder & "_CreditApplication/body/" & fileName) Then
			filePath = "_CreditApplication/body/" & fileName
		ElseIf File.Exists(gitFolder & "_CreditAppButton/" & fileName) Then
			filePath = "_CreditAppButton/" & fileName
		ElseIf fileName.Contains("_") Then
			If pathDictionary.ContainsKey(LCase(Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1))) Then
				pathDictionary.TryGetValue(LCase(Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1)), dictionaryValue)
				filePath = dictionaryValue & "/" & fileName
			Else
				Dim isGroup As Boolean = False
				For i As Integer = 0 To groupDictionary.Keys.Count - 1
					If fileName.ToLower.Contains(groupDictionary.Keys(i)) Then
						filePath = groupDictionary.Values(i) & "/" & fileName
						If File.Exists(gitFolder & filePath) Then
							isGroup = True
						Else
							filePath = filePath.Replace(gitFolder, "").Replace(groupDictionary.Values(i) & "/", "")
						End If
						filePath = filePath.Replace(gitFolder, "")
					End If
				Next
				If isGroup = False Then
					If Char.IsDigit(fileName.Chars(0)) Then
						filePath = String.Format("_Generic/{0}", fileName)
					Else
						filePath = Strings.Left(fileName, InStr(fileName, "_", CompareMethod.Text) - 1) & "/" & fileName
					End If
				End If
			End If
		ElseIf fileName.Contains(".xslt") Then
			'File name does not contain underscore
			If pathDictionary.ContainsKey(LCase(Strings.Left(fileName, InStr(fileName, ".xslt", CompareMethod.Text) - 1))) Then
				pathDictionary.TryGetValue(LCase(Strings.Left(fileName, InStr(fileName, ".xslt", CompareMethod.Text) - 1)), dictionaryValue)
				filePath = dictionaryValue & "/" & fileName
			Else
				Dim isGroup As Boolean = False
				For i As Integer = 0 To groupDictionary.Keys.Count - 1
					If fileName.ToLower.Contains(groupDictionary.Keys(i)) Then
						filePath = groupDictionary.Values(i) & "/" & fileName
						If File.Exists(gitFolder & filePath) Then
							isGroup = True
						Else
							filePath = filePath.Replace(gitFolder, "").Replace(groupDictionary.Values(i) & "/", "")
						End If
						filePath = filePath.Replace(gitFolder, "")
					End If
				Next
				If isGroup = False Then
					If Char.IsDigit(fileName.Chars(0)) Then
						filePath = String.Format("_Generic/{0}", fileName)
					Else
						filePath = Strings.Left(fileName, InStr(fileName, ".xslt", CompareMethod.Text) - 1) & "/" & fileName
					End If
				End If
			End If
		End If

		If GetFullPath Then filePath = gitFolder & filePath
		filePath = filePath.Replace("/", "\")
		Return filePath
	End Function

	Public Sub backupWorksheet(wsFileName)
		wsFileName = wsFileName.replace("/", "\")
		Dim tempReader = File.OpenText(wsFileName)
		Dim tempText = tempReader.ReadToEnd
		tempReader.Close()
		Dim wsFileNameOnly = Strings.Right(wsFileName, wsFileName.Length - InStrRev(wsFileName, "\", -1, CompareMethod.Text))
		If Not System.IO.Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups")) Then
			System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups"))
		End If
		Dim currentDate = System.DateTime.Now
		'Dim dateString = "(" & currentDate.Month & "." & currentDate.Day & "." & currentDate.Year & "." & currentDate.Hour & "." & currentDate.Minute & ")"
		'Dim backUpFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups\" & wsFileNameOnly & dateString & ".backup")
		Dim backUpFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups\" & wsFileNameOnly & ".backup")
		Dim sw As StreamWriter = File.CreateText(backUpFile)
		sw.Write(tempText)
		sw.Close()
	End Sub

	Public Sub restoreWorksheet(wsFileName)
		wsFileName = wsFileName.replace("/", "\")
		Dim wsFileNameOnly = Strings.Right(wsFileName, wsFileName.Length - InStrRev(wsFileName, "\", -1, CompareMethod.Text))
		Try
			Dim backUpFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups\" & wsFileNameOnly & ".backup")
			Dim tempReader = File.OpenText(backUpFile)
			Dim tempText = tempReader.ReadToEnd
			tempReader.Close()
			Dim sw As StreamWriter = File.CreateText(wsFileName)
			sw.Write(tempText)
			sw.Close()
		Catch
			MsgBox("Error reading Backup")
		End Try
	End Sub

	Private Sub UndoAllChangesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoAllChangesToolStripMenuItem.Click
		restoreWorksheet(targetXSL)
	End Sub

	Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
		Dim about = New About(String.Format("{0}.{1}", displayArea.Version.Major.ToString(), displayArea.Version.Minor.ToString()))
		about.ShowDialog(Me)
	End Sub
	Public Sub clearBackups()
		Dim backupDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\FormBackups")
		If Directory.Exists(backupDirectory) Then
			For Each backup As String In My.Computer.FileSystem.GetFiles(backupDirectory, FileIO.SearchOption.SearchTopLevelOnly, "*")
				My.Computer.FileSystem.DeleteFile(backup, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
			Next
		End If
	End Sub

	Private Sub Blorp_Click(sender As Object, e As EventArgs) Handles blorp.Click
		'Dim test As New SnippetPreProcess
		'test.ShowDialog()

		MsgBox(System.Environment.UserName)
	End Sub

	Private Sub createParagraph_Click(sender As Object, e As EventArgs)
		Dim styles As String() = {"font-size", "14px", "vertical-align", "bottom"}
		Dim other As String() = {""}
		CreateElement("p", styles, other, " ")
	End Sub

	Private Sub createHeader1_Click(sender As Object, e As EventArgs)
		Dim styles As String() = {"font-size", "14px", "vertical-align", "bottom"}
		Dim other As String() = {""}
		CreateElement("h1", styles, other, " ")
	End Sub

	Private Sub createHeader2Button_Click(sender As Object, e As EventArgs)
		Dim styles As String() = {"font-size", "14px", "vertical-align", "bottom"}
		Dim other As String() = {""}
		CreateElement("h2", styles, other, " ")
	End Sub

	Private Sub borderTopButton_Click(sender As Object, e As EventArgs) Handles borderTopButton.Click
		removeStyle("border-top")
		If borderTopButton.BackColor = colorGray2 Then
			updateClass("bt")
			borderTopButton.BackColor = colorButton
			borderTopButton.FlatAppearance.BorderSize = 2
			borderTopButton.FlatAppearance.BorderColor = colorButton
		Else
			removeClass("bt")
			borderTopButton.BackColor = colorGray2
			borderTopButton.FlatAppearance.BorderSize = 1
			borderTopButton.FlatAppearance.BorderColor = Color.Black
		End If
	End Sub

	Private Sub borderBottomButton_Click(sender As Object, e As EventArgs) Handles borderBottomButton.Click
		removeStyle("border-bottom")
		If borderBottomButton.BackColor = colorGray2 Then
			updateClass("bb")
			borderBottomButton.BackColor = colorButton
			borderBottomButton.FlatAppearance.BorderSize = 2
			borderBottomButton.FlatAppearance.BorderColor = colorButton
		Else
			removeClass("bb")
			borderBottomButton.BackColor = colorGray2
			borderBottomButton.FlatAppearance.BorderSize = 1
			borderBottomButton.FlatAppearance.BorderColor = Color.Black
		End If
	End Sub

	Private Sub borderRightButton_Click(sender As Object, e As EventArgs) Handles borderRightButton.Click
		removeStyle("border-right")
		If borderRightButton.BackColor = colorGray2 Then
			updateClass("br")
			borderRightButton.BackColor = colorButton
			borderRightButton.FlatAppearance.BorderSize = 2
			borderRightButton.FlatAppearance.BorderColor = colorButton
		Else
			removeClass("br")
			borderRightButton.BackColor = colorGray2
			borderRightButton.FlatAppearance.BorderSize = 1
			borderRightButton.FlatAppearance.BorderColor = Color.Black
		End If
	End Sub

	Private Sub borderLeftButton_Click(sender As Object, e As EventArgs) Handles borderLeftButton.Click
		removeStyle("border-left")
		If borderLeftButton.BackColor = colorGray2 Then
			updateClass("bl")
			borderLeftButton.BackColor = colorButton
			borderLeftButton.FlatAppearance.BorderSize = 2
			borderLeftButton.FlatAppearance.BorderColor = colorButton
		Else
			removeClass("bl")
			borderLeftButton.BackColor = colorGray2
			borderLeftButton.FlatAppearance.BorderSize = 1
			borderLeftButton.FlatAppearance.BorderColor = Color.Black
		End If
	End Sub

	Private Sub bgColorDropButton_Click(sender As Object, e As EventArgs) Handles bgColorDropButton.Click
		If Not bgColorButtonHTML.BackColor = colorGray2 Then
			htmlBGColorPicker.Color = bgColorButtonHTML.BackColor
		End If
		htmlBGColorPicker.ShowDialog(Me)
		bgColorButtonHTML.BackColor = htmlBGColorPicker.Color
		bgColorDropButton.BackColor = htmlBGColorPicker.Color
		If htmlBGColorPicker.Color.GetBrightness < 0.4 Then
			bgColorButtonHTML.ForeColor = Color.White
		Else
			bgColorButtonHTML.ForeColor = Color.Black
		End If
	End Sub

	Private Sub fontColorButton_Click(sender As Object, e As EventArgs) Handles fontColorButton.Click
		updateStyle("color", ColorTranslator.ToHtml(fontColorButton.ForeColor))
	End Sub

	Private Sub fontColorDropButton_Click(sender As Object, e As EventArgs) Handles fontColorDropButton.Click
		htmlFontColorPicker.Color = fontColorButton.ForeColor
		htmlFontColorPicker.ShowDialog(Me)
		If htmlFontColorPicker.Color.GetBrightness < 0.4 Then
			fontColorDropButton.BackColor = Color.LightGray
			fontColorButton.BackColor = Color.LightGray
		Else
			fontColorDropButton.BackColor = Color.DarkGray
			fontColorButton.BackColor = Color.DarkGray
		End If
		fontColorButton.ForeColor = htmlFontColorPicker.Color
	End Sub

	Private Sub colspanBox_ValueChanged(sender As Object, e As EventArgs) Handles colspanBox.Click, colspanBox.KeyUp
		Dim tempTD As mshtml.HTMLTableCell = targetElement.DomElement
		tempTD.colSpan = colspanBox.Value
	End Sub
	Private Sub rowspanBox_ValueChanged(sender As Object, e As EventArgs) Handles rowspanBox.Click, rowspanBox.KeyUp
		Dim tempTD As mshtml.HTMLTableCell = targetElement.DomElement
		tempTD.rowSpan = rowspanBox.Value
	End Sub

	Private Sub CloseCurrentFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseCurrentFileToolStripMenuItem.Click
		displayArea.Document.OpenNew(True)
		displayArea.Document.OpenNew(True)
	End Sub

	Public Sub buttonPress(sender As Control, e As EventArgs)
		undoHistory.AddChange(targetElement)
		Dim desiredCode As String
		Dim buttonNodeName = sender.Name
		Dim frameNodeName = sender.Parent.Text
		Dim tabNodeName = sender.Parent.Parent.Text
		Dim tabNode = banksyInputFile.DocumentElement.SelectSingleNode(tabNodeName)
		Dim frameNode = tabNode.SelectSingleNode(frameNodeName)
		Dim buttonNode = frameNode.SelectSingleNode(buttonNodeName)
		Dim newKey As Integer = xslValueOfDictionary.Count
		Dim IDString As String() = {"id", newKey}
		xslValueOfDictionary.Add(newKey, xslTagDictionary.Item(tabNodeName & "/" & frameNodeName & "/" & buttonNodeName))

		Dim xmlDoc As New XmlDocument
		xmlDoc.Load(targetXML)
		Dim xDoc As XDocument
		Using xmlReader = New XmlNodeReader(xmlDoc.DocumentElement)
			xDoc = XDocument.Load(xmlReader)
		End Using

		Dim xp As New xPath
		Dim xPathString As String = xp.ParseFromString(xslValueOfDictionary.Values(newKey))
		Dim nameSpaceMGR As New XmlNamespaceManager(xmlDoc.NameTable)
		Dim node As XmlNode
		nameSpaceMGR.AddNamespace("x", "http://www.elead.us/AppSchema.xsd")

		Try
			node = xmlDoc.DocumentElement.SelectNodes(xPathString, nameSpaceMGR)(0)
		Catch ex As Exception
			desiredCode = String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", newKey, xslValueOfDictionary.Values(newKey).Substring(xslValueOfDictionary.Values(newKey).IndexOf("""") + 1, xslValueOfDictionary.Values(newKey).LastIndexOf("""") - xslValueOfDictionary.Values(newKey).IndexOf("""") - 1))
		End Try

		If Not node Is Nothing Then
			Try
				CreateElement("xslvalueof", Nothing, IDString, node.InnerText)
			Catch ex As Exception
				CreateElement("xslvalueof", Nothing, IDString, xslValueOfDictionary.Values(newKey).Substring(xslValueOfDictionary.Values(newKey).IndexOf("""") + 1, xslValueOfDictionary.Values(newKey).LastIndexOf("""") - xslValueOfDictionary.Values(newKey).IndexOf("""") - 1))
				Exit Sub
			End Try
		Else
			CreateElement("xslvalueof", Nothing, IDString, xslValueOfDictionary.Values(newKey).Substring(xslValueOfDictionary.Values(newKey).IndexOf("""") + 1, xslValueOfDictionary.Values(newKey).LastIndexOf("""") - xslValueOfDictionary.Values(newKey).IndexOf("""") - 1))
			Exit Sub
		End If
	End Sub

	Private Function ConvertToAppsSchema(directory As String) As String
		If directory.Length = 0 Then
			MsgBox("No file selected.")
			Return ""
		End If
		Dim outputString As String = ""
		Using sr As StreamReader = File.OpenText(directory)
			outputString = sr.ReadToEnd
		End Using
		outputString = Replace(outputString, "x:TradeIn/", "")
		outputString = Replace(outputString, "x:TradeIn[1]/", "")
		outputString = Replace(outputString, "x:TradeIn[2]/", "")
		outputString = Replace(outputString, "x:TradeIn[x:Year !=0]/", "")
		outputString = Replace(outputString, "x:TradeIn[x:Year != 0]/", "")
		outputString = Replace(outputString, "x:TradeIn[x:Payoff !='']/", "")
		outputString = Replace(outputString, "x:TradeIn[x:Payoff !='']/", "")
		outputString = Replace(outputString, "x:TradeIn", "")
		outputString = Replace(outputString, "x:TradeIn/", "")
		outputString = Replace(outputString, "x:Company/", "/x:AppSchemaBase/x:Company/")
		outputString = Replace(outputString, "x:Customer/", "/x:AppSchemaBase/x:Customer/")
		outputString = Replace(outputString, "x:Customer[1]/", "/x:AppSchemaBase/x:Customer[1]/")
		outputString = Replace(outputString, "x:Customer[2]/", "/x:AppSchemaBase/x:Customer[2]/")
		outputString = Replace(outputString, "x:Opportunity/", "/x:AppSchemaBase/x:Opportunity/")
		outputString = Replace(outputString, "x:SalesPerson/", "/x:AppSchemaBase/x:SalesPerson/")
		outputString = Replace(outputString, "x:SalesTeam/", "/x:AppSchemaBase/x:SalesTeam/")
		outputString = Replace(outputString, "x:DeskingManager/", "/x:AppSchemaBase/x:DeskingManager/")
		outputString = Replace(outputString, "x:Address/", "/x:AppSchemaBase/x:Address/")
		outputString = Replace(outputString, "x:Address[1]/", "/x:AppSchemaBase/x:Address[1]/")
		outputString = Replace(outputString, "x:Address[2]/", "/x:AppSchemaBase/x:Address[2]/")
		outputString = Replace(outputString, "x:Address[3]/", "/x:AppSchemaBase/x:Address[3]/")
		outputString = Replace(outputString, "x:Address[4]/", "/x:AppSchemaBase/x:Address[4]/")
		outputString = Replace(outputString, "x:Opportunity/", "/x:AppSchemaBase/x:Opportunity/")
		outputString = Replace(outputString, "x:PersonInsurance/", "/x:AppSchemaBase/x:PersonInsurance/")
		outputString = Replace(outputString, "x:VehicleSought/", "/x:AppSchemaBase/x:VehicleSought/")
		outputString = Replace(outputString, "x:Inventory/", "/x:AppSchemaBase/x:Inventory/")
		outputString = Replace(outputString, "x:VehicleSought[", "/x:AppSchemaBase/x:VehicleSought[")
		outputString = Replace(outputString, "x:Inventory[", "/x:AppSchemaBase/x:Inventory[")
		outputString = Replace(outputString, "x:PaymentGrid/", "/x:AppSchemaBase/x:PaymentGrid/")
		outputString = Replace(outputString, "x:SalesQuote/", "/x:AppSchemaBase/x:SalesQuote/")
		outputString = Replace(outputString, "x:SalesQuote[", "/x:AppSchemaBase/x:SalesQuote[")
		outputString = Replace(outputString, "x:Fee/", "/x:AppSchemaBase/x:Fee/")
		outputString = Replace(outputString, "x:Fee[", "/x:AppSchemaBase/x:Fee[")
		outputString = Replace(outputString, "x:Lien/", "/x:AppSchemaBase/x:Lien/")
		outputString = Replace(outputString, "x:BEAdd/", "/x:AppSchemaBase/x:BEAdd/")
		outputString = Replace(outputString, "x:BEAdd[", "/x:AppSchemaBase/x:BEAdd[")
		outputString = Replace(outputString, "x:Tax/", "/x:AppSchemaBase/x:Tax/")
		outputString = Replace(outputString, "x:Vehicle/", "/x:AppSchemaBase/x:Vehicle/")
		outputString = Replace(outputString, "x:Vehicle[1]/", "/x:AppSchemaBase/x:Vehicle[1]/")
		outputString = Replace(outputString, "x:Vehicle[2]/", "/x:AppSchemaBase/x:Vehicle[2]/")
		outputString = Replace(outputString, "x:Vehicle[3]/", "/x:AppSchemaBase/x:Vehicle[3]/")
		outputString = Replace(outputString, "x:Vehicle[4]/", "/x:AppSchemaBase/x:Vehicle[4]/")
		outputString = Replace(outputString, "x:CreditApplication/", "/x:AppSchemaBase/x:CreditApplication/")
		outputString = Replace(outputString, "/x:AppSchemaBase//x:AppSchemaBase/", "/x:AppSchemaBase/")
		outputString = Replace(outputString, "/x:AppSchemaBase//x:AppSchemaBase/", "/x:AppSchemaBase/")
		Return outputString
	End Function

	Private Function ConvertFromAppschema(directory As String) As String
		Dim outputString As String = ""
		Using sr As StreamReader = File.OpenText(directory)
			outputString = sr.ReadToEnd
		End Using


		Using sr As StreamReader = File.OpenText(directory)
			outputString = sr.ReadToEnd
		End Using
		Dim formContentCorrected = ""
		Dim stream_reader As New IO.StringReader(outputString)
		Dim line As String
		Try
			line = stream_reader.ReadLine()
			Do While Not (line Is Nothing)
				formContentCorrected &= line & vbCrLf
				line = stream_reader.ReadLine()
			Loop
			stream_reader.Close()
		Catch ex As Exception
			errorMessage = ex.Message.ToString
			handleError(ex)
		End Try
		Dim sw As StreamWriter = File.CreateText(targetXSL)
		sw.Write(formContentCorrected)
		sw.Close()

		outputString = Replace(outputString, """x:Year", "x:TradeIn/x:Year")
		outputString = Replace(outputString, """x:Make", "x:TradeIn/x:Make")
		outputString = Replace(outputString, """x:Book", "x:TradeIn/x:Book")
		outputString = Replace(outputString, """x:BookValue", "x:TradeIn/x:BookValue")
		outputString = Replace(outputString, """x:MarketValue", "x:TradeIn/x:MarketValue")
		outputString = Replace(outputString, """x:Model", "x:TradeIn/x:Model")
		outputString = Replace(outputString, """x:Trim", "x:TradeIn/x:Trim")
		outputString = Replace(outputString, """x:VIN", "x:TradeIn/x:VIN")
		outputString = Replace(outputString, """x:Mileage", "x:TradeIn/x:Mileage")
		outputString = Replace(outputString, """x:ExtColor", "x:TradeIn/x:ExtColor")
		outputString = Replace(outputString, """x:ACVValue", "x:TradeIn/x:ACVValue")
		outputString = Replace(outputString, """x:TradeAllowance", "x:TradeIn/x:TradeAllowance")
		outputString = Replace(outputString, """x:Payoff", "x:TradeIn/x:Payoff")
		outputString = Replace(outputString, """x:PayoffGoodUntil", "x:TradeIn/x:PayoffGoodUntil")
		outputString = Replace(outputString, """x:LicenseRegState", "x:TradeIn/x:LicenseRegState")
		outputString = Replace(outputString, """x:LicensePlateNumber", "x:TradeIn/x:LicensePlateNumber")
		outputString = Replace(outputString, """x:LicensePlateRegNumber", "x:TradeIn/x:LicensePlateRegNumber")
		outputString = Replace(outputString, """x:InsuranceCompany", "x:TradeIn/x:InsuranceCompany")
		outputString = Replace(outputString, """x:InsurancePolicyNumber", "x:TradeIn/x:InsurancePolicyNumber")
		outputString = Replace(outputString, """x:LenderName", "x:TradeIn/x:LenderName")
		outputString = Replace(outputString, """x:LenderPhone", "x:TradeIn/x:LenderPhone")
		outputString = Replace(outputString, """x:LenderAccountNumber", "x:TradeIn/x:LenderAccountNumber")
		outputString = Replace(outputString, """x:PrimaryTrade", "x:TradeIn/x:PrimaryTrade")
		outputString = Replace(outputString, """x:IsLeased", "x:TradeIn/x:IsLeased")
		outputString = Replace(outputString, """x:AppraisedBy", "x:TradeIn/x:AppraisedBy")
		outputString = Replace(outputString, """x:AppraisedByDate", "x:TradeIn/x:AppraisedByDate")
		outputString = Replace(outputString, " x:Year", "x:TradeIn/x:Year")
		outputString = Replace(outputString, " x:Make", "x:TradeIn/x:Make")
		outputString = Replace(outputString, " x:Book", "x:TradeIn/x:Book")
		outputString = Replace(outputString, " x:BookValue", "x:TradeIn/x:BookValue")
		outputString = Replace(outputString, " x:MarketValue", "x:TradeIn/x:MarketValue")
		outputString = Replace(outputString, " x:Model", "x:TradeIn/x:Model")
		outputString = Replace(outputString, " x:Trim", "x:TradeIn/x:Trim")
		outputString = Replace(outputString, " x:VIN", "x:TradeIn/x:VIN")
		outputString = Replace(outputString, " x:Mileage", "x:TradeIn/x:Mileage")
		outputString = Replace(outputString, " x:ExtColor", "x:TradeIn/x:ExtColor")
		outputString = Replace(outputString, " x:ACVValue", "x:TradeIn/x:ACVValue")
		outputString = Replace(outputString, " x:TradeAllowance", "x:TradeIn/x:TradeAllowance")
		outputString = Replace(outputString, " x:Payoff", "x:TradeIn/x:Payoff")
		outputString = Replace(outputString, " x:PayoffGoodUntil", "x:TradeIn/x:PayoffGoodUntil")
		outputString = Replace(outputString, " x:LicenseRegState", "x:TradeIn/x:LicenseRegState")
		outputString = Replace(outputString, " x:LicensePlateNumber", "x:TradeIn/x:LicensePlateNumber")
		outputString = Replace(outputString, " x:LicensePlateRegNumber", "x:TradeIn/x:LicensePlateRegNumber")
		outputString = Replace(outputString, " x:InsuranceCompany", "x:TradeIn/x:InsuranceCompany")
		outputString = Replace(outputString, " x:InsurancePolicyNumber", "x:TradeIn/x:InsurancePolicyNumber")
		outputString = Replace(outputString, " x:LenderName", "x:TradeIn/x:LenderName")
		outputString = Replace(outputString, " x:LenderPhone", "x:TradeIn/x:LenderPhone")
		outputString = Replace(outputString, " x:LenderAccountNumber", "x:TradeIn/x:LenderAccountNumber")
		outputString = Replace(outputString, " x:PrimaryTrade", "x:TradeIn/x:PrimaryTrade")
		outputString = Replace(outputString, " x:IsLeased", "x:TradeIn/x:IsLeased")
		outputString = Replace(outputString, " x:AppraisedBy", "x:TradeIn/x:AppraisedBy")
		outputString = Replace(outputString, " x:AppraisedByDate", "x:TradeIn/x:AppraisedByDate")
		outputString = Replace(outputString, "/x:AppSchemaBase/", "")
		Return outputString
	End Function

	Private Function ConvertSpecialCharacters(directory As String) As String
		If directory.Length = 0 Then
			MsgBox("No file selected.")
			Return ""
		End If
		Dim outputString As String = ""
		Using sr As StreamReader = File.OpenText(directory)
			outputString = sr.ReadToEnd
		End Using
		outputString = Replace(outputString, "Á", "&#193;")
		outputString = Replace(outputString, "á", "&#225;")
		outputString = Replace(outputString, "É", "&#201;")
		outputString = Replace(outputString, "é", "&#233;")
		outputString = Replace(outputString, "Í", "&#205;")
		outputString = Replace(outputString, "í", "&#237;")
		outputString = Replace(outputString, "Ó", "&#211;")
		outputString = Replace(outputString, "ó", "&#243;")
		outputString = Replace(outputString, "Ú", "&#218;")
		outputString = Replace(outputString, "ú", "&#250;")
		outputString = Replace(outputString, "Ñ", "&#209;")
		outputString = Replace(outputString, "ñ", "&#241;")
		outputString = Replace(outputString, "¿", "&#191;")
		outputString = Replace(outputString, "¡", "&#161;")
		outputString = Replace(outputString, "& ", "&amp; ")
		outputString = Replace(outputString, ““““, """")
		outputString = Replace(outputString, ””””, """")


		Return outputString
	End Function

	Private Sub writeTag(outputString)
		If Not targetElement.OuterHtml = "" Then
			Try
				Dim sel As IHTMLSelectionObject = Nothing
				Dim selectionRange As IHTMLTxtRange = Nothing
				Dim rangeParent As IHTMLElement4 = Nothing
				Dim duplicateRange As IHTMLTxtRange = Nothing
				Dim temp As IHTMLDocument2 = displayArea.Document.DomDocument
				sel = TryCast(temp.selection, IHTMLSelectionObject)
				selectionRange = sel.createRange
				rangeParent = selectionRange.parentElement.parentElement
				Dim test As mshtml.IHTMLObjectElement = selectionRange.parentElement.parentElement
				Dim elementPar As System.Windows.Forms.HtmlElement = test.object
				MsgBox(elementPar.OuterHtml)

				selectionRange.text = outputString
				UpdateCurrentElement(targetElement)
			Catch ex As Exception
				handleError(ex)
			End Try
		End If
	End Sub

	Private Sub widthBox_KeyUp(sender As Object, e As EventArgs) Handles widthBox.KeyUp
		If widthUnitBox.Text = "%" Then
			updateClass("w" & Val(widthBox.Value))
		Else
			updateStyle("width", widthBox.Value & widthUnitBox.Text)
		End If
	End Sub
	Private Sub widthBox_Click(sender As Object, e As EventArgs) Handles widthBox.Click
		updateStyle("width", widthBox.Value & widthUnitBox.Text)
	End Sub
	Private Sub heightBox_KeyUp(sender As Object, e As EventArgs) Handles heightBox.KeyUp, heightBox.Click
		updateStyle("height", heightBox.Value & heightUnitBox.Text)
	End Sub

	Private Function GetElementPointer(elementToPoint)
		Dim currentLevel = elementToPoint
		Dim pointer As String = ""
		Do While Not currentLevel.Parent = displayArea.Document.Body.Parent
			If currentElement.Parent.HasChildren Then
				Dim elementCollection = currentLevel.Parent.Children
				For i As Integer = 0 To elementCollection.Count - 1
					If elementCollection.Item(i) = currentLevel Then
						If pointer.Length = 0 Then
							pointer = i
						Else
							pointer = i & "/" & pointer
						End If
					End If
				Next
			End If
			currentLevel = currentLevel.Parent
		Loop
		Return pointer
	End Function

	Private Function GetElementFromPointer(pointer)
		Dim parsedPointer As String()
		parsedPointer = Split(pointer, "/")
		Dim selector = displayArea.Document.Body
		For i As Integer = 0 To parsedPointer.Count - 1
			Dim j As Integer = Val(parsedPointer(i))
			selector = selector.Children.Item(j)
		Next
		If selector IsNot Nothing Then
			Return selector
		Else
			Return -1
		End If
	End Function

	Private Sub undoButton_Click(sender As Object, e As EventArgs) Handles undoButton.Click
		undoHistory.UndoLast()
	End Sub

	Private Sub redoButton_Click(sender As Object, e As EventArgs) Handles redoButton.Click
		undoHistory.RedoLast()
	End Sub
	Public Sub MoveCanvas()
		Dim crpos As Point = Me.PointToClient(Me.DesktopLocation)
		With CanvasForm
			.DesktopLocation = New Point(Me.DesktopLocation.X + displayArea.Location.X - crpos.X, Me.DesktopLocation.Y + displayArea.Location.Y - crpos.Y + 1)

			If Not Me.WindowState = FormWindowState.Minimized Then
				.WindowState = FormWindowState.Normal
			Else
				.WindowState = Me.WindowState
			End If
			.Size = displayArea.ClientSize - New Size(0, 1)
			.ShowInTaskbar = False
			.Refresh()
		End With
	End Sub
	Private Sub WSGUIWindow_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.Resize, MyBase.ResizeEnd, MyBase.Move, MyBase.Shown
		MoveCanvas()
	End Sub
	Private Sub CreateElement(TagName As String, Styles As String(), OtherAttributes() As String, Optional InnerText As String = "")
		undoHistory.AddChange(targetElement)
		Dim newElement = displayArea.Document.CreateElement(TagName)
		If OtherAttributes.Length > 1 Then
			For i As Integer = 0 To (OtherAttributes.Count / 2) - 1
				newElement.SetAttribute(OtherAttributes.ElementAt(i * 2), OtherAttributes.ElementAt(i * 2 + 1))
			Next
		End If
		If Not IsNothing(Styles) Then
			If Styles.Length > 1 Then
				For i As Integer = 0 To (Styles.Count / 2) - 1
					updateStyle(Styles.ElementAt(i * 2), Styles.ElementAt(i * 2 + 1), newElement)
				Next
			End If
		End If
		If InnerText.Length > 0 Then newElement.InnerText = InnerText
		If (targetElement IsNot Nothing) Then
			Try
				Dim sel As IHTMLSelectionObject = Nothing
				Dim selectionRange As IHTMLTxtRange = Nothing
				Dim newElementSub As IHTMLElement = Nothing
				Dim temp As IHTMLDocument2 = displayArea.Document.DomDocument
				sel = TryCast(temp.selection, IHTMLSelectionObject)
				selectionRange = sel.createRange
				targetElement = displayArea.Document.All()(selectionRange.parentElement.sourceIndex)

				If Not selectionRange Is Nothing Then
					Dim bookmark = selectionRange.getBookmark

					selectionRange.pasteHTML(newElement.OuterHtml.ToString)
					selectionRange.moveToBookmark(bookmark)
					selectionRange.moveStart("character", -newElement.InnerHtml.Length - 1)
					UpdateCurrentElement(targetElement)
				Else
					targetElement.AppendChild(newElement)
				End If
			Catch ex As Exception
				Try
					targetElement.AppendChild(newElement)
				Catch ex2 As Exception
					MsgBox("Unable to place element there." & vbCrLf & ex2.Message.ToString)
				End Try
			End Try
		Else
			MsgBox("Not sure where to put element.")
		End If
		MoveCanvas()

	End Sub

	Private Function CreateChildElement(TagName As String, Styles As String(), OtherAttributes() As String, Optional InnerText As String = "") As System.Windows.Forms.HtmlElement
		Dim newElement = displayArea.Document.CreateElement(TagName)
		If OtherAttributes.Length > 1 Then
			For i As Integer = 0 To (OtherAttributes.Count / 2) - 1
				newElement.SetAttribute(OtherAttributes.ElementAt(i * 2), OtherAttributes.ElementAt(i * 2 + 1))
			Next
		End If
		If Styles.Length > 1 Then
			For i As Integer = 0 To (Styles.Count / 2) - 1
				updateStyle(Styles.ElementAt(i * 2), Styles.ElementAt(i * 2 + 1), newElement)
			Next
		End If
		If InnerText.Length > 0 Then newElement.InnerText = InnerText
		Return newElement
	End Function

	Private Sub InsertHTMLElement(newElement As System.Windows.Forms.HtmlElement, Optional element As System.Windows.Forms.HtmlElement = Nothing)
		undoHistory.AddChange(targetElement)
		If element Is Nothing Then
			element = targetElement
		End If
		If (targetElement IsNot Nothing) Then
			Try
				Dim sel As IHTMLSelectionObject = Nothing
				Dim selectionRange As IHTMLTxtRange = Nothing
				Dim newElementSub As IHTMLElement = Nothing
				Dim temp As IHTMLDocument2 = displayArea.Document.DomDocument
				sel = TryCast(temp.selection, IHTMLSelectionObject)
				selectionRange = sel.createRange
				If Not selectionRange Is Nothing Then
					Dim bookmark = selectionRange.getBookmark
					selectionRange.pasteHTML(newElement.OuterHtml.ToString)
					selectionRange.moveToBookmark(bookmark)
					selectionRange.moveStart("character", -newElement.InnerHtml.Length - 1)
					UpdateCurrentElement(targetElement)
				Else
					element.AppendChild(newElement)
				End If
			Catch ex As Exception
				MsgBox("Unable to place element there." & vbCrLf & ex.Message.ToString)
			End Try
		Else
			MsgBox("Not sure where to put element.")
		End If
	End Sub

	Private Sub displayArea_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles displayArea.PreviewKeyDown
		If _skipPreviewKeyDown = True Then
			_skipPreviewKeyDown = False
			Exit Sub
		Else
			_skipPreviewKeyDown = True
		End If

		If (displayArea.Document IsNot Nothing) Then
			Dim isAlt As Boolean = (Control.ModifierKeys And Keys.Alt) > 0
			Dim isCtrl As Boolean = (Control.ModifierKeys And Keys.Control) > 0
			Dim isShift As Boolean = (Control.ModifierKeys And Keys.Shift) > 0

			If editMode Then
				BrowserCursorMove()
				targetElement.Focus()
				If e.KeyCode = Keys.Delete Then undoHistory.AddChange(targetElement)

				If isCtrl Then
					Select Case e.KeyCode
						Case Keys.Y
							undoHistory.RedoLast()
						Case Keys.Z
							If TypingCountdown.Enabled Then TypingCountdown_Tick(sender, e)
							undoHistory.UndoLast()
						Case Keys.C
							doc.ExecCommand("copy", True, Nothing)
							e.IsInputKey = True
						Case Keys.X
							undoHistory.AddChange(targetElement)
							doc.ExecCommand("cut", True, Nothing)
						Case Keys.V
							undoHistory.AddChange(targetElement)
							doc.ExecCommand("paste", True, Nothing)
							e.IsInputKey = True
						Case Keys.B
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Boldify!"
							doc.ExecCommand("bold", True, Nothing)
							e.IsInputKey = True
						Case Keys.I
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Italicize!"
							doc.ExecCommand("italic", True, Nothing)
							e.IsInputKey = True
						Case Keys.U
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Underline!"
							doc.ExecCommand("underline", True, Nothing)
							e.IsInputKey = True
						Case Keys.L
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Align Left!"
							doc.ExecCommand("justifyLeft", True, Nothing)
							e.IsInputKey = True
						Case Keys.R
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Align Right!"
							doc.ExecCommand("justifyRight", True, Nothing)
							e.IsInputKey = True
						Case Keys.E
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Align Center!"
							doc.ExecCommand("justifyCenter", True, Nothing)
							e.IsInputKey = True
						Case Keys.J
							undoHistory.AddChange(targetElement)
							showStatus.Text = "Justify!"
							doc.ExecCommand("justifyFull", True, Nothing)
						Case Keys.Oemplus
							If isShift Then
								undoHistory.AddChange(targetElement)
								showStatus.Text = "Subscript!"
								doc.ExecCommand("subscript", True, Nothing)
							Else
								undoHistory.AddChange(targetElement)
								showStatus.Text = "Superscript!"
								doc.ExecCommand("superscript", True, Nothing)
							End If
					End Select
				Else
					If e.KeyCode = Keys.Return Then
						Dim sel As IHTMLSelectionObject = Nothing
						Dim selectionRange As IHTMLTxtRange = Nothing
						Dim newElementSub As IHTMLElement = Nothing
						Dim temp As IHTMLDocument2 = doc.DomDocument
						sel = TryCast(temp.selection, IHTMLSelectionObject)
						selectionRange = sel.createRange
						If Not selectionRange Is Nothing Then
							Dim bookmark = selectionRange.getBookmark
							selectionRange.pasteHTML("<br>")
						End If
						showStatus.Text = "New line!"
						If Not TypingCountdown.Enabled Then
							undoHistory.StartRecordingChange(targetElement, targetElement.Parent.OuterHtml)
							TypingCountdown.Enabled = True
							TypingCountdown.Start()
						Else
							'This whole 'Else' section is a test
							'stop
							TypingCountdown.Stop()
							undoHistory.StopRecordingChange()
							parentElementHTML = targetElement.Parent.OuterHtml
							TypingCountdown.Enabled = False
							'restart
							undoHistory.StartRecordingChange(targetElement, targetElement.Parent.OuterHtml)
							TypingCountdown.Enabled = True
							TypingCountdown.Start()
						End If

						'This applies only if the key pressed is an arrow key
					ElseIf e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
						_skipPreviewKeyDown = False

					ElseIf Char.IsLetterOrDigit(Convert.ToChar(e.KeyCode)) Then
						If targetElement.Parent IsNot Nothing And Not targetElement = Nothing Then
							If Not TypingCountdown.Enabled Then
								undoHistory.StartRecordingChange(targetElement, targetElement.Parent.OuterHtml)
								TypingCountdown.Enabled = True
								TypingCountdown.Start()
							End If
						End If
					End If
				End If
			ElseIf isCtrl Then
				Select Case e.KeyCode
					Case Keys.O
						openWorksheetOption.PerformClick()
				End Select
			End If
			UpdateCurrentElement(targetElement)
			MoveCanvas()
		End If

	End Sub

	Public Sub BrowserCursorMove()
		Dim sel As IHTMLSelectionObject = Nothing
		Dim selectionRange As IHTMLTxtRange = Nothing
		Dim rangeParent As IHTMLElement4 = Nothing
		Dim temp As IHTMLDocument2 = displayArea.Document.DomDocument
		sel = TryCast(temp.selection, IHTMLSelectionObject)
		selectionRange = sel.createRange
		rangeParent = selectionRange.parentElement
		Dim focusedElement = displayArea.Document.GetElementById(selectionRange.parentElement.id)
		If Not focusedElement = targetElement Then
			targetElement = focusedElement
			ElementSelect(targetElement)
			If TypingCountdown.Enabled Then
				TypingCountdown.Stop()
				undoHistory.StopRecordingChange()
				parentElementHTML = targetElement.Parent.OuterHtml
				TypingCountdown.Enabled = False
			End If
		End If
	End Sub

	Private Sub elementLosingFocus(sender As Object, e As EventArgs)
		If TypingCountdown.Enabled Then TypingCountdown_Tick(sender, e)
	End Sub

	Private Sub document_Scroll()
		MoveCanvas()
	End Sub

	Private Sub UpdateCurrentElement(element As System.Windows.Forms.HtmlElement)
		Dim text As String = ""
		currentElementEditEnabled = False
		Select Case targetElement.TagName.ToLower
			Case "xslvalueof"
				currentElement.Text = xslValueOfDictionary.Values(Val(element.GetAttribute("origID")))
			Case "xslif"
				currentElement.Text = xslIfDictionary.Values(Val(element.GetAttribute("origID")))
			Case "xslchoose"
				currentElement.Text = xslChooseDictionary.Values(Val(element.GetAttribute("origID")))
			Case Else
				If editMode Then
					Dim newText As String = element.OuterHtml.ToString.TrimStart(vbCrLf).Replace("&nbsp;", "&#160;").Replace("></xsl: value-of>", " />").Replace("contenteditable=""true""", "").Replace("contenteditable=""false""", "")
					newText = Regex.Replace(newText, "\sid=\""editID[0-9]+\""", "")
					currentElement.Text = newText.Replace("origid=", "id=")
					currentElementEditEnabled = True
				Else
					currentElement.Text = element.OuterHtml.ToString.TrimStart(vbCrLf).Replace("&nbsp;", "&#160;").Replace("></xsl: value-of>", " />").Replace("contenteditable=""true""", "").Replace("contenteditable=""false""", "")
					currentElementEditEnabled = False
				End If
		End Select
		currentElement.Text = currentElement.Text.Replace("  ", " ")

		For i As Integer = 0 To currentElement.Lines.Count - 1
			currentElement.Lines.SetValue(currentElement.Lines.ElementAt(i).Trim, i)
		Next

	End Sub

	Private Sub currentElement_KeyUp(sender As Object, e As KeyEventArgs) Handles currentElement.KeyDown
		If e.KeyCode = Keys.Enter Then
			If My.Computer.Keyboard.CtrlKeyDown And currentElementEditEnabled Then
				Try
					targetElement.OuterHtml = currentElement.Text
					UpdateCurrentElement(targetElement)
					e.Handled = True
				Catch ex As Exception
					MsgBox("Unable to set current element's HTML." & vbCrLf & ex.Message.ToString)
				End Try
			End If
		End If
	End Sub

	Private Sub TypingCountdown_Tick(sender As Object, e As EventArgs) Handles TypingCountdown.Tick
		TypingCountdown.Stop()
		undoHistory.StopRecordingChange()
		parentElementHTML = targetElement.Parent.OuterHtml
		TypingCountdown.Enabled = False
	End Sub

	Private Sub CssButtonClick(c As String, Optional element As System.Windows.Forms.HtmlElement = Nothing)
		If element = Nothing Then element = targetElement
	End Sub

	Private Sub DoubleClickTimer_Tick(sender As Object, e As EventArgs) Handles DoubleClickTimer.Tick
		DoubleClickTimer.Enabled = False
	End Sub

	Private Sub basicStyleButtonAnswer_Click(sender As Object, e As EventArgs) Handles basicStyleButtonAnswer.Click
		ToggleClass("answer")
	End Sub

	Private Sub ToggleClass(targetClass As String)
		If HasClass(targetClass) Then
			removeClass(targetClass)
		Else
			updateClass(targetClass)
		End If
	End Sub

	Private Sub basicStyleButtonBlack_Click(sender As Object, e As EventArgs) Handles basicStyleButtonBlack.Click
		ToggleClass("black")
	End Sub

	Private Sub basicStylesSilverButton_Click(sender As Object, e As EventArgs) Handles basicStylesSilverButton.Click
		ToggleClass("silver")
	End Sub

	Private Sub ConvertToAppSchemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToAppSchemaToolStripMenuItem.Click
		Dim t As String = ChooseIncludedFile(targetWorksheet.GetFiles)
		Dim newCode = ConvertToAppsSchema(t)
		WriteWorksheet(t, newCode)
	End Sub

	Public Sub WriteWorksheet(targetDirectory As String, formCode As String, Optional MakePretty As Boolean = False)
		targetDirectory = targetDirectory.Replace("/", "\")
		If System.IO.Directory.Exists(Strings.Left(targetDirectory, InStrRev(targetDirectory, "\", -1, CompareMethod.Text))) Then
			If MakePretty Then
				formCode = PrettyXML(formCode)
			End If
			Dim xslWriteSetttings As XmlWriterSettings = New XmlWriterSettings
			xslWriteSetttings.Indent = Formatting.Indented
			xslWriteSetttings.IndentChars = ControlChars.Tab
			xslWriteSetttings.ConformanceLevel = ConformanceLevel.Fragment
			Using xw As XmlWriter = XmlTextWriter.Create(targetDirectory, xslWriteSetttings)
				xw.WriteRaw(formCode)
			End Using
		Else
			showStatus.Text = "The referenced directory does not exist."
		End If
	End Sub

	Private Function PrettyXML(XMLString As String) As String
		Dim sw As New StringWriterWithEncoding(System.Text.Encoding.UTF8)
		Dim settings As New XmlWriterSettings
		settings.Indent = True
		settings.IndentChars = " "
		settings.NamespaceHandling = NamespaceHandling.OmitDuplicates
		settings.NewLineHandling = NewLineHandling.None
		settings.CheckCharacters = False
		Dim xw As XmlWriter = XmlWriter.Create(sw, settings)
		Dim doc As New XmlDocument
		doc.LoadXml(XMLString.Replace("&", "~?!#~"))
		doc.Save(xw)
		xw.Close()
		sw.Close()
		Return sw.ToString().Replace("~?!#~", "&")
	End Function

	Private Sub MakeFormEditableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MakeFormEditableToolStripMenuItem.Click
		Dim ws As String = ChooseIncludedFile(targetWorksheet.GetFiles)
		Dim wc As WorksheetConverter = New WorksheetConverter(ws)
		Dim temp As String = wc.MakeWorksheetEditable()
		WriteWorksheet(ws, temp)
	End Sub

	Private Sub cursorPositionTimer_Tick(sender As Object, e As EventArgs) Handles cursorPositionTimer.Tick
		Dim cursorPos = GetCursorPositionInDocument()
		cursorPositionLabel.Text = "X: " & cursorPos.X & ", Y: " & cursorPos.Y
		If overlayMode Then
			CanvasForm.DragRectangleUpdate(GetCursorPositionInDocument)
		End If
	End Sub

	Private Sub ConvertExcelButton_Click(sender As Object, e As EventArgs) Handles ConvertExcelButton.Click
		ExcelConverter.ShowDialog(Me)
	End Sub

	Public Function ResolveMerge(w As String, Optional KeepHead As Boolean = False) As String
		Dim targetXSLContents As String = ""
		autoRefresh = False
		autoRefreshButton.BackColor = colorGray2
		refreshTimer.Enabled = False

		Using sr As StreamReader = File.OpenText(w)
			Do While sr.Peek() >= 0
				targetXSLContents = sr.ReadToEnd
			Loop
		End Using

		Dim HeadPosition As Integer = 0
		While HeadPosition <> -1
			HeadPosition = targetXSLContents.IndexOf("<<<<<<< HEAD", HeadPosition)
			If HeadPosition <> -1 Then
				Dim SeparatorPosition As Integer = targetXSLContents.IndexOf("=======", HeadPosition + 12) + 7
				If SeparatorPosition <> -1 Then
					Dim EndPosition As Integer = targetXSLContents.IndexOf(">>>>>>>", SeparatorPosition)
					Dim EndLength As Integer = targetXSLContents.IndexOf(vbCrLf, EndPosition) - EndPosition
					If EndPosition <> -1 Then
						If KeepHead Then
							targetXSLContents = targetXSLContents.Remove(SeparatorPosition - 7, (EndPosition - SeparatorPosition) + EndLength - 6)
							targetXSLContents = targetXSLContents.Remove(HeadPosition, 13)
							HeadPosition = EndPosition - (SeparatorPosition - HeadPosition)
						Else
							targetXSLContents = targetXSLContents.Remove(EndPosition, EndLength + 1)
							targetXSLContents = targetXSLContents.Remove(HeadPosition, (SeparatorPosition - HeadPosition + 1))
							HeadPosition = EndPosition - (SeparatorPosition - HeadPosition)
						End If
					End If
				End If
			End If
		End While
		Return targetXSLContents
	End Function

	Public Function TransformWorksheet(wsFileName As String) As String
		errorMessage = ""
		Dim targetWorksheet As New Worksheet.ShellFile
		Dim output As String
		Try
			output = targetWorksheet.TransformWorksheet(wsFileName, errorMessage, erSourceURI, targetXML, newStoreID, newStoreName, SalesQuoteCalculationTypeBox.Text)
		Catch ex As Exception
			handleError(ex)
			Return "I AM ERROR"
		End Try
		If errorMessage.Length > 0 Then
			handleError(Nothing, errorMessage)
			Dim errorHTML As String = errorMessage.Replace(erSourceURI, String.Format("<span style='color: red; font-weight:bold;'>{0}</span>", erSourceURI))
			Return String.Format("<div style='text-align: center; font-size:20pt; padding-top:50px;'><span style='font-weight: bold; font-size:30pt;'>I AM ERROR <img height='100px' src='C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\ERROR.png' /></span><br>An error has occured. Please see below. <br><div style='font-size:12pt;'>{0}</div></div>", errorHTML)
		Else
			codingBuddy.Clear()
			Return output
		End If
	End Function

	Private Sub chromepreviewbutton_Click(sender As Object, e As EventArgs) Handles chromepreviewbutton.Click
		Try
			System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\Temp"))
			Dim temp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\Temp\chrometest.html")
			WriteWorksheet(temp, TransformWorksheet(targetXSL))
			Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", temp)
		Catch ex As Exception
			errorMessage = ex.Message
			handleError(ex)
		End Try
	End Sub

	Private Sub overlayModeButton_Click(sender As Object, e As EventArgs) Handles overlayModeButton.Click
		If overlayMode = False Then
			overlayMode = True
			overlayModeButton.BackColor = colorButton
		Else
			overlayMode = False
			overlayModeButton.BackColor = colorGray2
		End If
	End Sub

	Private Sub ImageOverlayWorksheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageOverlayWorksheetToolStripMenuItem.Click
		newFileType = 2
		saveWorksheetDialog.ShowDialog(Me)
	End Sub

	Private Sub UpdateOldCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateOldCodeToolStripMenuItem.Click
		Dim targetFile As String = ChooseIncludedFile(targetWorksheet.GetFiles)
		Dim converter As WorksheetConverter = New WorksheetConverter(targetFile)
		Dim newCode As String = converter.UpdateOldCode()
		WriteWorksheet(targetFile, newCode)
		MsgBox(newCode)
	End Sub

	Private Sub CreateBodyForCreditAppButtonFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateBodyForCreditAppButtonFormToolStripMenuItem.Click
		Dim converter As WorksheetConverter = New WorksheetConverter(targetXSL)
		converter.CreateCreditAppButtonBodyFile()
	End Sub

	Private Sub columnInsertRight_Click(sender As Object, e As EventArgs) Handles columnInsertRight.Click
		Try
			Dim tbl As mshtml.HTMLTable = targetElement.GetParentTable.DomElement
			Dim td As mshtml.IHTMLTableCell = targetElement.DomElement
			Dim newTD As mshtml.IHTMLElement
			Dim cells = tbl.GetColumnCells(td.cellIndex)
			For Each cell As mshtml.HTMLTableCell In cells
				newTD = cell.cloneNode(True)
				newTD.innerText = " "
				cell.insertAdjacentElement("afterEnd", newTD)
			Next
		Catch ex As Exception
			errorMessage = ex.Message
			handleError(ex)
		End Try
	End Sub

	Private Sub columnInsertLeft_Click(sender As Object, e As EventArgs) Handles columnInsertLeft.Click
		Try
			Dim tbl As mshtml.HTMLTable = targetElement.GetParentTable.DomElement
			Dim td As mshtml.IHTMLTableCell = targetElement.DomElement
			Dim newTD As mshtml.IHTMLElement
			Dim cells = tbl.GetColumnCells(td.cellIndex)
			For Each cell As mshtml.HTMLTableCell In cells
				newTD = cell.cloneNode(True)
				newTD.innerText = " "
				cell.insertAdjacentElement("beforeBegin", newTD)
			Next
		Catch ex As Exception
			errorMessage = ex.Message
			handleError(ex)
		End Try
	End Sub

	Private Sub UnhandledError(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
		Dim ex = TryCast(e.ExceptionObject, Exception)
		If Not IsNothing(ex) Then
			errorMessage = ex.Message
			handleError(ex)
		End If
	End Sub

	Private Sub ViewTagCreatorButton_Click(sender As Object, e As EventArgs) Handles ViewTagCreatorButton.Click
		If tagCreator.Visible = False Then
			ViewTagCreatorButton.BackColor = colorButton
			tagCreator.Visible = True
			LeftSplitContainer.Width = 200
		Else
			ViewTagCreatorButton.BackColor = colorGray2
			tagCreator.Visible = False
			LeftSplitContainer.Width = 112
		End If
	End Sub

	Private Sub lCompanyIDInput_KeyUp(sender As Object, e As KeyEventArgs) Handles lCompanyIDInput.KeyUp
		'lCompanyIDInput.DroppedDown = True
		Dim index As Integer
		Dim actual As String
		Dim found As String
		Dim isCtrl As Boolean = (Control.ModifierKeys And Keys.Control) > 0
		Dim isAlt As Boolean = (Control.ModifierKeys And Keys.Alt) > 0
		Dim isShift As Boolean = (Control.ModifierKeys And Keys.Shift) > 0

		' Do nothing for some keys such as navigation keys.
		If ((e.KeyCode = Keys.Back) Or
			(e.KeyCode = Keys.Left) Or
			(e.KeyCode = Keys.Right) Or
			(e.KeyCode = Keys.Up) Or
			(e.KeyCode = Keys.Delete) Or
			(e.KeyCode = Keys.Down) Or
			(e.KeyCode = Keys.PageUp) Or
			(e.KeyCode = Keys.PageDown) Or
			(e.KeyCode = Keys.Home) Or
			(e.KeyCode = Keys.Control) Or
			(e.KeyCode = Keys.Alt) Or
			(e.KeyCode = Keys.Tab) Or
			(e.KeyCode = Keys.Shift) Or
			(e.KeyCode = Keys.LShiftKey) Or
			(e.KeyCode = Keys.RShiftKey) Or
			(e.KeyCode = Keys.ShiftKey) Or
			(e.KeyCode = Keys.LControlKey) Or
			(e.KeyCode = Keys.RControlKey) Or
			(isCtrl) Or
			(isAlt) Or
			(isShift) Or
			(e.KeyCode = Keys.End)) Then
			Return
		End If

		If ((e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Return)) Then
			lCompanyIDInput.SelectionStart = lCompanyIDInput.Text.Length
			lCompanyIDInput.SelectionLength = 0
			Call lCompanyIDInput_Leave(sender, e)
			Return
		End If

		' Store the actual text that has been typed.
		actual = lCompanyIDInput.Text
		If actual.Length > 0 Then

			' Find the first match for the typed value.
			If Char.IsDigit(actual.Chars(0)) Or actual.StartsWith("(") Then
				index = lCompanyIDInput.FindSubString(actual)
			Else
				index = lCompanyIDInput.FindString(actual)
			End If


			' Get the text of the first match.
			If (index > -1) Then
				found = lCompanyIDInput.Items(index).ToString()

				' Select this item from the list.
				lCompanyIDInput.SelectedIndex = index

				' Select the portion of the text that was automatically
				' added so that additional typing will replace it.
				If actual.StartsWith("(") Then
					lCompanyIDInput.SelectionStart = 0
					lCompanyIDInput.SelectionLength = lCompanyIDInput.Text.LastIndexOf(actual) + actual.Length
				ElseIf lCompanyIDInput.SelectionLength < 1 Then
					lCompanyIDInput.SelectionStart = actual.Length
					lCompanyIDInput.SelectionLength = found.Length
				Else
					lCompanyIDInput.SelectionStart = actual.Length - lCompanyIDInput.SelectionLength
					lCompanyIDInput.SelectionLength = found.Length
				End If
			End If
		End If
	End Sub
	Private Sub lCompanyIDInput_Leave(sender As Object, e As EventArgs) Handles lCompanyIDInput.Leave
		Dim resultIndex As Integer = -1

		resultIndex = lCompanyIDInput.FindStringExact(lCompanyIDInput.Text)

		If resultIndex > -1 Then
			Dim parStart As Integer = lCompanyIDInput.Text.LastIndexOf("(") + 1
			Dim parLenth As Integer = lCompanyIDInput.Text.LastIndexOf(")") - parStart
			newStoreID = lCompanyIDInput.Text.Substring(parStart, parLenth)
			newStoreName = lCompanyIDInput.Text.Substring(0, parStart - 2)
		Else
			lCompanyIDInput.Text = ""
		End If
	End Sub

	Private Sub TakeScreenshot_Click(sender As Object, e As EventArgs) Handles TakeScreenshot.Click
		Dim bmpRectangle As Rectangle
		Dim bmpLocation As Point
		Dim SelectWindow As New Tutorial(bmpRectangle, bmpLocation)
		SelectWindow.ShowDialog(Me)
		bmpRectangle = SelectWindow.bmpRectangle

		If bmpRectangle.Width > 100 And bmpRectangle.Height > 100 Then
			Dim ScreenShot As Bitmap = New Bitmap(bmpRectangle.Width, bmpRectangle.Height, Imaging.PixelFormat.Format24bppRgb)


			Using g As Graphics = Graphics.FromImage(ScreenShot)
				g.CopyFromScreen(bmpRectangle.X, bmpRectangle.Y, 0, 0, bmpRectangle.Size, CopyPixelOperation.SourceCopy)
				Dim WorksheetBuilderStatus As New ImageConversionStatus

				WorksheetBuilderStatus.ImageToConvert = ScreenShot
				WorksheetBuilderStatus.ShowDialog()


				'displayArea.Document.OpenNew(True)
				'displayArea.DocumentText = WorksheetBuilderStatus.Output
				CefSharp.WebBrowserExtensions.LoadHtml(cefBrowser, WorksheetBuilderStatus.Output, "http://test/")

				ScreenShot.Dispose()
			End Using
		Else
			Me.showStatus.Text = "Screenshot Canceled"
		End If
	End Sub

	Private Sub dealPackInsertionButton_Click(sender As Object, e As EventArgs) Handles dealPackInsertionButton.Click
		Dim Insert As New DealPackInsertForm
		Insert.ShowDialog()
	End Sub

	Private Sub ConvertSavedImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertSavedImageToolStripMenuItem.Click
		Dim getImage As New OpenFileDialog
		getImage.Filter = "All Image Files|*.bmp; *.jpeg; *.jpg; *.png; *.tiff|All files (*.*)|*.*"
		getImage.FilterIndex = 1
		getImage.ShowDialog()
		Dim ScreenShot As Bitmap = New Bitmap(getImage.FileName)
		Dim clone As Bitmap = New Bitmap(ScreenShot.Width, ScreenShot.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
		Using g As Graphics = Graphics.FromImage(clone)
			g.DrawImage(ScreenShot, New Rectangle(0, 0, clone.Width, clone.Height))
		End Using
		ScreenShot.Dispose()

		If clone.Width > 100 And clone.Height > 100 Then
			Dim WorksheetBuilderStatus As New ImageConversionStatus

			WorksheetBuilderStatus.ImageToConvert = clone
			WorksheetBuilderStatus.ShowDialog()

			Me.Text = "Conversion Results - Worksheet Previewer"
			CefSharp.WebBrowserExtensions.LoadHtml(cefBrowser, WorksheetBuilderStatus.Output, "http://test/")
			DocumentCompleted()

			clone.Dispose()
		Else
			Me.showStatus.Text = "Screenshot Canceled"
		End If
	End Sub
End Class