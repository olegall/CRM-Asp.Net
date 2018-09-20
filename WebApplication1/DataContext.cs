using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DataContext : DbContext
    {
        public DbSet<Act> Acts { get; set; }
        public DbSet<AdditionalAgreement> AdditionalAgreements { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Email> Emails { get; set; }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<DocumentStatus> DocumentStatuses { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<EmailStatus> EmailStatuses { get; set; }
    }
}