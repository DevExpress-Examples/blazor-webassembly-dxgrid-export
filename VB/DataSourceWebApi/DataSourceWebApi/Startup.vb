Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports DataSourceWebApi.Models
Imports DataSourceWebApi.Services
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.HttpsPolicy
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging

Namespace DataSourceWebApi
	Public Class Startup
		Public Sub New(ByVal configuration As IConfiguration)
			Me.Configuration = configuration
		End Sub

		Public ReadOnly Property Configuration() As IConfiguration

		' This method gets called by the runtime. Use this method to add services to the container.
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			services.AddCors(Sub(options)
				options.AddPolicy("AllowAll", Sub(builder)
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
				End Sub)
			End Sub)
			services.AddControllers()
			services.AddDbContext(Of NWINDContext)()
			services.AddSingleton(Of ExportHelper)()
		End Sub

		' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
			If env.IsDevelopment() Then
				app.UseDeveloperExceptionPage()
			End If

			app.UseHttpsRedirection()

			app.UseRouting()
			app.UseCors("AllowAll")

			app.UseAuthorization()

			app.UseEndpoints(Sub(endpoints)
				endpoints.MapControllers()
			End Sub)
		End Sub
	End Class
End Namespace
