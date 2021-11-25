using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 194, DateTimeKind.Local).AddTicks(6685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 532, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 184, DateTimeKind.Local).AddTicks(9633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 518, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(7792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 195, DateTimeKind.Local).AddTicks(6660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 533, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 182, DateTimeKind.Local).AddTicks(6995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 515, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 181, DateTimeKind.Local).AddTicks(3311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 514, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 180, DateTimeKind.Local).AddTicks(5346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 513, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 179, DateTimeKind.Local).AddTicks(4948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 512, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 175, DateTimeKind.Local).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 507, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ProductOptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 178, DateTimeKind.Local).AddTicks(4656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 511, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 176, DateTimeKind.Local).AddTicks(9476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 509, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 171, DateTimeKind.Local).AddTicks(2763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 504, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 167, DateTimeKind.Local).AddTicks(7331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 500, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "Orders",
                type: "nvarchar(max)",
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
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 169, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 501, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 193, DateTimeKind.Local).AddTicks(5445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 531, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 165, DateTimeKind.Local).AddTicks(8996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 498, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(7191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 163, DateTimeKind.Local).AddTicks(5884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 495, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 157, DateTimeKind.Local).AddTicks(5416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 489, DateTimeKind.Local).AddTicks(5714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 159, DateTimeKind.Local).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 491, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.AddColumn<int>(
                name: "ColorOptionId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeOptionId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 154, DateTimeKind.Local).AddTicks(7758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 486, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(2707));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 200, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 200, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 202, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 20, 16, 50, 0, 201, DateTimeKind.Local).AddTicks(7659));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ProductOptions");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ColorOptionId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "SizeOptionId",
                table: "CartItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 532, DateTimeKind.Local).AddTicks(3872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 194, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 518, DateTimeKind.Local).AddTicks(7274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 184, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(3242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 517, DateTimeKind.Local).AddTicks(716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 533, DateTimeKind.Local).AddTicks(7081),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 195, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 515, DateTimeKind.Local).AddTicks(9038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 182, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 514, DateTimeKind.Local).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 181, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 513, DateTimeKind.Local).AddTicks(6837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 180, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 512, DateTimeKind.Local).AddTicks(5542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 179, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 507, DateTimeKind.Local).AddTicks(8207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 175, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 511, DateTimeKind.Local).AddTicks(4739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 178, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 509, DateTimeKind.Local).AddTicks(8622),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 176, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 504, DateTimeKind.Local).AddTicks(140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 171, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 500, DateTimeKind.Local).AddTicks(2659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 167, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 501, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 169, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 531, DateTimeKind.Local).AddTicks(1585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 193, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 498, DateTimeKind.Local).AddTicks(4728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 165, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 13, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 497, DateTimeKind.Local).AddTicks(2180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 495, DateTimeKind.Local).AddTicks(9978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 163, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 489, DateTimeKind.Local).AddTicks(5714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 157, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 491, DateTimeKind.Local).AddTicks(1452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 159, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 11, 21, 50, 37, 486, DateTimeKind.Local).AddTicks(2613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 154, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 11, 21, 50, 37, 541, DateTimeKind.Local).AddTicks(4630));

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
    }
}
