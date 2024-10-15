using Tempo_API.Mapper;
using dotenv.net;
using Tempo_BLL.Mapper;
using Tempo_BLL.DI;
using Tempo_DAL.DI;
using Tempo_Shared.DI;
using Tempo_API.DI;
using Tempo_API.Middleware;

namespace Tempo_API;

static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {@".env"}));

        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.RegisterApiDependencies();
        builder.Services.RegisterSharedDependencies();
        builder.Services.RegisterDALDependencies(builder.Configuration);
        builder.Services.RegisterBllDependencies();

        builder.Services.AddAutoMapper(typeof(BllMapperProfile).Assembly, typeof(ApiMapperProfile).Assembly);

        var app = builder.Build();

        app.UseMiddleware<ExeptionHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}