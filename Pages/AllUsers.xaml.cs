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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        public AllUsers()
        {
            InitializeComponent();
            var currentUsers = Entities.GetContext().User.ToList();
            ListUser.ItemsSource = currentUsers;
            ComboBoxSort.SelectedIndex = 0;
            CheckBoxOnlyClients.IsChecked = false;

            UpdateUsers();

        }

        private void UpdateUsers()
        {
           
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().User.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            
   
            currentUsers = currentUsers.Where(x => x.Surname.ToLower().Contains(TextBoxFIO.Text.ToLower())).ToList();


            //обрабатываем фильтр по одной роли пользователей
            if (CheckBoxOnlyClients !=null && CheckBoxOnlyClients.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.Role.Contains("Клиент")).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (ListUser != null)
            {
                if(ComboBoxSort.SelectedIndex == 0)
                    ListUser.ItemsSource = currentUsers.OrderBy(x => x.Surname).ToList();
                else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.Surname).ToList();
            }

        }

            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtfio.Visibility = Visibility.Visible;
            if (TextBoxFIO.Text.Length > 0)
            {
                txtfio.Visibility = Visibility.Hidden;
            }
            UpdateUsers();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFIO.Clear();
            CheckBoxOnlyClients.IsChecked = false;
            ComboBoxSort.SelectedIndex = 0;
            UpdateUsers();
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void CheckBoxOnlyClients_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();            
        }

        private void CheckBoxOnlyClients_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();         
        }
    }
}
