using Domain.Utils.Result;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Net;
using Domain.Interfaces;

namespace Application.Controllers
{ 
    [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!", null)]
    [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!", null)]
    [SwaggerResponse(401, "Requisição requer autenticação do usuário!", null)]
    [SwaggerResponse(403, "Privilégios insuficientes!", null)]
    [SwaggerResponse(404, "O recurso solicitado não existe!", null)]
    [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!", null)]
    [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!", null)]
    public abstract class ControllerBase : Controller
    {
        private readonly IlogService _logService;

        public readonly Stopwatch _stopwatch;

        protected string _systemName { get; set; }

        protected ControllerBase(IlogService logFunctions, string systemName)
        {
            _logService = logFunctions;
            _stopwatch = new Stopwatch();
            _systemName = systemName;
        }

        public virtual IActionResult FromResult(ModelStateDictionary modelState)
        {
            List<ResultError> listaErros = modelState.Keys.SelectMany((string key) => modelState[key].Errors.Select((ModelError x) => new ResultError
            {
                FieldError = key,
                MesagemError = x.ErrorMessage
            })).ToList();
            CustomResult<ErroValidation> result = new CustomResult<ErroValidation>(403)
            {
                Data = new ErroValidation { ListErrors = listaErros, MessageErro = "erro de validação"}
            };
            return FromResult(result);
        }

        public virtual IActionResult FromResult<T>(Result<T> result)
        {
            switch (result.ResultType)
            {
                case ResultType.Accepted:
                    LogFix(result, HttpStatusCode.Accepted);
                    return ReturnStatusCode(202, result);
                case ResultType.BadRequest:
                    LogFix(result, HttpStatusCode.BadRequest);
                    return ReturnStatusCode(400, result);
                case ResultType.Created:
                    LogFix(result, HttpStatusCode.Created);
                    return ReturnStatusCode(201, result);
                case ResultType.Exception:
                    {
                        int num = result.Code ?? 500;
                        LogFix(result, (HttpStatusCode)num);
                        return ReturnStatusCode(num, result);
                    }
                case ResultType.NoContent:
                    LogFix(result, HttpStatusCode.NoContent);
                    return ReturnStatusCode(204);
                case ResultType.NotFound:
                    LogFix(result, HttpStatusCode.NotFound);
                    return ReturnStatusCode(404);
                case ResultType.PartialContent:
                    LogFix(result, HttpStatusCode.PartialContent);
                    return ReturnStatusCode(206, result);
                case ResultType.PermissionDenied:
                    LogFix(result, HttpStatusCode.Forbidden);
                    return ReturnStatusCode(403, result);
                case ResultType.PreCondition:
                    LogFix(result, HttpStatusCode.PreconditionFailed);
                    return ReturnStatusCode(412, result);
                case ResultType.Success:
                    LogFix(result, HttpStatusCode.OK);
                    return ReturnStatusCode(200, result);
                case ResultType.Unauthorized:
                    LogFix(result, HttpStatusCode.Unauthorized);
                    return ReturnStatusCode(401, result);
                default:
                    LogFix(result, (HttpStatusCode)(result.Code ?? 501));
                    return ReturnStatusCode(result.Code ?? 501, result);
            }
        }

        private IActionResult ReturnStatusCode(int httpStatusCode)
        {
            return ReturnStatusCode<object>(httpStatusCode);
        }

        private IActionResult ReturnStatusCode<T>(int httpStatusCode, Result<T> result = null)
        {
            if (httpStatusCode == 412 && result != null && result.Error != null)
            {
                ErroValidation error = result.Error;
                if ((error != null && error.ListErrors?.Count > 0) || !string.IsNullOrEmpty(result.Error?.MessageErro))
                {
                    return StatusCode(httpStatusCode, result.Error);
                }
            }

            if (result == null || result.Data == null)
            {
                return StatusCode(httpStatusCode);
            }

            return StatusCode(httpStatusCode, result.Data);
        }

        public virtual void SetPaginationHeader(int _Offset, int _Limit, int _Total)
        {
            base.Request.HttpContext.Response.Headers.Add("_offset", _Offset.ToString());
            base.Request.HttpContext.Response.Headers.Add("_limit", _Limit.ToString());
            base.Request.HttpContext.Response.Headers.Add("_total", _Total.ToString());
        }

        public virtual void LogFix<T>(Result<T> result, HttpStatusCode metodo)
        {
            StringValues? stringValues = base.HttpContext?.Request?.Headers["correlation-id"];
            StringValues? stringValues2 = stringValues;
            if (string.IsNullOrEmpty(stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null))
            {
                stringValues = base.HttpContext?.Request?.Headers["request_id"];
            }

            stringValues2 = stringValues;
            if (string.IsNullOrEmpty(stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null))
            {
                stringValues = base.HttpContext?.Request?.Headers["access_token"];
            }

            int? num = 0;
            StringValues? stringValues3 = base.HttpContext?.Request?.Headers["client_id"];
            LogLevel logLevel = LogLevel.Information;
            if (metodo >= HttpStatusCode.BadRequest || metodo < HttpStatusCode.InternalServerError)
            {
                logLevel = LogLevel.Warning;
            }

            if (metodo >= HttpStatusCode.InternalServerError || metodo < (HttpStatusCode)600)
            {
                logLevel = LogLevel.Error;
            }

            /*ILogFunctions logFunctions = _logService;
            LogLevel loglevel = logLevel;
            HttpRequest httpRequest = base.Request?.HttpContext?.Request;
            string length = num?.ToString() ?? "0";
            string responsetime = ((_stopwatch != null) ? _stopwatch.Elapsed.ToString() : "00:00:00.000");
            string systemName = _systemName;
            stringValues2 = stringValues3;
            string user = (stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null);
            stringValues2 = stringValues;
            logFunctions.WriteConsoleLogs(loglevel, httpRequest, metodo, length, responsetime, systemName, user, stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null, result.LogFleuryMessage);
            */
            }
    }
}
