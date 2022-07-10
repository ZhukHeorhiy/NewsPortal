using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Domain;
using System;

namespace NewPortal.Domain.UnitTests
{
    [TestClass]
    public class NewsTests
    {
        [TestMethod]
        public void NewsAboutWarInCzechNewsIsImportant()
        {
            // Data preparation
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            News news = new("", title, "", "https://url.com", "", DateTime.Now, "");

            // Action
            bool isImportant = news.IsImportant();
            

            // Assert
            Assert.IsTrue(isImportant);
            
        }
        [TestMethod]
        public void NewsToday()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            //News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-4), "");
            News news = new("", title, "", "https://url.com", "", DateTime.Now, "");

            bool isToday = news.IsToday();

            Assert.IsTrue(isToday);
        }
        [TestMethod]
        public void NewsThisWeek()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-6), "");

            bool isThisWeek = news.IsThisWeek();

            Assert.IsTrue(isThisWeek);
        }
        [TestMethod]
        public void NewsThisMonth()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-28), "");

            bool isThisMonth = news.IsThisMonth();

            Assert.IsTrue(isThisMonth);
        }
        //question about repeating in test methods

    }
}