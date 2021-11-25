using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddOrderOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 299, DateTimeKind.Local).AddTicks(8041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 660, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 290, DateTimeKind.Local).AddTicks(2287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 649, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 289, DateTimeKind.Local).AddTicks(67),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 288, DateTimeKind.Local).AddTicks(7768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 300, DateTimeKind.Local).AddTicks(8209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 661, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 287, DateTimeKind.Local).AddTicks(8955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 647, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 286, DateTimeKind.Local).AddTicks(5046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 645, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 285, DateTimeKind.Local).AddTicks(7763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 644, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 284, DateTimeKind.Local).AddTicks(7480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 643, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 280, DateTimeKind.Local).AddTicks(1571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 638, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 283, DateTimeKind.Local).AddTicks(5299),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 642, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 282, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 641, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 276, DateTimeKind.Local).AddTicks(6351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 634, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 273, DateTimeKind.Local).AddTicks(3290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 630, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 274, DateTimeKind.Local).AddTicks(9034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 632, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.AddColumn<int>(
                name: "ColorOptionId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeOptionId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 298, DateTimeKind.Local).AddTicks(6857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 658, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 271, DateTimeKind.Local).AddTicks(4312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 628, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 269, DateTimeKind.Local).AddTicks(685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 626, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 263, DateTimeKind.Local).AddTicks(1417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 619, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 264, DateTimeKind.Local).AddTicks(5715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 621, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 260, DateTimeKind.Local).AddTicks(4885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 616, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 306, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 306, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38fc78cd-9722-4027-ba59-5f60ee12e5a7"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fca74d71-b4b1-418b-8197-b452299ddca4"),
                column: "DateCreated",
                value: new DateTime(2021, 9, 22, 14, 33, 36, 307, DateTimeKind.Local).AddTicks(2788));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ColorOptionId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "SizeOptionId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 660, DateTimeKind.Local).AddTicks(2251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 299, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 649, DateTimeKind.Local).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 290, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(2979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 289, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 648, DateTimeKind.Local).AddTicks(396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 288, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 661, DateTimeKind.Local).AddTicks(3250),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 300, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 647, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 287, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 645, DateTimeKind.Local).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 286, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 644, DateTimeKind.Local).AddTicks(9154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 285, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 643, DateTimeKind.Local).AddTicks(7943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 284, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 638, DateTimeKind.Local).AddTicks(9754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 280, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 642, DateTimeKind.Local).AddTicks(6935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 283, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 641, DateTimeKind.Local).AddTicks(372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 282, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 634, DateTimeKind.Local).AddTicks(5415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 276, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 630, DateTimeKind.Local).AddTicks(9347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 273, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 632, DateTimeKind.Local).AddTicks(6670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 274, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 658, DateTimeKind.Local).AddTicks(9969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 298, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 628, DateTimeKind.Local).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 271, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 23, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 627, DateTimeKind.Local).AddTicks(6089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 626, DateTimeKind.Local).AddTicks(3515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 269, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 619, DateTimeKind.Local).AddTicks(6991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 263, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 621, DateTimeKind.Local).AddTicks(3896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 264, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 21, 10, 52, 45, 616, DateTimeKind.Local).AddTicks(8373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 260, DateTimeKind.Local).AddTicks(4885));

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
    }
}
