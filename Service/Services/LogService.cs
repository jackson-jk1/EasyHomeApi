using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Serilog.Events;
using Serilog;
using Domain.Interfaces;

namespace Service.Services
{
    public class LogService : IlogService
    {
        public void GravarLogs(string acao, string? parametros, string? mensagem,
            int? statusCode, LogEventLevel LogEventLevel = LogEventLevel.Information)
        {
            var jsonObject = new JObject
            {
                {
                    "log-level",
                    (JToken)LogEventLevel.ToString()
                },
                {
                    "id",
                    (JToken)Guid.NewGuid().ToString()
                },
                {
                    "acao",
                    (JToken)acao
                },
                {
                    "params",
                    (JToken)parametros
                },
                {
                    "hora",
                    (JToken)DateTime.Now.ToString()
                },
                {
                    "statusCode",
                    (JToken)statusCode?.ToString()
                },
                {
                    "mensagem",
                    (JToken)mensagem?.ToString()
                }
            };

            CustomConsole(jsonObject, LogEventLevel);
        }

        public void GravarLogRepository(string acao, string? parametros, string? sql, string? result, string? mensagem,
            int? statusCode, LogEventLevel LogEventLevel = LogEventLevel.Information)
        {
            var jsonObject = new JObject
            {
                {
                    "log-level",
                    (JToken)LogEventLevel.ToString()
                },
                {
                    "id",
                    (JToken)Guid.NewGuid().ToString()
                },
                {
                    "acao",
                    (JToken)acao
                },
                {
                    "params",
                    (JToken)parametros
                },
                {
                    "sql",
                    (JToken)sql
                },
                {
                    "resultSql",
                    (JToken)result
                },
                {
                    "hora",
                    (JToken)DateTime.Now.ToString()
                },
                {
                    "statusCode",
                    (JToken)statusCode?.ToString()
                },
                {
                    "mensagem",
                    (JToken)mensagem?.ToString()
                }
            };
            CustomConsole(jsonObject, LogEventLevel);
        }

        public void CustomConsole(JObject logOk, LogEventLevel LogEventLevel)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext().WriteTo.Console(LogEventLevel.Verbose, "{Message:lj}{NewLine}{Exception}").CreateLogger();
            try
            {
                switch (LogEventLevel)
                {
                    case LogEventLevel.Information:
                        Log.Information(logOk.ToString(Formatting.None));
                        break;
                    case LogEventLevel.Debug:
                        Log.Debug(logOk.ToString(Formatting.None));
                        break;
                    case LogEventLevel.Error:
                        Log.Error(logOk.ToString(Formatting.None));
                        break;
                    case LogEventLevel.Warning:
                        Log.Warning(logOk.ToString(Formatting.None));
                        break;
                }
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Erro ao Gravar registro de Log.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}

