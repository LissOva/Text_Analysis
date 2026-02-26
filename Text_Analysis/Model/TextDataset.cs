using System;
using System.Collections.Generic;
using System.Text;
using Text_Analysis;
using System.Text.Json.Serialization;

namespace Text_Analysis.Model
{
    public class TextDataset
    {
        [JsonPropertyName("texts")]
        public List<TextItem> Texts { get; set; }


        public TextDataset() { }
        public TextDataset(TextItem text) {

            List<TextItem> texts = new List<TextItem>();
            texts.Add(text);
            this.Texts = texts;
        }
    }
}
