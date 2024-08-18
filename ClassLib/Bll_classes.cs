using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class User_bll: INotifyPropertyChanged//формируется на этапе регистрации/авторизации у Николая
    {
        //юзер может менять свои регистрационные данные
        public int Id_user { get; set; }
        public string? Name { get; set; }//для заказа достаточно только имени
        public string? Password { get; set; }
        public string? Phone { get; set; }//это и будет логин, будет возможность его изменить
        public string? Address { get; set; }//адес доставки пока будет, будет возможность его изменить
        public int isActual { get; set; }//если юзер решил удалить учетную запись  = 0 и отправляем на сервер //это у юрера не отображается

        public event PropertyChangedEventHandler? PropertyChanged;//телефон, адрес, имя
        public string Name_
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name_");
            }
        }
        public string Phone_
        {
            get { return Phone; }
            set
            {
                Phone = value;
                OnPropertyChanged("Phone_");
            }
        }
        public string Address_
        {
            get { return Address; }
            set
            {
                Address = value;
                OnPropertyChanged("Address_");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class Order_bll: INotifyPropertyChanged//клиент может либо оплатить либо удалить заказ
    {
        public int Id_order { get; set; }//сохраняем заказ, присылаем юзеру с id из базы данных
        public string? Name_dishes { get; set; }//названия блюд через запятую для DataGrid написать отдельный метод, который принимает 
        //лист блюд и возвращает стринг 
        public DateTime Date_order { get; set; }//дата заказа
        public DateTime Date_delivery { get; set; }//дата доставки вызывать нужно календарик 
        public double Cost { get; set; }//рассчитываемая стоимость(складывается из стоимости всех блюд) можно написать отдельный метод, который принимает
                                        //лист блюд и возвращает общую стоимость
        public string? isActual { get; set; }//1-Актуален, когда заказ будет отправлен, админ редактирует на 0-Не актуален
        public string? isPaid { get; set; }//Оплачен, Неоплачен 
        public int Id_user { get; set; }//Id юзера

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
    public class Dish_bll: INotifyPropertyChanged //админ может редактировать блюдо
    {
        public int Id_dish { get; set; }
        public string? Name_dish { get; set; }
        public double Price { get; set; }
        public byte[]? Image_byte { get; set; }
        public string? Image_name { get; set; }//это нужно только для Виталика, чтобы сохранить картинку в базе данных
        public string? Description { get; set; }
        public int isActual { get; set; }//1-актуально, 0-неактуально, 2-в стопе(временно отсутствует)

        public event PropertyChangedEventHandler? PropertyChanged;//все кроме id
        public string Name_dish_
        {
            get { return Name_dish; }
            set
            {
                Name_dish = value;
                OnPropertyChanged("Name_dish_");
            }
        }
        public double Price_
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("Price_");
            }
        }
        public byte[] Image_byte_
        {
            get { return Image_byte; }
            set
            {
                Image_byte = value;
                OnPropertyChanged("Image_byte_");
            }
        }
        public string Description_
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("Description_");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class Cheque_bll//оплата
    {
        public int Id_cheque { get; set; }//оплачиваем уже обновленный заказ с присвоенным id в базе данных!
        public DateTime Date_cheque { get; set; }
        public double Amount { get; set; }
        public int Id_order { get; set; }//связь с заказом
    }

    public class Admin_Cafe_bll//получаем по запросу при первоначальной загрузке клиента
    {
        public int Id_admin { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public byte[]? Image_byte { get; set; }//логотип
        public string? Image_name { get; set; }
        public string? Name_cafe { get; set; }//Название кафе
        public string? Phone { get; set; }//телефон для связи с кафе
        public string? Address { get; set; }//адрес кафе, может быть null, если кафе работает только на доставку
    }


	//Класс для пересылки данных между клиентом и пользователем
	[Serializable]
	public class Courier
    {
        //Команда
        public string Header { get; set; }
        //Передаваемые в байтах
        public byte[] Entity { get; set; }
    }

}

