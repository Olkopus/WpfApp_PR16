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
            DataGridSuppliers.ItemsSource = Entities.GetContext().Supplier.ToList();
            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddSupplier((sender as Button).DataContext as Supplier));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddSupplier(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var SuppliersForRemoving = DataGridSuppliers.SelectedItems.Cast<Supplier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {SuppliersForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Supplier.RemoveRange(SuppliersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridSuppliers.ItemsSource = Entities.GetContext().Supplier.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void DataGridSuppliers_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridSuppliers.ItemsSource = Entities.GetContext().Supplier.ToList();
            }
        }
    }
}
