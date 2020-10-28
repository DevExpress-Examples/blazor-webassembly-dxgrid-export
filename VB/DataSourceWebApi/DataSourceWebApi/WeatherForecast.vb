Imports System

Namespace DataSourceWebApi
	Public Class WeatherForecast
		Public Property [Date]() As DateTime

		Public Property TemperatureC() As Integer

		Public ReadOnly Property TemperatureF() As Integer
			Get
				Return 32 + CInt(Math.Truncate(TemperatureC / 0.5556))
			End Get
		End Property

		Public Property Summary() As String
	End Class
End Namespace
