using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddOriginalPriceToOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 101, DateTimeKind.Local).AddTicks(9019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 35, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 88, DateTimeKind.Local).AddTicks(529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 26, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.AddColumn<string>(
                name: "ExternalProvider",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(2918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 104, DateTimeKind.Local).AddTicks(6829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 37, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 83, DateTimeKind.Local).AddTicks(6638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 23, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 80, DateTimeKind.Local).AddTicks(8890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 21, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 72, DateTimeKind.Local).AddTicks(3339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 13, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 64, DateTimeKind.Local).AddTicks(6802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 8, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 67, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 10, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 58, DateTimeKind.Local).AddTicks(4964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 3, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 55, DateTimeKind.Local).AddTicks(422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 1, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 43, DateTimeKind.Local).AddTicks(9457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 993, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 38, DateTimeKind.Local).AddTicks(2579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 988, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 120, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 120, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 27, 15, 26, 43, 122, DateTimeKind.Local).AddTicks(1085));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalProvider",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 35, DateTimeKind.Local).AddTicks(9691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 101, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 26, DateTimeKind.Local).AddTicks(7821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 88, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(5113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 25, DateTimeKind.Local).AddTicks(3932),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 37, DateTimeKind.Local).AddTicks(9106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 104, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 23, DateTimeKind.Local).AddTicks(8335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 83, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 21, DateTimeKind.Local).AddTicks(6446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 80, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 13, DateTimeKind.Local).AddTicks(8982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 72, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 8, DateTimeKind.Local).AddTicks(6642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 64, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 10, DateTimeKind.Local).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 67, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 3, DateTimeKind.Local).AddTicks(8723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 58, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 9, 1, DateTimeKind.Local).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 55, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(4701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 999, DateTimeKind.Local).AddTicks(3533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 993, DateTimeKind.Local).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 43, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 25, 13, 11, 8, 988, DateTimeKind.Local).AddTicks(5130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 38, DateTimeKind.Local).AddTicks(2579));

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
    }
}
