using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserPreferenceModel
    {
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int ImmobileId { get; set; }
        public virtual ImmobileModel Immobile { get; set; }
    }
}
