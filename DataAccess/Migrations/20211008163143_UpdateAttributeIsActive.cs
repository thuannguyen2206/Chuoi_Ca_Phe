using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateAttributeIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 709, DateTimeKind.Local).AddTicks(3174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 770, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 694, DateTimeKind.Local).AddTicks(9423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 759, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "TokenConfirm",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 693, DateTimeKind.Local).AddTicks(1472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 692, DateTimeKind.Local).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "StoreLocations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 712, DateTimeKind.Local).AddTicks(247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 772, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Slides",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 690, DateTimeKind.Local).AddTicks(9552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 755, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 686, DateTimeKind.Local).AddTicks(2863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 751, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 682, DateTimeKind.Local).AddTicks(2272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 750, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Ratings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "Promotions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 679, DateTimeKind.Local).AddTicks(7636),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 748, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 672, DateTimeKind.Local).AddTicks(1704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 741, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.AlterColumn<string>(
                name: "CodeProduct",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 676, DateTimeKind.Local).AddTicks(9801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 745, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "ProductDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 674, DateTimeKind.Local).AddTicks(9245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 743, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "PostReviews",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 667, DateTimeKind.Local).AddTicks(6675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 737, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 662, DateTimeKind.Local).AddTicks(4105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 734, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 664, DateTimeKind.Local).AddTicks(7534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 736, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Options",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 707, DateTimeKind.Local).AddTicks(2662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 768, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Menus",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 659, DateTimeKind.Local).AddTicks(8095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 732, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 657, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 656, DateTimeKind.Local).AddTicks(8585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 653, DateTimeKind.Local).AddTicks(8213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 728, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 644, DateTimeKind.Local).AddTicks(620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 721, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 646, DateTimeKind.Local).AddTicks(905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 723, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Brands",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Brands",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 638, DateTimeKind.Local).AddTicks(6604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 719, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 728, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 728, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 730, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 8, 23, 31, 42, 729, DateTimeKind.Local).AddTicks(7615));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Contacts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 770, DateTimeKind.Local).AddTicks(182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 709, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 759, DateTimeKind.Local).AddTicks(3037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 694, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "TokenConfirm",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(6073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 693, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(3535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 692, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "StoreLocations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 772, DateTimeKind.Local).AddTicks(2715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 712, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 755, DateTimeKind.Local).AddTicks(4382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 690, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 751, DateTimeKind.Local).AddTicks(3915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 686, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 750, DateTimeKind.Local).AddTicks(3701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 682, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 748, DateTimeKind.Local).AddTicks(3317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 679, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 741, DateTimeKind.Local).AddTicks(5613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 672, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.AlterColumn<string>(
                name: "CodeProduct",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 745, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 676, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 743, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 674, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "PostReviews",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 737, DateTimeKind.Local).AddTicks(8950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 667, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 734, DateTimeKind.Local).AddTicks(4219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 662, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 736, DateTimeKind.Local).AddTicks(851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 664, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 768, DateTimeKind.Local).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 707, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 732, DateTimeKind.Local).AddTicks(5317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 659, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(5350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 657, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 656, DateTimeKind.Local).AddTicks(8585));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 728, DateTimeKind.Local).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 653, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 721, DateTimeKind.Local).AddTicks(9354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 644, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 723, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 646, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 719, DateTimeKind.Local).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 638, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 783, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 783, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(5608));
        }
    }
}
