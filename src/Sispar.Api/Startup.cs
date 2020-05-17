using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sispar.Api.Profiles;
using Sispar.Startup;
using System;

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

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TithersProfile());
                mc.AddProfile(new TitheProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

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
                            // Debug.WriteLine("usu�rio autenticado: " + context.HttpContext.User.Claims);
                            return Task.CompletedTask;
                        },

                        OnAuthenticationFailed = context => {
                            // ctx.Log.Add(new Log(){})
                            // ctx.Savechanges()
                            // Debug.WriteLine("usu�rio n�o autenticado: " + context.HttpContext.User.Claims);
                            return Task.CompletedTask;
                        }
                    };
                });
                */

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Sispar - Doc",
                        Version = "v1",
                        // Description = "Exemplo de API REST criada com o ASP.NET Core 3.0 para consulta a indicadores econ�micos",
                        Contact = new OpenApiContact
                        {
                            Email = "factorysolutionit@outlook.com",
                            Name = "Factory Solution IT",
                            Url = new Uri("http://factorysolutionit.com.br")
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
            //         Description = "Entre com o token<br>(N�O ESQUE�A DO <strong>bearer</strong> na frente)",
            //         Name = "Authorization",
            //          In =  "header",
            //         Type = "apiKey"
            //     });*/

            //     //s.AddSecurityRequirement(security);
            // });

            DependencyResolver.Resolve(services);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Startup));
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
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "SisparAPI");
                s.RoutePrefix = "api/docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}