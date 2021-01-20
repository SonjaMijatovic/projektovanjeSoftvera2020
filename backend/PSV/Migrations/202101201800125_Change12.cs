namespace PSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Visible = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "User_Id", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "User_Id" });
            DropTable("dbo.Feedbacks");
        }
    }
}
