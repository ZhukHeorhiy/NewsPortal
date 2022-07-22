using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPortal.Domain.UnitTests
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void CommentNotRepeat()
        {
            News news = new News("", "title", "", "https://url.com", "", DateTime.Now, "Content");
            Comment comment = new Comment(commentContent: "Hello World!");
            news.AddComment(comment);
            int count = 0;
            foreach(Comment i in news.Comments)
            {
                if(i.CommentContent == "Hello World!")
                {
                    count++;
                }
            }
            Assert.IsTrue(count < 2);

        }
        [TestMethod]
        public void CommentRightSize()
        {
            News news = new News("", "title", "", "https://url.com", "", DateTime.Now, "Content");
            Comment comment = new Comment("Hello World!");
            news.AddComment(comment);
            Console.WriteLine(comment.CommentContent.Length);
            Assert.IsFalse(comment.CommentContent.Length < 1 || comment.CommentContent.Length > 100);
         

        }
    }
}
