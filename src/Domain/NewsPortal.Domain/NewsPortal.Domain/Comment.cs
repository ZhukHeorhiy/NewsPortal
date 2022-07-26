using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain
{
    public class Comment
    {
        public string CommentContent { get; }
        
        public int CommentId { get; }

        public int CommentLikes { get; }

        public Comment(string commentContent, int commentLikes, int commentId)
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
