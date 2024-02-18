using System.Diagnostics;

namespace Lab1Pavlovich253505;

public partial class ProgressBar : ContentPage
{
    private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private CancellationToken cancellationToken = cancellationTokenSource.Token;
	public ProgressBar()
	{
		InitializeComponent();
	}

    private async Task calculate()
    {
        double n = 1e8;
        double h = 1 / n;
        double result = 0;
        double perCounter = 0;
        for (int i = 0; i < n; i++)
        {
            double per = i / n;
            result += Math.Sin(h / 2 + i * h);
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            if (perCounter < per)
            {
                perCounter += 0.001;
                ProgressPercentLabel.Text = $"{Math.Round(perCounter*100,0)}%";
                await CalculationProgressBar.ProgressTo(perCounter, 5, Easing.Linear);
            }
        }
        result *= h;
        StatusLabel.Text = result.ToString();
    }

    private async void OnStartButtonClicked(object sender, EventArgs e)
    {
        StartButton.IsEnabled = false;
        StatusLabel.Text = "Вычисление";
        cancellationTokenSource = new CancellationTokenSource();
        cancellationToken = cancellationTokenSource.Token;
        await calculate();
        StartButton.IsEnabled = true;
    }

    private void OnCancellButtonClicked(object sender, EventArgs e)
    {
        StatusLabel.Text = "Задание отменено";
        cancellationTokenSource.Cancel();
    }
}