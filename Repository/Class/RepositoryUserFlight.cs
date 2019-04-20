using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceRepository.Repository.Class
{
    public class RepositoryUserFlight : IRepositoryUserFlight
    {
        public int CreateUserFlight(UserFlight userFlight)
        {
            int queryReponse = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestAssert"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_CreateUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentType", SqlDbType.VarChar).Value = userFlight.DocumentType;
                cmd.Parameters.Add("@DocumentNumber", SqlDbType.Int).Value = userFlight.DocumentNumber;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userFlight.UserName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = userFlight.Email;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = userFlight.PhoneNumber;
                cmd.Parameters.Add("@IdUser", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                queryReponse = Convert.ToInt32(cmd.Parameters["@IdUser"].Value.ToString());
                return queryReponse;
            }
        }

        public UserFlight GetUserFlight(int userDocumentNumber)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestAssert"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetUserFlight", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocumentNumber", SqlDbType.Int).Value = userDocumentNumber;

                UserFlight user = new UserFlight();
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        user.IdUser = dr.GetInt32(0);
                        user.DocumentType = dr.GetString(1);
                        user.DocumentNumber = dr.GetInt32(2);
                        user.UserName = dr.GetString(3);
                        user.Email = dr.GetString(4);
                        user.PhoneNumber = dr.GetString(5);
                    }
                }

                return user;
            }
        }
    }
}
