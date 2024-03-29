﻿namespace F_15E_Strike_Eagle_Performance_Calculator.Imports;

// DTCImport myDeserializedClass = JsonConvert.DeserializeObject<DTCImport>(myJsonResponse);
public class DTCImport
{
    public string? Aircraft { get; set; }
    public object? Upload { get; set; }
    public object? WaypointsCapture { get; set; }
    public Route? RouteA { get; set; } = new();
    public Route? RouteB { get; set; } = new();
    public Route? RouteC { get; set; } = new();
    public object? Radios { get; set; }
    public object? Displays { get; set; }
    public object? SmartWeapons { get; set; }
    public object? Misc { get; set; }
    public int? Version { get; set; }
}

public class Route
{
    public List<Waypoint> Waypoints { get; set; } = new();
}

public class Waypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }
    public int Mea { get; set; }
    public int Ktas { get; set; }
    public int Activity { get; set; }
}