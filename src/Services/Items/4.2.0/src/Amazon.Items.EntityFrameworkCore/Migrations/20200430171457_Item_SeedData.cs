using Microsoft.EntityFrameworkCore.Migrations;

namespace Amazon.Items.Migrations
{
    public partial class Item_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var arr = new string[] { "Dell", "Hp", "Acer", "Apple", "MI", "Samsung", "Lenovo", "Huwawi" };

            migrationBuilder.Sql(@" TRUNCATE TABLE  [Item].[Item];
                delete from[Item].[Brand];
            DBCC CHECKIDENT('[Item].[Brand]', RESEED, 0); ");
            
            migrationBuilder.Sql($@"INSERT INTO [Item].[Brand]([Name],[Description],[Image],[IsDeleted])
                 VALUES('Dell', 'Del; description', 'del.png', 0),
                  ('HP', 'HP description', 'del.png', 0),
                  ('Acer', 'Azur description', 'azur.png', 0),
                  ('Apple', 'Apple description', 'apple.png', 0),
                  ('MI', 'MI description', 'mi.png', 0),
                  ('Samsung', 'Samsung description', 'samsung.png', 0),
                  ('Lenovo', 'Lenovo description', 'lenovo.png', 0),
                   ('Huawi', 'Huawi description', 'Huawi.png', 0);");

            for (int i = 1; i < 9; i++)
            {
                for (int i2 = 1; i2 <= 5; i2++)
                {
                    migrationBuilder.Sql($@"INSERT INTO [Item].[Item]([Name],[Description],[Image],[Review],
                                    [NumberOfAvailableItems],[BrandId],[IsDeleted],[Price])
                         VALUES  ('{arr[i - 1]}-{i2}','{arr[i - 1]}-{i2} Description','no.png','4',100,{i},0,100)");
                }
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
