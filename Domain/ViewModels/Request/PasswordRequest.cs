using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModels.Request
{
    public class PasswordRequest : IValidatableObject
    {
        [JsonProperty("PasswordOld")]
        public string PasswordOld { get; set; }

        [JsonProperty("PasswordNew")]
        public string PasswordNew { get; set; }

        [JsonProperty("PasswordConfirm")]
        public string PasswordConfirm { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(PasswordOld))
            {
                yield return new ValidationResult("O parametro PasswordOld é obrigatorio", new string[] { "PasswordOld" });
            }
            if (string.IsNullOrEmpty(PasswordNew))
            {
                yield return new ValidationResult("O parametro PasswordNew é obrigatorio", new string[] { "PasswordNew" });
            }
            if (string.IsNullOrEmpty(PasswordConfirm))
            {
                yield return new ValidationResult("O parametro PasswordConfirm é obrigatorio", new string[] { "PasswordConfirm" });
            }
        
        }
    }
}
