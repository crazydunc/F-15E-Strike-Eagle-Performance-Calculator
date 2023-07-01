using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public enum CategoryType
    {
        AirToAirMissiles,
        PylonsLaunchersAdaptors,
        GeneralPurposeWeapons,
        GuidedWeapons,
        DispensersRockets,
        Pods,
        FuelTanks,
        Unknown
    }
    internal class Stores
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Weight { get; set; }
        public decimal? DragIndexCl { get; set; }
        public decimal? DragIndexWing { get; set; }
        public decimal? DragIndexCftNoBomborTankWing { get; set; }
        public decimal? DragIndexCft { get; set; }
        public decimal? DragIndexClNoCfta2GStores { get; set; }
        public CategoryType Category { get; set; }
        public string Description { get; set; }
        public int Sta2A { get; set; }
        public int Sta2 { get; set; }
        public int Sta2B { get; set; }
        public int LcftO { get; set; }
        public int LcftI { get; set; }
        public int Ltp { get; set; }
        public int Sta5 { get; set; }
        public int Lnp { get; set; }
        public int RcftI { get; set; }
        public int RcftO { get; set; }
        public int Sta8A { get; set; }
        public int Sta8 { get; set; }
        public int Sta8B { get; set; }
    }
}
