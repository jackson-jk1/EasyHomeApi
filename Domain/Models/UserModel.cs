using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string CellPhone {get;set;}
        public string Email {get;set;}
        public string Password { get; set; }
        public string Image { get;set; }

        [NotMapped]
        public virtual ICollection<UserPreferenceModel> UserPreferences { get; set; }

    }
}
