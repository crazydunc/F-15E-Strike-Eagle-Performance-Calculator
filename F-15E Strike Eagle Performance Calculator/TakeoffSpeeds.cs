using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public static class TakeoffSpeeds
{
    public static string Calculate(double targetWeight, int centreGravity, int thrustSetting)
    {
        var livDbLoc = Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        var connectionString = "Data Source = " + livDbLoc + ";";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        var rotationWeights =
            Worker.GetClosestDataPoints(connection, "GrossWeight", targetWeight, 2, centreGravity, thrustSetting);

        // Retrieve the two closest weight and speed data points from the database for each speed
        var speedData = new Dictionary<string, List<double>>();
        speedData.Add("Rotation",
            Worker.GetClosestDataPoints(connection, "Rotation", targetWeight, 2, centreGravity, thrustSetting));
        speedData.Add("Nosewheel",
            Worker.GetClosestDataPoints(connection, "Nosewheel", targetWeight, 2, centreGravity, thrustSetting));
        speedData.Add("Takeoff",
            Worker.GetClosestDataPoints(connection, "Takeoff", targetWeight, 2, centreGravity, thrustSetting));

        // Perform interpolation for each speed
        var interpolatedRotationSpeed =
            Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Rotation"], targetWeight);
        var interpolatedNosewheelSpeed =
            Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Nosewheel"], targetWeight);
        var interpolatedTakeoffSpeed =
            Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Takeoff"], targetWeight);

        return interpolatedRotationSpeed + "/" + interpolatedNosewheelSpeed + "/" + interpolatedTakeoffSpeed;
    }
}