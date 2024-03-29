﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Infrastructure.Data
{
    public class NewsApiModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
        [JsonProperty("articles")]
        public List<Articles> Articles { get; set; }
    }
    public class Articles
    {
        [JsonProperty("source")]
        public Source Source { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
    public class Source
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id {get; set;}
    }
}
