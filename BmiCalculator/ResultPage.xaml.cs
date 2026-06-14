namespace BmiCalculator;

public partial class ResultPage : ContentPage
{
    private readonly double bmi;
    private readonly string gender;
    private readonly string status;

    public ResultPage(
        double bmi,
        string gender,
        string status)
    {
        InitializeComponent();

        this.bmi = bmi;
        this.gender = gender;
        this.status = status;

        BmiLabel.Text = $"BMI: {bmi:F1}";
        CategoryLabel.Text = $"Category: {status}";
    }

    private async void Recommendations_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new RecommendationPage(
                gender,
                status));
    }

    private async void Back_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}