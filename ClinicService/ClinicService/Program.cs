using ClinicService.Services;
using ClinicService.Services.Impl;
using System.Data.SQLite;

namespace ClinicService
{
    public class Program
    {
        /// https://sqlitestudio.pl/
        /// https://www.sqlite.org/datatype3.html
        public static void Main(string[] args)
        {
            //ConfigureSqliteConnection();

            var builder = WebApplication.CreateBuilder(args);

            //  Singleton - одиночка.
            //  Scoped - создаются заново при каждом запросе от клиента
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureSqliteConnection()
        {
            string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private static void PrepareSchema(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = "DROP TABLE IF EXISTS Consultations";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Pets";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Clients";
            command.ExecuteNonQuery();

            command.CommandText =
                    @"CREATE TABLE Clients(
                    ClientId INTEGER PRIMARY KEY,
                    Document TEXT,
                    SurName TEXT,
                    FirstName TEXT,
                    Patronymic TEXT,
                    Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE Pets(
                    PetId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    Name TEXT,
                    Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE Consultations(
                    ConsultationId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    PetId INTEGER,
                    ConsultationDate INTEGER,
                    Description TEXT)";
            command.ExecuteNonQuery();

        }
    }
}