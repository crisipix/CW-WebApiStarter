using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Common;
using WebExample.DataAccess.Models;

namespace WebExample.DataAccess.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IHttpClientProvider _httpProvider;
        public PostService(IHttpClientProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }
      

        public async Task<IEnumerable<PostModel>> GetPosts()
        {
            var client = _httpProvider.ProvideClient("https://jsonplaceholder.typicode.com", false);
            var array = await client.GetJsonAsync("posts");
            var results = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(array);
            return results;
        }

        public async Task<PostModel> GetPostById(int id)
        {
            var client = _httpProvider.ProvideClient("https://jsonplaceholder.typicode.com", false);
            var url = $"posts/{id}";
            var post= await client.GetGenericAsync<PostModel>(url);            
            return post;
        }

        public async Task<PostModel> InsertPost(PostModel post)
        {
            var client = _httpProvider.ProvideClient("https://jsonplaceholder.typicode.com", false);
            var url = $"posts";
            var insertedPost = await client.PostGenericAsync(url, post);
            return insertedPost;
        }

        public async Task<PostModel> UpdatePost(PostModel post)
        {
            var client = _httpProvider.ProvideClient("https://jsonplaceholder.typicode.com", false);
            var url = $"posts/{post.Id}";
            var updatedPost = await client.PutGenericAsync(url, post);
            return updatedPost;
        }

        public async Task<bool> DeletePost(int Id)
        {
            var client = _httpProvider.ProvideClient("https://jsonplaceholder.typicode.com", false);
            var url = $"posts/{Id}";
            var deleted = await client.DeleteJsonAsync(url);
            return deleted;
        }
    }
}
