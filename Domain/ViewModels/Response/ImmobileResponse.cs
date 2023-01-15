using Domain.Models;
using System.Text.Json.Serialization;

namespace Domain.ViewModels.Response
{
    public class ImmobileResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("SiteUrl")]
        public string SiteUrl { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
        [JsonPropertyName("Rooms")]
        public int Rooms { get; set; }
        [JsonPropertyName("Desc")]
        public string Desc { get; set; }
        [JsonPropertyName("Bairro")]
        public BairroModel Bairro { get; set; }
        [JsonPropertyName("Imgs")]
        public virtual List<string> Imgs { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("Map")]
        public string Map { get; set; }
        [JsonPropertyName("UserPreferences")]
        public virtual ICollection<UserPreferenceModel> UserPreferences { get; set; }
    }     
}
