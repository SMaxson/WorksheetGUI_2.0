Imports System.IO
Imports System.Xml
Public Class UndoStack
	Dim undoHistory As XmlDocument
	Dim redoHistory As XmlDocument
	Dim undoFile = "WSGUI_UndoHistory.xml"
	Dim redoFile = "WSGUI_RedoHistory.xml"
	Dim undoDirectory As String
	Dim redoDirectory As String
	Dim storedPointer As String
	Dim storedValue As String
	Dim ChangeInProgress As Boolean = False


	Public Sub New()
		undoHistory = New XmlDocument
		redoHistory = New XmlDocument
		undoHistory.CreateXmlDeclaration("1.0", "utf-8", "yes")
		redoHistory.CreateXmlDeclaration("1.0", "utf-8", "yes")
		Dim undoRoot = undoHistory.CreateElement("UndoHistory")
		undoHistory.AppendChild(undoRoot)
		Dim redoRoot = redoHistory.CreateElement("RedoHistory")
		redoHistory.AppendChild(redoRoot)

		If Not System.IO.Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools")) Then
			System.IO.Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer"))
		End If
		undoDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\" & undoFile)
		undoHistory.Save(undoDirectory)
		redoDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorksheetTools\WorksheetPreviewer\" & redoFile)
		redoHistory.Save(redoDirectory)
	End Sub

	Public Sub Clear()
		wsGUIWindow.unsavedChanges = True
		If Not wsGUIWindow.Text.Contains("●") Then
			wsGUIWindow.Text = wsGUIWindow.Text.Replace("● ", "")
		End If
		wsGUIWindow.redoButton.Enabled = False
		wsGUIWindow.undoButton.Enabled = False
		redoHistory.DocumentElement.RemoveAll()
		redoHistory.Save(redoDirectory)
		undoHistory.DocumentElement.RemoveAll()
		undoHistory.Save(undoDirectory)
	End Sub

	Public Sub AddChange(element As HtmlElement)
		If element.Parent IsNot Nothing Then
			wsGUIWindow.unsavedChanges = True
			If Not wsGUIWindow.Text.Contains("●") Then
				wsGUIWindow.Text = "● " & wsGUIWindow.Text
			End If
			wsGUIWindow.redoButton.Enabled = False
			Dim location As String = GetPointerFromElement(element)
			undoHistory.Load(undoDirectory)
			Dim undoRoot = undoHistory.SelectSingleNode("UndoHistory")
			Dim action = undoHistory.CreateElement("Action")
			Dim pointer = undoHistory.CreateElement("Pointer")
			Dim value = undoHistory.CreateElement("Value")
			pointer.InnerText = location
			value.InnerText = element.Parent.OuterHtml
			action.AppendChild(pointer)
			action.AppendChild(value)
			undoRoot.AppendChild(action)
			undoHistory.Save(undoDirectory)
			wsGUIWindow.undoButton.Enabled = True
			redoHistory.DocumentElement.RemoveAll()
			redoHistory.Save(redoDirectory)
		End If
	End Sub

	Public Sub AddChangeManually(element As HtmlElement, oldHTML As String)
		If element.Parent IsNot Nothing Then
			wsGUIWindow.unsavedChanges = True
			If Not wsGUIWindow.Text.Contains("●") Then
				wsGUIWindow.Text = "● " & wsGUIWindow.Text
			End If
			wsGUIWindow.redoButton.Enabled = False
			Dim location As String = GetPointerFromElement(element)
			undoHistory.Load(undoDirectory)
			Dim undoRoot = undoHistory.SelectSingleNode("UndoHistory")
			Dim action = undoHistory.CreateElement("Action")
			Dim pointer = undoHistory.CreateElement("Pointer")
			Dim value = undoHistory.CreateElement("Value")
			pointer.InnerText = location
			value.InnerText = oldHTML
			action.AppendChild(pointer)
			action.AppendChild(value)
			undoRoot.AppendChild(action)
			undoHistory.Save(undoDirectory)
			wsGUIWindow.undoButton.Enabled = True
			redoHistory.DocumentElement.RemoveAll()
			redoHistory.Save(redoDirectory)
		End If
	End Sub
	Public Sub StartRecordingChange(element As HtmlElement, oldHTML As String)
		If element.Parent IsNot Nothing Then
			wsGUIWindow.unsavedChanges = True
			If Not wsGUIWindow.Text.Contains("●") Then
				wsGUIWindow.Text = "● " & wsGUIWindow.Text
			End If
			Dim location As String = GetPointerFromElement(element)
			storedPointer = location
			storedValue = oldHTML

			redoHistory.DocumentElement.RemoveAll()
			redoHistory.Save(redoDirectory)
			wsGUIWindow.redoButton.Enabled = False
		End If
	End Sub
	Public Sub StopRecordingChange()
		wsGUIWindow.unsavedChanges = True
		If Not wsGUIWindow.Text.Contains("●") Then
			wsGUIWindow.Text = "● " & wsGUIWindow.Text
		End If

		undoHistory.Load(undoDirectory)
		Dim undoRoot = undoHistory.SelectSingleNode("UndoHistory")
		Dim action = undoHistory.CreateElement("Action")
		Dim pointer = undoHistory.CreateElement("Pointer")
		Dim value = undoHistory.CreateElement("Value")
		pointer.InnerText = storedPointer
		value.InnerText = storedValue
		action.AppendChild(pointer)
		action.AppendChild(value)
		undoRoot.AppendChild(action)
		undoHistory.Save(undoDirectory)
		wsGUIWindow.undoButton.Enabled = True
	End Sub

	Public Sub UndoLast()
		If Not ChangeInProgress Then
			ChangeInProgress = True
			undoHistory.Load(undoDirectory)
			Dim undoRoot = undoHistory.SelectSingleNode("UndoHistory")
			If undoRoot.HasChildNodes = True Then
				Dim action = undoRoot.LastChild
				Dim pointer = action.SelectSingleNode("Pointer")
				Dim value = action.SelectSingleNode("Value")
				Dim location = pointer.InnerText
				Try
					Dim selector = GetElementFromPointer(location)
					redoHistory.Load(redoDirectory)
					Dim redoRoot = redoHistory.DocumentElement
					Dim newAction = redoHistory.CreateElement("Action")
					Dim newPointer = redoHistory.CreateElement("Pointer")
					Dim newValue = redoHistory.CreateElement("Value")
					newPointer.InnerText = pointer.InnerText
					newValue.InnerText = selector.Parent.OuterHtml
					newAction.AppendChild(newPointer)
					newAction.AppendChild(newValue)
					redoRoot.AppendChild(newAction)
					wsGUIWindow.redoButton.Enabled = True
					redoHistory.Save(redoDirectory)
					selector.Parent.OuterHtml = value.InnerText
					undoRoot.RemoveChild(action)
					undoHistory.Save(undoDirectory)
					Dim d As mshtml.IHTMLDocument2 = wsGUIWindow.displayArea.Document.DomDocument
					d.designMode = "Off"
					If Not wsGUIWindow.overlayMode Then d.designMode = "On"

					wsGUIWindow.targetElement = selector
					wsGUIWindow.ElementSelect(selector)
					Dim el As mshtml.IHTMLElement3 = selector.DomElement
					Dim el2 As mshtml.IHTMLElement2 = selector.DomElement
					el.contentEditable = True
					selector.Focus()
					el.setActive()
					el2.focus()

				Catch ex As Exception
					MsgBox("Error reverting last change." & vbCrLf & "Error message:" & ex.Message)
					undoRoot.RemoveAll()
				End Try
				If undoRoot.ChildNodes.Count = 0 Then
					wsGUIWindow.undoButton.Enabled = False
				End If
			End If
			wsGUIWindow.MoveCanvas()
			ChangeInProgress = False
		End If
	End Sub

	Public Sub RedoLast()
		If Not ChangeInProgress Then
			ChangeInProgress = True
			redoHistory.Load(redoDirectory)
			Dim redoRoot = redoHistory.SelectSingleNode("RedoHistory")
			If redoRoot.HasChildNodes = True Then
				Dim action = redoRoot.LastChild
				Dim pointer = action.SelectSingleNode("Pointer")
				Dim value = action.SelectSingleNode("Value")
				Dim location = pointer.InnerText
				Dim selector = GetElementFromPointer(location)
				undoHistory.Load(undoDirectory)
				Dim undoRoot = undoHistory.DocumentElement
				Dim newAction = undoHistory.CreateElement("Action")
				Dim newPointer = undoHistory.CreateElement("Pointer")
				Dim newValue = undoHistory.CreateElement("Value")
				newPointer.InnerText = pointer.InnerText
				newValue.InnerText = selector.Parent.OuterHtml
				newAction.AppendChild(newPointer)
				newAction.AppendChild(newValue)
				undoRoot.AppendChild(newAction)
				wsGUIWindow.undoButton.Enabled = True
				undoHistory.Save(undoDirectory)
				selector.Parent.OuterHtml = value.InnerText

				Dim d As mshtml.IHTMLDocument2 = wsGUIWindow.displayArea.Document.DomDocument
				d.designMode = "Off"
				d.designMode = "On"
				wsGUIWindow.ElementSelect(selector)
				wsGUIWindow.targetElement = selector
				Dim el As mshtml.IHTMLElement3 = selector.DomElement
				Dim el2 As mshtml.IHTMLElement2 = selector.DomElement
				el.contentEditable = True
				selector.Focus()
				el.setActive()
				el2.focus()

				Dim sel As mshtml.IHTMLSelectionObject = Nothing
				Dim selectionRange As mshtml.IHTMLTxtRange = Nothing
				Dim temp As mshtml.IHTMLDocument2 = wsGUIWindow.displayArea.Document.DomDocument
				sel = TryCast(temp.selection, mshtml.IHTMLSelectionObject)

				redoRoot.RemoveChild(action)
				redoHistory.Save(redoDirectory)
				If redoRoot.ChildNodes.Count = 0 Then
					wsGUIWindow.redoButton.Enabled = False
				End If
			End If
			wsGUIWindow.MoveCanvas()
			ChangeInProgress = False
		End If
	End Sub

	Private Function GetPointerFromElement(element As System.Windows.Forms.HtmlElement) As String
		Dim currentLevel = element
		Dim location As String = ""

		Dim sel As mshtml.IHTMLSelectionObject = Nothing
		Dim selectionRange As mshtml.IHTMLTxtRange = Nothing
		Dim rangeParent As mshtml.IHTMLElement4 = Nothing
		Dim duplicateRange As mshtml.IHTMLTxtRange = Nothing
		Dim temp As mshtml.IHTMLDocument2 = wsGUIWindow.displayArea.Document.DomDocument
		Try
			sel = TryCast(temp.selection, mshtml.IHTMLSelectionObject)
			selectionRange = TryCast(sel.createRange, mshtml.IHTMLTxtRange)
			location = selectionRange.getBookmark
		Catch ex As Exception
			location = "NA"
		End Try
		Do While Not currentLevel.Parent = wsGUIWindow.displayArea.Document.Body.Parent
			Dim elementCollection = currentLevel.Parent.Children
			For i As Integer = 0 To elementCollection.Count - 1
				If elementCollection.Item(i) = currentLevel Then
					If location.Length = 0 Then
						location = i
					Else
						location = i & "/" & location
					End If
				End If
			Next
			currentLevel = currentLevel.Parent
		Loop
		Return location
	End Function
	Private Function GetElementFromPointer(pointer As String) As System.Windows.Forms.HtmlElement
		Dim parsedPointer As String()
		parsedPointer = Split(pointer, "/")
		Dim selector As System.Windows.Forms.HtmlElement = wsGUIWindow.displayArea.Document.Body
		For i As Integer = 0 To parsedPointer.Count - 2
			Dim j As Integer = Val(parsedPointer(i))
			selector = selector.Children.Item(j)
		Next
		Return selector
	End Function
End Class