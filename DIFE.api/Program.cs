
using DIP.lib.Common;
using DIP.lib.Objects.Config;
using DIP.lib.Services;

namespace DIP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mongoConfig = builder.Configuration.GetSection(AppConstants.DbConnectionMongo).Get<MongoDbConfig>();

            if (mongoConfig is null)
            {
                throw new Exception("Mongo Config was not set - shutting down");
            }

            builder.Services.AddSingleton(mongoConfig);

            builder.Services.AddSingleton<MongoDbService>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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