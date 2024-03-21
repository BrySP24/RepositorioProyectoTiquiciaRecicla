using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTiquiciaRecicla.Migrations
{
    /// <inheritdoc />
    public partial class AgregartablasaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAT_Empresas_Recolectoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEC_Latitud = table.Column<double>(type: "float", nullable: false),
                    DEC_Longitud = table.Column<double>(type: "float", nullable: false),
                    CH_Horario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Telefono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CH_Correo_Electronico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Empresas_Recolectoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAT_Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAT_Tipos_De_Materiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CH_Tratamiento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Tipos_De_Materiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAT_Centros_De_Acopio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEC_Latitud = table.Column<double>(type: "float", nullable: false),
                    DEC_Longitud = table.Column<double>(type: "float", nullable: false),
                    CH_Horario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Telefono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CH_Correo_Electronico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAT_Empresa_RecolectoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Centros_De_Acopio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAT_Centros_De_Acopio_CAT_Empresas_Recolectoras_CAT_Empresa_RecolectoraId",
                        column: x => x.CAT_Empresa_RecolectoraId,
                        principalTable: "CAT_Empresas_Recolectoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CH_Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DTI_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTI_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CH_Premio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CAT_Empresa_RecolectoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Eventos_CAT_Empresas_Recolectoras_CAT_Empresa_RecolectoraId",
                        column: x => x.CAT_Empresa_RecolectoraId,
                        principalTable: "CAT_Empresas_Recolectoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Apellido_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_apellido_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CH_Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CH_Telefono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CH_Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CAT_ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Usuarios_CAT_Provincias_CAT_ProvinciaId",
                        column: x => x.CAT_ProvinciaId,
                        principalTable: "CAT_Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAT_Centros_Materiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_Tipo_De_MaterialId = table.Column<int>(type: "int", nullable: false),
                    CAT_Centro_De_AcopioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAT_Centros_Materiales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAT_Centros_Materiales_CAT_Centros_De_Acopio_CAT_Centro_De_AcopioId",
                        column: x => x.CAT_Centro_De_AcopioId,
                        principalTable: "CAT_Centros_De_Acopio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAT_Centros_Materiales_CAT_Tipos_De_Materiales_CAT_Tipo_De_MaterialId",
                        column: x => x.CAT_Tipo_De_MaterialId,
                        principalTable: "CAT_Tipos_De_Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Titulo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IMG_Banner = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CH_Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CAT_Centro_De_AcopioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Anuncios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Anuncios_CAT_Centros_De_Acopio_CAT_Centro_De_AcopioId",
                        column: x => x.CAT_Centro_De_AcopioId,
                        principalTable: "CAT_Centros_De_Acopio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Zonas_de_Recolecta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CH_Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEC_Latitud = table.Column<double>(type: "float", nullable: false),
                    DEC_Longitud = table.Column<double>(type: "float", nullable: false),
                    DTI_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTI_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CH_Horario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAT_Centro_De_AcopioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Zonas_de_Recolecta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Zonas_de_Recolecta_CAT_Centros_De_Acopio_CAT_Centro_De_AcopioId",
                        column: x => x.CAT_Centro_De_AcopioId,
                        principalTable: "CAT_Centros_De_Acopio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Historicos_Sesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTI_Fecha_Hora_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DIT_Fecha_Hora_Cierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TBL_UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Historicos_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Historicos_Sesiones_TBL_Usuarios_TBL_UsuarioId",
                        column: x => x.TBL_UsuarioId,
                        principalTable: "TBL_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Recibos_De_Reciclaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTI_Fecha_Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DEC_Peso = table.Column<float>(type: "real", nullable: false),
                    CAT_Tipo_De_MaterialId = table.Column<int>(type: "int", nullable: false),
                    CAT_Centro_De_AcopioId = table.Column<int>(type: "int", nullable: false),
                    TBL_UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Recibos_De_Reciclaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_Recibos_De_Reciclaje_CAT_Centros_De_Acopio_CAT_Centro_De_AcopioId",
                        column: x => x.CAT_Centro_De_AcopioId,
                        principalTable: "CAT_Centros_De_Acopio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_Recibos_De_Reciclaje_CAT_Tipos_De_Materiales_CAT_Tipo_De_MaterialId",
                        column: x => x.CAT_Tipo_De_MaterialId,
                        principalTable: "CAT_Tipos_De_Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_Recibos_De_Reciclaje_TBL_Usuarios_TBL_UsuarioId",
                        column: x => x.TBL_UsuarioId,
                        principalTable: "TBL_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAT_Centros_De_Acopio_CAT_Empresa_RecolectoraId",
                table: "CAT_Centros_De_Acopio",
                column: "CAT_Empresa_RecolectoraId");

            migrationBuilder.CreateIndex(
                name: "IX_CAT_Centros_Materiales_CAT_Centro_De_AcopioId",
                table: "CAT_Centros_Materiales",
                column: "CAT_Centro_De_AcopioId");

            migrationBuilder.CreateIndex(
                name: "IX_CAT_Centros_Materiales_CAT_Tipo_De_MaterialId",
                table: "CAT_Centros_Materiales",
                column: "CAT_Tipo_De_MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Anuncios_CAT_Centro_De_AcopioId",
                table: "TBL_Anuncios",
                column: "CAT_Centro_De_AcopioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Eventos_CAT_Empresa_RecolectoraId",
                table: "TBL_Eventos",
                column: "CAT_Empresa_RecolectoraId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Historicos_Sesiones_TBL_UsuarioId",
                table: "TBL_Historicos_Sesiones",
                column: "TBL_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Recibos_De_Reciclaje_CAT_Centro_De_AcopioId",
                table: "TBL_Recibos_De_Reciclaje",
                column: "CAT_Centro_De_AcopioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Recibos_De_Reciclaje_CAT_Tipo_De_MaterialId",
                table: "TBL_Recibos_De_Reciclaje",
                column: "CAT_Tipo_De_MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Recibos_De_Reciclaje_TBL_UsuarioId",
                table: "TBL_Recibos_De_Reciclaje",
                column: "TBL_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Usuarios_CAT_ProvinciaId",
                table: "TBL_Usuarios",
                column: "CAT_ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Zonas_de_Recolecta_CAT_Centro_De_AcopioId",
                table: "TBL_Zonas_de_Recolecta",
                column: "CAT_Centro_De_AcopioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAT_Centros_Materiales");

            migrationBuilder.DropTable(
                name: "TBL_Anuncios");

            migrationBuilder.DropTable(
                name: "TBL_Eventos");

            migrationBuilder.DropTable(
                name: "TBL_Historicos_Sesiones");

            migrationBuilder.DropTable(
                name: "TBL_Recibos_De_Reciclaje");

            migrationBuilder.DropTable(
                name: "TBL_Zonas_de_Recolecta");

            migrationBuilder.DropTable(
                name: "CAT_Tipos_De_Materiales");

            migrationBuilder.DropTable(
                name: "TBL_Usuarios");

            migrationBuilder.DropTable(
                name: "CAT_Centros_De_Acopio");

            migrationBuilder.DropTable(
                name: "CAT_Provincias");

            migrationBuilder.DropTable(
                name: "CAT_Empresas_Recolectoras");
        }
    }
}
