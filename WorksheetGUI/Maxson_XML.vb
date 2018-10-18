Module Maxson_XML
	Public Class Node
		Public Property Name As String
		Private Property SelfClosing As Boolean = False
		Private Property PlainText As String
		Public ReadOnly Property ClassAttribute As String
			Get
				If ClassList.Count > 0 Then
					Dim classString As String = "class="""
					For Each cls In ClassList
						classString &= cls & " "
					Next
					classString = """"
					Return classString.TrimEnd
				Else
					Return New String("")
				End If
			End Get
		End Property
		Private Property ClassList As List(Of String)
		Public Property StyleList As String
		Public Property ColSpan As String
		Public Property RowSpan As String
		Public Property ID As String
		Public Property ChildNodes As List(Of Maxson_XML.Node)
		Public ReadOnly Property InnerText As String
		Public Property InnerXML As String
		Public ReadOnly Property OuterXML As String
			Get
				Dim UnformattedOutput As String = String.Format("<{0}", Name)
				UnformattedOutput &= ClassAttribute
				If StyleList.Count > 0 Then
					UnformattedOutput &= "style"""
					For i = 0 To StyleList.Count - 1
						If i > 0 Then UnformattedOutput &= " "
						UnformattedOutput &= StyleList(i) & ";"
					Next
					UnformattedOutput &= """"
				End If
				If ColSpan > 1 Then UnformattedOutput &= String.Format(" colspan=""{0}""", ColSpan)
				If RowSpan > 1 Then UnformattedOutput &= String.Format(" rowspan=""{0}""", RowSpan)
				UnformattedOutput &= ">"
				UnformattedOutput &= InnerXML
				UnformattedOutput &= String.Format("</{0}>", Name)
				Return PrettyXML(UnformattedOutput)
			End Get
		End Property
		Public Sub AddClass(newClass As String)
			If Not ClassList.Contains(newClass) Then
				ClassList.Add(newClass)
			End If
		End Sub
		Public Sub RemoveClass(newClass As String)
			If ClassList.Contains(newClass) Then
				ClassList.Remove(newClass)
			End If
		End Sub
		Private Function PrettyXML(XMLString As String) As String
			Dim sw As New IO.StringWriter()
			Dim xw As New Xml.XmlTextWriter(sw)
			xw.Formatting = Xml.Formatting.Indented
			xw.Indentation = 4
			Dim doc As New Xml.XmlDocument
			doc.LoadXml(XMLString)
			doc.Save(xw)
			Return sw.ToString()
		End Function
	End Class
End Module