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
            int thrustSetting = 0; //0 = Max || 1 = Mil
            if (radioButton1.Checked)
            {
                thrustSetting = 0;
            }
            else
            {
                thrustSetting = 1; 
            }
            double takeoffWeight = Convert.ToDouble(takeoffWeightTextBox.Text);
            label2.Text = TakeoffSpeeds.Calculate(takeoffWeight, 24, thrustSetting);
            double oat = Convert.ToDouble(OATTextBox.Text); // Actual OAT
            double runwayElevation = Convert.ToDouble(runwayElevationTextBox.Text); // Actual Runway Elevation

            double takeoffDistance = TakeoffDistance.CalculateNew(takeoffWeight, oat, runwayElevation);

            label4.Text = takeoffDistance + " ft";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}