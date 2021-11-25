using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddOriginalPriceInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Promotions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 35, DateTimeKind.Local).AddTicks(9691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 810, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 26, DateTimeKind.Local).AddTicks(7821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 801, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(5113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 800, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(3932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 799, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 37, DateTimeKind.Local).AddTicks(9106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 812, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 23, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 798, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 21, DateTimeKind.Local).AddTicks(6446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 796, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Ratings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShow",
                table: "Promotions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 13, DateTimeKind.Local).AddTicks(8982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 787, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 8, DateTimeKind.Local).AddTicks(6642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 782, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 10, DateTimeKind.Local).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 783, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 3, DateTimeKind.Local).AddTicks(8723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 777, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 1, DateTimeKind.Local).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 774, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(4701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(3533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 993, DateTimeKind.Local).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 766, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 988, DateTimeKind.Local).AddTicks(5130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 761, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 49, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 49, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 51, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 50, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 25, 13, 11, 9, 50, DateTimeKind.Local).AddTicks(6423));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 810, DateTimeKind.Local).AddTicks(9741),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 35, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 801, DateTimeKind.Local).AddTicks(3852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 26, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 800, DateTimeKind.Local).AddTicks(229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 799, DateTimeKind.Local).AddTicks(9054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 812, DateTimeKind.Local).AddTicks(8602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 37, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 798, DateTimeKind.Local).AddTicks(4021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 23, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 796, DateTimeKind.Local).AddTicks(3375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 21, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.AlterColumn<bool>(
                name: "IsShow",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 787, DateTimeKind.Local).AddTicks(7236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 13, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Promotions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 782, DateTimeKind.Local).AddTicks(75),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 8, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 783, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 10, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 777, DateTimeKind.Local).AddTicks(3630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 3, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 774, DateTimeKind.Local).AddTicks(9846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 1, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(9194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(7995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 766, DateTimeKind.Local).AddTicks(468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 993, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 761, DateTimeKind.Local).AddTicks(5193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 988, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 824, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 824, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 826, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 825, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 23, 22, 37, 21, 825, DateTimeKind.Local).AddTicks(7346));
        }
    }
}
