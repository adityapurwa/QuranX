namespace QuranX.DomainLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addchapter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        NumberOfVerses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chapters");
        }
    }
}
