namespace WinFormsApp6
{
    public partial class Form1 : Form
    {

        private int secretNumber;
        private int attempts;

        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();
            secretNumber = rand.Next(1, 2001);
            attempts = 0;
            label_info.Text = "Guess the number from 1 to 2000.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button1(object sender, EventArgs e)
        {
            int userGuess;

            if (int.TryParse(textBox.Text, out userGuess))
            {
                attempts++;

                if (userGuess < secretNumber)
                {
                    label_info.Text = "The secret number is bigger.";
                }
                else if (userGuess > secretNumber)
                {
                    label_info.Text = "The secret number is lower.";
                }
                else
                {
                    label_info.Text = $"You guessed the number for {attempts} attempts!";
                }

                textBox.Clear();
            }
            else
            {
                label_info.Text = "Please enter a valid number.";
            }
        }
    }
}
