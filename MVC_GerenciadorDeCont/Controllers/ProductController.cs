using Business;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {            
            return View("Products");
        }        

        //Adicione ao Carrinho
        public ActionResult AddToCart(int id)
        {
            OrderDetail OD = new OrderDetail();
            OD.ProductID = id;
            int Qty = 1;
            var price = Produto.BuscaPorId(id).UnitPrice;
            OD.Quantity = Qty;
            OD.UnitPrice = price;
            OD.TotalAmount = Qty * price;  
            OD.Produto = Produto.BuscaPorId(id);

            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }
            TempShpData.items.Add(OD);            

            return Redirect(TempData["returnURL"].ToString());

        }

        //Detalhes do Produtos
        public ActionResult ViewDetails(int id)
        {
            var prod = Produto.BuscaPorId(id);           

            this.GetDefaultData();
            return View(prod);
        }        
    }
}