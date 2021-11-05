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
        public static ObservableCollection<Users> users { get; set; }//коллекция данных
        public static ObservableCollection<orders> orders { get; set; }//коллекция данных
        int i { get; set; }
        public new_order()
        {
            InitializeComponent();
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList()); //users в лист
            this.DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //при изменении в комбобоксе в i будет записываться текущее значение
        {
            var a = (sender as ComboBox).SelectedItem as Users;
            i = a.id_user;

        }

        private void Button_add(object sender, RoutedEventArgs e) //при нажантии на кнопку добавление данные из текстбоксов будут записываться в таблиу orders
        {
            var a = new orders();
            a.order = txt_order.Text;
            a.id_user = i;
            a.wishes = txt_wishes.Text;
            a.ready = false;
            bd_connecton.connection.orders.Add(a);
            bd_connecton.connection.SaveChanges();
            MessageBox.Show("Заказ добавлен");
            NavigationService.GoBack();
        }

        private void Button_back(object sender, RoutedEventArgs e) 
        {
            NavigationService.GoBack(); //возвращает на прошлую страницу
        }
    }
}
