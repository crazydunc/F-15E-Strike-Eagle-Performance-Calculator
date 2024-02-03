namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

internal class WaypointConversion
{
    public static double WaypointCalculateDistance(string lat1, string lon1, string lat2, string lon2)
    {
        var lat1Decimal = Worker.ConvertToDecimalDegrees(lat1);
        var lon1Decimal = Worker.ConvertToDecimalDegrees(lon1);
        var lat2Decimal = Worker.ConvertToDecimalDegrees(lat2);
        var lon2Decimal = Worker.ConvertToDecimalDegrees(lon2);

        const double earthRadiusNauticalMiles = 3440.065; // Earth's mean radius in nautical miles

        var dLat = Worker.ToRadians(lat2Decimal - lat1Decimal);
        var dLon = Worker.ToRadians(lon2Decimal - lon1Decimal);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Worker.ToRadians(lat1Decimal)) * Math.Cos(Worker.ToRadians(lat2Decimal)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return earthRadiusNauticalMiles * c;
    }
}