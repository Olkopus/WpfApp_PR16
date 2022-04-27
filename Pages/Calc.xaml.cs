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

namespace WpfApp_PR16.Pages
{
    /// <summary>
    /// Логика взаимодействия для Calc.xaml
    /// </summary>
    public partial class Calc : Page
    {
        string first_str = "";
        string second_str = "";
        bool k;
        int num;


        public delegate double Operation(double a, double b);
        Operation op;
        public delegate double Operation_one(double c);
        Operation_one op_one;
        public Calc()
        {
            InitializeComponent();
        }

        private void _7TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "7";
            }
            else
            {
                second_str += "7";
            }

            resTB.Text += "7";

        }

        private void _8TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "8";
            }
            else
            {
                second_str += "8";
            }

            resTB.Text += "8";

        }

        private void _9TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "9";
            }
            else
            {
                second_str += "9";
            }

            resTB.Text += "9";
        }

        private void _4TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "4";
            }
            else
            {
                second_str += "4";
            }

            resTB.Text += "4";
        }

        private void _5TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "5";
            }
            else
            {
                second_str += "5";
            }

            resTB.Text += "5";
        }

        private void _6TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "6";
            }
            else
            {
                second_str += "6";
            }

            resTB.Text += "6";
        }

        private void _1TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "1";
            }
            else
            {
                second_str += "1";
            }

            resTB.Text += "1";
        }

        private void _2TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "2";
            }
            else
            {
                second_str += "2";
            }

            resTB.Text += "2";
        }

        private void _3TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "3";
            }
            else
            {
                second_str += "3";
            }

            resTB.Text += "3";
        }

        private void _0TB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += "0";
            }
            else
            {
                second_str += "0";
            }

            resTB.Text += "0";
        }

        private void commaTB_Click(object sender, RoutedEventArgs e)
        {
            if (k == false)
            {
                first_str += ",";
            }
            else
            {
                second_str += ",";
            }

            resTB.Text += ",";
        }

        private void CTB_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text = "";
            first_str = "";
            second_str = "";

        }
        private void substractionTB_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text += "-";
            op = (double a, double b) => { return a - b; };
            k = true;
            num = 1;

        }
        private void eqTB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resTB.Text += "=";
            
                switch (num)
                {

                    case 1:
                        resTB.Text += Convert.ToString(op(Convert.ToDouble(first_str), Convert.ToDouble(second_str)));
                        break;
                    case 0:
                        resTB.Text += Convert.ToString(op_one(Convert.ToDouble(first_str)));
                        break;

                }
                k = false;
            
            }
            catch (FormatException)
            {
                MessageBox.Show("Нужно ввести цифру.", "Ошибка!",
                                                  MessageBoxButton.OK);
                resTB.Text = "";
            }



        }

        private void divisionTB_Click(object sender, RoutedEventArgs e)
        {

            resTB.Text += "/";

            op = (double a, double b) => { return Math.Round(a / b, 3); };

            k = true;
            num = 1;

        }

        private void multiplicationTB_Click(object sender, RoutedEventArgs e)
        {

            resTB.Text += "x";
            op = (double a, double b) => { return a * b; };
            k = true;
            num = 1;
        }

        private void additionTB_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text += "+";
            op = (double a, double b) => { return a + b; };
            k = true;
            num = 1;
        }

        private void pow2TB_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text += "^2";
            num = 0;
            op_one = (double c) => { return c * c; };

        }

        private void pow3TB_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text += "^3";
            num = 0;
            op_one = (double c) => { return c * c * c; };
        }

        private void changeTB_Click(object sender, RoutedEventArgs e)
        {
            k = false;
            resTB.Text += "±";

            num = 0;
            op_one = (double c) => { return 0 - c; };

        }
        private void sqrtTB_Click(object sender, RoutedEventArgs e)
        {

            resTB.Text += "√";
            k = false;

            num = 0;
            op_one = (double c) => { return Math.Sqrt(c); };
        }
       
        
    }

}
