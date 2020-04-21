using Alsync.Application;
using Alsync.Domain.Repositories;
using Alsync.Domain.Repositories.EntityFramework;
using Alsync.IApplication;
using Alsync.Infrastructure.DependencyInjection;
using Alsync.Infrastructure.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alsync.Api
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
            //services.AddDbContext<AlsyncDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AlsyncDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepositoryContext, AlsyncRepositoryContext>();

            var payloadConfig = this.Configuration.GetSection("Jwt").GetSection("Payload");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //JwtBearer认证中，默认是通过Http的Authorization头来获取的，这也是最推荐的做法，但是在某些场景下，我们可能会使用Url或者是Cookie来传递Token
                //http://www.cnblogs.com/RainingNight/p/jwtbearer-authentication-in-asp-net-core.html#自定义token获取方式
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        context.Token = context.Request.Query["access_token"];
                        await Task.CompletedTask;
                    }
                };
                //JwtBearer认证配置
                var key = Encoding.UTF8.GetBytes(payloadConfig["Secret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = payloadConfig["iss"],
                    ValidAudience = payloadConfig["aud"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            })
            .AddJwtBearer("Admin", options =>
            {
                //JwtBearer认证中，默认是通过Http的Authorization头来获取的，这也是最推荐的做法，但是在某些场景下，我们可能会使用Url或者是Cookie来传递Token
                //http://www.cnblogs.com/RainingNight/p/jwtbearer-authentication-in-asp-net-core.html#自定义token获取方式
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        context.Token = context.Request.Query["access_token"];
                        await Task.CompletedTask;
                    }
                };
                //JwtBearer认证配置
                var key = Encoding.UTF8.GetBytes(payloadConfig["Secret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = payloadConfig["iss"],
                    ValidAudience = payloadConfig["aud"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Alsync Api v1 docs"
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Alsync Api v2 docs"
                });
                Directory.GetFiles(AppContext.BaseDirectory, "*.xml").ToList().ForEach(p => options.IncludeXmlComments(p));

                options.OperationFilter<HttpHeaderOperationFilter>();
            });

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration["Redis:Configuration"];
            //    options.InstanceName = Configuration["Redis:InstanceName"];
            //});
            services.AddCache()
                .AddRedis(options =>
                {
                    options.Configuration = Configuration["Redis:Configuration"];
                    options.InstanceName = Configuration["Redis:InstanceName"];
                });

            var serviceProvider = services.BuildServiceProvider();
            ServiceLocator.Instance.ConfirgureServiceProvider(serviceProvider);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(WebApiExceptionFilterAttribute));
                options.Filters.Add(typeof(WebApiActionFilterAttribute));
            })
                .AddApplicationPart(typeof(V1.Controllers.HttpController).Assembly)
                .AddApplicationPart(typeof(V2.Controllers.HttpController).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStatusCodePages();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            })
                .UseSwaggerUI(options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
                });
        }
    }
}
