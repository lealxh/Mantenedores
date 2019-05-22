using Microsoft.EntityFrameworkCore.Migrations;

namespace MantenedoresPerfilCliente.Persistence.Migrations
{
    public partial class addingUniversosColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_ARA",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_ARA",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_CRG",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_EFT",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_EFT",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_EPF",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_EPF",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_MVB",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_TPF",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_TPF",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_UNV",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_UNV",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TBL_PRF_MNT_UNV",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "UniversoId",
                table: "TBL_PRF_MNT_FTS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRF_MNT_FTS_UniversoId",
                table: "TBL_PRF_MNT_FTS",
                column: "UniversoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PRF_MNT_FTS_TBL_PRF_MNT_UNV_UniversoId",
                table: "TBL_PRF_MNT_FTS",
                column: "UniversoId",
                principalTable: "TBL_PRF_MNT_UNV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

              migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_ARA",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admision Riesgo" },
                    { 2, "Desarrollo Comercial" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_CRG",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Ejecutivo Comercial" },
                    { 2, "Agente Comercial" },
                    { 3, "Analista de Riesgo" },
                    { 4, "Jefe Deto." },
                    { 5, "Gerente de Riesgo" },
                    { 6, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_EFT",
                columns: new[] { "Id", "Cod", "Descripcion" },
                values: new object[,]
                {
                    { 1, "A", "Activo" },
                    { 2, "N", "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_EPF",
                columns: new[] { "Id", "Cod", "Descripcion" },
                values: new object[,]
                {
                    { 1, "A", "Activo" },
                    { 2, "N", "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_MVB",
                columns: new[] { "Id", "Descripcion", "TipoBloqueo" },
                values: new object[,]
                {
                    { 9, "Bloqueo 3", "Temporal" },
                    { 8, "Bloqueo 2", "Temporal" },
                    { 7, "Bloqueo 1", "Temporal" },
                    { 6, "Bloqueo Comercial", "Permanente" },
                    { 1, "Fraude(Titular-Relacionado)", "Permanente" },
                    { 4, "Cliente no desea recibir Ofertas", "Temporal" },
                    { 3, "Sector Economico", "Temporal" },
                    { 2, "Suficientemente atendido", "Temporal" },
                    { 5, "Bloqueo Duro de Riesgo", "Permanente" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_TPF",
                columns: new[] { "Id", "Cod", "Descripcion" },
                values: new object[,]
                {
                    { 1, "F", "Filtro" },
                    { 2, "F", "Filtro" }
                });

            migrationBuilder.InsertData(
                table: "TBL_PRF_MNT_UNV",
                columns: new[] { "Id", "Cod", "Descripcion" },
                values: new object[,]
                {
                    { 2, "N", "No Cliente" },
                    { 1, "C", "Cliente" },
                    { 3, "A", "Ambos" }
                });
      


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
