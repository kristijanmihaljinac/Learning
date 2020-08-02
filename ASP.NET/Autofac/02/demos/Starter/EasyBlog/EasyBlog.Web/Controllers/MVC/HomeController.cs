using EasyBlog.Data;
using EasyBlog.Support.Entities;
using EasyBlog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EasyBlog.Web.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        [Route("index")]
        [Route("~/")]
        public ActionResult Index()
        {
            IBlogPostRepository blogPostRepository = new BlogPostRepository("easyBlog");

            IEnumerable<BlogPost> blogPosts = blogPostRepository.Get();

            return View(blogPosts);
        }

        [Route("admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Route("post/{blogPostId}")]
        public ActionResult Post(int blogPostId)
        {
            return View("Post", new BlogPostModel() { BlogPostId = blogPostId });
        }
    }
}