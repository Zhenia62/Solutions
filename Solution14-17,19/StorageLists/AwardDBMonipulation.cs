using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using Task;
using System.Configuration;

namespace StorageLists
{
    public class AwardDBMonipulation
    {
        public static void Main()
        {
        }

        static string ConnectionString;

        public AwardDBMonipulation()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        }
        static public void Add(Award award)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.CommandText = "InsertAward";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = sqlConnection;

                        sqlConnection.Open();

                        command.Parameters.AddWithValue("@title", award.Title);
                        command.Parameters.AddWithValue("@description", award.Description);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка добавления награды", ex);
                    }
                }
            }
        }

        static public void EditAward(Award award)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.CommandText = "SELECT * FROM Awards";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = sqlConnection;

                        sqlConnection.Open();


                        command.Parameters.AddWithValue("@id", award.ID);
                        command.Parameters.AddWithValue("@title", award.Title);
                        command.Parameters.AddWithValue("@description", award.Description);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (award.Title == Convert.ToString(reader[1]))
                            {
                                command.CommandText = "EditAward";

                                int id = Convert.ToInt32(reader[0]);

                                command.Parameters.AddWithValue("@idAward", id);
                                command.Parameters.AddWithValue("@title", award.Title);
                                command.Parameters.AddWithValue("@description", award.Description);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка изменения награды", ex);
                    }
                }
            }
        }

        static  public void Remove(Award award)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.CommandText = "DeliteAward";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = sqlConnection;

                        sqlConnection.Open();

                        command.Parameters.AddWithValue("@idAward", award.ID);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка удаления пользователя", ex);
                    }
                }
            }
        }

        static public DataSet LoadAwards()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter adapterRewards = new SqlDataAdapter("SELECT * FROM [Awards]", sqlConnection);
                SqlCommandBuilder builderRewards = new SqlCommandBuilder(adapterRewards);
                DataSet rewardsInfo = new DataSet();
                adapterRewards.Fill(rewardsInfo, "Awards");
                return rewardsInfo;

            }
        }
    }
}
