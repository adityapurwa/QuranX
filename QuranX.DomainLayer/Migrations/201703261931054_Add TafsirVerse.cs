namespace QuranX.DomainLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTafsirVerse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TafsirVerses",
                c => new
                    {
                        TafsirCode = c.String(nullable: false, maxLength: 128),
                        Chapter = c.Int(nullable: false),
                        FirstVerse = c.Int(nullable: false),
                        LastVerse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TafsirCode, t.Chapter, t.FirstVerse });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TafsirVerses");
        }
    }
}
