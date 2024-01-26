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
                    store.Id = Convert.ToInt32(reader["ID"]);
                    store.Item = reader["Item"].ToString();
                    store.Weight = Convert.ToInt32(reader["Weight"]);
                    store.DragIndexCl = reader["DragIndex-CL"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CL"]);
                    store.DragIndexWing = reader["DragIndex-Wing"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-Wing"]);
                    store.DragIndexCftNoBomborTankWing = reader["DragIndex-CFT(NoBomborTankWing)"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CFT(NoBomborTankWing)"]);
                    store.DragIndexCft = reader["DragIndex-CFT"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CFT"]);
                    store.DragIndexClNoCfta2GStores = reader["DragIndex-CL(NoCFTA2GStores)"] == DBNull.Value
                        ? null
                        : Convert.ToDouble(reader["DragIndex-CL(NoCFTA2GStores)"]);
                    string categoryType = reader["Category"].ToString() ?? string.Empty;
                    store.Description = reader["Description"].ToString();
                    store.Sta2A = Convert.IsDBNull(reader["STA2A"]) ? 0 : Convert.ToInt32(reader["STA2A"]);
                    store.Sta2 = Convert.IsDBNull(reader["STA2"]) ? 0 : Convert.ToInt32(reader["STA2"]);
                    store.Sta2B = Convert.IsDBNull(reader["STA2B"]) ? 0 : Convert.ToInt32(reader["STA2B"]);
                    store.Lcft = Convert.IsDBNull(reader["LCFT"]) ? 0 : Convert.ToInt32(reader["LCFT"]);
                    store.Ltp = Convert.IsDBNull(reader["LTP"]) ? 0 : Convert.ToInt32(reader["LTP"]);
                    store.Sta5 = Convert.IsDBNull(reader["STA5"]) ? 0 : Convert.ToInt32(reader["STA5"]);
                    store.Lnp = Convert.IsDBNull(reader["LNP"]) ? 0 : Convert.ToInt32(reader["LNP"]);
                    store.Rcft = Convert.IsDBNull(reader["RCFT"]) ? 0 : Convert.ToInt32(reader["RCFT"]);
                    store.Sta8A = Convert.IsDBNull(reader["STA8A"]) ? 0 : Convert.ToInt32(reader["STA8A"]);
                    store.Sta8 = Convert.IsDBNull(reader["STA8"]) ? 0 : Convert.ToInt32(reader["STA8"]);
                    store.Sta8B = Convert.IsDBNull(reader["STA8B"]) ? 0 : Convert.ToInt32(reader["STA8B"]);
                    store.Category = categoryType switch
                    {
                        "Air to Air Missiles" => CategoryType.AirToAirMissiles,
                        "Pylons, Launchers and Adaptors" => CategoryType.PylonsLaunchersAdaptors,
                        "General Purpose Weapons" => CategoryType.GeneralPurposeWeapons,
                        "Pods" => CategoryType.Pods,
                        "Guided Weapons" => CategoryType.GuidedWeapons,
                        "Dispensers/Rockets" => CategoryType.DispensersRockets,
                        "Fuel Tanks" => CategoryType.FuelTanks,
                        _ => CategoryType.Unknown
                    };
                    data.Add(store);
                }
            }
        }

        connection.Close();

        return data;
    }
}