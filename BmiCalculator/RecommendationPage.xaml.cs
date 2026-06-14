namespace BmiCalculator;

public partial class RecommendationPage : ContentPage
{
    public RecommendationPage(
        string gender,
        string status)
    {
        InitializeComponent();

        RecommendationLabel.Text =
            GetRecommendation(status);
    }

    private string GetRecommendation(
        string status)
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

    private async void BackResults_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BackInput_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}