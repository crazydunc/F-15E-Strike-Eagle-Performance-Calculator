namespace F_15E_Strike_Eagle_Performance_Calculator;

public enum CategoryType
{
    AirToAirMissiles,
    PylonsLaunchersAdaptors,
    GeneralPurposeWeapons,
    GuidedWeapons,
    DispensersRockets,
    Pods,
    FuelTanks,
    Empty,
    Unknown
}

public class Stores
{
    public int Id { get; set; }
    public string? Item { get; set; }
    public int Weight { get; set; }
    public double? DragIndexCl { get; set; }
    public double? DragIndexWing { get; set; }
    public double? DragIndexCftNoBombOrTankWing { get; set; }
    public double? DragIndexCft { get; set; }
    public double? DragIndexClNoCftA2GStores { get; set; }
    public CategoryType Category { get; set; }
    public string? Description { get; set; }
    public int Sta2A { get; set; }
    public int Sta2 { get; set; }
    public int Sta2B { get; set; }
    public int Lcft { get; set; }
    public int Ltp { get; set; }
    public int Sta5 { get; set; }
    public int Lnp { get; set; }
    public int Rcft { get; set; }
    public int Sta8A { get; set; }
    public int Sta8 { get; set; }
    public int Sta8B { get; set; }
}