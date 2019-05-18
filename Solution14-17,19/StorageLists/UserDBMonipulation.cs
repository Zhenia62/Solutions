using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Task;

namespace StorageLists
{
    public class UserDBMonipulation
    {
        static string ConnectionString;

        public UserDBMonipulation()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        }

        static public void Remove(User user)
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                try
                {
                    command.CommandText = "DeliteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = sqlConnection;

                    command.Parameters.AddWithValue("@IdUser", user.Id);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();    
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка удаления пользователя", ex);
                }
            }

        }

        static public void EditUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                try
                {
                    sqlConnection.Open();
                    command.CommandText = "SELECT * FROM Users";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = sqlConnection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (user.FirstName == Convert.ToString(reader[1]) && user.LastName == Convert.ToString(reader[2]))
                        {
                            int id = Convert.ToInt32(reader[0]);

                            command.CommandText = "EditUser";

                            command.Parameters.AddWithValue("@idUser", id);
                            command.Parameters.AddWithValue("@Name", user.FirstName);
                            command.Parameters.AddWithValue("@SecondName", user.LastName);
                            command.Parameters.AddWithValue("@DateBirth", user.BirthDate);
                            command.Parameters.AddWithValue("@Age", user.Age);
                            command.Parameters.AddWithValue("@AwardsLisr", user.AwardList);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка изменения пользователя", ex);
                }

            }
        }

        static public void AddUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.CommandText = "InsertUser";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = sqlConnection;

                        sqlConnection.Open();

                        command.Parameters.AddWithValue("@Name", user.FirstName);
                        command.Parameters.AddWithValue("@SecondName", user.LastName);
                        command.Parameters.AddWithValue("@DateBirth", user.BirthDate);
                        command.Parameters.AddWithValue("@Age", user.Age);
                        command.Parameters.AddWithValue("@AwardsLisr", user.AwardList);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка добавления пользователя", ex);
                    }
                }

            }
        }
        static public DataSet LoadUsers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlDataAdapter adapterUsers = new SqlDataAdapter("SELECT * FROM [Users]", sqlConnection);
                SqlCommandBuilder builderUsers = new SqlCommandBuilder(adapterUsers);
                DataSet usersInfo = new DataSet();
                adapterUsers.Fill(usersInfo, "Users");
                sqlConnection.Close();
                return usersInfo;
            }

        }

        static public List<Award> LoadedUserRewards()
        {
            List<Award> awards = new List<Award>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {              
                string data = "SELECT * FROM Rewards";
                SqlCommand selectItems = new SqlCommand(data, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = selectItems.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2])));
                }
            }
            return awards;
        }
    }
}
