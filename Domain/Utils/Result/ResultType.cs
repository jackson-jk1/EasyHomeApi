using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Result
{
    public enum ResultType
    {
        Accepted,
        BadRequest,
        Created,
        Custom,
        Exception,
        NotFound,
        NoContent,
        PreCondition,
        PartialContent,
        PermissionDenied,
        Success,
        Unauthorized
    }
}
