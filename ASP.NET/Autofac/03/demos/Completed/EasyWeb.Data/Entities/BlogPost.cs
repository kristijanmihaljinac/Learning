using EasyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EasyBlog.Support.Entities
{
    [DataContract]
    public class BlogPost : IIdentifiableEntity
    {
        [DataMember]
        public int BlogPostId { get; set; }
        [DataMember]
        public string PostSubject { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
        [DataMember]
        public string PostBody { get; set; }
        [DataMember]
        public ICollection<BlogComment> Comments { get; set; }

        public int EntityId
        {
            get { return BlogPostId; }
            set { BlogPostId = value; }
        }
    }
}
