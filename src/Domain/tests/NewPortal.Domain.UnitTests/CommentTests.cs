//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NewsPortal.Domain;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NewPortal.Domain.UnitTests
//{
//    [TestClass]
//    public class CommentTests
//    {
//        [TestMethod]
//        public void CommentNotRepeat()
//        {
//            News news = new News(Guid.Empty, "", "title", "", "https://url.com", "", DateTime.Now, "Content");
//            Comment comment = new Comment(commentContent: "Hello World!", 43, Guid.Empty);
//            //-1 like checks 
//            news.AddComment(comment);
//            news.AddComment(comment);
//            Assert.IsTrue(news.Comments.Count == 1);


//        }
//        [TestMethod]
//        [ExpectedException(typeof(ApplicationException), "bad comment size")]
//        public void CommentNotRightSize()
//        {
//            News news = new News(Guid.Empty, "", "title", "", "https://url.com", "", DateTime.Now, "Content");
//            Comment comment = new Comment("", 0, Guid.Empty);

//        }
//    }
//}
