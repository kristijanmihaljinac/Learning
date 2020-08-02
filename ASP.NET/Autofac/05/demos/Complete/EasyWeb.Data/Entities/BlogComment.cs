using EasyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EasyBlog.Support.Entities
{
    [DataContract]
    public class BlogComment : IIdentifiableEntity
    {
        [DataMember]
        public int BlogCommentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
        [DataMember]
        public string CommentBody { get; set; }
        [DataMember]
        public int BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public int EntityId
        {
            get { return BlogCommentId; }
            set { BlogCommentId = value; }
        }
    }
}
