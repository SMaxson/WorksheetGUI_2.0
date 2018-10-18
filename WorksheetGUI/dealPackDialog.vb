Imports System.IO

Public Class dealPackDialog
	Dim dealPackFileName As String
	Dim maxLines As Integer = 1

	Private Sub dealPackDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim DisplayBox As New TextBox
		With TextBox1
			DisplayBox.Size = .Size
			DisplayBox.Location = .Location
			DisplayBox.Font = .Font
			DisplayBox.BorderStyle = .BorderStyle
			DisplayBox.BackColor = SystemColors.ButtonHighlight
			DisplayBox.Name = "DisplayBox1"
		End With
		AddHandler TextBox1.MouseClick, AddressOf TextBox_Click
		AddHandler DisplayBox.MouseClick, AddressOf TextBox_Click
		AddHandler CheckBox1.CheckedChanged, AddressOf AppSchema_CheckedChanged
		AddHandler newBox1.CheckedChanged, AddressOf NewOnly_CheckedChanged
		AddHandler usedBox1.CheckedChanged, AddressOf UsedOnly_CheckedChanged
		AddHandler tradeBox1.CheckedChanged, AddressOf TradeOnly_CheckedChanged
		AddHandler coBuyerBox1.CheckedChanged, AddressOf CoBuyerOnly_CheckedChanged
		AddHandler deleteButton1.Click, AddressOf ClearButton
		MainFrame.Controls.Add(DisplayBox)
		DisplayBox.BringToFront()
		For i As Integer = 1 To 15
			MoreButtons()
		Next
	End Sub

	Private Sub TextBox_Click(sender As Object, e As EventArgs)
		Dim sdr As TextBox = sender

		Dim n As Integer = 0
		Dim displayString As String = ""
		If Integer.TryParse(Strings.Right(sdr.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(sdr.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(sdr.Name, 1))
		End If
		Dim tb = DirectCast(MainFrame.Controls("TextBox" & n.ToString), TextBox)
		Dim db = DirectCast(MainFrame.Controls("DisplayBox" & n.ToString), TextBox)

		Dim getFile = New OpenFileDialog
		getFile.ShowDialog(Me)
		Me.Capture = False
		If getFile.FileName.ToLower.Contains("_body") Or getFile.FileName.ToLower.Contains("/body/") Then
			If Not AlreadyIncluded(getFile.FileName) Then
				tb.Text = getFile.FileName
				displayString = Strings.Right(getFile.FileName, (getFile.FileName.Length - InStrRev(getFile.FileName, "\", -1, CompareMethod.Text)))
				db.Text = displayString.Chars(0).ToString.ToUpper & displayString.Substring(1)
			End If
			Threading.Thread.Sleep(100)
			Me.Capture = True
		Else
			If getFile.FileName.Length > 1 Then
				Dim tempWS As New Worksheet.ShellFile
				tempWS.Load(getFile.FileName)
				Dim bodyFiles As List(Of String) = tempWS.GetFiles
				If bodyFiles.Count > 0 Then
					Dim appSchemaFiles As List(Of String) = GetIncludedAppSchema(getFile.FileName)
					InsertFiles(n, bodyFiles, appSchemaFiles)
				Else
					tb.Text = getFile.FileName
					displayString = Strings.Right(getFile.FileName, (getFile.FileName.Length - InStrRev(getFile.FileName, "\", -1, CompareMethod.Text)))
					db.Text = displayString.Chars(0).ToString.ToUpper & displayString.Substring(1)
				End If
			End If
			RollFiles()
			Threading.Thread.Sleep(100)
			Me.Capture = True
		End If
	End Sub


	Public Function GetIncludedAppSchema(w As String) As List(Of String)
		Dim AppSchemaList As New List(Of String)()
		Dim targetXSLContents As String = ""
		Dim folder As String = Strings.Left(w, InStrRev(w, "\", -1, CompareMethod.Text))
		Using sr As StreamReader = File.OpenText(w)
			Do While sr.Peek() >= 0
				targetXSLContents = sr.ReadToEnd
			Loop
		End Using

		Dim position As Integer = 0
		While position <> -1
			position = targetXSLContents.IndexOf("<xsl:for-each", position)
			If position <> -1 Then
				position = targetXSLContents.IndexOf("<xsl:call-template name=""", position)
				If position <> -1 Then
					Dim endPosition As Integer = targetXSLContents.IndexOf("""", position + 25)
					If endPosition <> -1 Then
						Dim referencedBody = targetXSLContents.Substring(position + 25, endPosition - position - 25)
						AppSchemaList.Add(referencedBody)
					End If
					position = endPosition
				End If
			End If
		End While
		Return AppSchemaList
	End Function

	Private Sub ClearButton(sender As Object, e As EventArgs)
		Dim btn As Button = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(btn.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(btn.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(btn.Name, 1))
		End If
		Dim tb = DirectCast(MainFrame.Controls("TextBox" & n.ToString), TextBox)
		tb.Text = ""
		RollFiles()
	End Sub

	Private Sub AppSchema_CheckedChanged(sender As Object, e As EventArgs)
		Dim checkbox As CheckBox = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(checkbox.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(checkbox.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(checkbox.Name, 1))
		End If
		Dim appschema = DirectCast(MainFrame.Controls("DisplayBox" & n.ToString), TextBox)
		If sender.Checked = True Then
			appschema.BackColor = Color.LightCoral
		Else
			appschema.BackColor = SystemColors.ButtonHighlight
		End If
	End Sub

	Private Sub NewOnly_CheckedChanged(sender As Object, e As EventArgs)
		Dim checkbox As CheckBox = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(checkbox.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(checkbox.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(checkbox.Name, 1))
		End If
		Dim nv = DirectCast(MainFrame.Controls("newLabel" & n), Label)
		Dim uv = DirectCast(MainFrame.Controls("usedLabel" & n), Label)
		Dim uc = DirectCast(usedPanel.Controls("usedBox" & n), CheckBox)
		If sender.Checked = True Then
			nv.Visible = True
			uv.Visible = False
			uc.Checked = False
		Else
			nv.Visible = False
		End If
	End Sub

	Private Sub UsedOnly_CheckedChanged(sender As Object, e As EventArgs)
		Dim checkbox As CheckBox = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(checkbox.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(checkbox.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(checkbox.Name, 1))
		End If
		Dim uv = DirectCast(MainFrame.Controls("usedLabel" & n), Label)
		Dim nv = DirectCast(MainFrame.Controls("newLabel" & n), Label)
		Dim nc = DirectCast(newPanel.Controls("newBox" & n), CheckBox)
		If sender.Checked = True Then
			uv.Visible = True
			nv.Visible = False
			nc.Checked = False
		Else
			uv.Visible = False
		End If
	End Sub

	Private Sub TradeOnly_CheckedChanged(sender As Object, e As EventArgs)
		Dim checkbox As CheckBox = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(checkbox.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(checkbox.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(checkbox.Name, 1))
		End If
		Dim tv = DirectCast(MainFrame.Controls("tradeLabel" & n), Label)
		If sender.Checked = True Then
			tv.Visible = True
		Else
			tv.Visible = False
		End If
	End Sub

	Private Sub CoBuyerOnly_CheckedChanged(sender As Object, e As EventArgs)
		Dim checkbox As CheckBox = sender
		Dim n As Integer = 0
		If Integer.TryParse(Strings.Right(checkbox.Name, 2), n) Then
			n = Integer.Parse(Strings.Right(checkbox.Name, 2))
		Else
			n = Integer.Parse(Strings.Right(checkbox.Name, 1))
		End If
		Dim tv = DirectCast(MainFrame.Controls("coBuyerLabel" & n), Label)
		If sender.Checked = True Then
			tv.Visible = True
		Else
			tv.Visible = False
		End If
	End Sub

	Private Sub cancelButton1_Click(sender As Object, e As EventArgs) Handles cancelButton1.Click
		dealPackDialog.ActiveForm.Close()
	End Sub

	Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
		createDealPackDialog.ShowDialog(Me)
	End Sub

	Private Sub createDealPackDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles createDealPackDialog.FileOk
		dealPackFileName = createDealPackDialog.FileName.ToString()
		Call createDealPackXSLT()
		wsGUIWindow.targetXSL = dealPackFileName

		Me.Close()
	End Sub

	Private Sub createDealPackXSLT()
		Dim body(maxLines) As String
		Dim templates(maxLines) As String
		Dim CoBuyerOnly, NewOnly, UsedOnly, TradeOnly, MultiTrade As Boolean
		For i As Integer = 1 To maxLines
			body(i) = DirectCast(MainFrame.Controls("TextBox" & i.ToString), TextBox).Text
			templates(i) = ""
			If body(i) IsNot "" Then
				Try
					body(i) = ((Strings.Right(body(i), (body(i).Length - InStrRev(body(i), "Worksheets\", -1, CompareMethod.Text) - 10))).Replace("\", "/")).Replace(".xslt", "")
					templates(i) = (Strings.Right(body(i), (body(i).Length - InStrRev(body(i), "/", -1, CompareMethod.Text))))
					templates(i) = templates(i).Chars(0).ToString.ToUpper & templates(i).Substring(1)
				Catch ex As Exception
					If ex.InnerException IsNot Nothing Then
						MsgBox((ex.Message.ToString & " " & ex.InnerException.Message.ToString).ToString)
					Else
						MsgBox((ex.Message.ToString).ToString)
					End If
				End Try
			End If
		Next

		Using sw As StreamWriter = File.CreateText((dealPackFileName).ToString)
			sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
			sw.WriteLine("<xsl:stylesheet version=""1.0""")
			sw.WriteLine("	xmlns:xsl=""http://www.w3.org/1999/XSL/Transform""")
			sw.WriteLine("	xmlns:msxsl=""urn:schemas-microsoft-com:xslt""")
			sw.WriteLine("	xmlns:user=""http://www.elead.us/eDESK""")
			sw.WriteLine("	xmlns:dt=""urn:schemas-microsoft-com:datatypes""")
			sw.WriteLine("	xmlns:x=""http://www.elead.us/AppSchema.xsd"">")
			sw.WriteLine(" ")
			sw.WriteLine("	<xsl:output method=""html"" omit-xml-declaration=""yes""/>")
			sw.WriteLine("	<xsl:decimal-format NaN=""""/>")
			sw.WriteLine(" ")
			sw.WriteLine("	<xsl:include href=""../_scripts/user_functions.xslt""/>")

			For i As Integer = 1 To maxLines
				If body(i) IsNot "" Then
					Try
						sw.WriteLine("	<xsl:include href=""../" & body(i) & ".xslt"" />")
					Catch ex As Exception
						If ex.InnerException IsNot Nothing Then
							MsgBox((ex.Message.ToString & " " & ex.InnerException.Message.ToString).ToString)
						Else
							MsgBox((ex.Message.ToString).ToString)
						End If
					End Try
				End If
			Next

			sw.WriteLine("	<xsl:include href=""../_Generic/body/FormStylesheet_Two.xslt"" />")
			sw.WriteLine("")
			sw.WriteLine("	<xsl:template match=""Package"">")
			sw.WriteLine("		<includes>")
			sw.WriteLine("			<include href=""../_scripts/user_functions.xslt""/>")

			For i As Integer = 1 To maxLines
				If body(i) IsNot "" Then
					Try
						sw.WriteLine("				<include href=""../" & body(i) & ".xslt"" />")
					Catch ex As Exception
						If ex.InnerException IsNot Nothing Then
							MsgBox((ex.Message.ToString & " " & ex.InnerException.Message.ToString).ToString)
						Else
							MsgBox((ex.Message.ToString).ToString)
						End If
					End Try
				End If
			Next

			sw.WriteLine("			<include href=""../_Generic/body/FormStylesheet_Two.xslt"" />")
			sw.WriteLine("		</includes>")
			sw.WriteLine("	</xsl:template>")
			sw.WriteLine("	<xsl:template match=""x:AppSchemaBase"">")
			sw.WriteLine("		<html>")
			sw.WriteLine("		<head>")
			sw.WriteLine("			<title>")
			sw.WriteLine("				<xsl:value-of select=""x:Company/x:Company""/> Delivery Package")
			sw.WriteLine("			</title>")
			sw.WriteLine("			<xsl:call-template name=""FormStylesheet_Two"" />")
			sw.WriteLine("			<xsl:call-template name=""user_functions"" />")
			sw.WriteLine("		</head>")
			sw.WriteLine("		<style>")
			sw.WriteLine("			.center {")
			sw.WriteLine("				margin-left:auto;")
			sw.WriteLine("				margin-right:auto;")
			sw.WriteLine("				width:750px;")
			sw.WriteLine("			}")
			sw.WriteLine("		</style>")
			For i As Integer = 1 To maxLines
				If DirectCast(newPanel.Controls("newBox" & i.ToString), CheckBox).Checked Or DirectCast(usedPanel.Controls("usedBox" & i.ToString), CheckBox).Checked Then
					Try
						sw.WriteLine("		<xsl:variable name =""NewUsedDemo"" select=""(x:VehicleSought[x:NewUsedDemo !='']/x:NewUsedDemo | x:Inventory[x:NewUsedDemo !='']/x:NewUsedDemo)[1]""/>")
						Exit For
					Catch ex As Exception
						If ex.InnerException IsNot Nothing Then
							MsgBox((ex.Message.ToString & " " & ex.InnerException.Message.ToString).ToString)
						Else
							MsgBox((ex.Message.ToString).ToString)
						End If
					End Try
				End If
			Next
			sw.WriteLine("		<body>")
			sw.WriteLine("			<div class=""center"">")

			For i As Integer = 1 To maxLines
				If templates(i) IsNot "" Then
					CoBuyerOnly = DirectCast(coBuyerPanel.Controls("coBuyerBox" & i.ToString), CheckBox).Checked
					NewOnly = DirectCast(newPanel.Controls("newBox" & i.ToString), CheckBox).Checked
					UsedOnly = DirectCast(usedPanel.Controls("usedBox" & i.ToString), CheckBox).Checked
					TradeOnly = DirectCast(tradePanel.Controls("tradeBox" & i.ToString), CheckBox).Checked
					MultiTrade = DirectCast(appSchemaPanel.Controls("CheckBox" & i.ToString), CheckBox).Checked
					If NewOnly Then
						sw.WriteLine("			<xsl:if test=""$NewUsedDemo ='N'"">")
					ElseIf UsedOnly Then
						sw.WriteLine("			<xsl:if test=""$NewUsedDemo ='U'"">")
					End If
					If CoBuyerOnly Then
						sw.WriteLine("			<xsl:if test=""x:Customer[2]"">")
					End If
					If TradeOnly And MultiTrade Then
						sw.WriteLine("          <xsl:for-each select=""x:TradeIn"">")
						sw.WriteLine("          	<div class=""page"">")
						sw.WriteLine(String.Format("          		<xsl:call-template name=""{0}""/>", templates(i)))
						sw.WriteLine("          	</div>")
						sw.WriteLine("          </xsl:for-each>")
					ElseIf TradeOnly Then
						sw.WriteLine("			<xsl:if test=""x:TradeIn"">")
						sw.WriteLine("			<div class=""page"">")
						sw.WriteLine(String.Format("				<xsl:call-template name=""{0}""/>", templates(i)))
						sw.WriteLine("			</div>")
						sw.WriteLine("			</xsl:if>")
					ElseIf MultiTrade Then
						sw.WriteLine("			<xsl:choose>")
						sw.WriteLine("				<xsl:when test=""x:TradeIn"">")
						sw.WriteLine("					<xsl:for-each select=""x:TradeIn"">")
						sw.WriteLine("						<div class=""page"">")
						sw.WriteLine(String.Format("							<xsl:call-template name=""{0}""/>", templates(i)))
						sw.WriteLine("						</div>")
						sw.WriteLine("					</xsl:for-each>")
						sw.WriteLine("				</xsl:when>")
						sw.WriteLine("				<xsl:otherwise>")
						sw.WriteLine("					<div class=""page"">")
						sw.WriteLine(String.Format("							<xsl:call-template name=""{0}""/>", templates(i)))
						sw.WriteLine("					</div>")
						sw.WriteLine("				</xsl:otherwise>")
						sw.WriteLine("			</xsl:choose>")
					Else
						sw.WriteLine("			<div class=""page"">")
						sw.WriteLine(String.Format("				<xsl:call-template name=""{0}""/>", templates(i)))
						sw.WriteLine("			</div>")
					End If
					If CoBuyerOnly Then sw.WriteLine("			</xsl:if>")
					If UsedOnly Then sw.WriteLine("			</xsl:if>")
					If NewOnly Then sw.WriteLine("			</xsl:if>")
					End If
            Next

			sw.WriteLine("			</div>")
			sw.WriteLine(" ")
			sw.WriteLine("		</body>")
			sw.WriteLine("		</html>")
			sw.WriteLine("	</xsl:template>")
			sw.WriteLine("</xsl:stylesheet>")
		End Using

	End Sub

	Private Sub MoreButtons()
		maxLines += 1
		Dim newTB As TextBox = New TextBox
		Dim newDB As New TextBox
		Dim newAS As CheckBox = New CheckBox
		Dim newCO As CheckBox = New CheckBox
		Dim newNO As CheckBox = New CheckBox
		Dim newTO As CheckBox = New CheckBox
		Dim newUO As CheckBox = New CheckBox
		Dim newCL As Label = New Label
		Dim newNL As Label = New Label
		Dim newTL As Label = New Label
		Dim newUL As Label = New Label
		Dim newNumber As Label = New Label
		Dim newClear As Button = New Button
		Dim t = DirectCast(MainFrame.Controls("TextBox" & maxLines - 1), TextBox)
		Dim t26 = TextBox1.Location.Y + ((maxLines - 1) * 26)
		newNumber.Location = New Point(number1.Location.X, t26 + 2)
		newNL.Location = New Point(newLabel1.Location.X, t26)
		newUL.Location = New Point(usedLabel1.Location.X, t26)
		newTL.Location = New Point(tradeLabel1.Location.X, t26)
		newCL.Location = New Point(coBuyerLabel1.Location.X, t26)
		newTB.Location = New Point(TextBox1.Location.X, t26)
		newDB.Location = New Point(TextBox1.Location.X, t26)
		newClear.Location = New Point(deleteButton1.Location.X, t26)
		newNumber.Font = number1.Font
		newNumber.AutoSize = False
		newNumber.Size = New Size(23, 19)
		newNumber.Text = maxLines
		newNumber.TextAlign = ContentAlignment.TopRight
		newNL.Font = newLabel1.Font
		newUL.Font = usedLabel1.Font
		newTL.Font = tradeLabel1.Font
		newCL.Font = coBuyerLabel1.Font
		newNL.ForeColor = Color.MediumSeaGreen
		newUL.ForeColor = Color.DodgerBlue
		newTL.ForeColor = Color.DarkKhaki
		newCL.ForeColor = coBuyerLabel1.ForeColor
		newNL.AutoSize = False
		newTL.AutoSize = False
		newUL.AutoSize = False
		newCL.AutoSize = False
		newNL.Size = New Size(21, 20)
		newUL.Size = New Size(21, 20)
		newTL.Size = New Size(21, 20)
		newCL.Size = New Size(21, 20)
		newNL.Name = "newLabel" & maxLines
		newUL.Name = "usedLabel" & maxLines
		newTL.Name = "tradeLabel" & maxLines
		newCL.Name = "coBuyerLabel" & maxLines
		newNL.Text = "N"
		newUL.Text = "U"
		newTL.Text = "T"
		newCL.Text = "2"
		newAS.Size = New Size(15, 14)
		newAS.Location = New Point(17, (maxLines - 1) * 26 + 4)
		newAS.Name = "CheckBox" & maxLines
		newCO.Size = New Size(15, 14)
		newCO.Location = New Point(15, (maxLines - 1) * 26 + 4)
		newCO.Name = "coBuyerBox" & maxLines
		newNO.Size = New Size(15, 14)
		newNO.Location = New Point(10, (maxLines - 1) * 26 + 4)
		newNO.Name = "newBox" & maxLines
		newTO.Size = New Size(15, 14)
		newTO.Location = New Point(14, (maxLines - 1) * 26 + 4)
		newTO.Name = "tradeBox" & maxLines
		newUO.Size = New Size(15, 14)
		newUO.Location = New Point(10, (maxLines - 1) * 26 + 4)
		newUO.Name = "usedBox" & maxLines
		newTB.Size = TextBox1.Size
		newTB.Name = "TextBox" & maxLines
		newTB.BackColor = SystemColors.ButtonHighlight
		newTB.TextAlign = HorizontalAlignment.Right
		newDB.Size = TextBox1.Size
		newDB.Name = "DisplayBox" & maxLines
		newDB.BackColor = SystemColors.ButtonHighlight
		newPanel.Height = newPanel.Height + 26
		newPanel.Controls.Add(newNO)
		tradePanel.Height = tradePanel.Height + 26
		tradePanel.Controls.Add(newTO)
		usedPanel.Height = usedPanel.Height + 26
		usedPanel.Controls.Add(newUO)
		appSchemaPanel.Height = appSchemaPanel.Height + 26
		appSchemaPanel.Controls.Add(newAS)
		coBuyerPanel.Height = coBuyerPanel.Height + 26
		coBuyerPanel.Controls.Add(newCO)
		newClear.Size = deleteButton1.Size
		newClear.Text = deleteButton1.Text
		newClear.FlatStyle = deleteButton1.FlatStyle
		newClear.Name = "deleteButton" & maxLines


		AddHandler newNO.CheckedChanged, AddressOf NewOnly_CheckedChanged
		AddHandler newUO.CheckedChanged, AddressOf UsedOnly_CheckedChanged
		AddHandler newTO.CheckedChanged, AddressOf TradeOnly_CheckedChanged
		AddHandler newAS.CheckedChanged, AddressOf AppSchema_CheckedChanged
		AddHandler newCO.CheckedChanged, AddressOf CoBuyerOnly_CheckedChanged
		AddHandler newTB.Click, AddressOf TextBox_Click
		AddHandler newDB.Click, AddressOf TextBox_Click
		AddHandler newClear.Click, AddressOf ClearButton


		MainFrame.Controls.Add(newDB)
		MainFrame.Controls.Add(newTB)
		MainFrame.Controls.Add(newTL)
		MainFrame.Controls.Add(newNL)
		MainFrame.Controls.Add(newUL)
		MainFrame.Controls.Add(newCL)
		MainFrame.Controls.Add(newNumber)
		MainFrame.Controls.Add(newClear)
		newNL.Visible = False
		newTL.Visible = False
		newUL.Visible = False
		newCL.Visible = False
		newDB.BringToFront()
	End Sub

	Private Sub RollFiles()
		Dim files As New List(Of String)
		Dim friendlyFiles As New List(Of String)
		Dim appSchemaCheckboxes As New List(Of Boolean)
		For i As Integer = 1 To maxLines
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & i), TextBox)
			Dim displayBox = DirectCast(MainFrame.Controls("DisplayBox" & i), TextBox)
			Dim appSchemaCheck = DirectCast(appSchemaPanel.Controls("CheckBox" & i), CheckBox)
			If textBox.Text.Length > 1 Then
				files.Add(textBox.Text)
				friendlyFiles.Add(displayBox.Text)
				appSchemaCheckboxes.Add(appSchemaCheck.Checked)
			End If
		Next
		For i As Integer = 1 To files.Count
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & i), TextBox)
			Dim displayBox = DirectCast(MainFrame.Controls("DisplayBox" & i), TextBox)
			Dim appSchemaCheck = DirectCast(appSchemaPanel.Controls("CheckBox" & i), CheckBox)
			textBox.Text = files.Item(i - 1)
			displayBox.Text = friendlyFiles.Item(i - 1)
			appSchemaCheck.Checked = appSchemaCheckboxes.Item(i - 1)
		Next
		For i As Integer = files.Count + 1 To maxLines
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & i), TextBox)
			Dim displayBox = DirectCast(MainFrame.Controls("DisplayBox" & i), TextBox)
			Dim appSchemaCheck = DirectCast(appSchemaPanel.Controls("CheckBox" & i), CheckBox)
			textBox.Text = ""
			displayBox.Text = ""
			appSchemaCheck.Checked = False
		Next
	End Sub

	Private Sub InsertFiles(n As Integer, bodyFiles As List(Of String), Optional AppSchemaFiles As List(Of String) = Nothing)
		Dim files As New List(Of String)
		Dim friendlyFiles As New List(Of String)
		Dim appSchemaCheckboxes As New List(Of Boolean)
		Dim multiTradeMatchFound As Boolean = False
		For i As Integer = 0 To bodyFiles.Count - 1
			If Not AlreadyIncluded(bodyFiles.Item(i)) Then
				files.Add(bodyFiles.Item(i))
				friendlyFiles.Add(Strings.Right(bodyFiles.Item(i), (bodyFiles.Item(i).Length - InStrRev(bodyFiles.Item(i), "\", -1, CompareMethod.Text))))
				If Not Char.IsUpper(friendlyFiles.Last.ToCharArray.First) Then
					files(i) = files(i).Substring(0, files(i).IndexOf(friendlyFiles.Last)) & Char.ToUpper(files(i).ToCharArray.ElementAt(files(i).IndexOf(friendlyFiles.Last))) & files(i).Substring(files(i).IndexOf(friendlyFiles.Last) + 1)
					friendlyFiles(friendlyFiles.Count - 1) = Char.ToUpper(friendlyFiles.Last.ToCharArray.First) & friendlyFiles.Last.Substring(1)
				End If

				multiTradeMatchFound = False
				For j As Integer = 0 To AppSchemaFiles.Count - 1
					If bodyFiles(i).ToLower.Contains(AppSchemaFiles(j).ToLower & ".xslt") Then
						multiTradeMatchFound = True
					End If
				Next
				appSchemaCheckboxes.Add(multiTradeMatchFound)
			End If
		Next
		For i As Integer = n To maxLines
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & i), TextBox)
			Dim displayBox = DirectCast(MainFrame.Controls("DisplayBox" & i), TextBox)
			Dim appSchemaCheck = DirectCast(appSchemaPanel.Controls("CheckBox" & i), CheckBox)
			If textBox.Text.Length > 1 Then
				files.Add(textBox.Text)
				friendlyFiles.Add(displayBox.Text)
				appSchemaCheckboxes.Add(appSchemaCheck.Checked)
			End If
			textBox.Text = ""
			displayBox.Text = ""
		Next
		If n + files.Count > maxLines Then
			Dim diff = (n + files.Count) - maxLines
			For i As Integer = 1 To diff
				MoreButtons()
			Next
		End If
		For i As Integer = 0 To files.Count - 1
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & n + i), TextBox)
			Dim displayBox = DirectCast(MainFrame.Controls("DisplayBox" & n + i), TextBox)
			Dim appSchemaCheck = DirectCast(appSchemaPanel.Controls("CheckBox" & n + i), CheckBox)
			textBox.Text = files.Item(i)
			displayBox.Text = friendlyFiles.Item(i)
			appSchemaCheck.Checked = appSchemaCheckboxes(i)
		Next
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		MoreButtons()
	End Sub
	Private Function AlreadyIncluded(ws As String) As Boolean
		Dim files As New List(Of String)
		For i As Integer = 1 To maxLines
			Dim textBox = DirectCast(MainFrame.Controls("TextBox" & i), TextBox)
			If textBox.Text.Length > 1 Then files.Add(textBox.Text.ToLower)
		Next
		Return files.Contains(ws.ToLower)
	End Function

	Private Sub MainFrame_Paint(sender As Object, e As PaintEventArgs) Handles MainFrame.Paint

	End Sub
End Class