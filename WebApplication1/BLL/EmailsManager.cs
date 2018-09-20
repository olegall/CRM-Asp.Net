using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BLL
{
    public class EmailsManager : IEmailManager
    {
        private readonly DataContext _db = new DataContext();
        private readonly EFGenericRepository<Email> rep;
        private Email email = new Email();

        public EmailsManager()
        {
            rep = new EFGenericRepository<Email>(_db);
        }

        public IList<EmailVM> GetVMs()
        {
            IEnumerable<Email> emails = rep.Get();
            IList<EmailVM> emailVMs = new List<EmailVM>();
            foreach (Email email in emails)
            {
                emailVMs.Add(new EmailVM
                {
                    Id = email.Id,
                    From = email.From,
                    To = email.To,
                    Date = email.Date,
                    DateBack = email.DateBack,
                    Description = email.Description,
                    DeliverySystem = email.DeliverySystem,
                    TrackingNumber = email.TrackingNumber,
                    TrackingNumberBack = email.TrackingNumberBack,
                    Statuses = _db.EmailStatuses.OrderByDescending(i => i.Id == email.StatusID).ThenBy(i => i).ToList()
                });
            }
            return emailVMs;
        }

        public void Create()
        {
            email.StatusID = 1;
            email.Date = DateTime.Now;
            email.DateBack = DateTime.Now;
            try
            {
                rep.Create(email);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(EmailVM vm)
        {
            email.Id = vm.Id;
            email.StatusID = vm.StatusId;
            email.From = vm.From;
            email.To = vm.To;
            email.Date = vm.Date;
            email.DateBack = vm.DateBack;
            email.Description = vm.Description;
            email.DeliverySystem = vm.DeliverySystem;
            email.TrackingNumber = vm.TrackingNumber;
            email.TrackingNumberBack = vm.TrackingNumberBack;

            try
            {
                rep.Update(email);
            }
            catch
            {

            }
        }

        public void Delete(int id)
        {
            email = _db.Emails.SingleOrDefault(x => x.Id == id);
            try
            {
                _db.Emails.Remove(email);
                _db.SaveChanges();
                //new EFGenericRepository<Act>(_context).Delete(act);
            }
            catch (Exception e)
            {

            }
        }
    }
}