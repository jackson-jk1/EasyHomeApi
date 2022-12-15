using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels.Response.Auth
{
    public class LoginResponse
    {
        [JsonPropertyName("Token")]
        public string Token { get; set; }

        public UserResponse User { get; set; }
    }
}
