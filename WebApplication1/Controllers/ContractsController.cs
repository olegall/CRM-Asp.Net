using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;

namespace WebApplication1.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ContractsManager contractsMng = new ContractsManager();
        public ActionResult Index()
        {
            IList<ContractVM> vms = contractsMng.GetVMs();
            return View("Index", vms);
        }

        public ActionResult Add()
        {
            contractsMng.Create();
            return RedirectToAction("Index");
        }

        public JsonResult Update(ContractVM vm)
        {
            contractsMng.Update(vm);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            contractsMng.Delete(id);
            return RedirectToAction("Index");
        }
    }
}