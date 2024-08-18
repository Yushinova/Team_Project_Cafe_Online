using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

namespace Admin.User_control
{
    /// <summary>
    /// Логика взаимодействия для AddPanel.xaml
    /// </summary>
    public partial class AddPanel : UserControl
    {
        public Dish_bll dish = new Dish_bll();
        public AddPanel(Dish_bll dish_)
        {
            InitializeComponent();
        }

    }
}
