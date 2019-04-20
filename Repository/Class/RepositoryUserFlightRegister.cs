using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ServiceRepository.Repository.Interfaces;

namespace ServiceRepository.Repository.Class
{
    public class RepositoryUserFlightRegister : IRepositoryUserFlightRegister
    {
        public int CreateUserFlightRegister(int idFlight, int userDocumentNumber)
        {
            int queryReponse = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestAssert"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_CreateUserFlightRegister", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdFlight", SqlDbType.Int).Value = idFlight;
                cmd.Parameters.Add("@UserDocumentNumber", SqlDbType.Int).Value = userDocumentNumber;
                cmd.Parameters.Add("@IdUserFlightRegister", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                queryReponse = Convert.ToInt32(cmd.Parameters["@IdUserFlightRegister"].Value.ToString());
                return queryReponse;
            }
        }
    }
}
