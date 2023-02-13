using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetupUpdate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepeatUpdateMinutes = table.Column<short>(type: "smallint", nullable: false),
                    ClearDLLTableMinutes = table.Column<short>(type: "smallint", nullable: false),
                    DLLServerPath = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    OtherServerPath = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdateObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileType = table.Column<short>(type: "smallint", nullable: false),
                    FileVersion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AssemblyType = table.Column<short>(type: "smallint", nullable: false),
                    UpdateFile = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateObjects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetupUpdate");

            migrationBuilder.DropTable(
                name: "UpdateObjects");
        }
    }
}
