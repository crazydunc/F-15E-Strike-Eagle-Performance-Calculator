using System.Data.SQLite;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public static class StoresManagement
{
    public static List<Stores> LoadStoresInfo()
    {
        var data = new List<Stores>();
        var dbLoc = Worker.ReplaceExtraSlashes(AppDomain.CurrentDomain.BaseDirectory + "\\F15EPerformance.db");
        var connectionString = "Data Source = " + dbLoc + ";";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();

        const string query = "SELECT * FROM STALoading";

        using (var command = new SQLiteCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var store = new Stores();
                    store.Id = Convert.ToInt32(reader["ID"], FuelPlanner.StandardCulture);
                    store.Item = reader["Item"].ToString();
                    store.Weight = Convert.ToInt32(reader["Weight"], FuelPlanner.StandardCulture);
                    store.DragIndexCl = reader["DragIndex-CL"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CL"], FuelPlanner.StandardCulture);
                    store.DragIndexWing = reader["DragIndex-Wing"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-Wing"], FuelPlanner.StandardCulture);
                    store.DragIndexCftNoBombOrTankWing = reader["DragIndex-CFT(NoBomborTankWing)"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CFT(NoBomborTankWing)"], FuelPlanner.StandardCulture);
                    store.DragIndexCft = reader["DragIndex-CFT"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CFT"], FuelPlanner.StandardCulture);
                    store.DragIndexClNoCftA2GStores = reader["DragIndex-CL(NoCFTA2GStores)"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CL(NoCFTA2GStores)"]);
                    var categoryType = reader["Category"].ToString() ?? string.Empty;
                    store.Description = reader["Description"].ToString();
                    store.Sta2A = Convert.IsDBNull(reader["STA2A"]) ? 0 : Convert.ToInt32(reader["STA2A"], FuelPlanner.StandardCulture);
                    store.Sta2 = Convert.IsDBNull(reader["STA2"]) ? 0 : Convert.ToInt32(reader["STA2"], FuelPlanner.StandardCulture);
                    store.Sta2B = Convert.IsDBNull(reader["STA2B"]) ? 0 : Convert.ToInt32(reader["STA2B"], FuelPlanner.StandardCulture);
                    store.Lcft = Convert.IsDBNull(reader["LCFT"]) ? 0 : Convert.ToInt32(reader["LCFT"], FuelPlanner.StandardCulture);
                    store.Ltp = Convert.IsDBNull(reader["LTP"]) ? 0 : Convert.ToInt32(reader["LTP"], FuelPlanner.StandardCulture);
                    store.Sta5 = Convert.IsDBNull(reader["STA5"]) ? 0 : Convert.ToInt32(reader["STA5"], FuelPlanner.StandardCulture);
                    store.Lnp = Convert.IsDBNull(reader["LNP"]) ? 0 : Convert.ToInt32(reader["LNP"], FuelPlanner.StandardCulture);
                    store.Rcft = Convert.IsDBNull(reader["RCFT"]) ? 0 : Convert.ToInt32(reader["RCFT"], FuelPlanner.StandardCulture);
                    store.Sta8A = Convert.IsDBNull(reader["STA8A"]) ? 0 : Convert.ToInt32(reader["STA8A"], FuelPlanner.StandardCulture);
                    store.Sta8 = Convert.IsDBNull(reader["STA8"]) ? 0 : Convert.ToInt32(reader["STA8"], FuelPlanner.StandardCulture);
                    store.Sta8B = Convert.IsDBNull(reader["STA8B"]) ? 0 : Convert.ToInt32(reader["STA8B"], FuelPlanner.StandardCulture);
                    store.Category = categoryType switch
                    {
                        "Air-to-Air Missiles" => CategoryType.AirToAirMissiles,
                        "Pylons, Launchers and Adaptors" => CategoryType.PylonsLaunchersAdaptors,
                        "General Purpose Weapons" => CategoryType.GeneralPurposeWeapons,
                        "Pods" => CategoryType.Pods,
                        "Guided Weapons" => CategoryType.GuidedWeapons,
                        "Dispensers/Rockets" => CategoryType.DispensersRockets,
                        "Fuel Tanks" => CategoryType.FuelTanks,
                        "Empty" => CategoryType.Empty,
                        _ => CategoryType.Unknown
                    };
                    data.Add(store);
                }
            }
        }

        connection.Close();

        return data;
    }

    public static double? DragIndexValidation(double? dragIndex, Stores selectedData)
    {
        if (dragIndex == null && selectedData.Category != CategoryType.Empty)
        {
            dragIndex = selectedData.DragIndexWing;
            if (dragIndex == null && selectedData.Category != CategoryType.Empty) dragIndex = selectedData.DragIndexCl;
        }

        return dragIndex;
    }

    public static double? FuelTankDragIndex(Station station, double? dragIndex)
    {
        //double? dragIndex = 0;

        if (station.StationName == "STA8")
        {
            if (F15EStrikeEagle.Station8.StoreName.Contains("610") && F15EStrikeEagle.RightCft.StoreQuantity > 3)
                // CFI-O
                dragIndex = 12.3;
            else if (F15EStrikeEagle.Station8.StoreName.Contains("610") &&
                     F15EStrikeEagle.RightCft.StoreQuantity <= 3 &&
                     F15EStrikeEagle.RightCft.StoreCategory != CategoryType.AirToAirMissiles &&
                     F15EStrikeEagle.RightCft.StoreCategory != CategoryType.Empty)
                //CFT-I
                dragIndex = 8.2;
            else if (F15EStrikeEagle.Station8.StoreName.Contains("610") &&
                     (F15EStrikeEagle.RightCft.StoreCategory == CategoryType.AirToAirMissiles ||
                      F15EStrikeEagle.RightCft.StoreCategory == CategoryType.Empty))
                //CFT
                dragIndex = 6;
        }
        else if (station.StationName == "STA2")
        {
            if (F15EStrikeEagle.Station2.StoreName.Contains("610") && F15EStrikeEagle.LeftCft.StoreQuantity > 3)
                // CFI-O
                dragIndex = 12.3;
            else if (F15EStrikeEagle.Station2.StoreName.Contains("610") &&
                     F15EStrikeEagle.LeftCft.StoreQuantity <= 3 &&
                     F15EStrikeEagle.LeftCft.StoreCategory != CategoryType.AirToAirMissiles &&
                     F15EStrikeEagle.LeftCft.StoreCategory != CategoryType.Empty)
                //CFT-I
                dragIndex = 8.2;
            else if (F15EStrikeEagle.Station2.StoreName.Contains("610") &&
                     (F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.AirToAirMissiles ||
                      F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.Empty))
                //CFT
                dragIndex = 6;
        }

        return dragIndex;
    }

    public static void UpdateDragIndexForAll()
    {
        foreach (var station in Main.StationList)
        {
            var dragIndexToUse = station.GetDragIndexToUse(F15EStrikeEagle.Station2.StoreCategory,
                F15EStrikeEagle.Station8.StoreCategory);
            double? dragIndex = 0;
            if (station.StationName != "STA5")
                switch (dragIndexToUse)
                {
                    case F15EStrikeEagle.DragOption.NoWingStores:
                        dragIndex = station.StationStore.DragIndexCftNoBombOrTankWing;
                        dragIndex = DragIndexValidation(dragIndex, station.StationStore);
                        break;
                    case F15EStrikeEagle.DragOption.WingStores:
                        dragIndex = station.StationStore.DragIndexCft;
                        dragIndex = DragIndexValidation(dragIndex, station.StationStore);

                        break;
                    default:
                        dragIndex = 0;
                        break;
                }
            else
                dragIndex = station.StationStore.DragIndexCl;

            if (station.StationStore.Item.Contains("LANTIRN"))
                if (F15EStrikeEagle.RightCft.StoreCategory == CategoryType.Empty &&
                    F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.Empty)
                {
                    if (station.StationStore.Item.Contains("AAQ-13")) dragIndex = 8.3;
                    if (station.StationStore.Item.Contains("AAQ-14")) dragIndex = 6.5;
                }

            if (station.StationName is "STA2" or "STA8") dragIndex = FuelTankDragIndex(station, dragIndex);

            var qty = 0;
            station.SetStore(station.StationStore.Item, station.StationStore.Weight, dragIndex ?? 0,
                station.StoreQuantity, station.StationStore.Category);
        }
    }
}