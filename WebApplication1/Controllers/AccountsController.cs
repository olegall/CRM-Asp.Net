using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.BLL;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        DbContext _context = new DataContext();
        DataContext _db = new DataContext();
        AccountsManager accsMng = new AccountsManager();

        public ActionResult Index()
        {
            IEnumerable<Account> acts = new EFGenericRepository<Account>(_context).Get();

            IList<AccountVM> vms = new AccountsManager().GetVMs();
            return View("Index", vms);
        }

        public ActionResult Add()
        {
            Account acc = new Account();
            acc.SelectedContractorID = 1;
            acc.Date = DateTime.Now;
            acc.Note = String.Empty;
            acc.Number = 0;
            acc.StatusID = 1;
            new EFGenericRepository<Account>(_context).Create(acc);
            return RedirectToAction("Index");
        }

        public JsonResult Update(AccountVM vm)
        {
            accsMng.Update(vm);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            accsMng.Delete(id);
            return RedirectToAction("Index");
        }
    }
}