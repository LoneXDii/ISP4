using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Lab1Pavlovich253505;

public partial class CalcPage : ContentPage
{
    
    private StringBuilder insertion = new StringBuilder("0");
    private bool isFractional = false;
    private bool isNegative = false;
    private double? operand1 = null;
    private double? operand2 = null;
    private string currOperator = "";
    private Func<double, double, double>? operation = null;
    private double? memory = null;

    public CalcPage()
    {
        InitializeComponent();
    }

    private void OnNumButtonClicked(object sender, EventArgs e)
    {
        if (insertion.Length >= 11) return;
        if (insertion.ToString() == "0") insertion.Clear();

        Button button = (Button)sender;

        insertion.Append(button.Text);

        EnterLabel.Text = insertion.ToString();
    }

    private void OnDelButtonClicked(object sender, EventArgs e)
    {
        insertion.Clear();
        insertion.Append(EnterLabel.Text);
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
        if (!isFractional)
        {
            insertion.Append(",");
            isFractional = true;
        }
        EnterLabel.Text = insertion.ToString();
    }

    private void OnBinaryExpressionButtonClicked(object sender, EventArgs e)
    {
        bool isReadyForOperation = false;
        if(insertion.ToString() == EnterLabel.Text && !ExpressionLabel.Text.Contains('='))
        {
            isReadyForOperation = true;
        }
        
        if (isReadyForOperation && operation is not null && operand1 is not null)
        {
            try
            {
                operand1 = operation(Convert.ToDouble(EnterLabel.Text), (double)operand1);
            }
            catch { }
        }
        else
        {
            try
            {
                operand1 = Convert.ToDouble(EnterLabel.Text.ToString());
            }
            catch { }
        }

        insertion.Clear();
        insertion.Append('0');
        isNegative = false;
        isFractional = false;

        Button button = (Button)sender;

        if (button.Equals(AddButton))
        {
            currOperator = "+";
            operation = (double a, double b) => a + b;
        }
        else if (button.Equals(SubButton))
        {
            currOperator = "-";
            operation = (double a, double b) => a - b;
        }
        else if (button.Equals(MulButton))
        {
            currOperator = "*";
            operation = (double a, double b) => a * b;
        }
        else if (button.Equals(DivButton))
        {
            currOperator = "÷";
            operation = (double a, double b) => a / b;
        }
        else if (button.Equals(ModButton))
        {
            currOperator = "mod";
            operation = (double a, double b) => a % b;
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(operand1);

        if (stringBuilder.ToString() != EnterLabel.Text)
        {
            stringBuilder = FixString(stringBuilder);
            EnterLabel.Text = stringBuilder.ToString();
        }

        stringBuilder.Append(" ");
        stringBuilder.Append(currOperator);
        ExpressionLabel.Text = stringBuilder.ToString();
        operand2 = null;
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if(operand2 is null)
                operand2 = Convert.ToDouble(EnterLabel.Text.ToString());
            else operand1 = Convert.ToDouble(EnterLabel.Text.ToString());
        }
        catch
        {
            return;
        }

        double answ;
        if (operation is not null &&
            operand1 is not null &&
            operand2 is not null)
        {
            answ = operation((double)operand1, (double)operand2);
        }
        else
            return;

        insertion.Clear();
        insertion.Append(Convert.ToString(answ));

        if (answ - Math.Floor(answ) == 0)
            isFractional = false;
        else
            isFractional = true;

        if (answ >= 0)
            isNegative = false;
        else
            isNegative = true;

        insertion = FixString(insertion);
        EnterLabel.Text = insertion.ToString();

        StringBuilder stringBuilder = new StringBuilder();
        StringBuilder temp = new StringBuilder();
        temp.Append(operand1.ToString());
        temp = FixString(temp);
        stringBuilder.Append(temp.ToString()); ;

        stringBuilder.Append(" ");
        stringBuilder.Append(currOperator);
        stringBuilder.Append(" ");

        temp.Clear();
        temp.Append(operand2.ToString());
        temp = FixString(temp);
        stringBuilder.Append(temp.ToString());
        stringBuilder.Append(" ");
        stringBuilder.Append("=");

        ExpressionLabel.Text = stringBuilder.ToString();
    }

    private void OnUnaryExpressionButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        double value = 0;
        try
        {
            value = Convert.ToDouble(EnterLabel.Text);
        }
        catch
        {
            return;
        }

        if (button.Equals(Pow2Button))
        {
            value = value * value;
            isNegative = false;
        }
        else if (button.Equals(SqrtXButton))
        {
            value = Math.Sqrt(value);
        }
        else if (button.Equals(DivXButton))
        {
            value = 1 / value;
        }
        else if (button.Equals(PercentButton))
        {
            value = value / 100;
        }

        insertion.Clear();
        insertion.Append(Convert.ToString(value));
        insertion = FixString(insertion);
        EnterLabel.Text = insertion.ToString();
    }

    private StringBuilder FixString(StringBuilder sb)
    {
        int ePos = sb.Length - 1;
        if (sb.ToString().Contains("E"))
        {
            ePos = sb.ToString().IndexOf("E");
        }
        if (sb.Length > 11)
        {
            int len = sb.Length - 11;
            sb.Remove(ePos - len, len);
        }
        return sb;
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        insertion.Clear();
        insertion.Append("0");
        isNegative = false;
        isFractional = false;
        if (ExpressionLabel.Text.Contains('=')) ExpressionLabel.Text = "";
        EnterLabel.Text = insertion.ToString();
    }

    private void OnClearAllButtonClicked(object sender, EventArgs e)
    {
        insertion.Clear();
        insertion.Append("0");
        isNegative = false;
        isFractional = false;
        operand1 = null;
        operand2 = null;
        currOperator = "";
        operation = null;
        EnterLabel.Text = "0";
        ExpressionLabel.Text = "";
    }

    private void OnMemoryCleanButtonClicked(object sender, EventArgs e)
    {
        memory = null;
    }

    private void OnMemoryCallButtonClicked(object sender, EventArgs e)
    {
        if (memory is not null)
        {
            if(memory - Math.Floor((double)memory) != 0)
                isFractional = true;
            else
                isFractional = false;

            if(memory >= 0)
                isNegative = false;
            else
                isNegative = true;

            insertion.Clear();
            insertion.Append(memory.ToString());
            EnterLabel.Text = memory.ToString();
        }
    }

    private void OnMemoryAddButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (memory is not null)
            {
                memory += Convert.ToDouble(EnterLabel.Text);
            }
            else
            {
                memory = Convert.ToDouble(EnterLabel.Text);
            }
        }
        catch 
        {
            return;
        }
    }

    private void OnMemorySubButtonClicked(object sender, EventArgs e)
    {
        try
        {
            if (memory is not null)
            {
                memory -= Convert.ToDouble(EnterLabel.Text);
            }
            else
            {
                memory = -Convert.ToDouble(EnterLabel.Text);
            }
        }
        catch
        {
            return;
        }
    }

    private void OnMemorySaveButtonClicked(object sender, EventArgs e)
    {
        try
        {
            memory = Convert.ToDouble(EnterLabel.Text);
        }
        catch
        {
            return;
        }
    }

    private void OnNumButtonPressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#323232");
    }

    private void OnNumButtonReleased(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#3B3B3B");
    }

    private void OnFunctionButtonPressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#3B3B3B");
    }

    private void OnFunctionButtonReleased(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#323232");
    }

    private void OnMemoryButtonPressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#323232");
    }

    private void OnMemoryButtonReleased(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#1F1F1F");
    }

    private void OnEqualsButtonPressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#47B1E8");
    }

    private void OnEqualsButtonReleased(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Color.FromArgb("#4CC2FF");
    }
}