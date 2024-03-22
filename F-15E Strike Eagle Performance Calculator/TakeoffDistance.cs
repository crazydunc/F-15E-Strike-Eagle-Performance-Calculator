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
    public static double CalculateNew(double weightInput, double temperatureInput, double altitudeInput, int thrust)
    {
        var dbLoc = Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        var connectionString = "Data Source = " + dbLoc + ";";
        List<DataPoint?> data = new();

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText =
                    @"SELECT ID, GrossWeight, OAT, Elevation, Distance FROM TakeoffDistance WHERE Thrust = @thrust";

                command.Parameters.AddWithValue("@thrust", thrust);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dataPoint = new DataPoint();
                        dataPoint.Weight = Convert.ToDouble(reader["GrossWeight"].ToString(), FuelPlanner.StandardCulture);
                        dataPoint.Temperature = Convert.ToDouble(reader["OAT"].ToString(), FuelPlanner.StandardCulture);
                        dataPoint.Altitude = Convert.ToDouble(reader["Elevation"].ToString(), FuelPlanner.StandardCulture);
                        dataPoint.Distance = Convert.ToDouble(reader["Distance"].ToString(), FuelPlanner.StandardCulture);
                        data.Add(dataPoint);
                    }
                }
            }
        }

        var nearestPoint1 = FindNearestDataPoint(data, weightInput, temperatureInput, altitudeInput);
        var nearestPoint2 =
            FindNearestDataPoint(data, weightInput, temperatureInput, altitudeInput, nearestPoint1);

        var weightFactor = nearestPoint1 != null && nearestPoint2 != null &&
                           nearestPoint2.Weight - nearestPoint1.Weight != 0
            ? (weightInput - nearestPoint1.Weight) / (nearestPoint2.Weight - nearestPoint1.Weight)
            : 0;

        var oatFactor = nearestPoint1 != null && nearestPoint2 != null &&
                        nearestPoint2.Temperature - nearestPoint1.Temperature != 0
            ? (temperatureInput - nearestPoint1.Temperature) / (nearestPoint2.Temperature - nearestPoint1.Temperature)
            : 0;

        var altitudeFactor = nearestPoint1 != null && nearestPoint2 != null &&
                             nearestPoint2.Altitude - nearestPoint1.Altitude != 0
            ? (altitudeInput - nearestPoint1.Altitude) / (nearestPoint2.Altitude - nearestPoint1.Altitude)
            : 0;


        if (nearestPoint1 != null && nearestPoint2 != null)
        {
            var interpolatedDistance = nearestPoint1.Distance +
                                       weightFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                       oatFactor * (nearestPoint2.Distance - nearestPoint1.Distance) +
                                       altitudeFactor * (nearestPoint2.Distance - nearestPoint1.Distance);


            return Worker.RoundDown(interpolatedDistance);
        }

        return 0;
    }

    /// <summary>
    ///     Finds nearest data point and returns it.
    /// </summary>
    /// <param name="data">List of Data points</param>
    /// <param name="weight">User entered Weight</param>
    /// <param name="oat">user entered OAT</param>
    /// <param name="altitude">user entered Altitude</param>
    /// <param name="exclude">Data entry to be excluded from search</param>
    /// <returns>instance of the nearest non excluded data point from List data</returns>
    private static DataPoint? FindNearestDataPoint(List<DataPoint?> data, double weight, double oat, double altitude,
        DataPoint? exclude = null)
    {
        var minDistance = double.MaxValue;
        DataPoint? nearestPoint = null;


        foreach (var dataPoint in data)
        {
            if (dataPoint != null && exclude != null && dataPoint.Weight == exclude.Weight &&
                dataPoint.Temperature == exclude.Temperature &&
                dataPoint.Altitude == exclude.Altitude)
                continue;

            if (dataPoint != null)
            {
                var distance = Math.Abs(weight - dataPoint.Weight) + Math.Abs(oat - dataPoint.Temperature) +
                               Math.Abs(altitude - dataPoint.Altitude);

                if (!(distance < minDistance)) continue;
                minDistance = distance;
                nearestPoint = dataPoint;
            }
        }

        return nearestPoint;
    }
}