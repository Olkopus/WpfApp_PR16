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
using System.Security.Cryptography;
using System.Data.Entity.Validation;

namespace WpfApp_PR16.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
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
        private void TextBoxPassword_Changed(object sender, RoutedEventArgs e)
        {
            txtpassword.Visibility = Visibility.Visible;
            if (TextBoxPassword.Password.Length > 0)
            {
                txtpassword.Visibility = Visibility.Hidden;
            }

        }

        private void TextBoxRepeatPassword_Changed(object sender, RoutedEventArgs e)
        {
            txtrepeatpassword.Visibility = Visibility.Visible;
            if (TextBoxRepeatPassword.Password.Length > 0)
            {
                txtrepeatpassword.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxFIO_Changed(object sender, TextChangedEventArgs e)
        {
            txtfio.Visibility = Visibility.Visible;
            if (TextBoxFIO.Text.Length > 0)
            {
                txtfio.Visibility = Visibility.Hidden;
            }
        }

        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

            NavigationService?.Navigate(new AuthPage());



        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string[] fioo = TextBoxFIO.Text.Split(' ');
            int n = fioo.Length;

            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(TextBoxPassword.Password) || string.IsNullOrEmpty(TextBoxRepeatPassword.Password) || string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }

            

            using (var dbb = new Entities2())
            {
                var user = dbb.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == TextBoxLogin.Text);
                if (user != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                }

                else if (TextBoxPassword.Password != TextBoxRepeatPassword.Password)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }

                else if (TextBoxPassword.Password.Length >= 6)
                {
                    bool en = true; // английская раскладка
                    bool number = false; // цифра

                    for (int i = 0; i < TextBoxPassword.Password.Length; i++) // перебираем символы
                    {
                        if (TextBoxPassword.Password[i] >= 'А' && TextBoxPassword.Password[i] <= 'Я') en = false; // если русская раскладка
                        if (TextBoxPassword.Password[i] >= '0' && TextBoxPassword.Password[i] <= '9') number = true; // если цифры

                    }

                    if (!en)
                        MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                    else if (n != 3)
                        MessageBox.Show("Ошибка при заполнении поля ФИО!");
                    else
                    {
                        if (en && number) // проверяем соответствие
                        {

                            MessageBox.Show("Пользователь зарегистрирован!");
                            ;


                            // Entities2 dbb = new Entities2();
                            User userObject = new User
                            {

                                Login = TextBoxLogin.Text,
                                Password = GetHash(TextBoxPassword.Password),
                                Role = ComboBoxRole.Text,
                                Surname = fioo[0],
                                Name = fioo[1],
                                Patronymic = fioo[2],



                            };
                            dbb.User.Add(userObject);
                            try
                            {
                                dbb.SaveChanges();
                            }
                            catch (DbEntityValidationException ex)
                            {
                                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                                {
                                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                                    MessageBox.Show("");
                                    foreach (DbValidationError err in validationError.ValidationErrors)
                                    {
                                        MessageBox.Show(err.ErrorMessage + "");
                                    }
                                }
                            }
                        }


                        else MessageBox.Show("Пароль слишком короткий, минимум 6 символов.");
                    }


                }


            }



        }

    }
}

