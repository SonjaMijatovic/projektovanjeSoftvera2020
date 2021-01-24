namespace PSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change121 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFree = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateUpdated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Doctor_Id)
                .ForeignKey("dbo.Users", t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropTable("dbo.Appointments");
        }
    }
}
