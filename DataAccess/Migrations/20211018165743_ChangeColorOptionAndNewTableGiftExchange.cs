using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeColorOptionAndNewTableGiftExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReceived",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ColorOptionId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ColorOptionId",
                table: "CartItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 767, DateTimeKind.Local).AddTicks(3091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 761, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 757, DateTimeKind.Local).AddTicks(9564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 748, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 20, 23, 57, 42, 756, DateTimeKind.Local).AddTicks(6483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 756, DateTimeKind.Local).AddTicks(5249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 769, DateTimeKind.Local).AddTicks(1782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 763, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 754, DateTimeKind.Local).AddTicks(7710),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 745, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 750, DateTimeKind.Local).AddTicks(8345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 737, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 745, DateTimeKind.Local).AddTicks(643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 726, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ratings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ratings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 742, DateTimeKind.Local).AddTicks(6284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 723, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 736, DateTimeKind.Local).AddTicks(8528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 716, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 740, DateTimeKind.Local).AddTicks(3909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 720, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 738, DateTimeKind.Local).AddTicks(8692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 718, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 732, DateTimeKind.Local).AddTicks(1540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 711, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 729, DateTimeKind.Local).AddTicks(5011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 706, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 20, 23, 57, 42, 727, DateTimeKind.Local).AddTicks(4825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 727, DateTimeKind.Local).AddTicks(3566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 719, DateTimeKind.Local).AddTicks(3988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 690, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 720, DateTimeKind.Local).AddTicks(8477),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 692, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 715, DateTimeKind.Local).AddTicks(8208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 685, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.CreateTable(
                name: "GiftExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RedemptionPoints = table.Column<int>(type: "int", nullable: false),
                    SeoAlias = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftExchanges", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 781, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 781, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 783, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 783, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 18, 23, 57, 42, 782, DateTimeKind.Local).AddTicks(2564));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiftExchanges");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CorlorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 761, DateTimeKind.Local).AddTicks(4506),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 767, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 748, DateTimeKind.Local).AddTicks(7164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 757, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(3345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 20, 23, 57, 42, 756, DateTimeKind.Local).AddTicks(6483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 747, DateTimeKind.Local).AddTicks(1695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 756, DateTimeKind.Local).AddTicks(5249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 763, DateTimeKind.Local).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 769, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 745, DateTimeKind.Local).AddTicks(284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 754, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 737, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 750, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 726, DateTimeKind.Local).AddTicks(9382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 745, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 723, DateTimeKind.Local).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 742, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 716, DateTimeKind.Local).AddTicks(4982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 736, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 720, DateTimeKind.Local).AddTicks(2920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 740, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 718, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 738, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.AddColumn<bool>(
                name: "IsReceived",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 711, DateTimeKind.Local).AddTicks(4283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 732, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.AddColumn<int>(
                name: "ColorOptionId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 706, DateTimeKind.Local).AddTicks(8548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 729, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(8474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 20, 23, 57, 42, 727, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 702, DateTimeKind.Local).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 727, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 690, DateTimeKind.Local).AddTicks(4925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 719, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 692, DateTimeKind.Local).AddTicks(4953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 720, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.AddColumn<int>(
                name: "ColorOptionId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 18, 23, 21, 685, DateTimeKind.Local).AddTicks(2107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 18, 23, 57, 42, 715, DateTimeKind.Local).AddTicks(8208));

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
    }
}
