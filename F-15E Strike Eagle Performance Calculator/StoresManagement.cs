using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    internal class StoresManagement
    {
        public List<Stores> LoadDataFromSqLiteDatabase(string databasePath)
        {
            var data = new List<Stores>();

            using var connection = new SQLiteConnection($"Data Source={databasePath};");
            connection.Open();

            const string query = "SELECT * FROM Stores";

            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var store = new Stores();
                        store.Id = Convert.ToInt32(reader["ID"]);
                        store.Item = reader["Item"].ToString();
                        store.Weight = Convert.ToDecimal(reader["Weight"]);
                        store.DragIndexCl = reader["DragIndex-CL"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["DragIndex-CL"]);
                        store.DragIndexWing = reader["DragIndex-Wing"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["DragIndex-Wing"]);
                        store.DragIndexCftNoBomborTankWing = reader["DragIndex-CFT(NoBomborTankWing)"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["DragIndex-CFT(NoBomborTankWing)"]);
                        store.DragIndexCft = reader["DragIndex-CFT"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["DragIndex-CFT"]);
                        store.DragIndexClNoCfta2GStores = reader["DragIndex-CL(NoCFTA2GStores)"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["DragIndex-CL(NoCFTA2GStores)"]);
                        store.Category = (CategoryType)Enum.Parse(typeof(CategoryType), reader["Category"].ToString() ?? string.Empty);
                        store.Description = reader["Description"].ToString();
                        store.Sta2A = Convert.ToInt32(reader["STA2A"]);
                        store.Sta2 = Convert.ToInt32(reader["STA2"]);
                        store.Sta2B = Convert.ToInt32(reader["STA2B"]);
                        store.LcftO = Convert.ToInt32(reader["LCFT-O"]);
                        store.LcftI = Convert.ToInt32(reader["LCFT-I"]);
                        store.Ltp = Convert.ToInt32(reader["LTP"]);
                        store.Sta5 = Convert.ToInt32(reader["STA5"]);
                        store.Lnp = Convert.ToInt32(reader["LNP"]);
                        store.RcftI = Convert.ToInt32(reader["RCFT-I"]);
                        store.RcftO = Convert.ToInt32(reader["RCFT-O"]);
                        store.Sta8A = Convert.ToInt32(reader["STA8A"]);
                        store.Sta8 = Convert.ToInt32(reader["STA8"]);
                        store.Sta8B = Convert.ToInt32(reader["STA8B"]);

                        data.Add(store);
                    }
                }
            }

            connection.Close();

            return data;
        }


    }
}
