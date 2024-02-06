using System.Reflection;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class Main : Form
{
    private const string Pounds = " Lbs";
    public static readonly List<Station> StationList = new();

    public static List<Stores> LoadedData = new();

    //private static List<string> ExportLoadout = new();
    private readonly bool _loaded;
    private Loadout _loadout;
    private Stores emptyStores = new();

    public Main()
    {
        LoadedData = StoresManagement.LoadStoresInfo();

        InitializeComponent();
        ResizeBegin += (s, e) => { SuspendLayout(); };
        ResizeEnd += (s, e) => { ResumeLayout(true); };
        Version version = Assembly.GetEntryAssembly().GetName().Version;
        labelCopy.Text = $@"© Duncan MacKellar 2024 - v{version}";
        Text = $@"Strike Eagle Performance Calculator -  v{version}";

    }

    private void Main_Load(object sender, EventArgs e)
    {
    }

    private void buttonHome_Click(object sender, EventArgs e)
    {
        fuelPlanner1.Visible = false;
        loadout1.Visible = true;
        loadout1.BringToFront();
    }

    private void buttonFuel_Click(object sender, EventArgs e)
    {
        fuelPlanner1.Visible = true;
        loadout1.Visible = false;
        fuelPlanner1.BringToFront();
    }
}