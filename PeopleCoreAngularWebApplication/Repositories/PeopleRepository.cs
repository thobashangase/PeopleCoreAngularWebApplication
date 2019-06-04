using Dapper;
using Microsoft.Extensions.Configuration;
using PeopleCoreAngularWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleCoreAngularWebApplication.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IConfiguration _config;

        public PeopleRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<IList<Person>> GetPeopleAsync()
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM People";
                conn.Open();
                var result = await conn.QueryAsync<Person>(sql);
                return result.ToList();
            }
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "SELECT * FROM People WHERE Id=@Id";
                conn.Open();
                var result = await conn.QueryAsync<Person>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<int> InsertPerson(Person person)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "INSERT INTO People (Name, Phone, Email) VALUES (@Name, @Phone, @Email)";
                conn.Open();
                return await conn.ExecuteAsync(sql, new { person.Name, person.Phone, person.Email });
            }
        }

        public async Task<int> UpdatePerson(Person person)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "UPDATE People SET Name = @Name, Phone = @Phone, Email = @Email WHERE Id = @Id";
                conn.Open();
                return await conn.ExecuteAsync(sql, new { person.Name, person.Phone, person.Email, person.Id });
            }
        }

        public async Task<int> DeletePerson(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sql = "DELETE FROM People WHERE Id = @Id";
                conn.Open();
                return await conn.ExecuteAsync(sql, new { id });
            }
        }
    }
}
