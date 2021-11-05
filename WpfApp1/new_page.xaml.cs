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
    /// Логика взаимодействия для hihi.xaml
    /// </summary>
    public partial class new_page : Page
    {
        public static ObservableCollection<Users> users { get; set; }
        public new_page()
        {
            InitializeComponent();
        }

        private void autho_event_click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList()); //таблицу в лист
            var z = users.Where(a => a.Login == txt_login.Text && a.Password == txt_password.Password).FirstOrDefault(); //проверка на совпадение логина и пароля из бд
            if (z != null)
            {
                if(z.id_type == 1) //проверка повар или официант
                {
                    MessageBox.Show("Доброго времени бытия, официант " + z.FullName);
                    NavigationService.Navigate(new oficiant());//на страницу официанта
                }
                else
                {
                    MessageBox.Show("Доброго времени бытия, повар " + z.FullName);
                    NavigationService.Navigate(new povar());//на страницу повара
                }
            }
            else
            {
                MessageBox.Show("Failed, you're dead lol.-.");//неверный логин или пароль
            }
        }

        private void registration(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_reg()); //перейти на страницу регистрации
        }
    }
}
