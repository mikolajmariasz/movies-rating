using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movies_rating.Migrations
{
    /// <inheritdoc />
    public partial class MakeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PosterImageContentType",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PosterImageData",
                table: "Movies",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosterImageContentType",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PosterImageData",
                table: "Movies");
        }
    }
}
