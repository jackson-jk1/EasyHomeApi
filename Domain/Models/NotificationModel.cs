using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Notification : BaseModel
    {

        public int UserId { get; set; }

        public int ContatandoId { get; set; }

        public int Status { get; set; }

        public bool Read { get; set; }

        public virtual UserModel User { get; set; }


        public virtual UserModel Contatando { get; set; }

        public DateTime Expires { get;set; } = DateTime.Now;
    }
}
