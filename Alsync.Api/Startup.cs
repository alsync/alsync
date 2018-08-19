using Alsync.Application;
using Alsync.Domain.Repositories;
using Alsync.Domain.Repositories.EntityFramework;
using Alsync.IApplication;
using Alsync.Infrastructure.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
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
            services.AddDbContext<AlsyncDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(WebApiExceptionFilterAttribute));
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepositoryContext, AlsyncRepositoryContext>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Alsync Api"
                });
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Alsync.Api.xml");
                //options.IncludeXmlComments(xmlPath);
            });

            //var pathToDoc = Configuration["Swagger:FileName"];
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "Geo Search API",
            //            Version = "v1",
            //            Description = "A simple api to search using geo location in Elasticsearch",
            //            TermsOfService = "None"
            //        }
            //     );

            //    var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
            //    options.IncludeXmlComments(filePath);
            //    options.DescribeAllEnumsAsStrings();
            //});

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
                var key = Encoding.ASCII.GetBytes(payloadConfig["Secret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role,

                    ValidIssuer = payloadConfig["iss"],

                    ValidAudience = payloadConfig["aud"],

                    IssuerSigningKey = new SymmetricSecurityKey(key),


                    /***********************************TokenValidationParameters的参数默认值***********************************/
                    // RequireSignedTokens = true,
                    // SaveSigninToken = false,
                    // ValidateActor = false,
                    // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                    //ValidateAudience = true,
                    //ValidateIssuer = true,
                    // ValidateIssuerSigningKey = false,
                    // 是否要求Token的Claims中必须包含Expires
                    // RequireExpirationTime = true,
                    // 允许的服务器时间偏移量
                    // ClockSkew = TimeSpan.FromSeconds(300),
                    // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    // ValidateLifetime = true
                };
            });
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
            app.UseStatusCodePages();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger(options => options.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value));
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs"));
        }
    }
}
