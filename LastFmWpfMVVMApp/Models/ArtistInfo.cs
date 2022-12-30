using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LastFmWpfMVVMApp.Models
{

    public class Artist_with_sim_Artists
    {
        public Artist_with_Info artist { get; set; }
    }

    public class Artist_with_Info
    {
        public string name { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public Image1[] image { get; set; }
        public string streamable { get; set; }
        public string ontour { get; set; }
        public Stats stats { get; set; }
        public Similar similar { get; set; }
        public Tags tags { get; set; }
        public Bio bio { get; set; }
    }

    public class Stats
    {
        public string listeners { get; set; }
        public string playcount { get; set; }
    }

    public class Similar
    {
        public Artist1[] artist { get; set; }
    }

    public class Artist1
    {
        [JsonPropertyName("name")]
        public string Sim_Name { get; set; }
        public string url { get; set; }
        public Image_with_Info[] image { get; set; }
    }

    public class Image_with_Info
    {
        [JsonPropertyName("#text")]
        public string text { get; set; }
        public string size { get; set; }
    }

    public class Tags
    {
        public Tag[] tag { get; set; }
    }

    public class Tag
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Bio
    {
        public Links links { get; set; }
        public string published { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }

    public class Links
    {
        public Link link { get; set; }
    }

    public class Link
    {
        public string text { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Image1
    {
        [JsonPropertyName("#text")]
        public string text { get; set; }
        public string size { get; set; }
    }

}
