namespace NNShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.Tags", "ID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.Tags", "ID");
            AddForeignKey("dbo.PostTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.Tags", "ID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.Tags", "ID");
            AddForeignKey("dbo.ProductTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostTags", "TagID", "dbo.Tags", "ID", cascadeDelete: true);
        }
    }
}
