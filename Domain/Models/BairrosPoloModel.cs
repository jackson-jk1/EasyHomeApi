using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BairrosPoloModel
    {
        public int BairroId { get; set; }
        public virtual BairroModel  Bairro { get; set; }
        public int PoloId { get; set; }
        public virtual PoloModel Polo { get; set; }
    }
}
