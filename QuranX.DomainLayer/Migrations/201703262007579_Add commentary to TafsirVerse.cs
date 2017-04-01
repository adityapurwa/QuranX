namespace QuranX.DomainLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddcommentarytoTafsirVerse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TafsirVerses", "Commentary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TafsirVerses", "Commentary");
        }
    }
}
