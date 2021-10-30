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
    /// Логика взаимодействия для page_reg.xaml
    /// </summary>
    public partial class page_reg : Page
    {
        public static ObservableCollection<Type> types { get; set; }
        int i { get; set; }
        public page_reg()
        {
            InitializeComponent();
            types = new ObservableCollection<Type>(bd_connecton.connection.Type.ToList());
            //cmd_type.Items.Add();
            this.DataContext = this;

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var a = new Users();
            a.FullName = name_txt.Text;
            a.Login = login_txt.Text;
            a.Password = password_txt.Text;
            a.type_id = i;
            bd_connecton.connection.Users.Add(a);
            bd_connecton.connection.SaveChanges();
            MessageBox.Show("you have registered with our company, congratulations, mr " + a.FullName);
            NavigationService.GoBack();
        }
        private void cmb__type(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Type;
            i = a.id_type;
        }
    }
}
