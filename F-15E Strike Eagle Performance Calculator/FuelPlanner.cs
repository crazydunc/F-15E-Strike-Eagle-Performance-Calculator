using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using F_15E_Strike_Eagle_Performance_Calculator.Imports;
using F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

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
    private void buttonCombatFlite_Click(object sender, EventArgs e)
    {
        ResetFuelPlanner();
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "CombatFlite Files (*.cf)|*.cf|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                try
                {
                    // Read the JSON file and deserialize it
                    var a = ParseMissionXml(filePath);
                    if (a.CfRoutes.Count == 1)
                    {
                        ProcessImport(a.CfRoutes[0].Waypoints);

                    }
                }
                catch (Exception ex)
                {
                    MissionPlanner.hold = false;
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
    private void ImportDtcButton_Click(object sender, EventArgs e)
    {
        ResetFuelPlanner();
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
                    ProcessImport(route);
                }
                catch (Exception ex)
                {
                    MissionPlanner.hold = false;
                    MessageBox.Show(@"Error: " + ex.Message);
                }
            }
        }
    }

    //private List<Waypoint> ProcessCombatFliteImport(string filePath)
    //{
    //    try
    //    {
    //        _combatFliteFile = ZipFile.OpenRead(filePath);
    //    }
    //    catch (Exception zip)
    //    {
    //        Log.WriteLog($@"Error Opening CombatFlite file {filePath} - Error is: {zip.Message}");
    //        MessageBox.Show(@"Error opening CombatFlite file. File is invalid. Import aborted");
    //        return null;

    //    }

    //    var missionXml = _combatFliteFile.Entries
    //        .FirstOrDefault(x => x.Name.Equals("mission.xml", StringComparison.InvariantCulture));
    //    if (missionXml == null)
    //    {
    //        Log.WriteLog($@"CF Import error - Could not locate Mission.xml in .cf file {filePath}");
    //        MessageBox.Show(@"Error locating Mission.xml. Import aborted");
    //        return null; 
    //    }
    //}

    public static CFImports ParseMissionXml(string zipFilePath)
    {
        try
        {
            using (var _combatFliteFile = ZipFile.OpenRead(zipFilePath))
            {
                var missionXmlEntry = _combatFliteFile.Entries.FirstOrDefault(entry => entry.FullName == "mission.xml");

                if (missionXmlEntry == null)
                {
                    // Log error message
                    Log.WriteLog("mission.xml not found in the ZIP file.");
                    MessageBox.Show("mission.xml not found in the ZIP file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                using (var stream = missionXmlEntry.Open())
                {
                    var xmlDoc = XDocument.Load(stream);
                    var cfImports = new CFImports
                    {
                        CfRoutes = new List<CFRoute>()
                    };

                    foreach (var routeElement in xmlDoc.Descendants("Route"))
                    {
                        var cfRoute = new CFRoute
                        {
                            Name = routeElement.Element("Name").Value,
                            MsnNumber = routeElement.Element("MSNnumber").Value,
                            Waypoints = new List<Waypoint>()
                        };

                        var waypointsElement = routeElement.Element("Waypoints");

                        if (waypointsElement != null)
                        {
                            var sequence = 0; // Initialize sequence to 1

                            cfRoute.Waypoints.AddRange(waypointsElement.Elements("Waypoint")
                                .Select(wp => new Waypoint
                                {
                                    Sequence = sequence++,
                                    Name = wp.Element("Name").Value,
                                    Latitude = wp.Element("Lat").Value,
                                    Longitude = wp.Element("Lon").Value,
                                    Elevation = Convert.ToInt32(wp.Element("Altitude").Value),
                                    TimeOverSteerpoint = wp.Element("TOT").Value,
                                    Target = (wp.Element("Type").Value == "Target"), // Set Target to True if Type is "Target"
                                    Ktas = (int)double.Parse(wp.Element("KTAS").Value)//Convert.ToInt32(wp.Element("KTAS").Value)
                                }));
                        }

                        cfImports.CfRoutes.Add(cfRoute);
                    }

                    return cfImports;
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception message
            Log.WriteLog("An error occurred while parsing the CF File: " + ex.Message);
            MessageBox.Show("An error occurred while parsing CF File:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
    private void ResetFuelPlanner()
    {
        MissionPlanner.CurrentMissionDataCard = new MissionDataCard();
        flowLayoutPanel1.Controls.Clear();
    }

    private void ProcessImport(List<Waypoint> route)
    {
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

    public void UpdateFuelInfo()
    {
        var landingSpeedInterpolation = new LandingSpeeds();
        var speeds = landingSpeedInterpolation.GetLandingSpeed(MissionPlanner.CurrentMissionDataCard.LandingWeight);
        var flapDownSpeed = speeds.FlapDownSpeed;
        var flapUpSpeed = speeds.FlapUpSpeed;
        var roundedBingo = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.BingoFuel / 100) * 100;
        var roundedJoker = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.JokerFuel / 100) * 100;
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