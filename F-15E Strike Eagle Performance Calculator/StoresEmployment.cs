namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class StoresEmployment : Form
{
    private double _dragRemoved;
    private double _weightRemoved;

    public StoresEmployment(bool sta2, bool lcft, bool sta5, bool rcft, bool sta8)
    {
        InitializeComponent();
        checkBoxSta8.Enabled = F15EStrikeEagle.Station8.StoreCategory == CategoryType.DispensersRockets ||
                               F15EStrikeEagle.Station8.StoreCategory == CategoryType.GeneralPurposeWeapons ||
                               F15EStrikeEagle.Station8.StoreCategory == CategoryType.GuidedWeapons;
        checkBoxRcft.Enabled = F15EStrikeEagle.RightCft.StoreCategory == CategoryType.DispensersRockets ||
                               F15EStrikeEagle.RightCft.StoreCategory == CategoryType.GeneralPurposeWeapons ||
                               F15EStrikeEagle.RightCft.StoreCategory == CategoryType.GuidedWeapons;
        checkBoxSta5.Enabled = F15EStrikeEagle.Station5.StoreCategory == CategoryType.DispensersRockets ||
                               F15EStrikeEagle.Station5.StoreCategory == CategoryType.GeneralPurposeWeapons ||
                               F15EStrikeEagle.Station5.StoreCategory == CategoryType.GuidedWeapons;
        checkBoxLcft.Enabled = F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.DispensersRockets ||
                               F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.GeneralPurposeWeapons ||
                               F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.GuidedWeapons;
        checkBoxSta2.Enabled = F15EStrikeEagle.Station2.StoreCategory == CategoryType.DispensersRockets ||
                               F15EStrikeEagle.Station2.StoreCategory == CategoryType.GeneralPurposeWeapons ||
                               F15EStrikeEagle.Station2.StoreCategory == CategoryType.GuidedWeapons;
        if (sta2) checkBoxSta2.Checked = true;
        if (rcft) checkBoxRcft.Checked = true;
        if (lcft) checkBoxLcft.Checked = true;
        if (sta5) checkBoxSta5.Checked = true;
        if (sta8) checkBoxSta8.Checked = true;
    }

    public double DragIndexRemoved { get; private set; }
    public double WeightRemoved { get; private set; }
    public bool LeftCft { get; private set; }
    public bool RightCft { get; private set; }
    public bool Station2 { get; private set; }
    public bool Station5 { get; private set; }
    public bool Station8 { get; private set; }

    private void buttonConfirm_Click(object sender, EventArgs e)
    {
        if (checkBoxSta8.Checked)
        {
            _weightRemoved += F15EStrikeEagle.Station8.StoreWeight * F15EStrikeEagle.Station8.StoreQuantity;
            _dragRemoved += F15EStrikeEagle.Station8.StoreDragIndex * F15EStrikeEagle.Station8.StoreQuantity;
            Station8 = true;
        }

        if (checkBoxRcft.Checked)
        {
            _weightRemoved += F15EStrikeEagle.RightCft.StoreWeight * F15EStrikeEagle.RightCft.StoreQuantity;
            _dragRemoved += F15EStrikeEagle.RightCft.StoreDragIndex * F15EStrikeEagle.RightCft.StoreQuantity;
            RightCft = true;
        }

        if (checkBoxSta5.Checked)
        {
            _weightRemoved += F15EStrikeEagle.Station5.StoreWeight * F15EStrikeEagle.Station5.StoreQuantity;
            _dragRemoved += F15EStrikeEagle.Station5.StoreDragIndex * F15EStrikeEagle.Station5.StoreQuantity;
            Station5 = true;
        }

        if (checkBoxLcft.Checked)
        {
            _weightRemoved += F15EStrikeEagle.LeftCft.StoreWeight * F15EStrikeEagle.LeftCft.StoreQuantity;
            _dragRemoved += F15EStrikeEagle.LeftCft.StoreDragIndex * F15EStrikeEagle.LeftCft.StoreQuantity;
            LeftCft = true;
        }

        if (checkBoxSta2.Checked)
        {
            _weightRemoved += F15EStrikeEagle.Station2.StoreWeight * F15EStrikeEagle.Station2.StoreQuantity;
            _dragRemoved += F15EStrikeEagle.Station2.StoreDragIndex * F15EStrikeEagle.Station2.StoreQuantity;
            Station2 = true;
        }

        DragIndexRemoved = _dragRemoved;
        WeightRemoved = _weightRemoved;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        WeightRemoved = 0;
        DragIndexRemoved = 0;
        DialogResult = DialogResult.Cancel;
        Close();
    }
}