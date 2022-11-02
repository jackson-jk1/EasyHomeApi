using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Result
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }
        public ErroValidation Error { get; set; }

        public string MensagemError { get; set; }

        public string LogMessage { get; set; }

        public int? Code { get; set; }

        public T Data { get; set; }
    }
}
