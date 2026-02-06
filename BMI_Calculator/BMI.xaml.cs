namespace BMI_Calculator
{
    public partial class BMI : ContentPage
    {
        int count = 0;

        public BMI()
        {
            InitializeComponent();
        }
        string choice = "Male";

        private void TapMale_Tapped(object sender, TappedEventArgs e)
        {
            this.choice = "Male";
            FrameMale.BorderColor = Color.FromArgb("#0a0e29");
            FrameFemale.BorderColor = Color.FromArgb("#fdfdfd");
        }

        private void TapFemale_Tapped(object sender, TappedEventArgs e)
        {
            this.choice = "Female";
            FrameFemale.BorderColor = Color.FromArgb("#0a0e29");
            FrameMale.BorderColor = Color.FromArgb("#fdfdfd");
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            int height = int.Parse(LblHeight.Text);
            int weight = int.Parse(LblWeight.Text);
            double bmi = Math.Round(weight * 703.0 / Math.Pow(height, 2), 2);

            Dictionary<string, string> bmiCategories = new Dictionary<string, string>();
            bmiCategories["Underweight"] = "Increase calore intake with nutrient-rich foods \n -Incorporate strength training to build muscle mass.";
            bmiCategories["Normal weight"] = "Maintain a balanced diet and regular exercise routine to sustain your current weight and overall health.";
            bmiCategories["Overweight"] = "Adopt a calorie-controlled diet focusing on whole foods \n -Engage in regular cardiovascular and strength training exercises.";
            bmiCategories["Obesity"] = "Consult a healthcare professional for personalized guidance \n -Implement a structured weight loss program combining diet and exercise.";

            if ((this.choice == "Male" && bmi < 18.5) || (this.choice == "Female" && bmi < 18.0))
            {
                await DisplayAlert(
                    "BMI Result",
                    $"Gender:{this.choice}\nBMI:{bmi}\nHealth Status: Underweight\nRecomendations:{bmiCategories["Underweight"]}",
                    "OK"
                );
            }
            else if ((this.choice == "Male" && bmi >= 18.5 && bmi < 24.9) || (this.choice == "Female" && bmi >= 18.0 && bmi < 23.9))
            {
                await DisplayAlert(
                    "BMI Result",
                    $"Gender:{this.choice}\nBMI:{bmi}\nHealth Status: Normal weight\nRecomendations:{bmiCategories["Normal weight"]}",
                    "OK"
                );
            }
            else if ((this.choice == "Male" && bmi >= 25.0 && bmi < 29.9) || (this.choice == "Female" && bmi >= 24.0 && bmi < 28.9))
            {
                await DisplayAlert(
                    "BMI Result",
                    $"Gender:{this.choice}\nBMI:{bmi}\nHealth Status: Overweight\nRecomendations:{bmiCategories["Overweight"]}",
                    "OK"
                );
            }
            else
            {
                await DisplayAlert(
                    "BMI Result",
                    $"Gender:{this.choice}\nBMI:{bmi}\nHealth Status: Obese\nRecomendations: {bmiCategories["Obesity"]}",
                    "OK"
                );
            }
        }
    }
}
