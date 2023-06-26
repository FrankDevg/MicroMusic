using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroBroker.Playlist.Infraestructure.Migrations.PlaylistSongDb
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Playlist_Song",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Playlist = table.Column<int>(type: "int", nullable: false),
                    Id_Song = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Playlist_Song", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Playlist_Song");
        }
    }
}
