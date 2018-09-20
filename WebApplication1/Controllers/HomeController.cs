using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DbContext _context = new DataContext();
        public ActionResult Index()
        {
            var a = new EFGenericRepository<Act>(_context).Get();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}