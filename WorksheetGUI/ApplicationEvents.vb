Namespace My
	' The following events are available for MyApplication:
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication
		Private Sub AppStart(ByVal sender As Object,
  ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
			AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies
			System.Reflection.Assembly.Load(My.Resources.HtmlAgilityPack)
		End Sub

		Private Function ResolveAssemblies(sender As Object, e As System.ResolveEventArgs) As Reflection.Assembly
			Dim desiredAssembly = New Reflection.AssemblyName(e.Name)
			'MsgBox(desiredAssembly.Name)
			'MsgBox(desiredAssembly.FullName)

			'			If desiredAssembly.Name = "WorksheetPreviewer.resources" Then
			'				Return Reflection.Assembly.Load(My.Resources.HtmlAgilityPack) 'replace with your assembly's resource name
			'				MsgBox("Did the thing" & vbCrLf & desiredAssembly.Name.ToString)
			If desiredAssembly.Name = "HtmlAgilityPack" Then
				Return Reflection.Assembly.Load(My.Resources.HtmlAgilityPack)
			ElseIf desiredAssembly.Name = "HtmlAgilityPack.dll" Then
				Return Reflection.Assembly.Load(My.Resources.HtmlAgilityPack)
			ElseIf desiredAssembly.Name = "HtmlAgilityPack, Version=1.4.6.0, Culture=neutral, PublicKeyToken=bd319b19eaf3b43a" Then
				Return Reflection.Assembly.Load(My.Resources.HtmlAgilityPack)
			ElseIf desiredAssembly.Name = "Tesseract" Then
				Return Reflection.Assembly.Load(My.Resources.Tesseract)
			ElseIf desiredAssembly.Name = "Tesseract.dll" Then
				Return Reflection.Assembly.Load(My.Resources.Tesseract)
			Else
				Return Nothing
			End If
		End Function
	End Class
End Namespace

