
using FitnesDataEF.Repositories;
using FitnessBL.Interfaces;
using FitnessBL.Services;
using System.Text.Json.Serialization;

namespace FitnessREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = @"Data Source=LAPTOP-I33SVT0O\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Trust Server Certificate=True";

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IMemberRepo>(r => new MemberRepo(connectionString));
            builder.Services.AddSingleton<MemberService>();
            builder.Services.AddSingleton<IEquipmentRepo>(r => new EquipmentRepo(connectionString));
            builder.Services.AddSingleton<EquipmentService>();
            var app = builder.Build();

            app.UseCors("AllowSpecificOrigin");

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
