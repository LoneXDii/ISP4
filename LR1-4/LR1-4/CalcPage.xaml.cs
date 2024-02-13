using System.Diagnostics;
using System.Text;

namespace LR1_4;

public partial class CalcPage : ContentPage
{
	private StringBuilder stringBuilder = new StringBuilder("0");
	private bool isFractional = false;
    private bool isNegative = false;

	public CalcPage()
	{
		InitializeComponent();
	}

	private void OnNumButtonClicked(object sender, EventArgs e)
	{
        if (stringBuilder.Length >= 11) return;
        if (stringBuilder.ToString() == "0") stringBuilder.Clear();
        Button button = (Button)sender;
		switch (button.Text)
		{
			case "0":
				stringBuilder.Append("0");
				break;
			case "1":
				stringBuilder.Append("1");
				break;
            case "2":
                stringBuilder.Append("2");
                break;
            case "3":
                stringBuilder.Append("3");
                break;
            case "4":
                stringBuilder.Append("4");
                break;
            case "5":
                stringBuilder.Append("5");
                break;
            case "6":
                stringBuilder.Append("6");
                break;
            case "7":
                stringBuilder.Append("7");
                break;
            case "8":
                stringBuilder.Append("8");
                break;
            case "9":
                stringBuilder.Append("9");
                break;
        }
        EnterLabel.Text = stringBuilder.ToString();
	}

    private void OnDelButtonClicked(object sender, EventArgs e)
    {
        if (stringBuilder.ToString() == "0") return;
        if (stringBuilder.Length > 0)
        {            
            if (stringBuilder[stringBuilder.Length - 1] == ',') isFractional = false;
            stringBuilder.Length--;
            if (stringBuilder.Length == 0) stringBuilder.Append("0");
            if (isNegative && stringBuilder.Length == 1)
            {
                stringBuilder.Clear();
                stringBuilder.Append("0");
                isNegative = false;
            }
            EnterLabel.Text = stringBuilder.ToString();
        }
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        if (stringBuilder.ToString() == "0" || stringBuilder.Length == 0) return;
        if (isNegative)
        {
            stringBuilder.Remove(0, 1);
            isNegative = false;
        }
        else
        {
            stringBuilder.Insert(0, "-");
            isNegative = true;
        }
        EnterLabel.Text = stringBuilder.ToString();
    }

    private void OnFractionalButtonClicked(object sender, EventArgs e)
    {
        if (stringBuilder.ToString() == "0") return;
        if (!isFractional)
        {
            stringBuilder.Append(",");
            isFractional = true;
        }
        EnterLabel.Text = stringBuilder.ToString();
    }
}