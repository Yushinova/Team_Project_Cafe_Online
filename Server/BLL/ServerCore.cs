using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.BLL
{
	internal class ServerCore
	{
		//Время проверки активных клиентов
		const int delayActiveClients = 10;

		TcpListener tcpListener;
		Config Config;
		public ServerCore(Config _config)
		{
			Config = _config;
			tcpListener = new TcpListener(IPAddress.Any, Config.ServerPort);
		}
		public void StartServer()
		{
			try
			{
				tcpListener.Start();
                //Console.WriteLine("Сервер запущен");
                Console.WriteLine("Server is running");

                while (true)
				{
					//Ждем входящее подключение
					TcpClient tcpClient = tcpListener.AcceptTcpClient();
					//Создаем новое подключение для клиента в отдельном потоке
					_ = Task.Factory.StartNew(() => ProcessClientAsync(tcpClient), TaskCreationOptions.LongRunning);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
                //Console.WriteLine("Ошибка сервера");
                Console.WriteLine("Server error");
            }
			finally
			{
				tcpListener.Stop();
				//Console.WriteLine("Сервер выключен");
				Console.WriteLine("Server is turned off");
			}
        }

		async Task ProcessClientAsync(TcpClient tcpClient)
		{
			NetworkStream stream = tcpClient.GetStream();
			
			while (true)
			{
				Courier courier = TransportServices.ReciverAndUnpacker(stream);
				Services.ServerCommands command = new Services.ServerCommands(Config);

				if (courier.Header == com.CommandGetAdminData)
				{
					command.GetAdminDataToClient(stream);
				}
				else if (courier.Header == com.CommandGetDishes)
				{
					command.GetAllDishes(stream);
				}
				else if (courier.Header == com.CommandRegisterMe)
				{
					command.RegistrationUser(stream, courier);
				}
				else if (courier.Header == com.CommandAuthorizeMe)
				{
					command.AuthorizationUser(stream, courier);
				}
				else if (courier.Header == com.CommandGetAllOrdersByID)
				{
					command.GetAllOrdersById(stream, courier);
				}
				else if (courier.Header == com.CommandTakeMyOrder)
				{
					command.TakeOrder(stream, courier);
				}
				else if (courier.Header == com.CommandShutUpAndTakeMyMoney)
				{
					command.OrderPayment(stream, courier);
				}
				else if (courier.Header == com.CommandAdminRegistration)
				{
					command.AdminRegistration(stream, courier);
				}
				else if (courier.Header == com.CommandAdminAuthorization)
				{
					command.AdminAuthorization(stream, courier);
				}
				else if (courier.Header == com.CommandGetAllUsers)
				{
					command.GetAllUsers(stream);
				}
				else if (courier.Header == com.CommandOrderClosed)
				{
					command.OrderClose(stream, courier);
				}
				else if (courier.Header == com.CommandAddNewDish)
				{
					command.AddNewDish(stream, courier);
				}
                //Изменения 15.07.2024 Добавление новых команд "получить все заказы", "апдейт блюда", "апдейт админа"
				else if (courier.Header == com.CommandGetAllOrders)
				{
					command.GetAllOrders(stream);
                }
				else if (courier.Header == com.CommandDishUpdate)
				{
					command.DishUpdate(stream, courier);
                }
				else if (courier.Header == com.CommandAdminUpdate)
				{
					command.AdminUpdate(stream, courier);
                }
                else
                {
                    //await Console.Out.WriteLineAsync($"Клиент {tcpClient.Client.RemoteEndPoint} выполнил недопустимую операцию: {courier.Header}. Связь разорвана\t{DateTime.Now}");
                    await Console.Out.WriteLineAsync($"Client {tcpClient.Client.RemoteEndPoint} made an invalid request: {courier.Header}. connection is broken\t{DateTime.Now}");
                    tcpClient.Close();
					break;
				}
			}
		}
	}
}
