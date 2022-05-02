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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtsurname.Visibility = Visibility.Visible;
            if (TextBoxSurname.Text.Length > 0)
            {
                txtsurname.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtname.Visibility = Visibility.Visible;
            if (TextBoxName.Text.Length > 0)
            {
                txtname.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxPatronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtpatronymic.Visibility = Visibility.Visible;
            if (TextBoxPatronymic.Text.Length > 0)
            {
                txtpatronymic.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtlogin.Visibility = Visibility.Visible;
            if (TextBoxLogin.Text.Length > 0)
            {
                txtlogin.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtpassword.Visibility = Visibility.Visible;
            if (TextBoxPassword.Text.Length > 0)
            {
                txtpassword.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtnumber.Visibility = Visibility.Visible;
            if (TextBoxNumber.Text.Length > 0)
            {
                txtnumber.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtemail.Visibility = Visibility.Visible;
            if (TextBoxEmail.Text.Length > 0)
            {
                txtemail.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
