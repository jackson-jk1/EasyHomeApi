using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


namespace Application.Configurations
{
    public static class MvcConfig
    {
        /// <summary>
        /// Adiciona as configurações MVC aos serviços da aplicação
        /// </summary>
        /// <param name="services">Interface de serviços</param>
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                o.Filters.Add(new AuthorizeFilter(policy));
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => $"O valor '{x}' e invalido.");
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => $"O campo {x} deve ser um numero.");
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => $"Um valor para a propriedade '{x}' nao foi fornecido.");
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => $"O valor '{x}' nao e valido para {y}.");
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Um valor e obrigatorio.");
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => $"O valor fornecido e invalido para {x}.");
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => $"O valor '{x}' e invalido.");
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "O request body e obrigatorio.");
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => $"O valor '{x}' nao e valido.");
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor fornecido e invalido.");
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser um numero.");
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

        }
    }
}
