namespace F_15E_Strike_Eagle_Performance_Calculator;

internal class ExportSelectedLoadout
{
    private static List<string> ExportLoadout = new();

    public void ExportData()
    {
        //Exports Loadout to .txt

        ExportLoadout = new List<string>();
        ExportLoadout.Add("*****************************************");
        ExportLoadout.Add("**          F-15E Strike Eagle         **");
        ExportLoadout.Add("**         loadout exported from       **");
        ExportLoadout.Add("**          F15E Perf Calculator       **");
        ExportLoadout.Add("*****************************************");
        ExportLoadout.Add(" ");
        ExportLoadout.Add(DateTime.UtcNow.ToString());
        ExportLoadout.Add(" ");
        ExportLoadout.Add($"Basic Airframe Weight (Aircraft + 2 x CFTs + Crew): {F15EStrikeEagle.EmptyWeight} Lbs");
        ExportLoadout.Add($"Basic Airframe Drag Index:                          {F15EStrikeEagle.BasicDragIndex}");
        ExportLoadout.Add($"Payload Weight:                                     {F15EStrikeEagle.PayloadWeight} Lbs");
        ExportLoadout.Add($"Payload Drag Index:                                 {F15EStrikeEagle.PayloadDragIndex}");
        ExportLoadout.Add($"Total Drag Index:                                   {F15EStrikeEagle.TotalDragIndex}");
        ExportLoadout.Add($"Internal Fuel:                                      {F15EStrikeEagle.InternalFuel}  Lbs");
        ExportLoadout.Add(
            $"External Fuel:                                      {F15EStrikeEagle.Station2Fuel + F15EStrikeEagle.Station5Fuel + F15EStrikeEagle.Station8Fuel}  Lbs");
        ExportLoadout.Add(
            $"Lateral Imbalance:                                  {F15EStrikeEagle.LateralImbalance}  Lbs");
        ExportLoadout.Add($"Total Fuel:                                         {F15EStrikeEagle.TotalFuel} Lbs");
        ExportLoadout.Add($"Gross Weight:                                       {F15EStrikeEagle.GrossWeight} Lbs");
        ExportLoadout.Add("*******************************");
        ExportLoadout.Add($"Internal Gun Ammo: {F15EStrikeEagle.InternalGunAmmo} Lbs");
        ExportLoadout.Add("*******************************");
        WriteStationInfo(F15EStrikeEagle.Station2A);
        WriteStationInfo(F15EStrikeEagle.Station2);
        WriteStationInfo(F15EStrikeEagle.Station2B);
        WriteStationInfo(F15EStrikeEagle.LeftCft);
        WriteStationInfo(F15EStrikeEagle.Ltp);
        WriteStationInfo(F15EStrikeEagle.Station5);
        WriteStationInfo(F15EStrikeEagle.Lnp);
        WriteStationInfo(F15EStrikeEagle.RightCft);
        WriteStationInfo(F15EStrikeEagle.Station8B);
        WriteStationInfo(F15EStrikeEagle.Station8);
        WriteStationInfo(F15EStrikeEagle.Station8A);
        ExportLoadout.Add("**************ENDS*************");
        ExportLoadout.Add("*******************************");
        Log.WriteLog("Exported Loadout to Textfile");
        Log.WriteExport(ExportLoadout);
    }

    private static void WriteStationInfo(Station station)
    {
        ExportLoadout.Add(station.StationName);
        if (station.StoreCategory == CategoryType.Empty)
        {
            ExportLoadout.Add("Empty");
            ExportLoadout.Add("*******************************");

            return;
        }

        if (station.PylonLauncher != string.Empty)
            ExportLoadout.Add($"Store: {station.StoreName} with a {station.PylonLauncher}");
        else
            ExportLoadout.Add($"Store: {station.StoreName}");
        ExportLoadout.Add($"Category: {station.StoreCategory.ToString()}");
        ExportLoadout.Add($"Quantity: {station.StoreQuantity}");
        ExportLoadout.Add($"Drag Index: {Math.Round(station.StationDragIndex, 2)}");
        ExportLoadout.Add($"Weight: {station.StationWeight} lbs");
        if (station.StoreCategory == CategoryType.FuelTanks)
        {
            if (station.StationName == "STA2") ExportLoadout.Add($"Fuel: {F15EStrikeEagle.Station2Fuel} lbs");
            if (station.StationName == "STA5") ExportLoadout.Add($"Fuel: {F15EStrikeEagle.Station5Fuel} lbs");
            if (station.StationName == "STA8") ExportLoadout.Add($"Fuel: {F15EStrikeEagle.Station8Fuel} lbs");
        }

        ExportLoadout.Add("*******************************");
    }
}