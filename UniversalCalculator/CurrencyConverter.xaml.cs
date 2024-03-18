using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
			StartCurrencyComboBox.SelectedIndex = 0;
			EndCurrencyComboBox.SelectedIndex = 0;
		}

		private void CurrencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			decimal amount = decimal.Parse(AmountTextBox.Text);
			int fromCurrencyIndex = StartCurrencyComboBox.SelectedIndex;
			int toCurrencyIndex = EndCurrencyComboBox.SelectedIndex;
			string fromCurrency = "US Dollar";
			string toCurrency = "US Dollar";
			decimal conversionRate = 1;

			if (fromCurrencyIndex == 1)
			{
				fromCurrency = "British Pound";
			}

			if (fromCurrencyIndex == 2)
			{
				fromCurrency = "Euro";
			}

			if (fromCurrencyIndex == 3)
			{
				fromCurrency = "Indian Rupee";
			}

			if (toCurrencyIndex == 1)
			{
				toCurrency = "British Pound";
			}

			if (toCurrencyIndex == 2)
			{
				toCurrency = "Euro";
			}

			if (toCurrencyIndex == 3)
			{
				toCurrency = "Indian Rupee";
			}

			if (fromCurrency == "US Dollar")
			{
				if (toCurrency == "Euro")
				{
					conversionRate = 0.85189982m;
				}
				else if (toCurrency == "British Pound")
				{
					conversionRate = 0.72872436m;
				}
				else if (toCurrency == "Indian Rupee")
				{
					conversionRate = 74.257327m;
				}
			}
			else if (fromCurrency == "Euro")
			{
				if (toCurrency == "US Dollar")
				{
					conversionRate = 1.1739732m;
				}
				else if (toCurrency == "British Pound")
				{
					conversionRate = 0.8556672m;
				}
				else if (toCurrency == "Indian Rupee")
				{
					conversionRate = 87.00755m;
				}
			}
			else if (fromCurrency == "British Pound")
			{
				if (toCurrency == "US Dollar")
				{
					conversionRate = 1.371907m;
				}
				else if (toCurrency == "Euro")
				{
					conversionRate = 1.1686692m;
				}
				else if (toCurrency == "Indian Rupee")
				{
					conversionRate = 101.68635m;
				}
			}
			else if (fromCurrency == "Indian Rupee")
			{
				if (toCurrency == "US Dollar")
				{
					conversionRate = 0.011492628m;
				}
				else if (toCurrency == "Euro")
				{
					conversionRate = 0.013492774m;
				}
				else if (toCurrency == "British Pound")
				{
					conversionRate = 0.0098339397m;
				}
			}

			decimal convertedAmount = amount * conversionRate;

			fromCurrencyAmountTextBlock.Text = $"{amount} {fromCurrency}";
			toCurrencyAmountTextBlock.Text = $"{convertedAmount} {toCurrency}";

			fromCurrencyUnitTextBlock.Text = $"1 {fromCurrency} = {conversionRate} {toCurrency}";
			toCurrencyUnitTextBlock.Text = $"1 {toCurrency} = {1 / conversionRate} {fromCurrency}";
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
