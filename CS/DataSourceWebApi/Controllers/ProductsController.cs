using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using System.IO;
using DataSourceWebApi.Models;
using DataSourceWebApi.Services;

namespace DataSourceWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ProductsController : ControllerBase
    {
        private readonly ExportHelper _eh;
        private readonly NWINDContext _context;

        public ProductsController(NWINDContext context, ExportHelper eh) {
            _context = context;
            _eh = eh;
        }

        // GET: api/Products
        [HttpGet]
        public object Products(DataSourceLoadOptions loadOptions) {
            return DataSourceLoader.Load(_context.Products, loadOptions);
        }

        [HttpGet]
        public async Task<ActionResult> ExportedDocument(DataSourceLoadOptions loadOptions, string format) {
            loadOptions.Skip = 0;
            loadOptions.Take = 0;
            byte[] content = await _eh.ExportResult(DataSourceLoader.Load(_context.Products.ToList(), loadOptions), format);
            string fileName = "DataGrid." + format;
            string mimeType = "application/octet-stream";
            return new FileStreamResult(new MemoryStream(content), mimeType) {
                FileDownloadName = fileName
            };           
        }
    }
}
