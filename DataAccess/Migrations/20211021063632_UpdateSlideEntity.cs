using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateSlideEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "SlideType",
                table: "Slides");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Slides",
                newName: "Title");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 816, DateTimeKind.Local).AddTicks(6309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 76, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 807, DateTimeKind.Local).AddTicks(1791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 66, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 7, 1, 64, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(7899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 64, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 818, DateTimeKind.Local).AddTicks(5233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 78, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 804, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 63, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 802, DateTimeKind.Local).AddTicks(1181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 59, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 796, DateTimeKind.Local).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 53, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 793, DateTimeKind.Local).AddTicks(3153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 50, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 787, DateTimeKind.Local).AddTicks(5661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 44, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 791, DateTimeKind.Local).AddTicks(790),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 48, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 789, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 46, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 782, DateTimeKind.Local).AddTicks(8087),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 40, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 780, DateTimeKind.Local).AddTicks(2244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 37, DateTimeKind.Local).AddTicks(2895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(1331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 7, 1, 35, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 35, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 770, DateTimeKind.Local).AddTicks(3842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 27, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 771, DateTimeKind.Local).AddTicks(8296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 28, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 766, DateTimeKind.Local).AddTicks(7813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 23, DateTimeKind.Local).AddTicks(4023));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Slides");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Slides",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 76, DateTimeKind.Local).AddTicks(1278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 816, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 66, DateTimeKind.Local).AddTicks(1873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 807, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 7, 1, 64, DateTimeKind.Local).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 64, DateTimeKind.Local).AddTicks(7801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 805, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 78, DateTimeKind.Local).AddTicks(327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 818, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 63, DateTimeKind.Local).AddTicks(1560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 804, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Slides",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 59, DateTimeKind.Local).AddTicks(3883),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 802, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 53, DateTimeKind.Local).AddTicks(1371),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 796, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 50, DateTimeKind.Local).AddTicks(7111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 793, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 44, DateTimeKind.Local).AddTicks(9105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 787, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 48, DateTimeKind.Local).AddTicks(3985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 791, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 46, DateTimeKind.Local).AddTicks(8766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 789, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 40, DateTimeKind.Local).AddTicks(1401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 782, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 37, DateTimeKind.Local).AddTicks(2895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 780, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 23, 13, 7, 1, 35, DateTimeKind.Local).AddTicks(2691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 23, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 35, DateTimeKind.Local).AddTicks(1396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 778, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 27, DateTimeKind.Local).AddTicks(3135),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 770, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 28, DateTimeKind.Local).AddTicks(7509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 771, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 21, 13, 7, 1, 23, DateTimeKind.Local).AddTicks(4023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 21, 13, 36, 31, 766, DateTimeKind.Local).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 90, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 90, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 92, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 92, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 92, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 21, 13, 7, 1, 91, DateTimeKind.Local).AddTicks(2941));
        }
    }
}
