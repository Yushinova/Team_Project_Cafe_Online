using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public Admin_Cafe_bll? admin;//null
        public string? path;
        public Services.Service service;
        public main_delegate main_Delegate;
        public RegistrationWindow(MainWindow main)
        {
            service = new Services.Service();
            InitializeComponent();
            main_Delegate = main.Close;
        }

        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();//диалоговое окно
            dialog.FileName = "Image"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Image (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                FileInfo f = new FileInfo(dialog.FileName);
                path = f.FullName;
                LogoLabel.Content = System.IO.Path.GetFileName(path);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                admin = new Admin_Cafe_bll()
                {
                    Login = LoginText.Text,//исключить знаки
                    Password = PasswordText.Text,//исключить знаки
                    Address = AddressText.Text,
                    Image_name = System.IO.Path.GetFileName(path),
                    Name_cafe = NameText.Text,
                    Phone = PhoneText.Text,//проверка на количество цифр
                    Image_byte = File.ReadAllBytes(path)
                };
                if (!string.IsNullOrEmpty(admin.Login) && !string.IsNullOrEmpty(admin.Password) && !string.IsNullOrEmpty(admin.Phone)
                    && !string.IsNullOrEmpty(admin.Name_cafe) && !string.IsNullOrEmpty(admin.Address) && !string.IsNullOrEmpty(admin.Image_name)
                    && admin.Image_byte != null)
                {
                   
                    admin = service.RegistrationAdmin(admin);
                    if(admin!=null)
                    {
                        MessageBox.Show("Администратор зарегистрирован!");
                        main_Delegate();
                        OrdersWindow ordersWindow = new OrdersWindow(admin);
                        this.Close();
                        ordersWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        ordersWindow.Show();
                    }                      
                    else MessageBox.Show("Ошибка регистрации!");
                    //отпарвка запроса на регистрацию, если все прошло хорошо,
                    //вызываем главное окно с заказами
                }
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены корректно!");
            }
        }
    }
}
