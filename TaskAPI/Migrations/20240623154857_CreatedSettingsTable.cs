using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAPI.Migrations
{
    public partial class CreatedSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Socials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Instructors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Informations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(8920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(556))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1391), "Location", "123 Street, New York, USA" },
                    { 2, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1392), "Phone", "+012 345 67890" },
                    { 3, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1393), "Email", "info@example.com" },
                    { 4, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1393), "Logo", "fa fa-book me-3" },
                    { 5, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1394), "Twitter", "twitter.com" },
                    { 6, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1395), "Facebook", "facebook.com" },
                    { 7, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1395), "Youtube", "youtube.com" },
                    { 8, new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1396), "Linkedin", "linkedin.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(8278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Socials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(8003),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Sliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Instructors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Informations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 823, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(7044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6774),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 23, 19, 26, 38, 79, DateTimeKind.Local).AddTicks(6281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 23, 19, 48, 57, 822, DateTimeKind.Local).AddTicks(8920));
        }
    }
}
