using NoCookBooks.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using NoCookBooks.Domain.Entities;

namespace NoCookBooks.Repositories.Implementations
{
    public class RecipeRepository: BaseRepository, IRecipeRepository
    {
        public List<Recipe> GetAll()
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                Connection.Open();

                string selectQuery = "GetAllRecipes";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Recipe recipe = new Recipe()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        MakeRecipe = Convert.ToString(reader["MakeRecipe"]),
                        //ImageUrl = Convert.ToString(reader["ImageUrl"]),
                        Favorite = Convert.ToBoolean(reader["Favorite"]),
                        Difficult = Convert.ToString(reader["Difficult"]),
                        Time = Convert.ToInt32(reader["Time"])
                    };

                    recipes.Add(recipe);
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
            return recipes;
        }

        public Recipe GetById(int id)
        {
            Recipe recipe = new Recipe();

            try
            {
                Connection.Open();

                string selectQuery = "GetRecipeById";

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
                    recipe = new Recipe()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        MakeRecipe = Convert.ToString(reader["MakeRecipe"]),
                        //ImageUrl = Convert.ToString(reader["ImageUrl"]),
                        Favorite = Convert.ToBoolean(reader["Favorite"]),
                        Difficult = Convert.ToString(reader["Difficult"]),
                        Time = Convert.ToInt32(reader["Time"])
                    };



                    Console.WriteLine($"Id: {reader["Id"]}, Receita: {reader["Name"]}, Descrição: {reader["Description"]}, Receita: {reader["MakeRecipe"]}/*, {reader["ImageUrl"]}*/, Favorito: {reader["Favorite"]}, Dificuldade: {reader["Difficult"]}, Tempo: {reader["Time"]}");
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



            return recipe;
        }

        public int Insert(Recipe recipe)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertRecipes";

                SqlParameter nameParam = new SqlParameter("@Name", recipe.Name);
                SqlParameter descriptionParam = new SqlParameter("@Description", recipe.Description);
                SqlParameter makeRecipeParam = new SqlParameter("@MakeRecipe", recipe.MakeRecipe);
                SqlParameter favoriteParam = new SqlParameter("@Favorite", recipe.Favorite);
                SqlParameter difficultParam = new SqlParameter("@Difficult", recipe.Difficult);
                SqlParameter timeParam = new SqlParameter("@Time", recipe.Time); 
                SqlParameter categoryIdParam = new SqlParameter("@CategoryId", recipe.CategoryId);


                SqlCommand insertSqlCommand = new SqlCommand(insertQuery, Connection);
                insertSqlCommand.CommandType = CommandType.StoredProcedure;
                insertSqlCommand.Parameters.Add(nameParam);
                insertSqlCommand.Parameters.Add(descriptionParam);
                insertSqlCommand.Parameters.Add(makeRecipeParam);
                insertSqlCommand.Parameters.Add(favoriteParam);
                insertSqlCommand.Parameters.Add(difficultParam);
                insertSqlCommand.Parameters.Add(timeParam);
                insertSqlCommand.Parameters.Add(categoryIdParam);   


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

        public int Update(Recipe recipe)
        {
            int totalUpdates = 0;
            try
            {
                Connection.Open();

                string updateQuery = $"UpdateRecipe";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Name", recipe.Name));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Description", recipe.Description));
                updateSqlCommand.Parameters.Add(new SqlParameter("@MakeRecipe", recipe.MakeRecipe));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Favorite", recipe.Favorite));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Difficult", recipe.Difficult));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Time", recipe.Time));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", recipe.Id));

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

                string deleteQuery = "DeleteRecipe";

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

        //estudar este abaixo
        public List<Recipe> GetByCategoryId(int categoryId)
        {
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                Connection.Open();

                string selectQuery = "GetRecipesByCategoryId";

                SqlParameter idParam = new SqlParameter();
                idParam.Direction = ParameterDirection.Input;
                idParam.SqlDbType = SqlDbType.Int;
                idParam.ParameterName = "@CategoryId";
                idParam.Value = categoryId;

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                selectSqlCommand.Parameters.Add(idParam);

                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Recipe Recipe = new Recipe()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Title"]),
                        Description = Convert.ToString(reader["Description"]),
                        MakeRecipe = Convert.ToString(reader["Preparation Method"]),
                        Difficult = Convert.ToString(reader["Dificulty"]),
                        Time = Convert.ToInt32(reader["Preparation Time"]),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        ImgUrl = Convert.ToString(reader["ImgUrl"])
                    };

                    recipes.Add(Recipe);
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



            return recipes;
        }


    }
}
