﻿namespace NewsPortal.Domain
{
    public class News
    {
        public string Author { get; }
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }
        public string ImageUrl { get; }
        public DateTime PublishedAt { get; }
        public string Content { get; }

        public News(string author, string title, string description, string url, string imageUrl, DateTime publishedAt, string content)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
            Content = content ?? throw new ArgumentNullException(nameof(content));

            if (string.IsNullOrEmpty(url)) throw new ApplicationException("Url can't be empty.");
            if (!url.Contains("https://")) throw new ApplicationException("Wrong url format.");
            if (publishedAt.Year < 2000 || publishedAt > DateTime.Now.AddSeconds(10)) throw new ApplicationException("Content is outdated.");
            //+test for unreal future

            PublishedAt = publishedAt;
            Url = url;

        }


        public bool IsImportant()
        {
            if (Title.ToLower().Contains("war") && Title.ToLower().Contains("czech"))
            {
                return true;
            }else if (Content.ToLower().Contains("war") && Content.ToLower().Contains("czech"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //adding content condition
        public bool IsToday() => PublishedAt.Day == DateTime.Now.Day && PublishedAt.Month == DateTime.Now.Month && PublishedAt.Year == DateTime.Now.Year;
        public bool IsThisWeek() => PublishedAt > DateTime.Now.AddDays(-7);
        public bool IsThisMonth() => PublishedAt > DateTime.Now.AddMonths(-1);

        public List<Country> WhatCountry()
        {
            List <Country> results = new List<Country>();
 
            if (Content.ToLower().Contains("ukraine") || Title.ToLower().Contains("ukraine")){
                results.Add(Country.UKR);
            }
            if (Content.ToLower().Contains("usa") || Title.ToLower().Contains("usa"))
            {
                results.Add(Country.USA);
            }
            if (Content.ToLower().Contains("germany") || Title.ToLower().Contains("germany"))
            {
                results.Add(Country.GER);
            }
            if (Content.ToLower().Contains("czech") || Title.ToLower().Contains("czech"))
            {
                results.Add(Country.CZH);
            }
            if (Content.ToLower().Contains("united kingdom") || Title.ToLower().Contains("united kingdom"))
            {
                results.Add(Country.UK);
            }
            return results;
            //adding title condition
        }
    }
}
