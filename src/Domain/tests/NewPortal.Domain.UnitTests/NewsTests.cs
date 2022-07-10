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
    }
}