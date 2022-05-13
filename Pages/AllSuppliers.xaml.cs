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
    /// Логика взаимодействия для AllSuppliers.xaml
    /// </summary>
    public partial class AllSuppliers : Page
    {
        public AllSuppliers()
        {
            InitializeComponent();
            var currentSupplier = Entities.GetContext().Supplier.ToList();
            ListUser.ItemsSource = currentSupplier;
            ComboBoxSort.SelectedIndex = 0;
            UpdateSuppliers();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxName.Clear();
      
            ComboBoxSort.SelectedIndex = 0;
            TextBoxINN.Clear();
            UpdateSuppliers();
        }

        private void UpdateSuppliers()
        {
            //загружаем всех пользователей в список
            var currentsupplier = Entities.GetContext().Supplier.ToList();

           
            currentsupplier = currentsupplier.Where(x => x.Name.ToLower().Contains(TextBoxName.Text.ToLower())).ToList();

            if(TextBoxINN != null)
            {
                currentsupplier = currentsupplier.Where(x => x.INN.ToLower().Contains(TextBoxINN.Text.ToLower())).ToList();
            }
           
          
            //осуществляем сортировку в зависимости от выбора пользователя
            if (ListUser != null)
            {
                if (ComboBoxSort.SelectedIndex == 0)
                    ListUser.ItemsSource = currentsupplier.OrderBy(x => x.Name).ToList();
                else ListUser.ItemsSource = currentsupplier.OrderByDescending(x => x.Name).ToList();
            }


        }
        

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtname.Visibility = Visibility.Visible;
            if (TextBoxName.Text.Length > 0)
            {
                txtname.Visibility = Visibility.Hidden;
            }
            UpdateSuppliers();
        }

        private void TextBoxINN_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtinn.Visibility = Visibility.Visible;
            if (TextBoxINN.Text.Length > 0)
            {
                txtinn.Visibility = Visibility.Hidden;
            }
            UpdateSuppliers();

        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSuppliers();
        }
    }
}
