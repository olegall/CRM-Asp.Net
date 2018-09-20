using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class AdditionalAgreementsController : Controller
    {
        DbContext _context = new DataContext();
        DataContext _db = new DataContext();
        AdditionalAgreementsManager aaMng = new AdditionalAgreementsManager();

        public ActionResult Index()
        {
            IList<AdditionalAgreementVM> vms = new AdditionalAgreementsManager().GetVMs();
            return View("Index", vms);
        }

        public ActionResult Add()
        {
            aaMng.Create();
            return RedirectToAction("Index");
        }

        public JsonResult Update(AdditionalAgreementVM vm)
        {
            aaMng.Update(vm);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            aaMng.Delete(id);
            return RedirectToAction("Index");
        }
    }
}