using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public static class LoadDataController {

        public static List<OrderDetail> GetDefaultData(this ControllerBase controller)
        {
            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }

            var data = TempShpData.items.ToList();
            
            controller.ViewBag.cartBox = data.Count == 0 ? null : data;
            controller.ViewBag.NoOfItem = data.Count();
            int? SubTotal = Convert.ToInt32(data.Sum(x => x.TotalAmount));
            controller.ViewBag.TotalAmount = SubTotal;

            int Discount = 0;

            controller.ViewBag.SubTotal = SubTotal;
            controller.ViewBag.Discount = Discount;
            controller.ViewBag.TotalAmount = SubTotal - Discount;

            return data;
        }
    }
}