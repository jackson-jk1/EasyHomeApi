using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModels.Request
{
    public class FilterRequest
    { 
        private int _page = 1;  // the name field
       
        [JsonProperty("Page")]
        public int Page    // the Name property
        {
            get => _page;
            set => _page = value;
        }

        [JsonProperty("Polo")]
        public string Polo { get; set; }

        [JsonProperty("ValueMax")]
        public decimal ValueMax { get; set; }

        [JsonProperty("Rooms")]
        public int Rooms { get; set; }

    }
}
