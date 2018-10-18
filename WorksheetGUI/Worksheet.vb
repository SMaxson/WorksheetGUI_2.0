Imports System.IO
Imports Microsoft.Win32.SafeHandles

Namespace Worksheet
	Public Class ShellFile
		Inherits Worksheet
		Public Property Files As New List(Of String)
		Private Templates As New List(Of String)

		Public Function GetFiles() As List(Of String)
			Dim output As New List(Of String)
			For Each file As String In Files
				output.Add(file)
			Next
			Return output
		End Function

		Public Function GetTemplates() As List(Of String)
			Dim output As New List(Of String)
			For Each template As String In Templates
				output.Add(template)
			Next
			Return output
		End Function

		Public Overloads Function CreateShell(FileName As String, Optional Functions As String = Nothing) As String
			Files.Clear()
			Files.Add(FileName)
			Templates.Clear()
			Templates.Add(Replace(Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))), ".xslt", ""))
			SourceCode = "<?xml version=""1.0"" encoding=""utf-8"" ?>"
			SourceCode &= vbCrLf & "<!DOCTYPE xsl:stylesheet ["
			SourceCode &= vbCrLf & "]>"
			SourceCode &= vbCrLf & "<xsl:stylesheet version=""1.0"""
			SourceCode &= vbCrLf & "	xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"""
			SourceCode &= vbCrLf & "	xmlns:msxsl=""urn:schemas-Microsoft - com: xslt"""
			SourceCode &= vbCrLf & "	xmlns:user=""http://www.elead.us/eDESK"""
			SourceCode &= vbCrLf & "	xmlns:dt=""urn:schemas-Microsoft-com:datatypes"""
			SourceCode &= vbCrLf & "	xmlns:x=""http://www.elead.us/AppSchema.xsd"">"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:output method=""html"" omit-xml-declaration=""yes""/>"
			SourceCode &= vbCrLf & "	<xsl:decimal-format NaN=""""/>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:include href=""../_scripts/user_functions.xslt""/>"
			SourceCode &= vbCrLf & "	<xsl:include href=""body/" & Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))) & """ />"
			SourceCode &= vbCrLf & "	<xsl:include href=""../_Generic/body/FormStylesheet_Two.xslt"" />"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:template match=""Package"">"
			SourceCode &= vbCrLf & "		<includes>"
			SourceCode &= vbCrLf & "			<include href=""../_scripts/user_functions.xslt""/>"
			SourceCode &= vbCrLf & "			<include href=""body/" & Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))) & """ />"
			SourceCode &= vbCrLf & "			<include href=""../_Generic/body/FormStylesheet_Two.xslt"" />"
			SourceCode &= vbCrLf & "		</includes>"
			SourceCode &= vbCrLf & "	</xsl:template>"
			SourceCode &= vbCrLf & ""
			If Functions IsNot Nothing Then
				SourceCode &= vbCrLf & String.Format("	{0}", Functions)
				SourceCode &= vbCrLf & ""
			End If
			SourceCode &= vbCrLf & "	<xsl:template match=""x:AppSchemaBase"">"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "		<html>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "			<head>"
			SourceCode &= vbCrLf & "				<title>"
			SourceCode &= vbCrLf & "					<xsl:value-of select=""x:Company/x:Company""/>"
			SourceCode &= vbCrLf & "				</title>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "				<xsl:call-template name=""FormStylesheet_Two"" />"
			SourceCode &= vbCrLf & "				<xsl:call-template name=""user_functions"" />"
			SourceCode &= vbCrLf & "			</head>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "			<body>"
			SourceCode &= vbCrLf & "				<xsl:call-template name=""" & Replace(Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))), ".xslt", "") & """ />"
			SourceCode &= vbCrLf & "			</body>"
			SourceCode &= vbCrLf & "		</html>"
			SourceCode &= vbCrLf & "	</xsl:template>"
			SourceCode &= vbCrLf & "</xsl:stylesheet>"
			Return SourceCode
		End Function
		Public Overloads Function CreateShell(FileNames As List(Of String), Optional Functions As String = Nothing, Optional TemplateOrder As List(Of String) = Nothing) As String
			Files.Clear()
			Files = FileNames
			Templates.Clear()
			If Not IsNothing(TemplateOrder) Then Templates = TemplateOrder
			SourceCode = "<?xml version=""1.0"" encoding=""utf-8"" ?>"
			SourceCode &= vbCrLf & "<!DOCTYPE xsl:stylesheet ["
			SourceCode &= vbCrLf & "]>"
			SourceCode &= vbCrLf & "<xsl:stylesheet version=""1.0"""
			SourceCode &= vbCrLf & "	xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"""
			SourceCode &= vbCrLf & "	xmlns:msxsl=""urn:schemas-Microsoft - com: xslt"""
			SourceCode &= vbCrLf & "	xmlns:user=""http://www.elead.us/eDESK"""
			SourceCode &= vbCrLf & "	xmlns:dt=""urn:schemas-Microsoft-com:datatypes"""
			SourceCode &= vbCrLf & "	xmlns:x=""http://www.elead.us/AppSchema.xsd"">"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:output method=""html"" omit-xml-declaration=""yes""/>"
			SourceCode &= vbCrLf & "	<xsl:decimal-format NaN=""""/>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:include href=""../_scripts/user_functions.xslt""/>"
			For Each FileName As String In FileNames
				SourceCode &= vbCrLf & "	<xsl:include href=""body/" & Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))) & """ />"
			Next
			SourceCode &= vbCrLf & "	<xsl:include href=""../_Generic/body/FormStylesheet_Two.xslt""/>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "	<xsl:template match=""Package"">"
			SourceCode &= vbCrLf & "		<includes>"
			SourceCode &= vbCrLf & "			<include href=""../_scripts/user_functions.xslt""/>"
			For Each FileName As String In FileNames
				SourceCode &= vbCrLf & "			<include href=""body/" & Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))) & """ />"
			Next
			SourceCode &= vbCrLf & "			<include href=""../_Generic/body/FormStylesheet_Two.xslt"" />"
			SourceCode &= vbCrLf & "		</includes>"
			SourceCode &= vbCrLf & "	</xsl:template>"
			SourceCode &= vbCrLf & ""
			If Functions IsNot Nothing Then
				SourceCode &= vbCrLf & String.Format("	{0}", Functions)
				SourceCode &= vbCrLf & ""
			End If
			SourceCode &= vbCrLf & "	<xsl:template match=""x:AppSchemaBase"">"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "		<html>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "		<head>"
			SourceCode &= vbCrLf & "			<title>"
			SourceCode &= vbCrLf & "				<xsl:value-of select=""x:Company/x:Company""/>"
			SourceCode &= vbCrLf & "			</title>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "			<xsl:call-template name=""FormStylesheet_Two"" />"
			SourceCode &= vbCrLf & "			<xsl:call-template name=""user_functions"" />"
			SourceCode &= vbCrLf & "		</head>"
			SourceCode &= vbCrLf & ""
			SourceCode &= vbCrLf & "		<body>"
			SourceCode &= vbCrLf & "			<div class=""center"">"
			If Not IsNothing(TemplateOrder) Then
				For Each Template As String In TemplateOrder
					If TemplateOrder.IndexOf(Template) = 0 Then
						SourceCode &= vbCrLf & "				<div class=""firstpage"">"
					Else
						SourceCode &= vbCrLf & "				<div class=""page"">"
					End If
					SourceCode &= vbCrLf & String.Format("					<xsl:call-template name=""{0}"" />", Template)
					SourceCode &= vbCrLf & "				</div>"
				Next
			Else
				For Each FileName As String In FileNames
					Templates.Add(Replace(Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))), ".xslt", ""))
					If FileNames.IndexOf(FileName) = 0 Then
						SourceCode &= vbCrLf & "				<div class=""firstpage"">"
					Else
						SourceCode &= vbCrLf & "				<div class=""page"">"
					End If
					SourceCode &= vbCrLf & "					<xsl:call-template name=""" & Replace(Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text))), ".xslt", "") & """ />"
					SourceCode &= vbCrLf & "				</div>"
				Next
			End If
			SourceCode &= vbCrLf & "			</div>"
			SourceCode &= vbCrLf & "		</body>"
			SourceCode &= vbCrLf & "		</html>"
			SourceCode &= vbCrLf & "	</xsl:template>"
			SourceCode &= vbCrLf & "</xsl:stylesheet>"
			Return SourceCode
		End Function
		Public Function ReturnCode() As String
			Return SourceCode
		End Function
		Private Function GetIncludedFiles(w As String, Optional filter As Boolean = True) As List(Of String)
			Dim targetXSLContents As String = SourceCode
			Dim folder As String = w.Replace("/", "\")
			folder = Strings.Left(folder, InStrRev(folder, "\", -1, CompareMethod.Text))
			Dim bodyFiles As New List(Of String)()
			Templates.Clear()

			Do While targetXSLContents.IndexOf("<!--") <> -1
				Dim rs = targetXSLContents.IndexOf("<!--")
				Dim re = targetXSLContents.IndexOf("-->") + 3
				targetXSLContents = targetXSLContents.Remove(rs, re - rs)
			Loop

			Dim position As Integer = 0
			While position <> -1
				position = targetXSLContents.IndexOf("<xsl:include href=""", position)
				If position <> -1 Then
					Dim endPosition As Integer = targetXSLContents.IndexOf("""", position + 19)
					If endPosition <> -1 Then
						Dim referencedBody = targetXSLContents.Substring(position + 19, endPosition - position - 19)
						If (Not referencedBody.ToLower.Contains("user_functions") And Not referencedBody.ToLower.Contains("formstylesheet")) Or filter = False Then
							bodyFiles.Add(IO.Path.GetFullPath(folder + referencedBody.Replace("/", "\")))
						End If
					End If
					position = endPosition
				End If
			End While
			position = 0
			While position <> -1
				position = targetXSLContents.IndexOf("<xsl:call-template name=""", position)
				If position <> -1 Then
					Dim endPosition As Integer = targetXSLContents.IndexOf("""", position + 25)
					If endPosition <> -1 Then
						Dim referencedTemplate = targetXSLContents.Substring(position + 25, endPosition - position - 25)
						If (Not referencedTemplate.ToLower.Contains("user_functions") And Not referencedTemplate.ToLower.Contains("formstylesheet")) Or filter = False Then
							Templates.Add(referencedTemplate)
						End If
					End If
					position = endPosition
				End If
			End While
			Return bodyFiles
		End Function

		Public Function Load(FileName As String) As String
			FilePath = FileName.Replace("/", "\")
			Using tempReader = IO.File.OpenText(FileName)
				SourceCode = tempReader.ReadToEnd
			End Using
			Templates.Clear()
			Files.Clear()
			Files = GetIncludedFiles(FilePath)
			Return SourceCode
		End Function

		Public Function IsCreditApp() As Boolean
			If SourceCode.Length > 0 And Not SourceCode.ToLower.Contains("<xsl:template name") And Files.Count = 0 Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Function TransformWorksheet(ByVal wsFileName As String, ByRef errorMessage As String, ByRef erSourceURI As String,
										   Optional targetXML As String = "C:\Projects\WorksheetsGit\Worksheets\Test\WorksheetTestWithCreditApp.xml", Optional newStoreId As Integer = 1,
										   Optional newStoreName As String = "", Optional calculationType As String = "") As String
			'Dim writer As New IO.StringWriter()
			Dim writer As New StringWriterWithEncoding(System.Text.Encoding.UTF8)
			Dim reader As Xml.XmlReader
			Dim rs = New Xml.XmlReaderSettings()
			Dim xslt As New Xml.Xsl.XslCompiledTransform()
			Dim xmlresolver As New System.Xml.XmlUrlResolver
			Dim Settings As Xml.Xsl.XsltSettings = New Xml.Xsl.XsltSettings(True, True)
			rs.ConformanceLevel = Xml.ConformanceLevel.Document
			rs.XmlResolver = Nothing
			rs.DtdProcessing = Xml.DtdProcessing.Parse
			rs.CloseInput = True
			errorMessage = ""
			erSourceURI = ""
			Try
				reader = Xml.XmlReader.Create(wsFileName, rs)
			Catch ex As Exception
				errorMessage = ex.Message.ToString
				wsGUIWindow.showStatus.Text = errorMessage.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
			End Try
			Try
				xslt.Load(reader, Settings, xmlresolver)
			Catch ex As Xml.XmlException
				errorMessage = ex.Message.ToString
				If ex.InnerException IsNot Nothing Then
					errorMessage &= " " & ex.InnerException.Message.ToString
				End If
				If ex.SourceUri IsNot Nothing Then
					erSourceURI = Strings.Right(ex.SourceUri.ToString, ex.SourceUri.ToString.Length - InStrRev(ex.SourceUri.ToString, "\", -1, CompareMethod.Text)).Replace("file:\\\", "")
					erSourceURI = erSourceURI.Replace("file:///", "")
					errorMessage &= " Error in file: " & Replace(ex.SourceUri.ToString, "file:///", "")
				End If
				wsGUIWindow.showStatus.Text = errorMessage.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
				reader.Close()
				reader.Dispose()
			Catch ex As Xml.Xsl.XsltException
				errorMessage = ex.Message.ToString
				If ex.InnerException IsNot Nothing Then
					errorMessage &= " " & ex.InnerException.Message.ToString
				End If
				If ex.SourceUri IsNot Nothing Then
					erSourceURI = Strings.Right(ex.SourceUri.ToString, ex.SourceUri.ToString.Length - InStrRev(ex.SourceUri.ToString, "\", -1, CompareMethod.Text)).Replace("file:\\\", "")
					erSourceURI = erSourceURI.Replace("file:///", "")
					errorMessage &= " Error in file: " & Replace(ex.SourceUri.ToString, "file:///", "")
				End If
				wsGUIWindow.showStatus.Text = errorMessage.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
				reader.Close()
				reader.Dispose()
			Catch ex As Exception
				wsGUIWindow.showStatus.Text = errorMessage.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
				If ex.InnerException IsNot Nothing Then
					errorMessage &= " " & ex.InnerException.Message.ToString
				End If
				reader.Close()
				reader.Dispose()
			End Try

			Dim tempXML As New Xml.XmlDocument()
			tempXML.Load(targetXML)
			Dim root = tempXML.DocumentElement
			Try
				Dim companyNode = root.Item("Company")
				Dim companyIDNode = companyNode.Item("EleadCompanyID")
				Dim companyNameNode = companyNode.Item("Company")
				companyIDNode.InnerText = newStoreId
				If newStoreName.Length > 0 Then
					companyNameNode.InnerText = newStoreName
				End If

				If calculationType.Length > 0 Then
					Dim SalesQuote = root.Item("SalesQuote")
					Dim CalcType = SalesQuote.Item("CalculationType")
					CalcType.InnerText = calculationType
				End If
			Catch ex As Exception
			End Try
			Try
				xslt.Transform(tempXML, Nothing, writer)
			Catch ex As Exception
				writer.Close()
				writer.Dispose()
			End Try
			wsGUIWindow.showStatus.Text = errorMessage.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
			Dim output As String = writer.ToString()
			If output.Contains("<script") Then output = output.Insert(output.IndexOf("<script"), "<script src=""https://code.jquery.com/jquery-3.2.1.min.js"" integrity=""sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4="" crossorigin=""anonymous"">//notnull</script>" & vbCrLf)
			reader.Close()
			writer.Close()
			reader.Dispose()
			writer.Dispose()
			Return output
		End Function
	End Class
	Public Class BodyFile
		Inherits Worksheet
		Public Function CreateBody(FileName As String, Optional Content As String = "&#160;") As String
			FileName = FileName.Replace("/", "\").Replace(".xslt", "")
			Dim TemplateName As String = Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text)))
			SourceCode = "<?xml version=""1.0"" encoding=""utf-8"" ?>"
			SourceCode &= "<xsl:stylesheet version=""1.0"""
			SourceCode &= "	xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"""
			SourceCode &= "	xmlns:msxsl=""urn:schemas-microsoft-com:xslt"""
			SourceCode &= "	xmlns:user=""http://www.elead.us/eDESK"""
			SourceCode &= "	xmlns:dt=""urn:schemas-microsoft-com:datatypes"""
			SourceCode &= "	xmlns:x=""http://www.elead.us/AppSchema.xsd"">"
			SourceCode &= ""
			SourceCode &= "	<xsl:output method=""html"" omit-xml-declaration=""yes""/>"
			SourceCode &= "	<xsl:decimal-format NaN=""""/>"
			SourceCode &= String.Format("  <xsl:template name=""{0}"">", TemplateName)
			SourceCode &= "	<xsl:param name=""logo""/>"
			SourceCode &= ""
			SourceCode &= "	<html>"
			SourceCode &= ""
			SourceCode &= String.Format("		<page id=""{0}"">", TemplateName)
			SourceCode &= "			<!--<header>If this is uncommented, it will act as a header.</header>-->"
			SourceCode &= "			<content>"
			SourceCode &= String.Format("				{0}", Content)
			SourceCode &= "			</content>"
			SourceCode &= "			<!--<footer>If this is uncommented, it will act as a footer.</footer>-->"
			SourceCode &= "		</page>"
			SourceCode &= ""
			SourceCode &= "	</html>"
			SourceCode &= "	</xsl:template>"
			SourceCode &= "</xsl:stylesheet>"
			Return SourceCode
		End Function


		Public Function CreateLandscapeBody(FileName As String, Optional Content As String = "&#160;") As String
			FilePath = FileName.Replace("/", "\")
			FileName = FileName.Replace("/", "\").Replace(".xslt", "")
			Dim TemplateName As String = Strings.Right(FileName, (FileName.Length - InStrRev(FileName, "\", -1, CompareMethod.Text)))
			SourceCode = "<?xml version=""1.0"" encoding=""utf-8"" ?>"
			SourceCode &= "<xsl:stylesheet version=""1.0"""
			SourceCode &= "	xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"""
			SourceCode &= "	xmlns:msxsl=""urn:schemas-microsoft-com:xslt"""
			SourceCode &= "	xmlns:user=""http://www.elead.us/eDESK"""
			SourceCode &= "	xmlns:dt=""urn:schemas-microsoft-com:datatypes"""
			SourceCode &= "	xmlns:x=""http://www.elead.us/AppSchema.xsd"">"
			SourceCode &= ""
			SourceCode &= "	<xsl:output method=""html"" omit-xml-declaration=""yes""/>"
			SourceCode &= "	<xsl:decimal-format NaN=""""/>"
			SourceCode &= String.Format("  <xsl:template name=""{0}"">", TemplateName)
			SourceCode &= "	<xsl:param name=""logo""/>"
			SourceCode &= ""
			SourceCode &= "	<html>"
			SourceCode &= ""
			SourceCode &= String.Format("	<landscape id=""{0}"">", TemplateName)
			SourceCode &= "		<!--<header>If this is uncommented, it will act as a header.</header>-->"
			SourceCode &= "		<content>"
			SourceCode &= String.Format("			{0}", Content)
			SourceCode &= "		</content>"
			SourceCode &= "		<!--<footer>If this is uncommented, it will act as a footer.</footer>-->"
			SourceCode &= "	</landscape>"
			SourceCode &= ""
			SourceCode &= "	</html>"
			SourceCode &= "	</xsl:template>"
			SourceCode &= "</xsl:stylesheet>"
			Return SourceCode
		End Function


		Public Function Load(FileName As String) As String
			FilePath = FileName.Replace("/", "\")

			'TEST
			SourceCode = ""
			Using tempReader = IO.File.OpenText(FileName)
				''Original
				'SourceCode = tempReader.ReadToEnd


				Dim line As String
				line = tempReader.ReadLine()
				Do While Not (line Is Nothing)
					If line.Length > 0 Then
						SourceCode &= line.Trim
					End If
					line = tempReader.ReadLine()
				Loop
			End Using
			Return SourceCode
		End Function

		Public Function ReturnCode() As String
			Return SourceCode
		End Function

		Public Function MakeWorksheetEditable() As String
			wsGUIWindow.backupWorksheet(FilePath)
			Dim tempText As String

			tempText = SourceCode.Replace("&", "~?!#~")
			Dim tempXML As New Xml.XmlDocument()

			Dim Settings = New Xml.XmlReaderSettings
			Settings.NameTable = New Xml.NameTable
			Dim xmlns = New Xml.XmlNamespaceManager(Settings.NameTable)
			Dim context = New Xml.XmlParserContext(Nothing, xmlns, "", Xml.XmlSpace.None)
			Settings.ConformanceLevel = Xml.ConformanceLevel.Document
			tempXML.LoadXml(tempText)
			Dim root = tempXML.DocumentElement
			Dim tlist = tempXML.GetElementsByTagName("xsl:value-of")
			Dim i As Integer = tlist.Count - 1
			Do While i > -1
				Select Case tlist(i).ParentNode.Name
					Case "xsl:attribute"

					Case "xsl:variable"

					Case Else
						Dim t As Xml.XmlNode = tempXML.CreateElement("xsl:input")
						Dim att As Xml.XmlAttribute = tempXML.CreateAttribute("type")
						att.Value = "text"
						t.Attributes.Append(att)
						att = tempXML.CreateAttribute("class")
						att.Value = "w98 fi inputanswer nobo nobg"
						t.Attributes.Append(att)
						att = tempXML.CreateAttribute("style")
						att.Value = "height:1.1em;"
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
			SourceCode = tempXML.OuterXml.Replace("~?!#~", "&")
			Return (SourceCode)
		End Function

		Public Function PrepareBodyForEdit(ByRef errorMessage As String, ByRef xslValueOfDictionary As Dictionary(Of Integer, String), ByRef xslChooseDictionary As Dictionary(Of Integer, String),
										   ByRef xslIfDictionary As Dictionary(Of Integer, String), Optional targetXML As String = "C:\Projects\WorksheetsGit\Worksheets\Test\WorksheetTestWithCreditApp.xml") As String
			Dim targetBodyContents As String = SourceCode
			Dim editXSLFramework = "C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\editFramework.xslt"
			xslValueOfDictionary.Clear()
			xslChooseDictionary.Clear()
			xslIfDictionary.Clear()

			Dim separatorTags As String() = {"<html>", "</html>"}
			Dim convertedBodyContents = targetBodyContents.Split(separatorTags, StringSplitOptions.None)(1)
			Dim i As Integer = 0
			convertedBodyContents = convertedBodyContents.Replace("xsl:attribute", "xslattribute")
			i = 0
			Dim xmlDoc As New Xml.XmlDocument
			xmlDoc.Load(targetXML)
			Dim xDoc As XDocument
			Using xmlReader = New Xml.XmlNodeReader(xmlDoc.DocumentElement)
				xDoc = XDocument.Load(xmlReader)
			End Using

			Do While convertedBodyContents.Contains("<xsl:variable")
				Dim startIndex As Integer = convertedBodyContents.IndexOf("<xsl:variable")
				Dim endIndex As Integer = convertedBodyContents.IndexOf(">", startIndex)
				convertedBodyContents = convertedBodyContents.Remove(endIndex - 1, 2)
				convertedBodyContents = convertedBodyContents.Insert(endIndex - 1, "</xslvariable>")
				convertedBodyContents = convertedBodyContents.Remove(startIndex, 13)
				convertedBodyContents = convertedBodyContents.Insert(startIndex, "<xslvariable>")
			Loop

			i = 0
			Do While convertedBodyContents.Contains("<xsl:if")
				Dim startIndex As Integer = convertedBodyContents.IndexOf("<xsl:if")
				Dim endIndex As Integer = convertedBodyContents.IndexOf("</xsl:if>", startIndex) + 9

				xslIfDictionary.Add(i, convertedBodyContents.Substring(startIndex, endIndex - startIndex))
				convertedBodyContents = convertedBodyContents.Remove(startIndex, endIndex - startIndex)
				convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslif id=""{0}""> XSL:If Test </xslif>", i))
				i += 1
			Loop

			i = 0
			Do While convertedBodyContents.Contains("<xsl:choose")
				Dim startIndex As Integer = convertedBodyContents.IndexOf("<xsl:choose")
				Dim endIndex As Integer = convertedBodyContents.IndexOf("</xsl:choose>", startIndex) + 13

				xslChooseDictionary.Add(i, convertedBodyContents.Substring(startIndex, endIndex - startIndex))
				convertedBodyContents = convertedBodyContents.Remove(startIndex, endIndex - startIndex)
				convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslchoose id=""{0}""> XSL:Choose Test </xslchoose>", i))
				i += 1
			Loop

			i = 0
			Do While convertedBodyContents.Contains("<xsl:value-of")
				Dim startIndex As Integer = convertedBodyContents.IndexOf("<xsl:value-of")
				Dim selectIndex As Integer = convertedBodyContents.IndexOf("=", startIndex)
				Dim endIndex As Integer = convertedBodyContents.IndexOf(">", startIndex)
				xslValueOfDictionary.Add(i, convertedBodyContents.Substring(startIndex, endIndex - startIndex + 1))
				convertedBodyContents = convertedBodyContents.Remove(startIndex, endIndex - startIndex + 1)

				Dim xp As New xPath
				Dim xPathString As String = xp.ParseFromString(xslValueOfDictionary.Values(i))
				Dim nameSpaceMGR As New Xml.XmlNamespaceManager(xmlDoc.NameTable)
				Dim node As Xml.XmlNode
				nameSpaceMGR.AddNamespace("x", "http://www.elead.us/AppSchema.xsd")

				Try
					node = xmlDoc.DocumentElement.SelectNodes(xPathString, nameSpaceMGR)(0)
				Catch ex As Exception
					convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, xslValueOfDictionary.Values(i).Substring(xslValueOfDictionary.Values(i).IndexOf("""") + 1, xslValueOfDictionary.Values(i).LastIndexOf("""") - xslValueOfDictionary.Values(i).IndexOf("""") - 1)))
				End Try

				If Not node Is Nothing Then
					If xslValueOfDictionary.Values(i).Substring(xslValueOfDictionary.Values(i).IndexOf("""") + 1, xslValueOfDictionary.Values(i).LastIndexOf("""") - xslValueOfDictionary.Values(i).IndexOf("""") - 1).ToLower.Contains("format-number") Then
						Dim delimeterChar As String
						Dim formatString As String = ""
						Dim t = xslValueOfDictionary.Values(i).Substring(xslValueOfDictionary.Values(i).IndexOf(""""), xslValueOfDictionary.Values(i).LastIndexOf("""") - xslValueOfDictionary.Values(i).IndexOf("""")).ToLower
						If t.Contains("[") Then
							t = t.Remove(t.IndexOf("["), t.IndexOf("]") - t.IndexOf("["))
						End If
						With t
							If .StartsWith("""") Then
								delimeterChar = "'"
							Else
								delimeterChar = """"
							End If
							Dim stIndex = .IndexOf(delimeterChar, .IndexOf("format-number("))
							Dim eIndex = .IndexOf(delimeterChar, stIndex + 1)
							formatString = .Substring(stIndex + 1, eIndex - stIndex - 1)
						End With
						convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, String.Format(Val(node.InnerText).ToString(formatString))))
					Else
						convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, node.InnerText))
					End If
				Else
					Try
						node = xmlDoc.DocumentElement.SelectNodes("x:AppSchemaBase/" & xPathString, nameSpaceMGR)(0)
						If Not node Is Nothing Then
							convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, node.InnerText))
						Else
							convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, xslValueOfDictionary.Values(i).Substring(xslValueOfDictionary.Values(i).IndexOf("""") + 1, xslValueOfDictionary.Values(i).LastIndexOf("""") - xslValueOfDictionary.Values(i).IndexOf("""") - 1)))
						End If
					Catch ex As Exception
						convertedBodyContents = convertedBodyContents.Insert(startIndex, String.Format("<xslvalueof id=""{0}""> {1} </xslvalueof>", i, xslValueOfDictionary.Values(i).Substring(xslValueOfDictionary.Values(i).IndexOf("""") + 1, xslValueOfDictionary.Values(i).LastIndexOf("""") - xslValueOfDictionary.Values(i).IndexOf("""") - 1)))
					End Try
				End If
				i += 1
			Loop
			Return convertedBodyContents
		End Function
	End Class

	Public Class Page
		Public ReadOnly Property Template As String
		Public ReadOnly Property StartingNode As String
		Public ReadOnly Property NewOnly As Boolean
		Public ReadOnly Property UsedOnly As Boolean
		Public ReadOnly Property TradeOnly As Boolean
		Public Sub New(templateName As String)
			Me.Template = templateName
			Me.StartingNode = "/x:AppSchemaBase/"
			Me.NewOnly = False
			Me.UsedOnly = False
			Me.TradeOnly = False
		End Sub
		Public Sub New(templateName As String, startingNode As String)
			Me.Template = templateName
			Me.StartingNode = startingNode
			Me.NewOnly = False
			Me.UsedOnly = False
			Me.TradeOnly = False
		End Sub
		Public Sub New(templateName As String, onlyOnNew As Boolean)
			Me.Template = templateName
			Me.StartingNode = "/x:AppSchemaBase/"
			Me.NewOnly = onlyOnNew
			Me.UsedOnly = False
			Me.TradeOnly = False
		End Sub
		Public Sub New(templateName As String, onlyOnNew As Boolean, onlyOnUsed As Boolean)
			Me.Template = templateName
			Me.StartingNode = "/x:AppSchemaBase/"
			Me.NewOnly = onlyOnNew
			Me.UsedOnly = onlyOnUsed
			Me.TradeOnly = False
		End Sub
		Public Sub New(templateName As String, onlyOnNew As Boolean, onlyOnUsed As Boolean, onlyOnTrade As Boolean)
			Me.Template = templateName
			Me.StartingNode = "/x:AppSchemaBase/"
			Me.NewOnly = onlyOnNew
			Me.UsedOnly = onlyOnUsed
			Me.TradeOnly = onlyOnTrade
		End Sub
		Public Sub New(templateName As String, onlyOnNew As Boolean, onlyOnUsed As Boolean, onlyOnTrade As Boolean, startingNode As String)
			Me.Template = templateName
			Me.StartingNode = startingNode
			Me.NewOnly = onlyOnNew
			Me.UsedOnly = onlyOnUsed
			Me.TradeOnly = onlyOnTrade
		End Sub
	End Class
	Public MustInherit Class Worksheet
		Public Property FilePath As String = ""
		Public Property SourceCode As String = ""

		Public Sub ResolveMerge(w As String, Optional KeepHead As Boolean = False)
			Dim targetXSLContents As String = SourceCode

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
			SourceCode = targetXSLContents
		End Sub
		Public Overloads Sub Save()
			If FilePath.Length > 0 Then
				If System.IO.Directory.Exists(Strings.Left(FilePath, InStrRev(FilePath, "\", -1, CompareMethod.Text))) Then
					Dim xslWriteSetttings As Xml.XmlWriterSettings = New Xml.XmlWriterSettings
					xslWriteSetttings.Indent = Xml.Formatting.Indented
					xslWriteSetttings.OmitXmlDeclaration = False
					xslWriteSetttings.IndentChars = ControlChars.Tab
					xslWriteSetttings.ConformanceLevel = Xml.ConformanceLevel.Fragment
					Using xw As Xml.XmlWriter = Xml.XmlTextWriter.Create(FilePath, xslWriteSetttings)
						xw.WriteRaw(SourceCode)
					End Using
				Else
					Dim ex As New Exception("The referenced directory does not exist. Unable to save file.")
					Throw ex
				End If
			Else
				Dim ex As New Exception("No directory specified. Unable to save file.")
				Throw ex
			End If
		End Sub
		Public Overloads Sub Save(SaveDirectory As String)
			FilePath = SaveDirectory
			If System.IO.Directory.Exists(Strings.Left(FilePath, InStrRev(FilePath, "\", -1, CompareMethod.Text))) Then

				''TEST
				Dim tempText As String

				tempText = SourceCode '.Replace("&", "~?!#~")


				Dim Settings = New Xml.XmlReaderSettings
				Settings.NameTable = New Xml.NameTable()
				Dim xmlns = New Xml.XmlNamespaceManager(Settings.NameTable)
				xmlns.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform")
				Dim context = New Xml.XmlParserContext(Nothing, xmlns, "", Xml.XmlSpace.None)
				Settings.ConformanceLevel = Xml.ConformanceLevel.Document
				Dim tempXML As New Xml.XmlDocument(xmlns.NameTable)
				tempXML.PreserveWhitespace = False
				tempXML.LoadXml(tempText)
				tempXML.Normalize()
				tempXML.Save(SaveDirectory)
				'SourceCode = tempXML.OuterXml.Replace("~?!#~", "&")
				''TEST


				Dim xslWriteSetttings As Xml.XmlWriterSettings = New Xml.XmlWriterSettings
				xslWriteSetttings.ConformanceLevel = Xml.ConformanceLevel.Document
				xslWriteSetttings.Encoding = System.Text.Encoding.ASCII
				xslWriteSetttings.OmitXmlDeclaration = False
				xslWriteSetttings.CheckCharacters = True
				xslWriteSetttings.Indent = True
				xslWriteSetttings.IndentChars = ControlChars.Tab
				xslWriteSetttings.NamespaceHandling = Xml.NamespaceHandling.OmitDuplicates
				xslWriteSetttings.NewLineChars = ControlChars.CrLf
				xslWriteSetttings.NewLineHandling = Xml.NewLineHandling.Replace



				Using xw As Xml.XmlWriter = Xml.XmlWriter.Create(FilePath, xslWriteSetttings)
					''TEST
					'tempDoc.Save()
					''TEST

					tempXML.Save(xw)
					'xw.WriteRaw(SourceCode)
				End Using
			Else
				Dim ex As New Exception("The referenced directory does not exist. Unable to save file.")
				Throw ex
			End If
		End Sub
	End Class
End Namespace
