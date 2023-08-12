namespace F_15E_Strike_Eagle_Performance_Calculator;

public class Station
{
    public Station(string stationName, string? storeName = "", int storeWeight = 0, double storeDragIndex = 0.0,
        int storeQuantity = 0)
    {
        StationName = stationName;
        StoreName = storeName;
        StoreWeight = storeWeight;
        StationDragIndex = storeDragIndex * storeQuantity;
        StoreQuantity = storeQuantity;
        StationWeight = storeWeight * storeQuantity;
        ValidateFuel();
    }

    public string StationName { get; set; }
    public string? StoreName { get; set; }
    public int StoreWeight { get; set; }
    public double StationDragIndex { get; set; }

    public int StoreQuantity { get; set; }
    public int StationWeight { get; set; }

    public void SetStore(string? storeName, int storeWeight, double storeDragIndex, int storeQuantity)
    {
        StoreName = storeName;
        StoreWeight = storeWeight;
        StationDragIndex = storeDragIndex * storeQuantity;
        StoreQuantity = storeQuantity;
        StationWeight = storeWeight * storeQuantity;
        ValidateFuel();
    }

    private void ValidateFuel()
    {
        if (StationName == "STA2")
        {
            if (!StoreName.Contains("610") && F15EStrikeEagle.Station2Fuel != 0) F15EStrikeEagle.Station2Fuel = 0;
        }
        else if (StationName == "STA5")
        {
            if (!StoreName.Contains("610") && F15EStrikeEagle.Station5Fuel != 0) F15EStrikeEagle.Station5Fuel = 0;
        }
        else if (StationName == "STA8")
        {
            if (!StoreName.Contains("610") && F15EStrikeEagle.Station8Fuel != 0) F15EStrikeEagle.Station8Fuel = 0;
        }
    }
}