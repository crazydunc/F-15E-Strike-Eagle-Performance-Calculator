using static F_15E_Strike_Eagle_Performance_Calculator.F15EStrikeEagle;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public class Station
{
    public Station(string stationName, string? storeName = "", CategoryType storeCategory = CategoryType.Empty,
        int storeWeight = 0, double storeDragIndex = 0.0,
        int storeQuantity = 0)
    {
        StationName = stationName;
        StoreName = storeName;
        StoreCategory = storeCategory;
        StoreWeight = storeWeight;
        StationDragIndex = storeDragIndex * storeQuantity;
        StoreQuantity = storeQuantity;
        StationWeight = storeWeight * storeQuantity;
        ValidateFuel();
    }

    public string StationName { get; set; }
    public string? StoreName { get; set; }
    public CategoryType StoreCategory { get; set; }
    public int StoreWeight { get; set; }
    public double StoreDragIndex { get; set; }
    public double StationDragIndex { get; set; }
    public int StoreQuantity { get; set; }
    public int StationWeight { get; set; }
    public Stores? StationStore { get; set; }
    public string? PylonLauncher { get; set; } = string.Empty;

    public void SetStore(string? storeName, int storeWeight, double storeDragIndex, int storeQuantity,
        CategoryType storeCategory)
    {
        PylonLauncher = string.Empty;
        StoreName = storeName;
        StoreWeight = storeWeight;
        StoreCategory = storeCategory;
        StoreWeight = storeWeight;
        StoreDragIndex = storeDragIndex;
        StationDragIndex = (storeDragIndex + GetLauncherDragIndex(StoreName)) * storeQuantity;
        StoreQuantity = storeQuantity;
        StationWeight = (storeWeight + GetLauncherWeight(StoreName)) * storeQuantity;
        ValidateFuel();
    }

    public void SetStore(string? storeName, int storeWeight, double storeDragIndex, int storeQuantity,
        CategoryType storeCategory, Stores? store)
    {
        PylonLauncher = string.Empty;
        StoreName = storeName;
        StoreWeight = storeWeight;
        StoreCategory = storeCategory;
        StoreDragIndex = storeDragIndex;
        StationDragIndex = (storeDragIndex + GetLauncherDragIndex(StoreName)) * storeQuantity;
        StoreQuantity = storeQuantity;
        StationWeight = (storeWeight + GetLauncherWeight(StoreName)) * storeQuantity;
        StationStore = store;
        ValidateFuel();
    }

    public DragOption GetDragIndexToUse(CategoryType stationTwoCategory, CategoryType stationEightCategory)
    {
        return StationName switch
        {
            "LCFT" => stationTwoCategory != CategoryType.Empty ? DragOption.WingStores : DragOption.NoWingStores,
            "RCFT" => stationEightCategory != CategoryType.Empty ? DragOption.WingStores : DragOption.NoWingStores,
            _ => DragOption.NoWingStores
        };
    }

    private double GetLauncherDragIndex(string? storeName)
    {
        if (storeName.Contains("AIM-9"))
            return 1.2d; // LAU-114/A 
        if (storeName.Contains("AIM-120"))
            return 1.1d; // LAU-128/A 
        if (storeName.Contains("GBU-38") || storeName.Contains("GBU-54") ||
            storeName.Contains("GBU-31")) return 3.3d; // SUU-73/A  or SUU-59C/A 

        return 0;
    }

    private int GetLauncherWeight(string? storeName)
    {
        if (storeName.Contains("AIM-9"))
        {
            PylonLauncher = "LAU-114/A";
            return 79; // LAU-114/A 
        }

        if (storeName.Contains("AIM-120"))
        {
            PylonLauncher = "LAU-128/A";
            return 111; // LAU-128/A 
        }

        if (storeName.Contains("GBU-38") || storeName.Contains("GBU-54") || storeName.Contains("GBU-31"))
        {
            var w = StationName.Contains("STA5") ? 316 : 371; // SUU-73/A OR SUU-59C/A 
            PylonLauncher = StationName.Contains("STA5") ? "SUU-73/A with BRU-47/A" : "SUU-59C/A with BRU-47/A";
            return w;
        }

        return 0;
    }

    private void ValidateFuel()
    {
        if (StationName == "STA2")
        {
            if (!StoreName.Contains("610") && Station2Fuel != 0) Station2Fuel = 0;
        }
        else if (StationName == "STA5")
        {
            if (!StoreName.Contains("610") && Station5Fuel != 0) Station5Fuel = 0;
        }
        else if (StationName == "STA8")
        {
            if (!StoreName.Contains("610") && Station8Fuel != 0) Station8Fuel = 0;
        }
    }
}