using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public class LandingSpeeds
    {
        static string livDbLoc = Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        static  string connectionString = "Data Source = " + livDbLoc + ";";
        //public static double Calculate(double weight)
        //{

        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SQLiteCommand command = new SQLiteCommand(connection))
        //        {
        //            command.CommandText =
        //                "SELECT FlapDown, FlapUp FROM LandingSpeeds WHERE Weight <= @Weight ORDER BY Weight DESC LIMIT 1";
        //            command.Parameters.AddWithValue("@Weight", weight);

        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    int lowerWeight = reader.GetInt32(0);
        //                    int upperWeight = reader.GetInt32(1);

        //                    if (lowerWeight == weight || upperWeight == weight)
        //                    {
        //                        // The weight matches an entry exactly, return the corresponding speed
        //                        return lowerWeight == weight ? lowerWeight : upperWeight;
        //                    }
        //                    else
        //                    {
        //                        // Interpolate the landing speed
        //                        double lowerSpeed = GetSpeedForWeight(lowerWeight, );
        //                        double upperSpeed = GetSpeedForWeight(upperWeight);

        //                        double interpolationFactor =
        //                            (double)(weight - lowerWeight) / (upperWeight - lowerWeight);
        //                        double interpolatedSpeed = lowerSpeed + interpolationFactor * (upperSpeed - lowerSpeed);

        //                        return interpolatedSpeed;
        //                    }
        //                }
        //                else
        //                {
        //                    // Handle the case where weight is outside the provided range
        //                    throw new Exception("Weight is outside the range of available data.");
        //                }
        //            }
        //        }
        //    }
        //}
        //private static double GetSpeedForWeight(double weight, bool flapDown)
        //{

        //    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SQLiteCommand command = new SQLiteCommand(connection))
        //        {
        //            command.CommandText = "SELECT Weight, FlapDown, FlapUp FROM LandingSpeeds WHERE Weight <= @Weight ORDER BY Weight DESC LIMIT 2";
        //            command.Parameters.AddWithValue("@Weight", (int)weight);

        //            using (SQLiteDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    int lowerWeight = reader.GetInt32(0);
        //                    int lowerFlapDownSpeed = reader.GetInt32(1);
        //                    int lowerFlapUpSpeed = reader.GetInt32(2);

        //                    if (lowerWeight == weight)
        //                    {
        //                        return lowerFlapDownSpeed; // Exact match, return FlapDown speed
        //                    }

        //                    if (reader.Read())
        //                    {
        //                        int upperWeight = reader.GetInt32(0);
        //                        int upperFlapDownSpeed = reader.GetInt32(1);
        //                        int upperFlapUpSpeed = reader.GetInt32(2);

        //                        // Perform linear interpolation between two closest weights
        //                        double interpolationFactor = (double)(weight - lowerWeight) / (upperWeight - lowerWeight);
        //                        double interpolatedFlapDownSpeed = lowerFlapDownSpeed + interpolationFactor * (upperFlapDownSpeed - lowerFlapDownSpeed);
        //                        double interpolatedFlaUpSpeed = lowerFlapUpSpeed + interpolationFactor * (upperFlapUpSpeed - lowerFlapUpSpeed);
        //                        var interpolatedFlapSpeed = flapDown ? interpolatedFlapDownSpeed : interpolatedFlaUpSpeed;
        //                        return interpolatedFlapSpeed;
        //                    }
        //                }

        //                // Handle the case where weight is outside the range of available data
        //                throw new Exception("Weight is outside the range of available data.");
        //            }
        //        }
        //    }
        //}
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
                        }

                        // Handle the case where weight is outside the range of available data
                        throw new Exception("Weight is outside the range of available data.");
                    }
                }
            }
        }
    }
}
