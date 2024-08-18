using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class Wpf_order
    {
        public int Id_order { get; set; }//сохраняем заказ, присылаем юзеру с id из базы данных
        public string? Name_dishes { get; set; }//названия блюд через запятую для DataGrid написать отдельный метод, который принимает 
        //лист блюд и возвращает стринг 
        public string Date_order { get; set; }//дата заказа
        public string Date_delivery { get; set; }//дата доставки вызывать нужно календарик 
        public double Cost { get; set; }//рассчитываемая стоимость(складывается из стоимости всех блюд) можно написать отдельный метод, который принимает
                                        //лист блюд и возвращает общую стоимость
        public string? isActual { get; set; }//1-Актуален, когда заказ будет отправлен, админ редактирует на 0-Не актуален
        public string? User_Phone { get; set; }//это и будет логин, будет возможность его изменить
        public string? User_Address { get; set; }//адес доставки пока будет, будет возможность его изменить
        public string? isPaid { get; set; }//Оплачен, Неоплачен 
        public event PropertyChangedEventHandler? PropertyChanged;//только оплачено или нет

        public string isActual_
        {
            get { return isActual; }
            set
            {
                isActual = value;
                OnPropertyChanged("isActual_");
            }
        }
        public string IsPaid_
        {
            get { return isPaid; }
            set
            {
                isPaid = value;
                OnPropertyChanged("IsPaid_");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
