using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using SmartMenu.DbContext;
using SmartMenu.DbContext.Infrastructure;

namespace SmartMenu.Web.Api
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
            services
                  .AddDbContext<SmartMenuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SmartMenuDbContext")))
                  .AddSingleton(new SmartMenuDbContextFactory(Configuration.GetConnectionString("SmartMenuDbContext")));
           
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes("Simple SHR Secret");
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(
            //      "CorsPolicy",
            //      builder => builder.WithOrigins("http://localhost:4200")
            //      .AllowAnyMethod()
            //      .AllowAnyHeader()
            //      .AllowCredentials());
            //});

            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "SmartMenu";
                document.Version = "v1";
                document.Title = "ToDo API";
                document.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });
                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
            });

            services
                  .AddMvc()
                  .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                  .AddJsonOptions(options =>
                  {
                      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                      options.JsonSerializerOptions.PropertyNamingPolicy = null;
                  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
