using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdatePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PostReviews");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "PostReviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 194, DateTimeKind.Local).AddTicks(6036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 101, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 183, DateTimeKind.Local).AddTicks(5632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 88, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 2, 21, 48, 53, 182, DateTimeKind.Local).AddTicks(3060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 182, DateTimeKind.Local).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 196, DateTimeKind.Local).AddTicks(5472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 104, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 180, DateTimeKind.Local).AddTicks(4042),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 83, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 178, DateTimeKind.Local).AddTicks(3241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 80, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 170, DateTimeKind.Local).AddTicks(3856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 72, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 165, DateTimeKind.Local).AddTicks(3122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 64, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 167, DateTimeKind.Local).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 67, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "PostReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PostComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 162, DateTimeKind.Local).AddTicks(671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 58, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 159, DateTimeKind.Local).AddTicks(4389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 55, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 2, 21, 48, 53, 157, DateTimeKind.Local).AddTicks(4181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 157, DateTimeKind.Local).AddTicks(3013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 151, DateTimeKind.Local).AddTicks(122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 43, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 146, DateTimeKind.Local).AddTicks(2004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 38, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 208, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 208, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 210, DateTimeKind.Local).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 209, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 10, 31, 21, 48, 53, 209, DateTimeKind.Local).AddTicks(4323));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "PostReviews");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PostComments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 101, DateTimeKind.Local).AddTicks(9019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 194, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 88, DateTimeKind.Local).AddTicks(529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 183, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(2918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 2, 21, 48, 53, 182, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 86, DateTimeKind.Local).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 182, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 104, DateTimeKind.Local).AddTicks(6829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 196, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 83, DateTimeKind.Local).AddTicks(6638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 180, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 80, DateTimeKind.Local).AddTicks(8890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 178, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 72, DateTimeKind.Local).AddTicks(3339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 170, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 64, DateTimeKind.Local).AddTicks(6802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 165, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 67, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 167, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PostReviews",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "PostReviews",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 58, DateTimeKind.Local).AddTicks(4964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 162, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 55, DateTimeKind.Local).AddTicks(422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 159, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 29, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 2, 21, 48, 53, 157, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 52, DateTimeKind.Local).AddTicks(543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 157, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 43, DateTimeKind.Local).AddTicks(9457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 151, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 27, 15, 26, 43, 38, DateTimeKind.Local).AddTicks(2579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 31, 21, 48, 53, 146, DateTimeKind.Local).AddTicks(2004));

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
    }
}
