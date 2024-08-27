using Business;
using System.Web.Mvc;

namespace MVC_GerenciadorDeCont.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            this.GetDefaultData();
            var usr = Customer.BuscaPorId(TempShpData.UserID);
            return View(usr);
        }


        //Cadastra Cliente
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                cust.Save();

                Session["username"] = cust.UserName;
                TempShpData.UserID = GetUser(cust.UserName).CustomerID;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public Customer GetUser(string _usrName)
        {
            var cust = Customer.BuscaPorUsername(_usrName);
            return cust;
        }


        //LOGIN
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection formColl)
        {
            string usrEmail = formColl["Email"];
            string Pass = formColl["Password"];

            if (ModelState.IsValid)
            {
                var cust = Customer.ValidaUser(usrEmail);

                if (cust.Email == usrEmail && cust.Password == Pass)
                {
                    if (cust != null)
                    {
                        TempShpData.UserID = cust.CustomerID;
                        Session["username"] = cust.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        //LOGoff
        public ActionResult Logout()
        {
            Session["username"] = null;
            TempShpData.UserID = 0;
            TempShpData.items = null;
            return RedirectToAction("Index", "Home");
        }


        //Atualiza dados do cliente
        [HttpPost]
        public ActionResult Update(Customer cust)
        {
            if (ModelState.IsValid)
            {
                var teste = Customer.BuscaPorUsername(cust.UserName);
                cust.Save();
                Session["username"] = cust.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}