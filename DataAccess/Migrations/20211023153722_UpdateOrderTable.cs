using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "GiftExchanges");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Headquarters",
                table: "StoreLocations",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 810, DateTimeKind.Local).AddTicks(9741),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 816, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 801, DateTimeKind.Local).AddTicks(3852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 807, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 800, DateTimeKind.Local).AddTicks(229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 799, DateTimeKind.Local).AddTicks(9054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 812, DateTimeKind.Local).AddTicks(8602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 818, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 798, DateTimeKind.Local).AddTicks(4021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 804, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 796, DateTimeKind.Local).AddTicks(3375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 802, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 796, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 787, DateTimeKind.Local).AddTicks(7236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 793, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 782, DateTimeKind.Local).AddTicks(75),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 787, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 791, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 783, DateTimeKind.Local).AddTicks(9690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 789, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AddColumn<int>(
                name: "DeliveryServiceType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 777, DateTimeKind.Local).AddTicks(3630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 782, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "GiftExchanges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GiftExchanges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 774, DateTimeKind.Local).AddTicks(9846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 780, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(9194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(7995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 770, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 766, DateTimeKind.Local).AddTicks(468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 771, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 761, DateTimeKind.Local).AddTicks(5193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 766, DateTimeKind.Local).AddTicks(7813));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryServiceType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "GiftExchanges");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GiftExchanges");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreLocations",
                newName: "Headquarters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 816, DateTimeKind.Local).AddTicks(6309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 810, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 807, DateTimeKind.Local).AddTicks(1791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 801, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 800, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(7899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 799, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "Tags",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 818, DateTimeKind.Local).AddTicks(5233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 812, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 804, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 798, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 802, DateTimeKind.Local).AddTicks(1181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 796, DateTimeKind.Local).AddTicks(3375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 796, DateTimeKind.Local).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Ratings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 793, DateTimeKind.Local).AddTicks(3153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 787, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 787, DateTimeKind.Local).AddTicks(5661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 782, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 791, DateTimeKind.Local).AddTicks(790),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "ProductImages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 789, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 783, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 782, DateTimeKind.Local).AddTicks(8087),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 777, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "GiftExchanges",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 780, DateTimeKind.Local).AddTicks(2244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 774, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(1331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 772, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 770, DateTimeKind.Local).AddTicks(3842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Carts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 771, DateTimeKind.Local).AddTicks(8296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 766, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 766, DateTimeKind.Local).AddTicks(7813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 22, 37, 21, 761, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 831, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 830, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 830, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 832, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 831, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 36, 31, 831, DateTimeKind.Local).AddTicks(5685));
        }
    }
}
