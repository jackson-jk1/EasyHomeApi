using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ImmobileModel : BaseModel
    {
        public string ExternalId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Rooms { get; set; }
        public string Desc { get; set; }
        public string Images { get; set; }

        public int BairroId { get; set; }
        public BairroModel Bairro { get; set; }
        public string Map { get; set; }

        [NotMapped]
        public virtual ICollection<UserPreferenceModel> UserPreferences { get; set; }
    }
}
