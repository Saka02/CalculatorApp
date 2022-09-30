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

namespace Kalkulator
{
    // <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedoperator;
        public MainWindow()
        {
            InitializeComponent();
            Negativan.Click += Negativan_Click;
            percent.Click += Percent_Click;
            point.Click += Point_Click;
            equal.Click += Equal_Click;

        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            double NewNum;
            if(double.TryParse(Label.Content.ToString(), out NewNum)){
                switch (selectedoperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber,NewNum );
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(lastNumber, NewNum);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastNumber, NewNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(lastNumber, NewNum);
                        break;
                }

            
            }
            Label.Content = result.ToString();  
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (Label.Content.ToString().Contains("."))
            {

            }
            else
            {
                Label.Content = $"{Label.Content}.";
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Label.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                Label.Content = lastNumber.ToString();
            }
        }

        private void Negativan_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Label.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                Label.Content = lastNumber.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.Content = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Label.Content.ToString(), out lastNumber))
            {
                Label.Content = "0";
            }
            if (sender == divide)
                selectedoperator = SelectedOperator.Division;
            if (sender == multiply)
                selectedoperator = SelectedOperator.Multiplication;
            if (sender == sub)
                selectedoperator = SelectedOperator.Subtraction;
            if (sender == add)
                selectedoperator = SelectedOperator.Addition;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == nula)
                selectedValue = 0;
            if (sender == dva)
                selectedValue = 2;
            if (sender == tri)
                selectedValue = 3;
            if (sender == cetiri)
                selectedValue = 4;
            if (sender == pet)
                selectedValue = 5;
            if (sender == sest)
                selectedValue = 6;
            if (sender == sedam)
                selectedValue = 7;
            if (sender == osam)
                selectedValue = 8;
            if (sender == devet)
                selectedValue = 9;

            if (Label.Content.ToString() == "0")
            {
                Label.Content = $"{selectedValue}";
            }
            else
            {
                Label.Content = $"{Label.Content}{selectedValue}";
            }


        }
    }
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public class SimpleMath
        {
        public static double Add(double n1, double n2) {
            return n1 + n2;        
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Wrong input","Wrong operator", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
        
        
    }
}
