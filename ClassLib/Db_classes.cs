namespace ClassLib
{
    public class User
    {
        public int Id_user { get; set; }
        public string? Name { get; set; }//для заказа достаточно только имени
        public string? Password { get; set; }
        public string? Phone { get; set; }//это и будет логин, будет возможность его изменить
        public string? Address { get; set; }//адес доставки пока будет, будет возможность его изменить
        public int isActual { get; set; }//по умолчанию 1-актуален, если будет удален из базы ставим 0-не актуален

    }

    public class Dish
    {
        public int Id_dish { get; set; }
        public string? Name_dish { get; set; }
        public double Price { get; set; }
        public string? Image_path { get; set; }//путь к картинке
        public string? Description { get; set; }
        public int isActual { get; set; }//1-актуально, 0-неактуально, 2-в стопе(временно отсутствует)

    }

    public class Order
    {
        public int Id_order { get; set; }
        public string? Name_dishes { get; set; }//названия блюд через запятую
        public string? Date_order { get; set; }//лучше хранить в стрингах думаю, при переводе в bll DateTime
        public string? Date_delivery { get; set; }//это дата/время на которе нужена досавка, лучше хранить в стрингах думаю, при переводе в bll DateTime
        public double Cost { get; set; }
        public int isActual { get; set; }//1-актуален, когда заказ будет отправлен, админ редактирует на 0-не актуален
        public int isPaid { get; set; }//1-оплачен, 2-неоплачен 
        public int Id_user { get; set; }//связь с юзером
    }

    public class Cheque
    {
        public int Id_cheque { get; set; }
        public string? Date_cheque { get; set; }
        public double Amount { get; set; }
        public int Id_order { get; set; }//связь с заказом
    }

    public class Admin_Cafe//админ пока один и у него личная база данных
    {
        public int Id_admin { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Image_path { get; set; }//путь к логотипу
        public string? Name_cafe { get; set; }//Название кафе
        public string? Phone { get; set; }//телефон для связи с кафе
        public string? Address { get; set; }//адрес кафе, может быть null, если кафе работает только на доставку
    }

}
