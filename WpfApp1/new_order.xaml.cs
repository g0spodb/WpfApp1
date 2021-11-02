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
    /// Логика взаимодействия для new_order.xaml
    /// </summary>
    public partial class new_order : Page
    {
        public static ObservableCollection<Users> users { get; set; }
        public static ObservableCollection<orders> orders { get; set; }
        int i { get; set; }
        public new_order()
        {
            InitializeComponent();
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList());
            this.DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Users;
            i = a.id_user;

        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            var a = new orders();
            a.order = txt_order.Text;
            a.id_user = i;
            a.wishes = txt_wishes.Text;
            bd_connecton.connection.orders.Add(a);
            bd_connecton.connection.SaveChanges();
            MessageBox.Show("Заказ добавлен");
            NavigationService.GoBack();
        }

        private void Button_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void cmb__type(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Type;
            i = a.id_type;
        }
    }
}
