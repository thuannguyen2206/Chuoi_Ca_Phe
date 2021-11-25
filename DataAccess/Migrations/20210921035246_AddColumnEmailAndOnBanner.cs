using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddColumnEmailAndOnBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 660, DateTimeKind.Local).AddTicks(2251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 194, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 649, DateTimeKind.Local).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 184, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(2979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 661, DateTimeKind.Local).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 195, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 647, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 182, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 645, DateTimeKind.Local).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 181, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 644, DateTimeKind.Local).AddTicks(9154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 180, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 643, DateTimeKind.Local).AddTicks(7943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 179, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 638, DateTimeKind.Local).AddTicks(9754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 175, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.AddColumn<bool>(
                name: "OnBanner",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 642, DateTimeKind.Local).AddTicks(6935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 178, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 641, DateTimeKind.Local).AddTicks(372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 176, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 634, DateTimeKind.Local).AddTicks(5415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 171, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 630, DateTimeKind.Local).AddTicks(9347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 167, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 632, DateTimeKind.Local).AddTicks(6670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 169, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 658, DateTimeKind.Local).AddTicks(9969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 193, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 628, DateTimeKind.Local).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 165, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(6089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 626, DateTimeKind.Local).AddTicks(3515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 163, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 619, DateTimeKind.Local).AddTicks(6991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 157, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 621, DateTimeKind.Local).AddTicks(3896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 159, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 616, DateTimeKind.Local).AddTicks(8373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 154, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 666, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 666, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 668, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 21, 10, 52, 45, 667, DateTimeKind.Local).AddTicks(8263));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnBanner",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 194, DateTimeKind.Local).AddTicks(6685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 660, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 184, DateTimeKind.Local).AddTicks(9633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 649, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(7792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 183, DateTimeKind.Local).AddTicks(5354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 195, DateTimeKind.Local).AddTicks(6660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 661, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 182, DateTimeKind.Local).AddTicks(6995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 647, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 181, DateTimeKind.Local).AddTicks(3311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 645, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 180, DateTimeKind.Local).AddTicks(5346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 644, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 179, DateTimeKind.Local).AddTicks(4948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 643, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 175, DateTimeKind.Local).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 638, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 178, DateTimeKind.Local).AddTicks(4656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 642, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 176, DateTimeKind.Local).AddTicks(9476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 641, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 171, DateTimeKind.Local).AddTicks(2763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 634, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 167, DateTimeKind.Local).AddTicks(7331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 630, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 169, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 632, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 193, DateTimeKind.Local).AddTicks(5445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 658, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 165, DateTimeKind.Local).AddTicks(8996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 628, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 164, DateTimeKind.Local).AddTicks(7191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 163, DateTimeKind.Local).AddTicks(5884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 626, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 157, DateTimeKind.Local).AddTicks(5416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 619, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 159, DateTimeKind.Local).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 621, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 16, 50, 0, 154, DateTimeKind.Local).AddTicks(7758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 616, DateTimeKind.Local).AddTicks(8373));

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
    }
}
