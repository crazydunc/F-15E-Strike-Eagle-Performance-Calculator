namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            takeoffWeightTextBox.MaxLength = 5;
            OATTextBox.MaxLength = 2;
            runwayElevationTextBox.MaxLength = 4; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validate Inputs

            if(!Worker.IsNumeric(takeoffWeightTextBox.Text))
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

            var thrustSetting = radioButton1.Checked ? 0 : 1;//0 = Max || 1 = Mil
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
                        label2.Text = TakeoffSpeeds.Calculate(takeoffWeight, 24, thrustSetting);
                        var oat = Convert.ToDouble(OATTextBox.Text); // Actual OAT
                        var runwayElevation = Convert.ToDouble(runwayElevationTextBox.Text); // Actual Runway Elevation
                        if (runwayElevation > 2000)
                        {
                            MessageBox.Show(@"Performance Data is Limited above 2000ft AMSL, Results may be inaccurate");
                        }
                        if (oat > 40)
                        {
                            MessageBox.Show(@"Performance Data is Limited above 40C OAT, Results may be inaccurate");
                        }
                        var takeoffDistance = TakeoffDistance.CalculateNew(takeoffWeight, oat, runwayElevation, thrustSetting);
                        if (RotationCheckBox.Checked)
                        {
                            takeoffDistance = Math.Round(takeoffDistance * 1.1);
                        }

                        label4.Text = takeoffDistance + @" ft";
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog("Calculation Error occurred. " + ex.Message);
                        Log.WriteLog(ex.ToString());

                        MessageBox.Show(@"An Error occurred during the calculation. Please send the log file to crazydunc on Discord. ");
                
                    }

                    break;
            }
        }


    }
}