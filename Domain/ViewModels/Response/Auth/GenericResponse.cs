using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels.Response.Auth
{
    public class GenericResponse
    {
        [JsonPropertyName("Response")]
        public string Response { get; set; }

        [JsonPropertyName("Statuscode")]

        public int Statuscode { get; set; }
    }
}
