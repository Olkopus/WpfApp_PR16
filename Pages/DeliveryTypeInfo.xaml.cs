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
    /// Логика взаимодействия для DeliveryTypeInfo.xaml
    /// </summary>
    public partial class DeliveryTypeInfo : Page
    {
        public DeliveryTypeInfo()
        {
            InitializeComponent();
            DataGridDelivery.ItemsSource = Entities.GetContext().DeliveryType.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddDeliveryType((sender as Button).DataContext as DeliveryType));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddDeliveryType(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var DeliveryForRemoving = DataGridDelivery.SelectedItems.Cast<DeliveryType>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {DeliveryForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().DeliveryType.RemoveRange(DeliveryForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridDelivery.ItemsSource = Entities.GetContext().DeliveryType.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void DataGridDelivery_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridDelivery.ItemsSource = Entities.GetContext().DeliveryType.ToList();
            }
        }
    }
}
