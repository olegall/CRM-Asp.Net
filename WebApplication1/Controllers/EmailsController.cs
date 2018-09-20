using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;

namespace WebApplication1.Controllers
{
    public class EmailsController : Controller
    {
        private readonly EmailsManager emailsMng = new EmailsManager();

        public ActionResult Index()
        {
            IList<EmailVM> vms = emailsMng.GetVMs();
            return View("Index", vms);
        }

        public JsonResult Update(EmailVM vm)
        {
            emailsMng.Update(vm);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            emailsMng.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            emailsMng.Create();
            return RedirectToAction("Index");
        }
    }
}