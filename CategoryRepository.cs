using NoCookBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoCookBooks.Repositories.Interfaces;

namespace NoCookBooks.Repositories.Implementations
{
    public class CategoryRepository: BaseRepository, ICategoryRepository
    {
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            try
            {
                Connection.Open();

                string selectQuery = "GetAllCategories";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),

                    };

                    categories.Add(category);
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
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = new Category();

            try
            {
                Connection.Open();

                string selectQuery = "GetCategoryById";

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
                    category = new Category()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),

                    };

                    Console.WriteLine($"Id: {reader["Id"]}, Categoria: {reader["Name"]}");
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

            return category;
        }

        public int Insert(Category category)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertCategory";

                SqlParameter nameParam = new SqlParameter("@Name", category.Name);


                SqlCommand insertSqlCommand = new SqlCommand(insertQuery, Connection);
                insertSqlCommand.CommandType = CommandType.StoredProcedure;
                insertSqlCommand.Parameters.Add(nameParam);

                totalInserts = insertSqlCommand.ExecuteNonQuery();

                //Console.WriteLine(totalInserts + " linhas inseridas");
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

        public int Update(Category category)
        {
            int totalUpdates = 0;
            try
            {
                Connection.Open();

                string updateQuery = $"UpdateCategory";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Name", category.Name));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", category.Id));

                totalUpdates = updateSqlCommand.ExecuteNonQuery();

                //Console.WriteLine(totalUpdates + " linhas atualizadas");
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

                string deleteQuery = "DeleteCategory";

                SqlParameter idParam = new SqlParameter();
                idParam.Direction = ParameterDirection.Input;
                idParam.SqlDbType = SqlDbType.Int;
                idParam.ParameterName = "@Id";
                idParam.Value = id;

                SqlCommand deleteSqlCommand = new SqlCommand(deleteQuery, Connection);
                deleteSqlCommand.CommandType = CommandType.StoredProcedure;
                deleteSqlCommand.Parameters.Add(idParam);

                totalDeletes = deleteSqlCommand.ExecuteNonQuery();


                //Console.WriteLine(totalDeletes + " linhas eliminadas");
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
    }
}
