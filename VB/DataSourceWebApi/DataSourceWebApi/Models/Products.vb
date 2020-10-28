Imports System
Imports System.Collections.Generic

Namespace DataSourceWebApi.Models
	Partial Public Class Products
		Public Property ProductId() As Integer
		Public Property ProductName() As String
		Public Property SupplierId() As Integer?
		Public Property CategoryId() As Integer?
		Public Property QuantityPerUnit() As String
		Public Property UnitPrice() As Decimal?
		Public Property UnitsInStock() As Short?
		Public Property UnitsOnOrder() As Short?
		Public Property ReorderLevel() As Short?
		Public Property Discontinued() As Boolean
		Public Property Ean13() As String
	End Class
End Namespace
