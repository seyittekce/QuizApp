using System.Data.Entity.Migrations;

namespace QuizApp.Migrations
{
#pragma warning disable IDE1006 // Naming Styles
    public partial class nam : DbMigration
#pragma warning restore IDE1006 // Naming Styles
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "NickName");
        }

        public override void Down()
        {
            AddColumn("dbo.Students", "NickName", c => c.String(false));
        }
    }
}