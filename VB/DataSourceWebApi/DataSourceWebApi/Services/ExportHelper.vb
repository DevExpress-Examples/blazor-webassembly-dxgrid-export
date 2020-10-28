Imports System
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.XtraReports.UI
Imports DevExtreme.AspNet.Data.ResponseModel
Imports System.Drawing
Imports DataSourceWebApi.Models
Imports System.IO

Namespace DataSourceWebApi.Services
	Public Class ExportHelper
		Private ReadOnly pdf As String = "pdf"
		Private ReadOnly xlsx As String = "xlsx"
		Private ReadOnly docx As String = "docx"
		Public Async Function ExportResult(ByVal lr As LoadResult, ByVal format As String) As Task(Of Byte())
			Dim report As New XtraReport()
			Dim loadedData = lr
			report.DataSource = loadedData.data.Cast(Of Products)()
			CreateReport(report, New String() { "ProductName", "CategoryId", "UnitPrice", "UnitsInStock", "UnitsOnOrder", "Discontinued" })
			Return Await (New TaskFactory()).StartNew(Function()
				report.CreateDocument()
				Using fs As New MemoryStream()
					If format = pdf Then
						report.ExportToPdf(fs)
					ElseIf format = xlsx Then
						report.ExportToXlsx(fs)
					ElseIf format = docx Then
						report.ExportToDocx(fs)
					End If
					Return fs.ToArray()
				End Using
			End Function)
		End Function
		Private Sub CreateReport(ByVal report As XtraReport, ByVal fields() As String)
			Dim pageHeader As New PageHeaderBand() With {
				.HeightF = 23,
				.Name = "pageHeaderBand"
			}
			Dim tableWidth As Integer = report.PageWidth - report.Margins.Left - report.Margins.Right
			Dim headerTable As XRTable = XRTable.CreateTable(New Rectangle(0, 0, tableWidth, 40), 1, 0) ' table column count
			headerTable.Borders = DevExpress.XtraPrinting.BorderSide.All
			headerTable.BackColor = Color.Gainsboro
			headerTable.Font = New Font("Verdana", 10, FontStyle.Bold)
			headerTable.Rows.FirstRow.Width = tableWidth
			headerTable.BeginInit()
			For Each field As String In fields
				Dim cell As New XRTableCell()
				cell.Width = 100
				cell.Text = field
				cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
				headerTable.Rows.FirstRow.Cells.Add(cell)
			Next field
			headerTable.EndInit()
			headerTable.AdjustSize()
			pageHeader.Controls.Add(headerTable)



			Dim detail As New DetailBand() With {
				.HeightF = 23,
				.Name = "detailBand"
			}
			Dim detailTable As XRTable = XRTable.CreateTable(New Rectangle(0, 0, tableWidth, 40), 1, 0) ' table column count



			detailTable.Width = tableWidth
			detailTable.Rows.FirstRow.Width = tableWidth
			detailTable.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
			detailTable.BeginInit()
			For Each field As String In fields
				Dim cell As New XRTableCell()
				Dim binding As New ExpressionBinding("BeforePrint", "Text", String.Format("[{0}]", field))
				cell.ExpressionBindings.Add(binding)
				cell.Width = 100
				cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
				If field.Contains("Date") Then
					cell.TextFormatString = "{0:MM/dd/yyyy}"
				End If
				detailTable.Rows.FirstRow.Cells.Add(cell)
			Next field
			detailTable.Font = New Font("Verdana", 8F)
			detailTable.EndInit()
			detailTable.AdjustSize()
			detail.Controls.Add(detailTable)
			report.Bands.AddRange(New Band() { detail, pageHeader })
		End Sub
	End Class
End Namespace
