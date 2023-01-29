using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels.Response
{
    public class ContactResponse
    {
        

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("ContactId")]
        public int ContactId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("CellPhone")]
        public string CellPhone { get; set; }

    }
}
