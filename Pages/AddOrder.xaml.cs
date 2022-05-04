using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp_PR16.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        public AddOrder()
        {
            InitializeComponent();
            ComboBoxProduct.ItemsSource = Entities.GetContext().Product.ToList();
            ComboBoxSurname.ItemsSource = Entities.GetContext().User.ToList();
            ComboBoxTypeOfPayment.ItemsSource = Entities.GetContext().TypeOfPayment.ToList();
            ComboBoxDeliveryType.ItemsSource = Entities.GetContext().DeliveryType.ToList();

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //bool number = false;
            //for(int i = 0; i < TextBoxCost.Text.Length; i++)
            //{
            //    if (TextBoxCost.Text[i] >= '0' && TextBoxCost.Text[i] <= '9') 
            //        number = true;
            //    if (number == false)
            //    {
            //        MessageBox.Show("В поле стоимость заказа могут содержатся только числа.");
            //    }
            //}
          
        }

        //private void TextBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    char number = e.KeyChar;

        //    if (!Char.IsDigit(number))
        //    {
        //        e.Handled = true;
        //    }
        //}
        private void TextBoxCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtcost.Visibility = Visibility.Visible;
            if (TextBoxCost.Text.Length > 0)
            {
                txtcost.Visibility = Visibility.Hidden;
            }
        }
    }
}
