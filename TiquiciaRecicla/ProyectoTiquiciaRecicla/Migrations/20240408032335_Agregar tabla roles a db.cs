using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTiquiciaRecicla.Migrations
{
    /// <inheritdoc />
    public partial class Agregartablarolesadb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CH_Clave_2",
                table: "TBL_Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CAT_RolId",
                table: "TBL_Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CAT_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAT_RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAT_Roles_CAT_Roles_CAT_RolId",
                        column: x => x.CAT_RolId,
                        principalTable: "CAT_Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Usuarios_CAT_RolId",
                table: "TBL_Usuarios",
                column: "CAT_RolId");

            migrationBuilder.CreateIndex(
                name: "IX_CAT_Roles_CAT_RolId",
                table: "CAT_Roles",
                column: "CAT_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_Usuarios_CAT_Roles_CAT_RolId",
                table: "TBL_Usuarios",
                column: "CAT_RolId",
                principalTable: "CAT_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_Usuarios_CAT_Roles_CAT_RolId",
                table: "TBL_Usuarios");

            migrationBuilder.DropTable(
                name: "CAT_Roles");

            migrationBuilder.DropIndex(
                name: "IX_TBL_Usuarios_CAT_RolId",
                table: "TBL_Usuarios");

            migrationBuilder.DropColumn(
                name: "CAT_RolId",
                table: "TBL_Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "CH_Clave_2",
                table: "TBL_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
