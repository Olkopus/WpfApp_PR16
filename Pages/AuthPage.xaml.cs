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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void TextBoxLogin_Changed(object sender, RoutedEventArgs e)
        {
            txtlogin.Visibility = Visibility.Visible;
            if (TextBoxLogin.Text.Length > 0)
            {
                txtlogin.Visibility = Visibility.Hidden;
            }

        }

 private void PasswordBox_Changed(object sender, RoutedEventArgs e)
        {
            txtpassword.Visibility = Visibility.Visible;
            if (PasswordBox.SecurePassword.Length > 0)
            {
                txtpassword.Visibility = Visibility.Hidden;
            }

        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var db = new Entities2())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!");
                }
                else
                {
                    MessageBox.Show("Пользователь успешно найден!");
                    switch(user.Role)
                    {
                        case "Клиент":
                            NavigationService?.Navigate(new Client());
                            break;
                        case "Менеджер":
                            NavigationService?.Navigate(new Manager());
                            break;

                    }
                }

            }


        }

        private void Button_Reg(object sender, RoutedEventArgs e)
        {

            NavigationService?.Navigate(new RegPage());
        }



        }
    
}
