using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class addfieldtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondarySubCategoryid",
                schema: "product",
                table: "Products",
                newName: "SecondarySubCategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "user",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "SecondarySubCategoryId",
                schema: "product",
                table: "Products",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "user",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SecondarySubCategoryId",
                schema: "product",
                table: "Products",
                newName: "SecondarySubCategoryid");

            migrationBuilder.AlterColumn<long>(
                name: "SecondarySubCategoryid",
                schema: "product",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
