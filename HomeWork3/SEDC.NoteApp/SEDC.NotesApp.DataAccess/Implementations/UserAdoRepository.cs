using SEDC.NotesApp.DataAccess.Interfaces;
using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.DataAccess.Implementations
{
    public class UserAdoRepository : IRepository<User>
    {
        private string _connectionString;
        public UserAdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Delete(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "DELETE FROM dbo.Users WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", entity.Id);
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public List<User> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM dbo.Users";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<User> usersDb = new List<User>();

            while (sqlDataReader.Read())
            {
                usersDb.Add(new User()
                {
                    Id = (int)sqlDataReader["Id"],
                    FirstName = (string)sqlDataReader["FirstName"],
                    LastName = (string)sqlDataReader["LastName"],
                    UserName = (string)sqlDataReader["UserName"],
                    Age = (int)sqlDataReader["Age"]
                });
            }
            sqlConnection.Close();
            return usersDb;
        }

        public User GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM dbo.Users where Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<User> usersDb = new List<User>();

            while (sqlDataReader.Read())
            {
                usersDb.Add(new User
                {
                    Id = (int)sqlDataReader["Id"],
                    FirstName = (string)sqlDataReader["FirstName"],
                    LastName = (string)sqlDataReader["LastName"],
                    UserName = (string)sqlDataReader["UserName"],
                    Age = (int)sqlDataReader["Age"]
                });
            }
            sqlConnection.Close();
            return usersDb.FirstOrDefault();
        }

        public void Insert(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO dbo.Users (FirstName,LastName,UserName) " + "VALUES(@userFirstName, @userLastName, @userUserName, @userAge)";
            sqlCommand.Parameters.AddWithValue("@userFirstName", entity.FirstName);
            sqlCommand.Parameters.AddWithValue("@userLastName", entity.LastName);
            sqlCommand.Parameters.AddWithValue("@userUserName", entity.UserName);
            sqlCommand.Parameters.AddWithValue("@userAge", entity.Age);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Update(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "UPDATE dbo.Users SET FirstName = @userFirstName, LastName = @userLastName, UserName = @userUserName, Age =@userAge" +
                " WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@userFirstName", entity.FirstName);
            sqlCommand.Parameters.AddWithValue("@userLastName", entity.LastName);
            sqlCommand.Parameters.AddWithValue("@userUserName", entity.UserName);
            sqlCommand.Parameters.AddWithValue("@userAge", entity.Age);
            sqlCommand.Parameters.AddWithValue("@id", entity.Id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
