using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class AdditionalAgreementsManager : IAdditionalAgreementsManager
    {
        private readonly DataContext _db = new DataContext();
        private readonly EFGenericRepository<AdditionalAgreement> rep;
        private AdditionalAgreement aa = new AdditionalAgreement();

        public AdditionalAgreementsManager()
        {
            rep = new EFGenericRepository<AdditionalAgreement>(_db);
        }

        public IList<AdditionalAgreementVM> GetVMs()
        {
            IEnumerable<AdditionalAgreement> additionalAgreements = new EFGenericRepository<AdditionalAgreement>(_db).Get(); // Get - async
            // IEnumerable
            IList<AdditionalAgreementVM> actVMs = new List<AdditionalAgreementVM>();
            foreach (AdditionalAgreement aa in additionalAgreements)
            {
                actVMs.Add(new AdditionalAgreementVM
                {
                    Id = aa.Id,
                    Contractors = _db.Contractors.OrderByDescending(i => i.Id == aa.SelectedContractorID).ThenBy(i => i).ToList(),
                    Statuses = _db.DocumentStatuses.OrderByDescending(i => i.Id == aa.StatusID).ThenBy(i => i).ToList(),
                    Note = aa.Note,
                    Number = aa.Number,
                    ParentDocumentLink = aa.ParentDocumentLink,
                    Date = aa.Date
                });
            }
            return actVMs;
        }

        public void Create()
        {
            aa.SelectedContractorID = 1;
            aa.Date = DateTime.Now;
            try
            {
                rep.Create(aa);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(AdditionalAgreementVM vm)
        {
            aa.Id = vm.Id;
            aa.SelectedContractorID = vm.SelectedContractorId;
            aa.Date = vm.Date;
            aa.ParentDocumentLink = vm.ParentDocumentLink;
            aa.Note = vm.Note;
            aa.Number = vm.Number;
            aa.StatusID = vm.StatusId;
            try
            {
                rep.Update(aa);
            }
            catch (Exception e)
            {

            }
            
        }

        public void Delete(int id)
        {
            aa = _db.AdditionalAgreements.SingleOrDefault(x => x.Id == id);
            try
            {
                _db.AdditionalAgreements.Remove(aa);
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