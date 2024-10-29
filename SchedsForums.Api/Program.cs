using SchedsForums.API.Filters;
using SchedsForums.Application;
using SchedsForums.Infrastructure;

namespace SchedsForums.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Adding Custom services 
            builder.Services.AddDbContext();
            builder.Services.AddInfrastructureRepositories();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddMediatRServices();
            builder.Services.AddValidationServices();
            builder.Services.ConfigureJWTOptions(builder.Configuration);
            builder.Services.AddJwtAuthentication(builder.Configuration);

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
