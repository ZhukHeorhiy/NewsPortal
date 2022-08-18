using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain
{
    public class Comments
    {
        public string CommentContent { get; private set; }
        
        public Guid CommentId { get; private set; }

        public int CommentLikes { get; private set; }
        
        public News News { get; set; }
        protected Comments()
        {

        }

        public Comments(string commentContent, int commentLikes, Guid commentId)
        {
            CommentCheck(commentContent, commentLikes);
            CommentContent = commentContent;
            CommentLikes = commentLikes;
            CommentId = commentId;
        }

        private void CommentCheck(string comment, int likes)
        {
            if (comment == null) throw new ApplicationException("empty comment");
            if (comment.Contains("fuck")) throw new ApplicationException("bad words in comment");
            if (comment.Length < 1 || comment.Length > 100) throw new ApplicationException("bad comment size");
            if (likes < 0) throw new ApplicationException("less then 0 likes");
        }

    }
}
