Imports Microsoft.AspNetCore.Blazor.Hosting

Namespace DxDataGridExportingWithReportsClientBlazor
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			CreateHostBuilder(args).Build().Run()
		End Sub

		Public Shared Function CreateHostBuilder(ByVal args() As String) As IWebAssemblyHostBuilder
			Return BlazorWebAssemblyHost.CreateDefaultBuilder().UseBlazorStartup(Of Startup)()
		End Function
	End Class
End Namespace
