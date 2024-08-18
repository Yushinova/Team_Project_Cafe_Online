using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
	public static class com
	{
		//Фразы вписаны для отладки. Перед релизом можно вписать 0,1,2,3....
		//Клиент-Сервер
		//1.
		//Запрос от клиента серверу на получение административных данных
		public const string CommandGetAdminData = "get_Admin_Caffe";
		//Отправка клиенту административных данных
		public const string AnswerSetAdminData = "set_Admin_Caffe";
		
		//2.
		//Запрос от клиента серверу на получение всех блюд
		public const string CommandGetDishes = "Get_Dishes";
		//Отправка клиенту данных с блюдами
		public const string AnswerSetAllDishes = "Set_All_Dishes";
		
		//3.1.
		//Регистрация клиента
		public const string CommandRegisterMe = "Register_Me";
		//Регистрация прошла успешно
		public const string AnswerRegistrationOK = "Registration_OK";
		//Регистрация не удалась
		public const string AnswerRegistrationFailed = "Registration_Failed";
	
		//3.2.
		//Авторизация клиента
		public const string CommandAuthorizeMe = "Authorize_Me";
		//Авторизация прошла успешно
		public const string AnswerAuthorizeOK = "Authorize_OK";
		//Авторизация не удалась
		public const string AnswerAuthorizeFailed = "Authorize_Failed";

		//4.
		//Запрос на получение листа заказов для пользователя
		public const string CommandGetAllOrdersByID = "Get_All_Orders_By_ID";
		//Отправляю лист заказов клиенту
		public const string AnswerCatchOrdersListById = "Catch_Orders_By_ID";

		//5.
		//Пользователь делает заказ
		public const string CommandTakeMyOrder = "Take_Order";
		//Заказ принят
		public const string AnswerOrderAccepted = "Order_Accepted";
		//Заказ не принят
		public const string AnswerOrderFailed = "Order_Failed";

		//6.
		//Оплата
		public const string CommandShutUpAndTakeMyMoney = "Shut_Up_And_Take_My_Money";
		//Оплата произведена
		public const string AnswerPaidOK = "Paid_OK";
		//Оплата отклонена
		public const string AnswerPaidFailed = "Paid_Failed";

		//Админ-Сервер
		//7.1.
		//Регистрация админа
		public const string CommandAdminRegistration = "Admin_Registration_Request";
		//Регистрация админа прошла успешно
		public const string AnswerAdminRegistrationOK = "Admin_Registration_OK";
		//Регистрация админа не удалась
		public const string AnswerAdminRegistrationFailed = "Admin_Registration_Failed";

		//7.2
		//Авторизация админа
		public const string CommandAdminAuthorization = "Admin_Authorization";
		//Авторизация админа прошла успешно
		public const string AnswerAdminAuthorizationOK = "Admin_Authorization_OK";
		//Авторизация админа не удалась
		public const string AnswerAdminAuthorizationFailed = "Admin_Authorization_Failed";

		//8 Получение всех зарегистрированных пользователей
		public const string CommandGetAllUsers = "Get_All_Users";
		//Отправка администратору пользователей
		public const string AnswerCatchAllUsers = "Catch_All_Users";

		//9. Заказ закрыт/выполнен
		public const string CommandOrderClosed = "OrderClosed";
		//Заказ закрыт
		public const string AnswerOrderClosedOK = "Order_Closed_OK";
		//Не удалось закрыть заказ
		public const string AnswerOrderClosedFailed = "Order_Closed_Failed";

		//10. Добавление нового блюда
		public const string CommandAddNewDish = "Add_New_Dish";
		//Добавление прошло успешно
		public const string AnswerNewDishInsertedOK = "New_Dish_Inserted_OK";
		//Блюдо не добавлено
		public const string AnswerNewDishInsertedFailed = "New_Dish_Inserted_Failed";

        //Изменения 15.07.2024 Добавление новых команд "получить все заказы", "апдейт блюда", "апдейт админа"
        //11. Получить все заказы
        public const string CommandGetAllOrders = "Get_All_Orders";
		public const string AnswerCatchAllOrders = "Catch_All_Orders";

		//12. Обновление блюда
		public const string CommandDishUpdate = "Dish_Update";
		public const string AnswerDishUpdateOK = "Dish_Update_Ok";
		public const string AnswerDishUpdateFailed = "Dish_Update_Failed";

		//13. Обновление админа
		public const string CommandAdminUpdate = "Admin_Update";
		public const string AnswerAdminUpdateOK = "Admin_Update_OK";
		public const string AnswerAdminUpdateFailed = "Admin_Update_Failed";
	}
}
