using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LEARN_CS
{
    internal class Item
    {
        [JsonProperty("LABEL")]
        public int LABEL { get; set; } // LABEL은 정수로 사용
        [JsonProperty("NAME")]
        public string NAME { get; set; }
        [JsonProperty("STAT")]
        public string STAT { get; set; }
        [JsonProperty("VALUE")]
        public int VALUE { get; set; }

        [JsonProperty("PRICE")]
        public int PRICE { get; set; }
    }
}
