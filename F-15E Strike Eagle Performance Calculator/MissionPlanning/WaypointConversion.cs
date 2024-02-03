using System.Text.RegularExpressions;

namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

internal class WaypointConversion
{
    public static double WaypointCalculateDistance(string lat1, string lon1, string lat2, string lon2)
    {
        double lat1Decimal;
        double lon1Decimal;
        double lat2Decimal;
        double lon2Decimal;

        if (!IsDecimalDegrees(lat1))
        {
            lat1Decimal = ConvertToDecimalDegrees(lat1);
            lon1Decimal = ConvertToDecimalDegrees(lon1);
            lat2Decimal = ConvertToDecimalDegrees(lat2);
            lon2Decimal = ConvertToDecimalDegrees(lon2);
        }
        else
        {
            lat1Decimal = Convert.ToDouble(lat1);
            lon1Decimal = Convert.ToDouble(lon1);
            lat2Decimal = Convert.ToDouble(lat2);
            lon2Decimal = Convert.ToDouble(lon2);
        }
        const double earthRadiusNauticalMiles = 3440.065; // Earth's mean radius in nautical miles

        var dLat = Worker.ToRadians(lat2Decimal - lat1Decimal);
        var dLon = Worker.ToRadians(lon2Decimal - lon1Decimal);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Worker.ToRadians(lat1Decimal)) * Math.Cos(Worker.ToRadians(lat2Decimal)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return earthRadiusNauticalMiles * c;
    }
    private static double ConvertToDecimalDegrees(string input)
    {
        var parts = input.Split(new[] { ' ', '°', '\'', '’' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 3)
        {
            var direction = parts[0];
            var degrees = int.Parse(parts[1]);
            var minutes = double.Parse(parts[2]);

            var decimalDegrees = degrees + minutes / 60.0;

            return direction == "S" || direction == "W" ? -decimalDegrees : decimalDegrees;
        }

        throw new ArgumentException("Invalid input format");
    }
    private static bool IsDecimalDegrees(string value)
    {

        var pattern = @"^-?\d+(\.\d+)?$";

        return Regex.IsMatch(value, pattern);
    }
}