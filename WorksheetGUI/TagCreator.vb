Public Class TagCreator
	Private xmlDoc As New Xml.XmlDocument
	Private nodes As Xml.XmlNodeList
	Private nameSpaceMGR As New Xml.XmlNamespaceManager(xmlDoc.NameTable)
	Private xPathList As New List(Of String)

	Private Sub TagCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		xmlDoc.Load("C:\Projects\WorksheetsGit\Worksheets\Test\WorksheetTestWithCreditApp.xml")
		nameSpaceMGR.AddNamespace("x", "http://www.elead.us/AppSchema.xsd")
	End Sub

	Private Sub SearchBox_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
		'nodes = GetNodeList(String.Format("//*[contains(name(),'{0}')]", SearchBox.Text))
		nodes = GetNodeList(String.Format("//*[contains(translate(name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'),'{0}')]", SearchBox.Text.ToLower))
		ResultList.Items.Clear()
		xPathList.Clear()

		For Each node As Xml.XmlNode In nodes
			If node.NodeType = Xml.XmlNodeType.Element Then
				Dim n = TryCast(node, Xml.XmlElement)
				If Not HasChildElements(node) Then
					If node.ParentNode.Name = xmlDoc.DocumentElement.Name Then
						If Not ResultList.Items.Contains(node.Name) Then
							ResultList.Items.Add(node.Name)
							xPathList.Add(getxPath(node))
						End If
					Else
						If Not ResultList.Items.Contains(node.ParentNode.Name & "/" & node.Name) Then
							ResultList.Items.Add(node.ParentNode.Name & "/" & node.Name)
							xPathList.Add(getxPath(node))
						End If
					End If
				Else
					For Each child As Xml.XmlNode In node.ChildNodes
						If Not HasChildElements(child) Then
							ResultList.Items.Add(node.Name & "/" & child.Name)
							xPathList.Add(getxPath(child))
						End If
					Next
				End If
			End If
		Next
	End Sub

	Private Function HasChildElements(node As Xml.XmlNode) As Boolean
		Dim containsElement As Boolean = False
		For Each child As Xml.XmlNode In node.ChildNodes
			If child.NodeType = Xml.XmlNodeType.Element Then
				containsElement = True
				Exit For
			End If
		Next
		Return containsElement
	End Function

	Private Sub ResultList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResultList.SelectedIndexChanged

		Dim path As String = xPathList.Item(ResultList.SelectedIndex)
		Dim node As Xml.XmlNode = GetNode(path)
		If Not path.Length > 0 Then
			TagTextBox.Text = ""
			TagPreviewTextBox.Text = ""
		Else
			If System.Text.RegularExpressions.Regex.IsMatch(node.InnerText, "^[0-9 ]+(\.+[0-9 ]*)?$") Then
				If node.InnerText.Contains(".") Then
					TagTextBox.Text = String.Format("<xsl:value-of select=""format-number({0}, '###,###.00')"" />", path)
					TagPreviewTextBox.Text = String.Format("{0:0.00}", Val(node.InnerText))
				ElseIf node.InnerText.Trim.Length = 10 Then
					TagTextBox.Text = String.Format("<xsl:value-of select=""format-number({0}, '(###) ###-####')"" />", path)
					TagPreviewTextBox.Text = String.Format("{0:(000) 000-0000}", Val(node.InnerText))
				ElseIf node.InnerText.Trim.Length = 9 Then
					TagTextBox.Text = String.Format("<xsl:value-of select=""format-number({0}, '###-##-####')"" />", path)
					TagPreviewTextBox.Text = String.Format("{0:000-00-0000}", Val(node.InnerText))
				End If
			Else
				TagTextBox.Text = String.Format("<xsl:value-of select=""{0}"" />", path)
				TagPreviewTextBox.Text = node.InnerText
			End If
		End If
	End Sub

	Private Function getxPath(node As Xml.XmlNode) As String
		Dim path As String = ""
		Do While Not node.Name = xmlDoc.DocumentElement.Name
			If path.Length > 0 Then path = "/" & path
			path = String.Format("x:{0}{1}", node.Name, path)
			node = node.ParentNode
		Loop
		Return path
	End Function

	Private Function GetNode(path) As Xml.XmlNode
		Dim node As Xml.XmlNode
		node = xmlDoc.DocumentElement.SelectNodes(path, nameSpaceMGR)(0)
		Return node
	End Function

	Private Function GetNodeList(path) As Xml.XmlNodeList
		Dim nodes As Xml.XmlNodeList
		nodes = xmlDoc.SelectNodes(String.Format(path), nameSpaceMGR)
		Return nodes
	End Function

	Public Function SelectedTag() As String
		Return TagTextBox.Text
	End Function

	Private Sub ResizeChildren(sender As Object, e As EventArgs) Handles MyBase.Resize
		SearchBox.Width = Width - 6
		TagTextBox.Width = Width - 6
		TagPreviewTextBox.Width = Width - 6
		SearchBox.Left = 3
		TagTextBox.Left = 3
		TagPreviewTextBox.Left = 3
		ResultList.Width = Width - 6
		ResultList.Height = Height - 119
		ResultList.Left = 3
		ResultList.Top = 116
	End Sub
	
End Class
