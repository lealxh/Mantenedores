using Microsoft.EntityFrameworkCore.Migrations;

namespace MantenedoresPerfilCliente.Persistence.Migrations
{
    public partial class Precarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_ARA] ON ");

            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_ARA] ([Id], [Nombre]) VALUES (1, N'Desarrollo Comercial')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_ARA] ([Id], [Nombre]) VALUES (2, N'Admision de Riesgo')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_ARA] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_CRG] ON"); 

            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (1, N'Ejecutivo Comercial')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (2, N'Agente Comercial')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (3, N'Analista de Riesgo')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (4, N'Jefe Deto.')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (5, N'Gerente de Riesgo')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_CRG] ([Id], [Descripcion]) VALUES (6, N'Otro')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_CRG] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_MVB] ON"); 
            
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (1, N'Fraude (Titular-Relacionado)', N'Permanente')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (2, N'Suficientemente Atendido', N'Temporal')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (3, N'Sector Económico', N'Temporal')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (4, N'Cliente no desea recibir Ofertas', N'Temporal')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (5, N'Bloqueo Duro de Riesgo', N'Permanente')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_MVB] ([Id], [Descripcion], [TipoBloqueo]) VALUES (6, N'Bloqueo Comercial', N'Permanente')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_MVB] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_EPF] ON"); 
            
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_EPF] ([Id], [Cod], [Descripcion]) VALUES (1, N'A', N'Activo')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_EPF] ([Id], [Cod], [Descripcion]) VALUES (2, N'N', N'Inactivo')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_EPF] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_TPF] ON"); 

            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_TPF] ([Id], [Cod], [Descripcion]) VALUES (1, N'F', N'Filtro')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_TPF] ([Id], [Cod], [Descripcion]) VALUES (2, N'M', N'Modelo')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_TPF] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_EFT] ON"); 

            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_EFT] ([Id], [Cod], [Descripcion]) VALUES (1, N'A', N'Activo')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_EFT] ([Id], [Cod], [Descripcion]) VALUES (2, N'N', N'Inactivo')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_EFT] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_UNV] ON"); 

            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_UNV] ([Id], [Cod], [Descripcion]) VALUES (1, N'C', N'Clientes')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_UNV] ([Id], [Cod], [Descripcion]) VALUES (2, N'N', N'No Clientes')");
            migrationBuilder.Sql("INSERT [dbo].[TBL_PRF_MNT_UNV] ([Id], [Cod], [Descripcion]) VALUES (3, N'A', N'Ambos')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[TBL_PRF_MNT_UNV] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
