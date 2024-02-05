using F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class MissionLegUserControl : UserControl
{
    private bool Lcft;
    private bool RCft;

    private bool Station2;
    private bool Station5;
    private bool Station8;

    public MissionLegUserControl()
    {
        InitializeComponent();

    }

    public MissionLegs MissionLeg { get; set; }
    public event FuelPlanner.MissionLegsUpdatedEventHandler MissionLegsUpdated;

    public void BindData()
    {
        LegIdValueLabel.DataBindings.Add("Text", MissionLeg, "Id");
        WaypointFromNameLabel.DataBindings.Add("Text", MissionLeg.FromWaypoint, "Name");
        WaypointToNameLabel.DataBindings.Add("Text", MissionLeg.ToWaypoint, "Name");
        SpeedTexbox.DataBindings.Add("Text", MissionLeg, "LegSpeed", true, DataSourceUpdateMode.OnPropertyChanged);
        LegDistanceValueLabel.DataBindings.Add("Text", MissionLeg, "LegDistance");
        AltitudeTextbox.DataBindings.Add("Text", MissionLeg, "LegAltitude", true,
            DataSourceUpdateMode.OnPropertyChanged);
        FuelUsedValueLabel.DataBindings.Add("Text", MissionLeg, "LegFuel", true,
            DataSourceUpdateMode.OnPropertyChanged);
        label3.DataBindings.Add("Text", MissionLeg, "LegStartAircraftWeight", true,
            DataSourceUpdateMode.OnPropertyChanged);
        label4.DataBindings.Add("Text", MissionLeg, "LegEndAircraftWeight", true,
            DataSourceUpdateMode.OnPropertyChanged);
        FuelRemLabel.DataBindings.Add("Text", MissionLeg, "LegFuelRemainEnd", true,
            DataSourceUpdateMode.OnPropertyChanged);
        DelaytextBox.DataBindings.Add("Text", MissionLeg, "LegDelay", true,
            DataSourceUpdateMode.OnPropertyChanged);
        if (MissionLeg.LegTarget) buttonStores.Visible = true;
    }

    private void SpeedTexbox_Leave(object sender, EventArgs e)
    {
        try
        {
            var a = Convert.ToInt32(SpeedTexbox.Text);
            if (a is > 359 and < 601)
            {
                MissionLeg.LegSpeed = a;
                RecalculateFuel();
            }
            else
            {
                SpeedTexbox.Text = MissionLeg.LegSpeed.ToString();
            }
        }
        catch
        {
            SpeedTexbox.Text = MissionLeg.LegSpeed.ToString();
        }
    }

    private void AltitudeTextbox_Leave(object sender, EventArgs e)
    {
        try
        {
            var a = Convert.ToInt32(AltitudeTextbox.Text);

            if (a is > -1 and < 45001)
            {
                MissionLeg.LegAltitude = a;
                RecalculateFuel();
            }
            else
            {
                AltitudeTextbox.Text = MissionLeg.LegAltitude.ToString();
            }
        }
        catch
        {
            AltitudeTextbox.Text = MissionLeg.LegAltitude.ToString();
        }
    }

    public void updateFuelUi()
    {
        //MissionLeg.LegEndAircraftWeight = 1000; 
    }

    private void RecalculateFuel()
    {
        // Calculate fuel based on updated values
        var newFuel = MissionPlanner.CalculateLegFuel(MissionLeg);

        // Update the MissionLeg object with the new fuel value
        MissionLeg.LegFuel = newFuel;
        MissionLeg.LegEndAircraftWeight = MissionLeg.LegStartAircraftWeight - newFuel + MissionLeg.LegFuelAdded;
        OnMissionLegsUpdated();
    }

    protected virtual void OnMissionLegsUpdated()
    {
        MissionLegsUpdated?.Invoke(this, EventArgs.Empty);
    }

    private void checkBoxAAR_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxAAR.Checked)
        {
            AARtextBox.Enabled = true;
        }
        else
        {
            AARtextBox.Text = "0";
            MissionLeg.LegFuelAdded = 0;
            AARtextBox.Enabled = false;
            RecalculateFuel();
        }
    }

    private void AARtextBox_Leave(object sender, EventArgs e)
    {
        try
        {
            var a = Convert.ToInt32(AARtextBox.Text);
            var max = F15EStrikeEagle.MaximumFuel + 1;
            if (a > 0 && a < max)
            {
                MissionLeg.LegFuelAdded = a;
                RecalculateFuel();
            }
            else
            {
                MissionLeg.LegFuelAdded = 0;
                AARtextBox.Text = MissionLeg.LegFuelAdded.ToString();
            }
        }
        catch
        {
            MissionLeg.LegFuelAdded = 0;
            AARtextBox.Text = MissionLeg.LegFuelAdded.ToString();
        }
    }

    private void DelaytextBox_Leave(object sender, EventArgs e)
    {
        try
        {
            var a = Convert.ToInt32(DelaytextBox.Text);
            if (a > 0 && a < 61)
            {
                MissionLeg.LegDelay = a;
                RecalculateFuel();
            }
            else
            {
                MissionLeg.LegDelay = 0;
                DelaytextBox.Text = MissionLeg.LegDelay.ToString();
            }
        }
        catch
        {
            MissionLeg.LegDelay = 0;
            DelaytextBox.Text = MissionLeg.LegDelay.ToString();
        }
    }

    private void buttonStores_Click(object sender, EventArgs e)
    {
        var stores = new StoresEmployment(Station2, Lcft, Station5, RCft, Station8);
        var result = stores.ShowDialog();

        if (result == DialogResult.OK)
        {
            Station8 = stores.Station8;
            Station5 = stores.Station5;
            Station2 = stores.Station2;
            RCft = stores.RightCft;
            Lcft = stores.LeftCft;
            var drag = stores.DragIndexRemoved;
            var weight = stores.WeightRemoved;
            MissionLeg.LegDragIndexRemoved = drag;
            MissionLeg.LegPayloadReleased = (int)weight;
            RecalculateFuel();
        }
    }

    private void AltitudeTextbox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // Call the Leave event of the control
            AltitudeTextbox_Leave(this, EventArgs.Empty);
        }
    }

    private void SpeedTexbox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SpeedTexbox_Leave(this, EventArgs.Empty);
        }
    }

    private void DelaytextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            DelaytextBox_Leave(this, EventArgs.Empty);
        }
    }

    private void AARtextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            AARtextBox_Leave(this, EventArgs.Empty);
        }
    }
}