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
            users = new ObservableCollection<Users>(bd_connecton.connection.Users.ToList());
            var z = users.Where(a => a.Login == txt_login.Text && a.Password == txt_password.Password).FirstOrDefault();
            if (z != null)
            {
                MessageBox.Show(z.FullName);
            }
            else
            {
                MessageBox.Show("Failed, you're dead lol.-.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page_reg());
        }
    }
}
