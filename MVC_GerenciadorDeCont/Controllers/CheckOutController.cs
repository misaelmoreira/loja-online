using Business;
using System;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class CheckOutController : Controller
    {

        public ActionResult Index()
        {
            var typePayment = new PaymentType().Lista();
            ViewBag.PayMethod = new SelectList(typePayment, "PayTypeID", "TypeName");
            var data = this.GetDefaultData();
            return View(data);
        }


        public ActionResult PlaceOrder(FormCollection getCheckoutDetails)
        {

            var item = new ShippingDetail();
            int itemCompra = item.Count();

            var item2 = new Payment();
            int itemPagamento = item2.Count();

            var item3 = new Order();
            int itemPedido = item3.Count();


            int shpID = 1;
            if (itemCompra > 0)
            {
                shpID = itemCompra + 1;
            }

            int payID = 1;
            if (itemPagamento > 0)
            {
                payID = itemPagamento + 1;
            }
            int orderID = 1;
            if (itemPedido > 0)
            {
                orderID = itemPedido + 1;
            }

            ShippingDetail shpDetails = new ShippingDetail();
            shpDetails.ShippingID = shpID;
            shpDetails.FirstName = getCheckoutDetails["FirstName"];
            shpDetails.LastName = getCheckoutDetails["LastName"];
            shpDetails.Email = getCheckoutDetails["Email"];
            shpDetails.Mobile = getCheckoutDetails["Mobile"];
            shpDetails.Address = getCheckoutDetails["Address"];
            shpDetails.Province = getCheckoutDetails["Province"];
            shpDetails.City = getCheckoutDetails["City"];
            shpDetails.PostCode = getCheckoutDetails["PostCode"];
            shpDetails.Save();


            Payment pay = new Payment();
            pay.PaymentID = payID;
            pay.Type = Convert.ToInt32(getCheckoutDetails["PayMethod"]);
            pay.Save();

            Order o = new Order();
            o.OrderID = orderID;
            o.CustomerID = TempShpData.UserID;
            o.PaymentID = payID;
            o.ShippingID = shpID;
            o.Discount = Convert.ToInt32(getCheckoutDetails["discount"]);
            o.TotalAmount = Convert.ToInt32(getCheckoutDetails["totalAmount"]);
            o.isCompleted = true;
            o.OrderDate = DateTime.Now;
            o.Save();


            foreach (var OD in TempShpData.items)
            {
                OD.OrderID = orderID;
                OD.Order = Order.BuscaPorId(orderID);
                OD.Produto = Produto.BuscaPorId(OD.ProductID);
                OD.Save();
            }

            return RedirectToAction("Index", "ThankYou");
        }
    }
}