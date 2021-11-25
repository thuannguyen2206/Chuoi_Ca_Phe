using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddIsAdminColumnInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 770, DateTimeKind.Local).AddTicks(182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 418, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 759, DateTimeKind.Local).AddTicks(3037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 407, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(6073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(3535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 772, DateTimeKind.Local).AddTicks(2715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 420, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 755, DateTimeKind.Local).AddTicks(4382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 404, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 751, DateTimeKind.Local).AddTicks(3915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(8614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 750, DateTimeKind.Local).AddTicks(3701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 748, DateTimeKind.Local).AddTicks(3317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 398, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 741, DateTimeKind.Local).AddTicks(5613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 392, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 745, DateTimeKind.Local).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 395, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 743, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 394, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 737, DateTimeKind.Local).AddTicks(8950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 388, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 734, DateTimeKind.Local).AddTicks(4219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 385, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 736, DateTimeKind.Local).AddTicks(851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 387, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 768, DateTimeKind.Local).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 416, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 732, DateTimeKind.Local).AddTicks(5317),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 383, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(5350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 728, DateTimeKind.Local).AddTicks(3192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 379, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 721, DateTimeKind.Local).AddTicks(9354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 373, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 723, DateTimeKind.Local).AddTicks(4204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 374, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 719, DateTimeKind.Local).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 370, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 783, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 783, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 785, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 30, 16, 26, 8, 784, DateTimeKind.Local).AddTicks(5608));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 418, DateTimeKind.Local).AddTicks(376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 770, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 407, DateTimeKind.Local).AddTicks(8687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 759, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(4648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 757, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 420, DateTimeKind.Local).AddTicks(1618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 772, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 404, DateTimeKind.Local).AddTicks(5958),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 755, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(8614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 751, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(1110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 750, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 398, DateTimeKind.Local).AddTicks(79),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 748, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 392, DateTimeKind.Local).AddTicks(3722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 741, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 395, DateTimeKind.Local).AddTicks(7765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 745, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 394, DateTimeKind.Local).AddTicks(2819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 743, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 388, DateTimeKind.Local).AddTicks(7314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 737, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 385, DateTimeKind.Local).AddTicks(4241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 734, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 387, DateTimeKind.Local).AddTicks(137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 736, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 416, DateTimeKind.Local).AddTicks(3325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 768, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 383, DateTimeKind.Local).AddTicks(5417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 732, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(3573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(2432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 730, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 379, DateTimeKind.Local).AddTicks(2499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 728, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 373, DateTimeKind.Local).AddTicks(2730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 721, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 374, DateTimeKind.Local).AddTicks(7798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 723, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 370, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 16, 26, 8, 719, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(5554));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 430, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 430, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 28, 23, 0, 51, 431, DateTimeKind.Local).AddTicks(9151));
        }
    }
}
