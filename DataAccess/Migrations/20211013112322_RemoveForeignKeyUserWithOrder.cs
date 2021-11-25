using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemoveForeignKeyUserWithOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 761, DateTimeKind.Local).AddTicks(4506),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 435, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 748, DateTimeKind.Local).AddTicks(7164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 425, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.AddColumn<int>(
                name: "AccumulatedPoint",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(3345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(1695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 763, DateTimeKind.Local).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 437, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 745, DateTimeKind.Local).AddTicks(284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 422, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 737, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 419, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 726, DateTimeKind.Local).AddTicks(9382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 418, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 723, DateTimeKind.Local).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 416, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 716, DateTimeKind.Local).AddTicks(4982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 410, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 720, DateTimeKind.Local).AddTicks(2920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 414, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 718, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 412, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 711, DateTimeKind.Local).AddTicks(4283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 406, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 706, DateTimeKind.Local).AddTicks(8548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 402, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(8474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 690, DateTimeKind.Local).AddTicks(4925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 392, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 692, DateTimeKind.Local).AddTicks(4953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 394, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 685, DateTimeKind.Local).AddTicks(2107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 389, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 777, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 777, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 13, 18, 23, 21, 778, DateTimeKind.Local).AddTicks(2451));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccumulatedPoint",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 435, DateTimeKind.Local).AddTicks(5507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 761, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 425, DateTimeKind.Local).AddTicks(6952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 748, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(4263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(3038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 437, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 763, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 422, DateTimeKind.Local).AddTicks(7766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 745, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 419, DateTimeKind.Local).AddTicks(2789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 737, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 418, DateTimeKind.Local).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 726, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 416, DateTimeKind.Local).AddTicks(3734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 723, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 410, DateTimeKind.Local).AddTicks(6788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 716, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 414, DateTimeKind.Local).AddTicks(1543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 720, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 412, DateTimeKind.Local).AddTicks(5826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 718, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 406, DateTimeKind.Local).AddTicks(673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 711, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 402, DateTimeKind.Local).AddTicks(7749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 706, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(6466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 392, DateTimeKind.Local).AddTicks(8319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 690, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 394, DateTimeKind.Local).AddTicks(3216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 692, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 389, DateTimeKind.Local).AddTicks(1979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 685, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 447, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 447, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 10, 10, 47, 47, 449, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
