using Admin.User_control;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    public delegate void dish_delegate(Dish_bll dish);
    /// <summary>
    /// Логика взаимодействия для DishesWindow.xaml
    /// </summary>
    public partial class DishesWindow : Window
    {
        public Services.Service service = new Services.Service();
        public Dish_bll dish = new Dish_bll();
        public List<Dish_bll> dishes;
        public DishesWindow()
        {

            InitializeComponent();
            SetAllDishes();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)//добавляется обсервал нужно
        {
            AddDishWindow dishWindow = new AddDishWindow(this);
            dishWindow.Owner = this;
            dishWindow.Title = "Новое блюдо";
            dishWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dishWindow.ShowDialog();
          
        }
        public void AddDish(Dish_bll dish)//тут запрос на вставку блюда и обновлеие листа блюд
        {
            service.AddNewDish(dish);
            SetAllDishes();
        }
        public void RedDish(Dish_bll dish)//Пока запрос на сервер не реализован!
        {
            try
            {
                service.UpdateDish(dish);
                SetAllDishes();
            }
            catch
            {
                MessageBox.Show("Ошибка сервера!");
            }
            //dishes[dishes.FindIndex(d=>d.Id_dish==dish.Id_dish)] = dish; 
            //DishesList.Items.Refresh();//без этого блюдо меняется но не отображается картинка новая!
            //DishesList.ItemsSource = dishes;
        }
        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            int ind = int.Parse((((sender as Button).Parent as StackPanel).Children[0] as DishPanel).DishId.Text);
            dish = dishes.First(d => d.Id_dish == ind);
            RedDishWindow dishWindow = new RedDishWindow(this);
            dishWindow.Owner = this;
            dishWindow.Title = "Редактор";
            dishWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dishWindow.ShowDialog();
        }
        public void SetAllDishes()
        {
            dishes = new List<Dish_bll>();
            try
            {
                dishes = service.SetListDishes();
                if (dishes != null)
                {
                    DishesList.ItemsSource = dishes;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления блюд!");
            }
        }
    }
}
