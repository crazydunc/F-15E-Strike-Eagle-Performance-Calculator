using System.ComponentModel;
using F_15E_Strike_Eagle_Performance_Calculator.Imports;

namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

public class MissionLegs : INotifyPropertyChanged
{
    private int _legFuelRemainEnd;
    private int _legPayloadReleased;
    private string _legRemarks;
    private int _legStartAircraftWeight;
    public int Id { get; set; }
    public Waypoint FromWaypoint { get; set; }
    public Waypoint ToWaypoint { get; set; }
    public int LegAltitude { get; set; }
    public double LegSpeed { get; set; }

    public double LegDragIndex { get; set; }

    //public double LegStartAircraftWeight { get; set; }
    public int LegStartAircraftWeight
    {
        get => _legStartAircraftWeight;
        set
        {
            if (_legStartAircraftWeight != value)
            {
                _legStartAircraftWeight = value;
                OnPropertyChanged(nameof(LegStartAircraftWeight));
            }
        }
    } // Weight at the start of the leg. Basic + Stores + Fuel not burned. 

    public int LegFuelRemainEnd
    {
        get => _legFuelRemainEnd;
        set
        {
            if (_legFuelRemainEnd != value)
            {
                _legFuelRemainEnd = value;
                OnPropertyChanged(nameof(LegFuelRemainEnd));
            }
        }
    } // Weight at the start of the leg. Basic + Stores + Fuel not burned. 

    //public int LegFuelRemainEnd { get; set; }
    public int LegEndAircraftWeight { get; set; } // Weight at the start of the leg. Basic + Stores + Fuel not burned. 
    public double LegFuel { get; set; }
    public double LegFuelFlow { get; set; }

    public int LegFuelAdded { get; set; }
    public double LegDistance { get; set; }
    public double LegDragIndexRemoved { get; set; }

    public int LegDelay { get; set; }

    public int LegPayloadReleased
    {
        get => _legPayloadReleased;
        set
        {
            if (_legPayloadReleased != value)
            {
                _legPayloadReleased = value;
                OnPropertyChanged(nameof(LegPayloadReleased));
            }
        }
    }

    public string LegRemarks
    {
        get => _legRemarks;
        set
        {
            if (_legRemarks != value)
            {
                _legRemarks = value;
                OnPropertyChanged(nameof(LegRemarks));
            }
        }
    }

    public bool LegTarget { get; set; }
    public MissionLegUserControl LegUserControl { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}