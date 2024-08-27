using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cep = Business.Cep.Busca("09931410");
            return View();
        }

        public string Consulta(string cep)
        {
            var cepObj = Business.Cep.Busca(cep);
            return new JavaScriptSerializer().Serialize(cepObj);
        }
    }
}