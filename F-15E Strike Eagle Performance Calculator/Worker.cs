using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public static class Worker
    {
        /// <summary>
        /// Linear Interpolation of weights to derive Speed. 
        /// </summary>
        /// <param name="weightLow">Weight data from below target</param>
        /// <param name="speedLow">Speed data from below target</param>
        /// <param name="weightHigh">Weight data from above target</param>
        /// <param name="speedHigh">Speed data from above target</param>
        /// <param name="targetSpeed">Interpolated Speed value</param>
        /// <returns></returns>
        public static double Interpolate(double weightLow, double speedLow, double weightHigh, double speedHigh, double targetSpeed)
        {
            // Perform linear interpolation
            var slope = (speedHigh - speedLow) / (weightHigh - weightLow);
            var interpolatedY = speedLow + slope * (targetSpeed - weightLow);

            return interpolatedY;
        }
        public static double InterpolateNearestNeighbor(List<double> x, List<double> y, double targetX)
        {
            int nearestIndex = FindNearestIndex(x, targetX);

            //if (nearestIndex == x.Count - 1 || nearestIndex == 0)
            //{
            //    If the nearest index is the first or last index, we cannot perform interpolation
            //    return y[nearestIndex];
            //}

            double x0 = x[nearestIndex];
            double x1 = x[nearestIndex + 1];
            double y0 = y[nearestIndex];
            double y1 = y[nearestIndex + 1];

            double interpolatedValue = y0 + (targetX - x0) * (y1 - y0) / (x1 - x0);
            double roundedValue = Math.Ceiling(interpolatedValue);

            return roundedValue;
        }
        public static int FindNearestIndex(List<double> list, double target)
        {
            int nearestIndex = 0;
            double nearestDifference = double.MaxValue;

            for (int i = 0; i < list.Count; i++)
            {
                double difference = Math.Abs(list[i] - target);

                if (difference < nearestDifference)
                {
                    nearestIndex = i;
                    nearestDifference = difference;
                }
            }

            return nearestIndex;
        }
        public static List<double> GetClosestDataPoints(SQLiteConnection connection, string speedColumnName, double targetWeight, int count, int centreGravity, int thrustSetting)
        {
            string query = $"SELECT GrossWeight, {speedColumnName} FROM TOSpeeds WHERE CG = @centreGravity AND Thrust = @thrustSetting ORDER BY ABS(GrossWeight - @targetWeight) ASC LIMIT {count}";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@targetWeight", targetWeight);
                command.Parameters.AddWithValue("@centreGravity", centreGravity);
                command.Parameters.AddWithValue("@thrustSetting", thrustSetting);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    List<double> dataPoints = new List<double>();
                    while (reader.Read())
                    {
                        double speed = reader.GetDouble(1);
                        dataPoints.Add(speed);
                    }

                    return dataPoints;
                }
            }
        }
        public static string ReplaceExtraslashes(string filepath)
        {
            if (filepath.Contains("\\\\")) filepath = filepath.Replace("\\\\", "\\");

            return filepath;
        }

    }
}
