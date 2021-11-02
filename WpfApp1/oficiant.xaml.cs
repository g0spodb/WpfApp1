using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для oficiant.xaml
    /// </summary>
    public partial class oficiant : Page
    {
        public static ObservableCollection<Users> users { get; set; }
        public static g0spodbEntities1 db = new g0spodbEntities1();
        public oficiant()
        {
            InitializeComponent();
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList());

        }

        private void new_order(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new new_order());
        }

        private void ListOrders_Loaded(object sender, RoutedEventArgs e)
        {
            ListOrders.ItemsSource = db.orders.ToList();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (ListViewItem eachItem in ListOrders.SelectedItems)
        //    {
        //        ListOrders.Items.Remove(eachItem);
        //    }
        //}
    }
}
