using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels.Response.Auth
{
    public class UserResponse

    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("CellPhone")]
        public string CellPhone { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Image")]
        public string Image { get; set; }

        [NotMapped]
        [JsonPropertyName("Favoritos")]
        public virtual ICollection<UserPreferenceModel> UserPreferences { get; set; }

    }
}
