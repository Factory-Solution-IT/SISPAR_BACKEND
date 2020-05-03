using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sispar.Startup;

namespace Sispar.Api
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
            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));


            // services.AddDbContext<SisparDataContext>(options => {
            //     //options.UseSqlServer("Server=sql5059.site4now.net;Database=DB_A5E01E_sisparhomolog;User Id=DB_A5E01E_sisparhomolog_admin;Password=metal001;");
            //     options.UseSqlServer(_config.GetConnectionString("SisparDbConn"));
            // });
            // Bearer ou Basic (Usuario|Senha) em Base64
            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "sispar",
                        ValidAudience = "sispar/client",

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["SecurityKey"])
                        ),

                        ClockSkew = System.TimeSpan.Zero


                    };

                    options.Events = new JwtBearerEvents()
                    {

                        OnTokenValidated = context => {
                            // ctx.Log.Add(new Log(){})
                            // ctx.Savechanges()
                            // Debug.WriteLine("usuário autenticado: " + context.HttpContext.User.Claims);
                            return Task.CompletedTask;
                        },

                        OnAuthenticationFailed = context => {
                            // ctx.Log.Add(new Log(){})
                            // ctx.Savechanges()
                            // Debug.WriteLine("usuário não autenticado: " + context.HttpContext.User.Claims);
                            return Task.CompletedTask;
                        }


                    };
                });
                */

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Indicadores Econômicos",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.0 para consulta a indicadores econômicos",
                        Contact = new OpenApiContact
                        {
                            Name = "Renato Groffe",
                            Url = new Uri("https://github.com/renatogroffe")
                        }
                    });
            });

            // Add Swagger
            // services.AddSwaggerGen(s => {

            //     s.SwaggerDoc("v1", new OpenApiInfo
            //     {
            //         Title = "Sispar - Doc",
            //         Version = "v1",
            //         Contact = new  OpenApiContact
            //         {
            //             Email = "factorysolutionit@outlook.com",
            //             Name = "Factory Solution IT",
            //             Url = new Uri("http://factorysolutionit.com.br")
            //         }
            //     });


            //     /*var security = new Dictionary<string, IEnumerable<string>>
            //     {
            //         { "Bearer", new string[] { }}
            //     };*/

            //     /*s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //     {
            //         Description = "Entre com o token<br>(NÃO ESQUEÇA DO <strong>bearer</strong> na frente)",
            //         Name = "Authorization",
            //          In =  "header",
            //         Type = "apiKey"
            //     });*/

            //     //s.AddSecurityRequirement(security);
            // });

            DependencyResolver.Resolve(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "FNStoreAPI");
                s.RoutePrefix = "api/docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
