using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.Specs.Common;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Services.Post;

namespace WebExample.Specs.Servicce
{
    [TestClass]
    public class PostServiceSpecs : TestBase
    {
        protected IPostService PostService;
        public PostServiceSpecs()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            PostService = Resolve<IPostService>();
            base.BeforeEachTest();
        }

        [TestCleanup]
        public void TearDown()
        {
            PostService = null;
            base.AfterEachTest();
            ShutdownIoC();
        }


        [TestMethod]
        public void When_retrieving_posts()
        {
            var people = PostService.GetPosts().Result;
            Assert.IsTrue(people.Any());
        }


        [TestMethod]
        public void When_updatinging_posts()
        {
            var title = "Updated";
            var postId = 2;
            var updatedPost = new PostModel { Id = postId,Title = title };
            updatedPost = PostService.UpdatePost(updatedPost).Result;
            Assert.IsNotNull(updatedPost);
            Assert.AreEqual(title, updatedPost.Title);
            Assert.AreEqual(postId, updatedPost.Id);
        }

        [TestMethod]
        public void When_insertinging_posts()
        {
            var title = "Test Insert";
            var insertedPost = new PostModel { Title = title };
            insertedPost = PostService.InsertPost(insertedPost).Result;
            Assert.IsNotNull(insertedPost);
            Assert.IsTrue(insertedPost.Id > 0);
            Assert.AreEqual(title, insertedPost.Title);
        }
    }
}
