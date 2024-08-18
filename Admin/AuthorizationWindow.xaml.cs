using ClassLib;
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
using System.Windows.Shapes;

namespace Admin
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public Admin_Cafe_bll? admin;//null
        public Services.Service service;
        public main_delegate main_Delegate;
        public AuthorizationWindow(MainWindow main)
        {
            service = new Services.Service();
            InitializeComponent();
            main_Delegate = main.Close;
    }

        private void EntryButton_Click(object sender, RoutedEventArgs e)
        {
            admin = new Admin_Cafe_bll();
            admin.Login = LoginText.Text;
            admin.Password = PasswordText.Password;
            admin = service.AuthorizationAdmin(admin);
            if (admin != null)
            {
                MessageBox.Show("Вход выполнен!");
                main_Delegate();
                OrdersWindow ordersWindow = new OrdersWindow(admin);
                this.Close();
                ordersWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                ordersWindow.Show();
                
            }
            else
            {
                MessageBox.Show("Данные не верны!");
            }
        }
    }
}
