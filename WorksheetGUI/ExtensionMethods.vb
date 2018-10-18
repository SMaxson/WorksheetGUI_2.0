Module ExtensionMethods
	<System.Runtime.CompilerServices.Extension()>
	Public Function GetCols(table As mshtml.HTMLTable) As Integer
		Dim cellCounts As New List(Of Integer)
		Dim rowCount As Integer
		For Each r As mshtml.HTMLTableRow In table.rows
			rowCount = 0
			For Each cell As mshtml.IHTMLTableCell In r.cells
				If cell.colSpan > 0 Then
					rowCount += cell.colSpan
				Else
					rowCount += 1
				End If
			Next
			cellCounts.Add(rowCount)
		Next
		Return cellCounts.Max
	End Function
	<System.Runtime.CompilerServices.Extension()>
	Public Function GetColumnCells(table As mshtml.HTMLTable, index As Integer) As List(Of mshtml.HTMLTableCell)
		Dim ColumnCells As New List(Of mshtml.HTMLTableCell)
		Dim rowCount As Integer
		For Each r As mshtml.HTMLTableRow In table.rows
			rowCount = 0
			For Each cell As mshtml.IHTMLTableCell In r.cells
				If index > rowCount And index < rowCount + cell.colSpan Then
					ColumnCells.Add(cell)
					Exit For
				ElseIf index = rowCount Then
					ColumnCells.Add(cell)
					Exit For
				Else
					rowCount += cell.colSpan
				End If
			Next
		Next
		Return ColumnCells
	End Function
	<System.Runtime.CompilerServices.Extension()>
	Public Function IsTableElement(element As System.Windows.Forms.HtmlElement) As Boolean
		Dim tblElements As New List(Of String) From {"table", "tr", "td", "tbody", "thead", "tfoot", "th"}
		Dim t = element
		If tblElements.Contains(t.TagName.ToLower) Then
			Return True
		Else
			Return False
		End If
	End Function
	<System.Runtime.CompilerServices.Extension()>
	Public Function GetParentTable(element As System.Windows.Forms.HtmlElement) As System.Windows.Forms.HtmlElement
		Dim t = element
		Do While Not (t.TagName.ToLower = "table" Or t.TagName.ToLower = "body") And Not IsNothing(t.Parent)
			t = t.Parent
		Loop
		Return t
	End Function
	<System.Runtime.CompilerServices.Extension>
	Public Function FindSubString(c As ToolStripComboBox, s As String) As Integer
		If c Is Nothing Then
			Throw New ArgumentNullException("combo")
		End If
		If s Is Nothing Then
			Return -1
		End If
		For i As Integer = 0 To c.Items.Count - 1
			If c.Items.Item(i).ToString.Contains(s) Then Return i
		Next
		Return -1
	End Function
End Module
