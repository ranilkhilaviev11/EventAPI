using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using EventAPI.Models;

namespace EventAPI.Repository
{
    public class ParticipantRepository : IRepository<Participant>
    {
        private string connectionString;
        public ParticipantRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Participant item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO \"Participant\" (Surname, Name, MiddleName, BirthDate, PhoneNum, Email, Post) VALUES(@Surname, @Name, @MiddleName, @BirthDate, @PhoneNum, @Email, @Post)", item);
            }

        }
        public IEnumerable<Participant> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Participant>("SELECT * FROM \"Participant\"");//(\"Surname\", \"Name\", \"MiddleName\", \"BirthDate\", \"PhoneNum\", \"Email\", \"Post\")
            }
        }
        public Participant FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Participant>("SELECT (Surname, Name, MiddleName, BirthDate, PhoneNum, Email, Post) FROM \"Participant\" WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM \"Participant\" WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Participant item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE \"Participant\" SET Surname=@Surname, Name=@Name, MiddleName=@MiddleName, BirthDate=@BirthDate, PhoneNum=@PhoneNum, Email=@Email, Post=@Post WHERE id = @Id", item);
            }
        }
    }
}
