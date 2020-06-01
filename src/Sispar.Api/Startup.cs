using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sispar.Api.Filters;
using Sispar.Api.Profiles;
using Sispar.Domain.UserModule.Commands;
using Sispar.Startup;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            services.AddControllers(options => options.Filters.Add<NotificationFilter>());

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TitherProfile());
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
            // var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(Configuration["SecurityKey"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { }}
                };

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Entre com o token<br>(NÃO ESQUEÇA DO <strong>bearer</strong> na frente)",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });

            DependencyResolver.Resolve(services);
            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseCors("MyPolicy");

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
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