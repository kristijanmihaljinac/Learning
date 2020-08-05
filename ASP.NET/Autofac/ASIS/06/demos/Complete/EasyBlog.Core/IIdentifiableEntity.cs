using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBlog.Core
{
    public interface IIdentifiableEntity
    {
        int EntityId { get; set; }
    }
}
