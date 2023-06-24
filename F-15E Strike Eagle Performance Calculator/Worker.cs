using System.Data.SQLite;
using System.Text.RegularExpressions;

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
            var nearestIndex = FindNearestIndex(x, targetX);

            //if (nearestIndex == x.Count - 1 || nearestIndex == 0)
            //{
            //    If the nearest index is the first or last index, we cannot perform interpolation
            //    return y[nearestIndex];
            //}

            var x0 = x[nearestIndex];
            var x1 = x[nearestIndex + 1];
            var y0 = y[nearestIndex];
            var y1 = y[nearestIndex + 1];

            var interpolatedValue = y0 + (targetX - x0) * (y1 - y0) / (x1 - x0);
            var roundedValue = Math.Ceiling(interpolatedValue);

            return roundedValue;
        }
        public static int FindNearestIndex(List<double> list, double target)
        {
            var nearestIndex = 0;
            var nearestDifference = double.MaxValue;

            for (var i = 0; i < list.Count; i++)
            {
                var difference = Math.Abs(list[i] - target);

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
            var query = $"SELECT GrossWeight, {speedColumnName} FROM TOSpeeds WHERE CG = @centreGravity AND Thrust = @thrustSetting ORDER BY ABS(GrossWeight - @targetWeight) ASC LIMIT {count}";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@targetWeight", targetWeight);
                command.Parameters.AddWithValue("@centreGravity", centreGravity);
                command.Parameters.AddWithValue("@thrustSetting", thrustSetting);

                using (var reader = command.ExecuteReader())
                {
                    var dataPoints = new List<double>();
                    while (reader.Read())
                    {
                        var speed = reader.GetDouble(1);
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
        public static bool IsNumeric(string inputStr)
        {
            var regex = new Regex(@"^\d+$");
            return regex.IsMatch(inputStr);
        }
    }
}
