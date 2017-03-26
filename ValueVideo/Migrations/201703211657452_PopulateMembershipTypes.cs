namespace ValueVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO MembershipTypes (Id,Name,Fee,DurationInMonths,DiscountPercentage) VALUES (1,'Pay as you Go',0,0,0)");
            Sql(@"INSERT INTO MembershipTypes (Id,Name,Fee,DurationInMonths,DiscountPercentage) VALUES (2,'Monthly',30,1,10)");
            Sql(@"INSERT INTO MembershipTypes (Id,Name,Fee,DurationInMonths,DiscountPercentage) VALUES (3,'Quarterly',90,3,15)");
            Sql(@"INSERT INTO MembershipTypes (Id,Name,Fee,DurationInMonths,DiscountPercentage) VALUES (4,'Annual',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
