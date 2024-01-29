using System.Globalization;
using System.Runtime.CompilerServices;
using static System.Collections.Specialized.BitVector32;

namespace F_15E_Strike_Eagle_Performance_Calculator;

public partial class Main : Form
{
    private const string Pounds = " Lbs";
    private readonly bool _loaded;
    private readonly List<Stores> _loadedData;
    private Stores emptyStores = new();
    private static List<Station> StationList = new ();
    public Main()
    {
        InitializeComponent();
        takeoffWeightTextBox.MaxLength = 5;
        OATTextBox.MaxLength = 2;
        runwayElevationTextBox.MaxLength = 4;
        calcuateButton.Enabled = false;
        takeoffWeightTextBox.TextChanged += TextBox_TextChanged;
        OATTextBox.TextChanged += TextBox_TextChanged;
        runwayElevationTextBox.TextChanged += TextBox_TextChanged;
        _loadedData = StoresManagement.LoadStoresInfo();
        _loaded = true;
        trackBarIntFuel.Value = F15EStrikeEagle.InternalFuel;
        StationDataLoad();
        _loaded = false;
        StationList.Add(F15EStrikeEagle.LeftCft);
        StationList.Add(F15EStrikeEagle.RightCft);
        StationList.Add(F15EStrikeEagle.Station2);
        StationList.Add(F15EStrikeEagle.Station2A);
        StationList.Add(F15EStrikeEagle.Station2B);
        StationList.Add(F15EStrikeEagle.Station5);
        StationList.Add(F15EStrikeEagle.Station8);
        StationList.Add(F15EStrikeEagle.Station8A);
        StationList.Add(F15EStrikeEagle.Station8B);
        StationList.Add(F15EStrikeEagle.Lnp);
        StationList.Add(F15EStrikeEagle.Ltp);
        UpdateDragIndexForAll();
        F15EStrikeEagle.Calculate();
        UpdateLoadoutUi();
    }

    public int Weight { get; set; }

    public string Item { get; set; }

    public int Id { get; set; }

    private void PopulateComboBox<T>(ComboBox comboBox, IEnumerable<T> data, Func<T, string> displayMemberSelector,
        Func<T, object> valueMemberSelector)
    {
        comboBox.DisplayMember = "DisplayText";
        comboBox.ValueMember = "Value";
        comboBox.DataSource = data.Select(d => new
        {
            DisplayText = displayMemberSelector(d),
            Value = valueMemberSelector(d)
        }).Distinct().ToList();
    }

    private void PopulateComboBox<T>(ComboBox comboBox, IEnumerable<T> data, Func<T, string> displayMemberSelector,
        Func<T, object> valueMemberSelector, bool includeEmpty = false) where T : new()
    {
        var dataList = data.ToList();

        if (includeEmpty)
        {
            T emptyItem2 = new();
            {
                Id = 99; // Set the appropriate values for the "empty" item
                Item = "Empty";
                Weight = 0;
                // Set other properties as needed
            }
            ;
            var loose = emptyItem2;
            dataList.Insert(0, loose);
        }

        comboBox.DisplayMember = "DisplayText";
        comboBox.ValueMember = "Value";
        comboBox.DataSource = dataList.Select(d => new
        {
            DisplayText = displayMemberSelector(d),
            Value = valueMemberSelector(d)
        }).ToList();
        ;
    }

    private void StationDataLoad()
    {
        PopulateComboBox(comboBoxSta2a,
            _loadedData
                .Where(s => s.Sta2A != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta2A),
            s => $"{s.Sta2A} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta2,
            _loadedData
                .Where(s => s.Sta2 != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta2),
            s => $"{s.Sta2} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta2b,
            _loadedData
                .Where(s => s.Sta2B != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta2B),
            s => $"{s.Sta2B} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxLcft,
            _loadedData
                .Where(s => s.Lcft != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Lcft),
            s => $"{s.Lcft} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxltp,
            _loadedData
                .Where(s => s.Ltp != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Ltp),
            s => $"{s.Ltp} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta5,
            _loadedData
                .Where(s => s.Sta5 != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta5),
            s => $"{s.Sta5} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxlnp,
            _loadedData
                .Where(s => s.Lnp != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Lnp),
            s => $"{s.Lnp} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxrcft,
            _loadedData
                .Where(s => s.Rcft != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1) 
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)    
                .ThenBy(s => s.Rcft),   
            s => $"{s.Rcft} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta8a,
            _loadedData
                .Where(s => s.Sta8A != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta8A),
            s => $"{s.Sta8A} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta8,
            _loadedData
                .Where(s => s.Sta8 != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta8),
            s => $"{s.Sta8} x {s.Item}",
            s => s);
        PopulateComboBox(comboBoxsta8b,
            _loadedData
                .Where(s => s.Sta8B != 0 && s.Category != CategoryType.PylonsLaunchersAdaptors)
                .OrderBy(s => s.Category == CategoryType.Empty ? 0 : 1)
                .ThenBy(s => s.Category)
                .ThenBy(s => s.Item)
                .ThenBy(s => s.Sta8B),
            s => $"{s.Sta8B} x {s.Item}",
            s => s);

        comboBoxSta2a.SelectedIndex = 2;
        comboBoxsta2.SelectedIndex = 21;
        comboBoxsta2b.SelectedIndex = 4;
        comboBoxltp.SelectedIndex = 1;
        comboBoxlnp.SelectedIndex = 1;
        comboBoxsta8a.SelectedIndex = 2;
        comboBoxsta8.SelectedIndex = 21;
        comboBoxsta8b.SelectedIndex = 4;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //Validate Inputs

        if (!Worker.IsNumeric(takeoffWeightTextBox.Text))
        {
            MessageBox.Show(@"Please Enter weight in numerical form only");
            return;
        }

        if (!Worker.IsNumeric(OATTextBox.Text))
        {
            MessageBox.Show(@"Please Enter Outside Air Temperature in numerical form only");
            return;
        }

        if (!Worker.IsNumeric(runwayElevationTextBox.Text))
        {
            MessageBox.Show(@"Please Enter Elevation in numerical form only");
            return;
        }

        var thrustSetting = radioButton1.Checked ? 0 : 1; //0 = Max || 1 = Mil
        var takeoffWeight = Convert.ToDouble(takeoffWeightTextBox.Text);
        switch (takeoffWeight)
        {
            case > 81000:
                MessageBox.Show(@"Take off Weight exceeds MTOW");
                return;
            case < 40000:
                MessageBox.Show(@"Minimum Weight Performance data is 40000lbs ");
                return;
            default:
                try
                {
                    label2.Text = TakeoffSpeeds.Calculate(takeoffWeight, 24, thrustSetting) + " KCAS";
                    var oat = Convert.ToDouble(OATTextBox.Text); // Actual OAT
                    var runwayElevation = Convert.ToDouble(runwayElevationTextBox.Text); // Actual Runway Elevation
                    if (runwayElevation > 2000)
                        MessageBox.Show(@"Performance Data is Limited above 2000ft AMSL, Results may be inaccurate");
                    if (oat > 40)
                        MessageBox.Show(@"Performance Data is Limited above 40C OAT, Results may be inaccurate");
                    var takeoffDistance =
                        TakeoffDistance.CalculateNew(takeoffWeight, oat, runwayElevation, thrustSetting);
                    if (RotationCheckBox.Checked) takeoffDistance = Math.Round(takeoffDistance * 1.1);

                    label4.Text = takeoffDistance + @" ft";
                }
                catch (Exception ex)
                {
                    Log.WriteLog("Calculation Error occurred. " + ex.Message);
                    Log.WriteLog(ex.ToString());

                    MessageBox.Show(
                        @"An Error occurred during the calculation. Please send the log file to crazydunc on Discord. ");
                }

                break;
        }
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        // Check if all three textboxes have data
        if (!string.IsNullOrEmpty(takeoffWeightTextBox.Text) &&
            !string.IsNullOrEmpty(OATTextBox.Text) &&
            !string.IsNullOrEmpty(runwayElevationTextBox.Text))
            calcuateButton.Enabled = true; // Enable the button
        else
            calcuateButton.Enabled = false; // Disable the button
    }

    private void comboBoxsta2_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta2, F15EStrikeEagle.Station2, s => s.Sta2);
    }

    private void HandleStationComboBoxSelectionChange(ComboBox comboBox, Station? station,
        StationPropertySelector propertySelector)
    {
        if (comboBox.SelectedItem == null)
            // No selection made, return or perform other desired actions
            return;
        var selectedItem = comboBox.SelectedItem as dynamic;
        if (selectedItem.DisplayText == "Empty") return;
        string displayText = selectedItem.DisplayText;
        var displayParts = displayText.Split(" x ");

        var sta = int.Parse(displayParts[0]);
        var item = displayParts[1];
        var selectedData = _loadedData.FirstOrDefault(s => propertySelector(s) == sta && s.Item == item);

        if (selectedData != null && station != null)
        {
            var dragIndexToUse = station.GetDragIndexToUse(F15EStrikeEagle.Station2.StoreCategory, F15EStrikeEagle.Station8.StoreCategory);
            double? dragIndex = 0; 
            switch (dragIndexToUse)
            {
                case F15EStrikeEagle.DragOption.NoWingStores:
                    dragIndex = selectedData.DragIndexCftNoBombOrTankWing;
                    dragIndex = DragIndexValidation(dragIndex, selectedData);
                    break;
                case F15EStrikeEagle.DragOption.WingStores:
                    dragIndex = selectedData.DragIndexCft;
                    dragIndex = DragIndexValidation(dragIndex, selectedData);

                    break;
                default:
                    dragIndex = 0;
                    break;
            }
            if(selectedData.Item.Contains("LANTIRN"))
            {
                if (F15EStrikeEagle.RightCft.StoreCategory == CategoryType.Empty &&
                    F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.Empty)
                {
                    if (selectedData.Item.Contains("AAQ-13")) dragIndex = 8.3;
                    if (selectedData.Item.Contains("AAQ-14")) dragIndex = 6.5;
                }
            }

            if (station.StationName is "STA2" or "STA8")
            {
                dragIndex = FuelTankDragIndex(station);
            }
            station.SetStore(selectedData.Item, selectedData.Weight, dragIndex ?? 0, sta, selectedData.Category, selectedData);
            F15EStrikeEagle.Calculate();
        }

        UpdateLoadoutUi();
    }

    public static void UpdateDragIndexForAll()
    {
        foreach (var station in StationList)
        {



            var dragIndexToUse = station.GetDragIndexToUse(F15EStrikeEagle.Station2.StoreCategory, F15EStrikeEagle.Station8.StoreCategory);
            double? dragIndex = 0;
            if (station.StationName != "STA5")
            {
                switch (dragIndexToUse)
                {
                    case F15EStrikeEagle.DragOption.NoWingStores:
                        dragIndex = station.StationStore.DragIndexCftNoBombOrTankWing;
                        dragIndex = DragIndexValidation(dragIndex, station.StationStore);
                        break;
                    case F15EStrikeEagle.DragOption.WingStores:
                        dragIndex = station.StationStore.DragIndexCft;
                        dragIndex = DragIndexValidation(dragIndex, station.StationStore);

                        break;
                    default:
                        dragIndex = 0;
                        break;
                }
            }
            else
            {
                dragIndex = station.StationStore.DragIndexCl;
            }
            if (station.StationStore.Item.Contains("LANTIRN"))
            {
                if (F15EStrikeEagle.RightCft.StoreCategory == CategoryType.Empty &&
                    F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.Empty)
                {
                    if (station.StationStore.Item.Contains("AAQ-13"))
                    {
                        dragIndex = 8.3;
                    }
                    if (station.StationStore.Item.Contains("AAQ-14")) dragIndex = 6.5;
                }
            }

            if (station.StationName is "STA2" or "STA8")
            {
                dragIndex = FuelTankDragIndex(station);
            }

            int qty = 0;
            station.SetStore(station.StationStore.Item, station.StationStore.Weight, dragIndex ?? 0, station.StoreQuantity, station.StationStore.Category);
        }
    }

    private static double? FuelTankDragIndex(Station station)
    {
        double? dragIndex = 0;

        if (station.StationName == "STA8")
        {
            if (F15EStrikeEagle.Station8.StoreName.Contains("610") && F15EStrikeEagle.RightCft.StoreQuantity > 3)
            {
                // CFI-O
                dragIndex = 12.3;
            }
            else if (F15EStrikeEagle.Station8.StoreName.Contains("610") &&
                     F15EStrikeEagle.RightCft.StoreQuantity <= 3 &&
                     F15EStrikeEagle.RightCft.StoreCategory != CategoryType.AirToAirMissiles &&
                     F15EStrikeEagle.RightCft.StoreCategory != CategoryType.Empty)
            {
                //CFT-I
                dragIndex = 8.2;
            }
            else if (F15EStrikeEagle.Station8.StoreName.Contains("610") &&
                     (F15EStrikeEagle.RightCft.StoreCategory == CategoryType.AirToAirMissiles ||
                      F15EStrikeEagle.RightCft.StoreCategory == CategoryType.Empty))
            {
                //CFT
                dragIndex = 6;
            }
        }
        else if (station.StationName == "STA2")
        {
            if (F15EStrikeEagle.Station2.StoreName.Contains("610") && F15EStrikeEagle.LeftCft.StoreQuantity > 3)
            {
                // CFI-O
                dragIndex = 12.3;
            }
            else if (F15EStrikeEagle.Station2.StoreName.Contains("610") &&
                     F15EStrikeEagle.LeftCft.StoreQuantity <= 3 &&
                     F15EStrikeEagle.LeftCft.StoreCategory != CategoryType.AirToAirMissiles &&
                     F15EStrikeEagle.LeftCft.StoreCategory != CategoryType.Empty)
            {
                //CFT-I
                dragIndex = 8.2;
            }
            else if (F15EStrikeEagle.Station2.StoreName.Contains("610") &&
                     (F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.AirToAirMissiles ||
                      F15EStrikeEagle.LeftCft.StoreCategory == CategoryType.Empty))
            {
                //CFT
                dragIndex = 6;
            }
        }

        return dragIndex;
    }

    private static double? DragIndexValidation(double? dragIndex, Stores selectedData)
    {
        if (dragIndex == null && selectedData.Category != CategoryType.Empty)
        {
            dragIndex = selectedData.DragIndexWing;
            if (dragIndex == null && selectedData.Category != CategoryType.Empty)
            {
                dragIndex = selectedData.DragIndexCl;
            }
        }

        return dragIndex;
    }

    private void comboBoxsta5_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta5, F15EStrikeEagle.Station5, s => s.Sta5);
    }

    private void comboBoxSta2a_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxSta2a, F15EStrikeEagle.Station2A, s => s.Sta2A);
    }

    private void comboBoxsta2b_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta2b, F15EStrikeEagle.Station2B, s => s.Sta2B);
    }

    private void comboBoxLcft_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxLcft, F15EStrikeEagle.LeftCft, s => s.Lcft);
    }

    private void comboBoxltp_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxltp, F15EStrikeEagle.Ltp, s => s.Ltp);
    }

    private void comboBoxlnp_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxlnp, F15EStrikeEagle.Lnp, s => s.Lnp);
    }

    private void comboBoxrcft_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxrcft, F15EStrikeEagle.RightCft, s => s.Rcft);
    }

    private void comboBoxsta8a_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta8a, F15EStrikeEagle.Station8A, s => s.Sta8A);
    }

    private void comboBoxsta8_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta8, F15EStrikeEagle.Station8, s => s.Sta8);
    }

    private void comboBoxsta8b_SelectedIndexChanged(object sender, EventArgs e)
    {
        HandleStationComboBoxSelectionChange(comboBoxsta8b, F15EStrikeEagle.Station8B, s => s.Sta8B);
    }

    public void UpdateLoadoutUi()
    {


        if (F15EStrikeEagle.Station2.StoreName.Contains("610"))
        {
            if (trackBarsta2.Enabled == false)
            {
                trackBarsta2.Enabled = true;
                trackBarsta2.Value = 3965;
                F15EStrikeEagle.Station2Fuel = trackBarsta2.Value;
            }
        }
        else
        {
            trackBarsta2.Enabled = false;
            F15EStrikeEagle.Station2Fuel = 0;
            if (trackBarsta2.Value != 0) trackBarsta2.Value = 0;
        }

        if (F15EStrikeEagle.Station5.StoreName.Contains("610"))
        {
            if (trackBarsta5.Enabled == false)
            {
                trackBarsta5.Enabled = true;
                trackBarsta5.Value = 3965;
                F15EStrikeEagle.Station5Fuel = trackBarsta5.Value;
            }
        }
        else
        {
            trackBarsta5.Enabled = false;
            F15EStrikeEagle.Station5Fuel = 0;
            if (trackBarsta5.Value != 0) trackBarsta5.Value = 0;
        }

        if (F15EStrikeEagle.Station8.StoreName.Contains("610"))
        {
            if (trackBarsta8.Enabled == false)
            {
                trackBarsta8.Enabled = true;
                trackBarsta8.Value = 3965;
                F15EStrikeEagle.Station8Fuel = trackBarsta8.Value;
            }
        }
        else
        {
            trackBarsta8.Enabled = false;
            F15EStrikeEagle.Station8Fuel = 0;
            if (trackBarsta8.Value != 0) trackBarsta8.Value = 0;
        }

        if (trackBarsta2.Value != F15EStrikeEagle.Station2Fuel && trackBarsta2.Enabled == true) F15EStrikeEagle.Station2Fuel = trackBarsta2.Value;
        if (trackBarsta5.Value != F15EStrikeEagle.Station5Fuel && trackBarsta5.Enabled == true) F15EStrikeEagle.Station5Fuel = trackBarsta5.Value;
        if (trackBarsta8.Value != F15EStrikeEagle.Station8Fuel && trackBarsta8.Enabled == true) F15EStrikeEagle.Station8Fuel = trackBarsta8.Value;
        F15EStrikeEagle.Calculate();

        if (!_loaded)
        {
            fuelLabel.Text = F15EStrikeEagle.TotalFuel + Pounds;
            payloadLabel.Text = F15EStrikeEagle.PayloadWeight + Pounds;
            LatAsymLabel.Text = F15EStrikeEagle.LateralImbalance + Pounds;
            DragLabel.Text = F15EStrikeEagle.TotalDragIndex.ToString(CultureInfo.InvariantCulture);
            weightLabel.Text = F15EStrikeEagle.GrossWeight + Pounds;
            labelGW.Visible = F15EStrikeEagle.GrossWeight > 81000;
        }
        takeoffWeightTextBox.Text = F15EStrikeEagle.GrossWeight.ToString();

    }

    private void trackBarIntFuel_Scroll(object sender, EventArgs e)
    {
        F15EStrikeEagle.InternalFuel = trackBarIntFuel.Value;
        F15EStrikeEagle.Calculate(); 
        UpdateLoadoutUi();
    }

    private void trackBarsta2_Scroll(object sender, EventArgs e)
    {
        F15EStrikeEagle.Station2Fuel = trackBarsta2.Value;
        F15EStrikeEagle.Calculate(); 
        UpdateLoadoutUi();
    }

    private void trackBarsta5_Scroll(object sender, EventArgs e)
    {
        F15EStrikeEagle.Station5Fuel = trackBarsta5.Value;
        F15EStrikeEagle.Calculate(); 
        UpdateLoadoutUi();
    }

    private void trackBarsta8_Scroll(object sender, EventArgs e)
    {
        F15EStrikeEagle.Station8Fuel = trackBarsta8.Value;
        F15EStrikeEagle.Calculate(); 
        UpdateLoadoutUi();
    }

    private delegate int StationPropertySelector(Stores store);
}