using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator;

internal class DataPoint
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
        var dbLoc = Worker.ReplaceExtraslashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        var connectionString = "Data Source = " + dbLoc + ";";
        List<DataPoint?> data = new();
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
                        var dataPoint = new DataPoint();
                        dataPoint.Weight = Convert.ToDouble(reader["GrossWeight"].ToString());
                        dataPoint.Temperature = Convert.ToDouble(reader["OAT"].ToString());
                        dataPoint.Altitude = Convert.ToDouble(reader["Elevation"].ToString());
                        dataPoint.Distance = Convert.ToDouble(reader["Distance"].ToString());
                        data.Add(dataPoint);
                    }
                }
            }
        }

        // User inputs
        // Calculate the weight differences
        var nearestPoint1 = FindNearestDataPoint(data, weightInput, temperatureInput, altitudeInput);
        var nearestPoint2 =
            FindNearestDataPoint(data, weightInput, temperatureInput, altitudeInput, nearestPoint1);

        var weightFactor = nearestPoint1 != null && nearestPoint2 != null && nearestPoint2.Weight - nearestPoint1.Weight != 0
            ? (weightInput - nearestPoint1.Weight) / (nearestPoint2.Weight - nearestPoint1.Weight)
            : 0;

        // Calculate the OAT factors
        var oatFactor = nearestPoint1 != null && nearestPoint2 != null && nearestPoint2.Temperature - nearestPoint1.Temperature != 0
            ? (temperatureInput - nearestPoint1.Temperature) / (nearestPoint2.Temperature - nearestPoint1.Temperature)
            : 0;

        // Calculate the altitude factors
        var altitudeFactor = nearestPoint1 != null && nearestPoint2 != null && nearestPoint2.Altitude - nearestPoint1.Altitude != 0
            ? (altitudeInput - nearestPoint1.Altitude) / (nearestPoint2.Altitude - nearestPoint1.Altitude)
            : 0;


        // Interpolate the distance

        if (nearestPoint1 != null && nearestPoint2 != null)
        {
        
                var interpolatedDistance = nearestPoint1.Distance +
                                           weightFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                           oatFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                           altitudeFactor * (nearestPoint2.Distance - nearestPoint1.Distance);


            // Display the interpolated distance
            return RoundDown(interpolatedDistance);

        }

        return 0;
    }

    private static DataPoint? FindNearestDataPoint(List<DataPoint?> data, double weight, double oat, double altitude,
        DataPoint? exclude = null)
    {
        var minDistance = double.MaxValue;
        DataPoint? nearestPoint = null;


        foreach (var dataPoint in data)
        {
            if (dataPoint != null && exclude != null && dataPoint.Weight == exclude.Weight && dataPoint.Temperature == exclude.Temperature &&
                dataPoint.Altitude == exclude.Altitude)
                continue;

            if (dataPoint != null)
            {
                var distance = Math.Abs(weight - dataPoint.Weight) + Math.Abs(oat - dataPoint.Temperature) +
                               Math.Abs(altitude - dataPoint.Altitude);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPoint = dataPoint;
                }
            }
        }

        return nearestPoint;
    }

    private static double RoundDown(double value)
    {
        var roundedDown = Math.Floor(value / 10) * 10;

        return roundedDown;
    }
}