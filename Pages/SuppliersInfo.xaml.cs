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
    /// Логика взаимодействия для SuppliersInfo.xaml
    /// </summary>
    public partial class SuppliersInfo : Page
    {
        public SuppliersInfo()
        {
            InitializeComponent();
            DataGridSuppliers.ItemsSource = Entities2.GetContext().Supplier.ToList();
            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddSupplier());
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
