namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

internal class MissionDataCard
{
    public List<MissionLegs> MissionLegs { get; set; }
    public double MissionDistance { get; set; }
    public int TotalRouteFuel { get; set; }
    public int TotalFuelLoad { get; set; }
    public int RecommendedTakeOffFuel { get; set; }
    public double JokerFuel { get; set; }
    public double BingoFuel { get; set; } = 6800;
    public double AAROnload { get; set; }
    public bool StoresEmployed { get; set; } = false;
    public DateTime EstimatedEnrouteTime { get; set; }
    public int LandingWeight { get; set; }

    public void ExportMissionData()
    {

    }
}