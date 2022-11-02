using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Result
{
    public class CustomResult<T> : Result<T>
    {
        public override ResultType ResultType => ResultType.Custom;
        public CustomResult(int code)
        {
            Code = code;
            LogMessage = "custom";
        }
    }
}
