using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTiquiciaRecicla.Migrations
{
    /// <inheritdoc />
    public partial class AgregarlacolumnaCH_Clave_2aTBL_Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CH_Clave_2",
                table: "TBL_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CH_Titulo",
                table: "TBL_Anuncios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CH_Clave_2",
                table: "TBL_Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "CH_Titulo",
                table: "TBL_Anuncios",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
