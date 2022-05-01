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
    /// Логика взаимодействия для AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Page
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtname.Visibility = Visibility.Visible;
            if (TextBoxName.Text.Length > 0)
            {
                txtname.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxINN_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtinn.Visibility = Visibility.Visible;
            if (TextBoxINN.Text.Length > 0)
            {
                txtinn.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtaddres.Visibility = Visibility.Visible;
            if (TextBoxAdress.Text.Length > 0)
            {
                txtaddres.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtaccount.Visibility = Visibility.Visible;
            if (TextBoxAccount.Text.Length > 0)
            {
                txtaccount.Visibility = Visibility.Hidden;
            }

        }
    }
}
