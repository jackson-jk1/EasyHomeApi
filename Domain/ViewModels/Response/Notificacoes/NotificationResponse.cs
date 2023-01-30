using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels.Response.Notificacoes
{
    public class NotificationResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("UserId")]
        public int UserId { get; set; }
       
        [JsonPropertyName("Status")]
        public int Status { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Read")]
        public bool Read { get; set; }


    }
}
