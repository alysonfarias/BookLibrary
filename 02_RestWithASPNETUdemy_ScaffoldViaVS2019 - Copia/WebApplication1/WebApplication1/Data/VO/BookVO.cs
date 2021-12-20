using System;
using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class BookVO
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Author { get; set; }

        [JsonPropertyName("date")]
        public DateTime LaunchDate { get; set; }

        [JsonPropertyName("value")]
        public double Price { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
