using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для povar.xaml
    /// </summary>
    public partial class povar : Page
    {
        public static ObservableCollection<Users> users { get; set; }
        public static ObservableCollection<orders> order { get; set; }
        public static g0spodbEntities1 db = new g0spodbEntities1();
        public povar()
        {
            InitializeComponent();
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList()); //таблицу в лист
            order = new ObservableCollection<orders>(bd_connecton.connection.orders.ToList()); //таблицу в лист
            this.DataContext = this;

        }

        private void new_order(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new new_order()); //открыть страницу добавления заказов
        }

        private void Btn_back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new new_page());
        }
    }
}
