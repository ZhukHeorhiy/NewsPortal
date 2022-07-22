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

        public Comment(string commentContent)
        {
            CommentCheck(commentContent);
            CommentContent = commentContent;
        }

        private void CommentCheck(string comment)
        {
            if (comment == null) throw new ApplicationException("empty comment");
            if (comment.Contains("fuck")) throw new ApplicationException("bad words in comment");
            if (comment.Length < 1 || comment.Length > 100) throw new ApplicationException("bad comment size");
        }

    }
}
