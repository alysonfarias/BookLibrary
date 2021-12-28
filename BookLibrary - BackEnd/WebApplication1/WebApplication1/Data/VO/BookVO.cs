using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApplication1.Hypermedia;
using WebApplication1.Hypermedia.Abstract;

namespace WebApplication1.Model
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public double Price { get; set; }

        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
