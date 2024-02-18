using System.Diagnostics;

namespace Lab1Pavlovich253505;

public partial class ProgressBar : ContentPage
{
	public ProgressBar()
	{
		InitializeComponent();
	}

    private async Task<double> calculate()
    {
        double n = 1e8;
        double h = 1 / n;
        double result = 0;
        double perCounter = 0;
        for (int i = 0; i < n; i++)
        {
            double per = i / n;
            result += Math.Sin(h / 2 + i * h);
            if (perCounter < per)
            {
                perCounter += 0.01;
                ProgressPercentLabel.Text = $"{Math.Round(perCounter*100,0)}%";
                await CalculationProgressBar.ProgressTo(perCounter, 10, Easing.Linear);
            }
        }
        result *= h;
        return result;
    }

    private async void OnStartButtonClicked(object sender, EventArgs e)
    {
        double answ = await calculate();
        StatusLabel.Text = answ.ToString();
    }
}