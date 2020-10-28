Imports System
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata

Namespace DataSourceWebApi.Models
	Partial Public Class NWINDContext
		Inherits DbContext

		Public Sub New()
		End Sub

		Public Sub New(ByVal options As DbContextOptions(Of NWINDContext))
			MyBase.New(options)
		End Sub

		Public Overridable Property Products() As DbSet(Of Products)

		Protected Overrides Sub OnConfiguring(ByVal optionsBuilder As DbContextOptionsBuilder)
			If Not optionsBuilder.IsConfigured Then
				optionsBuilder.UseSqlServer("Server=(local);Database=NWIND;User ID=XXX;Password=XXX;")
			End If
		End Sub

		Protected Overrides Sub OnModelCreating(ByVal modelBuilder As ModelBuilder)
			modelBuilder.Entity(Of Products)(Sub(entity)
				entity.HasKey(Function(e) e.ProductId)
				entity.Property(Function(e) e.ProductId).HasColumnName("ProductID")
				entity.Property(Function(e) e.CategoryId).HasColumnName("CategoryID")
				entity.Property(Function(e) e.Ean13).HasColumnName("EAN13").HasColumnType("text")
				entity.Property(Function(e) e.ProductName).IsRequired().HasMaxLength(40)
				entity.Property(Function(e) e.QuantityPerUnit).HasMaxLength(20)
				entity.Property(Function(e) e.SupplierId).HasColumnName("SupplierID")
				entity.Property(Function(e) e.UnitPrice).HasColumnType("smallmoney")
			End Sub)

			OnModelCreatingPartial(modelBuilder)
		End Sub

		Partial Private Sub OnModelCreatingPartial(ByVal modelBuilder As ModelBuilder)
		End Sub
	End Class
End Namespace
