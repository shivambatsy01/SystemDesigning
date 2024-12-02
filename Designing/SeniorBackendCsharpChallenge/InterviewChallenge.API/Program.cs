using InterviewChallenge.API.Models;
using System.Security.Cryptography.X509Certificates;
using LiteDB;
using InterviewChallenge.API.Context;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.Xml;

namespace InterviewChallenge.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var databasePath = builder.Configuration.GetConnectionString("DataPath");
            builder.Services.AddSingleton<LiteDatabase>(sp =>
            {
                return new LiteDatabase(databasePath);
            });
            builder.Services.AddSingleton<DBContext>();
            builder.Services.AddSingleton<DummyDataSeeder>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                //since it uses service Db context, to rseolve dependencies, we use GetRequiredServices (which are in services)
                var dataSeeder = scope.ServiceProvider.GetRequiredService<DummyDataSeeder>();
                dataSeeder.GenerateDummyData(); // Seed data only if necessary
            }


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

    public class Something
    {
        int x;
        Something(int xx) 
        {
            x = xx;
        }

    }
}