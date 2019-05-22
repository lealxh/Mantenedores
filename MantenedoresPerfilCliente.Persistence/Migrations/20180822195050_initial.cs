using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MantenedoresPerfilCliente.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_ARA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_ARA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_CRG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_CRG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_EFT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cod = table.Column<string>(maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_EFT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_EPF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cod = table.Column<string>(maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_EPF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_MVB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    TipoBloqueo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_MVB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_TPF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cod = table.Column<string>(maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_TPF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_UNV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cod = table.Column<string>(maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_UNV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_EXC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(maxLength: 100, nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    CargoId = table.Column<int>(nullable: false),
                    MotivoBloqueoId = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 255, nullable: false),
                    Fechainicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_EXC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_EXC_TBL_PRF_MNT_ARA_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TBL_PRF_MNT_ARA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_EXC_TBL_PRF_MNT_CRG_CargoId",
                        column: x => x.CargoId,
                        principalTable: "TBL_PRF_MNT_CRG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_EXC_TBL_PRF_MNT_MVB_MotivoBloqueoId",
                        column: x => x.MotivoBloqueoId,
                        principalTable: "TBL_PRF_MNT_MVB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_PFS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 3, nullable: false),
                    PiMax = table.Column<double>(nullable: true),
                    EstadoPerfilId = table.Column<int>(nullable: false),
                    TipoPerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_PFS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_PFS_TBL_PRF_MNT_EPF_EstadoPerfilId",
                        column: x => x.EstadoPerfilId,
                        principalTable: "TBL_PRF_MNT_EPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_PFS_TBL_PRF_MNT_TPF_TipoPerfilId",
                        column: x => x.TipoPerfilId,
                        principalTable: "TBL_PRF_MNT_TPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRF_MNT_FTS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 255, nullable: false),
                    EstadoFiltroId = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Corte1 = table.Column<int>(nullable: true),
                    Corte2 = table.Column<int>(nullable: true),
                    Monto1 = table.Column<double>(nullable: true),
                    Monto2 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRF_MNT_FTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_FTS_TBL_PRF_MNT_EFT_EstadoFiltroId",
                        column: x => x.EstadoFiltroId,
                        principalTable: "TBL_PRF_MNT_EFT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_PRF_MNT_FTS_TBL_PRF_MNT_PFS_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "TBL_PRF_MNT_PFS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_EXC_AreaId",
                table: "TBL_PRF_MNT_EXC",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_EXC_CargoId",
                table: "TBL_PRF_MNT_EXC",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_EXC_MotivoBloqueoId",
                table: "TBL_PRF_MNT_EXC",
                column: "MotivoBloqueoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_FTS_EstadoFiltroId",
                table: "TBL_PRF_MNT_FTS",
                column: "EstadoFiltroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_FTS_Orden",
                table: "TBL_PRF_MNT_FTS",
                column: "Orden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_FTS_PerfilId",
                table: "TBL_PRF_MNT_FTS",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_PFS_EstadoPerfilId",
                table: "TBL_PRF_MNT_PFS",
                column: "EstadoPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_PFS_TipoPerfilId",
                table: "TBL_PRF_MNT_PFS",
                column: "TipoPerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_EXC");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_FTS");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_UNV");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_ARA");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_CRG");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_MVB");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_EFT");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_PFS");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_EPF");

            migrationBuilder.DropTable(
                name: "TBL_PRF_MNT_TPF");
        }
    }
}
