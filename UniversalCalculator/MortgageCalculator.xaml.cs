using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	/// Author: Simona Cancian
	/// Feature Mortgage Calculator
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void btnCalculate_Click(object sender, RoutedEventArgs e)
		{
			double principalBorrow, yearlyInterestRate, monthlyInterestRate, monthlyRepayment;
			int years, months;

			// Handle principalBorrow user input
			if (string.IsNullOrWhiteSpace(principalBorrowTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Please fill this field.");
				await dialogMessage.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}

			try
			{
				principalBorrow = double.Parse(principalBorrowTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please enter a valid numeric amount: " + ex.Message);
				await dialogMessage.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}
			// Handle years user input
			if (string.IsNullOrWhiteSpace(yearsTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Please fill this field.");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please enter a valid numeric amount: " + ex.Message);
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}
			// Handle months user input
			if (string.IsNullOrWhiteSpace(monthsTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Please fill this field.");
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please enter a valid numeric amount" + ex.Message);
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}
			// Handle yearlyInterestRate user input
			if (string.IsNullOrWhiteSpace(yearlyInterestRateTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Please fill this field.");
				await dialogMessage.ShowAsync();
				yearlyInterestRateTextBox.Focus(FocusState.Programmatic);
				yearlyInterestRateTextBox.SelectAll();
				return;
			}

			try
			{
				yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please enter a valid numeric amount" + ex.Message);
				await dialogMessage.ShowAsync();
				yearlyInterestRateTextBox.Focus(FocusState.Programmatic);
				yearlyInterestRateTextBox.SelectAll();
				return;
			}

			CalculateMonthlyRepayment(principalBorrow, yearlyInterestRate, years, months);

		}

		private void bnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void CalculateMonthlyRepayment(double principalBorrow, double yearlyInterestRate, int years, int months)
		{
			int totalMonths = years * 12 + months;
			double monthlyInterestRate = yearlyInterestRate / 12 / 100;
			// Mortgage repayment equation: M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]
			double monthlyRepayment = principalBorrow * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths) / (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);
			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("F4") + "%";
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("F2");
		}
	}
}
