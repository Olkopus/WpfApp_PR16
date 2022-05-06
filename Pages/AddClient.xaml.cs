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
        private User _user = new User();

        public AddClient(User selecteduser)
        {
            InitializeComponent();
            if(selecteduser != null)
            {
                _user = selecteduser;
            }
            DataContext = _user;
           

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
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_user.Surname))
                errors.AppendLine("Укажите фамилию!");
            if (string.IsNullOrWhiteSpace(_user.Name))
                errors.AppendLine("Укажите имя!");
            if (string.IsNullOrWhiteSpace(_user.Login))
                errors.AppendLine("Укажите логин!");
            if (string.IsNullOrWhiteSpace(_user.Password))
                errors.AppendLine("Укажите пароль!");
            if (string.IsNullOrWhiteSpace(_user.Email))
                errors.AppendLine("Укажите почту!");
            if (string.IsNullOrWhiteSpace(_user.PhoneNumber))
                errors.AppendLine("Укажите номер телефона!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_user.ID == 0)
                Entities.GetContext().User.Add(_user);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

           


        }
       
    }
}
