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
            double takeoffWeight = Convert.ToDouble(takeoffWeightTextBox.Text);
            TakeoffSpeeds.Calculate(takeoffWeight, 24, thrustSetting);
            double oat = 25; // Actual OAT
            double runwayElevation = 1000; // Actual Runway Elevation

            double takeoffDistance = TakeoffDistance.Calculate(oat, takeoffWeight, runwayElevation);

            Console.WriteLine($"Calculated Takeoff Distance: {takeoffDistance} feet");
        }
    }
}