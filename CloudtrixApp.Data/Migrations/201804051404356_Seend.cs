namespace CloudtrixApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seend : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO UserAccount (Name,Email,Password, Role, CreateDate, UpdateDate,IsDelete) VALUES ('CloudTRIX', 'sunil@cloudtrix.in', '12345','Admin', '02-03-2018','02-03-2018', 'false')");
            Sql("INSERT INTO Customer (Name,Email,Phone, CreateDate, UpdateDate,IsDelete) VALUES ('Walk in Customer', 'customer@gmail.com', '0000000000', '02-03-2018','02-03-2018', 'false')");
            Sql("INSERT INTO StoreSetting (Logo,StoreName,Email, Phone, Currency, Address, CreateDate,UpdateDate,IsDelete, web) VALUES ('/Content/adminFront/assets/img/2.png', 'CloudTRIX','sunil@cloudtrix.in', '0000000000', '$', 'Mumbai, India', '02-03-2018','23-04-2019', 'false', 'www.kodauthor.com')");
        }
        
        public override void Down()
        {
        }
    }
}
