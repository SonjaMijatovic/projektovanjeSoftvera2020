namespace PSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medicine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        UserType = c.String(),
                        IsFirstTime = c.Boolean(nullable: false),
                        Blocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                        DoctorType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Doctor_Id)
                .ForeignKey("dbo.DoctorTypes", t => t.DoctorType_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.DoctorType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DoctorType_Id", "dbo.DoctorTypes");
            DropForeignKey("dbo.Users", "Doctor_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "DoctorType_Id" });
            DropIndex("dbo.Users", new[] { "Doctor_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Medicines");
            DropTable("dbo.DoctorTypes");
        }
    }
}
