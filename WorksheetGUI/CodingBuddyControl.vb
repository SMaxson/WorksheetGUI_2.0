Public Class CodingBuddyControl
	Public Property codingBuddySpeaking As Image
	Dim codingBuddyBlinking As Image
	Dim codingBuddySFX As New List(Of Object)
	Public Property codingBuddyActive As Boolean = True
	Public Property isFirstUse As Boolean = False
	Private Property Index As Integer = 0
	Private WithEvents codingBuddyTimer As Timer
	Private WithEvents textPrintDelay As Timer
	Public Property codingBuddyID As Integer
		Get
			Return Index
		End Get
		Set(newCodingBuddyID As Integer)
			Me.Index = newCodingBuddyID
			loadBuddy()
		End Set
		'Determines which character to use. 
		'1 = MumboJumbo
		'2 = Bottles
		'3 = Kazooie
		'4 = JamJars
		'5 = Klungo
		'6 = Banjo
		'7 = Peppy Hare
		'8 = Navi
		'9 = Sabreman
		'10 = Dispear
		'11 = Oblivion Guard
	End Property

	'These are for containing information about errors
	Dim erFile As String
	Dim erFolder As String
	Dim erLine As String
	Dim erPos As String
	Public erSourceURI As String = ""
	Private errorMessage As String
	Public fullErrorMessage As String
	Private lastErrorMessage As String
	Private errorMessageDictionary As New Dictionary(Of String, String)

	'This information is used to determine how text is printed to the output
	Dim count_ As Integer
	Dim str_ As String

	Public Property codingBuddyReadAll As Boolean = False

	Dim codingBuddyFunctionArgs As New List(Of String)
	Public Property codingBuddyFunctionToExecute As String = ""


	Public Sub New(Optional codingBuddyID As Integer = 0)
		Me.InitializeComponent()
		Me.Visible = False
		For Each line As String In IO.File.ReadAllLines("C:\Projects\WorksheetsGit\.WorksheetTools\Program Files (Do Not Modify)\errorMessageDictionary.txt")
			Dim parts() As String = line.Split("~")
			Me.errorMessageDictionary.Add(parts(0), parts(1))
		Next
		If Not codingBuddyID = 0 Then
			Me.codingBuddyID = codingBuddyID
		Else
			Dim codingBuddyChoose As New Random
			Me.codingBuddyID = codingBuddyChoose.Next(1, 11)
		End If

		textPrintDelay = New Timer
		textPrintDelay.Enabled = False
		textPrintDelay.Interval = 10
		loadBuddy()
	End Sub

	Private Sub loadBuddy()
		'Clear prior character resources
		codingBuddySFX.Clear()

		'Load new character resources
		Select Case Me.Index
			Case 1
				Me.codingBuddySFX.Add(My.Resources.mumbo1)
				Me.codingBuddySFX.Add(My.Resources.mumbo2)
				Me.codingBuddySFX.Add(My.Resources.mumbo3)
				Me.codingBuddySFX.Add(My.Resources.mumbo4)
				Me.codingBuddySFX.Add(My.Resources.mumbo5)
				Me.codingBuddySFX.Add(My.Resources.mumbo6)
				Me.codingBuddySpeaking = My.Resources.Mumbo_Speaking
				Me.codingBuddyBlinking = My.Resources.Mumbo_Blinking
			Case 2
				Me.codingBuddySFX.Add(My.Resources.bottles1)
				Me.codingBuddySFX.Add(My.Resources.bottles2)
				Me.codingBuddySFX.Add(My.Resources.bottles3)
				Me.codingBuddySpeaking = My.Resources.Bottles_Speaking
				Me.codingBuddyBlinking = My.Resources.Bottles_Blinking
			Case 3
				Me.codingBuddySFX.Add(My.Resources.kazooie1)
				Me.codingBuddySFX.Add(My.Resources.kazooie2)
				Me.codingBuddySFX.Add(My.Resources.kazooie3)
				Me.codingBuddySFX.Add(My.Resources.kazooie4)
				Me.codingBuddySpeaking = My.Resources.Kazooie_Speaking
				Me.codingBuddyBlinking = My.Resources.Kazooie_Blinking
			Case 4
				Me.codingBuddySFX.Add(My.Resources.jamjars1)
				Me.codingBuddySFX.Add(My.Resources.jamjars2)
				Me.codingBuddySFX.Add(My.Resources.jamjars3)
				Me.codingBuddySFX.Add(My.Resources.jamjars4)
				Me.codingBuddySpeaking = My.Resources.Jamjars_Speaking
				Me.codingBuddyBlinking = My.Resources.Jamjars_Speaking
			Case 5
				Me.codingBuddySFX.Add(My.Resources.klungo1)
				Me.codingBuddySFX.Add(My.Resources.klungo2)
				Me.codingBuddySFX.Add(My.Resources.klungo3)
				Me.codingBuddySpeaking = My.Resources.Klungo_Speaking
				Me.codingBuddyBlinking = My.Resources.Klungo_Blinking
			Case 6
				Me.codingBuddySFX.Add(My.Resources.banjo1)
				Me.codingBuddySpeaking = My.Resources.Banjo_Speaking
				Me.codingBuddyBlinking = My.Resources.Banjo_Blinking
			Case 7
				Me.codingBuddySFX.Add(My.Resources.peppy1)
				Me.codingBuddySpeaking = My.Resources.Peppy
				Me.codingBuddyBlinking = My.Resources.Peppy
			Case 8
				Me.codingBuddySFX.Add(My.Resources.OOT_Dialogue_Next)
				Me.codingBuddySpeaking = My.Resources.Navi
				Me.codingBuddyBlinking = My.Resources.Navi
			Case 9
				Me.codingBuddySFX.Add(My.Resources.Sabreman_Beep)
				Me.codingBuddySpeaking = My.Resources.Sabreman_Blinking
				Me.codingBuddyBlinking = My.Resources.Sabreman_Blinking
			Case 10
				Me.codingBuddySFX.Add(My.Resources.Burp1)
				Me.codingBuddySFX.Add(My.Resources.Burp2)
				Me.codingBuddySFX.Add(My.Resources.Burp3)
				Me.codingBuddySFX.Add(My.Resources.Burp4)
				Me.codingBuddySpeaking = My.Resources.Pear
				Me.codingBuddyBlinking = My.Resources.Pear
			Case 11
				Me.codingBuddySFX.Add(My.Resources.StopRightThere_Short)
				Me.codingBuddySpeaking = My.Resources.ImperialGuard
				Me.codingBuddyBlinking = My.Resources.ImperialGuard
			Case Else
				isFirstUse = True
				Dim codingBuddyChoose As New Random
				Me.codingBuddyID = codingBuddyChoose.Next(1, 7)
		End Select
	End Sub
	Public Sub handleError(Optional ByRef ex As Exception = Nothing, Optional ByVal errorMessageString As String = "")
		If Not IsNothing(ex) Then
			errorMessage = ex.Message
			If ex.InnerException IsNot Nothing Then
				errorMessage &= " " & ex.InnerException.Message.ToString
			End If
		ElseIf errorMessageString.Length > 0 Then
			errorMessage = errorMessageString
		Else
			errorMessage = "An error has occurred. I apologize for the inconvenience"
		End If
		Dim errorCulprit As String()
		Dim separatorTags As String() = {"'"}
		codingBuddyFunctionToExecute = ""
		codingBuddyFunctionArgs.Clear()
		errorCulprit = errorMessage.Split(separatorTags, StringSplitOptions.None)
		fullErrorMessage = errorMessage.ToString().Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "")
		If Not erSourceURI = "" Then
			erSourceURI = erSourceURI.Replace("file:///", "")
			fullErrorMessage = fullErrorMessage & " " & erSourceURI
			erFile = Strings.Right(erSourceURI, erSourceURI.Length - InStrRev(erSourceURI, "/", -1, CompareMethod.Text))
			
		End If
		If codingBuddyActive Then
			Dim helpMessage As String = ""
			If Me.errorMessageDictionary.TryGetValue(errorMessage, helpMessage) Then
				Me.errorMessageDictionary.TryGetValue(errorMessage, helpMessage)
			End If
			If errorMessage.Contains("The named template") AndAlso errorMessage.Contains("does not exist") Then
				errorCulprit = errorMessage.Split(separatorTags, StringSplitOptions.None)
				errorMessageDictionary.TryGetValue("Template does not exist", helpMessage)
			ElseIf errorMessage.Contains("Could not find a part of the path") Then
				errorCulprit = errorMessage.Split(separatorTags, StringSplitOptions.None)
				erFolder = Replace(errorCulprit(1), "file:///", "").Replace("\", "/")
				erFile = Strings.Right(erFolder, erFolder.Length - InStrRev(erFolder, "/", -1, CompareMethod.Text))
				erFolder = Strings.Left(erFolder, InStrRev(erFolder, "/", -1, CompareMethod.Text))
				errorMessageDictionary.TryGetValue("Could not find path", helpMessage)
				codingBuddyFunctionToExecute = "fixReferences"
			ElseIf errorMessage.Contains("Could not find file") Then
				errorCulprit = errorMessage.Split(separatorTags, StringSplitOptions.None)
				erFolder = Replace(errorCulprit(1), "file:///", "").Replace("\", "/")
				erFile = Strings.Right(erFolder, erFolder.Length - InStrRev(erFolder, "/", -1, CompareMethod.Text))
				erFolder = Strings.Left(erFolder, InStrRev(erFolder, "/", -1, CompareMethod.Text))
				If erFile.Contains("__") Then
					errorMessageDictionary.TryGetValue("Double underscore", helpMessage)
					codingBuddyFunctionToExecute = "fixUnderscore"
				Else
					errorMessageDictionary.TryGetValue("Could not find file", helpMessage)
					codingBuddyFunctionToExecute = "fixReferences"
				End If
			ElseIf errorMessage.Contains("'xsl:stylesheet' element cannot have text node children.") Then
				Me.errorMessageDictionary.TryGetValue("'xsl:stylesheet' element cannot have text node children.", helpMessage)
			ElseIf errorMessage.Contains("Name cannot begin with the '<' character") Then
				'If wsGUIWindow.IsMerged(erSourceURI) Then
				'	Me.errorMessageDictionary.TryGetValue("File merge", helpMessage)
				'	Me.codingBuddyFunctionToExecute = "ChooseMerge"
				'Else
				'	Me.errorMessageDictionary.TryGetValue("Name cannot begin with the '<' character", helpMessage)
				'End If
			Else
				For i As Integer = 0 To errorMessageDictionary.Count - 1
					If errorMessage.Contains(errorMessageDictionary.Keys(i)) Then
						helpMessage = errorMessageDictionary.Values(i)
						Exit For
					End If
				Next
			End If
			If Not (helpMessage = "" Or textPrintDelay.Enabled = True) Then
				Select Case Me.codingBuddyID
					Case 1
						helpMessage = helpMessage.Replace("I ", "Mumbo ")
					Case 5
						helpMessage = helpMessage.Replace("s", "sss").Replace("I ", "Klungo ")
				End Select
				helpMessage = helpMessage.Replace("<FileName>", erFile).Replace("<Folder>", erFolder).Replace("<SourceURI>", erSourceURI)
				If errorCulprit.Count > 1 Then
					helpMessage = helpMessage.Replace("<Template>", errorCulprit(1))
				End If
				If Not helpMessage = lastErrorMessage Then
					printText(helpMessage)
				End If
			ElseIf textPrintDelay.Enabled = False And codingBuddyReadAll Then
				If (Not errorMessage = lastErrorMessage) And errorMessage.Length > 0 Then
					printText(errorMessage)
				End If
			End If
		End If
	End Sub

	Private Sub codingTextPrintDelay_Tick(sender As Object, e As EventArgs) Handles textPrintDelay.Tick
		If speechOutput.Text.Length = str_.Length Then
			textPrintDelay.Enabled = False
			If codingBuddyFunctionToExecute.Length > 1 Then
				speechCompleteIndicator.Visible = False
				codingBuddyInputPanel.Visible = True
				Me.Width = 800
			Else
				speechCompleteIndicator.Visible = True
				Me.Width = 750
			End If
			Me.talkingHeadBox.Image = codingBuddyBlinking
			Exit Sub
		End If
		speechOutput.Text = str_.Substring(0, count_)
		count_ = count_ + 1
	End Sub

	Private Sub DisplayTextImmediate()
		speechOutput.Text = str_
		Me.textPrintDelay.Enabled = False
		Me.talkingHeadBox.Image = codingBuddyBlinking
		If codingBuddyFunctionToExecute.Length > 1 Then
			speechCompleteIndicator.Visible = False
			codingBuddyInputPanel.Visible = True
		Else
			speechCompleteIndicator.Visible = True
		End If
	End Sub

	Private Sub codingBuddySpeakLoop()
		If Not (codingBuddyID = 6 Or codingBuddyID = 7 Or codingBuddyID = 8 Or codingBuddyID = 9 Or codingBuddyID = 11) Then
			Dim randomGrunt As Integer = 0
			Do While textPrintDelay.Enabled = True
				Dim sPlayer As New System.Media.SoundPlayer
				Dim rnd = New Random()
				rnd.Next(0, codingBuddySFX.Count)
				randomGrunt = rnd.Next(0, codingBuddySFX.Count)
				Try
					sPlayer.Stream = codingBuddySFX(randomGrunt)
					sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
					sPlayer.PlaySync()
				Catch ex As Exception
					MsgBox(ex.ToString)
				End Try
				System.Threading.Thread.Sleep(70)
				randomGrunt = Nothing
				If sPlayer IsNot Nothing Then sPlayer = Nothing
			Loop
		Else
			Dim sPlayer As New System.Media.SoundPlayer
			Try
				sPlayer.Stream = codingBuddySFX(0)
				sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
				sPlayer.Play()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
			If sPlayer IsNot Nothing Then sPlayer = Nothing
		End If
	End Sub

	Public Sub printText(dialogue As String)
		Dim codingBuddySpeak As New System.Threading.Thread(AddressOf codingBuddySpeakLoop)
		Me.str_ = dialogue
		Me.count_ = 1
		Me.speechOutput.Text = ""
		Me.Visible = True
		If codingBuddyID = 9 Then
			DisplayTextImmediate()
		Else
			Me.textPrintDelay.Enabled = True
		End If
		Me.talkingHeadBox.Image = codingBuddySpeaking
		codingBuddySpeak.Start()
	End Sub

	Private Sub speechCompleteIndicator_Click(sender As Object, e As EventArgs) Handles speechCompleteIndicator.Click
		If Me.Index = 8 Then
			Dim sPlayer As New System.Media.SoundPlayer
			Try
				sPlayer.Stream = My.Resources.OOT_Dialogue_Done_Mono
				sPlayer.Stream.Seek(0, IO.SeekOrigin.Begin)
				sPlayer.Play()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
			If sPlayer IsNot Nothing Then sPlayer = Nothing
		End If
		speechCompleteIndicator.Visible = False
		Me.Visible = False
		speechOutput.Text = ""
	End Sub

	Public Sub buddyIntroSpeech()
		Select Case codingBuddyID
			Case 1
				printText("Mumbo powerful shaman. If Mumbo has any ideas about an error, Mumbo will help.")
			Case 2
				printText("Hello. I'm Bottles. If I spot any problems I know how to fix, I'll pop up. ")
			Case 3
				printText("I'm Kazooie. If you do anything dumb, I'll be sure to laugh at you.")
			Case 4
				printText("I'm Sgt. JamJars. If you run into trouble in your code, I'll show you how it's done.")
			Case 5
				printText("I Klungo. If I sssee a problem, I will do what I can to help you resssolve it.")
			Case 6
				printText("I'm Banjo. If you bump into an error I'm familiar with, I'll lend a hand.")
			Case 7
				printText("I'm Peppy. I'm here to impart folksy wisdom and press Z or R twice. Do a barrel roll!!")
		End Select
	End Sub

	Private Sub mumboYes_Click(sender As Object, e As EventArgs) Handles mumboYes.Click
		Me.Width = 750
		codingBuddyInputPanel.Visible = False
		If Not codingBuddyFunctionToExecute = "" Then
			CallByName(wsGUIWindow, codingBuddyFunctionToExecute, CallType.Method)
			Threading.Thread.Sleep(250)
		End If
		codingBuddyFunctionToExecute = ""
		speechOutput.Text = ""
		speechCompleteIndicator.Visible = False
		Me.Visible = False
		wsGUIWindow.loadWorksheet(wsGUIWindow.targetXSL)
	End Sub

	Private Sub mumboNo_Click(sender As Object, e As EventArgs) Handles mumboNo.Click
		Me.Width = 750
		codingBuddyInputPanel.Visible = False
		speechCompleteIndicator.Visible = False
		Me.Visible = False
		speechOutput.Text = ""
	End Sub

	Public Sub Clear()
		Me.Width = 750
		Me.textPrintDelay.Enabled = False
		Me.codingBuddyInputPanel.Visible = False
		Me.speechCompleteIndicator.Visible = False
		Me.Visible = False
		Me.codingBuddyFunctionToExecute = ""
		Me.speechOutput.Text = ""
	End Sub
End Class
