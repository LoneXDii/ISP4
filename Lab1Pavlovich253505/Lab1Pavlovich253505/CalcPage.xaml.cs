﻿using System.Diagnostics;
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
            operand1 = Convert.ToDouble(EnterLabel.Text.ToString());
        }

        insertion.Clear();
        insertion.Append('0');
        isNegative = false;
        isFractional = false;

        Button button = (Button)sender;

        switch (button.Text)
        {
            case "+":
                currOperator = "+";
                operation = (double a, double b) => a + b;
                break;
            case "-":
                currOperator = "-";
                operation = (double a, double b) => a - b;
                break;
            case "*":
                currOperator = "*";
                operation = (double a, double b) => a * b;
                break;
            case "÷":
                currOperator = "÷";
                operation = (double a, double b) => a / b;
                break;
            case "mod":
                currOperator = "mod";
                operation = (double a, double b) => a % b;
                break;
        }
        
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(operand1);

        if(stringBuilder.ToString() != EnterLabel.Text)
            EnterLabel.Text = stringBuilder.ToString();

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

        EnterLabel.Text = insertion.ToString();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(operand1.ToString()); ;
        stringBuilder.Append(" ");
        stringBuilder.Append(currOperator);
        stringBuilder.Append(" ");
        stringBuilder.Append(operand2.ToString());
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
            case ("%"):
                value = value / 100;
                break;
        }
        insertion.Clear();
        insertion.Append(Convert.ToString(value));
        EnterLabel.Text = insertion.ToString();
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
}