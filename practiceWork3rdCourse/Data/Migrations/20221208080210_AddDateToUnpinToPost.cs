using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceWork3rdCourse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToUnpinToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateToUnpin",
                table: "Posts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateToUnpin",
                table: "Posts");
        }
    }
}
