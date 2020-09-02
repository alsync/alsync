using Alsync.Application;
using Alsync.Domain.Repositories;
using Alsync.Domain.Repositories.EntityFramework;
using Alsync.IApplication;
using Alsync.Infrastructure.DependencyInjection;
using Alsync.Infrastructure.Mvc.Filters;
using Consul;
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
            services.AddCustomServices(Configuration);

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

                // Add security definitions
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<AuthorizeOperationFilter>();
                //Use below code to replace AuthorizeOperationFilter.
                //var jwtBearerScheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } };
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement { [jwtBearerScheme] = Array.Empty<string>() });
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

            app.UseAuthorization();

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

            app.RegisterConsul(this.Configuration);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class AppServiceServiceCollectionExtensions
    {
        /// <summary>
        /// 注入自定义服务。
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<AlsyncDbContext>(options =>
            {
                options.UseLoggerFactory(LoggerFactory.Create(configure =>
                {
                    configure.AddConsole();
                    configure.AddDebug();
                }))
                    .UseLazyLoadingProxies()
                    //.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAppServices()
                .AddRepositories();

            services.AddScoped<IRepositoryContext, AlsyncRepositoryContext>();

            return services;
        }

        /// <summary>
        /// 注入应用服务。
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            var appServices = from m in Assembly.GetAssembly(typeof(ApplicationService)).GetTypes()
                              where m.IsClass && m.IsSubclassOf(typeof(ApplicationService))
                              select m;
            foreach (var service in appServices)
            {
                var iAppServiceTypes = service.GetInterfaces();
                foreach (var iService in iAppServiceTypes)
                {
                    services.AddScoped(iService, service);
                }
            }

            return services;
        }

        /// <summary>
        /// 注入仓储服务。
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var repositories = from m in Assembly.GetAssembly(typeof(EntityFrameworkRepository<>)).GetTypes()
                               where m.IsClass
                               && (m.BaseType?.IsGenericType ?? false)
                               && m.BaseType.GetGenericTypeDefinition() == typeof(EntityFrameworkRepository<>)
                               select m;
            foreach (var repository in repositories)
            {
                var iRepositoryTypes = repository.GetInterfaces();
                foreach (var iRepository in iRepositoryTypes)
                {
                    services.AddScoped(iRepository, repository);
                }
            }

            return services;
        }
    }

    public static class ConsulApplicationBuilderExtensions
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration)
        {

            var client = new ConsulClient(config =>
            {
                config.Address = new Uri("http://192.168.222.135:8500");
                config.Datacenter = "dc1";
            });

            //register
            client.Agent.ServiceRegister(new AgentServiceRegistration
            {
                ID = Guid.NewGuid().ToString("N"),
                Name = "alsync",
                //Address = configuration["ip"],
                //Port = int.Parse(configuration["port"]),
                Address = "192.168.222.133",
                Port = 2617,
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10),
                    Interval = TimeSpan.FromSeconds(10),
                    //HTTP = $"http://{configuration["ip"]}:{configuration["port"]}/api/health",
                    HTTP = "http://192.168.222.133:2617/api/healthcheck",
                    Timeout = TimeSpan.FromSeconds(5)
                }
            });

            //invoke in another place.
            var serviceDicts = client.Agent.Services().Result.Response.Where(m => m.Value.Service.Equals("alsync", StringComparison.OrdinalIgnoreCase));
            foreach (var service in serviceDicts)
            {
                //new Uri("").Scheme
                //service.Value.Address
            }

            return app;
        }
    }
}
