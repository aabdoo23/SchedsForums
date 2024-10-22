using SchedsForums.Application;
using SchedsForums.Infrastructure;

namespace SchedsForums.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Custom services registration
            builder.Services.RegisterDbContext();
            builder.Services.RegisterInfrastructureRepositories();
            builder.Services.RegisterInfrastructureServices();
            builder.Services.RegisterMediatRServices();
            builder.Services.RegisterValidationServices();
            builder.Services.RegisterJwtAuth(builder.Configuration);

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
