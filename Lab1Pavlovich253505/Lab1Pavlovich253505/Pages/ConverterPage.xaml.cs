using Lab1Pavlovich253505.Services;
using Lab1Pavlovich253505.Entities;

namespace Lab1Pavlovich253505;

public partial class ConverterPage : ContentPage
{
	private IRateService rateService;
    private Rate? currentRate = null;
    private bool isInEntryEntered = false;
    private List<string> currencyCodes = new List<string> {"RUB", "EUR", "USD", "CHF", "CNY", "GBP"};
    private List<Rate> currentRates = new();

    public ConverterPage(IRateService service)
    {
        InitializeComponent();
        Connectivity.ConnectivityChanged += OnConnectivityChanged;
        rateService = service;
        RateDatePicker.MaximumDate = DateTime.Today;
        isInEntryEntered = true;
    }

    private void OnPageLoaded(object sender, EventArgs e) 
    {
        CurrencyPicker.ItemsSource = currencyCodes;
        ConnectivityLabel.Text = "";
        GetRates();                                             
    }

    private void OnConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        if(e.NetworkAccess == NetworkAccess.Internet)
        {
            OnPageLoaded(sender, EventArgs.Empty);
        }
        else
        {
            ConnectivityLabel.Text = "Отсутствует подключение к интернету";
        }
    }

    private void OnCurrencyPickerChanged(object sender, EventArgs e)
	{
        var picker = (Picker)sender;
        string currencyName = (string)picker.SelectedItem;
        foreach (var item in currentRates)
        {
            if (item.Cur_Abbreviation == currencyName)
            {
                currentRate = item;
                break;
            }
        }
        ChangeCurrencyEntry();
	}

    private void OnDateSelected(object sender, EventArgs e)
    {
        GetRates();
        ChangeCurrencyEntry();
    }
    private void OnBYNEntryChanged(object sender, EventArgs e)
	{
        if (!isInEntryEntered) return;
        if (currentRate is null || BYNEntry.Text == "")
        {
            BYNEntry.Text = "";
            return;
        }
        ChangeCurrencyEntry();
    }

	private void OnCurrencyEntryChanged(object sender, EventArgs e)
	{
        if (!isInEntryEntered) return;
        if (currentRate is null || CurrencyEntry.Text == "")
        {
            CurrencyEntry.Text = "";
            return;
        }
        ChangeBynEntry();
    }

    private void GetRates()
    {
        List<Rate> rates;
        try
        {
            rates = rateService.GetRates(RateDatePicker.Date).ToList();
        }
        catch
        {
            return;
        }

        currentRates = new List<Rate>();
        foreach (var rate in rates)
        {
            if(currencyCodes.Contains(rate.Cur_Abbreviation)) currentRates.Add(rate);
        }

        if(currentRate is not null)
        {
            string currencyName = currentRate.Cur_Abbreviation;
            foreach (var item in currentRates)
            {
                if (item.Cur_Abbreviation == currencyName)
                {
                    currentRate = item;
                    break;
                }
            }
        }
        RatesView.ItemsSource = currentRates;
    }

    private void ChangeBynEntry()
    {
        isInEntryEntered = false;
        decimal? sum;
        try
        {
            sum = Convert.ToDecimal(CurrencyEntry.Text);
            sum *= currentRate.Cur_OfficialRate / currentRate.Cur_Scale;
            sum = Math.Round(sum.Value, 4);
            BYNEntry.Text = sum.ToString();
            isInEntryEntered = true;
        }
        catch
        {
            isInEntryEntered = true;
            return;
        }
    }

    private void ChangeCurrencyEntry()
    {
        isInEntryEntered = false;
        decimal? sum;
        try
        {
            sum = Convert.ToDecimal(BYNEntry.Text);
            sum /= currentRate.Cur_OfficialRate / currentRate.Cur_Scale;
            sum = Math.Round(sum.Value, 4);
            CurrencyEntry.Text = sum.ToString();
            isInEntryEntered = true;
        }
        catch
        {
            isInEntryEntered = true;
            return;
        }
    }
}