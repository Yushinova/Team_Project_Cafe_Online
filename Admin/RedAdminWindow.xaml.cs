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
    /// пока не реализуем
    /// </summary>
    public partial class RedAdminWindow : Window
    {
        public admin_delegate delegate_;
        public Admin_Cafe_bll admin = new Admin_Cafe_bll();
        public RedAdminWindow(OrdersWindow window)
        {
            InitializeComponent();
            admin = window.admin_;
            this.DataContext = admin;

        }
    }
}
