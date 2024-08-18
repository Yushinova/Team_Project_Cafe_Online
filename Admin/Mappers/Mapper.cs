using Admin.Models;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Mappers
{
    public class Mapper
    {
        public Wpf_order MapOrder_bllToWpf(Order_bll order_Bll, User_bll user)
        {
            return new Wpf_order()
            {
                Id_order = order_Bll.Id_order,
                Cost = order_Bll.Cost,
                Date_order = $"{order_Bll.Date_order}",
                Date_delivery = $"{order_Bll.Date_delivery}",
                isActual = order_Bll.isActual,
                Name_dishes = order_Bll.Name_dishes,
                User_Address = user.Address,
                User_Phone = user.Phone,
                isPaid = order_Bll.isPaid
            };
        }
    }
}
