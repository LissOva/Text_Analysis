using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Text_Analysis.Model
{
    public class TextItem
    {
        [JsonPropertyName("title")]

        public string Title { get; set; }
        [JsonPropertyName("content")]

        public string Content { get; set; }
    }
}
