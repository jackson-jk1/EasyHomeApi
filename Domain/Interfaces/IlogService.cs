using Microsoft.AspNetCore.Http;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IlogService
    {
        public void GravarLogs(string acao, string? parametros, string? mensagem,
            int? statusCode, LogEventLevel LogEventLevel = LogEventLevel.Information);
        public void GravarLogRepository(string acao, string? parametros, string? sql, string? result, string? mensagem,
         int? statusCode, LogEventLevel LogEventLevel = LogEventLevel.Information);     

    }
}
