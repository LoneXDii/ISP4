using Lab1Pavlovich253505.Services;
using Lab1Pavlovich253505.Entities;

namespace Lab1Pavlovich253505;

public partial class ConverterPage : ContentPage
{
	private IRateService rateService;
    private decimal? officialRate = 0;
    public ConverterPage(IRateService service)
    {
        InitializeComponent();
        rateService = service;
        RateDatePicker.MaximumDate = DateTime.Today;
    }


    private void OnCurrencyPickerChanged(object sender, EventArgs e)
	{
        var picker = (Picker)sender;
        List<Rate> rates = rateService.GetRates(RateDatePicker.Date).ToList();
        var currency = (string)picker.SelectedItem;
        foreach (var rate in rates)
        {
            if(rate.Cur_Abbreviation == currency)
            {
                officialRate = rate.Cur_OfficialRate;
                break;
            }
        }
	}

    private void OnBYNEntryChanged(object sender, EventArgs e)
	{

	}

	private void OnCurrencyEntryChanged(object sender, EventArgs e)
	{

	}
}