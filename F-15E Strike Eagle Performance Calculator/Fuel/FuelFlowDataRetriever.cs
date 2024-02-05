using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public class FuelFlowDataRetriever
{
    private static readonly string dbLoc =
        Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");

    private static readonly string connectionString = "Data Source = " + dbLoc + ";";

    public double RetrieveFuelFlow(int altitude, int dragIndex, int speed, int aircraftWeight)
    {
        //Log.WriteLog("SEPC - Fuel Calculation - Input data");
        //Log.WriteLog($"Weight: {aircraftWeight}");
        //Log.WriteLog($"Speed: {speed}");
        //Log.WriteLog($"Drag Index: {dragIndex}");
        //Log.WriteLog($"Altitude: {altitude}");
        //Log.WriteLog("Input Ends \r\n");

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Step 1: Construct the SQL query
            var query = "SELECT FuelFlowPerHour FROM FuelFlowData " +
                        "WHERE Altitude = @Altitude " +
                        "AND DragIndex = @DragIndex " +
                        "AND Speed = @Speed " +
                        "AND AircraftWeight = @AircraftWeight";

            using (var command = new SQLiteCommand(query, connection))
            {
                // Step 2: Set parameter values
                command.Parameters.AddWithValue("@Altitude", altitude);
                command.Parameters.AddWithValue("@DragIndex", dragIndex);
                command.Parameters.AddWithValue("@Speed", speed);
                command.Parameters.AddWithValue("@AircraftWeight", aircraftWeight);

                // Step 3: Execute the query and retrieve the result
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Exact match found, return the fuel flow
                        var fuelFlow = Convert.ToDouble(reader["FuelFlowPerHour"]);
                        //Log.WriteLog("Exact Fuel Flow Match found");

                        return fuelFlow;
                    }

                    //Log.WriteLog("No Exact Fuel Flow Match found - QuadLinear Interpolation time");

                    var b = PerformQuadlinearInterpolation(altitude, dragIndex, speed, aircraftWeight);
                    //Log.WriteLog("FF Interpolated: " + b);
                    return b;
                }
            }
        }
    }

    private double PerformIndependentInterpolations(
        int altitude, int dragIndex, int speed, int aircraftWeight)
    {
        //Log.WriteLog("Attempting 1D Interpolates");

        var numbers = new List<int> { 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000, 80000 };
        var closestWeight = FindClosestValue(numbers, aircraftWeight);

        var interpolatedAltitude =
            Perform1DInterpolation(altitude, "Altitude", closestWeight, speed, dragIndex, altitude);
        var interpolatedDragIndex =
            Perform1DInterpolation(dragIndex, "DragIndex", closestWeight, speed, dragIndex, altitude);
        var interpolatedSpeed = Perform1DInterpolation(speed, "Speed", closestWeight, speed, dragIndex, altitude);
        double averageFuelFlow = 0;
        if (interpolatedSpeed == -1 || interpolatedDragIndex == -1 || interpolatedAltitude == -1)
        {
            if ((interpolatedSpeed == -1 && interpolatedDragIndex == -1) ||
                (interpolatedSpeed == -1 && interpolatedAltitude == -1) ||
                (interpolatedDragIndex == -1 && interpolatedAltitude == -1))
            {
                //Log.WriteLog("All 1D Interpolates Failed");


                //Log.WriteLog("Finding closest tabulated data");

                averageFuelFlow = FallbackCalculation(altitude, dragIndex, speed, closestWeight);
            }
            else if (interpolatedSpeed != -1 && interpolatedDragIndex != -1 && interpolatedAltitude == -1)
            {
                //Log.WriteLog("All 1D Alt Interpolates Failed");

                averageFuelFlow = (FallbackCalculation(altitude, dragIndex, speed, closestWeight) +
                                   interpolatedDragIndex +
                                   interpolatedSpeed) / 3.0;
            }
            else if (interpolatedSpeed != -1 && interpolatedDragIndex == -1 && interpolatedAltitude != -1)
            {
                //Log.WriteLog("All 1D Drag Interpolates Failed");

                averageFuelFlow = (FallbackCalculation(altitude, dragIndex, speed, closestWeight) +
                                   interpolatedAltitude +
                                   interpolatedSpeed) / 3.0;
            }
            else if (interpolatedSpeed == -1 && interpolatedDragIndex != -1 && interpolatedAltitude != -1)
            {
                //Log.WriteLog("All 1D Speed Interpolates Failed");

                averageFuelFlow = (FallbackCalculation(altitude, dragIndex, speed, closestWeight) +
                                   interpolatedAltitude +
                                   interpolatedDragIndex) / 3.0;
            }
        }
        else
        {
            //Log.WriteLog("All 1D Interpolates Worked shooting a 4 way average");

            // Average the interpolated values
            averageFuelFlow = (interpolatedAltitude + interpolatedDragIndex +
                               interpolatedSpeed + FallbackCalculation(altitude, dragIndex, speed, closestWeight)) /
                              4.0;
        }


        return averageFuelFlow;
    }


    private double FallbackCalculation(int altitude, int dragIndex, int speed, int aircraftWeight)
    {
        //Log.WriteLog("Final fallback step");
        var numbersSpd = new List<int> { 360, 400, 440, 480, 520, 560, 600 };
        var numbersDi = new List<int> { 0, 20, 40, 60, 80, 100, 120, 140, 160 };
        var numbersAlt = new List<int> { 0, 5000, 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000 };
        var closestSpeed = FindClosestValue(numbersSpd, speed);
        var closestDrag = FindClosestValue(numbersDi, dragIndex);
        var closestAltitude = FindClosestValue(numbersAlt, altitude);

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT FuelFlowPerHour FROM FuelFlowData " +
                        "WHERE Altitude = @Altitude " +
                        "AND DragIndex = @DragIndex " +
                        "AND Speed = @Speed " +
                        "AND AircraftWeight = @AircraftWeight";

            using (var command = new SQLiteCommand(query, connection))
            {
                // Step 2: Set parameter values
                command.Parameters.AddWithValue("@Altitude", closestAltitude);
                command.Parameters.AddWithValue("@DragIndex", closestDrag);
                command.Parameters.AddWithValue("@Speed", closestSpeed);
                command.Parameters.AddWithValue("@AircraftWeight", aircraftWeight);

                // Step 3: Execute the query and retrieve the result
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Exact match found, return the fuel flow
                        var fuelFlow = Convert.ToDouble(reader["FuelFlowPerHour"]);
                        return fuelFlow;
                    }

                    return -1;
                }
            }
        }
    }

    private double Perform1DInterpolation(int value, string columnName, int aircraftWeight, int speed, int dragIndex,
        int altitude)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            var numbersSpd = new List<int> { 360, 400, 440, 480, 520, 560, 600 };
            var numbersDi = new List<int> { 0, 20, 40, 60, 80, 100, 120, 140, 160 };
            var numbersAlt = new List<int> { 0, 5000, 10000, 15000, 20000 };
            var closestSpeed = FindClosestValue(numbersSpd, speed);
            var closestDrag = FindClosestValue(numbersDi, dragIndex);
            var closestAltitude = FindClosestValue(numbersAlt, altitude);
            connection.Open();
            var lowerBound = 0;
            var upperBound = 0;

            var query = string.Empty;

            if (columnName == "Altitude")
            {
                lowerBound = value - 5500;
                upperBound = value + 5500;
                if (upperBound > 21000)
                {
                    upperBound = 21000;
                    lowerBound = 9000;
                }

                if (lowerBound < -1000)
                {
                    lowerBound = -1000;
                    upperBound = 11000;
                }

                query = $"SELECT FuelFlowPerHour FROM FuelFlowData " +
                        $"WHERE {columnName} BETWEEN @LowerBound AND @UpperBound " +
                        $"AND AircraftWeight = @AircraftWeight " +
                        $"AND DragIndex = @DragIndex " +
                        $"AND Speed = @Speed " +
                        $"ORDER BY ABS({columnName} - @Value) LIMIT 2";
            }
            else if (columnName == "Speed")
            {
                lowerBound = value - 45;
                upperBound = value + 45;
                if (upperBound > 605)
                {
                    upperBound = 605;
                    lowerBound = 515;
                }

                if (lowerBound < 355)
                {
                    lowerBound = 355;
                    upperBound = 445;
                }

                query = $"SELECT FuelFlowPerHour FROM FuelFlowData " +
                        $"WHERE {columnName} BETWEEN @LowerBound AND @UpperBound " +
                        $"AND AircraftWeight = @AircraftWeight " +
                        $"AND DragIndex = @DragIndex " +
                        $"AND Altitude = @Altitude " +
                        $"ORDER BY ABS({columnName} - @Value) LIMIT 2";
            }
            else
            {
                lowerBound = value - 25;
                upperBound = value + 25;

                if (upperBound > 165)
                {
                    upperBound = 165;
                    lowerBound = 115;
                }

                if (lowerBound < -5)
                {
                    lowerBound = -1;
                    upperBound = 41;
                }

                query = $"SELECT FuelFlowPerHour FROM FuelFlowData " +
                        $"WHERE {columnName} BETWEEN @LowerBound AND @UpperBound " +
                        $"AND AircraftWeight = @AircraftWeight " +
                        $"AND Speed = @Speed " +
                        $"AND Altitude = @Altitude " +
                        $"ORDER BY ABS({columnName} - @Value) LIMIT 2";
            }

            // Fetch the closest data points for the specific dimension

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LowerBound", lowerBound);
                command.Parameters.AddWithValue("@UpperBound", upperBound);
                command.Parameters.AddWithValue("@Value", value);
                command.Parameters.AddWithValue("@AircraftWeight", aircraftWeight);
                command.Parameters.AddWithValue("@DragIndex", closestDrag);
                command.Parameters.AddWithValue("@Altitude", closestAltitude);
                command.Parameters.AddWithValue("@Speed", closestSpeed);

                var cornerValues = new double[2];
                var i = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cornerValues[i] = Convert.ToDouble(reader["FuelFlowPerHour"]);
                        i++;
                    }
                }

                if (i == 2)
                {
                    // Calculate interpolation ratio
                    var ratio = (value - lowerBound) / (double)(upperBound - lowerBound);

                    // Perform linear interpolation for the specific dimension
                    var interpolatedValue = LinearInterpolation(
                        ratio, cornerValues[0], cornerValues[1]);

                    return interpolatedValue;
                }

                return -1;
            }
        }
    }

    private double LinearInterpolation(double ratio, double lowerValue, double upperValue)
    {
        return lowerValue * (1 - ratio) + upperValue * ratio;
    }

    private double PerformQuadlinearInterpolation(
        int altitude, int dragIndex, int speed, int aircraftWeight)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Define bounds and parameters for quadlinear interpolation
            var lowerAltitude = altitude - 5500;
            var upperAltitude = altitude + 5500;
            var lowerDragIndex = dragIndex - 25;
            var upperDragIndex = dragIndex + 25;
            var lowerSpeed = speed - 25;
            var upperSpeed = speed + 25;
            var lowerAircraftWeight = aircraftWeight - 5500;
            var upperAircraftWeight = aircraftWeight + 5500;

            // Fetch the 16 corner values for quadlinear interpolation
            var query = "SELECT FuelFlowPerHour FROM FuelFlowData " +
                        "WHERE Altitude BETWEEN @LowerAltitude AND @UpperAltitude " +
                        "AND DragIndex BETWEEN @LowerDragIndex AND @UpperDragIndex " +
                        "AND Speed BETWEEN @LowerSpeed AND @UpperSpeed " +
                        "AND AircraftWeight BETWEEN @LowerAircraftWeight AND @UpperAircraftWeight";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LowerAltitude", lowerAltitude);
                command.Parameters.AddWithValue("@UpperAltitude", upperAltitude);
                command.Parameters.AddWithValue("@LowerDragIndex", lowerDragIndex);
                command.Parameters.AddWithValue("@UpperDragIndex", upperDragIndex);
                command.Parameters.AddWithValue("@LowerSpeed", lowerSpeed);
                command.Parameters.AddWithValue("@UpperSpeed", upperSpeed);
                command.Parameters.AddWithValue("@LowerAircraftWeight", lowerAircraftWeight);
                command.Parameters.AddWithValue("@UpperAircraftWeight", upperAircraftWeight);

                var cornerValues = new double[16];
                var i = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read() && i < 16)
                    {
                        cornerValues[i] = Convert.ToDouble(reader["FuelFlowPerHour"]);
                        i++;
                    }
                }

                if (i == 16)
                {
                    // Calculate interpolation ratios for all four dimensions
                    var xRatio = (altitude - lowerAltitude) / (double)(upperAltitude - lowerAltitude) +
                                 (double)altitude / 5000 / 100;
                    var yRatio = (dragIndex - lowerDragIndex) / (double)(upperDragIndex - lowerDragIndex) +
                                 (double)dragIndex / 20 / 100;
                    var zRatio = (speed - lowerSpeed) / (double)(upperSpeed - lowerSpeed) +
                                 (double)speed / 400 / 100;
                    var wRatio =
                        (aircraftWeight - lowerAircraftWeight) / (double)(upperAircraftWeight - lowerAircraftWeight) +
                        (double)aircraftWeight / 70000 / 100;

                    // Perform quadlinear interpolation with all four dimensions
                    var interpolatedFuelFlow = QuadlinearInterpolation(
                        xRatio, yRatio, zRatio, wRatio,
                        cornerValues[0], cornerValues[1], cornerValues[2], cornerValues[3],
                        cornerValues[4], cornerValues[5], cornerValues[6], cornerValues[7],
                        cornerValues[8], cornerValues[9], cornerValues[10], cornerValues[11],
                        cornerValues[12], cornerValues[13], cornerValues[14], cornerValues[15]);

                    return interpolatedFuelFlow;
                }

                //Log.WriteLog("QuadLinear failed - only " + i + " corner points returned");
            }
        }

        return PerformIndependentInterpolations(
            altitude, dragIndex, speed, aircraftWeight);
    }

    private double QuadlinearInterpolation(
        double xRatio, double yRatio, double zRatio, double wRatio,
        double f0000, double f0001, double f0010, double f0011,
        double f0100, double f0101, double f0110, double f0111,
        double f1000, double f1001, double f1010, double f1011,
        double f1100, double f1101, double f1110, double f1111)
    {
        // Quadlinear interpolation in four dimensions formula
        var c0000 = f0000 * (1 - xRatio) + f1000 * xRatio;
        var c0001 = f0001 * (1 - xRatio) + f1001 * xRatio;
        var c0010 = f0010 * (1 - xRatio) + f1010 * xRatio;
        var c0011 = f0011 * (1 - xRatio) + f1011 * xRatio;
        var c0100 = f0100 * (1 - xRatio) + f1100 * xRatio;
        var c0101 = f0101 * (1 - xRatio) + f1101 * xRatio;
        var c0110 = f0110 * (1 - xRatio) + f1110 * xRatio;
        var c0111 = f0111 * (1 - xRatio) + f1111 * xRatio;

        var c00 = c0000 * (1 - yRatio) + c0100 * yRatio;
        var c01 = c0001 * (1 - yRatio) + c0101 * yRatio;
        var c10 = c0010 * (1 - yRatio) + c0110 * yRatio;
        var c11 = c0011 * (1 - yRatio) + c0111 * yRatio;

        var c0 = c00 * (1 - zRatio) + c10 * zRatio;
        var c1 = c01 * (1 - zRatio) + c11 * zRatio;

        var result = c0 * (1 - wRatio) + c1 * wRatio;

        return result;
    }

    private static int FindClosestValue(List<int> numbers, int a)
    {
        var closestValue = int.MinValue;
        var minDifference = int.MaxValue;

        foreach (var number in numbers)
        {
            var difference = Math.Abs(number - a);

            if (difference < minDifference || (difference == minDifference && number > closestValue))
            {
                minDifference = difference;
                closestValue = number;
            }
        }

        return closestValue;
    }

    public string FindClosestValidData( int weight, int dragIndex, int altitude, int speed)
    {
        var numbersSpd = new List<int> { 360, 400, 440, 480, 520, 560, 600 };
        var numbersDi = new List<int> { 0, 20, 40, 60, 80, 100, 120, 140, 160 };
        var numbersAlt = new List<int> { 0, 5000, 10000, 15000, 20000, 25000, 30000, 35000, 40000, 45000 };
        var numbersWeight = new List<int> { 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000, 80000 };

        //var closestSpeed = FindClosestValue(numbersSpd, speed);
        var closestDrag = FindClosestValue(numbersDi, dragIndex);
        //var closestAltitude = FindClosestValue(numbersAlt, altitude);
        var closestWeight = FindClosestValue(numbersWeight, weight);

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var query = @"
                SELECT *
                FROM FuelFlowData
                WHERE AircraftWeight = @Weight
                    AND DragIndex = @DragIndex
                    AND FuelFlowPerHour <> 0
                ORDER BY
                    ABS(Altitude - @Altitude) ASC,
                    ABS(Speed - @Speed) ASC
                LIMIT 1;";

            using (var command = new SQLiteCommand(query, connection))
            {
                // Step 2: Set parameter values
                command.Parameters.AddWithValue("@Weight", closestWeight);
                command.Parameters.AddWithValue("@DragIndex", closestDrag);
                command.Parameters.AddWithValue("@Altitude", altitude);
                command.Parameters.AddWithValue("@Speed", speed);

                // Step 3: Execute the query and retrieve the result
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Exact match found, return the fuel flow
                        var alt = reader["Altitude"];
                        var spd = reader["Speed"];
                        var pph = reader["FuelFlowPerHour"];
                        
                        return $"Calculation Failure: Suggested Profile: {alt} ft - Speed: {spd} KTAS";
                    }

                    return $"Calculation Failure: Unable to find valid data - Please select a lower altitude/speed.";
                }
            }
        }
    }
}