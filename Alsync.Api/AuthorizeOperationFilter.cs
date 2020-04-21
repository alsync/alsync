using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();
            var allowAnonymous = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AllowAnonymousAttribute>();
            if (attributes.Any() && !allowAnonymous.Any())
            {
                //.net core 2.0
                //var parameter = new OpenApiParameter
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Description = "Access Token",
                //    Required = true
                //};
                //operation.Parameters.Add(parameter);

                //.net core 3.1
                var jwtBearerScheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } };
                operation.Security = new List<OpenApiSecurityRequirement> {
                    new OpenApiSecurityRequirement { [jwtBearerScheme] = Array.Empty<string>() }
                };
            }
        }
    }
}
