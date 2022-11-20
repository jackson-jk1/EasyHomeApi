using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PoloModel : BaseModel
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<BairrosPoloModel> BairrosPolo { get; set; }
    }
}
