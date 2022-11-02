using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Result
{
    public class ErroValidation
    {
        public string MessageErro { get; set; }
        public List<ResultError> ListErrors { get; set; }
    }
}
