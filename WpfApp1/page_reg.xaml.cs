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
            types = new ObservableCollection<Type>(bd_connecton.connection.Type.ToList()); //types в лист
            //cmd_type.Items.Add();
            this.DataContext = this;
        }
        private void Btn_back(object sender, RoutedEventArgs e) //при нажатии на кнопку вернёт на страницу авторизации
        {
            NavigationService.GoBack();
        }

        private void Btn_regist(object sender, RoutedEventArgs e) //при нажатии на кнопку все данные из текстбоксов записываются в таблицу users
        {
            var a = new Users();
            a.FullName = name_txt.Text;
            a.Login = login_txt.Text;
            a.Password = password_txt.Text;
            a.id_type = i;
            bd_connecton.connection.Users.Add(a);
            bd_connecton.connection.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрированы " + a.FullName);
            NavigationService.GoBack();
        }
        private void cmb__type(object sender, SelectionChangedEventArgs e) //записываем в i тип для записи в таблицу users
        {
            var a = (sender as ComboBox).SelectedItem as Type;
            i = a.id_type;
        }
    }
}
