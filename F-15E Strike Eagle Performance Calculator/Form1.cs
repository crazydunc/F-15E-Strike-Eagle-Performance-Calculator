namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            int thrustSetting; //0 = Max || 1 = Mil
            if (radioButton1.Checked)
            {
                thrustSetting = 0;
            }
            else
            {
                thrustSetting = 1; 
            }
            var takeoffWeight = Convert.ToDouble(takeoffWeightTextBox.Text);
            if (takeoffWeight > 81000)
            {
                MessageBox.Show(@"Take off Weight exceeds MTOW");
                return; 
            }

            try
            {
                label2.Text = TakeoffSpeeds.Calculate(takeoffWeight, 24, thrustSetting);
                var oat = Convert.ToDouble(OATTextBox.Text); // Actual OAT
                var runwayElevation = Convert.ToDouble(runwayElevationTextBox.Text); // Actual Runway Elevation

                var takeoffDistance = TakeoffDistance.CalculateNew(takeoffWeight, oat, runwayElevation);
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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}