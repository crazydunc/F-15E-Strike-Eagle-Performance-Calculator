using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public class LandingSpeeds
    {
        static string livDbLoc = Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        static  string connectionString = "Data Source = " + livDbLoc + ";";
     
        public (double FlapDownSpeed, double FlapUpSpeed) GetLandingSpeed(int weight)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Weight, FlapDown, FlapUp FROM LandingSpeeds WHERE Weight <= @Weight ORDER BY Weight DESC LIMIT 2";
                    command.Parameters.AddWithValue("@Weight", weight);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var lowerWeight = reader.GetInt32(0);
                            var lowerFlapDownSpeed = reader.GetInt32(1);
                            var lowerFlapUpSpeed = reader.GetInt32(2);

                            if (lowerWeight == weight)
                            {
                                // Exact match, return FlapDown and FlapUp speeds
                                return (lowerFlapDownSpeed, lowerFlapUpSpeed);
                            }

                            if (reader.Read())
                            {
                                var upperWeight = reader.GetInt32(0);
                                var upperFlapDownSpeed = reader.GetInt32(1);
                                var upperFlapUpSpeed = reader.GetInt32(2);

                                // Perform linear interpolation between two closest weights for FlapDown and FlapUp speeds
                                var interpolationFactor = (double)(weight - lowerWeight) / (upperWeight - lowerWeight);
                                var interpolatedFlapDownSpeed = lowerFlapDownSpeed + interpolationFactor * (upperFlapDownSpeed - lowerFlapDownSpeed);
                                var interpolatedFlapUpSpeed = lowerFlapUpSpeed + interpolationFactor * (upperFlapUpSpeed - lowerFlapUpSpeed);

                                return (interpolatedFlapDownSpeed, interpolatedFlapUpSpeed);
                            }
                            else if (lowerWeight != 0 && lowerFlapDownSpeed != 0 && lowerFlapUpSpeed != 0) 
                            {
                                return (lowerFlapDownSpeed, lowerFlapUpSpeed);
                            }
                        }

                        // Handle the case where weight is outside the range of available data
                        throw new Exception("Weight is outside the range of available data for Landing Speed.");
                    }
                }
            }
        }
    }
}
