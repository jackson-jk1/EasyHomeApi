using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.ViewModels.Response.Filtros
{
    public class PoloResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
