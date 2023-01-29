using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactsModel
    {
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int ContactId { get; set; }
        public UserModel Contact { get; set; }
    }
}
