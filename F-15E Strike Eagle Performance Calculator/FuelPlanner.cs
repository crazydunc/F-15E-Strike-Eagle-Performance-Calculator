using F_15E_Strike_Eagle_Performance_Calculator.DTC;
using F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;
using Newtonsoft.Json;

namespace F_15E_Strike_Eagle_Performance_Calculator;

//Normal Recovery Fuel 2500lb. 
//Minimum Fuel - 1900lb
//Emerg Fuel - 800lb. 
//30min Reserve = 4300lb
//Start up/Taxi = 800lb. 
public partial class FuelPlanner : UserControl
{
    public delegate void MissionLegsUpdatedEventHandler(object sender, EventArgs e);

    public FuelPlanner()
    {
        InitializeComponent();
    }

    // Define the event handler method in your main form
    private void MissionLegsUpdatedHandler(object sender, EventArgs e)
    {
        var endWeight = F15EStrikeEagle.GrossWeight;
        var fuelWeight = F15EStrikeEagle.TotalFuel;
        var dragIndex = F15EStrikeEagle.TotalDragIndex;
        MissionPlanner.CurrentMissionDataCard.AAROnload = 0;
        MissionPlanner.CurrentMissionDataCard.TotalRouteFuel = 0;

        foreach (var leg in MissionPlanner.CurrentMissionDataCard.MissionLegs)
        {
            leg.LegDragIndex = dragIndex - leg.LegDragIndexRemoved;
            leg.LegStartAircraftWeight = endWeight;
            var calculateLegFuel = MissionPlanner.CalculateLegFuel(leg);
            if (leg.Id == 1) calculateLegFuel += 1488; // Startup and Taxi
            leg.LegFuel = calculateLegFuel;
            leg.LegEndAircraftWeight = leg.LegStartAircraftWeight - calculateLegFuel;
            endWeight = leg.LegStartAircraftWeight - calculateLegFuel + leg.LegFuelAdded - leg.LegPayloadReleased;
            leg.LegFuelRemainEnd = fuelWeight - (int)leg.LegFuel + leg.LegFuelAdded;
            fuelWeight = leg.LegFuelRemainEnd;
            dragIndex = leg.LegDragIndex;
            MissionPlanner.CurrentMissionDataCard.AAROnload += leg.LegFuelAdded;
            MissionPlanner.CurrentMissionDataCard.TotalRouteFuel += (int)leg.LegFuel;
            MissionPlanner.CurrentMissionDataCard.LandingWeight = endWeight;
        }

        UpdateFuelInfo();
    }

    private void ImportDtcButton_Click(object sender, EventArgs e)
    {
        MissionPlanner.CurrentMissionDataCard = new MissionDataCard();
        flowLayoutPanel1.Controls.Clear();
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                try
                {
                    // Read the JSON file and deserialize it
                    var json = File.ReadAllText(filePath);
                    var jsonObject = JsonConvert.DeserializeObject<DTCImport>(json);

                    var route = jsonObject.RouteA.Waypoints;
                    MissionPlanner.hold = true;
                    MissionPlanner mission = new();
                    mission.MissionInitialisation(route);
                    foreach (var leg in MissionPlanner.CurrentMissionDataCard.MissionLegs)
                    {
                        var legControl = new MissionLegUserControl
                        {
                            MissionLeg = leg
                        };
                        legControl.BindData();
                        legControl.MissionLegsUpdated += MissionLegsUpdatedHandler;
                        flowLayoutPanel1.Controls.Add(legControl);
                    }

                    while (MissionPlanner.hold)
                    {
                        var t = "waiting";
                    }

                    MissionLegsUpdatedHandler(null, null);
                    UpdateFuelInfo();
                }
                catch (Exception ex)
                {
                    MissionPlanner.hold = false;
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }

    public void UpdateFuelInfo()
    {
        LandingSpeeds landingSpeedInterpolation = new LandingSpeeds();
        var speeds = landingSpeedInterpolation.GetLandingSpeed(MissionPlanner.CurrentMissionDataCard.LandingWeight);
        double flapDownSpeed = speeds.FlapDownSpeed;
        double flapUpSpeed = speeds.FlapUpSpeed;
        double roundedBingo = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.BingoFuel / 100) * 100;
        double roundedJoker = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.JokerFuel / 100) * 100;
        labelTotalDistance.Text = (int)MissionPlanner.CurrentMissionDataCard.MissionDistance + " nm";
        labelSuggestedFuel.Text =
            MissionPlanner.CurrentMissionDataCard.TotalRouteFuel + 2500 + 1200 * 5 + " lbs";
        textBoxBingo.Text = roundedBingo.ToString();
        labelFuelBurn.Text = MissionPlanner.CurrentMissionDataCard.TotalRouteFuel + " lbs";
        FuelLoadedLabelValue.Text = F15EStrikeEagle.TotalFuel + " lbs";
        takeoffWeightLabel.Text = F15EStrikeEagle.GrossWeight + " lbs";
        LandingWeightValueLabel.Text = MissionPlanner.CurrentMissionDataCard.LandingWeight + " lbs";
        JokertextBox.Text = roundedJoker.ToString();
        AAROnloadLabel.Text = MissionPlanner.CurrentMissionDataCard.AAROnload + " lbs";
        labelSpeeds.Text = (int)flapDownSpeed + @"/" + (int)flapUpSpeed + " KCAS";
        
    }

    private void FuelPlanner_VisibleChanged(object sender, EventArgs e)
    {
        if (Visible && flowLayoutPanel1.Controls.Count != 0) MissionLegsUpdatedHandler(null, null);
    }

    private void textBoxBingo_Leave(object sender, EventArgs e)
    {
        try
        {
            MissionPlanner.CurrentMissionDataCard.BingoFuel = Convert.ToDouble(textBoxBingo.Text);
        }
        catch
        {
            textBoxBingo.Text = MissionPlanner.CurrentMissionDataCard.BingoFuel.ToString();
        }
    }

    private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
    {
    }

    private void JokertextBox_Leave(object sender, EventArgs e)
    {
        try
        {
            MissionPlanner.CurrentMissionDataCard.JokerFuel = Convert.ToDouble(JokertextBox.Text);
        }
        catch
        {
            JokertextBox.Text = MissionPlanner.CurrentMissionDataCard.JokerFuel.ToString();
        }
    }
}