using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Commands;
using MantenedoresPerfilCliente.Application.Areas.Queries;
using MantenedoresPerfilCliente.Application.Cargos.Commands;
using MantenedoresPerfilCliente.Application.Cargos.Queries;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Commands;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Queries;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries;
using MantenedoresPerfilCliente.Application.Exclusiones.Commands;
using MantenedoresPerfilCliente.Application.Exclusiones.Queries;
using MantenedoresPerfilCliente.Application.Filtros.Commands;
using MantenedoresPerfilCliente.Application.Filtros.Queries;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries;
using MantenedoresPerfilCliente.Application.Perfiles.Commands;
using MantenedoresPerfilCliente.Application.Perfiles.Queries;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Commands;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Queries;
using MantenedoresPerfilCliente.Application.Universos.Commands;
using MantenedoresPerfilCliente.Application.Universos.Queries;
using MantenedoresPerfilCliente.Persistence.Repositories;
using MantenedoresPerfilCliente.Persistence.Shared;
using MantenedoresPerfilCliente.Presentation.ExceptionHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;


namespace MantenedoresPerfilCliente.Presentation
{
    public class Startup
		{
				public IConfiguration Configuration { get; }
				public Startup(IConfiguration configuration)
				{
						Configuration = configuration;
				}



				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{

				  services.Configure<IISOptions>(options => 
				  {
				    options.ForwardClientCertificate = false;
           
				  });

         
						services.AddDbContext<DatabaseContext>(options => options.
						UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
								b => b.MigrationsAssembly("MantenedoresPerfilCliente.Persistence")));



				  services.AddCors(options =>
				  {
				    options.AddPolicy("angularlocal" , builder =>
				      {
				        builder.AllowAnyOrigin()
				          .AllowAnyMethod()
				          .AllowAnyHeader();
				      });


				  });


				  services.AddAutoMapper();

					services.AddTransient<IUnityOfWork, UnityOfWork>();
				   services.AddTransient<IDatabaseContext, DatabaseContext>();
				  services.AddTransient<IFiltrosRepository, FiltrosRepository>();
			      services.AddTransient<IPerfilesRepository, PerfilesRepository>();
				  services.AddTransient<IExclusionesRepository, ExclusionesRepository>();
				  services.AddTransient<IAreasRepository, AreasRepository>();
				  services.AddTransient<ICargosRepository, CargosRepository>();
				  services.AddTransient<IEstadoFiltroRepository, EstadoFiltroRepository>();
				  services.AddTransient<IEstadoPerfilRepository, EstadoPerfilRepository>();
				  services.AddTransient<ITipoPerfilRepository, TipoPerfilRepository>();
				  services.AddTransient<IUniversoRepository, UniversoRepository>();
                 services.AddTransient<IMotivosBloqueoRepository, MotivosBloqueoRepository>();



					services.AddTransient<IInsertFiltro, InsertFiltro>();
					services.AddTransient<IUpdateFiltro, UpdateFiltro>();
					services.AddTransient<IDeleteFiltro, DeleteFiltro>();
					services.AddTransient<IListFiltros, ListFiltros>();
					services.AddTransient<IGetSingleFiltro, GetSingleFiltro>();
				  services.AddTransient<IValidateCodigoFiltro, ValidateCodigoFiltro>();
				  services.AddTransient<IValidateOrdenFiltro, ValidateOrdenFiltro>();
				  
				  

					services.AddTransient<IInsertPerfil, InsertPerfil>();
					services.AddTransient<IUpdatePerfil, UpdatePerfil>();
					services.AddTransient<IDeletePerfil, DeletePerfil>();
					services.AddTransient<IListPerfiles, ListPerfiles>();
					services.AddTransient<IGetSinglePerfil, GetSinglePerfil>();

				  services.AddTransient<IInsertExclusion, InsertExclusion>();
				  services.AddTransient<IUpdateExclusion, UpdateExclusion>();
				  services.AddTransient<IDeleteExclusion, DeleteExclusion>();
				  services.AddTransient<IListExclusiones, ListExclusiones>();
				  services.AddTransient<IGetSingleExclusion, GetSingleExclusion>();

				  services.AddTransient<IInsertArea, InsertArea>();
				  services.AddTransient<IUpdateArea, UpdateArea>();
				  services.AddTransient<IDeleteArea, DeleteArea>();
				  services.AddTransient<IListAreas, ListAreas>();
				  services.AddTransient<IGetSingleArea, GetSingleArea>();

				  services.AddTransient<IInsertCargo, InsertCargo>();
				  services.AddTransient<IUpdateCargo, UpdateCargo>();
				  services.AddTransient<IDeleteCargo, DeleteCargo>();
				  services.AddTransient<IListCargos, ListCargos>();
				  services.AddTransient<IGetSingleCargo, GetSingleCargo>();

				  services.AddTransient<IInsertEstadoFiltro, InsertEstadoFiltro>();
				  services.AddTransient<IUpdateEstadoFiltro, UpdateEstadoFiltro>();
				  services.AddTransient<IDeleteEstadoFiltro, DeleteEstadoFiltro>();
				  services.AddTransient<IListEstadoFiltros, ListEstadoFiltros>();
				  services.AddTransient<IGetSingleEstadoFiltro, GetSingleEstadoFiltro>();

				  services.AddTransient<IInsertEstadoPerfil, InsertEstadoPerfil>();
				  services.AddTransient<IUpdateEstadoPerfil, UpdateEstadoPerfil>();
				  services.AddTransient<IDeleteEstadoPerfil, DeleteEstadoPerfil>();
				  services.AddTransient<IListEstadoPerfiles, ListEstadoPerfiles>();
				  services.AddTransient<IGetSingleEstadoPerfiles, GetSingleEstadoPerfiles>();


				  services.AddTransient<IInsertTipoPerfil, InsertTipoPerfil>();
				  services.AddTransient<IUpdateTipoPerfil, UpdateTipoPerfil>();
				  services.AddTransient<IDeleteTipoPerfil, DeleteTipoPerfil>();
				  services.AddTransient<IListTipoPerfiles, ListTipoPerfiles>();
				  services.AddTransient<IGetSingleTipoPerfiles, GetSingleTipoPerfiles>();
				  services.AddTransient<IValidateCodigoPerfil, ValidateCodigoPerfil>();

          
				  services.AddTransient<IInsertUniverso, InsertUniverso>();
				  services.AddTransient<IUpdateUniverso, UpdateUniverso>();
				  services.AddTransient<IDeleteUniverso, DeleteUniverso>();
				  services.AddTransient<IListUniversos, ListUniversos>();
				  services.AddTransient<IGetSingleUniversos, GetSingleUniversos>();

      	          services.AddTransient<IInsertMotivoBloqueo, InsertMotivoBloqueo>();
				  services.AddTransient<IUpdateMotivoBloqueo, UpdateMotivoBloqueo>();
				  services.AddTransient<IDeleteMotivoBloqueo, DeleteMotivoBloqueo>();
				  services.AddTransient<IListMotivoBloqueos, ListMotivoBloqueos>();
				  services.AddTransient<IGetSingleMotivoBloqueos, GetSingleMotivoBloqueos>();


				  services.AddMvc();/*.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);*/

					services.AddSwaggerGen(c =>
					{
						c.SwaggerDoc("v1", new Info { Title = "Mantenedores API", Version = "v1" });
					});
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
						}
						else
						{
								app.UseHsts();
						}

				        app.UseCors("angularlocal");
					
						app.UseHttpsRedirection();
				        app.UseWebApiExceptionHandler();
						app.UseMvc();

						app.UseSwagger();
						app.UseSwaggerUI(c =>
						{
							c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
						});

                    //configurando el logging con el ApiGlobalExceptionHandlerExtension
					//loggerFactory.AddConsole();
					//loggerFactory.AddDebug(LogLevel.Information);

					//if (env.IsDevelopment())
					//{
					//	 app.UseWebApiExceptionHandler();
					//	//app.UseDeveloperExceptionPage();
					//}
					//else
					//{
					//	app.UseWebApiExceptionHandler();
					//}





				}
		}
}
