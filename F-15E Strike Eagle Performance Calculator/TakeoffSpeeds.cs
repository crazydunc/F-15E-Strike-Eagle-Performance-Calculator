using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public static class TakeoffSpeeds
    {
        public static string Calculate(double targetWeight, int centreGravity, int thrustSetting)
        {
            string livDBLoc = Worker.ReplaceExtraslashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
            string connectionString = "Data Source = " + livDBLoc + ";";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                List<double> rotationWeights = Worker.GetClosestDataPoints(connection, "GrossWeight", targetWeight, 2, centreGravity, thrustSetting);

                // Retrieve the two closest weight and speed data points from the database for each speed
                Dictionary<string, List<double>> speedData = new Dictionary<string, List<double>>();
                speedData.Add("Rotation", Worker.GetClosestDataPoints(connection, "Rotation", targetWeight, 2, centreGravity, thrustSetting));
                speedData.Add("Nosewheel", Worker.GetClosestDataPoints(connection, "Nosewheel", targetWeight, 2, centreGravity, thrustSetting));
                speedData.Add("Takeoff", Worker.GetClosestDataPoints(connection, "Takeoff", targetWeight, 2, centreGravity, thrustSetting));

                // Perform interpolation for each speed
                double interpolatedRotationSpeed = Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Rotation"], targetWeight);
                double interpolatedNosewheelSpeed = Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Nosewheel"], targetWeight);
                double interpolatedTakeoffSpeed = Worker.InterpolateNearestNeighbor(rotationWeights, speedData["Takeoff"], targetWeight);

                Console.WriteLine("Interpolated Rotation Speed: " + interpolatedRotationSpeed + " KCAS");
                Console.WriteLine("Interpolated Nosewheel Speed: " + interpolatedNosewheelSpeed + " KCAS");
                Console.WriteLine("Interpolated Takeoff Speed: " + interpolatedTakeoffSpeed + " KCAS");

                return interpolatedRotationSpeed + "/" + interpolatedNosewheelSpeed + "/" + interpolatedTakeoffSpeed; 
            }
        }


    }
}
