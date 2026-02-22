using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Text_Analysis.Model
{
    public class TextDataset
    {
        [JsonPropertyName("texts")]
        public List<TextItem> Texts { get; set; }
    }
}
