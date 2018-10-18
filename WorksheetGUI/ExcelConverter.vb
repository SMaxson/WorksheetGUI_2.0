Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class ExcelConverter
	Dim xlsApp As Excel.Application
	Dim xlsWB As Excel.Workbook
	Dim Target As Excel.Worksheet
	Dim tbl As Excel.Worksheet
	Dim xlsCell As Excel.Range
	Private Sub ExcelConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		OpenFileDialog1.ShowDialog(Me)
	End Sub

	Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
		xlsApp = New Excel.Application
		xlsApp.Visible = True
		xlsApp.ShowWindowsInTaskbar = True
		xlsWB = xlsApp.Workbooks.Open(OpenFileDialog1.FileName)
		Target = xlsWB.Worksheets(1)
		xlsCell = Target.Range("A1")
		'Dim t = xlsCell.Text.ToString.Contains("&")
	End Sub

	Public Function CarpenterMain() As String
		Target = xlsApp.ActiveSheet
		xlsWB = xlsApp.ActiveWorkbook
		Dim output As String = "<table class='w100 hp100 f14'>"

		'This is an attempt to automatically select the relevant area of the document. It needs work.
		'Dim LastRow As Excel.Range
		'LastRow = Target.Cells.Find(What:="*", After:=Target.Cells(1, 1), LookIn:=XlFindLookIn.xlFormulas, LookAt:=
		'XlLookAt.xlPart, SearchOrder:=XlSearchOrder.xlByRows, SearchDirection:=XlSearchDirection.xlPrevious, MatchCase:=False)
		'Dim LastCol As Excel.Range
		'LastCol = Target.Cells.Find(What:="*", After:=Target.Cells(1, 1), LookIn:=XlFindLookIn.xlFormulas, LookAt:=
		'XlLookAt.xlPart, SearchOrder:=XlSearchOrder.xlByColumns, SearchDirection:=XlSearchDirection.xlPrevious, MatchCase:=False)
		'Dim FirstRow As Excel.Range
		'FirstRow = Target.Cells.Find(What:="*", After:=Target.Cells(1, 1), LookIn:=XlFindLookIn.xlFormulas, LookAt:=
		'XlLookAt.xlPart, SearchOrder:=XlSearchOrder.xlByRows, SearchDirection:=XlSearchDirection.xlNext, MatchCase:=False)
		'Dim FirstCol As Excel.Range
		'FirstCol = Target.Cells.Find(What:="*", After:=Target.Cells(1, 1), LookIn:=XlFindLookIn.xlFormulas, LookAt:=
		'XlLookAt.xlPart, SearchOrder:=XlSearchOrder.xlByColumns, SearchDirection:=XlSearchDirection.xlNext, MatchCase:=False)
		'Dim LastCell As Excel.Range = Target.Cells(LastRow.Row, LastCol.Column)
		'Dim FirstCell As Excel.Range = Target.Cells(FirstRow.Row, FirstCol.Column)
		'Dim cellRange As Excel.Range = Target.Range(FirstCell, LastCell)

		Dim cellRange As Excel.Range = xlsApp.Selection
		If cellRange Is Nothing Then Return ""
		Dim y = cellRange.Row
		Dim x = cellRange.Column
		Dim exists As Boolean = False
		Dim Height = cellRange.Rows
		Dim Width = cellRange.Columns
		Dim c As Range
		Dim cellText As String
		Dim Col As Integer
		Dim Row As Integer = 1
		Dim mergeTest As Boolean
		Dim mergeTestRange As String
		Dim mergeCol As Integer = 0
		Dim mergeRow As Integer = 0
		Dim cellWidth(0 To 100) As Double
		Dim totalWidth As Double = 0
		Dim extraClass As String = ""
		Dim extraStyles As String = ""
		Dim stuff As List(Of String)
		Col = 1
		For Each Column In Width
			cellWidth(Col) = Target.Range("A1").Offset(y - 1, Col + x - 2).ColumnWidth
			totalWidth = totalWidth + cellWidth(Col)
			Col += 1
		Next Column
		Dim widthRatio = 100 / totalWidth

		For Each RowEl In Height
			output &= "<tr>"
			Col = 1
			For Each Column As Excel.Range In Width
				c = Target.Cells(Row + y - 1, Col + x - 1)
				cellText = "&#160;"
				If c.Text.ToString.Length > 0 Then cellText = c.Text.ToString.Replace("&", "&amp;")
				extraClass = ""
				extraStyles = ""
				If ExtraAccuracyCheckBox.Checked Then
					stuff = CellStylesToStylesAndClass(c)
					extraClass = stuff(0)
					extraStyles = stuff(1)
				Else
					extraClass = CellStylesToClass(c)
				End If
				mergeTestRange = c.Address(True, True, , False)
				mergeTest = Target.Range(mergeTestRange).MergeCells
				'If mergeCol > 0 Then
				If c.Column > Target.Range(mergeTestRange).MergeArea.Column Then
					'mergeCol -= 1
					Col += 1
					Continue For
				ElseIf mergeTest = False Or Target.Range(mergeTestRange).MergeArea.Columns.Count < 2 Then
					If Row = 1 Then
						output &= String.Format("<td class=""w{2} {0}""{1}>", extraClass, extraStyles, Math.Round(cellWidth(Col) * widthRatio, 0))
					Else
						output &= String.Format("<td class=""{0}""{1}>", extraClass, extraStyles)
					End If
					output &= cellText
				Else
					mergeCol = Target.Range(mergeTestRange).MergeArea.Columns.Count
					mergeRow = Target.Range(mergeTestRange).MergeArea.Rows.Count
					output &= String.Format("<td class=""{0}"" colspan=""{2}""{1}> {3}", extraClass, extraStyles, mergeCol, cellText)
					'Col = Col + mergeCol - 1
				End If
				output &= "</td>"
				Col += 1
			Next Column
			output &= "</tr>"
			Row += 1
		Next RowEl
		output &= "</table>"
		'xlsWB = Nothing
		'xlsApp.Quit()
		'xlsApp = Nothing
		Return output
	End Function

	Private Function CellStylesToClass(cell As Excel.Range) As String
		Dim Classes As String = ""
		Dim key As String
		Dim sides As New Dictionary(Of Integer, String) From {{7, "bl"}, {8, "bt"}, {9, "bb"}, {10, "br"}}
		For side As Integer = 7 To 10
			If Not cell.Borders(side).LineStyle = Excel.XlLineStyle.xlLineStyleNone Then
				With cell.Borders(side)
					key = ""
					If .Weight = Excel.XlBorderWeight.xlThin Or .Weight = Excel.XlBorderWeight.xlHairline Then
						sides.TryGetValue(side, key)
						Classes &= key & " "
					ElseIf .Weight = Excel.XlBorderWeight.xlMedium Then
						sides.TryGetValue(side, key)
						Classes &= key & "2 "
					Else .Weight = Excel.XlBorderWeight.xlThick
						sides.TryGetValue(side, key)
						Classes &= key & "3 "
					End If
				End With
			End If
		Next
		With cell
			Classes &= "f" & .Font.Size & " "
			If Not .Font.Bold.GetType = GetType(DBNull) Then
				If .Font.Bold Then Classes &= "bold "
			End If
			If Not .Font.Italic.GetType = GetType(DBNull) Then
				If .Font.Italic Then Classes &= "i "
			End If
			If Not .Font.Underline.GetType = GetType(DBNull) Then
				If Not .Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone Then Classes &= "underline "
			End If
			If Not .Font.Strikethrough.GetType = GetType(DBNull) Then
				If .Font.Strikethrough Then Classes &= "strike "
			End If
			If .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter Then Classes &= "ac "
			If .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft Then Classes &= "al "
			If .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight Then Classes &= "ar "
			If .HorizontalAlignment = Excel.XlHAlign.xlHAlignJustify Then Classes &= "justify "
			If .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom Then Classes &= "ab "
			If .VerticalAlignment = Excel.XlVAlign.xlVAlignTop Then Classes &= "at "
			If .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter Then Classes &= "am "
		End With
		Return Classes.Trim()
	End Function

	Private Function CellStylesToStylesAndClass(cell As Excel.Range) As List(Of String)
		Dim Classes As String = ""
		Dim Styles As String = ""
		Dim key As String
		Dim sides As New Dictionary(Of Integer, String) From {{7, "bl"}, {8, "bt"}, {9, "bb"}, {10, "br"}}
		Dim sidesStyle As New Dictionary(Of Integer, String) From {{7, "border-left"}, {8, "border-top"}, {9, "border-bottom"}, {10, "border-right"}}
		For side As Integer = 7 To 10
			If Not cell.Borders(side).LineStyle = Excel.XlLineStyle.xlLineStyleNone Then
				With cell.Borders(side)
					key = ""
					If Not Val(.Color) = 0 Then
						If .Weight = Excel.XlBorderWeight.xlThin Or .Weight = Excel.XlBorderWeight.xlHairline Then
							sidesStyle.TryGetValue(side, key)
							Styles &= String.Format(" {0}: 1px solid {1};", key, GetRGB(.Color))
						ElseIf .Weight = Excel.XlBorderWeight.xlMedium Then
							sidesStyle.TryGetValue(side, key)
							Styles &= String.Format(" {0}: 2px solid {1};", key, GetRGB(.Color))
						ElseIf .Weight = Excel.XlBorderWeight.xlThick Then
							sidesStyle.TryGetValue(side, key)
							Styles &= String.Format(" {0}: 3px solid {1};", key, GetRGB(.Color))
						End If
					Else
						If .Weight = Excel.XlBorderWeight.xlThin Or .Weight = Excel.XlBorderWeight.xlHairline Then
							sides.TryGetValue(side, key)
							Classes &= key & " "
						ElseIf .Weight = Excel.XlBorderWeight.xlMedium Then
							sides.TryGetValue(side, key)
							Classes &= key & "2 "
						Else .Weight = Excel.XlBorderWeight.xlThick
							sides.TryGetValue(side, key)
							Classes &= key & "3 "
						End If
					End If
				End With
			End If
		Next
		With cell
			If Not IsDBNull(.Font.Size) Then
				Classes &= "f" & Math.Round(Val(.Font.Size)) & " "
			End If
			If Not IsDBNull(.Font.Bold) Then
				If .Font.Bold Then Classes &= "bold "
			End If
			If Not IsDBNull(.Font.Italic) Then
				If .Font.Italic Then Classes &= "i "
			End If
			If Not IsDBNull(.Font.Underline) Then
				If Not .Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone Then Classes &= "underline "
			End If
			If Not IsDBNull(.Font.Strikethrough) Then
				If .Font.Strikethrough Then Classes &= "strike "
				Select Case .HorizontalAlignment
					Case XlHAlign.xlHAlignCenter
						Classes &= "ac "
					Case XlHAlign.xlHAlignLeft
						Classes &= "al "
					Case XlHAlign.xlHAlignRight
						Classes &= "ar "
					Case XlHAlign.xlHAlignJustify
						Classes &= "justify "
				End Select
			End If
			If Not IsDBNull(.VerticalAlignment) Then
				If .VerticalAlignment = Excel.XlVAlign.xlVAlignBottom Then Classes &= "ab "
			If .VerticalAlignment = Excel.XlVAlign.xlVAlignTop Then Classes &= "at "
				If .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter Then Classes &= "am "
			End If
			Try
				If Not Val(.Font.Color) = 0 Then Styles &= String.Format(" color: {0};", GetRGB(.Font.Color))
			Catch ex As Exception
			End Try
			Try
				If Not (.Interior.ColorIndex = 0 Or .Interior.ColorIndex = 2) Then Styles &= String.Format(" background-color: {0};", GetRGB(.Interior.Color))
			Catch ex As Exception
			End Try
		End With
		If Styles.Length > 0 Then Styles = String.Format(" style=""{0}""", Styles.Trim())
		Dim output As List(Of String) = New List(Of String)
		output.Add(Classes.Trim())
		output.Add(Styles)
		Return output
	End Function

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		'Dim Carpenter As New System.Threading.Thread(AddressOf CarpenterCall)
		'Carpenter.Start()
		CarpenterCall()
	End Sub

	Private Sub CarpenterCall()
		saveWorksheetDialog.InitialDirectory = "C:\Projects\WorksheetsGit\Worksheets"
		saveWorksheetDialog.ShowDialog(Me)
		Cursor = Cursors.WaitCursor
		Dim code = CarpenterMain()
		Dim outputShellFileName = saveWorksheetDialog.FileName.ToString()
		Dim outputBodyFileName = Strings.Left(outputShellFileName, InStrRev(outputShellFileName, "\", -1, CompareMethod.Text)).ToString & "body\" & Strings.Right(outputShellFileName, (outputShellFileName.Length - InStrRev(outputShellFileName, "\", -1, CompareMethod.Text))).Replace(".xslt", "_Body.xslt")

		Dim outputShell As New Worksheet.ShellFile
		outputShell.CreateShell(outputBodyFileName)

		Dim outputBody As New Worksheet.BodyFile
		outputBody.CreateBody(outputBodyFileName, code)
		'outputBodyFileName = Replace(outputBodyFileName, ".xslt", "_Body.xslt")

		wsGUIWindow.WriteWorksheet(outputShellFileName, outputShell.ReturnCode)
		wsGUIWindow.WriteWorksheet(outputBodyFileName, outputBody.ReturnCode)

		wsGUIWindow.targetXSL = outputShellFileName
		Cursor = Cursors.Default
		wsGUIWindow.loadWorksheet(outputShellFileName)
	End Sub

	Private Sub ExtraAccuracyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ExtraAccuracyCheckBox.CheckedChanged

	End Sub

	Private Function GetRGB(ByVal Color As Object) As String
		Dim hexCode
		hexCode = Hex(Color)

		Dim R As String, G As String
		Dim b As String

		'Note the order excel uses for hex is BGR.
		b = Mid(hexCode, 1, 2)
		G = Mid(hexCode, 3, 2)
		R = Mid(hexCode, 5, 2)
		If Not b.Length > 0 Then b = "00"
		If Not G.Length > 0 Then G = "00"
		If Not R.Length > 0 Then R = "00"
		If Not b.Length > 1 Then b = "0" & b
		If Not G.Length > 1 Then G = "0" & G
		If Not R.Length > 1 Then R = "0" & R

		GetRGB = "#" & R & G & b
		Return GetRGB
	End Function

	Private Sub ExcelConverter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
		xlsWB = Nothing
		xlsApp.Quit()
		xlsApp = Nothing
	End Sub
End Class