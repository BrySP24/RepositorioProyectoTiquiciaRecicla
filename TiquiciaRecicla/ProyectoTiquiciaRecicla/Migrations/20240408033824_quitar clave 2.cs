using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTiquiciaRecicla.Migrations
{
    /// <inheritdoc />
#pragma warning disable IDE1006 // Estilos de nombres
    public partial class quitarclave2 : Migration
#pragma warning restore IDE1006 // Estilos de nombres
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CH_Clave_2",
                table: "TBL_Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CH_Clave_2",
                table: "TBL_Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
