using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Admin.Services
{
    public class Service//запросы к сервису
    {
        public string IP = "127.0.0.1";
        public int port = 8888;
        //"127.0.0.1", 8888
        public Admin_Cafe_bll RegistrationAdmin(Admin_Cafe_bll admin)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] admin_write = TransportServices.Packer(admin);
                Courier courier = new Courier()
                {
                    Header = com.CommandAdminRegistration,
                    Entity = admin_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                admin = TransportServices.Unpacker<Admin_Cafe_bll>(courier.Entity);
                tcpClient.Close();
                if (courier.Header == com.AnswerAdminRegistrationOK)
                {
                    return admin;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public Admin_Cafe_bll AuthorizationAdmin(Admin_Cafe_bll admin)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] admin_write = TransportServices.Packer(admin);
                Courier courier = new Courier()
                {
                    Header = com.CommandAdminAuthorization,
                    Entity = admin_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                admin = TransportServices.Unpacker<Admin_Cafe_bll>(courier.Entity);
                tcpClient.Close();
                if (courier.Header == com.AnswerAdminAuthorizationOK)
                {
                    return admin;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<User_bll>SetListUsers()
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                Courier courier = new Courier()
                {
                    Header = com.CommandGetAllUsers
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                List<User_bll> users = new List<User_bll>();
                users = TransportServices.Unpacker<List<User_bll>>(courier.Entity);
                tcpClient.Close();
                if (courier.Header == com.AnswerCatchAllUsers)
                {
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Order_bll> SetListOrders()//нет такой команды
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                Courier courier = new Courier()
                {
                    Header = com.CommandGetAllOrders
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                List<Order_bll> orders = new List<Order_bll>();
                orders = TransportServices.Unpacker<List<Order_bll>>(courier.Entity);
                tcpClient.Close();
                if (courier.Header == com.AnswerCatchAllOrders)
                {
                    return orders;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Dish_bll> SetListDishes()
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                Courier courier = new Courier()
                {
                    Header = com.CommandGetDishes
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                List<Dish_bll> dishes = new List<Dish_bll>();
                dishes = TransportServices.Unpacker<List<Dish_bll>>(courier.Entity);
                tcpClient.Close();
                if (courier.Header == com.AnswerSetAllDishes)
                {
                    return dishes;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void AddNewDish(Dish_bll dish)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] dish_write = TransportServices.Packer(dish);
                Courier courier = new Courier()
                {
                    Header = com.CommandAddNewDish,
                    Entity = dish_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                tcpClient.Close();
                if (courier.Header == com.AnswerNewDishInsertedOK)
                {
                    MessageBox.Show("Блюдо вставлено!");
                }
                else
                {
                    MessageBox.Show("Блюдо НЕ вставлено!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }

        public void UpdateOrder(Order_bll order)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] order_write = TransportServices.Packer(order);
                Courier courier = new Courier()
                {
                    Header = com.CommandOrderClosed,
                    Entity = order_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                tcpClient.Close();
                if (courier.Header == com.AnswerOrderClosedOK)
                {
                    MessageBox.Show("Заказ закрыт!");
                }
                else
                {
                    MessageBox.Show("Заказ не закрыт!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }

        public void UpdateDish(Dish_bll dish)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] dish_write = TransportServices.Packer(dish);
                Courier courier = new Courier()
                {
                    Header = com.CommandDishUpdate,
                    Entity = dish_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                tcpClient.Close();
                if (courier.Header == com.AnswerDishUpdateOK)
                {
                    MessageBox.Show("Данные изменены!");
                }
                else
                {
                    MessageBox.Show("Не удалось изменить данные!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }

        public void UpdateAdmin(Admin_Cafe_bll admin)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IP, port);
                NetworkStream stream = tcpClient.GetStream();
                byte[] admin_write = TransportServices.Packer(admin);
                Courier courier = new Courier()
                {
                    Header = com.CommandAdminUpdate,
                    Entity = admin_write
                };
                TransportServices.PackerAndSender(stream, courier);
                courier = TransportServices.ReciverAndUnpacker(stream);
                tcpClient.Close();
                if (courier.Header == com.AnswerAdminUpdateOK)
                {
                    MessageBox.Show("Данные изменены!");
                }
                else
                {
                    MessageBox.Show("Не удалось изменить данные!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сервера!");
            }
        }
    }
}
