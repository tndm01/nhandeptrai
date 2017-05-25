namespace NNShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetRolesByUser : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_GetRolesByUserName",
                p => new
                {
                    userId = p.String()
                }
                ,
                @"
                select us.UserName,
                ag.Name
                from ApplicationGroups ag
                inner join ApplicationUserGroups usg
                on ag.ID = usg.GroupId inner join
                ApplicationUsers us on us.Id = usg.UserId
                where us.UserName = @UserId"
                );
        }

        public override void Down()
        {
        }
    }
}
