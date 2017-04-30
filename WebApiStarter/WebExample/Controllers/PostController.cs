using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Services.Post;

namespace WebExample.Controllers
{
    [RoutePrefix("api/Posts")]
    public class PostController : ApiController
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;

        private readonly IPostService _service;

        public PostController(IPostService service,
            ILog log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PostModel>> GetPosts()
        {
            _log.Debug("Get Posts");

            return await _service.GetPosts();
        }

        [HttpGet]
        [Route("Id")]
        public async Task<PostModel> GetPostById(int id)
        {
            _log.Debug("Get Post By Id");

            return await _service.GetPostById(id);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<PostModel> InsertPost(PostModel post)
        {
            _log.Debug("Insert Post");

            return await _service.InsertPost(post);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<PostModel> UpdatePost(PostModel post)
        {
            _log.Debug("Update Post");

            return await _service.UpdatePost(post);
        }

        [HttpDelete]
        public async Task<bool> DeletePost(PostModel post)
        {
            _log.Debug("Update Post");

            return await _service.DeletePost(post.Id);
        }
    }
}