using FluentValidation;
using Serilog;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Tempo_API.Validators;

namespace Tempo_API.DI;

public static class ApiLayerDependencies
{
    public static void RegisterApiDependencies(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        builder.Logging.AddSerilog().SetMinimumLevel(LogLevel.Information);

        builder.Services.AddValidatorsFromAssemblyContaining<BillValidator>();

        builder.Services.AddFluentValidationAutoValidation();
    }
}
