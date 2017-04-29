using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Models;

namespace WebExample.DataAccess.Services.Post
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetPosts();

        Task<PostModel> GetPostById(int id);

        Task<PostModel> InsertPost(PostModel post);
        PostModel UpdatePost(PostModel post);

        bool DeletePost(int Id);
    }
}
