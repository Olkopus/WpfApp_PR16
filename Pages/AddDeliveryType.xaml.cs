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
    /// Логика взаимодействия для AddDeliveryType.xaml
    /// </summary>
    public partial class AddDeliveryType : Page
       
    {
        private DeliveryType _deliverytype = new DeliveryType();
        public AddDeliveryType(DeliveryType selectedtype)
        {
            InitializeComponent();
            if (selectedtype != null)
            {
               _deliverytype = selectedtype;
            }
            DataContext = _deliverytype;

        }

        private void TextBoxType_TextChanged(object sender, TextChangedEventArgs e)
        {
            txttype.Visibility = Visibility.Visible;
            if (TextBoxType.Text.Length > 0)
            {
               txttype.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_deliverytype.Type))
                errors.AppendLine("Укажите тип доставки!");
          

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_deliverytype.ID == 0)
                Entities.GetContext().DeliveryType.Add(_deliverytype);
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
