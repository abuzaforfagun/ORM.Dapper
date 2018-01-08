using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using ORM.Dapper.Core;

namespace ORM.Dapper.Repository
{
    public class AuthorRepository
    {
        private string connectionString;
        public AuthorRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Default");
        }

        public IDbConnection Connection
        {
            get{
                return new SqlConnection(connectionString);
            }
        }
        
        public Author Get(int id){
            using(IDbConnection dbConnection = Connection){
                dbConnection.Open();
                string query = "SELECT * FROM Authors WHERE id = @id";
                return dbConnection.Query<Author>(query, new {id = id}).FirstOrDefault();
            }
        }
        public IEnumerable<Author> GetAll(){
            using(IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Author>("SELECT * FROM Authors");
                
            }
        }
        public int Add(Author author){
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "INSERT INTO Authors (Name, Email) Values (@Name, @Email); select CAST(scope_identity() as int)";
                return dbConnection.Query<int>(query, author).FirstOrDefault();
            }
        }

        
    }
}