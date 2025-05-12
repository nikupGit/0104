using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        private readonly string[] currencies = { "RUB", "USD", "EUR", "GBP", "UAH" };

        public MainWindow()
        {
            InitializeComponent();
            InitializeCurrencyLists();
        }

        private void InitializeCurrencyLists()
        {
            CurrencyFromListBox.ItemsSource = currencies;
            CurrencyToListBox.ItemsSource = currencies;

            CurrencyFromListBox.SelectedIndex = 0;
            CurrencyToListBox.SelectedIndex = 1;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(AmountTextBox.Text, out double amount) || amount <= 0)
                {
                    MessageBox.Show("Пожалуйста, введите корректное положительное число.", "Ошибка ввода",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (CurrencyFromListBox.SelectedItem == null || CurrencyToListBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите исходную и целевую валюту.", "Ошибка выбора",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string fromCurrency = CurrencyFromListBox.SelectedItem.ToString();
                string toCurrency = CurrencyToListBox.SelectedItem.ToString();

                string googleUrl = $"https://www.google.com/search?q={Uri.EscapeDataString($"{amount} {fromCurrency} в {toCurrency}")}";

                ResultsWebView2.Source = new Uri(googleUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
