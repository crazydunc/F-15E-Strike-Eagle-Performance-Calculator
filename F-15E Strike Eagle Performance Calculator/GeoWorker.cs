using System.Diagnostics;

namespace F_15E_Strike_Eagle_Performance_Calculator;

internal static class GeoWorker
{
    public static string ConvertToFormattedCoordinates(double latitude, double longitude)
    {
        var latDirection = latitude >= 0 ? 'N' : 'S';
        var lonDirection = longitude >= 0 ? 'E' : 'W';

        var absLat = Math.Abs(latitude);
        var absLon = Math.Abs(longitude);

        var latDegrees = (int)absLat;
        var latMinutes = (absLat - latDegrees) * 60;

        var lonDegrees = (int)absLon;
        var lonMinutes = (absLon - lonDegrees) * 60;

        var formattedCoordinates =
            $"{latDirection} {latDegrees:00}°{latMinutes:00.000} {lonDirection} {lonDegrees:000}°{lonMinutes:00.000}'";
        return formattedCoordinates;
    }
    public static string ConvertToFormattedLatitude(double latitude)
    {
        var latDirection = latitude >= 0 ? 'N' : 'S';

        var absLat = Math.Abs(latitude);

        var latDegrees = (int)absLat;
        var latMinutes = (absLat - latDegrees) * 60;



        var formattedCoordinates =
            $"{latDirection} {latDegrees:00}°{latMinutes:00.000}";
        return formattedCoordinates;
    }

    public static string ConvertToFormattedLongitude(double longitude)
    {
        var lonDirection = longitude >= 0 ? 'E' : 'W';

        var absLon = Math.Abs(longitude);



        var lonDegrees = (int)absLon;
        var lonMinutes = (absLon - lonDegrees) * 60;

        var formattedCoordinates =
            $"{lonDirection} {lonDegrees:000}°{lonMinutes:00.000}'";
        return formattedCoordinates;
    }

    public static int ConvertMetersToFeet(double meters)
    {
        return (int)Math.Round(meters * 3.28084d);
    }
}