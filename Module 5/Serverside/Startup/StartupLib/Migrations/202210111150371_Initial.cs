namespace StartupLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Name = c.String(),
                        BossId = c.Int(),
                        MainTeacherId = c.Int(),
                        HasCiscoCertificate = c.Boolean(),
                        Github = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        School_Id = c.Int(),
                        Subject_Id = c.Int(),
                        School_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.BossId)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.MainTeacherId)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Schools", t => t.School_Id1)
                .Index(t => t.SchoolId)
                .Index(t => t.BossId)
                .Index(t => t.MainTeacherId)
                .Index(t => t.School_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.School_Id1);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Name = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.SchoolId)
                .Index(t => t.TeacherId)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "School_Id1", "dbo.Schools");
            DropForeignKey("dbo.Subjects", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.People");
            DropForeignKey("dbo.People", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.People", "MainTeacherId", "dbo.People");
            DropForeignKey("dbo.Subjects", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.People", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.People", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.People", "BossId", "dbo.People");
            DropIndex("dbo.Subjects", new[] { "Person_Id" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropIndex("dbo.Subjects", new[] { "SchoolId" });
            DropIndex("dbo.People", new[] { "School_Id1" });
            DropIndex("dbo.People", new[] { "Subject_Id" });
            DropIndex("dbo.People", new[] { "School_Id" });
            DropIndex("dbo.People", new[] { "MainTeacherId" });
            DropIndex("dbo.People", new[] { "BossId" });
            DropIndex("dbo.People", new[] { "SchoolId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Schools");
            DropTable("dbo.People");
        }
    }
}
