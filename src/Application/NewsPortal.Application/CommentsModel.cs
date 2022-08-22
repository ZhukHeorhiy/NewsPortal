using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Application
{
    public class CommentsModel
    {

        public string Content { get; set; }
        public int Likes { get; set; }
        public Guid CommentId { get; set; }

    }

}
