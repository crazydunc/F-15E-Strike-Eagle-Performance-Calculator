using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    class DataPoint
    {
        public double Weight { get; set; }
        public double Temperature { get; set; }
        public double Altitude { get; set; }
        public double Distance { get; set; }
    }
    public static class TakeoffDistance
    {
        public static double CalculateNew(double weightInput, double temperatureInput, double altitudeInput)
        {
            var livDBLoc = Worker.ReplaceExtraslashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
            var connectionString = "Data Source = " + livDBLoc + ";";
            List<DataPoint> dataset = new List<DataPoint>();
            //{
            //    new DataPoint { Weight = 45000, Temperature = 0, Altitude = 0, Distance = 1200 },
            //    // Add the rest of your data points here...
            //};
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                        @"SELECT ID, GrossWeight, OAT, Elevation, Distance FROM TakeoffDistance";


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data = new DataPoint();
                            data.Weight = Convert.ToDouble(reader["GrossWeight"].ToString());
                            data.Temperature = Convert.ToDouble(reader["OAT"].ToString());
                            data.Altitude = Convert.ToDouble(reader["Elevation"].ToString()); ;
                            data.Distance = Convert.ToDouble(reader["Distance"].ToString());
                            dataset.Add(data);

                        }


                    }
                }
            }

            // User inputs


            // Calculate the weight differences
            DataPoint nearestPoint1 = FindNearestDataPoint(dataset, weightInput, temperatureInput, altitudeInput);
            DataPoint nearestPoint2 = FindNearestDataPoint(dataset, weightInput, temperatureInput, altitudeInput, nearestPoint1);

            double weightFactor = (nearestPoint2.Weight - nearestPoint1.Weight) != 0 ? (weightInput - nearestPoint1.Weight) / (nearestPoint2.Weight - nearestPoint1.Weight) : 0;

            // Calculate the OAT factors
            double oatFactor = (nearestPoint2.Temperature - nearestPoint1.Temperature) != 0 ? (temperatureInput - nearestPoint1.Temperature) / (nearestPoint2.Temperature - nearestPoint1.Temperature) : 0;

            // Calculate the altitude factors
            double altitudeFactor = (nearestPoint2.Altitude - nearestPoint1.Altitude) != 0 ? (altitudeInput - nearestPoint1.Altitude) / (nearestPoint2.Altitude - nearestPoint1.Altitude) : 0;


            // Interpolate the distance

            double interpolatedDistance = nearestPoint1.Distance +
                                          weightFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                          oatFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                          altitudeFactor * (nearestPoint2.Distance - nearestPoint1.Distance);


            // Display the interpolated distance
            return RoundDown(interpolatedDistance);

        }
        static DataPoint FindNearestDataPoint(List<DataPoint> data, double weight, double oat, double altitude, DataPoint exclude = null)
        {
            double minDistance = double.MaxValue;
            DataPoint nearestPoint = null;


            foreach (DataPoint dataPoint in data)
            {
                if (exclude != null && dataPoint.Weight == exclude.Weight && dataPoint.Temperature == exclude.Temperature && dataPoint.Altitude == exclude.Altitude)
                    continue;

                double distance = Math.Abs(weight - dataPoint.Weight) + Math.Abs(oat - dataPoint.Temperature) + Math.Abs(altitude - dataPoint.Altitude);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPoint = dataPoint;
                }
            }

            return nearestPoint;
        }
         static double RoundDown(double value)
        {
            var roundedDown = Math.Floor(value / 10) * 10;

            return roundedDown;
        }
        static double InterpolateDistance(List<DataPoint> dataset, double weight, double temperature, double altitude)
        {
            double sumOfWeightsTimesDistances = 0;
            double sumOfWeights = 0;

            foreach (var dataPoint in dataset)
            {
                // Calculate the distance between the given values and the data point values
                var weightDistance = Math.Abs(weight - dataPoint.Weight);
                var temperatureDistance = Math.Abs(temperature - dataPoint.Temperature);
                var altitudeDistance = Math.Abs(altitude - dataPoint.Altitude);

                // Calculate the weight based on the inverse of the distances
                var weightFactor = 1.0 / (weightDistance + 1);
                var temperatureFactor = 1.0 / (temperatureDistance + 1);
                var altitudeFactor = 1.0 / (altitudeDistance + 1);

                // Calculate the weighted distance
                var weightedDistance = weightFactor * temperatureFactor * altitudeFactor * dataPoint.Distance;

                // Accumulate the weighted distance and weights
                sumOfWeightsTimesDistances += weightedDistance;
                sumOfWeights += weightFactor * temperatureFactor * altitudeFactor;
            }

            // Perform the interpolation
            var interpolatedDistance = sumOfWeightsTimesDistances / sumOfWeights;

            return interpolatedDistance;
        }
        //public static double Calculate(double oat, double grossWeight, double runwayElevation)
        //{
        //    string livDBLoc = Worker.ReplaceExtraslashes(AppDomain.CurrentDomain.BaseDirectory+"\\F15EPerformance.db");
        //    string connectionString = "Data Source = " + livDBLoc + ";";

        //    double distance1 = 0;
        //    double distance2 = 0;
        //    double interpolationFactorOAT = 0;

        //    //using (var connection = new SQLiteConnection(connectionString))
        //    //{
        //    //    connection.Open();

        //    //    using (var command = new SQLiteCommand(connection))
        //    //    {
        //    //        command.CommandText = @"SELECT OAT, Distance FROM TakeoffDistance WHERE OAT < @oat AND GrossWeight < @grossWeight AND Elevation < @elevation 
        //    //                            ORDER BY OAT DESC, GrossWeight DESC, Elevation DESC LIMIT 2;";
        //    //        command.Parameters.AddWithValue("@oat", oat.ToString());
        //    //        command.Parameters.AddWithValue("@grossWeight", grossWeight.ToString());
        //    //        command.Parameters.AddWithValue("@elevation", runwayElevation.ToString());

        //    //        using (var reader = command.ExecuteReader())
        //    //        {
        //    //            if (reader.Read())
        //    //            {
        //    //                distance1 = Convert.ToDouble(reader["Distance"]);
        //    //            }

        //    //            if (reader.Read())
        //    //            {
        //    //                distance2 = Convert.ToDouble(reader["Distance"]);
        //    //                double oat1 = Convert.ToDouble(reader["OAT"]);

        //    //                // Calculate the interpolation factor based on OAT
        //    //                interpolationFactorOAT = (oat - oat1) / (oat - oat1 + 1);
        //    //            }
        //    //        } //test
        //    //    }
        //    //    var filteredDistanceCommand = new SQLiteCommand(connection);
        //    //    filteredDistanceCommand.CommandText = @"SELECT GrossWeight, Distance FROM TakeoffDistance WHERE GrossWeight <= @grossWeight AND Elevation < @elevation 
        //    //                            ORDER BY GrossWeight DESC LIMIT 2;";
        //    //    filteredDistanceCommand.Parameters.AddWithValue("@grossWeight", grossWeight.ToString());
        //    //    filteredDistanceCommand.Parameters.AddWithValue("@elevation", runwayElevation.ToString());

        //    //    using (var weightReader = filteredDistanceCommand.ExecuteReader())
        //    //    {
        //    //        if (weightReader.Read())
        //    //        {
        //    //            var distance3 = Convert.ToDouble(weightReader["Distance"]);

        //    //            if (weightReader.Read()) //teste
        //    //            {
        //    //                var distance4 = Convert.ToDouble(weightReader["Distance"]);

        //    //                var interpolationFactorWeight = (grossWeight - Convert.ToDouble(weightReader["GrossWeight"])) /
        //    //                                                (Convert.ToDouble(weightReader["GrossWeight"]) - Convert.ToDouble(weightReader["GrossWeight"]));

        //    //                var interpolatedDistanceWeight = distance3 + (distance4 - distance3) * interpolationFactorWeight;

        //    //                var interpolatedDistanceOAT = distance1 + (distance2 - distance1) * interpolationFactorOAT;

        //    //                // Perform linear interpolation for elevation
        //    //                var interpolatedDistance = interpolatedDistanceOAT +
        //    //                                           (interpolatedDistanceWeight - interpolatedDistanceOAT) * interpolationFactorWeight;

        //    //                return interpolatedDistance;
        //    //            }

        //    //        }
        //    //    }
        //    //}


        //    return 0; // Default value if no data is found
        //}
    }
}
