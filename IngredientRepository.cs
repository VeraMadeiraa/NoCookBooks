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
    public class IngredientRepository: BaseRepository, IIngredientRepository
    {
        public List<Ingredient> GetAll()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                Connection.Open();

                string selectQuery = "GetAllIngredients";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                    
                    };

                    ingredients.Add(ingredient);
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
            return ingredients;
        }

        public Ingredient GetById(int id)
        {
            Ingredient ingredient = new Ingredient();

            try
            {
                Connection.Open();

                string selectQuery = "GetIngredientById";

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
                    ingredient = new Ingredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        
                    };

                    Console.WriteLine($"Id: {reader["Id"]}, Ingrediente: {reader["Name"]}");
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

            return ingredient;
        }

        public int Insert(Ingredient ingredient)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertIngredient";

                SqlParameter nameParam = new SqlParameter("@Name", ingredient.Name);


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

        public int Update(Ingredient ingredient)
        {
            int totalUpdates = 0;
            try
            {
                Connection.Open();

                string updateQuery = $"UpdateIngredient";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Name", ingredient.Name));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", ingredient.Id));

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

                string deleteQuery = "DeleteIngredient";

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

        //   Estudar isto abaixo!!!!
        public List<Ingredient> GetByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                Connection.Open();

                string selectQuery = "GetIngredientsByRecipeId";

                SqlParameter idParam = new SqlParameter();
                idParam.Direction = ParameterDirection.Input;
                idParam.SqlDbType = SqlDbType.Int;
                idParam.ParameterName = "@RecipeId";
                idParam.Value = recipeId;

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                selectSqlCommand.Parameters.Add(idParam);

                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Ingredient Ingredient = new Ingredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"])
                    };

                    ingredients.Add(Ingredient);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }



            return ingredients;
        }


        public List<Ingredient> GetRecipesByIngredientId(int id)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                Connection.Open();

                string selectQuery = "GetRecipesByIngredientId";

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
                    Ingredient Ingredient = new Ingredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Recipe = new Recipe()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = Convert.ToString(reader["Title"]),
                            Description = Convert.ToString(reader["Description"]),
                            MakeRecipe = Convert.ToString(reader["PreparationMethod"]),
                            Difficult = Convert.ToString(reader["Dificulty"]),
                            Time = Convert.ToInt32(reader["PreparationTime"]),
                            ImgUrl = Convert.ToString(reader["ImgUrl"])

                        }

                    };

                    ingredients.Add(Ingredient);
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



            return ingredients;
        }
    }
}
