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

namespace MyСloud
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        private void RegisterUser_Clik(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.Nickname = log.Text;
            if (log.Text == "" || password.Text== "")
            {
                MessageBox.Show("Не все ячейки заполнены");
            }

            if (password.Text == secondPassword.Text)
            {
                user.Password = password.Text;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают ");
            }
        }

        private void BackwardMain(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
