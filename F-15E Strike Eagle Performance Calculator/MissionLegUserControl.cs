using F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class MissionLegUserControl : UserControl
{
    private bool _lcft;
    private bool _rCft;

    private bool _station2;
    private bool _station5;
    private bool _station8;

    public MissionLegUserControl()
    {
        InitializeComponent();
        FuelBurnTt.SetToolTip(FuelUsedValueLabel, "This is your total fuel used on this leg in Lbs");
        AltTt.SetToolTip(AltitudeLabelName, "Valid data: 0-45000ft");
        SpeedTt.SetToolTip(SpdLabel, "Valid data: 360-600 KTAS");
        DelayTt.SetToolTip(labelDelay, "Valid data: 0-60 Min");
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
        if (MissionLeg.Id == 1)
        {
            FuelBurnTt.SetToolTip(FuelUsedValueLabel, "This is your total fuel used on this leg in Lbs with 1488Lbs added for Startup, Taxi and Takeoff");

        }
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

    public void UpdateFuelUi()
    {
        //MissionLeg.LegEndAircraftWeight = 1000; 
    }

    private void RecalculateFuel()
    {
        // Calculate fuel based on updated values
        var newFuel = MissionPlanner.CalculateLegFuel(MissionLeg);

        // Update the MissionLeg object with the new fuel value
        MissionLeg.LegFuel = newFuel.calculatedValue;
        MissionLeg.LegFuelFlow = newFuel.poundPerHour;
        MissionLeg.LegEndAircraftWeight = MissionLeg.LegStartAircraftWeight - (int)MissionLeg.LegFuel + MissionLeg.LegFuelAdded;
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
        var stores = new StoresEmployment(_station2, _lcft, _station5, _rCft, _station8);
        var result = stores.ShowDialog();

        if (result == DialogResult.OK)
        {
            _station8 = stores.Station8;
            _station5 = stores.Station5;
            _station2 = stores.Station2;
            _rCft = stores.RightCft;
            _lcft = stores.LeftCft;
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