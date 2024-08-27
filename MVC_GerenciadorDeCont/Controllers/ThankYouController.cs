using Business;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class ThankYouController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.cartBox = null;
            ViewBag.TotalAmount = null;
            ViewBag.NoOfItem = null;
            TempShpData.items = null;

            return View("Thankyou");
        }        
    }
}