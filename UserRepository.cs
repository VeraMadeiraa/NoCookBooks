using NoCookBooks.Domain.Entities;
using NoCookBooks.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Implementations
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                Connection.Open();

                string selectQuery = "GetAllUsers";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Address = Convert.ToString(reader["Adress"]),
                        Email = Convert.ToString(reader["Email"]),
                        Password = Convert.ToString(reader["Password"])
                    };

                    users.Add(user);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado aconteceu!");
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();

            try
            {
                Connection.Open();

                string selectQuery = "GetUserById";

                SqlParameter idParam = new SqlParameter();
                idParam.Direction = ParameterDirection.Input;
                idParam.SqlDbType = SqlDbType.Int;
                idParam.ParameterName = "@Id";
                idParam.Value = id;

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                selectSqlCommand.Parameters.Add(idParam);

                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Email = Convert.ToString(reader["Email"]),
                        Password = Convert.ToString(reader["Password"]),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                        Address = Convert.ToString(reader["Address"])

                    };
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado aconteceu!");
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return user;
        }

        public int Insert(User user)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertUser";

                SqlParameter nameParam = new SqlParameter("@Name", user.Name);
                SqlParameter emailParam = new SqlParameter("@Email", user.Email);
                SqlParameter passwordParam = new SqlParameter("@Password", user.Password);
                SqlParameter addressParam = new SqlParameter("@Address", user.Address);
                // SqlParameter isAdminParam = new SqlParameter("@IsAdmin", user.IsAdmin);


                SqlCommand insertSqlCommand = new SqlCommand(insertQuery, Connection);
                insertSqlCommand.CommandType = CommandType.StoredProcedure;
                insertSqlCommand.Parameters.Add(nameParam);
                insertSqlCommand.Parameters.Add(emailParam);
                insertSqlCommand.Parameters.Add(passwordParam);
                insertSqlCommand.Parameters.Add(addressParam);
                //  insertSqlCommand.Parameters.Add(isAdminParam);

                totalInserts = insertSqlCommand.ExecuteNonQuery();

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
                Console.ReadLine();
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return totalInserts;
        }

        public int Update(User user)
        {
            int totalUpdates = 0;

            try
            {
                Connection.Open();

                string updateQuery = $"UpdateUser";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", user.Id));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Name", user.Name));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Name", user.Address));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Email", user.Email));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Password", user.Password));

                totalUpdates = updateSqlCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado aconteceu!");
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return totalUpdates;
        }

        public int Delete(int id)
        {
            int totalDeletes = 0;

            try
            {
                Connection.Open();

                string deleteQuery = "DeleteUser";

                SqlParameter Param = new SqlParameter();
                Param.Direction = ParameterDirection.Input;
                Param.SqlDbType = SqlDbType.Int;
                Param.ParameterName = "Id";
                Param.Value = id;

                SqlCommand deleteSqlCommand = new SqlCommand(deleteQuery, Connection);
                deleteSqlCommand.CommandType = CommandType.StoredProcedure;
                deleteSqlCommand.Parameters.Add(Param);

                totalDeletes = deleteSqlCommand.ExecuteNonQuery();

                // Console.WriteLine(totalDeletes + " linhas eliminadas");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo de errado aconteceu!");
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return totalDeletes;
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        Address = reader["Address"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };

                    Connection.Close();
                    return user;
                }

                Connection.Close();
                return null;
            }
        }
    }
}
