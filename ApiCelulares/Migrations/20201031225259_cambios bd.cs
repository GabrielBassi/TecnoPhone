using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCelulares.Migrations
{
    public partial class cambiosbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "MarcaCelulars",
                columns: table => new
                {
                    MarcaCelularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaCelulars", x => x.MarcaCelularId);
                });

            migrationBuilder.CreateTable(
                name: "MarcaPcs",
                columns: table => new
                {
                    MarcaPcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaPcs", x => x.MarcaPcId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedors",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedors", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "ModeloCelulars",
                columns: table => new
                {
                    ModeloCelularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaCelularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloCelulars", x => x.ModeloCelularId);
                    table.ForeignKey(
                        name: "FK_ModeloCelulars_MarcaCelulars_MarcaCelularId",
                        column: x => x.MarcaCelularId,
                        principalTable: "MarcaCelulars",
                        principalColumn: "MarcaCelularId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModeloPcs",
                columns: table => new
                {
                    ModeloPcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaPcId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloPcs", x => x.ModeloPcId);
                    table.ForeignKey(
                        name: "FK_ModeloPcs_MarcaPcs_MarcaPcId",
                        column: x => x.MarcaPcId,
                        principalTable: "MarcaPcs",
                        principalColumn: "MarcaPcId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    montoPago = table.Column<double>(type: "float", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Celulars",
                columns: table => new
                {
                    CelularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chip = table.Column<bool>(type: "bit", nullable: false),
                    tarjetaSd = table.Column<bool>(type: "bit", nullable: false),
                    enciende = table.Column<bool>(type: "bit", nullable: false),
                    diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pin = table.Column<int>(type: "int", nullable: false),
                    patron = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeloCelularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulars", x => x.CelularId);
                    table.ForeignKey(
                        name: "FK_Celulars_ModeloCelulars_ModeloCelularId",
                        column: x => x.ModeloCelularId,
                        principalTable: "ModeloCelulars",
                        principalColumn: "ModeloCelularId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    PcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeloPcId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.PcId);
                    table.ForeignKey(
                        name: "FK_Pcs_ModeloPcs_ModeloPcId",
                        column: x => x.ModeloPcId,
                        principalTable: "ModeloPcs",
                        principalColumn: "ModeloPcId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoEquipos",
                columns: table => new
                {
                    TipoEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularId = table.Column<int>(type: "int", nullable: true),
                    PcId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipos", x => x.TipoEquipoId);
                    table.ForeignKey(
                        name: "FK_TipoEquipos_Celulars_CelularId",
                        column: x => x.CelularId,
                        principalTable: "Celulars",
                        principalColumn: "CelularId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoEquipos_Pcs_PcId",
                        column: x => x.PcId,
                        principalTable: "Pcs",
                        principalColumn: "PcId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeReparacions",
                columns: table => new
                {
                    OrdenDeReparacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    estadoReparacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detalleReparacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEquipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeReparacions", x => x.OrdenDeReparacionId);
                    table.ForeignKey(
                        name: "FK_OrdenDeReparacions_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenDeReparacions_TipoEquipos_TipoEquipoId",
                        column: x => x.TipoEquipoId,
                        principalTable: "TipoEquipos",
                        principalColumn: "TipoEquipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioCompra = table.Column<double>(type: "float", nullable: false),
                    precioVenta = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<double>(type: "float", nullable: false),
                    stockMinimo = table.Column<double>(type: "float", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    OrdenDeReparacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_OrdenDeReparacions_OrdenDeReparacionId",
                        column: x => x.OrdenDeReparacionId,
                        principalTable: "OrdenDeReparacions",
                        principalColumn: "OrdenDeReparacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedors_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedors",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaVentas",
                columns: table => new
                {
                    LineaVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    descuento = table.Column<double>(type: "float", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    OrdenDeReparacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaVentas", x => x.LineaVentaId);
                    table.ForeignKey(
                        name: "FK_LineaVentas_OrdenDeReparacions_OrdenDeReparacionId",
                        column: x => x.OrdenDeReparacionId,
                        principalTable: "OrdenDeReparacions",
                        principalColumn: "OrdenDeReparacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineaVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineaVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celulars_ModeloCelularId",
                table: "Celulars",
                column: "ModeloCelularId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaVentas_OrdenDeReparacionId",
                table: "LineaVentas",
                column: "OrdenDeReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaVentas_ProductoId",
                table: "LineaVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaVentas_VentaId",
                table: "LineaVentas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloCelulars_MarcaCelularId",
                table: "ModeloCelulars",
                column: "MarcaCelularId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloPcs_MarcaPcId",
                table: "ModeloPcs",
                column: "MarcaPcId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeReparacions_ClienteId",
                table: "OrdenDeReparacions",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeReparacions_TipoEquipoId",
                table: "OrdenDeReparacions",
                column: "TipoEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_VentaId",
                table: "Pagos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_ModeloPcId",
                table: "Pcs",
                column: "ModeloPcId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_OrdenDeReparacionId",
                table: "Productos",
                column: "OrdenDeReparacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEquipos_CelularId",
                table: "TipoEquipos",
                column: "CelularId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEquipos_PcId",
                table: "TipoEquipos",
                column: "PcId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaVentas");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "OrdenDeReparacions");

            migrationBuilder.DropTable(
                name: "Proveedors");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoEquipos");

            migrationBuilder.DropTable(
                name: "Celulars");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "ModeloCelulars");

            migrationBuilder.DropTable(
                name: "ModeloPcs");

            migrationBuilder.DropTable(
                name: "MarcaCelulars");

            migrationBuilder.DropTable(
                name: "MarcaPcs");
        }
    }
}
