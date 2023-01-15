namespace Wizard_Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();


        }
        //Taschenrechner Summe errechnen
        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                double a = Convert.ToInt32(txta.Text);
                double b = Convert.ToInt32(txtb.Text);
                double total = a + b;
                lbltotal.Text = total.ToString();
            }
            catch
            {
                MessageBox.Show("Bitte füllen sie die Felder richtig aus es werden nur Zahlen akzeptiert!", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
         
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }
    }
}
