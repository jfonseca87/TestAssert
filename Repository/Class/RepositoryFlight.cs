using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceRepository.Repository.Class
{
    public class RepositoryFlight : IRepositoryFlight
    {
        public int CreateFlight(Flight flight)
        {
            int queryReponse = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestAssert"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_CreateFlight", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SourceCity", SqlDbType.VarChar).Value = flight.SourceCity;
                cmd.Parameters.Add("@DestinationCity", SqlDbType.VarChar).Value = flight.DestinationCity;
                cmd.Parameters.Add("@DepartureDateTime", SqlDbType.DateTime).Value = flight.DepartureDateTime;
                cmd.Parameters.Add("@PlaneNumber", SqlDbType.VarChar).Value = flight.PlaneNumber;
                cmd.Parameters.Add("@PilotName", SqlDbType.VarChar).Value = flight.PilotName;
                cmd.Parameters.Add("@IdFlight", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                queryReponse = Convert.ToInt32(cmd.Parameters["@IdFlight"].Value.ToString());
                return queryReponse;
            }
        }

        public Flight GetFlight(int idFlight)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestAssert"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetFlight", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdFlight", SqlDbType.Int).Value = idFlight;

                Flight flight = new Flight();
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        flight.IdFlight = dr.GetInt32(0);
                        flight.SourceCity = dr.GetString(1);
                        flight.DestinationCity = dr.GetString(2);
                        flight.DepartureDateTime = dr.GetDateTime(3);
                        flight.PlaneNumber = dr.GetString(4);
                        flight.PilotName = dr.GetString(5);
                    }
                }

                return flight;
            }
        }
    }
}
