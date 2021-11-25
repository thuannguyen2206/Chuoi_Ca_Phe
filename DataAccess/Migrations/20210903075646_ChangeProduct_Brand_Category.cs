using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeProduct_Brand_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 953, DateTimeKind.Local).AddTicks(2034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 662, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 943, DateTimeKind.Local).AddTicks(3440),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 653, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 942, DateTimeKind.Local).AddTicks(1167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 941, DateTimeKind.Local).AddTicks(8712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 954, DateTimeKind.Local).AddTicks(2387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 663, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 940, DateTimeKind.Local).AddTicks(7721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 650, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 939, DateTimeKind.Local).AddTicks(4040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 649, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 938, DateTimeKind.Local).AddTicks(5728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 648, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 937, DateTimeKind.Local).AddTicks(5105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 647, DateTimeKind.Local).AddTicks(6491));

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 932, DateTimeKind.Local).AddTicks(9838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 642, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 936, DateTimeKind.Local).AddTicks(4002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 646, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 934, DateTimeKind.Local).AddTicks(8765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 645, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 929, DateTimeKind.Local).AddTicks(4025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 639, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 926, DateTimeKind.Local).AddTicks(749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 635, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 927, DateTimeKind.Local).AddTicks(6555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 637, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 952, DateTimeKind.Local).AddTicks(164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 661, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 924, DateTimeKind.Local).AddTicks(4158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 634, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(3380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(1918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 922, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 631, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 915, DateTimeKind.Local).AddTicks(8254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 625, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 917, DateTimeKind.Local).AddTicks(3374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 627, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 913, DateTimeKind.Local).AddTicks(899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 623, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.AddColumn<string>(
                name: "BrandImage",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BrandImage",
                table: "Brands");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 662, DateTimeKind.Local).AddTicks(9042),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 953, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 653, DateTimeKind.Local).AddTicks(826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 943, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(8457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 942, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 651, DateTimeKind.Local).AddTicks(6111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 941, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 663, DateTimeKind.Local).AddTicks(9269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 954, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 650, DateTimeKind.Local).AddTicks(7518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 940, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 649, DateTimeKind.Local).AddTicks(4130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 939, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 648, DateTimeKind.Local).AddTicks(6772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 938, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 647, DateTimeKind.Local).AddTicks(6491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 937, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 642, DateTimeKind.Local).AddTicks(9878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 932, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 646, DateTimeKind.Local).AddTicks(6201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 936, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 645, DateTimeKind.Local).AddTicks(1080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 934, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 639, DateTimeKind.Local).AddTicks(3305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 929, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 635, DateTimeKind.Local).AddTicks(9575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 926, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 637, DateTimeKind.Local).AddTicks(5087),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 927, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 661, DateTimeKind.Local).AddTicks(7554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 952, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 634, DateTimeKind.Local).AddTicks(2978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 924, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(2137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 5, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 633, DateTimeKind.Local).AddTicks(1038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 923, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 631, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 922, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 625, DateTimeKind.Local).AddTicks(9116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 915, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 627, DateTimeKind.Local).AddTicks(3717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 917, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 0, 25, 49, 623, DateTimeKind.Local).AddTicks(2492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 3, 14, 56, 45, 913, DateTimeKind.Local).AddTicks(899));

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
    }
}
