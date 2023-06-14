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
    public class RatingRepository: BaseRepository, IRatingRepository
    {
        public List<Rating> GetAllRatings()
        {
            List<Rating> ratings = new List<Rating>();
            try
            {
                Connection.Open();

                string selectQuery = "GetAllRatings";

                SqlCommand selectSqlCommand = new SqlCommand(selectQuery, Connection);
                selectSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = selectSqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Rating rating = new Rating()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UserId = Convert.ToInt32(reader["UserId"]),
                        RecipeId = Convert.ToInt32(reader["RecipeId"]),
                        Nrating = Convert.ToInt32(reader["Nrating"]),
                        Comment = Convert.ToString(reader["Comment"])
                    };

                    ratings.Add(rating);

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
            return ratings;
        }

        public int Insert(Rating rating)
        {
            int totalInserts = 0;

            try
            {
                Connection.Open();

                string insertQuery = $"InsertRatings";

                //SqlParameter idParam = new SqlParameter("@Id", rating.Id);
                SqlParameter userIdParam = new SqlParameter("@UserId", rating.UserId);
                SqlParameter recipeIdParam = new SqlParameter("@RecipeId", rating.RecipeId);
                SqlParameter starsParam = new SqlParameter("@Stars", rating.Nrating);
                SqlParameter commentParam = new SqlParameter("@Comment", rating.Comment);


                SqlCommand insertSqlCommand = new SqlCommand(insertQuery, Connection);
                insertSqlCommand.CommandType = CommandType.StoredProcedure;
                //insertSqlCommand.Parameters.Add(idParam);
                insertSqlCommand.Parameters.Add(userIdParam);
                insertSqlCommand.Parameters.Add(recipeIdParam);
                insertSqlCommand.Parameters.Add(starsParam);
                insertSqlCommand.Parameters.Add(commentParam);

                totalInserts = insertSqlCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return totalInserts;
        }

        public int Update(Rating rating)
        {
            int totalUpdates = 0;
            try
            {
                Connection.Open();

                string updateQuery = $"UpdateRating";

                SqlCommand updateSqlCommand = new SqlCommand(updateQuery, Connection);
                updateSqlCommand.CommandType = CommandType.StoredProcedure;
                updateSqlCommand.Parameters.Add(new SqlParameter("@Id", rating.Id));
                updateSqlCommand.Parameters.Add(new SqlParameter("@UserId", rating.UserId));
                updateSqlCommand.Parameters.Add(new SqlParameter("@RecipeId", rating.RecipeId));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Stars", rating.Nrating));
                updateSqlCommand.Parameters.Add(new SqlParameter("@Comment", rating.Comment));

                totalUpdates = updateSqlCommand.ExecuteNonQuery();

                Console.WriteLine(totalUpdates + " linhas atualizadas");
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

                string deleteQuery = "DeleteRating";

                SqlParameter Param = new SqlParameter();
                Param.Direction = ParameterDirection.Input;
                Param.SqlDbType = SqlDbType.Int;
                Param.ParameterName = "@Id";
                Param.Value = id;

                SqlCommand deleteSqlCommand = new SqlCommand(deleteQuery, Connection);
                deleteSqlCommand.CommandType = CommandType.StoredProcedure;
                deleteSqlCommand.Parameters.Add(Param);

                totalDeletes = deleteSqlCommand.ExecuteNonQuery();

                //  Console.WriteLine(totalDeletes + " linhas eliminadas");
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

