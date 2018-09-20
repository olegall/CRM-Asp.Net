using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class ActsManager : IActsManager
    {
        private readonly DataContext _db = new DataContext();
        private readonly EFGenericRepository<Act> rep;
        private Act act = new Act();
        public ActsManager()
        {
            rep = new EFGenericRepository<Act>(_db);
        }

        public IList<ActVM> GetVMs()
        {
            IEnumerable<Act> acts = rep.Get();
            IList<ActVM> actVMs = new List<ActVM>();
            foreach (Act act in acts)
            {
                actVMs.Add(new ActVM
                {
                    Id = act.Id,
                    Contractors = _db.Contractors.OrderByDescending(i => i.Id == act.SelectedContractorID).ThenBy(i => i).ToList(),
                    Statuses = _db.DocumentStatuses.OrderByDescending(i => i.Id == act.StatusID).ThenBy(i => i).ToList(),
                    Note = act.Note,
                    Number = act.Number,
                    ParentDocumentLink = act.ParentDocumentLink,
                    Date = act.Date
                });
            }
            return actVMs;
        }

        public void Create()
        {
            act.SelectedContractorID = 1;
            act.Date = DateTime.Now;
            try
            {
                rep.Create(act);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(ActVM vm)
        {
            act.Id = vm.Id;
            act.SelectedContractorID = vm.SelectedContractorId;
            act.Date = vm.Date;
            act.ParentDocumentLink = vm.ParentDocumentLink;
            act.Note = vm.Note;
            act.Number = vm.Number;
            act.StatusID = vm.StatusId;
            rep.Update(act);
        }

        public void Delete(int id)
        {
            act = _db.Acts.Where(x => x.Id == id).SingleOrDefault();
            try
            { 
                _db.Acts.Remove(act);
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