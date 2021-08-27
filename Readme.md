<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/236017943/20.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T854758)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
*Files to look at*:

* [Index.razor](./CS/DxDataGridExportingWithReportsClientBlazor/DxDataGridExportingWithReportsClientBlazor/Pages/Index.razor)
* [ExportButtons.razor](./CS/DxDataGridExportingWithReportsClientBlazor/DxDataGridExportingWithReportsClientBlazor/Components/ExportButtons.razor)
* [ProductsController.cs](./CS/DataSourceWebApi/DataSourceWebApi/Controllers/ProductsController.cs)
* [ExportHelper.cs](./CS/DataSourceWebApi/DataSourceWebApi/Services/ExportHelper.cs)
* [NWINDContext.cs](./CS/DataSourceWebApi/DataSourceWebApi/Models/NWINDContext.cs)
* [Products.cs](./CS/DataSourceWebApi/DataSourceWebApi/Models/Products.cs)

### DataGrid for Blazor - WebAssembly application - How to implement the exporting functionality using DevExpress Reporting tools 

This example illustrates how to use DevExpress Reporting tools to export DxDataGrid content to different formats (*.pdf*/*.xlsx*/*.docx*) in the Blazor WebAssembly application.

In this example, DataGrid is [bound to the external Web API service](./CS/DxDataGridExportingWithReportsClientBlazor/DxDataGridExportingWithReportsClientBlazor/Pages/Index.razor#L26) using the [CustomData](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxDataGrid-1.CustomData) property. This Web API service’s source code is located in [this folder](./CS/DataSourceWebApi/DataSourceWebApi). The database is "Northwind", and its script generation file can be found in [this folder](./CS/DataSourceWebApi/DataSourceWebApi/DBBackup). Generate this data on your SQL server and change the connection string in [this file](./CS/DataSourceWebApi/DataSourceWebApi/Models/NWINDContext.cs) correspondingly (see the OnConfiguring method).

The export buttons are located within the [ExportButtons](./CS/DxDataGridExportingWithReportsClientBlazor/DxDataGridExportingWithReportsClientBlazor/Components/ExportButtons.razor) components. Each of them contains a URI to a specific [ExportedDocument](./CS/DataSourceWebApi/DataSourceWebApi/Controllers/ProductsController.cs#L34) controller method in the mentioned Web API service. This URI contains DataGrid's options, so the created report will only contain data, which is displayed in the grid after sorting and filtering are applied.

The [ReportHelper.CreateReport](./CS/DataSourceWebApi/DataSourceWebApi/Services/ExportHelper.cs#L35) method is used to create a report that is exported to the file of the corresponding type using the [ExportToPdf(String)](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XtraReport.ExportToPdf(System.String))/[ExportToXlsx(Stream)](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XtraReport.ExportToXlsx(System.IO.Stream))/[ExportToDocx(Stream)](https://docs.devexpress.com/XtraReports/DevExpress.XtraReports.UI.XtraReport.ExportToDocx(System.IO.Stream)) method.

See also:

[DataGrid for Blazor - Server side - How to implement the exporting functionality using DevExpress Reporting tools](https://supportcenter.devexpress.com/ticket/details/t854755/datagrid-for-blazor-server-side-how-to-implement-the-exporting-functionality-using)

[How to use DevExpress Reporting Components in Blazor applications](https://supportcenter.devexpress.com/ticket/details/t834711/how-to-use-devexpress-reporting-components-in-blazor-applications)

