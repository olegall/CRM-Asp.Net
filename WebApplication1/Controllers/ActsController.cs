using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class ActsController : Controller
    {
        DbContext _context = new DataContext();
        DataContext _db = new DataContext();
        ActsManager actsMng = new ActsManager();
        public ActionResult Index()
        {
            IList<ActVM> vms = new ActsManager().GetVMs();
            return View("Index", vms);
        }

        public ActionResult Add()
        {
            actsMng.Create();
            return RedirectToAction("Index");
        }

        public JsonResult Update(ActVM vm)
        {
            actsMng.Update(vm);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            actsMng.Delete(id);
            return RedirectToAction("Index");
        }
    }
}