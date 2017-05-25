namespace NNShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetNameProductById : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_GetNameProductById",
                p => new
                {
                    id = p.Int()
                }
                ,
                @"
                select p.Name from Orders o 
                inner join OrderDetails od
                on o.ID = od.OrderID
                inner join Products p
                on od.ProductID = p.ID
                where o.ID = @ID"
                );
        }
        
        public override void Down()
        {
        }
    }
}
