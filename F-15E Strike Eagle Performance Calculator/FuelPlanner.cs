using System.IO.Compression;
using System.Xml.Linq;
using F_15E_Strike_Eagle_Performance_Calculator.Imports;
using F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;
using Newtonsoft.Json;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class FuelPlanner : UserControl
{
    public delegate void MissionLegsUpdatedEventHandler(object sender, EventArgs e);

    public FuelPlanner()
    {
        InitializeComponent();

        dtcTt.SetToolTip(ImportDtcButton, "Import a DTC v7 Json File");
        CfTt.SetToolTip(buttonCombatFlite, "Import a CombatFlite .CF File");
        TwTt.SetToolTip(buttonTw, "Import a DCS TheWay .tw File");
        DistTt.SetToolTip(labelTotalDistance, "Total length of the imported route");
        TowTt.SetToolTip(takeoffWeightLabel, "Takeoff Weight - From Planned Loadout");
        LawTt.SetToolTip(LandingWeightValueLabel, "Landing Weight - Total Fuel burned + Stores expended");
        LandingSpdTt.SetToolTip(labelSpeeds, "Calculated Landing Speeds for Landing Weight. Flaps Down / Flaps Up");
        FuelBurnTt.SetToolTip(labelFuelBurn, "Total Fuel burn for planned route, including delay times.");
        RecFuelTt.SetToolTip(RecoveryFuelLabel, "Minimum fuel at FAF/Initial Point for recovery to planned base");
        ReqFuelTt.SetToolTip(labelSuggestedFuel,
            "Suggested planned fuel load, based on Fuel burn + Recovery Fuel + 5min of Combat maneuvering (if selected)");
        AarOnloadTt.SetToolTip(AAROnloadLabel,
            "Total planned Air to Air refueling onload, for the sortie");
        FuelLoadedTt.SetToolTip(FuelLoadedLabelValue, "Fuel on board (Internal + External) - From Planned Loadout");

        JokerTt.SetToolTip(JokerLabel,
            "Joker Fuel is Bingo Fuel, plus 1500lbs. User can enter their own value to override");
        JokerTt.SetToolTip(BingoLabel,
            "Bingo Fuel is recovery fuel, plus half route distance at 15lb/nm on a Max Endurance profile. User can enter their own value to override");
        toolTipCmbt.SetToolTip(checkBoxCombat, "Adds fuel for 5min of combat maneuvering");
        fuelNetTt.SetToolTip(fuelLabelNet,
            "If Positive, you have extra fuel on board vs the Estimated Required, if negative, you have a fuel deficit vs the Estimated Required");
    }

    protected override void OnResize(EventArgs e)
    {
        Visible = false;
        base.OnResize(e);
        Visible = true;
    }

    // Define the event handler method in your main form
    private void MissionLegsUpdatedHandler(object sender, EventArgs e)
    {
        bool issue = false;
        textBoxLog.Clear();
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
            if (leg.Id == 1) calculateLegFuel.calculatedValue += 1488; // Startup and Taxi
            leg.LegFuel = calculateLegFuel.calculatedValue;
            leg.LegFuelFlow = calculateLegFuel.poundPerHour;

            if (leg.LegFuelFlow < 3200)
            {
                leg.LegFuel = 0;
                FuelFlowDataRetriever getData = new();

                leg.LegRemarks = getData.FindClosestValidData(leg.LegStartAircraftWeight,
                    (int)leg.LegDragIndex, leg.LegAltitude, (int)leg.LegSpeed);
                textBoxLog.AppendText($"Leg {leg.Id}: {leg.LegRemarks}" + Environment.NewLine);
            }
            else
            {
                leg.LegRemarks = string.Empty;
            }

            foreach (MissionLegUserControl legUserControl in routeFlowPanel.Controls)
                if (legUserControl.MissionLeg.Id == leg.Id && leg.LegRemarks != string.Empty)
                {
                    legUserControl.BackColor = Color.Firebrick;
                    issue = true;
                }
                else if (legUserControl.MissionLeg.Id == leg.Id && leg.LegRemarks == string.Empty)
                {
                    legUserControl.BackColor = SystemColors.ControlDark;
                }

            leg.LegEndAircraftWeight = leg.LegStartAircraftWeight - calculateLegFuel.calculatedValue;
            endWeight = leg.LegStartAircraftWeight - calculateLegFuel.calculatedValue + leg.LegFuelAdded -
                        leg.LegPayloadReleased;
            leg.LegFuelRemainEnd = fuelWeight - (int)leg.LegFuel + leg.LegFuelAdded;
            fuelWeight = leg.LegFuelRemainEnd;
            dragIndex = leg.LegDragIndex;
            MissionPlanner.CurrentMissionDataCard.AAROnload += leg.LegFuelAdded;
            MissionPlanner.CurrentMissionDataCard.TotalRouteFuel += (int)leg.LegFuel;
            MissionPlanner.CurrentMissionDataCard.LandingWeight = endWeight;
        }

        missionInfoGroupBox.BackColor = issue ? Color.Firebrick : SystemColors.WindowFrame;

        UpdateFuelInfo();
    }

    private void buttonCombatFlite_Click(object sender, EventArgs e)
    {
        ResetFuelPlanner();
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = @"CombatFlite Files (*.cf)|*.cf|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                try
                {
                    var a = ParseMissionXml(filePath);
                    if (a.CfRoutes.Count == 1)
                    {
                        ProcessImport(a.CfRoutes[0].Waypoints);
                    }
                    else if (a.CfRoutes.Count > 1)
                    {
                        // Create a form to display the route selection
                        var routeSelectionForm = new Form();
                        routeSelectionForm.Text = @"Select a route";
                        routeSelectionForm.MaximizeBox = false;
                        routeSelectionForm.MinimizeBox = false;
                        routeSelectionForm.StartPosition = FormStartPosition.CenterParent;
                        var routeListBox = new ListBox();
                        routeListBox.Dock = DockStyle.Fill;

                        foreach (var route in a.CfRoutes)
                            routeListBox.Items.Add($"{route.Name} (MSN#{route.MsnNumber})");

                        var importButton = new Button();
                        importButton.Text = @"Import";
                        importButton.Click += (sender, e) =>
                        {
                            if (routeListBox.SelectedIndex >= 0 && routeListBox.SelectedIndex < a.CfRoutes.Count)
                            {
                                var selectedRoute = a.CfRoutes[routeListBox.SelectedIndex];
                                ProcessImport(selectedRoute.Waypoints);
                                routeSelectionForm.DialogResult = DialogResult.OK;

                                routeSelectionForm.Close();
                            }
                        };

                        var cancelButton = new Button();
                        cancelButton.Text = @"Cancel";
                        cancelButton.Click += (sender, e) => { routeSelectionForm.Close(); };

                        var buttonPanel = new FlowLayoutPanel();
                        buttonPanel.FlowDirection = FlowDirection.RightToLeft;
                        buttonPanel.Dock = DockStyle.Bottom;
                        buttonPanel.Controls.Add(importButton);
                        buttonPanel.Controls.Add(cancelButton);

                        routeSelectionForm.Controls.Add(routeListBox);
                        routeSelectionForm.Controls.Add(buttonPanel);

                        routeSelectionForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(@"No routes found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MissionPlanner.hold = false;
                    MessageBox.Show(@"Error: " + ex.Message);
                }
            }
        }
    }

    private void buttonTw_Click(object sender, EventArgs e)
    {
        ResetFuelPlanner();
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = @"TheWay Files (*.tw)|*.tw|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                try
                {
                    var json = File.ReadAllText(filePath);
                    var jsonObject = JsonConvert.DeserializeObject<List<TheWayImport>>(json);
                    var a = "test";
                    List<Waypoint> _import = new List<Waypoint>();
                    foreach (var wpt in jsonObject)
                    {
                        var convertWaypoint = new Waypoint();
                        convertWaypoint.Sequence = wpt.id;
                        convertWaypoint.Name = wpt.name;
                        convertWaypoint.Latitude = wpt.lat.ToString();
                        convertWaypoint.Longitude = wpt.@long.ToString();
                        convertWaypoint.Elevation = (int)wpt.elev;
                        if (convertWaypoint.Name.Contains("Target") || convertWaypoint.Name.Contains("TGT") ||
                            convertWaypoint.Name.Contains("DMPI"))
                            convertWaypoint.Target = true;

                        _import.Add(convertWaypoint);
                    }

                    if (_import.Count == 0) throw new Exception("No valid The Way waypoints found");
                    ProcessImport(_import);
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex.Message);
                    MessageBox.Show(@"Route Import failed. Please see Log");
                }
            }
        }
    }

    private void ImportDtcButton_Click(object sender, EventArgs e)
    {
        ResetFuelPlanner();
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = @"JSON Files (*.json)|*.json|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                try
                {
                    // Read the JSON file and deserialize it
                    var json = File.ReadAllText(filePath);
                    var jsonObject = JsonConvert.DeserializeObject<DTCImport>(json);
                    bool hasWaypointsInA = jsonObject.RouteA != null;
                    bool hasWaypointsInB = jsonObject.RouteB != null;
                    bool hasWaypointsInC = jsonObject.RouteC != null;

                    if (hasWaypointsInA && !hasWaypointsInB && !hasWaypointsInC)
                    {
                        ProcessImport(jsonObject.RouteA.Waypoints);
                    }
                    else if (!hasWaypointsInA && hasWaypointsInB && !hasWaypointsInC)
                    {
                        ProcessImport(jsonObject.RouteB.Waypoints);
                    }
                    else if (!hasWaypointsInA && !hasWaypointsInB && hasWaypointsInC)
                    {
                        ProcessImport(jsonObject.RouteC.Waypoints);
                    }
                    else if ((hasWaypointsInA && hasWaypointsInB) || (hasWaypointsInA && hasWaypointsInC) ||
                             (hasWaypointsInB && hasWaypointsInC))
                    {
                        // Two or more of the three routes have waypoints, present a dialog to choose which one
                        var selectedRoute = ShowRouteSelectionDialog(hasWaypointsInA, hasWaypointsInB, hasWaypointsInC);

                        if (selectedRoute != null)
                        {
                            if (selectedRoute == "A")
                                ProcessImport(jsonObject.RouteA.Waypoints);
                            else if (selectedRoute == "B")
                                ProcessImport(jsonObject.RouteB.Waypoints);
                            else if (selectedRoute == "C")
                                ProcessImport(jsonObject.RouteC.Waypoints);
                            else
                                MessageBox.Show(@"No Route Selected", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // None of the routes have waypoints
                        MessageBox.Show(@"No waypoints found in any route.", @"Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    MissionPlanner.hold = false;
                }
                catch (Exception ex)
                {
                    MissionPlanner.hold = false;
                    MessageBox.Show(@"Error: " + ex.Message);
                }
            }
        }
    }

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
                    MessageBox.Show(@"mission.xml not found in the ZIP file.", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                        var aircraft = routeElement.Element("Aircraft");

                        var cfRoute = new CFRoute
                        {
                            Name = routeElement.Element("Name").Value,
                            MsnNumber = routeElement.Element("MSNnumber").Value,
                            Waypoints = new List<Waypoint>(),
                            AircraftType = aircraft.Element("Type").Value

                        };
                        if (cfRoute.AircraftType != "F-15ESE")
                        {
                            continue;
                        }

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
                                    Target = wp.Element("Type").Value ==
                                             "Target", // Set Target to True if Type is "Target"
                                    Ktas = (int)double.Parse(wp.Element("KTAS")
                                        .Value), //Convert.ToInt32(wp.Element("KTAS").Value)
                                    Activity = Worker.ConvertTimeToMinutes(wp.Element("Activity").Value)
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
            MessageBox.Show(@"An error occurred while parsing CF File:
" + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    private void ResetFuelPlanner()
    {
        MissionPlanner.CurrentMissionDataCard = new MissionDataCard();
        routeFlowPanel.Controls.Clear();
    }

    private void ProcessImport(List<Waypoint> route)
    {
        try
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
                routeFlowPanel.Controls.Add(legControl);
            }

            while (MissionPlanner.hold)
            {
                var t = "waiting";
            }

            MissionLegsUpdatedHandler(null, null);
            UpdateFuelInfo();
        }
        catch (Exception exception)
        {
            Log.WriteLog("Route Calculation Failed. Route Import Aborted. " + exception.Message);
            MessageBox.Show(@"Route Calculation Failed. Route Import Aborted. See Log for more information");
        }
    }

    public void UpdateFuelInfo()
    {
        if (MissionPlanner.CurrentMissionDataCard.LandingWeight >= 30000 &&
            MissionPlanner.CurrentMissionDataCard.LandingWeight <= 80000)
        {
            var landingSpeedInterpolation = new LandingSpeeds();
            var speeds = landingSpeedInterpolation.GetLandingSpeed(MissionPlanner.CurrentMissionDataCard.LandingWeight);
            var flapDownSpeed = speeds.FlapDownSpeed;
            var flapUpSpeed = speeds.FlapUpSpeed;
            labelSpeeds.Text = (int)flapDownSpeed + @"/" + (int)flapUpSpeed + @" KCAS";
        }

        int cmbt = 0;
        if (checkBoxCombat.Checked) cmbt = 6000;

        var suggestedFuel = MissionPlanner.CurrentMissionDataCard.TotalRouteFuel + 2500 + cmbt;
        var roundedBingo = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.BingoFuel / 100) * 100;
        var roundedJoker = Math.Ceiling(MissionPlanner.CurrentMissionDataCard.JokerFuel / 100) * 100;
        labelTotalDistance.Text = (int)MissionPlanner.CurrentMissionDataCard.MissionDistance + @" nm";
        labelSuggestedFuel.Text = suggestedFuel + @" lbs";
        textBoxBingo.Text = roundedBingo.ToString();
        labelFuelBurn.Text = MissionPlanner.CurrentMissionDataCard.TotalRouteFuel + @" lbs";
        FuelLoadedLabelValue.Text = F15EStrikeEagle.TotalFuel + @" lbs";
        takeoffWeightLabel.Text = F15EStrikeEagle.GrossWeight + @" lbs";
        LandingWeightValueLabel.Text = MissionPlanner.CurrentMissionDataCard.LandingWeight + @" lbs";
        JokertextBox.Text = roundedJoker.ToString();
        AAROnloadLabel.Text = MissionPlanner.CurrentMissionDataCard.AAROnload + @" lbs";
        var netFuel = F15EStrikeEagle.TotalFuel + MissionPlanner.CurrentMissionDataCard.AAROnload - suggestedFuel;
        fuelLabelNet.Text = netFuel + " lbs";
        fuelLabelNet.ForeColor = netFuel < 0 ? Color.Red : Color.LawnGreen;
    }

    private string ShowRouteSelectionDialog(bool routeAExists, bool routeBExists, bool routeCExists)
    {
        string value = null;
        // Create a form to display the route selection
        var routeSelectionForm = new Form();
        routeSelectionForm.MaximizeBox = false;
        routeSelectionForm.MinimizeBox = false;
        routeSelectionForm.Text = @"Select a route to import";
        routeSelectionForm.StartPosition = FormStartPosition.CenterParent;
        var routeListBox = new ListBox();
        routeListBox.Dock = DockStyle.Fill;

        // Add options for available routes
        if (routeAExists) routeListBox.Items.Add("Route A");
        if (routeBExists) routeListBox.Items.Add("Route B");
        if (routeCExists) routeListBox.Items.Add("Route C");

        var importButton = new Button();
        importButton.Text = @"Import";
        importButton.Click += (sender, e) =>
        {
            if (routeListBox.SelectedIndex >= 0)
            {
                var selectedRoute = routeListBox.SelectedItem.ToString();
                value = selectedRoute switch
                {
                    "Route A" => "A",
                    "Route B" => "B",
                    "Route C" => "C",
                    _ => string.Empty
                };
                routeSelectionForm.DialogResult = DialogResult.OK;
                routeSelectionForm.Close();
            }
        };

        var cancelButton = new Button();
        cancelButton.Text = @"Cancel";
        cancelButton.Click += (sender, e) => { routeSelectionForm.Close(); };

        var buttonPanel = new FlowLayoutPanel();
        buttonPanel.FlowDirection = FlowDirection.RightToLeft;
        buttonPanel.Dock = DockStyle.Bottom;
        buttonPanel.Controls.Add(importButton);
        buttonPanel.Controls.Add(cancelButton);

        routeSelectionForm.Controls.Add(routeListBox);
        routeSelectionForm.Controls.Add(buttonPanel);

        // Show the dialog and wait for the user's selection
        var result = routeSelectionForm.ShowDialog();

        if (result == DialogResult.Cancel) return null;

        return value; // Handle the case when no route is selected
    }

    private void FuelPlanner_VisibleChanged(object sender, EventArgs e)
    {
        if (Visible && routeFlowPanel.Controls.Count != 0) MissionLegsUpdatedHandler(null, null);
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

    private void RouteFlowPanelControlAdded(object sender, ControlEventArgs e)
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

    private void checkBoxCombat_CheckedChanged(object sender, EventArgs e)
    {
        if (routeFlowPanel.Controls.Count != 0) UpdateFuelInfo();
    }
}