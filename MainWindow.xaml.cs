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
using System.Threading;
using System.IO; 
using System.Diagnostics; 
using Microsoft.Win32; 


namespace WpfApp_PR16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded_Date();
        }
        private void Loaded_Date()
        {
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(0);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LabelDate.Content = DateTime.Now.ToString();
        }

        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) 
                MainFrame.GoBack();
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !(MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.None,MessageBoxResult.No) == MessageBoxResult.Yes);

        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"ProjectByVoynalovichShergina - {page.Title}";

            if (page is Pages.AuthPage)
                ButtonBack.Visibility = Visibility.Hidden;
            else ButtonBack.Visibility = Visibility.Visible;

            if (page is Pages.Calc)
                ButtonGoCalc.Visibility = Visibility.Hidden;
            else ButtonGoCalc.Visibility = Visibility.Visible;

        }

        private void ButtonGoCalc_Click(object sender, RoutedEventArgs e)
        {
           
                MainFrame.NavigationService.Navigate(new Pages.Calc());
            // определяем путь к файлу ресурсов
            var uri = new Uri("DictionaryCalc.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
           SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Только текстовый формат(.txt) | *.txt";
            dlg.ShowDialog();
            string path = dlg.FileName;
            if (dlg.FileName == "")
            {
                MessageBox.Show("Введите имя файла!");
            }
            else
            {


                StreamWriter sw = new StreamWriter(path);
                using (Entities2 db = new Entities2())
                {
                    string IDline = String.Join(":", db.User.Select(x => x.ID));
                    sw.Write(":");
                    sw.WriteLine(IDline);

                    string Loginline = String.Join(":", db.User.Select(x => x.Login));
                    sw.Write(":");
                    sw.WriteLine(Loginline);

                    string Passwordline = String.Join(":", db.User.Select(x => x.Password));
                    sw.Write(":");
                    sw.WriteLine(Passwordline);

                    string Nameline = String.Join(":", db.User.Select(x => x.Name));
                    sw.Write(":");
                    sw.WriteLine(Nameline);

                    string Surnameline = String.Join(":", db.User.Select(x => x.Surname));
                    sw.Write(":");
                    sw.WriteLine(Surnameline);

                    string Patronymicline = String.Join(":", db.User.Select(x => x.Patronymic));
                    sw.Write(":");
                    sw.WriteLine(Patronymicline);

                    string Roleline = String.Join(":", db.User.Select(x => x.Role));
                    sw.Write(":");
                    sw.WriteLine(Roleline);

                    sw.Close();
                    Process.Start("notepad.exe", path);
                }
            }
        }

        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader sr = new StreamReader(ofd.FileName); // открываем файл
                while (!sr.EndOfStream) // перебираем строки, пока они не закончены
                {
                    string[] lines = new string[7];// массив данных 
                    for (int i = 0; i < 7; i++) // читаем 5 строк 
                    {
                        string line = sr.ReadLine(); // читаем строку  
                        string[] data = line.Split(':');
                        line = ""; // обнуляем переменную    
                        if (data.Length >= 2) // проверяем на целостность данных  
                        {
                            for (int j = 1; j < data.Length; j++) // складываем данные      
                            {
                                line += " ";
                                line += data[j]; // собираем строку  
                            }
                        }
                        lines[i] = line; // записываем значения в массив 
                    }
                    // выводим данные 
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] + "\nЛогин: " + lines[1] + "\nПароль: " + lines[2] + "\nИмя: " + lines[3] + "\nФамилия: " + lines[4]+ "\nОтчество: " + lines[5] + "\nРоль: " + lines[6]);
                }

            }
            else MessageBox.Show("Файл для импорта не выбран!");

        }
    }


}
