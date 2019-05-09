namespace CloudtrixApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CloudtrixDb : DbMigration
    {
        public override void Up()
        {
            {

                Sql("INSERT INTO UserAccount (Name,Email,Password, Role, CreateDate, UpdateDate,IsDelete) VALUES ('CloudTRIX', 'sunil@cloudtrix.in', '12345','Admin', '02-03-2018','02-03-2018', 'false')");
                Sql("INSERT INTO Customer (Name,Email,Phone, CreateDate, UpdateDate,IsDelete) VALUES ('Walk in Customer', 'customer@gmail.com', '0000000000', '02-03-2018','02-03-2018', 'false')");
                Sql("INSERT INTO StoreSetting (Logo,StoreName,Email, Phone, Currency, Address, CreateDate,UpdateDate,IsDelete, web) VALUES ('/Content/adminFront/assets/img/2.png', 'CloudTRIX','sunil@cloudtrix.in', '0000000000', '$', 'Mumbai, India', '02-03-2018','23-04-2019', 'false', 'www.cloudtrix.in')");
            }
            CreateTable(
                "dbo.Architect",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArchitectName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        GSTIN = c.String(),
                        Notes = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        EmployeeEmail = c.String(),
                        EmployeePhone = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeGender = c.String(),
                        EmployeeDOB = c.DateTime(nullable: false),
                        EmployeeDOJ = c.DateTime(nullable: false),
                        EmployeeAddress = c.String(),
                        EmployeeSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceCode = c.String(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Total = c.Double(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        Status = c.String(),
                        Discount = c.Double(nullable: false),
                        IGST = c.Double(nullable: false),
                        CGST = c.Double(nullable: false),
                        SGST = c.Double(nullable: false),
                        GrandTotal = c.Double(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        BillingName = c.String(),
                        ArchitectId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Architect", t => t.ArchitectId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ArchitectId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.StoreSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        StoreName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Web = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Currency = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeSheet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        WorkDetails = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.UserAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheet", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.TimeSheet", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Project", "ArchitectId", "dbo.Architect");
            DropIndex("dbo.TimeSheet", new[] { "ProjectId" });
            DropIndex("dbo.TimeSheet", new[] { "EmployeeId" });
            DropIndex("dbo.Project", new[] { "CustomerId" });
            DropIndex("dbo.Project", new[] { "ArchitectId" });
            DropIndex("dbo.Invoice", new[] { "ProjectId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropTable("dbo.UserAccount");
            DropTable("dbo.TimeSheet");
            DropTable("dbo.StoreSetting");
            DropTable("dbo.Project");
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Employee");
            DropTable("dbo.Customer");
            DropTable("dbo.Architect");
        }
    }
}
