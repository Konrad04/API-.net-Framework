namespace codeWiki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Image");
        }
    }
}
