using LegacyApp.Enums;
using LegacyApp.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LegacyApp.Repositories
{
    public class ClientRepository
    {
        public static Client GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetClientById"
            })
            {
                var parameter = new SqlParameter("@clientId", SqlDbType.Int) { Value = id };
                command.Parameters.Add(parameter);

                connection.Open();

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Client
                    {
                        Id = reader.GetInt32("ClientId"),
                        Name = reader.GetString("Name"),
                        ClientStatus = (ClientStatus)reader.GetInt32("ClientStatus")
                    };
                }
            }

            return null;
        }
    }
}