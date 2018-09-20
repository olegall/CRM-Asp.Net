using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.BLL
{
    public class ContractsManager : IContractsManager
    {
        private readonly DbContext _context = new DataContext();
        private readonly DataContext _db = new DataContext();
        private readonly EFGenericRepository<Contract> rep;
        private Contract contract = new Contract();

        public ContractsManager()
        {
            rep = new EFGenericRepository<Contract>(_db);
        }

        public IList<ContractVM> GetVMs()
        {
            IEnumerable<Contract> contracts = rep.Get(); // Get - async
            IList<ContractVM> contractVMs = new List<ContractVM>();
            foreach (Contract c in contracts)
            {
                contractVMs.Add(new ContractVM
                {
                    Id = c.Id,
                    Contractors = _db.Contractors.OrderByDescending(i => i.Id == c.SelectedContractorID).ThenBy(i => i).ToList(),
                    Statuses = _db.DocumentStatuses.OrderByDescending(i => i.Id == c.StatusID).ThenBy(i => i).ToList(),
                    Note = c.Note,
                    Number = c.Number,
                    ParentDocumentLink = c.ParentDocumentLink,
                    Date = c.Date
                });
            }
            return contractVMs;
        }

        public void Create()
        {
            contract.SelectedContractorID = 1;
            contract.StatusID = 1;
            contract.Date = DateTime.Now;
            try
            {
                rep.Create(contract);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(ContractVM vm)
        {
            contract.Id = vm.Id;
            contract.SelectedContractorID = vm.SelectedContractorId;
            contract.Date = vm.Date;
            contract.ParentDocumentLink = vm.ParentDocumentLink;
            contract.Note = vm.Note;
            contract.Number = vm.Number;
            contract.StatusID = vm.StatusId;
            try
            {
                rep.Update(contract);
            }
            catch
            {

            }
        }

        public void Delete(int id)
        {
            contract = _db.Contracts.SingleOrDefault(x => x.Id == id);
            try
            {
                _db.Contracts.Remove(contract);
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
                _disposed = true;
            }
        }
    }
}