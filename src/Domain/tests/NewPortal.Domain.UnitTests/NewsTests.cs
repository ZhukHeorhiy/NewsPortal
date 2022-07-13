using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Domain;
using System;
using System.Collections.Generic;

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
        public void NewsIsToday()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            //News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-4), "");
            News news = new("", title, "", "https://url.com", "", DateTime.Now, "");

            bool isToday = news.IsToday();

            Assert.IsTrue(isToday);
        }
        [TestMethod]
        public void NewsIsThisWeek()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-6), "");

            bool isThisWeek = news.IsThisWeek();

            Assert.IsTrue(isThisWeek);
        }
        [TestMethod]
        public void NewsIsThisMonth()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-28), "");

            bool isThisMonth = news.IsThisMonth();

            Assert.IsTrue(isThisMonth);
        }
        //question about repeating in test methods
        [TestMethod]
        public void NewsIsRightCountry()
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war Germany";
            News news = new("", title, "", "https://url.com", "", DateTime.Now.AddDays(-28), "Soldiers from Ukraine were trained in Czech for war Germany and USA");

            List<Countrie> isWhatCountry = news.WhatCountry();

            Assert.IsTrue(isWhatCountry.Contains(Countrie.UKR));
            Assert.IsTrue(isWhatCountry.Contains(Countrie.GER));
            Assert.IsTrue(isWhatCountry.Contains(Countrie.CZH));
            Assert.IsTrue(isWhatCountry.Contains(Countrie.USA));
            Assert.IsTrue(isWhatCountry.Count == 4);
        }

    }
}