using NoCookBooks.Domain.Entities;
using NoCookBooks.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Implementations
{
    public class RecipeIngredientRepository: BaseRepository, IRecipeIngredientRepository
    {
        public List<RecipeIngredient> GetAll()
        {
            List<RecipeIngredient> recipesingredients = new List<RecipeIngredient>();
            try
            {
                Connection.Open();

                string selectQuery = "GetAllRecipesIngredients";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RecipeIngredient recipeingredient = new RecipeIngredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Quantity = Convert.ToDecimal(reader["Quantity"]),
                        Unity = Convert.ToString(reader["Unity"])

                    };

                    recipesingredients.Add(recipeingredient);
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
            return recipesingredients;
        }

        public RecipeIngredient GetById(int id)
        {
            RecipeIngredient recipeingredient = new RecipeIngredient();

            try
            {
                Connection.Open();

                string selectQuery = "GetRecipeIngredientById";

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
                    recipeingredient = new RecipeIngredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Unity = Convert.ToString(reader["Name"]),
                        Quantity = Convert.ToDecimal(reader["Id"])

                    };

                    Console.WriteLine($"Id: {reader["Id"]},Quantidade: {reader["Quantity"]} ,Unidade: {reader["Unity"]}");
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

            return recipeingredient;
        }

        public int Insert(RecipeIngredient recipeingredient)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertRecipeIngredient";

                SqlParameter quantityParam = new SqlParameter("@Quantity", recipeingredient.Quantity);
                SqlParameter unityParam = new SqlParameter("@Unity", recipeingredient.Unity);


                SqlCommand insertSqlCommand = new SqlCommand(insertQuery, Connection);
                insertSqlCommand.CommandType = CommandType.StoredProcedure;
                insertSqlCommand.Parameters.Add(quantityParam);
                insertSqlCommand.Parameters.Add(unityParam);

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

        public int Update(RecipeIngredient recipeingredient)
        {
            int totalUpdates = 0;
            try
            {
                Connection.Open();

                string updateQuery = $"UpdateRecipeIngredient";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Quantity", recipeingredient.Quantity));
                updateSqlCommand.Parameters.Add(new SqlParameter("Unity", recipeingredient.Unity));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", recipeingredient.Id));

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

                string deleteQuery = "DeleteRecipeIngredient";

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



        // estudar este abaixo
        public List<RecipeIngredient> GetRecipeIngredientByRecipeId(int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();

            try
            {
                Connection.Open();

                string selectQuery = "GetRecipeIngredientsByRecipeId";

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
                    RecipeIngredient RecipeIngredient = new RecipeIngredient()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IngredientId = Convert.ToInt32(reader["IngredientId"]),
                        RecipeId = Convert.ToInt32(reader["RecipeId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Unity = Convert.ToString(reader["Unit"]),
                        

                    };

                    recipeIngredients.Add(RecipeIngredient);
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



            return recipeIngredients;
        }

    }
}
