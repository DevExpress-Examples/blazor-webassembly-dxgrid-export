Imports System
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Cors
Imports DevExtreme.AspNet.Mvc
Imports DevExtreme.AspNet.Data
Imports System.IO
Imports DataSourceWebApi.Models
Imports DataSourceWebApi.Services

Namespace DataSourceWebApi.Controllers
	<Route("api/[controller]/[action]")>
	<ApiController>
	<EnableCors("AllowAll")>
	Public Class ProductsController
		Inherits ControllerBase

		Private ReadOnly _eh As ExportHelper
		Private ReadOnly _context As NWINDContext

		Public Sub New(ByVal context As NWINDContext, ByVal eh As ExportHelper)
			_context = context
			_eh = eh
		End Sub

		' GET: api/Products
		<HttpGet>
		Public Function Products(ByVal loadOptions As DataSourceLoadOptions) As Object
			Return DataSourceLoader.Load(_context.Products, loadOptions)
		End Function

		<HttpGet>
		Public Async Function ExportedDocument(ByVal loadOptions As DataSourceLoadOptions, ByVal format As String) As Task(Of ActionResult)
			loadOptions.Skip = 0
			loadOptions.Take = 0
			Dim content() As Byte = Await _eh.ExportResult(DataSourceLoader.Load(_context.Products.ToList(), loadOptions), format)
			Dim fileName As String = "DataGrid." & format
			Dim mimeType As String = "application/octet-stream"
			Return New FileStreamResult(New MemoryStream(content), mimeType) With {.FileDownloadName = fileName}
		End Function
	End Class
End Namespace
