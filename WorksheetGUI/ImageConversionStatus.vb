Public Class ImageConversionStatus
	Private Converter As WorksheetConverter
	Public ImageToConvert As Bitmap = Nothing
	Public Output As String = ""
	Public Property ConversionComplete As Boolean = False
	Dim ConversionProcess As Threading.Thread
	Dim Rando As New Random()
	Dim isRando As Boolean = False
	Dim edges As BitmapConverter
	Dim StatusMessages As New List(Of String)({"Feeding llamas..." _
											  , "Generating more worksheet code..." _
											  , "Getting Schwifty..." _
											  , "Finding Carmen Sandiego..." _
											  , "Taking coffee break..." _
											  , "Offering sacrifice to the worksheet gods..." _
											  , "Becoming king of the pirates..." _
											  , "Consulting the sages..." _
											  , "Appealing to the Jedi Council..." _
											  , "Eating pie..." _
											  , "Using the force..." _
											  , "Generating theoretical singularity..." _
											  , "Calculating meaning of life..." _
											  , "Getting hooked on a feeling..." _
											  , "Going off the rails on a crazy train..." _
											  , "Drinking and knowing things..." _
											  , "Bio-engineering a superior race of octopi..." _
											  , "Stayin' alive..." _
											  , "Calculating code offset based on moon-phase..." _
											  , "Converting to hyroglyphics..." _
											  , "Estoy haciendo cosas..." _
											  , "Hunting mavericks..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..." _
											  , "Still generating worksheet code..."})
	Private Sub ImageConversionStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If ImageToConvert Is Nothing Then
			MsgBox("No Image selected to convert.")
			Me.Close()
		ElseIf ImageToConvert.Height < 100 Or ImageToConvert.Width < 100 Then
			MsgBox("The provided image is too small. Please provide a larger image")
			Me.Close()
		End If

		ConversionProcess = New Threading.Thread(AddressOf KickOff)
		ConversionProcess.IsBackground = True
		ConversionProcess.Start()
		StatusTimer.Enabled = True
		StatusTimer.Start()
	End Sub

	Public Sub WorksheetComplete()
		'Dim ShellFile As New Worksheet.ShellFile
		'Dim BodyFile As New Worksheet.BodyFile
		'Me.CurrentStatus.Text = "Creating Worksheet files..."
		Using sw As IO.StreamWriter = IO.File.CreateText("C:\Users\SMaxson\Desktop\Worksheets\Science\TesseractTest_ConverterOutput.html")
			sw.Write(Output)
		End Using
		'Me.CurrentStatus.Text = "Complete!!"
		Me.ConversionComplete = True
		Me.isRando = False
		Me.edges.Clear()
	End Sub

	Private Sub KickOff()
		edges = New BitmapConverter()
		Output = edges.Start(ImageToConvert)
		WorksheetComplete()
	End Sub

	Private Shadows Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
		Me.CurrentStatus.Text = "Canceled..."
		ConversionProcess.Abort()
		Me.isRando = False
		Me.edges = Nothing
		Me.Close()
	End Sub

	Private Sub StatusTimer_Tick(sender As Object, e As EventArgs) Handles StatusTimer.Tick
		If Me.ConversionComplete Then
			Me.edges.Clear()
			Me.Close()
		ElseIf IsNothing(Me.edges) Then
			StatusTimer.Enabled = False
			StatusTimer.Stop()
			Exit Sub
		ElseIf Me.isRando Then
			Me.CurrentStatus.Text = Me.StatusMessages(Rando.Next(0, StatusMessages.Count - 1))
		ElseIf Me.CurrentStatus.Text = "Generating Worksheet source code..." Then
			Me.isRando = True
		Else
			Me.CurrentStatus.Text = edges.DearDiary
		End If
		If Not IsNothing(edges.CurrentCell) Then Me.CurrentCell.Text = edges.CurrentCell
		If Not IsNothing(edges.CurrentStep) Then Me.ImageDisplayLeft.BackgroundImage = edges.CurrentStep
	End Sub

End Class