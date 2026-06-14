namespace BmiCalculator
{
    public partial class MainPage : ContentPage
    {
        private string selectedGender = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void MaleTapped(object sender, TappedEventArgs e)
        {
            selectedGender = "Male";

            MaleBorder.Stroke = Colors.Blue;
            FemaleBorder.Stroke = Colors.Gray;
        }

        private void FemaleTapped(object sender, TappedEventArgs e)
        {
            selectedGender = "Female";

            FemaleBorder.Stroke = Colors.HotPink;
            MaleBorder.Stroke = Colors.Gray;
        }

        private void HeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            HeightLabel.Text = $"{(int)e.NewValue} inches";
        }

        private void WeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            WeightLabel.Text = $"{(int)e.NewValue} lbs";
        }

        private async void CalculateBMI_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedGender))
            {
                await DisplayAlert("Error", "Please select a gender.", "OK");
                return;
            }

            double height = HeightSlider.Value;
            double weight = WeightSlider.Value;

            if (height == 0)
            {
                await DisplayAlert("Error", "Height cannot be zero.", "OK");
                return;
            }

            double bmi = (weight * 703) / (height * height);

            string status = GetBMIStatus(bmi);
            string recommendation = GetRecommendation(status);

            await Navigation.PushAsync(
                new ResultPage(
                    bmi,
                    selectedGender,
                    status));
        }

        private string GetBMIStatus(double bmi)
        {
            if (selectedGender == "Male")
            {
                if (bmi < 18.5)
                    return "Underweight";
                else if (bmi < 25)
                    return "Normal Weight";
                else if (bmi < 30)
                    return "Overweight";
                else
                    return "Obese";
            }
            else
            {
                if (bmi < 18)
                    return "Underweight";
                else if (bmi < 24)
                    return "Normal Weight";
                else if (bmi < 29)
                    return "Overweight";
                else
                    return "Obese";
            }
        }

        private string GetRecommendation(string status)
        {
            switch (status)
            {
                case "Underweight":
                    return "Increase calorie intake with nutrient-rich foods and incorporate strength training.";

                case "Normal Weight":
                    return "Maintain a balanced diet and complete at least 150 minutes of exercise each week.";

                case "Overweight":
                    return "Reduce processed foods, control portions, and increase aerobic exercise and strength training.";

                case "Obese":
                    return "Consult a healthcare provider, follow a structured weight-loss plan, and begin low-impact exercise.";

                default:
                    return "";
            }
        }
    }
}