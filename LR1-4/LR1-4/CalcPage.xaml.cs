using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace LR1_4;

public partial class CalcPage : ContentPage
{
	private StringBuilder insertion = new StringBuilder("0");
    private BinaryExpression expression = new BinaryExpression();
	private bool isFractional = false;
    private bool isNegative = false;

	public CalcPage()
	{
		InitializeComponent();
	}

	private void OnNumButtonClicked(object sender, EventArgs e)
	{
        if (insertion.Length >= 11) return;
        if (insertion.ToString() == "0") insertion.Clear();
        Button button = (Button)sender;
		switch (button.Text)
		{
			case "0":
				insertion.Append("0");
				break;
			case "1":
				insertion.Append("1");
				break;
            case "2":
                insertion.Append("2");
                break;
            case "3":
                insertion.Append("3");
                break;
            case "4":
                insertion.Append("4");
                break;
            case "5":
                insertion.Append("5");
                break;
            case "6":
                insertion.Append("6");
                break;
            case "7":
                insertion.Append("7");
                break;
            case "8":
                insertion.Append("8");
                break;
            case "9":
                insertion.Append("9");
                break;
        }
        EnterLabel.Text = insertion.ToString();
	}

    private void OnDelButtonClicked(object sender, EventArgs e)
    {
        if (insertion.ToString() == "0") return;
        if (insertion.Length > 0)
        {            
            if (insertion[insertion.Length - 1] == ',') isFractional = false;
            insertion.Length--;
            if (insertion.Length == 0) insertion.Append("0");
            if (isNegative && insertion.Length == 1)
            {
                insertion.Clear();
                insertion.Append("0");
                isNegative = false;
            }
            EnterLabel.Text = insertion.ToString();
        }
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        if (insertion.ToString() == "0" || insertion.Length == 0) return;
        if (isNegative)
        {
            insertion.Remove(0, 1);
            isNegative = false;
        }
        else
        {
            insertion.Insert(0, "-");
            isNegative = true;
        }
        EnterLabel.Text = insertion.ToString();
    }

    private void OnFractionalButtonClicked(object sender, EventArgs e)
    {
        if (insertion.ToString() == "0") return;
        if (!isFractional)
        {
            insertion.Append(",");
            isFractional = true;
        }
        EnterLabel.Text = insertion.ToString();
    }

    private void OnBinaryExpressionButtonClicked(object sender, EventArgs e)
    {
        expression.Operand2 = "";
        Button button = (Button)sender;
        expression.Operand1 = insertion.ToString();
        insertion.Clear();
        insertion.Append('0');
        isNegative = false;
        isFractional = false;
        switch (button.Text)
        {
            case "+":
                expression.OperatorString = "+";
                expression.Operator = (double a, double b) => a + b;
                break;
            case "-":
                expression.OperatorString = "-";
                expression.Operator = (double a, double b) => a - b;
                break;
            case "*":
                expression.OperatorString = "*";
                expression.Operator = (double a, double b) => a * b;
                break;
            case "÷":
                expression.OperatorString = "÷";
                expression.Operator = (double a, double b) => a / b;
                break;
            case "mod":
                expression.OperatorString = "mod";
                expression.Operator = (double a, double b) => a % b;
                break;
        }
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(expression.Operand1);
        stringBuilder.Append(" ");
        stringBuilder.Append(expression.OperatorString);
        ExpressionLabel.Text = stringBuilder.ToString();
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        if (expression.Operand2 == "")
        {
            expression.Operand2 = insertion.ToString();
        }
        else
        {
            expression.Operand1 = insertion.ToString();
        }
        double answ = 0;
        try{
            answ = expression.Evaluate();
        }
        catch{
            return;
        }

        insertion.Clear();
        insertion.Append(Convert.ToString(answ));

        if (answ - Math.Floor(answ) == 0) isFractional = false; //Тут баг //или не (хз, вроде нет)
        else isFractional = true;

        if (answ >= 0) isNegative = false;
        else isNegative = true;

        EnterLabel.Text = insertion.ToString();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(expression.Operand1);
        stringBuilder.Append(" ");
        stringBuilder.Append(expression.OperatorString);
        stringBuilder.Append(" ");
        stringBuilder.Append(expression.Operand2);
        stringBuilder.Append(" ");
        stringBuilder.Append("=");
        ExpressionLabel.Text = stringBuilder.ToString();
    }

    private void OnUnaryExpressionButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        double value = Convert.ToDouble(EnterLabel.Text);
        switch (button.Text)
        {
            case ("x²"):
                value = value * value;
                break;
            case ("√x"):
                value = Math.Sqrt(value);
                break;
            case ("1/x"):
                value = 1 / value;
                break;
        }
        insertion.Clear();
        insertion.Append(Convert.ToString(value));
        EnterLabel.Text = insertion.ToString();
    }
}