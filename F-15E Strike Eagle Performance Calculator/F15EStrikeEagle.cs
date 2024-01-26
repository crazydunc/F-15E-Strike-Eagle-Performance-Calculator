namespace F_15E_Strike_Eagle_Performance_Calculator;

public static class F15EStrikeEagle
{
    public enum DragOption
    {
        NoWingStores,
        WingStores
    }
    public static int EmptyWeight = 34600 + 4386 + 430; // Empty Weight + 2 * -5 CFTs + 2 Crew. 
    public static int GrossWeight = EmptyWeight;
    public static double BasicDragIndex = 21.3;
    public static double TotalDragIndex = BasicDragIndex;
    public static int InternalFuel { get; set; } = 12915 + 9352; // Internal + CFT
    public static int PayloadWeight { get; set; }
    public static int TotalFuel { get; set; } = InternalFuel;
    public static int Station2Fuel { get; set; } = 0;
    public static int Station5Fuel { get; set; } = 0;
    public static int Station8Fuel { get; set; } = 0;
    public static int InternalGunAmmo { get; set; } = 289;
    public static int LateralImbalance { get; set; }
    public static Station Station2A { get; set; } = new("STA2A");
    public static Station Station2 { get; set; } = new("STA2");
    public static Station Station2B { get; set; } = new("STA2B");
    public static Station LeftCft { get; set; } = new("LCFT");
    public static Station Ltp { get; set; } = new("LTP");
    public static Station Station5 { get; set; } = new("STA5");
    public static Station Lnp { get; set; } = new("LNP");
    public static Station RightCft { get; set; } = new("RCFT");
    public static Station Station8A { get; set; } = new("STA8A");
    public static Station Station8 { get; set; } = new("STA8");
    public static Station Station8B { get; set; } = new("STA8B");

    public static void Calculate()
    {
        Main.UpdateDragIndexForAll();
        TotalFuel = CalculateTotalFuel();
        GrossWeight = CalculateGrossWeight();
        PayloadWeight = GrossWeight - TotalFuel;
        TotalDragIndex = CalculateDragIndex();
        var leftWing = CalculateLeftWing();
        var rightWing = CalculateRightWing();
        LateralImbalance = rightWing - leftWing;
    }

    private static int CalculateGrossWeight()
    {
        var weight = EmptyWeight + InternalGunAmmo + Station2A.StationWeight + Station2.StationWeight +
                     Station2B.StationWeight + LeftCft.StationWeight + Ltp.StationWeight + Station5.StationWeight +
                     Lnp.StationWeight + RightCft.StationWeight + Station8A.StationWeight + Station8.StationWeight +
                     Station8B.StationWeight + TotalFuel;


        return weight;
    }

    private static int CalculateLeftWing()
    {
        var weight = Station2A.StationWeight + Station2.StationWeight +
                     Station2B.StationWeight + LeftCft.StationWeight + Ltp.StationWeight + Station2Fuel;


        return weight;
    }

    private static int CalculateRightWing()
    {
        var weight = Lnp.StationWeight + RightCft.StationWeight + Station8A.StationWeight + Station8.StationWeight +
                     Station8B.StationWeight + Station8Fuel;


        return weight;
    }

    private static double CalculateDragIndex()
    {
        var dragIndex = BasicDragIndex + Station2A.StationDragIndex + Station2.StationDragIndex +
                        Station2B.StationDragIndex + LeftCft.StationDragIndex + Ltp.StationDragIndex +
                        Station5.StationDragIndex +
                        Lnp.StationDragIndex + RightCft.StationDragIndex + Station8A.StationDragIndex +
                        Station8.StationDragIndex +
                        Station8B.StationDragIndex;


        return Math.Round(dragIndex, 2);
    }

    private static int CalculateTotalFuel()
    {
        var fuel = InternalFuel;
        if (Station2.StoreName.Contains("610")) fuel += Station2Fuel;
        if (Station5.StoreName.Contains("610")) fuel += Station5Fuel;
        if (Station8.StoreName.Contains("610")) fuel += Station8Fuel;
        return fuel;
    }
}