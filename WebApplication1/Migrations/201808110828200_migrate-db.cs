namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratedb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accounts", newName: "aleynikov_Accounts");
            RenameTable(name: "dbo.AccountStatus", newName: "aleynikov_AccountStatuses");
            RenameTable(name: "dbo.AdditionalAgreements", newName: "aleynikov_AdditionalAgreements");
            RenameTable(name: "dbo.Contractors", newName: "aleynikov_Contractors");
            RenameTable(name: "dbo.Contracts", newName: "aleynikov_Contracts");
            RenameTable(name: "dbo.DocumentStatus", newName: "aleynikov_DocumentStatuses");
            RenameTable(name: "dbo.Emails", newName: "aleynikov_Emails");
            RenameTable(name: "dbo.EmailStatus", newName: "aleynikov_EmailStatuses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.aleynikov_EmailStatuses", newName: "EmailStatus");
            RenameTable(name: "dbo.aleynikov_Emails", newName: "Emails");
            RenameTable(name: "dbo.aleynikov_DocumentStatuses", newName: "DocumentStatus");
            RenameTable(name: "dbo.aleynikov_Contracts", newName: "Contracts");
            RenameTable(name: "dbo.aleynikov_Contractors", newName: "Contractors");
            RenameTable(name: "dbo.aleynikov_AdditionalAgreements", newName: "AdditionalAgreements");
            RenameTable(name: "dbo.aleynikov_AccountStatuses", newName: "AccountStatus");
            RenameTable(name: "dbo.aleynikov_Accounts", newName: "Accounts");
        }
    }
}
