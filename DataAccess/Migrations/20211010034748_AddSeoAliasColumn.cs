using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddSeoAliasColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 435, DateTimeKind.Local).AddTicks(5507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 709, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 425, DateTimeKind.Local).AddTicks(6952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 694, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(4263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 693, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(3038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 692, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Tags",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 437, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 712, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 422, DateTimeKind.Local).AddTicks(7766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 690, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Slides",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 419, DateTimeKind.Local).AddTicks(2789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 686, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 418, DateTimeKind.Local).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 682, DateTimeKind.Local).AddTicks(2272));

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
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 416, DateTimeKind.Local).AddTicks(3734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 679, DateTimeKind.Local).AddTicks(7636));

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
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 410, DateTimeKind.Local).AddTicks(6788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 672, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 414, DateTimeKind.Local).AddTicks(1543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 676, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 412, DateTimeKind.Local).AddTicks(5826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 674, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 667, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "PostReviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "PostComments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 662, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 406, DateTimeKind.Local).AddTicks(673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 664, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 707, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Options",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Menus",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 402, DateTimeKind.Local).AddTicks(7749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 659, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 657, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(6466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 656, DateTimeKind.Local).AddTicks(8585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 653, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 392, DateTimeKind.Local).AddTicks(8319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 644, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 394, DateTimeKind.Local).AddTicks(3216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 646, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 389, DateTimeKind.Local).AddTicks(1979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 638, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Brands",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "PostReviews");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Brands");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 709, DateTimeKind.Local).AddTicks(3174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 435, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 694, DateTimeKind.Local).AddTicks(9423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 425, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 693, DateTimeKind.Local).AddTicks(1472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 692, DateTimeKind.Local).AddTicks(9875),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 424, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 712, DateTimeKind.Local).AddTicks(247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 437, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 690, DateTimeKind.Local).AddTicks(9552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 422, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 686, DateTimeKind.Local).AddTicks(2863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 419, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 682, DateTimeKind.Local).AddTicks(2272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 418, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 679, DateTimeKind.Local).AddTicks(7636),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 416, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 672, DateTimeKind.Local).AddTicks(1704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 410, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 676, DateTimeKind.Local).AddTicks(9801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 414, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 674, DateTimeKind.Local).AddTicks(9245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 412, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 667, DateTimeKind.Local).AddTicks(6675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 662, DateTimeKind.Local).AddTicks(4105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 664, DateTimeKind.Local).AddTicks(7534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 406, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 707, DateTimeKind.Local).AddTicks(2662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 659, DateTimeKind.Local).AddTicks(8095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 402, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 10, 23, 31, 42, 657, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 12, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 656, DateTimeKind.Local).AddTicks(8585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 400, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 653, DateTimeKind.Local).AddTicks(8213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 644, DateTimeKind.Local).AddTicks(620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 392, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 646, DateTimeKind.Local).AddTicks(905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 394, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 8, 23, 31, 42, 638, DateTimeKind.Local).AddTicks(6604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 10, 10, 47, 47, 389, DateTimeKind.Local).AddTicks(1979));

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
    }
}
