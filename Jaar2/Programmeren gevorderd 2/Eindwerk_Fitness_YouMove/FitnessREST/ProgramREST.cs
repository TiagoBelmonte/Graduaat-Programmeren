
using FitnesDataEF.Repositories;
using FitnessBL.Interfaces;
using FitnessBL.Services;
using System.Text.Json.Serialization;

namespace FitnessREST
{
    public class ProgramREST
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
            builder.Services.AddSingleton<IProgramRepo>(r => new ProgramRepo(connectionString));
            builder.Services.AddSingleton<ProgramService>();
            builder.Services.AddSingleton<IReservationRepo>(r => new ReservationRepo(connectionString));
            builder.Services.AddSingleton<ReservationService>();
            builder.Services.AddSingleton<IProgramMembersRepo>( r => new ProgramMembersRepo(connectionString));
            builder.Services.AddSingleton<ProgramMembersService>();
            builder.Services.AddSingleton<ICyclingSession>(r => new CyclingSessionRepo(connectionString));
            builder.Services.AddSingleton<CyclingSessionService>();
            builder.Services.AddSingleton<IRunningSession_mainRepo>(r => new Runningsession_mainRepo(connectionString));
            builder.Services.AddSingleton<RunningSession_mainService>();
            builder.Services.AddSingleton<IRunningSession_detailRepo>(r => new RunningSession_detailRepo(connectionString));
            builder.Services.AddSingleton<RunningSession_detailService>();

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
