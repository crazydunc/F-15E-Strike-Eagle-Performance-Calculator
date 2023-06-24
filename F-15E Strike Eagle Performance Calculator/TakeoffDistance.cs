using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public static class TakeoffDistance
    {

        public static double Calculate(double oat, double grossWeight, double runwayElevation)
        {
            string livDBLoc = Worker.ReplaceExtraslashes("C:\\Users\\crazy\\Desktop\\F15EPerformance.db");
            string connectionString = "Data Source = " + livDBLoc + ";";

            double distance1 = 0;
            double distance2 = 0;
            double interpolationFactorOAT = 0;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"SELECT OAT, Distance FROM TakeoffDistance WHERE OAT < @oat AND GrossWeight < @grossWeight AND Elevation < @elevation 
                                        ORDER BY OAT DESC, GrossWeight DESC, Elevation DESC LIMIT 2;";
                    command.Parameters.AddWithValue("@oat", oat.ToString());
                    command.Parameters.AddWithValue("@grossWeight", grossWeight.ToString());
                    command.Parameters.AddWithValue("@elevation", runwayElevation.ToString());

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            distance1 = Convert.ToDouble(reader["Distance"]);
                        }

                        if (reader.Read())
                        {
                            distance2 = Convert.ToDouble(reader["Distance"]);
                            double oat1 = Convert.ToDouble(reader["OAT"]);

                            // Calculate the interpolation factor based on OAT
                            interpolationFactorOAT = (oat - oat1) / (oat - oat1 + 1);
                        }
                    } //test
                }
                var filteredDistanceCommand = new SQLiteCommand(connection);
                filteredDistanceCommand.CommandText = @"SELECT GrossWeight, Distance FROM TakeoffDistance WHERE GrossWeight <= @grossWeight AND Elevation < @elevation 
                                        ORDER BY GrossWeight DESC LIMIT 2;";
                filteredDistanceCommand.Parameters.AddWithValue("@grossWeight", grossWeight.ToString());
                filteredDistanceCommand.Parameters.AddWithValue("@elevation", runwayElevation.ToString());

                using (var weightReader = filteredDistanceCommand.ExecuteReader())
                {
                    if (weightReader.Read())
                    {
                        var distance3 = Convert.ToDouble(weightReader["Distance"]);

                        if (weightReader.Read())
                        {
                            var distance4 = Convert.ToDouble(weightReader["Distance"]);

                            var interpolationFactorWeight = (grossWeight - Convert.ToDouble(weightReader["GrossWeight"])) /
                                                            (Convert.ToDouble(weightReader["GrossWeight"]) - Convert.ToDouble(weightReader["GrossWeight"]));

                            var interpolatedDistanceWeight = distance3 + (distance4 - distance3) * interpolationFactorWeight;

                            var interpolatedDistanceOAT = distance1 + (distance2 - distance1) * interpolationFactorOAT;

                            // Perform linear interpolation for elevation
                            var interpolatedDistance = interpolatedDistanceOAT +
                                                       (interpolatedDistanceWeight - interpolatedDistanceOAT) * interpolationFactorWeight;

                            return interpolatedDistance;
                        }
                        
                    }
                }
            }

            return 0; // Default value if no data is found
        }
    }
}
