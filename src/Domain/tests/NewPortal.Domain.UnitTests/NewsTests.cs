using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Domain;
using System;
using System.Collections.Generic;

namespace NewPortal.Domain.UnitTests
{
    [TestClass]
    public class NewsTests
    {
        public News NewsTesterHelper(DateTime time, string content)
        {
            const string title = "Soldiers from Ukraine were trained in Czech for war";
            return new("", title, "", "https://url.com", "", time, content);
        }
        [TestMethod]
        public void NewsAboutWarInCzechNewsIsImportant()
        {
            // Data preparation
            News news = NewsTesterHelper(DateTime.Now, "");

            // Action
            bool isImportant = news.IsImportant();
            

            // Assert
            Assert.IsTrue(isImportant);
            
        }
        [TestMethod]
        public void NewsIsToday()
        {
            News news = NewsTesterHelper(DateTime.Now, "");

            bool isToday = news.IsToday();

            Assert.IsTrue(isToday);
        }
        [TestMethod]
        public void NewsIsThisWeek()
        {
            News news = NewsTesterHelper(DateTime.Now.AddDays(-6), "");

            bool isThisWeek = news.IsThisWeek();

            Assert.IsTrue(isThisWeek);
        }
        [TestMethod]
        public void NewsIsThisMonth()
        {
            News news = NewsTesterHelper(DateTime.Now.AddDays(-28), "");

            bool isThisMonth = news.IsThisMonth();

            Assert.IsTrue(isThisMonth);
        }
        //question about repeating in test methods
        [TestMethod]
        public void NewsIsRightCountry()
        {
            News news = NewsTesterHelper(DateTime.Now.AddDays(-28), "Soldiers from Ukraine were trained in Czech for war Germany and USA");
            
            List<Country> isWhatCountry = news.WhatCountry();

            Assert.IsTrue(isWhatCountry.Contains(Country.UKR));
            Assert.IsTrue(isWhatCountry.Contains(Country.GER));
            Assert.IsTrue(isWhatCountry.Contains(Country.CZH));
            Assert.IsTrue(isWhatCountry.Contains(Country.USA));
            Assert.IsTrue(isWhatCountry.Count == 4);
        }

    }
}