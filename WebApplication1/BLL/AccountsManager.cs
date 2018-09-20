using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class AccountsManager : IAccountManager
    {
        private readonly DataContext _db = new DataContext();
        private EFGenericRepository<Account> rep;
        private Account account = new Account();

        public AccountsManager()    // дёрнуть base конструктор
        {
            rep = new EFGenericRepository<Account>(_db);
        }

        public IList<AccountVM> GetVMs()
        {
            IEnumerable<Account> accs = new EFGenericRepository<Account>(_db).Get(); // Get - async
            IList<AccountVM> accVMs = new List<AccountVM>();
            foreach (Account acc in accs)
            {
                accVMs.Add(new AccountVM
                {
                    Id = acc.Id,
                    Contractors = _db.Contractors.OrderByDescending(i => i.Id == acc.SelectedContractorID).ThenBy(i => i).ToList(),
                    Statuses = _db.AccountStatuses.OrderByDescending(i => i.Id == acc.StatusID).ThenBy(i => i).ToList(),
                    Note = acc.Note,
                    Number = acc.Number,
                    Date = acc.Date
                });
            }
            return accVMs;
        }

        public void Create()
        {
            account.SelectedContractorID = 1;
            account.Date = DateTime.Now;
            try
            {
                rep.Create(account);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(AccountVM vm)
        {
            account.Id = vm.Id;
            account.SelectedContractorID = vm.SelectedContractorId;
            account.Date = vm.Date;
            account.Note = vm.Note;
            account.Number = vm.Number;
            account.StatusID = vm.StatusId;
            try
            {
                rep.Update(account);
            }
            catch (Exception e)
            {

            }
        }

        public void Delete(int id)
        {
            account = _db.Accounts.Where(x => x.Id == id).SingleOrDefault();
            try
            {
                _db.Accounts.Remove(account);
                _db.SaveChanges();
                //new EFGenericRepository<Act>(_context).Delete(act);
            }
            catch (Exception e)
            {

            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (rep != null)
                    {
                        rep.Dispose();
                    }
                }
                //_db = null;
                _disposed = true;
            }
        }

    }
}