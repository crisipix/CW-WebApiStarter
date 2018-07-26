using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Services.File;

namespace WebExample.Controllers
{
    [RoutePrefix("api/File")]
    public class FileController : BaseController
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;
        private readonly IFileService _service;
        public FileController(IFileService service, ILog log)
        {
            _service = service;
            _log = log;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<FileModel> Upload()
        {
            _log.Debug("Upload File");

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync();

            var results = new List<FileModel>();
            foreach (var stream in provider.Contents)
            {
                var fileBytes = await stream.ReadAsByteArrayAsync();

                var file = new FileModel
                {
                    Contents = fileBytes,
                    Size = fileBytes.Length,
                    FileType = Request.Content.Headers.ContentType.MediaType,
                    FileName = Request.Content.Headers.ContentDisposition?.FileName ?? "No File"
                };

                results.Add( await _service.Upload(file));
            }

            //var root = HttpContext.Current.Server.MapPath("C:\\Temp");
            //var provider = new MultipartFormDataStreamProvider(root);

            return results.FirstOrDefault();

        }

     
    }
}