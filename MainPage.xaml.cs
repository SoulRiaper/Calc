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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Calc
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string eventValue;
        double firstTerm, secondTerm;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            inputForm.Text += button.Content;
        }

        private void dotClickHandler(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            inputForm.Text += button.Content;
            button.IsEnabled = false;
        }

        private void calcButtonHandler(object sender, RoutedEventArgs e)
        {
            if (inputForm.Text == "")
            {
                return;
            }
            secondTerm = Convert.ToDouble(inputForm.Text);
            questionView.Text += secondTerm.ToString();
            inputForm.Text = calculateExample(firstTerm, secondTerm, eventValue);
        }

        private void eventButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            eventValue = (string)(button.Content);
            if (inputForm.Text == "")
            {
                return;
            }
            firstTerm = Convert.ToDouble(inputForm.Text);
            questionView.Text = inputForm.Text+ " " + eventValue;
            dotButton.IsEnabled = true;
            inputForm.Text = "";
            calculateButton.IsEnabled = true;
        }

        private void resetButtonHandler(object sender, RoutedEventArgs e)
        {
            inputForm.Text = "";
            questionView.Text = "";
            dotButton.IsEnabled = true;
            calculateButton.IsEnabled = false;
        }

        private string calculateExample(double firstTerm, double secondTerm, string action)
        {
            double result = 0;
            switch (action)
            {
                case "x":
                    result = firstTerm * secondTerm;
                    break;
                case "/":
                    result = firstTerm / secondTerm;
                    break ;
                case "+":
                    result = firstTerm + secondTerm;
                    break;
                case "-":
                    result = firstTerm - secondTerm;
                    break;
            }
            return Convert.ToString(result);
        }

    }
}
