namespace SportTrack.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Objectives");
            AlterColumn("dbo.Objectives", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Objectives", "Name");
            DropColumn("dbo.Objectives", "ObjectiveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objectives", "ObjectiveId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Objectives");
            AlterColumn("dbo.Objectives", "Name", c => c.String());
            AddPrimaryKey("dbo.Objectives", "ObjectiveId");
        }
    }
}
