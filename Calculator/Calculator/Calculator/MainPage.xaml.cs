﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string myoperator;
        double firstNumber, secondNumber;
        
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnSelectNumber(object sender, EventArgs e)// Numbers
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                {
                    currentState *= -1;
                }
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)// Operators
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            myoperator = pressed;
        }

        void OnClear(object sender, EventArgs e)// Clear
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnPercentage(object sender, EventArgs e)// Percentage button
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = firstNumber / 100;
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnCalculate(object sender, EventArgs e)// Equals
        {
            if (currentState == 2)
            {
                var result = OperatorHelper.Calculate(firstNumber, secondNumber, myoperator);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnSquareRoot(object sender, EventArgs e)// Root
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = Math.Sqrt(firstNumber);
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnDecimal(object sender, EventArgs e)// Decimal point
        {
            Button button = (Button)sender;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                {
                    currentState *= -1;
                }
            }
            
            this.resultText.Text += ".";

        }
    }
}
