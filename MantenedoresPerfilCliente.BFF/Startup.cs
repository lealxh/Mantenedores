using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace MantenedoresPerfilCliente.BFF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddHttpClient();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            
            var symmetricKey = System.Convert.FromBase64String(Configuration["JWTAuthConfig:symetricKey"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie().AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = false,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = Configuration["JWTAuthConfig:validIssuer"],
                    ValidAudience = Configuration["JWTAuthConfig:validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    SaveSigninToken = true

                };
            });
            services.AddSwaggerGen(c =>
		    {
				c.SwaggerDoc("v1", new Info { Title = "Mantenedores API", Version = "v1" });
			});
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
     
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
	        app.UseSwaggerUI(c =>
		    {
			    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
