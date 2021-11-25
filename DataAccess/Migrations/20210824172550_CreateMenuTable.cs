using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 662, DateTimeKind.Local).AddTicks(9042),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 391, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 653, DateTimeKind.Local).AddTicks(826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 380, DateTimeKind.Local).AddTicks(9588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(8457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 23, 19, 47, 379, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(6111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 379, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 663, DateTimeKind.Local).AddTicks(9269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 392, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "StoreLocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 650, DateTimeKind.Local).AddTicks(7518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 378, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.AddColumn<int>(
                name: "SlideType",
                table: "Slides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 649, DateTimeKind.Local).AddTicks(4130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 377, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 648, DateTimeKind.Local).AddTicks(6772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 376, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 647, DateTimeKind.Local).AddTicks(6491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 375, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 642, DateTimeKind.Local).AddTicks(9878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 368, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.AddColumn<bool>(
                name: "OnTopHot",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 646, DateTimeKind.Local).AddTicks(6201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 373, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 645, DateTimeKind.Local).AddTicks(1080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 371, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 639, DateTimeKind.Local).AddTicks(3305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 365, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 635, DateTimeKind.Local).AddTicks(9575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 361, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 637, DateTimeKind.Local).AddTicks(5087),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 363, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 661, DateTimeKind.Local).AddTicks(7554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 390, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 634, DateTimeKind.Local).AddTicks(2978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 360, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(2137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 23, 19, 47, 358, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(1038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 358, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 631, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 357, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 625, DateTimeKind.Local).AddTicks(9116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 350, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 627, DateTimeKind.Local).AddTicks(3717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 352, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 623, DateTimeKind.Local).AddTicks(2492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 348, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 670, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 670, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 670, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 670, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 670, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 668, DateTimeKind.Local).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 668, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 669, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 8, 25, 0, 25, 49, 669, DateTimeKind.Local).AddTicks(7207));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "StoreLocations");

            migrationBuilder.DropColumn(
                name: "SlideType",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "OnTopHot",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 391, DateTimeKind.Local).AddTicks(5349),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 662, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 380, DateTimeKind.Local).AddTicks(9588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 653, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 23, 19, 47, 379, DateTimeKind.Local).AddTicks(7398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 379, DateTimeKind.Local).AddTicks(5108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 392, DateTimeKind.Local).AddTicks(4749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 663, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 378, DateTimeKind.Local).AddTicks(6426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 650, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 377, DateTimeKind.Local).AddTicks(3319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 649, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 376, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 648, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 375, DateTimeKind.Local).AddTicks(3330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 647, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 368, DateTimeKind.Local).AddTicks(7315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 642, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 373, DateTimeKind.Local).AddTicks(7107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 646, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 371, DateTimeKind.Local).AddTicks(6288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 645, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 365, DateTimeKind.Local).AddTicks(1258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 639, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 361, DateTimeKind.Local).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 635, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 363, DateTimeKind.Local).AddTicks(3823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 637, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 390, DateTimeKind.Local).AddTicks(3658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 661, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 360, DateTimeKind.Local).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 634, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 23, 19, 47, 358, DateTimeKind.Local).AddTicks(9039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 358, DateTimeKind.Local).AddTicks(7728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 357, DateTimeKind.Local).AddTicks(4167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 631, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 350, DateTimeKind.Local).AddTicks(9577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 625, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 352, DateTimeKind.Local).AddTicks(4760),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 627, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 24, 23, 19, 47, 348, DateTimeKind.Local).AddTicks(2207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 623, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 394, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 395, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 395, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 395, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 395, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 393, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 393, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 394, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 8, 24, 23, 19, 47, 394, DateTimeKind.Local).AddTicks(5803));
        }
    }
}
