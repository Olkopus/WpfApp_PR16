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
    /// Логика взаимодействия для AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Page
    {

        private Supplier _supplier = new Supplier();

        public AddSupplier(Supplier selectedsupplier)
        {
            InitializeComponent();
            if (selectedsupplier != null)
            {
                _supplier = selectedsupplier;
            }
            DataContext = _supplier;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_supplier.Name))
                errors.AppendLine("Укажите наименование!");
            if (string.IsNullOrWhiteSpace(_supplier.INN))
                errors.AppendLine("Укажите ИНН!");
            if (string.IsNullOrWhiteSpace(_supplier.LegalAddres))
                errors.AppendLine("Укажите Юридический адрес!");
            if (string.IsNullOrWhiteSpace(_supplier.SettlementAccount))
                errors.AppendLine("Укажите расчётный счёт!");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_supplier.ID == 0)
                Entities.GetContext().Supplier.Add(_supplier);
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

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtname.Visibility = Visibility.Visible;
            if (TextBoxName.Text.Length > 0)
            {
                txtname.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxINN_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtinn.Visibility = Visibility.Visible;
            if (TextBoxINN.Text.Length > 0)
            {
                txtinn.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtaddres.Visibility = Visibility.Visible;
            if (TextBoxAdress.Text.Length > 0)
            {
                txtaddres.Visibility = Visibility.Hidden;
            }
        }

        private void TextBoxAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtaccount.Visibility = Visibility.Visible;
            if (TextBoxAccount.Text.Length > 0)
            {
                txtaccount.Visibility = Visibility.Hidden;
            }

        }
    }
}
