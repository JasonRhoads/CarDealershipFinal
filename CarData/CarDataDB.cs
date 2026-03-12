using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CarData
{
    public static class CarDataDB
    {
        public static SqlConnection GetConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["CarData.Properties.Settings.CarDealershipConnectionString"];

            if (settings == null)
                throw new Exception("Connection string 'CarData.Properties.Settings.CarDealershipConnectionString' was not found.");

            return new SqlConnection(settings.ConnectionString);
        }
    }
}