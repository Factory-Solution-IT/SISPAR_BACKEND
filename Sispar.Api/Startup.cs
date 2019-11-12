using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sispar.Startup;
using Swashbuckle.AspNetCore.Swagger;

namespace Sispar.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Bearer ou Basic (Usuario|Senha) em Base64
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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


            // Add Swagger
            services.AddSwaggerGen(s => {

                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Sispar - Doc",
                    Version = "v1",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                    {
                        Email = "factorysolutionit@outlook.com",
                        Name = "Factory Solution IT",
                        Url = "http://factorysolutionit.com.br"
                    }
                });


                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { }}
                };

                s.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "Entre com o token<br>(NÃO ESQUEÇA DO <strong>bearer</strong> na frente)",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                s.AddSecurityRequirement(security);
            });

            DependencyResolver.Resolve(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Deve ser antes do MVC
            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "FNStoreAPI");
                s.RoutePrefix = "api/docs";
            });
        }
    }
}
