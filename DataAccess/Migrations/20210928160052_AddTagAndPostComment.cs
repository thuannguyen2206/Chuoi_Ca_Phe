using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddTagAndPostComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 418, DateTimeKind.Local).AddTicks(376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 299, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 407, DateTimeKind.Local).AddTicks(8687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 290, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(4648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 289, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(2390),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 288, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 420, DateTimeKind.Local).AddTicks(1618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 300, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 404, DateTimeKind.Local).AddTicks(5958),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 287, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(8614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 286, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(1110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 285, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 398, DateTimeKind.Local).AddTicks(79),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 284, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 392, DateTimeKind.Local).AddTicks(3722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 280, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 395, DateTimeKind.Local).AddTicks(7765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 283, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 394, DateTimeKind.Local).AddTicks(2819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 282, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 388, DateTimeKind.Local).AddTicks(7314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 276, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 385, DateTimeKind.Local).AddTicks(4241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 273, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 387, DateTimeKind.Local).AddTicks(137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 274, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 416, DateTimeKind.Local).AddTicks(3325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 298, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 383, DateTimeKind.Local).AddTicks(5417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 271, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(3573),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(2432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 379, DateTimeKind.Local).AddTicks(2499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 269, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 373, DateTimeKind.Local).AddTicks(2730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 263, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 374, DateTimeKind.Local).AddTicks(7798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 264, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 370, DateTimeKind.Local).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 260, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ReplyFor = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_PostReviews_PostId",
                        column: x => x.PostId,
                        principalTable: "PostReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagInPosts",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagInPosts", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagInPosts_PostReviews_PostId",
                        column: x => x.PostId,
                        principalTable: "PostReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagInPosts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagInProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagInProducts", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagInProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagInProducts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsActive", "TagName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6002), null, true, "Clothing" },
                    { 3, new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6554), null, true, "Fashion" },
                    { 2, new DateTime(2021, 9, 28, 23, 0, 51, 432, DateTimeKind.Local).AddTicks(6534), null, true, "Accessories" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_TagInPosts_TagId",
                table: "TagInPosts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagInProducts_TagId",
                table: "TagInProducts",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "TagInPosts");

            migrationBuilder.DropTable(
                name: "TagInProducts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "WishLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 299, DateTimeKind.Local).AddTicks(8041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 418, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 290, DateTimeKind.Local).AddTicks(2287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 407, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 289, DateTimeKind.Local).AddTicks(67),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TokenConfirm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 288, DateTimeKind.Local).AddTicks(7768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 406, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StoreLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 300, DateTimeKind.Local).AddTicks(8209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 420, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Slides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 287, DateTimeKind.Local).AddTicks(8955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 404, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 286, DateTimeKind.Local).AddTicks(5046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(8614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Ratings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 285, DateTimeKind.Local).AddTicks(7763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 400, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 284, DateTimeKind.Local).AddTicks(7480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 398, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 280, DateTimeKind.Local).AddTicks(1571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 392, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 283, DateTimeKind.Local).AddTicks(5299),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 395, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ProductDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 282, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 394, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PostReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 276, DateTimeKind.Local).AddTicks(6351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 388, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 273, DateTimeKind.Local).AddTicks(3290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 385, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 274, DateTimeKind.Local).AddTicks(9034),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 387, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 298, DateTimeKind.Local).AddTicks(6857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 416, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 271, DateTimeKind.Local).AddTicks(4312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 383, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 30, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CodeResets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 270, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 381, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 269, DateTimeKind.Local).AddTicks(685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 379, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 263, DateTimeKind.Local).AddTicks(1417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 373, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 264, DateTimeKind.Local).AddTicks(5715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 374, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 22, 14, 33, 36, 260, DateTimeKind.Local).AddTicks(4885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 28, 23, 0, 51, 370, DateTimeKind.Local).AddTicks(5502));

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
    }
}
