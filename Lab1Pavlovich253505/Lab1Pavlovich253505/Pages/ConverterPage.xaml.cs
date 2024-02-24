using Lab1Pavlovich253505.Services;
using Lab1Pavlovich253505.Entities;

namespace Lab1Pavlovich253505;

public partial class ConverterPage : ContentPage
{
	private IRateService rateService;
    private decimal? officialRate = 0;
    private int scale = 0;
    private string currencyName = "";
    private bool isInEntryEntered = false;
    public ConverterPage(IRateService service)
    {
        InitializeComponent();
        rateService = service;
        RateDatePicker.MaximumDate = DateTime.Today;
        isInEntryEntered = true;
    }


    private void OnCurrencyPickerChanged(object sender, EventArgs e)
	{
        var picker = (Picker)sender;
        currencyName = (string)picker.SelectedItem;
        GetRate();
	}

    private void OnDateSelected(object sender, EventArgs e)
    {
        if (currencyName == "") return;
        GetRate();
    }
    private void OnBYNEntryChanged(object sender, EventArgs e)
	{
        if (!isInEntryEntered) return;
        if (officialRate == 0 || BYNEntry.Text == "")
        {
            BYNEntry.Text = "";
            return;
        }
        isInEntryEntered = false;
        decimal? sum;
        try
        {
            sum = Convert.ToDecimal(BYNEntry.Text);
            sum /= officialRate / scale;
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

	private void OnCurrencyEntryChanged(object sender, EventArgs e)
	{
        if (!isInEntryEntered) return;
        if (officialRate == 0 || CurrencyEntry.Text == "")
        {
            CurrencyEntry.Text = "";
            return;
        }
        isInEntryEntered = false;
        decimal? sum;
        try
        {
            sum = Convert.ToDecimal(CurrencyEntry.Text);
            sum *= officialRate / scale;
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

    private void GetRate()
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
        foreach (var rate in rates)
        {
            if (rate.Cur_Abbreviation == currencyName)
            {
                officialRate = rate.Cur_OfficialRate;
                scale = rate.Cur_Scale;
                break;
            }
        }

        isInEntryEntered = false;
        decimal? sum;
        try
        {
            sum = Convert.ToDecimal(BYNEntry.Text);
            sum /= officialRate / scale;
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