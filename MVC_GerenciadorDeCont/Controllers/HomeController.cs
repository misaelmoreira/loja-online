using Business;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Produtos = new Produto().Lista();
            ViewBag.Slider = new genMainSlider().Lista();
            ViewBag.PromoRight = new Promo().Lista();

            this.GetDefaultData();

            return View();
        }
        
    }
}