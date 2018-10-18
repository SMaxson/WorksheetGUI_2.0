Imports System.IO
Imports System.Xml
Imports System.Linq
Imports System.Text.RegularExpressions

Public Class WorksheetConverter
	Dim wsFileName As String
	Public Sub New(WorksheetPath As String)
		wsFileName = WorksheetPath
	End Sub

	Public Function MakeWorksheetEditable() As String
		wsGUIWindow.backupWorksheet(wsFileName)
		Dim tempText As String
		Using tempReader = File.OpenText(wsFileName)
			tempText = tempReader.ReadToEnd
		End Using

		tempText = tempText.Replace("&", "~?!#~")
		Dim tempXML As New XmlDocument()


		Dim Settings = New XmlReaderSettings
		Settings.NameTable = New NameTable
		Dim xmlns = New XmlNamespaceManager(Settings.NameTable)
		Dim context = New XmlParserContext(Nothing, xmlns, "", XmlSpace.None)
		Settings.ConformanceLevel = ConformanceLevel.Document
		Dim reader = XmlReader.Create(wsFileName, Settings, context)
		'tempXML.Load(reader)
		tempXML.LoadXml(tempText)
		Dim root = tempXML.DocumentElement
		Dim tlist = tempXML.GetElementsByTagName("xsl:value-of")
		Dim i As Integer = tlist.Count - 1
		Do While i > -1
			Select Case tlist(i).ParentNode.Name
				Case "xsl:attribute"

				Case "xsl:variable"

				Case Else
					Dim t As XmlNode = tempXML.CreateElement("xsl:input")
					Dim att As XmlAttribute = tempXML.CreateAttribute("type")
					att.Value = "text"
					t.Attributes.Append(att)
					att = tempXML.CreateAttribute("class")
					att.Value = "w99 answer nobo nobg"
					t.Attributes.Append(att)
					att = tempXML.CreateAttribute("style")
					att.Value = "height:1.1em; font-size:inherit;"
					t.Attributes.Append(att)
					Dim ct = tempXML.CreateElement("xsl", "attribute", "http://www.w3.org/1999/XSL/Transform")
					att = tempXML.CreateAttribute("name")
					att.Value = "value"
					ct.Attributes.Append(att)
					Dim gct = tempXML.CreateElement("xsl", "value-of", "http://www.w3.org/1999/XSL/Transform")
					att = tempXML.CreateAttribute("select")
					att.Value = tlist(i).Attributes.GetNamedItem("select").Value
					gct.Attributes.Append(att)
					ct.AppendChild(gct)
					t.AppendChild(ct)
					tlist(i).ParentNode.ReplaceChild(t, tlist(i))
			End Select
			i -= 1
		Loop
		reader.Close()
		Return (tempXML.OuterXml.Replace("~?!#~", "&"))
	End Function

	Public Function UpdateOldCode() As String
		wsGUIWindow.backupWorksheet(wsFileName)
		Dim tempReader As TextReader = File.OpenText(wsFileName)
		Dim tempText = tempReader.ReadToEnd
		tempReader.Close()
		tempText = tempText.Replace("&", "~?!#~")
		Dim tempXML As New XmlDocument()

		tempXML.PreserveWhitespace = True


		tempXML.LoadXml(tempText)
		Dim root = tempXML.DocumentElement

		Dim tlist = root.ChildNodes

		UpdateOldCodeNode(tlist)
		'Dim i As Integer = tlist.Count - 1
		'Do While i > -1
		'	'tlist(i).ParentNode.ReplaceChild(newtlist(i), tlist(i))
		'	'MsgBox(newtlist(i).OuterXml)
		'	i -= 1
		'Loop
		'tempXML.Save(wsFileName)
		Return (tempXML.OuterXml.Replace("~?!#~", "&"))
	End Function

	Private Sub UpdateOldCodeNode(tlist As XmlNodeList) ' As XmlNodeList
		Dim RegExBorder As Regex = New Regex("\d+px\s*solid\s*black", RegexOptions.IgnoreCase)
		For Each node As XmlNode In tlist
			If node.NodeType = XmlNodeType.Element Then
				If node.Attributes.GetNamedItem("align") IsNot Nothing Then
					Select Case node.Attributes.GetNamedItem("align").Value
						Case "left"
							AddClass(node, "al")
							RemoveAttribute(node, "align")
						Case "center"
							AddClass(node, "ac")
							RemoveAttribute(node, "align")
						Case "right"
							AddClass(node, "ar")
							RemoveAttribute(node, "align")
					End Select
				End If
				If node.Attributes.GetNamedItem("valign") IsNot Nothing Then
					Select Case node.Attributes.GetNamedItem("valign").Value
						Case "top"
							AddClass(node, "at")
							RemoveAttribute(node, "valign")
						Case "middle"
							AddClass(node, "am")
							RemoveAttribute(node, "valign")
						Case "bottom"
							AddClass(node, "ab")
							RemoveAttribute(node, "valign")
					End Select
				End If
				'If node.Attributes.GetNamedItem("style") IsNot Nothing Then
				Dim sg As New StyleGenerator
				If node.Attributes.GetNamedItem("style") IsNot Nothing Then
					sg.ParseStyleString(node.Attributes.GetNamedItem("style").Value.ToLower)
				End If
				If sg.GetStyle("font-size").Length > 0 Then
					If (Val(sg.GetStyle("font-size")) Mod 2) = 1 Then
						AddClass(node, "f" & Val(sg.GetStyle("font-size")) + 1)
					Else
						AddClass(node, "f" & Val(sg.GetStyle("font-size")))
					End If
					sg.RemoveStyle("font-size")
					If sg.GetStyle("font-family").Length > 0 Then
						If sg.GetStyle("font-family").ToLower.StartsWith("arial") Then sg.RemoveStyle("font-family")
					End If
				End If
				If RegExBorder.IsMatch(sg.GetStyle("border-top")) Then
					AddClass(node, "bt" & Val(sg.GetStyle("border-top")))
					sg.RemoveStyle("border-top")
				End If
				If RegExBorder.IsMatch(sg.GetStyle("border-right")) Then
					AddClass(node, "br" & Val(sg.GetStyle("border-right")))
					sg.RemoveStyle("border-right")
				End If
				If RegExBorder.IsMatch(sg.GetStyle("border-bottom")) Then
					AddClass(node, "bb" & Val(sg.GetStyle("border-bottom")))
					sg.RemoveStyle("border-bottom")
				End If
				If RegExBorder.IsMatch(sg.GetStyle("border-left")) Then
					AddClass(node, "bl" & Val(sg.GetStyle("border-left")))
					sg.RemoveStyle("border-left")
				End If

				Select Case sg.GetStyle("font-weight").ToLower
					Case "bold", "700"
						AddClass(node, "bold")
						sg.RemoveStyle("font-weight")
					Case "bolder", "900"
						AddClass(node, "bolder")
						sg.RemoveStyle("font-weight")
					Case Else
				End Select
				Select Case sg.GetStyle("text-align").ToLower
					Case "left"
						AddClass(node, "al")
						sg.RemoveStyle("text-align")
					Case "center"
						AddClass(node, "ac")
						sg.RemoveStyle("text-align")
					Case "right"
						AddClass(node, "ar")
						sg.RemoveStyle("text-align")
					Case "justify"
						AddClass(node, "justify")
						sg.RemoveStyle("text-align")
				End Select
				If sg.GetStyle("font-family").ToLower.EndsWith("%") Then
					AddClass(node, "w" & Val(sg.GetStyle("width")))
					sg.RemoveStyle("width")
				End If
				If sg.GetStyle("width").ToLower.EndsWith("%") And Not sg.GetStyle("width").ToLower.Contains(".") Then
					AddClass(node, "w" & Val(sg.GetStyle("width")))
					sg.RemoveStyle("width")
				ElseIf Not IsNothing(node.Attributes.GetNamedItem("width")) Then
					If Not node.Attributes.GetNamedItem("width").InnerText.Contains("*") Then
						If node.Attributes.GetNamedItem("width").InnerText.Contains("%") Then
							AddClass(node, "w" & Val(node.Attributes.GetNamedItem("width").InnerText))
						Else
							sg.SetStyle("width", node.Attributes.GetNamedItem("width").InnerText.Replace("px", "") & "px")
						End If
					End If
					RemoveAttribute(node, "width")
				End If
				UpdateStyle(node, sg)
				sg.Clear()
				'End If
				If Not IsNothing(node.Attributes.GetNamedItem("cellpadding")) Then node.Attributes.RemoveNamedItem("cellpadding")
				If Not IsNothing(node.Attributes.GetNamedItem("cellspacing")) Then node.Attributes.RemoveNamedItem("cellspacing")
				If Not IsNothing(node.Attributes.GetNamedItem("border")) Then node.Attributes.RemoveNamedItem("border")

				If (node.ChildNodes.Count > 0) Then
					UpdateOldCodeNode(node.ChildNodes)
				End If
			End If
		Next
	End Sub

	Private Sub AddClass(element As XmlNode, targetClass As String)
		Dim ClassGenerator = New ClassGenerator()
		If element.Attributes.GetNamedItem("class") IsNot Nothing Then
			ClassGenerator.ParseClassString(element.Attributes.GetNamedItem("class").Value)
		End If
		ClassGenerator.SetClass(targetClass)
		element.Attributes.RemoveNamedItem("class")
		Dim classes As XmlNode = element.OwnerDocument.CreateAttribute("class")
		classes.Value = ClassGenerator.GetClassString()
		element.Attributes.Prepend(classes)
		ClassGenerator.Clear()
	End Sub

	Private Sub RemoveAttribute(element As XmlNode, attribute As String)
		element.Attributes.RemoveNamedItem(attribute)
	End Sub

	Private Sub UpdateStyle(element As XmlNode, sg As StyleGenerator)
		element.Attributes.RemoveNamedItem("style")
		Dim newStyles As String = sg.GetStyleString()
		If newStyles.Length > 0 Then
			Dim styles As XmlNode = element.OwnerDocument.CreateAttribute("style")
			styles.Value = newStyles
			element.Attributes.Prepend(styles)
		End If
		sg.Clear()
	End Sub

	Public Function CreateCreditAppButtonBodyFile()
		Try
			Dim newShellDirectory As String = wsFileName '.Replace(".xslt", "_wBody.xslt").Replace("/", "\")
			newShellDirectory = "C:\Projects\WorksheetsGit\Worksheets\_CreditApplication\" & Strings.Right(newShellDirectory, (newShellDirectory.Length - InStrRev(newShellDirectory, "\", -1, CompareMethod.Text)))
			Dim newDirectory As String = wsFileName.Replace(".xslt", "_Body.xslt").Replace("/", "\")
			newDirectory = "C:\Projects\WorksheetsGit\Worksheets\_CreditApplication\body\" & Strings.Right(newDirectory, (newDirectory.Length - InStrRev(newDirectory, "\", -1, CompareMethod.Text)))
			wsGUIWindow.backupWorksheet(wsFileName)
			Dim tempText As String = ""
			'Using tempReader As TextReader = File.OpenText(wsFileName)
			'	tempText = tempReader.ReadToEnd
			'End Using
			Using tempReader As TextReader = File.OpenText(wsFileName)
				''Original
				'SourceCode = tempReader.ReadToEnd


				Dim line As String
				line = tempReader.ReadLine()
				Do While Not (line Is Nothing)
					If line.Length > 0 Then
						tempText &= line.Trim & vbCrLf
					End If
					line = tempReader.ReadLine()
				Loop
			End Using
			tempText = tempText.Replace("&", "~?!#~")
			Dim tempXML As New XmlDocument()
			tempXML.PreserveWhitespace = True

			tempXML.LoadXml(tempText.Replace("&", "~?!#~"))

			Dim root = tempXML.DocumentElement
			Dim templateElement = root.GetElementsByTagName("xsl:template")
			If Not templateElement.Count > 1 Then
				Dim newBody As New Worksheet.BodyFile
				newBody.CreateBody(newDirectory, templateElement(0).InnerXml.Replace("~?!#~", "&"))
				'wsGUIWindow.WriteWorksheet(newDirectory, newBody.ReturnCode, True)
				newBody.Save(newDirectory)

				Dim newShell As New Worksheet.ShellFile
				If root.GetElementsByTagName("msxsl:script").Count > 0 Then
					Dim Functions As String = ""
					For Each script As XmlNode In root.GetElementsByTagName("msxsl:script")
						Functions &= script.OuterXml
					Next
					newShell.CreateShell(newDirectory, Functions)
				Else
					newShell.CreateShell(newDirectory)
				End If
				wsGUIWindow.WriteWorksheet(newShellDirectory, newShell.ReturnCode, True)
				wsGUIWindow.loadWorksheet(newShellDirectory)
			End If
			Return 1
		Catch ex As Exception
			wsGUIWindow.showStatus.Text = ex.Message
			Return 0
		End Try
	End Function

	Public Function PrepareBodyFileForEdit()
		Try
			wsGUIWindow.backupWorksheet(wsFileName)
			Dim tempText As String
			Dim i As Integer
			Using tempReader As TextReader = File.OpenText(wsFileName)
				tempText = tempReader.ReadToEnd
			End Using
			tempText = tempText.Replace("&", "~?!#~")
			Dim tempXML As New XmlDocument()

			tempXML.LoadXml(tempText)
			Dim root = tempXML.DocumentElement
			'Dim htmlElement = root.GetElementsByTagName("html")
			'If htmlElement.Count = 1 Then
			'	Dim editedBodyCode As XmlNode = htmlElement(0).Clone
			'	'editedBodyCode.
			'End If
			Dim valueNodes = root.GetElementsByTagName("xsl:value-of")
			For k As Integer = 0 To valueNodes.Count - 1
				i = valueNodes.Count - k - 1
				valueNodes(i).Attributes.GetNamedItem("select")

			Next
			Dim templateElement = root.GetElementsByTagName("xsl:template")
			If Not templateElement.Count > 1 Then
				Dim newBody As New Worksheet.BodyFile
				'newBody.CreateBody(newDirectory, templateElement(0).InnerXml.Replace("~?!#~", "&"))

			End If
			Return 1
		Catch ex As Exception
			wsGUIWindow.showStatus.Text = ex.Message
			Return 0
		End Try
	End Function

	Private Function getxPathAndFormat(input As String) As String
		Dim xp As New xPath
		Dim FormatString As String = ""
		Dim PathString As String = xp.ParseFromString(input)
		If input.Contains("format-number") Then
			Dim parLevel As Integer = 0
			Dim StartIndex As Integer = input.IndexOf("format-number") + 13
			Dim EndIndex As Integer = StartIndex
			For i As Integer = StartIndex To input.Count - 1
				Select Case input.Chars(i)
					Case ","
						If parLevel = 1 Then StartIndex = i
					Case "("
						parLevel += 1
					Case ")"
						parLevel -= 1
						If parLevel = 0 Then
							EndIndex = i - 1
							Exit For
						End If
					Case Else
						Continue For
				End Select
			Next
			FormatString = input.Substring(StartIndex, EndIndex - StartIndex + 1)
			FormatString = FormatString.Replace("""", "").Replace("'", "")
			FormatString = FormatString.Trim
			'Select Case FormatString
			'	Case "00/00/0000"
			'		FormatString = "Date0"
			'	Case "##/##/####"
			'		FormatString = "Date"
			'	Case "(000) 000-0000"
			'		FormatString = "Phone0"
			'	Case "(###) ###-####"
			'		FormatString = "Phone"
			'End Select
			Return PathString & ", {" & FormatString & "}"
		Else
			Return PathString
		End If
	End Function



End Class
