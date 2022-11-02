using Newtonsoft.Json;

namespace Domain.Request.Auth
{
    public class LoginRequest
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
