using ClassLib;
using System;
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
    /// Логика взаимодействия для RedDishWindow.xaml
    /// </summary>
    public partial class RedDishWindow : Window
    {
        public dish_delegate red_delegate;
        public Dish_bll dish = new Dish_bll();
        public RedDishWindow(DishesWindow window)
        {
            InitializeComponent();
            red_delegate = window.RedDish;
            dish = window.dish;
            MainGrid.DataContext = dish;
           // DishName.Text = window.dish.Name_dish;
        }

        private void DishImage_MouseDown(object sender, MouseButtonEventArgs e)
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
                DishImage.Source = imageSource;
                dish.Image_byte = image_bytes;
                dish.Image_name = System.IO.Path.GetFileName(path);
            }
        }

        private void RedDish_Click(object sender, RoutedEventArgs e)
        {
            double res;
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(dish.Name_dish) && !string.IsNullOrEmpty(dish.Description) && double.TryParse(DishPrice.Text, out res) && dish.Image_byte != null)
            {
                dish.Name_dish = DishName.Text;
                dish.Price = double.Parse(DishPrice.Text);
                dish.Description = DishDescription.Text;
                dish.isActual = 1;
                red_delegate(dish);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка редактирования блюда!");
            }
        }
    }
}
