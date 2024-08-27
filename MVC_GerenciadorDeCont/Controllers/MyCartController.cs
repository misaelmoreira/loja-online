using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class MyCartController : Controller
    {

        public ActionResult Index()
        {
            var data = this.GetDefaultData();
            return View(data);
        }


        //Remove os Produtos
        public ActionResult Remove(int id)
        {
            TempShpData.items.RemoveAll(x => x.ProductID ==id); 
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ProcedToCheckout(FormCollection formcoll)
        {
            var a = TempShpData.items.ToList();
            for (int i = 0; i < formcoll.Count / 2; i++)
            {

                int pID = Convert.ToInt32(formcoll["shcartID-" + i + ""]);
                var ODetails = TempShpData.items.FirstOrDefault(x => x.ProductID == pID);


                int qty = Convert.ToInt32(formcoll["Qty-" + i + ""]);
                ODetails.Quantity = qty;

                TempShpData.items.RemoveAll(x => x.ProductID == pID);

                if (TempShpData.items == null)
                {
                    TempShpData.items = new List<OrderDetail>();
                }
                TempShpData.items.Add(ODetails);

            }

            return RedirectToAction("Index", "CheckOut");
        }
    }
}