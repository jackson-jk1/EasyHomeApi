﻿
using Domain.Request.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Request.Auth
{
    public class UserRequest  : IValidatableObject
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
       
        [JsonProperty("CellPhone")]
        [Required]
        [Phone]
        public string CellPhone { get; set; }
       
        [JsonProperty("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        [JsonProperty("Password")]
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [JsonProperty("Image")]
        public IFormFile Image { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("O parametro Name é obrigatorio", new string[] { "Name" });
            }
            if (string.IsNullOrEmpty(CellPhone))
            {
                yield return new ValidationResult("O parametro CellPhone é obrigatorio", new string[] { "CellPhone" });
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("O parametro Password é obrigatorio", new string[] { "Password" });
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("O parametro Email é obrigatorio", new string[] { "Email" });
            }
        }
    }
}
