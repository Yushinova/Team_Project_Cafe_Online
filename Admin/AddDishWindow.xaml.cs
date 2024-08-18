using ClassLib;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для AddDishWindow.xaml
    /// </summary>
    public partial class AddDishWindow : Window
    {
        public dish_delegate add_delegate;//там
        public Dish_bll dish = new Dish_bll();//там
        public AddDishWindow(DishesWindow dishesWindow)
        {
            InitializeComponent();
            add_delegate = dishesWindow.AddDish;

        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dish.Name_dish = DishName.Text;
                dish.Price = double.Parse(DishPrice.Text);
                dish.Description = DishDescription.Text;
                dish.isActual = 1;
            }
            catch
            {
                MessageBox.Show("Не все поля корректны!");
            }
            if(!string.IsNullOrEmpty(dish.Name_dish)&&!string.IsNullOrEmpty(dish.Description)&&dish.Price!=0&&dish.Image_byte!=null) 
            {
               add_delegate(dish);
            }
            else
            {
                MessageBox.Show("Ошибка добавления блюда!");
            }
        }

        private void DishImageButton_Click(object sender, RoutedEventArgs e)
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
                string path = f.FullName;
                byte[] image_bytes = File.ReadAllBytes(path);
                BitmapImage imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = new MemoryStream(image_bytes);
                imageSource.EndInit();
                Image image = new Image();
                image.Source = imageSource;
                (sender as Button).Content = image;
                dish.Image_byte = image_bytes;
                dish.Image_name = System.IO.Path.GetFileName(path);
            }
        }
    }
}
