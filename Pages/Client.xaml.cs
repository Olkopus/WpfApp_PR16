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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {

        public Client()
        {
            InitializeComponent();
        }

        public string Login { get; internal set; }
        public string Role { get; internal set; }
        public string Surname { get; internal set; }
        public string Patronymic { get; internal set; }
        public string Password { get; internal set; }
        public string Name { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public int ID { get; internal set; }
    }
}
