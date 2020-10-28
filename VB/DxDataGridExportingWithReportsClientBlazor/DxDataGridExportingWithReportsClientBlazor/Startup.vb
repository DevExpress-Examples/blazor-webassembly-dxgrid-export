Imports Microsoft.AspNetCore.Components.Builder
Imports Microsoft.Extensions.DependencyInjection

Namespace DxDataGridExportingWithReportsClientBlazor
	Public Class Startup
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			services.AddDevExpressBlazor()
		End Sub

		Public Sub Configure(ByVal app As IComponentsApplicationBuilder)
			app.AddComponent(Of App)("app")
		End Sub
	End Class
End Namespace
