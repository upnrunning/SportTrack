namespace SportTrack.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Objectives");
            AddColumn("dbo.Objectives", "ObjectiveId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Objectives", "Name", c => c.String());
            AddPrimaryKey("dbo.Objectives", "ObjectiveId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Objectives");
            AlterColumn("dbo.Objectives", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Objectives", "ObjectiveId");
            AddPrimaryKey("dbo.Objectives", "Name");
        }
    }
}
