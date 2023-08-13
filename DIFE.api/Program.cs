using DIFE.lib.Services.Base;
using DIP.lib.Common;
using DIP.lib.Objects.Config;

namespace DIP.API
{
    public class Program
    {
        private static BaseSourceService? InitIDS(InternalDataSourceConfig config) =>
            typeof(BaseSourceService).Assembly.GetTypes()
                .Where(a => a.BaseType == typeof(BaseSourceService))
                .Select(b => Activator.CreateInstance(b, args: new[] { config }) as BaseSourceService)
                .FirstOrDefault(c => c?.SourceType == config.IDSType);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var idsConfig = builder.Configuration.GetSection(AppConstants.InternalDataSourceConfig).Get<InternalDataSourceConfig>()
                ?? throw new Exception("idsConfig was not set - shutting down");

            var baseService = InitIDS(idsConfig) ?? throw new Exception("baseService is null");

            builder.Services.AddSingleton(baseService);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
}