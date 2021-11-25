using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeBrandImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "link",
                table: "Menus",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "BrandImage",
                table: "Brands",
                newName: "BrandLogo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 532, DateTimeKind.Local).AddTicks(3872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 953, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 518, DateTimeKind.Local).AddTicks(7274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 943, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(3242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 942, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 941, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 533, DateTimeKind.Local).AddTicks(7081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 954, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 515, DateTimeKind.Local).AddTicks(9038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 940, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 514, DateTimeKind.Local).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 939, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 513, DateTimeKind.Local).AddTicks(6837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 938, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 512, DateTimeKind.Local).AddTicks(5542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 937, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 507, DateTimeKind.Local).AddTicks(8207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 932, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 511, DateTimeKind.Local).AddTicks(4739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 936, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 509, DateTimeKind.Local).AddTicks(8622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 934, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 504, DateTimeKind.Local).AddTicks(140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 929, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 500, DateTimeKind.Local).AddTicks(2659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 926, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 501, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 927, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 531, DateTimeKind.Local).AddTicks(1585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 952, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 498, DateTimeKind.Local).AddTicks(4728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 924, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(2180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 495, DateTimeKind.Local).AddTicks(9978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 922, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 489, DateTimeKind.Local).AddTicks(5714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 915, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 491, DateTimeKind.Local).AddTicks(1452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 917, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 486, DateTimeKind.Local).AddTicks(2613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 913, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "DateCreated", "DateModified", "DisplayOrder", "IsActive", "Link", "MenuType", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3696), null, 1, true, "/", 1, "Home" },
                    { 2, new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4552), null, 2, true, "/shop", 1, "Shop" },
                    { 3, new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4625), null, 3, true, "/blog", 1, "Blog" },
                    { 4, new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4628), null, 4, true, "/contact", 1, "Contact" },
                    { 5, new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4630), null, 5, true, "/about", 1, "About" }
                });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 539, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 539, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 540, DateTimeKind.Local).AddTicks(8057));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "RatingStar",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Menus",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "BrandLogo",
                table: "Brands",
                newName: "BrandImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 953, DateTimeKind.Local).AddTicks(2034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 532, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 943, DateTimeKind.Local).AddTicks(3440),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 518, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 942, DateTimeKind.Local).AddTicks(1167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 941, DateTimeKind.Local).AddTicks(8712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 954, DateTimeKind.Local).AddTicks(2387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 533, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 940, DateTimeKind.Local).AddTicks(7721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 515, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 939, DateTimeKind.Local).AddTicks(4040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 514, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 938, DateTimeKind.Local).AddTicks(5728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 513, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.AddColumn<int>(
                name: "RatingStart",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 937, DateTimeKind.Local).AddTicks(5105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 512, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 932, DateTimeKind.Local).AddTicks(9838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 507, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 936, DateTimeKind.Local).AddTicks(4002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 511, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 934, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 509, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 929, DateTimeKind.Local).AddTicks(4025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 504, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 926, DateTimeKind.Local).AddTicks(749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 500, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 927, DateTimeKind.Local).AddTicks(6555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 501, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 952, DateTimeKind.Local).AddTicks(164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 531, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 924, DateTimeKind.Local).AddTicks(4158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 498, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(3380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(1918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 922, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 495, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 915, DateTimeKind.Local).AddTicks(8254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 489, DateTimeKind.Local).AddTicks(5714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 917, DateTimeKind.Local).AddTicks(3374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 491, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 913, DateTimeKind.Local).AddTicks(899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 486, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 959, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 959, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 3, 14, 56, 45, 960, DateTimeKind.Local).AddTicks(3664));
        }
    }
}
