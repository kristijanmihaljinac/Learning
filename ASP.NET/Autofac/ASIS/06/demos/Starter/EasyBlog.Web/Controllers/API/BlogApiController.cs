using EasyBlog.Common;
using EasyBlog.Data;
using EasyBlog.Support.Entities;
using EasyBlog.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EasyBlog.Web.Controllers.API
{
    [RoutePrefix("api/blog")]
    public class BlogApiController : ApiController
    {
        public BlogApiController(IComponentLocator componentLocator,
                                 IExtensibilityManager extensibilityManager)
        {
            _ComponentLocator = componentLocator;
            _ExtensibilityManager = extensibilityManager;
            _ModuleEvents = _ExtensibilityManager.ModuleEvents;
        }

        IComponentLocator _ComponentLocator;
        IExtensibilityManager _ExtensibilityManager;
        ModuleEvents _ModuleEvents;
        
        [HttpGet]
        [Route("posts")]
        public HttpResponseMessage FetchPosts(HttpRequestMessage request)
        {
            // this call is not used in the site since it's happening from the view-controller
            
            HttpResponseMessage response = null;

            try
            {
                IBlogPostRepository blogPostRepository = _ComponentLocator.ResolveComponent<IBlogPostRepository>();

                IEnumerable<BlogPost> blogPosts = blogPostRepository.Get();

                response = request.CreateResponse<BlogPost[]>(HttpStatusCode.OK, blogPosts.ToArray());
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        [HttpGet]
        [Route("post/{blogPostId}")]
        public HttpResponseMessage FetchPost(HttpRequestMessage request, int blogPostId)
        {
            HttpResponseMessage response = null;

            try
            {
                IBlogPostRepository blogPostRepository = _ComponentLocator.ResolveComponent<IBlogPostRepository>();

                BlogPost blogPost = blogPostRepository.GetComplete(blogPostId);

                response = request.CreateResponse<BlogPost>(HttpStatusCode.OK, blogPost);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        [HttpPost]
        [Route("post/add")]
        public HttpResponseMessage SubmitPost(HttpRequestMessage request, [FromBody]BlogPost blogPost)
        {
            HttpResponseMessage response = null;

            try
            {
                blogPost.Timestamp = DateTime.Now;

                PreSubmissionPostingEventArgs preArgs = new PreSubmissionPostingEventArgs(blogPost);

                _ExtensibilityManager.InvokeCancelableModuleEvent<PreSubmissionPostingEventArgs>(
                    _ModuleEvents.PreSubmissionPosting, preArgs);
                
                if (!preArgs.Cancel)
                {
                    IBlogPostRepository blogPostRepository = _ComponentLocator.ResolveComponent<IBlogPostRepository>();

                    blogPost = blogPostRepository.Add(blogPost);

                    PostSubmissionPostingEventArgs postArgs = new PostSubmissionPostingEventArgs(blogPost);
                    
                    _ExtensibilityManager.InvokeModuleEvent<PostSubmissionPostingEventArgs>(
                        _ModuleEvents.PostSubmissionPosting, postArgs);
                    
                    response = request.CreateResponse<BlogPost>(HttpStatusCode.OK, blogPost);
                }
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            
            return response;
        }

        [HttpPost]
        [Route("comment/add")]
        public HttpResponseMessage SubmitComment(HttpRequestMessage request, [FromBody]BlogComment blogComment)
        {
            HttpResponseMessage response = null;

            try
            {
                blogComment.Timestamp = DateTime.Now;

                PreSubmissionCommentEventArgs preArgs = new PreSubmissionCommentEventArgs(blogComment);

                _ExtensibilityManager.InvokeCancelableModuleEvent<PreSubmissionCommentEventArgs>(
                    _ModuleEvents.PreSubmissionComment, preArgs);

                if (!preArgs.Cancel)
                {
                    IBlogCommentRepository blogCommentRepository = _ComponentLocator.ResolveComponent<IBlogCommentRepository>();

                    blogComment.CommentBody = preArgs.CommentReplacement;
                    blogComment = blogCommentRepository.Add(blogComment);

                    PostSubmissionCommentEventArgs postArgs = new PostSubmissionCommentEventArgs(blogComment);

                    _ExtensibilityManager.InvokeModuleEvent<PostSubmissionCommentEventArgs>(
                        _ModuleEvents.PostSubmissionComment, postArgs);

                    response = request.CreateResponse<BlogComment>(HttpStatusCode.OK, blogComment);
                }
                else
                    throw new ApplicationException("Comment submission has been blocked.");
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }
    }
}
